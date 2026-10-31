using System;
using System.Buffers.Binary;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;

// Original deterministic fixture pixels and a small portable 8-bit PNG codec.
// No operating-system bitmap engine or external image/font download is used.
internal static class PortableImage
{
    public sealed record Pixels(int Width, int Height, byte[] Rgba);
    public static byte[] Png(int width, int height, Color color)
    {
        byte[] pixels = new byte[checked(width * height * 4)];
        for (int y=0;y<height;y++) for(int x=0;x<width;x++)
        {
            double dx=(x-width/2.0)/(width/4.0),dy=(y-height/2.0)/(height/4.0);
            Color c=dx*dx+dy*dy<=1?Color.White:color; int i=(y*width+x)*4;
            pixels[i]=c.R;pixels[i+1]=c.G;pixels[i+2]=c.B;pixels[i+3]=255;
        }
        return Encode(new Pixels(width,height,pixels));
    }
    public static byte[] Fit(byte[] data,int width,int height,bool crop)
    {
        var input=Decode(data);byte[] pixels=new byte[checked(width*height*4)];Array.Fill(pixels,(byte)255);
        double scale=crop?Math.Max((double)width/input.Width,(double)height/input.Height):Math.Min((double)width/input.Width,(double)height/input.Height);
        double left=(width-input.Width*scale)/2,top=(height-input.Height*scale)/2;
        for(int y=0;y<height;y++)for(int x=0;x<width;x++)
        {int sx=(int)Math.Floor((x-left)/scale),sy=(int)Math.Floor((y-top)/scale);if(sx>=0&&sy>=0&&sx<input.Width&&sy<input.Height)Array.Copy(input.Rgba,(sy*input.Width+sx)*4,pixels,(y*width+x)*4,4);}
        return Encode(new Pixels(width,height,pixels));
    }
    public static double Difference(string first,string second)
    {
        var a=Decode(File.ReadAllBytes(first));var b=Decode(File.ReadAllBytes(second));
        if(a.Width!=b.Width||a.Height!=b.Height)throw new InvalidDataException("Render dimensions differ.");
        double total=0;long count=0;
        for(int y=0;y<a.Height;y+=3)for(int x=0;x<a.Width;x+=3)for(int c=0;c<3;c++){int i=(y*a.Width+x)*4+c;total+=Math.Abs(a.Rgba[i]-b.Rgba[i]);count++;}
        return total/count;
    }
    public static byte[] Encode(Pixels image)
    {
        using var output=new MemoryStream();output.Write(new byte[]{137,80,78,71,13,10,26,10});
        byte[] header=new byte[13];BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(0,4),image.Width);BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(4,4),image.Height);header[8]=8;header[9]=6;Chunk(output,"IHDR",header);
        using var compressed=new MemoryStream();using(var z=new ZLibStream(compressed,CompressionLevel.Optimal,true))for(int y=0;y<image.Height;y++){z.WriteByte(0);z.Write(image.Rgba,y*image.Width*4,image.Width*4);}
        Chunk(output,"IDAT",compressed.ToArray());Chunk(output,"IEND",Array.Empty<byte>());return output.ToArray();
    }
    private static void Chunk(Stream stream,string type,byte[] data)
    {
        byte[] name=Encoding.ASCII.GetBytes(type),size=new byte[4];BinaryPrimitives.WriteInt32BigEndian(size,data.Length);stream.Write(size);stream.Write(name);stream.Write(data);
        uint crc=0xffffffff;foreach(byte value in name)crc=Crc(crc,value);foreach(byte value in data)crc=Crc(crc,value);BinaryPrimitives.WriteUInt32BigEndian(size,crc^0xffffffff);stream.Write(size);
    }
    private static uint Crc(uint crc,byte value){crc^=value;for(int i=0;i<8;i++)crc=(crc&1)!=0?0xedb88320^(crc>>1):crc>>1;return crc;}
    public static Pixels Decode(byte[] png)
    {
        if(png.Length<33||!png.AsSpan(0,8).SequenceEqual(new byte[]{137,80,78,71,13,10,26,10}))throw new InvalidDataException("Invalid PNG fixture.");
        int width=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(16,4)),height=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(20,4));int type=png[25];
        if(png[24]!=8||png[28]!=0)throw new InvalidDataException("This fixture helper requires noninterlaced 8-bit PNG.");
        int channels=type switch{0=>1,2=>3,3=>1,4=>2,6=>4,_=>throw new InvalidDataException("Unsupported PNG color type.")};
        using var idat=new MemoryStream();byte[] palette=Array.Empty<byte>(),alpha=Array.Empty<byte>();
        for(int p=8;p+12<=png.Length;){int n=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(p,4));string name=Encoding.ASCII.GetString(png,p+4,4);if(n<0||p+12L+n>png.Length)throw new InvalidDataException("Invalid PNG chunk.");if(name=="IDAT")idat.Write(png,p+8,n);if(name=="PLTE")palette=png.AsSpan(p+8,n).ToArray();if(name=="tRNS")alpha=png.AsSpan(p+8,n).ToArray();p+=12+n;}
        idat.Position=0;using var z=new ZLibStream(idat,CompressionMode.Decompress);int stride=checked(width*channels);byte[] previous=new byte[stride],row=new byte[stride],pixels=new byte[checked(width*height*4)];
        for(int y=0;y<height;y++)
        {
            int filter=z.ReadByte();z.ReadExactly(row);for(int i=0;i<stride;i++){int a=i>=channels?row[i-channels]:0,b=previous[i],c=i>=channels?previous[i-channels]:0;row[i]=unchecked((byte)(row[i]+(filter switch{0=>0,1=>a,2=>b,3=>(a+b)/2,4=>Paeth(a,b,c),_=>throw new InvalidDataException("Invalid PNG filter.")})));}
            for(int x=0;x<width;x++){int s=x*channels,d=(y*width+x)*4;if(type==3){int k=row[s];pixels[d]=palette[k*3];pixels[d+1]=palette[k*3+1];pixels[d+2]=palette[k*3+2];pixels[d+3]=k<alpha.Length?alpha[k]:(byte)255;}else{pixels[d]=row[s];pixels[d+1]=type is 0 or 4?row[s]:row[s+1];pixels[d+2]=type is 0 or 4?row[s]:row[s+2];pixels[d+3]=type==6?row[s+3]:type==4?row[s+1]:(byte)255;}}
            (previous,row)=(row,previous);
        }
        return new Pixels(width,height,pixels);
    }
    private static int Paeth(int a,int b,int c){int p=a+b-c,pa=Math.Abs(p-a),pb=Math.Abs(p-b),pc=Math.Abs(p-c);return pa<=pb&&pa<=pc?a:pb<=pc?b:c;}
}
