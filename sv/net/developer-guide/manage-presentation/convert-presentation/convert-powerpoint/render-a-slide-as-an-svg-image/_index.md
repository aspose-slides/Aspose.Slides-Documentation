---
title: Rendera presentationsbilder som SVG-bilder i .NET
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i .NET och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, teckensnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/) när den exporterade SVG-filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/), välj en bild och skriv den till en ström. Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Filnamnet använder [ISlide.SlideNumber](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/slidenumber/) istället för loop-indexet. Du kan också exportera en enskild form med [IShape.WriteAsSvg](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/writeassvg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/) styr SVG-rendering. För textramar inkluderar [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/useframesize/) textramen i renderingsområdet, och [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/useframerotation/) bestämmer om ramens rotation tillämpas. Ställ in [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/disablefontligatures/) till `true` när text måste renderas utan ligaturer.

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

## **Styr text och teckensnitt**

### **Vektorisera all text**

Ställ in [SVGOptions.VectorizeText](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/vectorizetext/) till `true` för att skriva all bildtext som vektorgrafik. Detta tar bort beroenden av teckensnitt och gör det visuella resultatet mer enhetligt i olika webbläsare, men texten blir inte längre valbar eller sökbar som SVG-text.

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

### **Välj hur externa teckensnitt hanteras**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/externalfontshandling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata teckensnitts-filer, `Embed` för att inkludera teckensnittsdata i SVG-filen, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Kontrollera teckensnittslicenser innan du bäddar in teckensnitt.

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

## **Minska storleken på inbäddade bilder**

Använd [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/picturescompression/) för att minska upplösningen på inbäddade bilder, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) för att utelämna beskurna källområden, och [SVGOptions.JpegQuality](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/jpegquality/) för att styra JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildens noggrannhet eller bevarade bilddata.

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

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshapeformattingcontroller/) för att ange [ISvgShape.Id](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshape/id/) för varje SVG-form. För att även sätta [ISvgTSpan.Id](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgtspan/id/)‑värden på text-`tspan`-element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Följande kontroller använder [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/officeinteropshapeid/), vilket är stabilt under formens livstid, och en upprepningsbar räknare för dess text-spans. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

## **Lägg till SVG‑händelsehanterare**

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshapeformattingcontroller/) anropar du [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshape/seteventhandler/) med ett [SvgEvent](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgevent/)‑värde för att lägga till en JavaScript‑händelsehanterare till en exporterad form. Tilldela kontrollern med [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) och definiera JavaScript‑funktionen på sidan eller i SVG‑dokumentet som innehåller resultatet.

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

Värdsidan kan definiera JavaScript‑funktionen som refereras av hanteraren. Att tilldela ID:n och händelsehanterare möjliggör bildvisare, förbättringar för tillgänglighet och andra interaktiva SVG‑arbetsflöden.

## **Vanliga frågor**

**När bör jag använda [SVGOptions.VectorizeText](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/vectorizetext/) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions.VectorizeText](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/vectorizetext/) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska omvandlas till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnitts-filer när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG-kvalitet och vektorisering av text alla har olika kvalitets- och storleksavvägningar.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan de matchande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.