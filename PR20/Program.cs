/*Музыкальный плейлист
Создайте IMusicIterator, PlaylistIterator, Playlist, чтобы реализовать удобную навигацию по песням в плейлисте.*/

using System;
using System.Collections.Generic;

public interface IMusicIterator<T>
{
    bool HasNext();
    T Next();
}

public interface IPlaylist<T>
{
    IMusicIterator<T> CreateIterator();
}

public class PlaylistIterator : IMusicIterator<string>
{
    private List<string> _playlist;
    private int _position = 0;

    public PlaylistIterator(List<string> playlist)
    {
        _playlist = playlist;
    }

    public bool HasNext()
    {
        return _position < _playlist.Count;
    }

    public string Next()
    {
        if (!HasNext()) throw new InvalidOperationException("Больше нет песен.");
        return _playlist[_position++];
    }
}

public class Playlist : IPlaylist<string>
{
    private List<string> _playlist = new List<string>();

    public void Add(string song)
    {
        _playlist.Add(song);
    }

    public IMusicIterator<string> CreateIterator()
    {
        return new PlaylistIterator(_playlist);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();
        playlist.Add("Kai Angel - amy");
        playlist.Add("лиззз - БСНЖ");
        playlist.Add("LAZZY2WICE - Soldier of Cola");
        playlist.Add("Girl Tones - High and Dry");
        playlist.Add("ssshhhiiittt - Танцы");
        playlist.Add("julie - lochness");

        IMusicIterator<string> iterator = playlist.CreateIterator();

        Console.WriteLine("Плейлист:");
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}