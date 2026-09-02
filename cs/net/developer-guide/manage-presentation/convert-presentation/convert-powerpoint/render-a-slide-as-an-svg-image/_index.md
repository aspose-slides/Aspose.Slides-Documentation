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
description: "Exportujte snímky PowerPoint jako SVG obrázky v .NET a ovládejte písma, text, obrázky, ID a události pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, pracovní postupy přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám kontrolovat, jak jsou zapisovány text, písma, obrázky a prvky SVG.  
Použijte [SVGOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/) když exportovaný SVG musí být kompaktní, předvídatelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Název souboru používá [ISlide.SlideNumber](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/slidenumber/) místo indexu cyklu. Můžete také exportovat jednotlivý tvar pomocí [IShape.WriteAsSvg](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/writeassvg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Nastavení výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámy zahrnuje [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/useframesize/) textový rámec do oblasti vykreslování a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/useframerotation/) určuje, zda se použije rotace rámce. Nastavte [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/disablefontligatures/) na `true`, když musí být text vykreslen bez ligatur.

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

## **Ovládání textu a písem**

### **Vektorizovat veškerý text**

Nastavte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/vectorizetext/) na `true`, aby byl veškerý text snímku zapsán jako vektorová grafika. To eliminuje závislosti na písmenech a zajistí, že vizuální výsledek bude konzistentnější napříč prohlížeči, ale text už nebude možné v SVG vybírat ani prohledávat jako text.

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

### **Zvolte, jak se zachází s externími písmy**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/externalfontshandling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgexternalfontshandling/) pro písma načtená externě. Vyberte `AddLinksToFontFiles` pro odkaz na samostatné soubory písem, `Embed` pro zahrnutí dat písem do SVG, nebo `Vectorize` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vložením písem ověřte licenční podmínky písem.

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

## **Snížení velikosti vložených obrázků**

Použijte [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/picturescompression/) ke snížení rozlišení vložených obrázků, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) k vynechání oříznutých oblastí zdroje a [SVGOptions.JpegQuality](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/jpegquality/) k řízení kvality kódování JPEG. Tato nastavení snižují velikost souboru na úkor kvality obrazu nebo zachovaných dat obrázku.

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

## **Přiřazení stabilních ID tvarům a textu**

Použijte [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshapeformattingcontroller/) k nastavení [ISvgShape.Id](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshape/id/) pro každý SVG tvar. Pro nastavení hodnot [ISvgTSpan.Id](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgtspan/id/) na textových prvcích `tspan` rovněž implementujte [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Připojte jeden z řadičů pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Následující řadič používá [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/officeinteropshapeid/), který je stabilní po celou životnost tvaru, a opakovatelný čítač pro jeho textové úseky. To činí generovaná ID vhodná pro následné zpracování nezměněné prezentace.

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

## **Přidání obslužných rutin událostí SVG**

V [ISvgShapeFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshapeformattingcontroller/) zavolejte [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/cs/net/aspose.slides.export/isvgshape/seteventhandler/) s hodnotou [SvgEvent](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgevent/) pro přidání JavaScriptové obslužné rutiny události k exportovanému tvaru. Přiřaďte řadič pomocí [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) a definujte JavaScriptovou funkci na stránce nebo v SVG dokumentu, který výsledek hostí.

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

Hostitelská stránka může definovat JavaScriptovou funkci referencovanou obslužnou rutinou. Přiřazování ID a obslužných rutin událostí umožňuje prohlížečům snímků, vylepšení přístupnosti a další interaktivní pracovní postupy s SVG.

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.VectorizeText](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/vectorizetext/) místo [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.VectorizeText](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/vectorizetext/), pokud musí být veškerý text nezávislý na písmech. Použijte [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgexternalfontshandling/), pokud by měl být převeden na grafiku pouze text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud je cílové prostředí schopné je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.

**Mohu po exportu upravovat exportované SVG prvky?**

Ano. Přiřaďte ID pomocí řadiče formátování a poté vyberte odpovídající SVG prvky ve vašem nástroji pro následné zpracování nebo ve skriptu prohlížeče.