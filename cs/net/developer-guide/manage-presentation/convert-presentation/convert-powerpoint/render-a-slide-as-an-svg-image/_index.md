---
title: Vykreslit snímky prezentace jako SVG obrázky v .NET
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako SVG obrázky v .NET a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který dobře funguje pro webové publikování, prohlížeče snímků, workflowy přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a prvky SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) když musí být exportovaný SVG kompaktní, předvídatelný napříč prohlížeči nebo připravený k interaktivnímu použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Název souboru používá [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) místo indexu smyčky. Také můžete exportovat jednotlivý tvar pomocí [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebují jen tento tvar.

## **Konfigurace výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) zahrnuje textový rámeček do oblasti vykreslování a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) určuje, zda se použije rotace rámečku. Nastavte [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) na `true`, když musí být text vykreslen bez ligatur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Řízení oříznutí konce čáry u šipek**

SVG 1.1 nemá nastavení vložení značky, které by určovalo, kde má čára končit pod špičkou šipky. Ve výchozím nastavení Aspose.Slides zkracuje exportovanou čáru, aby tah nevyčníval skrz značku. Nastavte [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) na `true`, aby se tah kreslil až po původní koncový bod čáry. Toto nastavení ovlivňuje pouze výstup SVG. Čára si na snímku zachová své umístění a délku.

Příklad vykresluje trojúhelníkové a diamantové hroty na čárach o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, změnou pouze volby oříznutí.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Porovnání ukazuje trojúhelníkový hrot na 10‑bodové čáře. Při zapnutém oříznutí je špička ostrá. Při vypnutém oříznutí tah vyčnívá skrz šikmé strany značky a zůstává plochý konec.

![Zvětšený 10‑bodový trojúhelník s ostrou špičkou při zapnutém oříznutí a s plochým koncem při vypnutém oříznutí](line-end-cropping.png)

V ostatních čarách z příkladu je vyčnívající tah méně patrný na 2‑bodovém trojúhelníku. Vyplněný diamant zakrývá konec tahu v obou šířkách.

## **Řízení textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuty nebo odkazovány externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) na `true`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se odstraní závislost na písmech a výsledek bude vizuálně konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani vyhledávat jako SVG‑text.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Zvolte, jak se zacházejí s externími písmy**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkazování na samostatné soubory písem, `Embed` pro zahrnutí dat písem do SVG nebo `Vectorize` pro vykreslení pouze textu, který používá externí písma, jako grafiku. Před vložením písem ověřte licenční podmínky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Zmenšení velikosti vložených obrázků**

Použijte [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) k vynechání oříznutých oblastí zdroje a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ke kontrole kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachování dat obrázku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Řízení rozlišení rastrování metafilů**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) stanoví spodní limit rozlišení pro rastrování metafilů během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je EMF nebo WMF obrázek rastrován. Nenastavuje globální DPI pro SVG ani neznamená, že každý objekt na snímku se změní na rastrový obrázek.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s těsně umístěnými úhlopříčnými čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rastrování pomocí [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Ve výstupu se EMF promění na jeden vložený PNG v každém SVG. Následující měření jsou pro poskytnutou prezentaci; nejedná se o obecný vzorec pro převod DPI na rozměry v pixelech.

| Rozlišení rastrování metafilu DPI | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170 221 |
| 150 | 2492 × 1242 | 423 149 |
| 300 | 4983 × 2483 | 1 027 169 |

Porovnání níže ukazuje stejnou oblast vloženého rastrování při stejném zvětšeném zobrazení. Úhlopříčné čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrázku.

![Zvětšený detail úhlopříčných čar při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) řídí snížení rozlišení obrázku a může maskovat efekt změny rozlišení rastrování metafilu. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) řídí kvalitu JPEG kódování, nikoli rozlišení rastrování metafilu.

## **Přiřazení stabilních ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) k nastavení [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) pro každý tvar SVG. Pro nastavení hodnot [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) na textových elementech `tspan` také implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Přiřaďte kterýkoli kontroler pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Následující kontroler používá [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové segmenty. To dělá generovaná ID vhodná pro post‑processing nezměněné prezentace.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Přidání SVG obslužníků událostí**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) zavolejte [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) pro přidání JavaScriptového obslužníku události k exportovanému tvaru. Přiřaďte kontroler pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Hostitelská stránka může definovat JavaScriptovou funkci, na kterou odkazuje obslužník. Přiřazení ID a obslužníků událostí umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflowy.

## **Časté otázky**

**Kdy mám použít [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), když musí být celý text nezávislý na písmech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), když by měl být převeden na grafiku jen text používající externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, mazáním oříznutých oblastí obrázku a volbou odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG elementy?**

Ano. Přiřaďte ID pomocí formátovacího kontroleru, poté vyberte odpovídající SVG elementy ve vašem post‑processing nástroji nebo skriptu prohlížeče.