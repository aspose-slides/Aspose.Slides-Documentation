---
title: Převod snímků prezentace na obrázky v .NET
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/net/convert-slide/
keywords: 
- převod snímku
- export snímku
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v C# s Aspose.Slides pro .NET."
---
## **Úvod**

Aspose.Slides for .NET může vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Chcete-li převést snímek na obrázek, postupujte podle těchto kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/).
4. Zavolejte metodu [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/). Vrátí objekt [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/).
5. Zavolejte metodu [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/) a určete výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) lze zpracovat v paměti nebo uložit do souboru.

Následující příklad v C# vykreslí první snímek a uloží jej jako PNG obrázek:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetížení metody [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/), které přijímá hodnotu [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytváří JPEG obrázek o rozměrech 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Přiřaďte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) do vlastnosti [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/slideslayoutoptions/), abyste určili, kde se poznámky a komentáře zobrazí.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře napravo:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Pro převod snímku na obrázek nenastavujte vlastnost [NotesPosition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) na hodnotu [BottomFull](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notespositions/). Poznámky mohou obsahovat více textu, než co může pevná velikost obrázku pojmout. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/) vám umožňuje řídit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Převod všech snímků na obrázky**

Procházejte kolekci snímků a převedete celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je výslovně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek se horizontálním a vertikálním měřítkem 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je nutné vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od pixelového obrázku může EMF zachovat vektorové kreslířské operace, které se škálují bez ztráty ostrosti. EMF je však především formát kompatibility pro aplikace s podporou Windows metafilu, nikoli univerzální výměnný formát. Navíc může být složitý obsah snímku, jako jsou bitmapové obrázky a některé efekty, uložen jako rasterizované prvky uvnitř kontejneru vektorového metafilu.

### **Export snímku do EMF**

Metoda [ISlide.WriteAsEmf](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/writeasemf/) zapisuje [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/) do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Volající vlastní proud předaný metodě [ISlide.WriteAsEmf](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/writeasemf/) a musí jej uzavřít nebo uvolnit. Aspose.Slides zapisuje na aktuální pozici proudu a nechává proud otevřený.

### **Převod SVG obrázku na EMF a přidání do prezentace**

Použijte [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/writeasemf/) k převodu SVG obsahu na EMF. Výsledné bajty lze přidat do prezentace pomocí [IImageCollection.AddImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection/addimage/) a umístit na snímek pomocí [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/svgimage/) ze SVG značkování, převede jej na EMF v paměti, vloží metafil na první snímek a uloží prezentaci:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/writeasemf/) nepřevádí vlastnictví cílového proudu. Po zápisu je pozice proudu na konci generovaných dat. Před předáním stejného seekovatelného proudu čteči jej, jak je ukázáno výše, nastavte `Position` na začátek. Proud nechte otevřený, dokud jej spotřebitel nedokončí číst, a poté jej uvolněte. Případně zavolejte `ToArray` a předáte vrácené pole bajtů metodě [IImageCollection.AddImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection/addimage/); `ToArray` vrací celý buffer bez ohledu na aktuální pozici proudu.

Generování EMF je k dispozici na operačních systémech podporovaných vybranou sestavou Aspose.Slides pro .NET, ale vykreslování se může lišit napříč platformami, pokud nejsou k dispozici fonty nebo nativní grafické závislosti. Nainstalujte fonty použité ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, dodržujte [požadavky na platformu](/slides/cs/net/system-requirements/) pro váš balíček Aspose.Slides a ověřte výsledek v cílové aplikaci, která EMF používá. Aplikace pro Linux a macOS často mají omezenou nebo nekonzistentní podporu pro zobrazování a úpravu Windows metafile.

## **Vykreslování barevných emoji**

{{% alert title="Note" color="info" %}}
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být v systému, kde probíhá převod, nainstalovány a dostupné fonty emoji použité v prezentaci. Například pokud prezentace používá **Segoe UI Emoji** a tento font chybí, mohou se emoji ve výstupních obrázcích zobrazit v černobílé.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/) vykresluje statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit jako běžné snímky. Zahrňte je do smyčky zpracování, jak je ukázáno v příkladu výše.

**Zachovají se stíny a další efekty v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.