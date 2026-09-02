---
title: Hantera bildsektioner i presentationer med C++
linktitle: Bildsektion
type: docs
weight: 100
url: /sv/cpp/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionens namn
- hämta sektionbilder
- bearbeta sektionbilder
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera bildsektioner med Aspose.Slides för C++: skapa, byta namn, ändra ordning, hämta och bearbeta sektionbilder i PPTX-presentationer."
---
## **Introduktion**

Sektioner organiserar på varandra följande bilder i namngivna grupper utan att ändra bildens innehåll. Med Aspose.Slides för C++ kan du skapa, ändra ordning, byta namn, inspektera och ta bort sektioner via metoden [Presentation::get_Sections](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sections/).

Sektioner är särskilt användbara när:

- en stor presentation behöver delas in i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder behöver bearbetas, flyttas eller slås ihop som grupper.

Välj koncisa sektionsnamn som beskriver syftet med de grupperade bilderna. Eftersom sektioner är en del av presentationens struktur, använd sektions‑API:erna för att bestämma medlemskap i stället för att härleda det från bildpositioner.

## **Skapa och hantera sektioner**

Använd [ISectionCollection::AddSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/addsection/) för att skapa en sektion genom att ange dess namn och startbild. Aspose.Slides avgör vilka bilder som tillhör sektionen utifrån presentationens nuvarande sektionsstruktur.

Samma [ISectionCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/) låter dig också:

- flytta en sektion tillsammans med sina bilder genom att använda [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- ta bort endast sektionsdefinitionen med [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/removesection/), vilket behåller dess bilder;
- ta bort en sektion och dess bilder med [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- lägga till en tom sektion i slutet med [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/appendemptysection/).

Följande exempel skapar två sektioner, flyttar en av dem, tar bort den tillsammans med sina bilder och lägger till en tom sektion:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Efter dessa operationer innehåller presentationen `Introduction`-sektionen med sina bilder och en tom `Appendix`-sektion. `Results`-sektionen och dess bilder har tagits bort.

## **Byt namn på sektioner**

För att byta namn på en sektion, anropa [ISection::set_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/set_name/). Sektionens bilder och position förblir oförändrade.

Följande exempel skapar en sektion och ändrar dess namn:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Hämta bilder från sektioner**

Metoden [Presentation::get_Sections](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sections/) returnerar en [ISectionCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectioncollection/) som du kan iterera över. För varje [ISection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/), anropar du [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/getslideslistofsection/) för att få de bilder som för närvarande tillhör den. Metoden returnerar en [ISectionSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectionslidecollection/), som tillhandahåller ett antal, indexerad åtkomst och enumeration.

Följande exempel skapar två fyllda sektioner och en tom sektion, och skriver sedan ut varje sektions [name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/get_startedfromslide/), antalet bilder och bildnumren. Det använder indexerad åtkomst för att läsa den första bilden och en räckviddsbaserad `for`-loop för att bearbeta varje bild. För den tomma sektionen har den returnerade samlingen ett antal på noll, indexerad åtkomst används inte och enumeration utför inga iterationer.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Sektionsmedlemskap bestäms av presentationens sektionsstruktur. Beräkna inte en sektions intervall manuellt från [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/get_startedfromslide/), bildindex och nästa sektions startbild.

Strukturella redigeringar kan förändra både de bilder som returneras för en sektion och deras bildnummer. Detta inkluderar att ändra ordning på bilder, klona en bild till en sektion, flytta en sektion tillsammans med dess bilder, ta bort bilder och ta bort sektioner. Nästa exempel anropar [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/getslideslistofsection/) efter varje sådan förändring istället för att behålla antaganden om sektionens tidigare gränser.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Anropa [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/getslideslistofsection/) igen när bilder eller sektioner har ändrat ordning, klonats, flyttats eller tagits bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT-formatet (PowerPoint 97–2003) bevarar inte sektionmetadata. Använd detta arbetsflöde med ett format som stöder sektioner, till exempel PPTX; konvertering till PPT tar bort den sektionstruktur som behövs för senare enumeration.

## **FAQ**

**Bevaras sektioner när de sparas till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT-formatet stöder inte sektionmetadata, så sektiongruppering går förlorad när du sparar till .ppt.

**Kan en hel sektion \"döljas\"?**

Nej. En sektion har inget synlighetstillstånd. För att dölja dess innehåll, anropa [ISlide::set_Hidden](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/set_hidden/) för varje bild i sektionen.

**Hur kan jag hitta sektionen som innehåller en bild?**

Iterera igenom [Presentation::get_Sections](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sections/), anropa [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/getslideslistofsection/) för varje sektion och jämför de returnerade bilderna med målbilden. För en icke-tom sektion returnerar [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isection/get_startedfromslide/) dess första bild; för en tom sektion returneras `nullptr`.