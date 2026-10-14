---
title: Konvertera PowerPoint-bilder till PNG i C++
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/cpp/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- C++
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder snabbt med Aspose.Slides för C++, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för C++. Du kan ladda presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑bild.

Exemplen nedan visar rendering med standardskala, ökande skala, ange utmatningsdimensioner i pixlar och välja en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) och få åtkomst till dess bilder via åtkomstmetoden [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Exemplet renderar varje bild med [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) utan parametrar för att skapa en miniatyr. Det anropar sedan [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) med [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) för att spara varje renderad bild som en PNG‑bild.

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
Den parametriska overloaden [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) renderar med en skala på 0,2. Till exempel producerar en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att styra utmatningsdimensionerna, använd overloads med skalningsfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Skicka horisontella och vertikala skalningsfaktorer till [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) för att kontrollera de renderade dimensionerna. I detta exempel är båda faktorerna 2, så en bild som mäter 720 × 540 punkter producerar en bild på 1440 × 1080 pixlar. Lika skalningsfaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

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

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utmatningsdimensioner i pixlar, skicka en storlek till [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) istället för skalningsfaktorer. Detta exempel renderar varje bild med 960 × 720 pixlar och sparar resultatet med [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

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

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut jämfört med vad du ser i PowerPoint. Du kan använda metoden [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) i [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i programmets arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul nedtill. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel laddar denna presentation och renderar samma första bild i båda lägen med [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

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

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `Default` lättare mellanfärger, medan `PowerPointUI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `Default` när den standardmässiga Aspose.Slides‑utmatningen passar dina behov. Prova `PowerPointUI` när ditt mål är att matcha utseendet i PowerPoint. Jämför båda utmatningarna med ditt önskade resultat; inget läge är generellt föredraget.

## **FAQ**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stödjer [generering av miniatyrbilder för enskilda former](/slides/sv/cpp/shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [dela inte en enda instans mellan trådar](/slides/sv/cpp/multithreading/).

**Vad är begränsningarna i evalueringsläget när du exporterar till PNG?**

Evalueringsläget lägger till ett vattenmärke i utdata bilder och tillämpar [andra begränsningar](/slides/sv/cpp/licensing/) tills en licens har aktiverats.