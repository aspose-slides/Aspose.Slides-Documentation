---
title: Effektivt slå samman presentationer i C++
linktitle: Slå samman presentationer
type: docs
weight: 40
url: /sv/cpp/merge-presentation/
keywords:
- slå samman PowerPoint
- slå samman presentationer
- slå samman bilder
- slå samman PPT
- slå samman PPTX
- slå samman ODP
- kombinera PowerPoint
- kombinera presentationer
- kombinera bilder
- kombinera PPT
- kombinera PPTX
- kombinera ODP
- C++
- Aspose.Slides
description: "Slå enkelt samman PowerPoint (PPT, PPTX) och OpenDocument (ODP)-presentationer med Aspose.Slides för C++, vilket förenklar ditt arbetsflöde."
---
## **Översikt**

Aspose.Slides låter dig slå samman presentationer genom att klona bilder från en presentation till en annan. Den här artikeln förklarar hur du slår samman hela presentationer eller utvalda bilder, använder en bildbakgrund eller en specifik layout under sammanslagningen, hanterar presentationer med olika bildstorlekar och lägger till sammanslagna bilder i ett presentationsavsnitt. Den täcker också praktiska anteckningar relaterade till sammanslaget innehåll, inklusive talarnoter, kommentarer, lösenordsskyddade källfiler och trådanvändning.

## **Sammanslagning av presentationer**

När du slår samman en presentation med en annan kombinerar du i praktiken deras bilder i en enda presentation för att få en fil. 

{{% alert title="Info" color="info" %}}

De flesta presentationsprogram (PowerPoint eller OpenOffice) saknar funktioner som låter användare kombinera presentationer på detta sätt. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/sv/cpp/), men låter dig slå samman presentationer på olika sätt. Du kan slå samman presentationer med alla deras former, stilar, texter, formatering, kommentarer, animationer etc. utan att behöva oroa dig för kvalitets- eller dataförlust. 

**Se även**

[Klona bilder](https://docs.aspose.com/slides/sv/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Vad kan slås samman**

Med Aspose.Slides kan du slå ihop 

* hela presentationer. Alla bilder från presentationerna hamnar i en enda presentation
* specifika bilder. Utvalda bilder hamnar i en enda presentation
* presentationer i ett format (PPT till PPT, PPTX till PPTX, etc) och i olika format (PPT till PPTX, PPTX till ODP, etc) till varandra. 

{{% alert title="Note" color="warning" %}} 

Förutom presentationer låter Aspose.Slides dig slå samman andra filer:

* [Bilder](https://products.aspose.com/slides/sv/cpp/merger/image-to-image/), såsom [JPG till JPG](https://products.aspose.com/slides/sv/cpp/merger/jpg-to-jpg/) eller [PNG till PNG](https://products.aspose.com/slides/sv/cpp/merger/png-to-png/)
* Dokument, såsom [PDF till PDF](https://products.aspose.com/slides/sv/cpp/merger/pdf-to-pdf/) eller [HTML till HTML](https://products.aspose.com/slides/sv/cpp/merger/html-to-html/)
* Och två olika filer såsom [bild till PDF](https://products.aspose.com/slides/sv/cpp/merger/image-to-pdf/) eller [JPG till PDF](https://products.aspose.com/slides/sv/cpp/merger/jpg-to-pdf/) eller [TIFF till PDF](https://products.aspose.com/slides/sv/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Sammanslagningsalternativ**

Du kan använda alternativ som bestämmer om

* varje bild i resultatpresentationen behåller en unik stil
* en specifik stil används för alla bilder i resultatpresentationen. 

För att slå samman presentationer tillhandahåller Aspose.Slides [AddClone](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)‑metoder (från [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection)‑gränssnittet). Det finns flera implementationer av `AddClone`‑metoderna som definierar parametrarna för presentationssammanfogningsprocessen. Varje Presentation‑objekt har en [Slides](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑samling, så du kan anropa en `AddClone`‑metod från den presentation du vill slå samman bilder till. 

`AddClone`‑metoden returnerar ett `ISlide`‑objekt, vilket är en klon av källbilden. Bilderna i en resultatpresentation är helt enkelt en kopia av bilderna från källan. Därför kan du göra ändringar i de resulterande bilderna (t.ex. tillämpa stilar eller formateringsalternativ eller layouter) utan att oroa dig för att källpresentationerna påverkas. 

## **Slå samman presentationer** 

Aspose.Slides tillhandahåller metoden [**AddClone (ISlide)**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) som låter dig kombinera bilder medan bilderna behåller sina layouter och stilar (standardparametrar). 

Denna C++‑kod visar hur du slår samman presentationer:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slå samman presentationer med en bildbakgrund**

Aspose.Slides tillhandahåller metoden [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) som låter dig kombinera bilder medan du använder en bildbakgrundsmall för presentationen. På så sätt kan du, om det behövs, ändra stilen för bilderna i resultatpresentationen. 

Denna C++‑kod demonstrerar den beskrivna operationen:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Bildlayouten för bildbakgrunden bestäms automatiskt. När en lämplig layout inte kan bestämmas, om den booleska parametern `allowCloneMissingLayout` för `AddClone`‑metoden är satt till true, används layouten för källbilden. Annars kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Om du vill att bilderna i resultatpresentationen ska ha en annan bildlayout, använd istället metoden [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) vid sammanslagning. 

## **Slå samman specifika bilder från presentationer**

Att slå samman specifika bilder från flera presentationer är användbart för att skapa anpassade bildspel. Aspose.Slides C++ låter dig välja och importera bara de bilder du behöver. API‑et bevarar formatering, layout och design på de ursprungliga bilderna.

Följande C++‑kod skapar en ny presentation, lägger till titelföredrag från två andra presentationer och sparar resultatet till en fil:

```cpp
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

## **Slå samman presentationer med en bildlayout**

Denna C++‑kod visar hur du kombinerar bilder från presentationer samtidigt som du tillämpar din föredragna bildlayout för att få en enda resultatpresentation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Slå samman presentationer med olika bildstorlekar**

{{% alert title="Note" color="warning" %}} 

Du kan inte slå samman presentationer med olika bildstorlekar. 

{{% /alert %}}

För att slå samman två presentationer med olika bildstorlekar måste du ändra storleken på den ena presentationen så att den matchar den andra. 

Denna exempel­kod demonstrerar den beskrivna operationen:

```cpp
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

## **Slå samman bilder till ett presentationsavsnitt**

Denna C++‑kod visar hur du slår samman en specifik bild till ett avsnitt i en presentation:

```cpp
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

{{% alert title="Tip" color="primary" %}}

Aspose erbjuder en [FREE Collage web app](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå samman [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare. 

{{% /alert %}}

## **FAQ**

**Behålls talarnoter vid sammanslagning?**

Ja. När du klonar bilder tar Aspose.Slides med alla bildelement, inklusive noteringar, formatering och animationer.

**Överförs kommentarer och deras författare?**

Kommentarer, som en del av bildinnehållet, kopieras med bilden. Kommentarförfattarnas etiketter bevaras som kommentarobjekt i den resulterande presentationen.

**Vad händer om källpresentationen är lösenordsskyddad?**

Den måste [öppnas med lösenordet](/slides/sv/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/); efter inläsning kan dessa bilder säkert klonas till en icke‑skyddad målfil (eller även en skyddad).

**Hur trådsäker är sammanslagningsoperationen?**

Använd inte samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/cpp/multithreading/). Den rekommenderade regeln är "ett dokument — en tråd"; olika filer kan bearbetas parallellt i separata trådar.