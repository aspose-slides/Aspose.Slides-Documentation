---
title: Dia szekciók kezelése prezentációkban C++-ben
linktitle: Dia szekció
type: docs
weight: 100
url: /hu/cpp/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- szekció diák lekérése
- szekció diák feldolgozása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a dia szekciókat az Aspose.Slides for C++-ban: hozza létre, nevezze át, rendezze át, kérje le, és dolgozza fel a szekció diákat PPTX prezentációkban."
---
## **Bevezetés**

A szekciók egymás után következő diák csoportosítására szolgálnak név szerint, anélkül, hogy a diák tartalmát megváltoztatnák. Az Aspose.Slides for C++ segítségével a szekciókat a [Presentation::get_Sections](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_sections/) metódussal hozhatja létre, rendezheti át, nevezheti át, ellenőrizheti és távolíthatja el.

A szekciók különösen hasznosak, ha:

- egy nagy bemutatót logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző munkatársakhoz kell rendelni;
- a diák csoportokként kell, hogy feldolgozhatók, áthelyezhetők vagy egyesíthetők legyenek.

Válasszon tömör szekciónévket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató struktúrájának részei, a szekció API‑kat használja a tagság meghatározásához, a diák pozíciójából történő levezetés helyett.

## **Szekciók létrehozása és kezelése**

Használja a [ISectionCollection::AddSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/addsection/) metódust egy szekció létrehozásához a név és a kezdő dia megadásával. Az Aspose.Slides a bemutató aktuális szekciószerkezete alapján határozza meg, mely diák tartoznak a szekcióhoz.

Az ugyanaz a [ISectionCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/) lehetővé teszi továbbá:

- egy szekció és diái áthelyezését a [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) használatával;
- csak a szekciódefiníció eltávolítását a [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/removesection/) segítségével, amely megőrzi a diákot;
- a szekció és diái együttes eltávolítását a [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/removesectionwithslides/) használatával;
- egy üres szekció hozzáadását a végére a [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/appendemptysection/) metódussal.

Az alábbi példa két szekciót hoz létre, az egyik áthelyezi, eltávolítja együtt a diái­val, majd egy üres szekciót fűz hozzá:

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

E műveletek után a bemutató tartalmazza a `Introduction` szekciót a diái­val és egy üres `Appendix` szekciót. A `Results` szekció és a benne lévő diák eltávolításra kerültek.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja a [ISection::set_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/set_name/) metódust. A szekció diái és pozíciója változatlan marad.

Az alábbi példa létrehoz egy szekciót és megváltoztatja a nevét:

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

## **Diák lekérdezése a szekciókból**

A [Presentation::get_Sections](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_sections/) metódus egy [ISectionCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectioncollection/) objektumot ad vissza, amelyet enumerálhat. Minden [ISection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/) esetén hívja a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/getslideslistofsection/) metódust a jelenleg hozzá tartozó diák lekéréséhez. A metódus egy [ISectionSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectionslidecollection/) objektumot ad vissza, amely számlálót, indexelt elérést és enumerációt biztosít.

Az alábbi példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [nevét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/get_name/), [azonosítóját](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/get_sectionid/), [kezdő diabját](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/get_startedfromslide/), a diák számát és a dia számokat. Indexelt hozzáféréssel olvassa az első diát, a range‑alapú `for` ciklussal pedig minden diát feldolgoz. Az üres szekciónál a visszaadott gyűjtemény darabszáma nulla, indexelt hozzáférés nem használatos, az enumeráció nem hajt végre iterációkat.

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

A szekciótagság a bemutató szekciószerkezete alapján határozható meg. Ne számolja ki manuálisan egy szekció tartományát a [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/get_startedfromslide/), diaindexek és a következő szekció kezdő diapontja alapján.

A strukturális módosítások megváltoztathatják egy szekcióhoz visszaadott diák listáját és azok dia számait is. Ide tartozik a diák átrendezése, egy dia klónozása egy szekcióba, egy szekció és diái áthelyezése, diák eltávolítása és szekciók törlése. A következő példa minden ilyen változás után meghívja a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/getslideslistofsection/), ahelyett, hogy a szekció korábbi határait feltételezné.

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

Hívja újra a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/getslideslistofsection/) metódust, valahányszor diákat vagy szekciókat átrendeznek, klónoznak, áthelyeznek vagy eltávolítanak. Így a további feldolgozás a jelenlegi bemutató struktúrához igazodik.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatait. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX‑szel; a PPT‑re konvertálás eltávolítja a későbbi enumeráláshoz szükséges szekciószerkezetet.

## **GYIK**

**Megmaradnak a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik a .ppt mentésekor.

**Lehet egy teljes szekciót „elrejteni”?**

Nem. A szekciónak nincs láthatósági állapota. A tartalmát elrejteni kell minden egyes diára a [ISlide::set_Hidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/set_hidden/) metódust meghívni a szekcióban.

**Hogyan találhatom meg azt a szekciót, amelyik egy adott diát tartalmaz?**

Iterálja a [Presentation::get_Sections](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_sections/) elemeit, hívja meg a [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/getslideslistofsection/) metódust minden szekción, és hasonlítsa össze a visszakapott diákat a cél diával. Egy nem üres szekció esetén a [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isection/get_startedfromslide/) visszaadja az első diát; egy üres szekció esetén `nullptr`‑t ad.