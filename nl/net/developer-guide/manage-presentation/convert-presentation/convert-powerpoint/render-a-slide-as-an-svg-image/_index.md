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

SVG is een schaalaanpasbaar XML-gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, slide‑viewers, toegankelijkheidsprocessen en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG‑bestand en laat u bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het onderstaande voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

De bestandsnaam gebruikt [ISlide.SlideNumber](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/slidenumber/) in plaats van de lus‑index. U kunt ook een individuele vorm exporteren met [IShape.WriteAsSvg](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/writeassvg/) wanneer een slide‑viewer of webpagina alleen die vorm nodig heeft.

## **SVG‑output configureren**

[SVGOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/) regelt de SVG‑rendering. Voor tekstframes zorgt [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/useframesize/) ervoor dat het tekstframe wordt meegenomen in het rendergebied, en [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/useframerotation/) bepaalt of de rotatie van het frame wordt toegepast. Stel [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/disablefontligatures/) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Tekst en lettertypen beheren**

### **Alle tekst vectoriseren**

Stel [SVGOptions.VectorizeText](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/vectorizetext/) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om afzonderlijke lettertypebestanden te refereren, `Embed` om lettertypegegevens in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als grafische weergave te renderen. Controleer de licentievoorwaarden van het lettertype voordat u lettertypen embedt.

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

## **Grootte van ingesloten afbeeldingen verkleinen**

Gebruik [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/picturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.JpegQuality](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/jpegquality/) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de afbeeldingsnauwkeurigheid of behouden afbeeldingsdata.

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

## **Stabiele ID's aan vormen en tekst toewijzen**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape.Id](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshape/id/) voor elke SVG‑vorm in te stellen. Om ook [ISvgTSpan.Id](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgtspan/id/) waarden op tekst‑`tspan`‑elementen te zetten, implementeer [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Wijs één van de controllers toe via [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

De onderstaande controller gebruikt [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/officeinteropshapeid/), dat stabiel blijft gedurende de levensduur van de vorm, en een reproduceerbare teller voor de tekst‑spans ervan. Hierdoor zijn de gegenereerde ID's geschikt voor nabewerking van een ongewijzigde presentatie.

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

## **SVG‑eventhandlers toevoegen**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshapeformattingcontroller/) roep je [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/nl/net/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe via [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en eventhandlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.VectorizeText](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/vectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.VectorizeText] wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize] wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafische weergave.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gelinkte lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere resolutie van de afbeelding, een lagere JPEG‑kwaliteit en vectorisatie van tekst elk verschillende afwegingen tussen kwaliteit en bestandsgrootte hebben.

**Kan ik geëxporteerde SVG‑elementen na het exporteren aanpassen?**

Ja. Ken ID's toe via een formatteringscontroller en selecteer vervolgens de overeenkomstige SVG‑elementen in uw nabewerkings‑tool of browserscript.