using System;
using System.Collections.Generic;

namespace musicPlayer
{
    enum RandomizeType
    {
        Shuffle,
        Random,
        FisherYatesShuffle,
        None,
    }
    class Randomizer
    {
        Random _random;
        RandomizeType _lastRandomizeType = RandomizeType.None;
        private Stack<uint> _songList = new Stack<uint>();
        private int _listState = 0;
        public uint SongCount = 0;

        public void SongPlaying(int idx)
        {
            if (_songList.Count == 0 || _songList.Peek() != (uint)idx)
                _songList.Push((uint)idx);
        }
        public uint GetNext()
        {
            if (SongCount == 0)
                return 0;

            if (_songList.Count == 0)
                _listState = 0;

            if (_listState != -1)
            {
                _listState = 1;
                uint next = 0;
                switch (Settings.settings.RandomizeType)
                {
                    case RandomizeType.None:
                        next = RandomizeNone();
                        break;
                    case RandomizeType.Shuffle:
                        next = RandomizeShuffle();
                        break;
                    case RandomizeType.Random:
                        next = RandomizeRandom();
                        break;
                    case RandomizeType.FisherYatesShuffle:
                        next = RandomizeFisherYatesShuffle();
                        break;
                    default:
                        break;
                }
                _songList.Push(next);
                _lastRandomizeType = Settings.settings.RandomizeType;
                return next;
            }
            else
            {
                _lastRandomizeType = Settings.settings.RandomizeType;
                return _songList.Pop();
            }
        }
        public uint GetPrev()
        {
            if (SongCount == 0)
                return 0;

            if (_songList.Count == 0)
                _listState = 0;

            if (_listState != 1)
            {
                _listState = -1;
                uint prev = 0;
                switch (Settings.settings.RandomizeType)
                {
                    case RandomizeType.None:
                        prev = RandomizeNone(false);
                        break;
                    case RandomizeType.Shuffle:
                        prev = RandomizeShuffle();
                        break;
                    case RandomizeType.Random:
                        prev = RandomizeRandom();
                        break;
                    case RandomizeType.FisherYatesShuffle:
                        prev = RandomizeFisherYatesShuffle();
                        break;
                    default:
                        break;
                }
                _songList.Push(prev);
                _lastRandomizeType = Settings.settings.RandomizeType;
                return prev;
            }
            else
            {
                _lastRandomizeType = Settings.settings.RandomizeType;
                return _songList.Pop();
            }
        }

        public Randomizer()
        {
            _random = new Random(new Random().Next(0, int.MaxValue));
        }

        // ------------------------------------------------------------------------------
        // not the cleanest solution, purpose is learing about randomize functions & .net
        // so this is not a real problem
        // ------------------------------------------------------------------------------
        //randomize functions

        List<uint> _shuffledList = new List<uint>();
        int _shuffleIdx = 0;
        uint RandomizeNone(bool next = true)
        {
             return Math.Min(_songList.Peek() + (uint)(next ? +1 : -1), SongCount);
        }
        uint RandomizeShuffle()
        {
            if (_lastRandomizeType != RandomizeType.Shuffle)
            {
                _shuffledList.Clear();
                for (uint i = 0; i < SongCount; i++)
                {
                    _shuffledList.Add(i);
                }
                _shuffledList.Shuffle(_random, 1000);
                _shuffleIdx = 0;
            }
            else
                _shuffleIdx = (_shuffleIdx + 1) % (int)SongCount;

            return _shuffledList[_shuffleIdx];
        }
        uint RandomizeFisherYatesShuffle()
        {
            if (_lastRandomizeType != RandomizeType.Shuffle)
            {
                _shuffledList.Clear();
                for (uint i = 0; i < SongCount; i++)
                {
                    _shuffledList.Add(i);
                }
                _shuffledList.FisherYatesShuffle(_random);
                _shuffleIdx = 0;
            }
            else
                _shuffleIdx = (_shuffleIdx + 1) % (int)SongCount;

            return _shuffledList[_shuffleIdx];
        }
        uint RandomizeRandom()
        {
            return (uint)_random.Next((int)SongCount);
        }

    }
    static class ListExtensions
    {
        //https://stackoverflow.com/questions/273313/randomize-a-listt
        public static void FisherYatesShuffle<T>(this IList<T> list, Random rnd)
        {
            for (var i = list.Count; i > 0; i--)
                list.Swap(i, rnd.Next(0, i));
        }
        public static void Shuffle<T>(this IList<T> list, Random rnd, int shuffleCount)
        {
            for (int i = 0; i < shuffleCount; i++)
            {
                list.Swap(rnd.Next(0, list.Count), rnd.Next(0, list.Count));
            }
        }
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
