---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hela bildbakgrunden
type: docs
weight: 95
url: /sv/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- bildbakgrund
- slutgiltig bakgrund
- extrahera bakgrund
- hel bakgrund
- bakgrund till bild
- PPT-bakgrund
- PPTX-bakgrund
- ODP-bakgrund
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Extrahera hela bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET, och förenkla visuella arbetsflöden."
---
## **Översikt**

I PowerPoint-presentationer kan en bildbakgrund bestå av flera element, inklusive bildbakgrundsbilden, presentationstemat, färgschemat och objekt som placerats på mastern eller layoutbilden.

Den här artikeln visar hur du extraherar hela bildbakgrunden som en bild med Aspose.Slides för .NET. Eftersom det inte finns någon enda metod för detta, innebär tillvägagångssättet att klona den valda bilden till en temporär presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för .NET erbjuder ingen enkel metod för att extrahera hela presentationsbildens bakgrund som en bild, men du kan följa stegen nedan för att göra det:
1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en temporär presentation.
1. Ställ in samma bildstorlek i den temporära presentationen.
1. Klona den valda bilden till den temporära presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela presentationsbildens bakgrund som en bild.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **Vanliga frågor**

**Komplexa gradienter, texturer eller bildfyllningar från en masterslides bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient-, bild- och texturfyllningar som definierats på bilden, layouten eller masteren. Om du behöver isolera utseendet från ärvda masters, [ange en egen bakgrund](/slides/sv/net/presentation-background/) på den aktuella bilden före export.

**Kan jag lägga till ett vattenmärke i den resulterande bakgrundsbilden innan jag sparar den?**

Ja. Du kan [lägga till ett vattenmärke](/slides/sv/net/watermark/) som en form eller bild på en arbets-[kopia av bilden](/slides/sv/net/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta låter dig generera en bakgrundsbild med vattenmärket inbakat.

**Kan jag hämta bakgrunden för en specifik layout eller master utan att koppla den till en befintlig bild?**

Ja. Åtkomst till önskad master eller layout, applicera den på en [temporär bild](/slides/sv/net/clone-slides/) med den erforderliga storleken och exportera den bilden för att få bakgrunden som härstammar från den layouten eller masteren.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktionerna är fullt tillgängliga med en [giltig licens](/slides/sv/net/licensing/). I utvärderingsläge kan utdata innehålla begränsningar såsom ett vattenmärke. Aktivera licensen en gång per process innan du kör batchexporter.