---
title: "Render presentatiedia's als SVG-afbeeldingen in .NET"
linktitle: "Dia naar SVG"
type: docs
weight: 50
url: /nl/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint naar SVG"
- "presentatie naar SVG"
- "dia naar SVG"
- "PPT naar SVG"
- "PPTX naar SVG"
- "SVG-exportopties"
- "interactieve SVG"
- "PowerPoint"
- "presentatie"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in .NET en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar op XML gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, presentatieweergave, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat om te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden geschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactieve werking.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream. Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

De bestandsnaam gebruikt [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) in plaats van de lus‑index. U kunt ook een individuele vorm exporteren met [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) wanneer een presentatieweergave of webpagina alleen die vorm nodig heeft.

## **SVG‑uitvoer configureren**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) bepaalt de SVG‑weergave. Voor tekstkaders zorgt [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) ervoor dat het tekstkader in het weergavegebied wordt opgenomen, en [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) in op `true` wanneer tekst moet worden gerenderd zonder ligaturen.

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

Bij het exporteren van dia’s naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vector‑graphics, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u om de visuele consistentie, tekstselectie en afhankelijkheden van lettertypen in het geëxporteerde SVG in balans te houden.

### **Alle tekst vectoriseren**

Stel [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) in op `true` om alle dia‑tekst als vector‑graphics te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden verwerkt**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om te verwijzen naar afzonderlijke lettertype‑bestanden, `Embed` om lettertype‑data in het SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als graphics te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Ingesloten beeldgrootte verkleinen**

Gebruik [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) om bijgesneden brongebieden weg te laten, en [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of bewaarde beeldgegevens.

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

## **Metabestand rasterisatie‑resolutie beheren**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) stelt de ondergrens van de resolutie in voor het rasteriseren van metafiles tijdens SVG‑export. Gebruik dit om details en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor het SVG en dwingt niet elk object op de dia om een raster‑afbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met dicht opeengepakte diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Alle andere exportinstellingen blijven identiek zodat de resultaten kunnen worden vergeleken.

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

In de uitvoer is de EMF één ingesloten PNG geworden in elk SVG. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule om DPI om te rekenen naar pixelafmetingen.

| Metabestand rasterisatie‑DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en vloeiendere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet per se elk detail of wijzigt elke geëxporteerde afbeelding.

![Vergrote diagonale lijndetails bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) regelt de vermindering van de beeldresolutie en kan het effect van een wijziging in de rasterisatie‑resolutie van het metabestand maskeren. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) regelt de JPEG‑coderingskwaliteit, niet de rasterisatie‑resolutie van het metabestand.

## **Stabiele ID’s aan vormen en tekst toewijzen**

Gebruik [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) om [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) in te stellen voor elke SVG‑vorm. Om ook [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) waarden op tekst‑`tspan`‑elementen te zetten, implementeert u [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Wijs een van beide controllers toe met [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

De onderstaande controller gebruikt [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), dat gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de bijbehorende tekst‑spans. Hierdoor zijn de gegenereerde ID’s geschikt voor nabewerking van een ongewijzigde presentatie.

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

## **SVG‑gebeurtenis‑handlers toevoegen**

In een [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) roept u [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) aan met een [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/)‑waarde om een JavaScript‑event‑handler toe te voegen aan een geëxporteerde vorm. Wijs de controller toe met [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

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

De host‑pagina kan de door de handler gerefereerde JavaScript‑functie definiëren. Het toewijzen van ID’s en event‑handlers maakt presentatieweergave, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Gebruik [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar graphics.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden, en het kiezen van gekoppelde lettertype‑bestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen met zich meebrengen.

**Kan ik geëxporteerde SVG‑elementen na de export aanpassen?**

Ja. Ken ID’s toe via een opmaak‑controller en selecteer vervolgens de bijbehorende SVG‑elementen in uw nabewerkings‑tool of browserscript.