---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hela bildbakgrunden
type: docs
weight: 95
url: /sv/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- bildbakgrund
- slutlig bakgrund
- extrahera bakgrund
- hel bakgrund
- bakgrund till bild
- PPT-bakgrund
- PPTX-bakgrund
- ODP-bakgrund
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Extrahera hela bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java, vilket effektiviserar visuella arbetsflöden."
---
## **Översikt**

I PowerPoint-presentationer kan en bildbakgrund bestå av flera element, inklusive bildbakgrundsbilden, presentationstemat, färgschemat och objekt som placerats på mastern eller layoutbilden.

Denna artikel visar hur man extraherar hela bildbakgrunden som en bild med hjälp av Aspose.Slides för .NET. Eftersom det inte finns någon enskild metod för detta, går tillvägagångssättet ut på att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för Java erbjuder inte en enkel metod för att extrahera hela bildbakgrunden i en presentation som en bild, men du kan följa stegen nedan för att göra det:
1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Kommer komplexa gradienter, texturer eller bildfyllningar från en mastern att bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient‑, bild‑ och texturfyllningar som definierats på bilden, layouten eller mastern. Om du behöver isolera utseendet från ärvda master, [ange en egen bakgrund](/slides/sv/java/presentation-background/) på den aktuella bilden innan export.

**Kan jag lägga till ett vattenmärke i den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till ett vattenmärke](/slides/sv/java/watermark/) som form eller bild på en arbets-[kopia av bilden](/slides/sv/java/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta gör att du kan skapa en bakgrundsbild med vattenmärket inbakat.

**Kan jag hämta bakgrunden för en specifik layout eller master utan att koppla den till en befintlig bild?**

Ja. Åtkomst till önskad master eller layout, tillämpa den på en [tillfällig bild](/slides/sv/java/clone-slides/) med önskad storlek och exportera den bilden för att få bakgrunden som härrör från den layouten eller mastern.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/java/licensing/). I evalueringsläge kan utdata ha begränsningar som ett vattenmärke. Aktivera licensen en gång per process innan du kör batch‑export.