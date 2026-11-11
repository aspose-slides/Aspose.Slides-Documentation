---
title: Rendera presentationsbilder som SVG‑bilder i .NET
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
- SVG‑exportalternativ
- interaktiv SVG
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Exportera PowerPoint‑bilder som SVG‑bilder i .NET och kontrollera teckensnitt, text, bilder, ID:n och händelser med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, teckensnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) när den exporterade SVG-filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), välj en bild och skriv den till en ström. Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Filnamnet använder [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) istället för loop‑indexet. Du kan också exportera en enskild form med [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG‑utdata**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) styr SVG-rendering. För textramar inkluderar [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) textramen i renderingsområdet, och [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) bestämmer om ramrotationen tillämpas. Ställ in [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) på `true` när text måste renderas utan ligaturer.

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

När du exporterar bilder till SVG kan du styra om text förblir som text eller konverteras till vektorgrafik, samt hur externa teckensnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textmarkering och teckensnittsberoenden i den exporterade SVG-filen.

### **Vektorisera all text**

Ställ in [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) på `true` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittsberoenden och gör det visuella resultatet mer konsistent i olika webbläsare, men texten blir inte längre valbar eller sökbar som SVG‑text.

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `AddLinksToFontFiles` för att referera separata teckensnittsfiler, `Embed` för att inkludera teckensnittsdata i SVG:n, eller `Vectorize` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittslicenser innan du bäddar in teckensnitt.

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

## **Minska storlek på inbäddade bilder**

Använd [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) för att minska upplösningen på inbäddade bilder, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) för att utelämna beskurna källområden, och [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) för att styra JPEG‑kodningskvalitet. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

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

## **Styr rasteriseringsupplösning för metafiler**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) sätter den lägre upplösningsgränsen för rasterisering av metafiler under SVG‑export. Använd den för att balansera detaljrikedom och filstorlek när en EMF‑ eller WMF‑bild rasteriseras. Den definierar inte ett globalt DPI för SVG:n eller tvingar varje objekt på bilden att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF‑bild med tät placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

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

I resultatet blir EMF en inbäddad PNG i varje SVG. Följande mått gäller den medföljande presentationen; de är inte en allmän formel för att konvertera DPI till pixeldimensioner.

| Metafils rasteriserings‑DPI | Inbäddade PNG-dimensioner | SVG‑filstorlek (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstorade visningsstorlek. Diagonal linjer visar synlig pixelering vid 72 DPI och mjukare kanter vid högre upplösningar, samtidigt som SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller ändrar varje exporterad bild.

![Förstorad detalj av diagonal linje vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) styr reduktion av bildupplösning och kan maskera effekten av att ändra metafils rasteriseringsupplösning. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) styr JPEG‑kodningskvalitet, inte metafils rasteriseringsupplösning.

## **Tilldela stabila ID:n till former och text**

Använd [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) för att ange [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) för varje SVG‑form. För att även sätta [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/)‑värden på text‑`tspan`‑element, implementera [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tilldela någon av kontrollerna med [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Följande kontroller använder [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), som är stabil under formens livstid, samt en repeterbar räknare för dess textsprång. Detta gör de genererade ID:n lämpliga för efterbehandling av en oförändrad presentation.

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

I en [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) anropar du [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) med ett [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/)-värde för att lägga till en JavaScript‑händelsehanterare på en exporterad form. Tilldela kontrolleren med [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) och definiera JavaScript‑funktionen på sidan eller i SVG‑dokumentet som innehåller resultatet.

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

## **FAQ**

**När bör jag använda [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) istället för [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text har olika kompromisser mellan kvalitet och storlek.

**Kan jag ändra exporterade SVG‑element efter export?**

Ja. Tilldela ID:n via en formateringskontroller och välj sedan de motsvarande SVG‑elementen i ditt efterbehandlingsverktyg eller browserskript.