---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hel bildbakgrund
type: docs
weight: 95
url: /sv/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Extrahera fullständiga bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java, vilket förenklar visuella arbetsflöden."
---
## **Översikt**

I PowerPoint-presentationer kan en bildbakgrund bestå av flera element, inklusive bildbakgrundsbild, presentationstema, färgschema och objekt placerade på huvudbilden eller layoutbilden.

Denna artikel visar hur du extraherar hela bildbakgrunden som en bild med Aspose.Slides. Eftersom det inte finns någon enkel metod för detta, går tillvägagångssättet ut på att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för PHP via Java tillhandahåller ingen enkel metod för att extrahera hela bildbakgrunden i en presentation som en bild, men du kan följa stegen nedan för att göra det:
1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta bildstorleken från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela bildbakgrunden i en presentation som en bild.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **Vanliga frågor**

**Kommer komplexa gradienter, texturer eller bildfyllningar från en huvudbild att bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient-, bild- och texturfyllningar som definierats på bilden, layouten eller huvudbilden. Om du behöver isolera utseendet från ärvda huvudbilder, [ange en egen bakgrund](/slides/sv/php-java/presentation-background/) på den aktuella bilden innan du exporterar.

**Kan jag lägga till ett vattenstämpel på den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till ett vattenstämpel](/slides/sv/php-java/watermark/) form eller bild på en arbets[kopia av bilden](/slides/sv/php-java/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta låter dig generera en bakgrundsbild med vattenstämpeln inbäddad.

**Kan jag få bakgrunden för en specifik layout eller huvudbild utan att binda den till en befintlig bild?**

Ja. Åtkomst till önskad huvudbild eller layout, applicera den på en [tillfällig bild](/slides/sv/php-java/clone-slides/) med önskad storlek och exportera den bilden för att få bakgrunden som härstammar från den layouten eller huvudbilden.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/php-java/licensing/). I utvärderingsläge kan utdata innehålla begränsningar såsom ett vattenstämpel. Aktivera licensen en gång per process innan du kör batchexport.