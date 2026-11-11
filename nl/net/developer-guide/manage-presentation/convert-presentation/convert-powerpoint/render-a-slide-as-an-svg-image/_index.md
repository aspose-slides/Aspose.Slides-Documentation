---
title: Render presentatiedia's als SVG-afbeeldingen in .NET
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in .NET en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML-gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diavoorstellers, toegankelijkheidsprocessen en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en laat u controleren hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie als een afzonderlijk SVG‑bestand.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

De bestandsnaam gebruikt [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) in plaats van de lusindex. U kunt ook een individueel object exporteren met [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) wanneer een diavoorsteller of webpagina alleen dat object nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) regelt de weergave van SVG. Voor tekstkaders bevat [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) het tekstkader in het weergavegebied, en [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Beheer bijsnijden van lijnuiteinden bij pijlpuntjes**

SVG 1.1 heeft geen instelling voor marker‑inset om op te geven waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de lijnbreedte niet door de marker heen steekt. Stel [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) in op `true` om de lijnbreedte helemaal tot het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG‑output. De lijn behoudt zijn positie en lengte op de dia.

Het voorbeeld tekent driehoek‑ en ruit‑pijlpuntjes op lijnen van respectievelijk 2 en 10 punten breed. Het exporteert dezelfde dia twee keer, waarbij alleen de bijsnijdingsoptie wordt gewijzigd.

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

De vergelijking toont de driehoekige pijlpunt op de 10‑puntlijn. Met bijsnijden ingeschakeld is de punt scherp. Met bijsnijden uitgeschakeld steekt de lijnbreedte door de schuine zijden van de marker en ontstaat een platte uiteinde.

![Vergrote driehoek van 10 punten met een scherpe punt wanneer bijsnijden is ingeschakeld en een plat uiteinde wanneer bijsnijden is uitgeschakeld](line-end-cropping.png)

Bij de andere lijnen uit het voorbeeld is de uitsteekende lijnbreedte minder zichtbaar op de 2‑punts driehoek. De gevulde ruit bedekt het uiteinde van de lijnbreedte bij beide breedtes.

## **Beheer tekst en lettertypen**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of verwezen. De volgende opties helpen u visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in het geëxporteerde SVG in balans te brengen.

### **Vectoriseer alle tekst**

Stel [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit elimineert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet meer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden afgehandeld**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar afzonderlijke lettertypebestanden te verwijzen, `Embed` om lettertype‑data in het SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als afbeeldingen te renderen. Controleer de licentie van het lettertype voordat u lettertypen embed.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) om de resolutie van ingesloten afbeeldingen te verminderen, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of behouden afbeeldingsdata.

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

## **Beheer resolutie van metafile‑rasterisatie**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) stelt de ondergrens voor resolutie in bij het rasteren van metafiles tijdens SVG‑export. Gebruik het om details en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor het SVG en dwingt niet elk object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met dicht opeengepakte diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Alle overige exportinstellingen blijven identiek zodat de resultaten vergeleken kunnen worden.

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

In de output is de EMF omgezet naar één ingesloten PNG in elk SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile rasterisatie DPI | Ingesloten PNG-afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De onderstaande vergelijking toont hetzelfde gebied van de ingesloten raster op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet per se elk detail of verandert elke geëxporteerde afbeelding.

![Vergrote diagonale lijndetails bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) regelt de vermindering van beeldresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) regelt de JPEG‑coderingskwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Ken stabiele ID's toe aan vormen en tekst**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) in te stellen voor elke SVG‑vorm. Om ook [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) waarden op tekst‑`tspan`‑elementen in te stellen, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Wijs één van de controllers toe met [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

De volgende controller gebruikt [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), die gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor zijn tekstdelen. Dit maakt de gegenereerde ID's geschikt voor nabewerking van een onveranderde presentatie.

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

## **Voeg SVG‑eventhandlers toe**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), roep [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en eventhandlers maakt diavoorstellers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar afbeeldingen.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden, en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteit‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Ken ID's toe via een formatteringscontroller en selecteer vervolgens de overeenkomende SVG‑elementen in uw nabewerkings‑tool of browserscript.