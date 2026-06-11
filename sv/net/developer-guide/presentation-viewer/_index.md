---
title: Skapa en presentationsvisare i .NET
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/net/presentation-viewer/
keywords:
- visa presentation
- presentationsvisare
- skapa presentationsvisare
- visa PPT
- visa PPTX
- visa ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare i .NET med Aspose.Slides. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för .NET används för att skapa presentationsfiler med bilder. Dessa bilder kan visas genom att öppna presentationerna i Microsoft PowerPoint, till exempel. Ibland kan utvecklare behöva visa bilder som bilder i sin föredragna bildvisare eller använda dem i en anpassad presentationsvisare. I sådana fall låter Aspose.Slides dig exportera enskilda bilder som bildfiler. Denna artikel förklarar hur du gör det.

## **Generera en SVG-bild från en bild**

För att generera en SVG-bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till bilden med dess index.
1. Öppna en filström.
1. Spara bilden som en SVG-bild till filströmmen.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Generera en SVG med ett anpassat form-ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form-`ID`. För att uppnå detta, använd Id‑egenskapen från gränssnittet [ISvgShape](https://reference.aspose.com/slides/sv/net/aspose.slides.export/isvgshape). Klassen `CustomSvgShapeFormattingController` kan användas för att ange formens ID.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Skapa en miniatyrbild av en bild**

Aspose.Slides hjälper dig att generera miniatyrbilder av bilder. För att generera en miniatyr av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till bilden med dess index.
1. Skapa en miniatyrbild av den refererade bilden i önskad skala.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Skapa en miniatyrbild med användardefinierade dimensioner**

För att skapa en miniatyrbild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till bilden med dess index.
1. Generera en miniatyrbild av den refererade bilden med de angivna dimensionerna.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Skapa en miniatyrbild med talarnoter**

För att generera en miniatyr av en bild med talarnoter med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/).
1. Använd egenskapen `RenderingOptions.SlidesLayoutOptions` för att ställa in positionen för talarnoterna.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta en referens till bilden med dess index.
1. Generera en miniatyrbild av den refererade bilden med hjälp av renderingsalternativen.
1. Spara miniatyrbilden i ditt föredragna bildformat.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Live-exempel**

Prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides API:

[![Online PowerPoint-visare](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/sv/viewer/)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en ASP.NET-webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bilder som bilder eller HTML och visa dem i webbläsaren. Navigations- och zoomfunktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bilder i en anpassad .NET‑visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller HTML‑behållare (för webb).

**Hur hanterar jag stora presentationer med många bilder?**

För stora upplägg, överväg lazy‑loading eller rendera bilder på begäran. Det innebär att generera en bilds innehåll endast när användaren navigerar till den, vilket minskar minnes‑ och laddningstid.