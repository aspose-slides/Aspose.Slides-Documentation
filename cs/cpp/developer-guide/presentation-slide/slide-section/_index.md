---
title: Správa sekcí snímků v prezentacích pomocí C++
linktitle: Sekce snímku
type: docs
weight: 100
url: /cs/cpp/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- získat snímky sekce
- zpracovat snímky sekce
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro C++: vytvářejte, přejmenovávejte, měňte pořadí, získávejte a zpracovávejte snímky sekcí v prezentacích PPTX."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro C++ můžete vytvářet, měnit pořadí, přejmenovávat, prohlížet a odstraňovat sekce pomocí metody [Presentation::get_Sections](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sections/) .

Sekce jsou zvláště užitečné, když:

- velká prezentace musí být rozdělena na logické témata nebo kapitoly;
- různé skupiny snímků jsou přiděleny různým spolupracovníkům;
- snímky potřebují být zpracovány, přesunuty nebo sloučeny jako skupiny.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, používejte API sekcí k určení příslušnosti místo odvozování z pozic snímků.

## **Vytváření a správa sekcí**

Použijte [ISectionCollection::AddSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/addsection/) k vytvoření sekce zadáním jejího názvu a úvodního snímku. Aspose.Slides určuje, které snímky patří do sekce, podle aktuální struktury sekcí prezentace.

Stejný [ISectionCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/) vám také umožní:

- přesunout sekci spolu se svými snímky pomocí [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- odstranit pouze definici sekce pomocí [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/removesection/), přičemž snímky zůstávají;
- odstranit sekci i její snímky pomocí [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- přidat prázdnou sekci na konec pomocí [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/appendemptysection/) .

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu se snímky a přidá prázdnou sekci:

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

Po těchto operacích prezentace obsahuje sekci `Introduction` se svými snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce zavolejte [ISection::set_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/set_name/). Snímky sekce a její pozice zůstávají beze změny.

Následující příklad vytvoří sekci a změní její název:

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

## **Získání snímků ze sekcí**

Metoda [Presentation::get_Sections](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sections/) vrací [ISectionCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectioncollection/), kterou můžete enumerovat. Pro každou [ISection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/), zavolejte [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/getslideslistofsection/) abyste získali snímky, které do ní právě patří. Metoda vrací [ISectionSlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectionslidecollection/), která poskytuje počet, indexovaný přístup a enumeraci.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou sekci, poté vypíše pro každou sekci její [název](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/get_name/), [identifikátor](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/get_sectionid/), [úvodní snímek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/get_startedfromslide/), počet snímků a čísla snímků. Používá indexovaný přístup k načtení prvního snímku a smyčku typu `for` založenou na rozsahu k zpracování všech snímků. Pro prázdnou sekci má vrácená kolekce počet nula, indexovaný přístup se nepoužívá a enumerace neprovádí žádné iterace.

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

Příslušnost ke sekci je určena strukturou sekcí v prezentaci. Nepočítejte ručně rozsah sekce z [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/get_startedfromslide/), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou změnit jak snímky vrácené pro sekci, tak jejich čísla. To zahrnuje změnu pořadí snímků, klonování snímku do sekce, přesunutí sekce spolu se snímky, odstraňování snímků i sekcí. Další příklad volá [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/getslideslistofsection/) po každé takové změně místo zachování předpokladů o předchozích hranicích sekce.

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

Zavolejte [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/getslideslistofsection/) znovu vždy, když jsou snímky nebo sekce přeuspořádány, klonovány, přesunuty nebo odstraněny. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který podporuje sekce, například PPTX; konverze do PPT odstraní strukturu sekcí potřebnou pro pozdější enumeraci.

## **FAQ**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.

**Může být celá sekce "skrytá"?**

Ne. Sekce nemá stav viditelnosti. Pro skrytí jejího obsahu zavolejte [ISlide::set_Hidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/set_hidden/) pro každý snímek v sekci.

**Jak mohu najít sekci, která obsahuje snímek?**

Enumerujte [Presentation::get_Sections](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sections/), zavolejte [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/getslideslistofsection/) pro každou sekci a porovnejte vrácené snímky s cílovým snímkem. Pro neprázdnou sekci [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/get_startedfromslide/) vrací její první snímek; pro prázdnou sekci vrací `nullptr`.