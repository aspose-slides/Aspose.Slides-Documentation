---
title: Képfeldolgozás fejlesztése a Modern API-val
linktitle: Modern API
type: docs
weight: 237
url: /hu/net/modern-api/
keywords:
- System.Drawing
- modern API
- rajzolás
- dia bélyegkép
- dia képpé
- alakzat bélyegkép
- alakzat képpé
- prezentáció bélyegkép
- prezentáció képekké
- kép hozzáadása
- kép beillesztése
- .NET
- C#
- Aspose.Slides
description: "Modernizáld a dia képfeldolgozást a elavult képgeneráló API-k .NET Modern API-val való helyettesítésével a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Történelmileg az Aspose Slides a System.Drawing-től függ, és a nyilvános API-ban a következő osztályokat tartalmazza onnan:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A 24.4-es verziótól kezdve ez a nyilvános API elavultnak lett jelölve.

Mivel a System.Drawing támogatása a .NET6 és újabb verziókban a nem Windows verziók esetén eltávolításra került ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), a Slides egy kétcsomagos megközelítést vezetett be:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – támogatás .NET6+ Windowsra, .NETStandard Windows/Linux/macOS rendszerekhez, .NETFramework 2+ (Windows).  
  - függ a [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) csomagtól.
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – Windows/Linux/macOS változat függőségek nélkül.

A [Aspose.Slides.NET6.CrossPlatform] kényelmetlensége, hogy saját System.Drawing változatot valósít meg ugyanabban a névtérben (a nyilvános API visszamenőleges kompatibilitásának támogatása érdekében). Így ha az Aspose.Slides.NET6.CrossPlatform és a .NET Framework‑ből vagy a System.Drawing.Common csomagból származó System.Drawing egyszerre kerül felhasználásra, névütközés keletkezik, hacsak nem használunk alias-t.

Az Aspose.Slides.NET főcsomagjában a System.Drawing függőségek eltávolítása érdekében bevezettük a úgynevezett „Modern API”-t – vagyis azt az API-t, amelyet a deprecated API helyett kell használni, és amelynek aláírásai a System.Drawing következő típusaira hivatkoznak: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) és [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). A [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) és a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) elavultnak van jelölve, és támogatásuk eltávolításra került a nyilvános Slides API-ból.

A jelenlegi verziókban a System.Drawing-re támaszkodó nyilvános API-t tekintse legacy/elavultnak. Új kódíráskor és a meglévő képfeldolgozó munkafolyamatok migrálásakor használja a Modern API-t.

## **Modern API**

A következő osztályokat és felsorolásokat adtuk a nyilvános API-hoz:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) – egy raszteres vagy vektorgrafikus képet képvisel.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) – a kép fájlformátumát jelöli.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/hu/net/aspose.slides/images/) – metódusok az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) interfész példányosításához és kezeléséhez.

Fontos megjegyezni, hogy az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) eldobható (implementálja a [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) interfészt, és használatát `using`‑ban vagy más kényelmes módon kell lezárni).

Használja a `GetImage`‑t egyetlen dia vagy alakzat rendereléséhez. Használja a `GetImages`‑t több prezentációs dia rendereléséhez. Használja a [Images](https://reference.aspose.com/slides/hu/net/aspose.slides/images/) metódusait képek betöltéséhez, a `AddImage`‑t az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, valamint a `ReplaceImage`‑t az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) használatával egy meglévő prezentációs kép frissítéséhez.

Egy tipikus új API használati forgatókönyv a következőképpen néz ki:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // hozzon létre egy eldobható IImage példányt a lemezen lévő fájlból.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // hozzon létre egy PowerPoint képet az IImage példány prezentáció képeihez való hozzáadásával.
        ppImage = pres.Images.AddImage(image);
    }

    // adjon hozzá egy képalakzatot az 1. diára
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // szerezzen egy IImage példányt, amely az 1. diát reprezentálja.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // mentse a képet a lemezre.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **A régi kód Modern API-val történő helyettesítése**

Az átmenet megkönnyítése érdekében az új [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) interfész megismétli a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) és a [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) osztályok különálló aláírásait. Általában csak annyit kell tennie, hogy a System.Drawing-et használó régi metódushívást kicseréli az újra.

### **Dia bélyegkép lekérése**

Régi/elavult API:

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

### **Alakzat bélyegkép lekérése**

Régi/elavult API:

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

### **Prezentáció bélyegkép lekérése**

Régi/elavult API:

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

### **Kép hozzáadása a prezentációhoz**

Régi/elavult API:

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

## **Elavult metódusok/tulajdonságok és azok helyettesítése a Modern API-ban**

### **Prezentáció**
| Metódus aláírása                               | Helyettesítő metódus aláírása                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print()                           | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement                            |
| public void Print(string printerName)         | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement                          |

### **Alakzat**
| Metódus aláírása                                                      | Helyettesítő metódus aláírása                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage#getimage_1) |

### **Dia**
| Metódus aláírása                                                      | Helyettesítő metódus aláírása                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement                                    |

### **Kimenet**
| Metódus aláírása                                                | Helyettesítő metódus aláírása                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/hu/net/aspose.slides.export.web/output/add#add_1)                               |

### **ImageCollection**
| Metódus aláírása                          | Helyettesítő metódus aláírása               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/addimage#addimage)                      |

### **ImageWrapperFactory**
| Metódus aláírása                                         | Helyettesítő metódus aláírása                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/hu/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### **PPImage**
| Metódus/Tulajdonság aláírása                     | Helyettesítő metódus aláírása   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/hu/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/hu/net/aspose.slides/ppimage/image)                    |

### **PatternFormat**
| Metódus aláírása                                          | Helyettesítő metódus aláírása                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/hu/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/hu/net/aspose.slides/patternformat/gettile#gettile)                           |

### **IPatternFormatEffectiveData**
| Metódus aláírása                                          | Helyettesítő metódus aláírása                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## **API támogatás a Graphics és a PrinterSettings számára**

A [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) osztály nem támogatott a .NET6 és újabb platformfüggetlen verzióiban. Az Aspose Slides‑ben használja a Modern API képrenderelő metódusait a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) felé renderelő API helyett:
[ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Emellett a [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) használatával kapcsolatos API-nak nincs közvetlen Modern API helyettesítője:

[IPresentation](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/print/#print_2)

## **GYIK**

**Miért lett eltávolítva a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?**

A [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) támogatása elavult a nyilvános API-ban, hogy egységesítsük a renderelést és a képek kezelését, megszüntessük a platformfüggő függőségeket, és egy platformfüggetlen megközelítést alkalmazzunk a [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) segítségével. Használja a `GetImage` vagy a `GetImages` metódusokat a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) helyett.

**Mi a gyakorlati előnye a [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) használatának a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) helyett?**

Az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) egyesíti a raszteres és vektorgrafikus képek kezelését, egyszerűsíti a különböző formátumokba való mentést a [ImageFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) használatával, csökkenti a `System.Drawing` függőséget, és kódot tesz hordozhatóbbá a különböző környezetek között.

**Hatással lesz a Modern API a bélyegképek generálásának teljesítményére?**

A `GetThumbnail`‑ról a `GetImage`‑re való átállás nem rontja a teljesítményt: az új metódusok ugyanazokat a képalkotási lehetőségeket és méreteket biztosítják, miközben megtartják a renderelési opciók támogatását. A konkrét nyereség vagy veszteség a felhasználási esetektől függ, de funkcionálisan a helyettesítések egyenértékűek.