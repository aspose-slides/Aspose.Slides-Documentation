---
title: Modern API ile Görüntü İşleme Geliştirme
linktitle: Modern API
type: docs
weight: 237
url: /tr/net/modern-api/
keywords:
- System.Drawing
- modern API
- çizim
- slayt küçük resmi
- slayttan görüntüye
- şekil küçük resmi
- şekilden görüntüye
- sunum küçük resmi
- sunumdan görüntülere
- görüntü ekle
- resim ekle
- .NET
- C#
- Aspose.Slides
description: "Slayt görüntü işleme sürecini, kullanımdan kaldırılmış görüntü API'lerini .NET Modern API ile değiştirerek sorunsuz PowerPoint ve OpenDocument otomasyonu sağlayacak şekilde modernleştirin."
---
## **Giriş**

Tarihsel olarak, Aspose Slides, System.Drawing'e bir bağımlılığı vardır ve ortak API'de aşağıdaki sınıfları içerir:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

24.4 sürümünden itibaren bu ortak API'nin kullanımdan kaldırıldığı belirtilmiştir.

.NET6 ve üzeri sürümlerde System.Drawing desteği Windows dışı platformlar için kaldırıldığı için ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides iki paketli bir yaklaşım benimsemiştir:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – Windows için .NET6+, Windows/Linux/MacOS için .NETStandard, Windows için .NETFramework 2+ desteği.
  - [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) paketine bağımlıdır.
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – bağımlılıkları olmayan Windows/Linux/MacOS sürümü.

[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) paketinin dezavantajı, aynı ad alanında (namespace) System.Drawing’in kendi sürümünü uygulamasıdır (ortak API ile geriye dönük uyumluluğu sağlamak için). Bu nedenle Aspose.Slides.NET6.CrossPlatform ve .NET Framework’ten gelen System.Drawing ya da System.Drawing.Common paketi aynı anda kullanıldığında alias kullanılmadıkça isim çakışması oluşur.

Ana Aspose.Slides.NET paketindeki System.Drawing bağımlılıklarından kurtulmak amacıyla, sözde “Modern API” eklendi – yani, kullanımdan kaldırılan API yerine kullanılacak, imzalarında System.Drawing’den gelen [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) ve [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) tiplerine bağımlı olmayan API. [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ve [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) sınıfları kullanımdan kaldırıldı ve ortak Slides API'sinden çıkarıldı.

Güncel sürümlerde System.Drawing’e bağımlı ortak API’yi eski/kullanımdan kaldırılmış olarak değerlendirin. Yeni kodlar ve mevcut görüntü‑işleme iş akışlarını taşırken Modern API’yı kullanın.

## **Modern API**

Ortak API'ye aşağıdaki sınıflar ve enum'lar eklendi:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) - görüntünün dosya formatını temsil eder.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/tr/net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) arayüzünü oluşturmak ve onunla çalışmak için yöntemler.

Lütfen [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesinin disposable olduğunu unutmayın ( [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) arayüzünü uygular ve kullanımı `using` bloğu içinde ya da başka uygun bir şekilde dispose edilmelidir).

`GetImage` tek bir slayt ya da şekil oluşturmak için, `GetImages` birden çok sunum slaytı oluşturmak için kullanılır. Görüntüleri yüklemek için [Images](https://reference.aspose.com/slides/tr/net/aspose.slides/images/) yöntemlerini, bir sunuma eklemek için `AddImage` ile [IImage] nesnesini, mevcut bir sunum görüntüsünü güncellemek için `ReplaceImage` ile [IImage] nesnesini kullanın.

Yeni API’nin tipik bir kullanım senaryosu şu şekilde olabilir:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // diskteki dosyadan IImage'in disposable bir örneğini oluştur.
    using (IImage image = Images.FromFile("image.png"))
    {
        // IImage örneğini sunumun görüntülerine ekleyerek bir PowerPoint görüntüsü oluştur.
        ppImage = pres.Images.AddImage(image);
    }

    // slide #1 üzerine bir resim şekli ekle
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // slide #1'i temsil eden IImage örneğini al.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // görüntüyü diske kaydet.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Eski Kodu Modern API ile Değiştirme**

Geçişi kolaylaştırmak amacıyla yeni [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) arayüzü, [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) ve [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) sınıflarının ayrı imzalarını yinelemektedir. Genel olarak, System.Drawing kullanan eski yöntemi yeni yöntemle değiştirmeniz yeterli olacaktır.

### **Bir Slayt Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Bir Şekil Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Bir Sunum Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:
``` csharp
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

Modern API:
``` csharp
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

### **Bir Sunuma Resim Ekleme**

Eski/kullanımdan kaldırılmış API:
``` csharp
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

Modern API:
``` csharp
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

## **Kullanımdan Kaldırılan Yöntemler/Özellikler ve Modern API’deki Yerine Kullanımları**

### **Presentation**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/tr/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/tr/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Yöntem/Özellik İmzası | Yerine Kullanılacak Yöntem İmzası |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/tr/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/tr/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/tr/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/tr/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Yöntem İmzası | Yerine Kullanılacak Yöntem İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/tr/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Graphics ve PrinterSettings İçin API Desteği**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) sınıfı .NET6 ve üzeri platformlarda çapraz‑platform sürümler için desteklenmez. Aspose Slides’te, [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) üzerine render yapan API yerine Modern API görüntü‑renderleme yöntemlerini kullanın:
[ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Ayrıca, [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) ile ilgili API’nin doğrudan bir Modern API karşılığı bulunmamaktadır:

[IPresentation](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/print/#print_2)

## **SSS**

**[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) neden kaldırıldı?**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) desteği, render işlemleri ve görüntülerle çalışma birleştirilerek, platform‑spesifik bağımlılıklar ortadan kaldırılarak ve [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) ile çapraz‑platform yaklaşımına geçiş sağlanarak ortak API'den kullanımdan kaldırıldı. [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) yerine `GetImage` ya da `GetImages` kullanın.

**[IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) , [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) / [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) yerine pratik faydası nedir?**

[IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) raster ve vektör görüntülerle çalışmayı tek bir arabirimde birleştirir, [ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) aracılığıyla çeşitli formatlarda kaydetmeyi basitleştirir, `System.Drawing` bağımlılığını azaltır ve kodun ortamlar arasında taşınabilirliğini artırır.

**Modern API küçük resim oluşturma performansını etkiler mi?**

`GetThumbnail` yerine `GetImage` kullanmak performansı düşürmez; yeni yöntemler aynı seçenekler ve boyutlarla görüntü üretme yeteneğini sağlar. Kazanç ya da kayıp senaryoya bağlıdır, işlevsel olarak ortam eşdeğerdir.