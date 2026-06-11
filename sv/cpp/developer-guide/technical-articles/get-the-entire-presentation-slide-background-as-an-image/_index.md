---
title: Hämta hela bildbakgrunden från en presentation som en bild
linktitle: Hel bildbakgrund
type: docs
weight: 95
url: /sv/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Extrahera hela bildbakgrunder som bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++, vilket förenklar visuella arbetsflöden."
---
## **Översikt**

I PowerPoint‑presentationer kan en bildbakgrund bestå av flera element, inklusive bildens bakgrundsbild, presentationstema, färgschema och objekt som placeras på mastern eller layout‑bilden.

Den här artikeln visar hur du extraherar hela bildbakgrunden som en bild med hjälp av Aspose.Slides. Eftersom det inte finns någon enda metod för detta arbete, innebär tillvägagångssättet att klona den valda bilden till en tillfällig presentation, ta bort bildens former och sedan konvertera den resulterande bildbakgrunden till en bild.

## **Hämta hela bildbakgrunden**

Aspose.Slides för C++ erbjuder ingen enkel metod för att extrahera hela bildbakgrunden i en presentation som en bild, men du kan följa stegen nedan för att göra det:
1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta bildens storlek från presentationen.
1. Välj en bild.
1. Skapa en tillfällig presentation.
1. Ställ in samma bildstorlek i den tillfälliga presentationen.
1. Klona den valda bilden till den tillfälliga presentationen.
1. Ta bort formerna från den klonade bilden.
1. Konvertera den klonade bilden till en bild.

Följande kodexempel extraherar hela bildbakgrunden i presentationen som en bild.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **FAQ**

**Kommer komplexa gradienter, texturer eller bildfyllningar från en mastern att bevaras i den resulterande bakgrundsbilden?**

Ja. Aspose.Slides renderar gradient‑, bild‑ och texturfyllningar som definierats på bilden, layouten eller mastern. Om du behöver isolera utseendet från ärvda masterbilder, [ange en egen bakgrund](/slides/sv/cpp/presentation-background/) på den aktuella bilden innan export.

**Kan jag lägga till ett vattenmärke i den resulterande bakgrundsbilden innan den sparas?**

Ja. Du kan [lägga till ett vattenmärke](/slides/sv/cpp/watermark/) som form eller bild på en arbets-[kopia av bilden](/slides/sv/cpp/clone-slides/) (placerad bakom annat innehåll) och sedan exportera. Detta gör det möjligt att generera en bakgrundsbild med vattenmärket inbäddat.

**Kan jag hämta bakgrunden för en specifik layout eller master utan att koppla den till en befintlig bild?**

Ja. Åtkomst till den önskade mastern eller layouten, tillämpa den på en [tillfällig bild](/slides/sv/cpp/clone-slides/) med önskad storlek och exportera den bilden för att få bakgrunden som härrör från den layouten eller mastern.

**Finns det licensbegränsningar som påverkar bildexport?**

Renderingsfunktioner är fullt tillgängliga med en [giltig licens](/slides/sv/cpp/licensing/). I evalueringsläge kan output innehålla begränsningar såsom ett vattenmärke. Aktivera licensen en gång per process innan du kör batch‑exporter.