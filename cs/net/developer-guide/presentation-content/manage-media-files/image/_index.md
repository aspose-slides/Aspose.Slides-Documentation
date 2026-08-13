---
title: "Optimalizace správy obrázků v prezentacích v .NET"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/net/image/
keywords:
- přidat obrázek
- přidat obrázek
- přidat bitmapu
- nahradit obrázek
- nahradit obrázek
- z webu
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- externí SVG zdroje
- SVG řešitel
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
description: "Zefektivněte správu obrázků v PowerPointu a OpenDocument pomocí Aspose.Slides pro .NET, optimalizujte výkon a automatizujte svůj pracovní postup."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky na snímky ze souborů, internetu nebo jiných zdrojů. Podobně Aspose.Slides vám umožňuje přidávat obrázky do snímků prezentace několika způsoby.

{{% alert title="Tip" color="info" %}} 
Aspose poskytuje zdarma převodníky—[JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které vám umožní rychle vytvořit prezentace z obrázků. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Pokud chcete přidat obrázek jako rámeček obrázku—zejména pokud ho plánujete měnit velikost, aplikovat efekty nebo použít jiné standardní možnosti formátování—podívejte se na [Picture Frame](/slides/cs/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}}
Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/net/conversion/png-to-svg/), a [SVG to PNG](https://products.aspose.com/slides/cs/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených lokálně do snímků**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači do snímku prezentace. Následující ukázkový kód v C# ukazuje, jak přidat obrázek do snímku:

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

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat do snímku, není uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v C# ukazuje, jak přidat obrázek z webu do snímku:

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

## **Přidání obrázků do hlavních snímků**

Hlavní snímek (slide master) ukládá a řídí informace, jako je téma a rozvržení pro snímky, které jej používají. Když přidáte obrázek do hlavního snímku, obrázek se zobrazí na každém snímku založeném na tomto masteru. 

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

Můžete použít obrázek jako pozadí pro jeden nebo více snímků. Podrobnosti najdete v *[Setting Images as Backgrounds for Slides](/slides/cs/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze přidat do prezentace pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/svgimage/). Výsledný objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) může být následně přidán do kolekce obrázků prezentace a použit k vytvoření rámečku obrázku.

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

## **Import SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro návrh, editorů diagramů, ikonových systémů a webových pipeline mohou odkazovat na zdroje, které jsou uloženy mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, hodnotu CSS `url(...)` nebo URL písma. 

Pro import takového SVG obsahu vytvořte implementaci [IExternalResourceResolver](https://reference.aspose.com/slides/cs/net/aspose.slides.import/iexternalresourceresolver/) a předávejte ji spolu se základním URI konstruktoru `SvgImage`. Základní URI určuje umístění dokumentu SVG a slouží k řešení relativních odkazů. 

Rozhraní [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) poskytuje přístup k informacím o importovaném SVG:

- `SvgContent` vrací značkování SVG jako řetězec.  
- `SvgData` vrací obsah SVG jako pole bajtů.  
- `BaseUri` vrací základní URI použité pro relativní odkazy.  
- `ExternalResourceResolver` vrací řešitel přiřazený ke SVG obrázku.  

### **Implementace externího řešitele zdrojů**

Řešitel má dvě metody:

- [ResolveUri](https://reference.aspose.com/slides/cs/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombinuje základní URI a relativní odkaz na zdroj a vrací absolutní URI. Vrátí `null`, pokud odkaz nelze vyřešit nebo není povolen.  
- [GetEntity](https://reference.aspose.com/slides/cs/net/aspose.slides.import/iexternalresourceresolver/getentity/) vrací čitelný stream pro absolutní URI zdroje. Vrátí `null`, pokud zdroj chybí, je zablokován nebo nedostupný. Vhodný fallback stream může být také vrácen.  

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

        // Tento řešitel úmyslně povoluje pouze místní soubory.
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

        // Použijte fallback pouze pro obrazové zdroje. Vrácení streamu obrázku
        // pro chybějící font nebo stylopis by nebylo platné.
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

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz, například:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad v C# předává URI souboru SVG jako základní URI a poskytuje vlastní řešitel. Řešitel převádí relativní odkaz na obrázek na absolutní URI a vrací stream obsahující odkazovaný zdroj, zatímco Aspose.Slides zpracovává SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Základní URI představuje umístění SVG dokumentu.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

Třída `SvgImage` také poskytuje přetížení, která přijímají SVG data jako pole bajtů nebo stream, spolu s externím řešitelem zdrojů a základním URI.

{{% alert title="Důležité" color="warning" %}}
Řešitel zdrojů zpřístupňuje externí zdroje během zpracování a vykreslování SVG knihovnou Aspose.Slides. Nemodifikuje původní značkování SVG ani automaticky nevkládá vyřešené zdroje do něj.  

Když je `ISvgImage` přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak původní SVG reprezentaci, tak rastrový fallback obrázek. Odkazovaný zdroj se může objevit ve vygenerovaném fallback obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane v uloženém SVG nezměněn. Aplikace, která vykresluje nativní SVG reprezentaci, tak může vynechat odkazovaný obsah, pokud není originální externí zdroj dostupný.  
{{% /alert %}}

### **Vytvoření přenositelného SVG obrázku**

Pro vytvoření SVG obrázku, který nevyžaduje externí soubory, udělejte SVG samostatným před vytvořením `SvgImage`. Například nahraďte odkazované URL obrázků za `data:` URI, které obsahují data obrázku:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech požadovaných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku obrázku, jak ukazuje předchozí příklad.

### **Zpracování chybějících nebo blokovaných zdrojů**

Vrátíte `null` z `ResolveUri`, pokud je URI zdroje neplatné, zakázané nebo ho nelze vyřešit. Vrátíte `null` z `GetEntity`, pokud zdroj nelze přečíst. Aspose.Slides bude SVG zpracovávat i bez tohoto zdroje, pokud je to možné.  

Fallback stream může být vrácen pro chybějící zdroj, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vracejte stream s obrázkem pouze pro chybějící obrázek, nikoli pro písmo nebo stylopis.

{{% alert title="Bezpečnost" color="warning" %}}
Nevyřešujte libovolné cesty k souborům ani neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolená schémata, adresáře a hosty. Pro síťové zdroje také aplikujte časové limity připojení, limity velikosti odpovědi a validaci obsahu.  
{{% /alert %}}

## **Převod SVG na sadu tvarů**
Aspose.Slides může převést SVG na sadu tvarů, podobně jako odpovídající funkce v PowerPointu:

![PowerPoint Popup Menu](img_01_01.png)

Tato funkce je poskytována přetížením metody [AddGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/addgroupshape/methods/1) rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection), která přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage) jako první argument.

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
    // Přečíst obsah SVG souboru
    string svgContent = File.ReadAllText(svgFileName);

    // Vytvořit objekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Získat velikost snímku
    SizeF slideSize = presentation.SlideSize.Size;

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Uložit prezentaci v PPTX formátu
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Přidání obrázků jako EMF do snímků**
Aspose.Slides pro .NET umožňuje generovat EMF obrázky z listů Excelu pomocí Aspose.Cells a přidávat je do snímků prezentace.

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

Aspose.Slides vám umožňuje nahrazovat obrázky uložené v kolekci obrázků prezentace, včetně obrázků použitých tvary snímků. Tato sekce popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Můžete nahradit obrázek pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Uložte upravenou prezentaci jako soubor PPTX.  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
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

## **Často kladené otázky**

**Zůstane po vložení zachována původní rozlišení obrázku?**  
Ano. Původní pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/net/picture-frame/) na snímku škálován a jaká komprese je použita při uložení.

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**  
Umístěte logo na hlavní snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace – změna se projeví ve všech prvcích, které tuto zdrojovou položku používají.

**Lze vložený SVG převést na editovatelné tvary?**  
Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části stanou editovatelnými pomocí standardních vlastností tvarů.

**Jak mohu najednou nastavit obrázek jako pozadí pro více snímků?**  
[Assign the image as the background](/slides/cs/net/presentation-background/) na hlavním snímku nebo příslušném rozvržení – všechny snímky používající tento master/layout zdědí pozadí.

**Jak zabránit tomu, aby se prezentace příliš zvětšila kvůli velkému počtu obrázků?**  
Opakovaně používejte jediný zdroj obrázku místo duplicit, vybírejte rozumná rozlišení, aplikujte kompresi při ukládání a pokud je to vhodné, uchovávejte opakující se grafiku v masteru.