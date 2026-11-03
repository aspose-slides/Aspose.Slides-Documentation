using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static byte[] Wav()
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes("RIFF"));w.Write(36+1600);w.Write(Encoding.ASCII.GetBytes("WAVEfmt "));w.Write(16);w.Write((short)1);w.Write((short)1);w.Write(8000);w.Write(16000);w.Write((short)2);w.Write((short)16);w.Write(Encoding.ASCII.GetBytes("data"));w.Write(1600);w.Write(new byte[1600]);return m.ToArray();}

    private static byte[] Chunk(string name,byte[] data)
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes(name));w.Write(data.Length);w.Write(data);if(data.Length%2!=0)w.Write((byte)0);return m.ToArray();}

    private static byte[] Bytes(Action<BinaryWriter> fill){using var m=new MemoryStream();using(var w=new BinaryWriter(m,Encoding.UTF8,true))fill(w);return m.ToArray();}

    private static byte[] Avi()
    {
        // One original 8x8 RGB frame in an uncompressed AVI container.
        byte[] frame=Enumerable.Repeat((byte)80,8*8*3).ToArray();
        byte[] avih=Bytes(w=>{w.Write(1000000);w.Write(frame.Length);w.Write(0);w.Write(0x10);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(8);w.Write(8);w.Write(new byte[16]);});
        byte[] strh=Bytes(w=>{w.Write(Encoding.ASCII.GetBytes("vidsDIB "));w.Write(0);w.Write((short)0);w.Write((short)0);w.Write(0);w.Write(1);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(-1);w.Write(0);w.Write((short)0);w.Write((short)0);w.Write((short)8);w.Write((short)8);});
        byte[] strf=Bytes(w=>{w.Write(40);w.Write(8);w.Write(8);w.Write((short)1);w.Write((short)24);w.Write(0);w.Write(frame.Length);w.Write(new byte[16]);});
        byte[] strl=Chunk("LIST",Encoding.ASCII.GetBytes("strl").Concat(Chunk("strh",strh)).Concat(Chunk("strf",strf)).ToArray());
        byte[] hdrl=Chunk("LIST",Encoding.ASCII.GetBytes("hdrl").Concat(Chunk("avih",avih)).Concat(strl).ToArray());
        byte[] movi=Chunk("LIST",Encoding.ASCII.GetBytes("movi").Concat(Chunk("00db",frame)).ToArray());
        return Chunk("RIFF",Encoding.ASCII.GetBytes("AVI ").Concat(hdrl).Concat(movi).ToArray());
    }

    private static (byte[] Audio, byte[] Video, byte[] Ole) CreateInput()
    {
        Example.Setup();byte[] audio=Wav(),video=Avi(),ole=Encoding.UTF8.GetBytes("Original embedded note – no executable content.\n");
        using(var p=new Presentation())
        {using var stream=new MemoryStream(audio);p.Slides[0].Shapes.AddAudioFrameEmbedded(20,20,60,60,stream).Name="../audio";
         p.Slides[0].Shapes.AddVideoFrame(100,20,100,80,p.Videos.AddVideo(video)).Name="Video";
         p.Slides[0].Shapes.AddOleObjectFrame(220,20,80,80,new OleEmbeddedDataInfo(ole,"txt")).Name="../note";
         p.Slides[0].Shapes.AddVideoFrame(320,20,100,80,"https://example.invalid/unfetched.mp4").Name="Linked video";
         p.Slides[0].Shapes.AddAudioFrameLinked(430,20,60,60,"https://example.invalid/unfetched.wav").Name="Linked audio";
         p.Save("output/input.pptx",SaveFormat.Pptx);}
        return (audio, video, ole);
    }
}
