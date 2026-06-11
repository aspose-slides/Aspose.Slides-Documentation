---
title: Skapa en presentationsvisare på Android
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare i Java med Aspose.Slides för Android. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för Android via Java används för att skapa presentationsfiler med bilder. Dessa bilder kan visas genom att öppna presentationer i Microsoft PowerPoint, till exempel. I vissa fall kan utvecklare behöva visa bilder som bilder i sin föredragna bildvisare eller skapa sin egen presentationsvisare. I sådana fall låter Aspose.Slides dig exportera en enskild bild som en bild. Den här artikeln beskriver hur man gör det.

## **Skapa en SVG-bild från en bild**

För att skapa en SVG-bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Öppna en filström.
1. Spara bilden som en SVG-bild till filströmmen.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Skapa en SVG med ett anpassat form-ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form-ID. För att göra detta, använd `setId`-metoden från [ISvgShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` kan användas för att ange form-ID:t.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Skapa en bildminiatyr**

Aspose.Slides hjälper dig att skapa miniatyrbilder av bilder. För att generera en miniatyr av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden i en definierad skala.
1. Spara miniatyrbilden i valfritt bildformat.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Skapa en bildminiatyr med användardefinierade dimensioner**

För att skapa en miniatyrbild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med de definierade dimensionerna.
1. Spara miniatyrbilden i valfritt bildformat.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Skapa en bildminiatyr med presentatörsanteckningar**

För att generera miniatyrbilden av en bild med presentatörsanteckningar med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/renderingoptions/).
1. Använd metoden `RenderingOptions.setSlidesLayoutOptions` för att ange positionen för presentatörsanteckningarna.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med renderingsalternativen.
1. Spara miniatyrbilden i valfritt bildformat.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Liveexempel**

Du kan prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bilder som bilder eller HTML och visa dem i webbläsaren. Navigations- och zoomfunktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bilder i en egen visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller i en HTML‑behållare (för webb).

**Hur hanterar jag stora presentationer med många bilder?**

För stora presentationer, överväg lazy‑loading eller rendering på begäran av bilderna. Det betyder att generera en bilds innehåll först när användaren navigerar till den, vilket minskar minnes- och laddningstid.