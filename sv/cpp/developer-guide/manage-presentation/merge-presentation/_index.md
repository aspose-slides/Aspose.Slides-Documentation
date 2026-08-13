---
title: Effektivt slå ihop presentationer i C++
linktitle: Slå ihop presentationer
type: docs
weight: 40
url: /sv/cpp/merge-presentation/
keywords:
- slå ihop PowerPoint
- slå ihop presentationer
- slå ihop bilder
- slå ihop PPT
- slå ihop PPTX
- slå ihop ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- C++
- Aspose.Slides
description: "Slå enkelt ihop PowerPoint (PPT, PPTX) och OpenDocument (ODP) presentationer med Aspose.Slides för C++ och effektivisera ditt arbetsflöde."
---
## **Översikt**

Aspose.Slides låter dig slå ihop presentationer genom att klona bilder från en presentation till en annan. Den här artikeln förklarar hur du slår ihop hela presentationer eller utvalda bilder, använder ett bildmästertema eller en specifik layout under sammanslagningen, hanterar presentationer med olika bildstorlekar och lägger till sammanslagna bilder i ett presentationsavsnitt. Den täcker också praktiska noteringar relaterade till sammanslaget innehåll, inklusive föreläsningsanteckningar, kommentarer, lösenordsskyddade källfiler och trådanvändning.

## **Sammanslagning av presentationer**

När du slår ihop en presentation med en annan kombinerar du i praktiken deras bilder i en enda presentation för att få en fil. 

{{% alert title="Info" color="info" %}}

De flesta presentationsprogram (PowerPoint eller OpenOffice) saknar funktioner som tillåter användare att kombinera presentationer på detta sätt. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/sv/cpp/) , tillåter dig dock att slå ihop presentationer på olika sätt. Du kan slå ihop presentationer med alla deras former, stilar, texter, formatering, kommentarer, animationer osv. utan att behöva oroa dig för kvalitets- eller dataförlust. 

**Se även**

[Klona bilder](https://docs.aspose.com/slides/sv/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Vad som kan slås ihop**

Med Aspose.Slides kan du slå ihop 

* hela presentationer. Alla bilder från presentationerna hamnar i en presentation
* specifika bilder. Utvalda bilder hamnar i en presentation
* presentationer i samma format (PPT till PPT, PPTX till PPTX osv.) och i olika format (PPT till PPTX, PPTX till ODP osv.) till varandra. 

{{% alert title="Note" color="warning" %}} 

Förutom presentationer låter Aspose.Slides dig slå ihop andra filer:

* [Bilder](https://products.aspose.com/slides/sv/cpp/merger/image-to-image/), såsom [JPG till JPG](https://products.aspose.com/slides/sv/cpp/merger/jpg-to-jpg/) eller [PNG till PNG](https://products.aspose.com/slides/sv/cpp/merger/png-to-png/)
* Dokument, såsom [PDF till PDF](https://products.aspose.com/slides/sv/cpp/merger/pdf-to-pdf/) eller [HTML till HTML](https://products.aspose.com/slides/sv/cpp/merger/html-to-html/)
* Och två olika filer såsom [bild till PDF](https://products.aspose.com/slides/sv/cpp/merger/image-to-pdf/) eller [JPG till PDF](https://products.aspose.com/slides/sv/cpp/merger/jpg-to-pdf/) eller [TIFF till PDF](https://products.aspose.com/slides/sv/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Sammanfogningsalternativ**

Du kan tillämpa alternativ som bestämmer om

* varje bild i den resulterande presentationen behåller en unik stil
* en specifik stil används för alla bilder i den resulterande presentationen. 

För att slå ihop presentationer tillhandahåller Aspose.Slides [AddClone](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)-metoder (från [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection)-gränssnittet). Det finns flera implementationer av `AddClone`‑metoderna som definierar parametrarna för sammanslagningsprocessen. varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑samling, så du kan anropa en `AddClone`‑metod från den presentation du vill slå ihop bilder i. 

`AddClone`‑metoden returnerar ett `ISlide`‑objekt, som är en klon av källbilden. Bilderna i en utdata‑presentation är helt enkelt en kopia av bilderna från källan. Därmed kan du göra ändringar i de resulterande bilderna (t.ex. tillämpa stilar, formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas. 

## **Slå ihop presentationer** 

Aspose.Slides tillhandahåller metoden [**AddClone (ISlide)**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) som låter dig kombinera bilder samtidigt som bilderna behåller sina layouter och stilar (standardparametrar). 

Denna C++‑kod visar hur du slår ihop presentationer:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slå ihop presentationer med ett bildmästertema**

Aspose.Slides tillhandahåller metoden [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) som låter dig kombinera bilder samtidigt som ett bildmästertema tillämpas. På så sätt kan du, om så behövs, ändra stilen för bilderna i utdata‑presentationen. 

Denna C++‑kod demonstrerar den beskrivna operationen:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Layouten för bildmästertemat bestäms automatiskt. När en lämplig layout inte kan bestämmas, används layouten för källbilden om `allowCloneMissingLayout`‑parametern i `AddClone`‑metoden är satt till true. Annars kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Om du vill att bilderna i utdata‑presentationen ska ha en annan layout kan du använda metoden [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) istället när du slår ihop. 

## **Slå ihop specifika bilder från presentationer**

Att slå ihop specifika bilder från flera presentationer är användbart för att skapa anpassade bilduppsättningar. Aspose.Slides C++ låter dig välja och importera endast de bilder du behöver. API‑et bevarar formatering, layout och design från de ursprungliga bilderna.

Följande C++‑kod skapar en ny presentation, lägger till titelförslag från två andra presentationer och sparar resultatet till en fil:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Deklarerad i koden ovan.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Slå ihop presentationer med en bildlayout**

Denna C++‑kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout för att få en enda utdata‑presentation:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slå ihop presentationer med olika bildstorlekar**

{{% alert title="Note" color="warning" %}} 

Du kan inte slå ihop presentationer med olika bildstorlekar. 

{{% /alert %}}

För att slå ihop två presentationer med olika bildstorlekar måste du ändra storleken på en av dem så att den matchar den andras storlek. 

Denna exempelkod demonstrerar den beskrivna operationen:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slå ihop bilder till ett presentationsavsnitt**

Denna C++‑kod visar hur du slår ihop en specifik bild till ett avsnitt i en presentation:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Bilden läggs till i slutet av avsnittet. 

{{% alert title="Tip" color="info" %}}

Aspose tillhandahåller en [FREE Collage web app](https://products.aspose.app/slides/sv/collage). Med denna onlinetjänst kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid) med mera. 

{{% /alert %}}

## **FAQ**

### Behålls föreläsningsanteckningar vid sammanslagning?

Ja. När bilder klonas överför Aspose.Slides alla bildelement, inklusive anteckningar, formatering och animationer.

### Överförs kommentarer och deras författare?

Kommentarer, som en del av bildinnehållet, kopieras med bilden. Kommentarförfattarens etiketter bevaras som kommentarsobjekt i den resulterande presentationen.

### Vad händer om källpresentationen är lösenordsskyddad?

Den måste [öppnas med lösenord](/slides/sv/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/); efter inläsning kan dessa bilder säkert klonas till en oskyddad målfil (eller även en skyddad fil).

### Hur trådsäker är sammanslagningsoperationen?

Använd inte samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/cpp/multithreading/). Den rekommenderade regeln är "ett dokument — en tråd"; olika filer kan behandlas parallellt i separata trådar.