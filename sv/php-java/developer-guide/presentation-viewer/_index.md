---
title: Skapa en presentationsvisare i PHP
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/php-java/presentation-viewer/
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
- PHP
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare med Aspose.Slides för PHP via Java. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för PHP via Java används för att skapa presentationsfiler med bilder. Dessa bilder kan visas genom att öppna presentationer i Microsoft PowerPoint, till exempel. I vissa fall kan utvecklare behöva visa bilder som bilder i sin föredragna bildvisare eller skapa sin egen presentationsvisare. I sådana fall låter Aspose.Slides dig exportera en enskild bild som en bild. Den här artikeln beskriver hur du gör det.

## **Generera en SVG-bild från en bild**

För att generera en SVG-bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta bildreferensen med dess index.
3. Öppna en filström.
4. Spara bilden som en SVG-bild till filströmmen.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Generera en SVG med ett anpassat form-ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form-ID. För att göra detta, använd `setId`‑metoden från [SvgShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` kan användas för att ange form‑ID:t.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Skapa en miniatyrbild av en bild**

Aspose.Slides hjälper dig att generera miniatyrbilder av bilder. För att skapa en miniatyr av en bild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta bildreferensen med dess index.
3. Hämta miniatyrbilden av den refererade bilden i en definierad skala.
4. Spara miniatyrbilden i önskat bildformat.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Skapa en miniatyrbild med användardefinierade dimensioner**

För att skapa en miniatyrbild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta bildreferensen med dess index.
3. Hämta miniatyrbilden av den refererade bilden med de definierade dimensionerna.
4. Spara miniatyrbilden i önskat bildformat.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Skapa en miniatyrbild med talarnoteringar**

För att generera en miniatyr av en bild med talarnoteringar med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/).
2. Använd metoden `RenderingOptions.setSlidesLayoutOptions` för att ange positionen för talarnoteringar.
3. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
4. Hämta bildreferensen med dess index.
5. Hämta miniatyrbilden av den refererade bilden med renderingsalternativen.
6. Spara miniatyrbilden i önskat bildformat.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Liveexempel**

Du kan prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides API:

![Online PowerPoint‑visare](online-PowerPoint-viewer.png)

## **Vanliga frågor**

**Kan jag bädda in en presentationsvisare i en webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bilder som bilder eller HTML och visa dem i webbläsaren. Navigations- och zoomfunktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bilder i en anpassad visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller en HTML‑behållare (för webb).

**Hur hanterar jag stora presentationer med många bilder?**

För stora presentationer, överväg lazy‑loading eller rendering på begäran av bilder. Det innebär att generera en bilds innehåll endast när användaren navigerar till den, vilket minskar minnes- och laddningstid.