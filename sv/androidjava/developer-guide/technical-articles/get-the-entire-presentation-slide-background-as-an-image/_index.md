---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hel bildbakgrund
type: docs
weight: 95
url: /sv/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- bildbakgrund
- slutlig bakgrund
- extrahera bakgrund
- hel bakgrund
- bakgrund till bild
- PPT‑bakgrund
- PPTX‑bakgrund
- ODP‑bakgrund
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Extrahera fullständiga bildbakgrunder som bilder från PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för Android via Java, och förenkla visuella arbetsflöden."
---
## **Översikt**

I PowerPoint‑presentationer kan en bildbakgrund bestå av flera element, inklusive bildens bakgrundsbild, presentationstema, färgschema och objekt som placeras på mastern eller layoutbilden.

Den här artikeln visar hur du extraherar hela bildbakgrunden som en bild med Aspose.Slides för .NET. Eftersom det inte finns en enda metod för denna uppgift innebär tillvägagångssättet att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för Android via Java erbjuder ingen enkel metod för att extrahera hela presentationsbildens bakgrund som en bild, men du kan följa stegen nedan för att göra detta:
1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela presentationsbildens bakgrund som en bild.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Vanliga frågor**

**Kommer komplexa gradienter, texturer eller bildfyllningar från en masterbild att bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient-, bild- och texturfyllningar som definierats på bilden, layouten eller mastern. Om du behöver isolera utseendet från ärvda masterbilder, [ange en egen bakgrund](/slides/sv/androidjava/presentation-background/) på den aktuella bilden innan export.

**Kan jag lägga till en vattenstämpel i den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till en vattenstämpel](/slides/sv/androidjava/watermark/) som form eller bild på en arbets-[kopia av bilden](/slides/sv/androidjava/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta låter dig skapa en bakgrundsbild med vattenstämpeln inbäddad.

**Kan jag hämta bakgrunden för en specifik layout eller master utan att koppla den till en befintlig bild?**

Ja. Åtkomst till önskad master eller layout, applicera den på en [tillfällig bild](/slides/sv/androidjava/clone-slides/) med önskad storlek och exportera den bilden för att erhålla bakgrunden hämtad från den layouten eller mastern.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/androidjava/licensing/). I utvärderingsläge kan output innehålla begränsningar som en vattenstämpel. Aktivera licensen en gång per process innan du kör batch‑exporter.