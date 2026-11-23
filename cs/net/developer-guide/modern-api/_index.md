---
title: Vylepšení zpracování obrazu pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 234
url: /cs/net/modern-api/
keywords:
- System.Drawing
- moderní API
- kreslení
- náhled snímku
- snímek na obrázek
- náhled tvaru
- tvar na obrázek
- náhled prezentace
- prezentace na obrázky
- přidat obrázek
- přidat obrázek
- .NET
- C#
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých API pro práci s obrázky pomocí .NET Moderního API pro bezproblémovou automatizaci PowerPoint a OpenDocument."
---
## **Úvod**

Historicky má Aspose Slides závislost na System.Drawing a má v veřejném API následující třídy z tohoto prostoru názvů:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Protože podpora System.Drawing ve verzích .NET6 a novějších byla odstraněna pro ne‑Windows verze ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides implementovala dvou‑balíčkový přístup:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – podpora pro .NET6+ pro Windows, .NETStandard pro Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - má závislost na [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – verze pro Windows/Linux/MacOS bez závislostí.

Inkonvenience [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) spočívá v tom, že implementuje vlastní verzi System.Drawing ve stejném jmenném prostoru (pro podporu zpětné kompatibility s veřejným API). Proto při současném použití Aspose.Slides.NET6.CrossPlatform a System.Drawing z .NET Framework nebo balíčku System.Drawing.Common vzniká konflikt názvů, pokud není použita alias.

Abychom se zbavili závislostí na System.Drawing v hlavním balíčku Aspose.Slides.NET, přidali jsme takzvané „Moderní API“ – tj. API, které by mělo být používáno místo zastaralého, jehož signatury obsahují závislosti na následujících typech ze System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) a [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) a [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) jsou označeny jako zastaralé a jejich podpora je odebrána z veřejného API Slides.

V aktuálních verzích považujte veřejné API závislé na System.Drawing za legacy/zastaralé. Pro nový kód a při migraci existujících pracovních postupů zpracování obrazu používejte Moderní API.

## **Moderní API**

Přidali jsme do veřejného API následující třídy a výčty:
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – metody pro vytvoření a práci s rozhraním [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) .

Všimněte si, že [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) je odhazovatelný (implementuje rozhraní [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) a jeho použití by mělo být zabalené do using nebo jiným vhodným způsobem uvolněno).

Použijte `GetImage` pro vykreslení jedné snímku nebo tvaru. Použijte `GetImages` pro vykreslení několika snímků prezentace. Použijte metody [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) k načtení obrázků, `AddImage` s [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) pro jejich přidání do prezentace a `ReplaceImage` s [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat následovně:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // vytvořte odhazovatelnou instanci IImage ze souboru na disku.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // vytvořte obrázek PowerPoint přidáním instance IImage do obrázků prezentace.
        ppImage = pres.Images.AddImage(image);
    }

    // přidejte obrázkový tvar na snímek #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // získejte instanci IImage představující snímek #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // uložte obrázek na disk.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Nahrazení starého kódu Moderním API**

Pro usnadnění přechodu rozhraní nového [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) opakuje oddělené signatury tříd [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) a [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Obecně budete muset jen nahradit volání staré metody používající System.Drawing novou.

### **Získání náhledu snímku**

Legacy/zastaralé API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Moderní API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Získání náhledu tvaru**

Legacy/zastaralé API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Moderní API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Získání náhledu prezentace**

Legacy/zastaralé API:

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

Moderní API:

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

### **Přidání obrázku do prezentace**

Legacy/zastaralé API:

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

Moderní API:

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

## **Zastaralé metody/vlastnosti a jejich náhrada v Moderním API**

### **Presentation**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
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
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
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
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Signatura metody/vlastnosti | Signatura náhradní metody |
|------------------------------|---------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Signatura metody | Signatura náhradní metody |
|------------------|---------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Podpora API pro Graphics a PrinterSettings**

[Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) třída není podporována pro multiplatformní verze .NET6 a vyšší. V Aspose Slides použijte moderní metody pro vykreslování obrázků místo API, které vykresluje do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Také API související s tiskem prostřednictvím [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) nemá přímou náhradu v Moderním API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **Často kladené otázky**

### Proč byl [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) odstraněn?

Podpora [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) je v veřejném API označena jako zastaralá, aby se sjednotila práce s vykreslováním a obrázky, eliminovaly se vazby na platformově specifické závislosti a přešlo se k multiplatformnímu přístupu s [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Použijte `GetImage` nebo `GetImages` místo vykreslování do [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ve srovnání s [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrázky, zjednodušuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), snižuje závislost na `System.Drawing` a činí kód přenosnějším mezi prostředími.

### Ovlivní Moderní API výkon generování náhledů?

Přechod z `GetThumbnail` na `GetImage` scénáře nezhoršuje: nové metody poskytují stejné možnosti pro výrobu obrázků s možnostmi a velikostmi, přičemž zachovávají podporu pro renderovací možnosti. Konkrétní zisk nebo pokles závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.