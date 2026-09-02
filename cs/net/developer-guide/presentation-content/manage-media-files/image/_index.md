---
title: Optimalizace správy obrázků v prezentacích v .NET
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/net/image/
keywords:
- přidat obrázek
- přidat fotografii
- přidat bitmapu
- nahradit obrázek
- nahradit fotografii
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- externí SVG zdroje
- SVG resolver
- propojené SVG obrázky
- SVG písma
- přidat EMF
- přidat WMF
- přidat TIFF
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjednodušte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro .NET, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vložit obrázky na snímky ze souborů, internetu nebo jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků prezentace několika způsoby.

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje zdarma konvertory—[JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvářet prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako rámeček obrázku—zejména pokud jej plánujete měnit velikost, aplikovat efekty nebo použít jiné standardní možnosti formátování—viz [Picture Frame](/slides/cs/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), a [SVG to PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně na snímky**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači na snímek prezentace. Následující ukázkový kód v C# ukazuje, jak přidat obrázek na snímek:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků z webu na snímky**

Pokud obrázek, který chcete přidat na snímek, není uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v C# ukazuje, jak přidat obrázek z webu na snímek:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků do hlavního snímku**

Hlavní snímek ukládá a řídí informace, jako je motiv a rozvržení snímků, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se zobrazí na každém snímku založeném na tomto masteru. 

Následující ukázkový kód v C# ukazuje, jak přidat obrázek do hlavního snímku:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí jednoho nebo více snímků. Podrobnosti naleznete v *[Setting Images as Backgrounds for Slides](/slides/cs/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/svgimage/). Výsledný objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) může být poté přidán do kolekce obrázků prezentace a použit k vytvoření rámečku obrázku. 

Následující příklad v C# importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité tímto SVG jsou vloženy přímo do obsahu SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Importování SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro design, diagramových editorů, ikonových systémů a webových pipeline mohou odkazovat na zdroje uložené mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, CSS hodnotu `url(...)` nebo URL písma. 

Pro import takového SVG obsahu vytvořte implementaci [IExternalResourceResolver](https://reference.aspose.com/slides/cs/net/aspose.slides.import/iexternalresourceresolver/) a předáte ji spolu se základní URI do příslušného konstruktoru `SvgImage`. Základní URI identifikuje umístění SVG dokumentu a používá se k řešení relativních odkazů. 

Rozhraní [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) poskytuje přístup k informacím o importovaném SVG:

- `SvgContent` vrací SVG značkování jako řetězec.  
- `SvgData` vrací obsah SVG jako pole bajtů.  
- `BaseUri` vrací základní URI použité pro relativní odkazy.  
- `ExternalResourceResolver` vrací resolver přiřazený SVG obrázku.  

### **Implementace externího resolveru zdrojů**

Resolver má dvě metody:

- `ResolveUri` kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vraťte `null`, když odkaz nelze vyřešit nebo není povolen.  
- `GetEntity` vrací čitelný stream pro absolutní URI zdroje. Vraťte `null`, když zdroj chybí, je blokován nebo není dostupný. Náhradní stream může být také vrácen, pokud je to vhodné.  

Následující resolver načítá odkazované zdroje pouze z povoleného lokálního adresáře. Síťové zdroje a cesty mimo povolený adresář jsou blokovány. Volitelný náhradní obrázek je vrácen pro nevyřešené odkazy na obrázky.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Tento resolver úmyslně povoluje pouze místní soubory.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Použijte náhradní soubor pouze pro obrazové zdroje. Vrácení proudu obrazu
        // pro chybějící písmo nebo stylopis by nebylo platné.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Řešení odkazovaných zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz jako například:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad v C# předává URI SVG souboru jako základní URI a poskytuje vlastní resolver. Resolver převádí relativní odkaz na obrázek na absolutní URI a vrací stream obsahující odkazovaný zdroj, zatímco Aspose.Slides zpracovává SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Base URI představuje umístění SVG dokumentu.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage poskytuje přístup k původnímu obsahu, binárním datům, base URI a resolveru.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` třída také poskytuje přetížení, která přijímají SVG data jako pole bajtů nebo stream, spolu s externím resolverem zdrojů a základní URI.

{{% alert title="Important" color="warning" %}}

Resolver zdrojů zpřístupňuje externí zdroje během zpracování a vykreslování SVG v Aspose.Slides. Nemodifikuje původní SVG značkování ani automaticky nevestavuje vyřešené zdroje do něj.  

Když je `ISvgImage` přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak původní SVG reprezentaci, tak rastrový náhradní obrázek. Odkazovaný zdroj se může objevit v generovaném náhradním obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane nezměněn v uloženém SVG. Aplikace, která vykresluje nativní SVG reprezentaci, může proto vynechat odkazovaný obsah, když není původní externí zdroj dostupný.  

{{% /alert %}}

### **Vytvoření přenositelného SVG obrázku**

Aby byl SVG obrázek nezávislý na externích souborech, udělejte SVG samostatný před vytvořením `SvgImage`. Například nahraďte URL odkazované obrázky pomocí `data:` URI, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku obrázku, jak je ukázáno v předchozím příkladu.  

### **Zpracování chybějících nebo blokovaných zdrojů**

Vraťte `null` z `ResolveUri`, když je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vraťte `null` z `GetEntity`, když zdroj nelze přečíst. Aspose.Slides pokračuje ve zpracování SVG bez toho zdroje, pokud je to možné.  

Náhradní stream může být vrácen pro chybějící zdroj, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vracejte stream s obrázkem jen pro chybějící obrázek, ne pro písmo nebo stylový list.  

{{% alert title="Security" color="warning" %}}

Nerozpoznávejte libovolné cesty k souborům ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolená schémata, adresáře a hosty. Pro síťové zdroje rovněž aplikujte časové limity připojení, limity velikosti odpovědi a validaci obsahu.  

{{% /alert %}}

## **Převod SVG na sadu tvarů**
Aspose.Slides může převést SVG na sadu tvarů, podobně jako odpovídající funkčnost v PowerPointu:

![PowerPoint Popup Menu](img_01_01.png)

Tato funkce je poskytována přetížením metody [AddGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/addgroupshape/methods/1) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection), která přebírá jako první argument objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage).  

Následující ukázkový kód v C# ukazuje, jak použít tuto metodu k převodu SVG souboru na sadu tvarů:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Název zdrojového SVG souboru
string svgFileName = "sample.svg";

// Název výstupního souboru prezentace
string outPptxPath = "presentation.pptx";

// Vytvořit novou prezentaci
using (IPresentation presentation = new Presentation())
{
    // Načíst obsah SVG souboru
    string svgContent = File.ReadAllText(svgFileName);

    // Vytvořit objekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Získat velikost snímku
    SizeF slideSize = presentation.SlideSize.Size;

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Uložit prezentaci ve formátu PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Přidání obrázků jako EMF na snímky**
Aspose.Slides pro .NET vám umožňuje generovat EMF obrázky z listů Excel pomocí Aspose.Cells a přidávat je do snímků prezentace.

Následující ukázkový kód v C# ukazuje, jak to provést:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Uložit sešit do proudu
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides vám umožňuje nahrazovat obrázky uložené v kolekci obrázků prezentace, včetně obrázků používaných tvary na snímcích. Toto oddílo popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Obrázek můžete nahradit pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) nebo jiným obrázkem, který již v kolekci existuje.  

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Zapište upravenou prezentaci jako soubor PPTX.  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která reprezentuje soubor prezentace.
using Presentation presentation = new Presentation("sample.pptx");

// První způsob.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Druhý způsob.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Třetí způsob.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Uložit prezentaci do souboru.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

S bezplatným konvertorem Aspose [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat text a vytvářet GIFy z textu. 

{{% /alert %}}

## **FAQ**

**Zůstane po vložení původní rozlišení obrázku nedotčeno?**

Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/net/picture-frame/) na snímku škálována a na případné kompresi při uložení.  

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na hlavní snímek nebo layout a nahraďte jej v kolekci obrázků prezentace – aktualizace se projeví ve všech prvcích, které tento zdroj používají.  

**Lze vložené SVG převést na editovatelné tvary?**

Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části dají upravovat pomocí standardních vlastností tvarů.  

**Jak mohu nastavit obrázek jako pozadí pro více snímků najednou?**

Přiřaďte obrázek jako pozadí [Assign the image as the background](/slides/cs/net/presentation-background/) na hlavním snímku nebo příslušném layoutu – všechny snímky používající tento master/layout zdědí pozadí.  

**Jak zabránit tomu, aby se prezentace příliš zvětšila kvůli mnoha obrázkům?**

Znovu používejte jediný zdroj obrázku místo duplicit, zvolte rozumné rozlišení, aplikujte kompresi při ukládání a opakovanou grafiku umisťujte na hlavní snímek tam, kde je to vhodné.