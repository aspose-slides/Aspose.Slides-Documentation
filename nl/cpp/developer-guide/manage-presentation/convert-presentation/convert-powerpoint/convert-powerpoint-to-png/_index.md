---
title: PowerPoint-dia's converteren naar PNG in C++
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- C++
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor C++, met nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑dia's kunt converteren naar PNG‑afbeeldingen met Aspose.Slides voor C++. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke dia renderen en opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden demonstreren renderen op de standaard schaal, het verhogen van de schaal, het specificeren van de uitvoerafmetingen in pixels, en het kiezen van een gradiënten‑renderingsstijl.

## **PowerPoint converteren naar PNG**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse en krijg toegang tot de dia's via de [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/)‑accessor. Het voorbeeld rendert elke dia met [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) zonder parameters om een miniatuur te maken. Vervolgens wordt [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) aangeroepen met [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) om elke gerenderde dia op te slaan als een PNG‑afbeelding.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
De parameterloze overload van [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) rendert op een schaal van 0.2. Bijvoorbeeld, een dia van 720 × 540 punten produceert een miniatuur van 144 × 108 pixels. Om de uitvoerafmetingen te beheersen, gebruik de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder weergegeven.
{{% /alert %}}

## **PowerPoint converteren naar PNG met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) om de gerenderde afmetingen te bepalen. In dit voorbeeld zijn beide factoren 2, waardoor een dia van 720 × 540 punten een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de dia. Elke afbeelding wordt opgeslagen in PNG‑formaat met [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint converteren naar PNG met aangepaste grootte**

Om uitvoerafmetingen in pixels te specificeren, geef een grootte door aan [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) in plaats van schaalfactoren. Dit voorbeeld rendert elke dia op 960 × 720 pixels en slaat het resultaat op met [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Kies afmetingen die overeenkomen met de beeldverhouding van de dia om uitrekken van de afbeelding te voorkomen.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Een gradiënt‑renderingsstijl kiezen**

Stel dat een dia gradiëntvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan in PowerPoint. U kunt de methode [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) van [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) gebruiken om te bepalen hoe de gradiënten worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats dit in de werkmap van de applicatie. De eerste dia bevat twee lineaire gradiënten: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradiënt heeft twee stops op 0% en 100%.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste dia in beide modi met [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

De onderstaande afbeeldingen tonen de uitvoer van dezelfde dia, met beide gradiënten in elke afbeelding:

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel gradiënten gerenderd met Default](gradient-Default.png) | ![Dezelfde gradiënten gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld levert `Default` lichtere tussenkleuren op, terwijl `PowerPointUI` donkerdere tussenkleuren oplevert. Het verschil hangt af van de kleuren en stops in de gradiënt.

Kies `Default` wanneer de standaarduitvoer van Aspose.Slides aan uw behoeften voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide uitvoer met uw beoogde resultaat; geen van beide modi is in alle gevallen te verkiezen.

## **Veelgestelde vragen**

**Hoe kan ik een specifiek object, zoals een diagram of afbeelding, exporteren in plaats van de volledige dia?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/cpp/shape-thumbnails/), waardoor u een vorm kunt renderen als een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte presentatie‑instantie voor elke thread of elk proces; [deel geen enkele instantie over threads](/slides/nl/cpp/multithreading/).

**Wat zijn de evaluatiebeperkingen bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en past [andere beperkingen](/slides/nl/cpp/licensing/) toe totdat een licentie is geactiveerd.