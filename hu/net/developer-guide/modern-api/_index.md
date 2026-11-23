---
title: A képfeldolgozás fejlesztése a Modern API-val
linktitle: Modern API
type: docs
weight: 234
url: /hu/net/modern-api/
keywords:
- System.Drawing
- modern API
- rajzolás
- dia bélyegkép
- dia képpé alakítás
- alakzat bélyegkép
- alakzat képpé alakítás
- prezentáció bélyegkép
- prezentáció képekké alakítás
- kép hozzáadása
- kép beszúrása
- .NET
- C#
- Aspose.Slides
description: "Modernizálja a dia képfeldolgozását az elavult képalkotó API-k helyettesítésével a .NET Modern API-val, a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Történelmileg, Aspose Slides függ a System.Drawing-tól és a nyilvános API-jában a következő osztályok találhatók onnan:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A 24.4-es verziótól kezdve ez a nyilvános API elavultnak van nyilvánítva.

Mivel a System.Drawing támogatás a .NET6 és későbbi verziókban eltávolításra került a nem Windows verziók esetén ([töréspont változás](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), a Slides két csomagos megközelítést valósított meg:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – támogatás .NET6+ Windowsra, .NETStandard Windowsra/Linuxra/MacOS-re, .NETFramework 2+ (Windows).  
  - függ a [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/MacOS verzió függőségek nélkül.

A [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) kényelmetlensége, hogy saját System.Drawing verziót valósít meg ugyanabban a névtérben (az API visszafelé kompatibilitásának támogatására). Így, ha az Aspose.Slides.NET6.CrossPlatform és a .NET Framework-ből vagy a System.Drawing.Common csomagból származó System.Drawing egyszerre van használva, névütközés lép fel, hacsak nem használunk alias-t.

Az System.Drawing-re támaszkodó függőségek eltávolítása érdekében a fő Aspose.Slides.NET csomagban hozzáadtuk a úgynevezett „Modern API”-t – vagyis azt az API-t, amelyet a deprecált helyett kell használni, és amelynek aláírásai a következő System.Drawing típusokra támaszkodnak: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) és [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). A [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) és a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) elavultnak van nyilvánítva, és támogatásuk eltávolításra került a nyilvános Slides API-ból.

A jelenlegi verziókban tekintse a System.Drawing-re támaszkodó nyilvános API-t örököltnek/elavultnak. Új kódhoz és a meglévő képfeldolgozó munkafolyamatok migrálásakor használja a Modern API-t.

## **Modern API**

A következő osztályokat és felsorolásokat (enum) adtuk hozzá a nyilvános API-hoz:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – a raszteres vagy vektorlét ábrázolja.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – a kép fájlformátumát reprezentálja.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – módszerek a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) interfész példányosításához és használatához.

Kérjük vegye figyelembe, hogy [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) disposable (azaz a [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) interfészt valósítja meg, és használatát using blokkban vagy más módon kell lezárni).

Használja a `GetImage`-et egyetlen diák vagy alakzat megjelenítéséhez. Használja a `GetImages`-et több bemutató dia megjelenítéséhez. Használja a [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) módszereket a képek betöltéséhez, a `AddImage`-et a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, és a `ReplaceImage`-et a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) segítségével egy meglévő prezentációs kép frissítéséhez.

Az új API használatának tipikus példája a következő lehet:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // egy lemezről származó IImage eldobható példányának létrehozása.
    using (IImage image = Images.FromFile("image.png"))
    {
        // PowerPoint kép létrehozása egy IImage példány hozzáadásával a prezentáció képeihez.
        ppImage = pres.Images.AddImage(image);
    }

    // kép alakzat hozzáadása a 1. diához
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // egy IImage példány lekérése, amely a 1. diát reprezentálja.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // kép mentése a lemezre.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Régi kód helyettesítése a Modern API-val**

Az átállás megkönnyítése érdekében az új [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) felülete megismétli a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) és [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) osztályok különálló aláírásait. Általában csak a System.Drawing-et használó régi metódushívást kell lecserélni az újra.

### **Dia előnézetének lekérése**

Örökölt/deprecált API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Alakzat előnézetének lekérése**

Örökölt/deprecált API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Prezentáció előnézetének lekérése**

Örökölt/deprecált API:

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

Modern API:

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

### **Kép hozzáadása a prezentációhoz**

Örökölt/deprecált API:

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

Modern API:

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

## **Elavult metódusok/tulajdonságok és azok helyettesítése a Modern API-ban**

### **Presentation**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
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
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
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
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Metódus/Property aláírás | Helyettesítő metódus aláírás |
|---|---|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **API támogatás a Graphics és PrinterSettings számára**

A [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) osztály nem támogatott a .NET6 és újabb keresztplatform verziók esetén. Az Aspose Slides-ben használja a Modern API képrenderelési metódusait a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) renderelő API helyett:
- [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
  - [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
  - [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
  - [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

A [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) használatával kapcsolatos nyomtatási API-nak nincs közvetlen Modern API helyettesítője:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **GYIK**

### Miért lett eltávolítva a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?

A [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) támogatása elavult a nyilvános API-ban, hogy egységesítse a renderelést és a képek kezelését, megszüntesse a platformfüggő függőségeket, és a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) segítségével keresztplatform megközelítésre váltson. Használja a `GetImage` vagy `GetImages` metódusokat a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) helyett.

### Mi a gyakorlati előnye a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)‑nek a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)‑hoz képest?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) egységesíti a raszteres és vektoralapú képek kezelését, egyszerűsíti a különböző formátumokba való mentést az [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) segítségével, csökkenti a `System.Drawing` függőséget, és a kódot hordozhatóbbá teszi a különböző környezetekben.

### Befolyásolja a Modern API a bélyegképek generálásának teljesítményét?

A `GetThumbnail`‑ról `GetImage`‑re való áttérés nem rontja a teljesítményt: az új metódusok ugyanazokat a lehetőségeket biztosítják a kép opciókkal és méretekkel való előállításához, miközben megtartják a renderelési opciók támogatását. A konkrét nyereség vagy vesztés a szituációtól függ, de funkcionálisan a helyettesítések ekvivalensek.