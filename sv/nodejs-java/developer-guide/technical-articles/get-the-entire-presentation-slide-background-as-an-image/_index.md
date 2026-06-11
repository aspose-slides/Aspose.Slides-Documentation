---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hela bildbakgrunden
type: docs
weight: 95
url: /sv/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahera hela bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java, och förenkla visuella arbetsflöden."
---
## **Översikt**

I PowerPoint-presentationer kan en bildbakgrund bestå av flera element, inklusive bildbakgrundsbilden, presentationstemat, färgschemat och objekt som placerats på mastern eller layoutbilderna.

Denna artikel visar hur du extraherar hela bildbakgrunden som en bild med Aspose.Slides. Eftersom det inte finns en enda metod för detta innebär tillvägagångssättet att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för Node.js via Java tillhandahåller inte en enkel metod för att extrahera hela presentationsbildens bakgrund som en bild, men du kan följa stegen nedan för att göra detta:
1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela presentationsbildens bakgrund som en bild.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **Vanliga frågor**

**Kommer komplexa gradienter, texturer eller bildfyllningar från en mastern att bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient-, bild- och texturfyllningar som definierats på bilden, layouten eller mastern. Om du behöver isolera utseendet från ärvda master kan du [ange en egen bakgrund](/slides/sv/nodejs-java/presentation-background/) på den aktuella bilden innan export.

**Kan jag lägga till ett vattenmärke i den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till ett vattenmärke](/slides/sv/nodejs-java/watermark/) som form eller bild på en [kopia av bilden](/slides/sv/nodejs-java/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta låter dig skapa en bakgrundsbild med vattenmärket ingraverat.

**Kan jag få bakgrunden för en specifik layout eller master utan att knyta den till en befintlig bild?**

Ja. Åtkomst till önskad master eller layout, applicera den på en [tillfällig bild](/slides/sv/nodejs-java/clone-slides/) med önskad storlek och exportera den bilden för att få bakgrunden härledd från den layouten eller mastern.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/nodejs-java/licensing/). I evalueringsläge kan resultatet innehålla begränsningar såsom ett vattenmärke. Aktivera licensen en gång per process innan du kör batchexporter.