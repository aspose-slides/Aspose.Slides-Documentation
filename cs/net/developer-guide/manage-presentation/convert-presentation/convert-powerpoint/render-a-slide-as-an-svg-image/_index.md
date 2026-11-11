---
title: Renderovat snímky prezentace jako SVG obrázky v .NET
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- Možnosti exportu SVG
- interaktivní SVG
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Exportovat snímky PowerPointu jako SVG obrázky v .NET a řídit písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti i automatizované následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/), pokud musí být exportované SVG kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

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

Název souboru používá [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurace výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) určuje, zda se použije rotace rámce. Nastavte [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) na `true`, když text musí být vykreslen bez ligatur.

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

## **Řízení textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo se převede na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vybalancovat vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) na `true`, aby byl veškerý text snímku zapsán jako vektorová grafika. Tím se eliminují závislosti na písmu a výsledek je vizuálně konzistentnější napříč prohlížeči, ale text již není možné vybrat ani vyhledávat jako SVG text.

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

### **Vyberte, jak zacházet s externími písmy**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) pro písma načítaná externě. Zvolte `AddLinksToFontFiles` pro odkaz na samostatné soubory písem, `Embed` pro zahrnutí dat písma do SVG nebo `Vectorize` pro vykreslení textu, který používá externí písma, jako grafiku. Před vložením písem ověřte licenční podmínky.

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

Použijte [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) k vynechání oříznutých částí zdrojových obrázků a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ke řízení kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachování dat obrázku.

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

## **Řízení rozlišení rasterizace metafile**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) nastavuje spodní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je EMF nebo WMF obrázek rasterizován. Nedefinuje globální DPI pro SVG ani nenutí, aby se každý objekt na snímku stal rastrovým obrázkem.

Stáhněte si [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s úzce umístěnými diagonálními čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Všechna ostatní nastavení exportu zůstávají identická, aby bylo možné výsledky srovnat.

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

Ve výstupu se EMF proměnil na jeden vložený PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| DPI rasterizace metafile | Rozměry vloženého PNG | Velikost SVG souboru (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Srovnání níže ukazuje stejnou oblast vloženého rastrového obrazu při stejném zvětšeném zobrazení. Diagonální čáry vykazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrázku.

![Zvětšený detail diagonální čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) řídí snížení rozlišení obrázku a může maskovat vliv změny rozlišení rasterizace metafile. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Přiřazení stabilních ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) k nastavení [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) pro každý SVG tvar. K nastavení hodnot [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) na textových `tspan` prvcích také implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Přiřaďte jeden z controllerů pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Následující controller používá [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové spany. To dělá generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidání SVG obslužných rutin (event handlers)**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) zavolejte [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) pro přidání JavaScriptového obslužného rutiny k exportovanému tvaru. Přiřaďte controller pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci, na kterou odkazuje obslužná rutina. Přiřazení ID a obslužných rutin umožňuje prohlížeče snímků, vylepšení přístupnosti a další interaktivní SVG workflowy.

## **Často kladené otázky**

**Kdy mám použít [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), když musí být veškerý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), když by měl být pouze text používající externí písma převeden na grafiku.

**Jaký je nejlepší způsob, jak udělat SVG menší?**

Začněte kompresí vložených obrázků, smazáním oříznutých částí obrázků a výběrem odkazovaných souborů písem, pokud je cílové prostředí schopné je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG prvky?**

Ano. Přiřaďte ID pomocí formátovacího controlleru a poté vyberte odpovídající SVG prvky ve svém nástroji pro následné zpracování nebo skriptu v prohlížeči.