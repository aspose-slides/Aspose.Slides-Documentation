---
title: Meningkatkan Pemrosesan Gambar dengan Modern API
linktitle: API Modern
type: docs
weight: 234
url: /id/net/modern-api/
keywords:
- System.Drawing
- API modern
- menggambar
- thumbnail slide
- slide menjadi gambar
- thumbnail bentuk
- bentuk menjadi gambar
- thumbnail presentasi
- presentasi menjadi gambar
- menambah gambar
- menambah gambar
- .NET
- C#
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API imaging yang usang menggunakan .NET Modern API untuk otomatisasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

Secara historis, Aspose Slides memiliki ketergantungan pada System.Drawing dan memiliki di API publik kelas-kelas berikut dari sana:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Mulai versi 24.4, API publik ini dinyatakan usang.

Karena dukungan System.Drawing pada versi .NET6 ke atas dihapus untuk versi non-Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides telah mengimplementasikan pendekatan dua paket:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - mendukung .NET6+ untuk Windows, .NETStandard untuk Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - memiliki ketergantungan pada [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - versi Windows/Linux/MacOS tanpa ketergantungan.

Ketidaknyamanan [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) adalah bahwa ia mengimplementasikan versi sendiri dari System.Drawing dalam namespace yang sama (untuk mendukung kompatibilitas mundur dengan API publik). Jadi, ketika Aspose.Slides.NET6.CrossPlatform dan System.Drawing dari .NET Framework atau paket System.Drawing.Common digunakan bersamaan, terjadi konflik nama kecuali alias digunakan.

Untuk menghilangkan ketergantungan pada System.Drawing di paket utama Aspose.Slides.NET, kami menambahkan apa yang disebut "Modern API" – yaitu API yang harus digunakan sebagai pengganti yang usang, yang tanda tangannya memiliki ketergantungan pada tipe berikut dari System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) dan [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) dan [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) dinyatakan usang dan dukungannya dihapus dari API Slides publik.

Pada versi saat ini, anggap API publik yang bergantung pada System.Drawing sebagai warisan/usang. Gunakan Modern API untuk kode baru dan saat memigrasikan alur kerja pemrosesan gambar yang ada.

## **Modern API**

Ditambahkan kelas dan enum berikut ke API publik:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) - mewakili gambar raster atau vektor.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) - mewakili format berkas gambar.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) - metode untuk membuat dan bekerja dengan antarmuka [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

Harap perhatikan bahwa [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) dapat dibuang (menerapkan antarmuka [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) dan penggunaannya harus dibungkus dalam using atau dibuang dengan cara yang nyaman lainnya).

Gunakan `GetImage` untuk merender satu slide atau bentuk. Gunakan `GetImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) untuk memuat gambar, `AddImage` dengan [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `ReplaceImage` dengan [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) untuk memperbarui gambar presentasi yang ada.

Skenario tipikal penggunaan API baru mungkin terlihat seperti berikut:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instansiasi instance IImage yang dapat dibuang dari file di disk.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
        ppImage = pres.Images.AddImage(image);
    }

    // tambahkan bentuk gambar pada slide #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // dapatkan instance IImage yang mewakili slide #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // simpan gambar ke disk.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Mengganti Kode Lama dengan Modern API**

Untuk memudahkan transisi, antarmuka [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) mengulangi tanda tangan terpisah dari kelas [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) dan [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Secara umum, Anda hanya perlu mengganti pemanggilan metode lama yang menggunakan System.Drawing dengan yang baru.

### **Mendapatkan Thumbnail Slide**

API warisan/usang:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Modern:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Mendapatkan Thumbnail Bentuk**

API warisan/usang:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Modern:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Mendapatkan Thumbnail Presentasi**

API warisan/usang:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API Modern:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **Menambahkan Gambar ke Presentasi**

API warisan/usang:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API Modern:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **Metode/Properti Usang dan Penggantiannya dalam Modern API**

### **Presentation**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Tanda Tangan Metode/Properti | Tanda Tangan Metode Pengganti |
|------------------------------|-------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|---------------------|-------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Dukungan API untuk Graphics dan PrinterSettings**

Kelas [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) tidak didukung untuk versi lintas platform .NET6 ke atas. Di Aspose Slides, gunakan metode render gambar Modern API alih-alih API yang merender ke [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Selain itu, API yang terkait dengan pencetakan melalui [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) tidak memiliki pengganti Modern API yang langsung:
[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Mengapa [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) dihapus?

Dukungan untuk [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) dinyatakan usang di API publik untuk menyatukan kerja dengan rendering dan gambar, menghilangkan ketergantungan khusus platform, dan beralih ke pendekatan lintas platform dengan [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Gunakan `GetImage` atau `GetImages` alih-alih merender ke [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Apa manfaat praktis [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) dibandingkan [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor, menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), mengurangi ketergantungan pada `System.Drawing`, dan membuat kode lebih portabel di berbagai lingkungan.

### Apakah Modern API memengaruhi kinerja pembuatan thumbnail?

Berpindah dari `GetThumbnail` ke `GetImage` tidak memperburuk skenario: metode baru memberikan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil mempertahankan dukungan untuk opsi rendering. Keuntungan atau penurunan spesifik tergantung pada skenario, tetapi secara fungsional penggantiannya setara.