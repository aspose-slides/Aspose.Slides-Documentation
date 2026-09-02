---
title: Beheer dia secties in presentaties met C++
linktitle: Dia sectie
type: docs
weight: 100
url: /nl/cpp/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- sectiedia's ophalen
- sectiedia's verwerken
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer dia secties met Aspose.Slides voor C++: maak, hernoem, herschik, haal op en verwerk sectiedia's in PPTX-presentaties."
---
## **Introductie**

Secties organiseren opeenvolgende dia’s in benoemde groepen zonder de inhoud van de dia’s te wijzigen. Met Aspose.Slides voor C++ kunt u secties maken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation::get_Sections](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sections/)‑methode.

Secties zijn vooral nuttig wanneer:

- een grote presentatie moet worden onderverdeeld in logische onderwerpen of hoofdstukken;
- verschillende groepen dia’s aan verschillende medewerkers worden toegewezen;
- dia’s moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienaam­en die het doel van de gegroepeerde dia’s beschrijven. Omdat secties deel uitmaken van de presentatiestructuur, gebruikt u de sectie‑API’s om lidmaatschap te bepalen in plaats van dit af te leiden van dia‑posities.

## **Secties maken en beheren**

Gebruik [ISectionCollection::AddSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/addsection/) om een sectie te maken door de naam en de startdia op te geven. Aspose.Slides bepaalt welke dia’s tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [ISectionCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/) stelt u ook in staat om:

- een sectie samen met zijn dia’s te verplaatsen via [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- alleen de sectiedefinitie te verwijderen met [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/removesection/), waarna de dia’s behouden blijven;
- een sectie en zijn dia’s te verwijderen met [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- een lege sectie aan het einde toe te voegen met [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/appendemptysection/).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert deze samen met zijn dia’s en voegt een lege sectie toe:

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

Na deze bewerkingen bevat de presentatie de sectie `Introductie` met zijn dia’s en een lege sectie `Bijlage`. De sectie `Resultaten` en de bijbehorende dia’s zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, roept u [ISection::set_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/set_name/) aan. De dia’s en de positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en wijzigt de naam:

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

## **Dia’s uit secties ophalen**

De [Presentation::get_Sections](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sections/)‑methode retourneert een [ISectionCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectioncollection/) die u kunt doorlopen. Voor elke [ISection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/) roept u [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/getslideslistofsection/) aan om de dia’s te verkrijgen die momenteel tot de sectie behoren. De methode retourneert een [ISectionSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectionslidecollection/), die een telling, geïndexeerde toegang en enumeratie biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en print vervolgens voor elke sectie de [naam](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/get_name/), [identificator](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/get_sectionid/), [startdia](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/get_startedfromslide/), aantal dia’s en dianummers. Het gebruikt geïndexeerde toegang om de eerste dia te lezen en een range‑gebaseerde `for`‑lus om elke dia te verwerken. Voor de lege sectie heeft de geretourneerde collectie een telling van nul; er wordt geen geïndexeerde toegang gebruikt en enumeratie voert geen iteraties uit.

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

Sectielidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bepaal de reikwijdte van een sectie niet handmatig aan de hand van [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/get_startedfromslide/), dia‑indexen en de startdia van de volgende sectie.

Structurele bewerkingen kunnen zowel de dia’s die voor een sectie worden geretourneerd als hun dianummers wijzigen. Dit omvat het herschikken van dia’s, het klonen van een dia naar een sectie, het verplaatsen van een sectie met zijn dia’s, het verwijderen van dia’s en het verwijderen van secties. Het volgende voorbeeld roept [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/getslideslistofsection/) aan na elke dergelijke wijziging in plaats van veronderstellingen over de voormalige grenzen van de sectie te behouden.

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

Roep [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/getslideslistofsection/) opnieuw aan telkens wanneer dia’s of secties worden herschikt, gekloond, verplaatst of verwijderd. Hierdoor blijft de vervolgverwerking afgestemd op de huidige presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) bewaart geen sectiemetadata. Gebruik deze werkwijze met een formaat dat secties ondersteunt, zoals PPTX; conversie naar PPT verwijdert de sectiestructuur die nodig is voor latere enumeratie.

## **FAQ**

**Worden secties behouden bij het opslaan in het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als *.ppt*.

**Kan een volledige sectie “verborgen” worden?**

Nee. Een sectie heeft geen zichtbaarheidstoestand. Om de inhoud te verbergen, roept u [ISlide::set_Hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/set_hidden/) aan voor elke dia in de sectie.

**Hoe vind ik de sectie die een bepaalde dia bevat?**

Door [Presentation::get_Sections](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sections/) te enumereren, voor elke sectie [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/getslideslistofsection/) aan te roepen en de geretourneerde dia’s te vergelijken met de doel‑dia. Voor een niet‑lege sectie geeft [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isection/get_startedfromslide/) de eerste dia terug; voor een lege sectie wordt `nullptr` geretourneerd.