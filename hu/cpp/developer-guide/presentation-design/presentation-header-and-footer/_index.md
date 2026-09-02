---
title: Prezentáció fejlécek és láblécek kezelése C++-ban
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/cpp/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kézjegyzék
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum-idő, diaszám és fejléc helyfoglalókat diákon, jegyzetoldalakon és kézjegyzékeken az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A PowerPoint különböző fejléc- és lábléchelyfoglalókat használ az oldaltípustól függően. Az Aspose.Slides for C++ lehetővé teszi, hogy ezeket a helyfoglalókat a fejléc/lábléc kezelői felületeken keresztül szabályozza a szöveg és a láthatóság szempontjából.

Az elérhető helyfoglalók a hatókör függvényei:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Normál dia | Nem | Igen | Igen | Igen |
| Jegyzet-mester | Igen | Igen | Igen | Igen |
| Jegyzet dia | Igen | Igen | Igen | Igen |
| Kézjegyzék-mester | Igen | Igen | Igen | Igen |

Egy normál prezentációs diának nincs fejléchelyfoglalója. A fejlécek a jegyzetoldalakon és a kézjegyzékeken érhetők el. Normál diák esetén a lábléc, a dátum/idő és a diaszám helyfoglalókat használja helyette.

A módosítás hatóköre attól a kezelőtől függ, amelyet használ. Az [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideheaderfootermanager/) interfész egy normál diát vezérel. Az [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslideheaderfootermanager/) interfész egy jegyzet-diat vezérel. A mester- és elrendezéskezelők szintén képesek a beállításokat a függő diákra propagálni, míg a [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) interfész a kézjegyzék-mestert kezeli.

## **Lábléc, Dátum/Idő és Diaszámok beállítása normál diákon**

Normál diák esetén az alapmunkafolyamat az, hogy elérje minden dia fejléc/lábléc kezelőjét, beállítsa a lábléc és a dátum/idő szöveget, engedélyezze a szükséges helyfoglalókat, és mentse a prezentációt. A diaszámokat a prezentáció generálja, ezért csak a láthatóságukat kell szabályoznia.

Használja a [`SetFooterText`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) és a [`SetDateTimeText`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) metódusokat a szöveg beállításához, illetve a [`SetFooterVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), a [`SetDateTimeVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) és a [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) metódusokat a megfelelő helyfoglalók megjelenítéséhez.

Az alábbi teljes példa ugyanazt a láblécet, dátum/idő szöveget és diaszám láthatóságot alkalmazza minden normál diára:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Ha csak egy diát kell frissíteni, érje el azt közvetlenül a [`Presentation::get_Slide`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slide/) segítségével, a teljes dia gyűjtemény iterálása helyett.

## **Fejlécek és Láblécek beállítása a Jegyzet-mesteren**

A jegyzet-mester meghatározza a közös formázást és a helyfoglalók viselkedését a jegyzetoldalak számára. Használja az [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/) interfészt, ha csak magát a jegyzet-mestert akarja módosítani.

Az alábbi példa beállítja a fejlécet, a láblécet és a dátum/idő szöveget a jegyzet-mesteren, és láthatóvá teszi az összes támogatott helyfoglalót ezen a mesteren:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Az [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) metódus `nullptr`-t ad vissza, ha a prezentáció nem tartalmaz jegyzet-mestert.

## **Jegyzet-mester beállításainak alkalmazása a gyermek jegyzet-diapokra**

A jegyzet-mester a fejléc- és láblécbeállításokat saját magára és minden függő jegyzet-diarra alkalmazhatja. Használja a dedikált propagációs metódusokat az [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/) esetén, ha ugyanazokat a beállításokat a jegyzet-hierarchiában kell alkalmazni.

Például a [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) és a [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) frissíti a jegyzet-mester fejlécét és minden gyermekfejlécet. Hasonló metódusok állnak rendelkezésre a láblécek, a dátum/idő és a diaszámok esetén.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

A fent használt propagációs metódusok a [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), a [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), a [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), a [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) valamint a [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/) metódusok.

## **Fejlécek és láblécek beállítása egy egyedi jegyzet-dian**

Egy jegyzet-dia egy adott normál diahoz tartozik. Használja annak [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslideheaderfootermanager/) interfészét, ha csak azt a jegyzet-oldalt szeretné testre szabni.

A [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslidemanager/addnotesslide/) metódus visszaadja az aktuális dia jegyzet-diaját, és létrehoz egyet, ha még nem létezik. Az alábbi példa az első prezentációs diához tartozó jegyzet-oldalt konfigurálja:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Ha először a jegyzet-mestertől propagálja a beállításokat, majd módosít egy egyedi jegyzet-diat, az utóbbi per-dia beállítások lehetővé teszik, hogy önállóan testre szabja azt a jegyzet-oldalt.

## **Fejlécek és láblécek beállítása a Kézjegyzék-mesteren**

A kézjegyzék-oldalak a kézjegyzék-mestert használják a fejléc, lábléc, dátum/idő és oldalszám helyfoglalóikhoz. A jegyzet-oldalakhoz képest a kézjegyzék beállításait a kézjegyzék-mester, nem pedig egyedi kézjegyzék-diák kezelik.

Használja a [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) metódust a kézjegyzék-master eléréséhez. Ha nincs jelen, hívja a [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) metódust az alapértelmezett kézjegyzék-master létrehozásához.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **A hatókör és öröklődés megértése**

Válassza ki azt a fejléc/lábléc kezelőt, amely megfelel a módosítani kívánt hatókörnek:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islideheaderfootermanager/) módosítja a lábléc, dátum/idő és diaszám beállításait egy normál dián.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslideheaderfootermanager/) egy elrendezés-diat vezérli, és a támogatott beállításokat a függő diákra propagálhatja.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslideheaderfootermanager/) egy normál dia mesterét vezérli, és a támogatott beállításokat a függő diákra propagálhatja.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasternotesslideheaderfootermanager/) a jegyzet-mestert vezérli, és a beállításokat az összes függő jegyzet-diarra propagálhatja.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotesslideheaderfootermanager/) egy jegyzet-diat módosít, és a lábléc, dátum/idő és diaszám mellett fejléchez is biztosít helyfoglalót.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) a kézjegyzék-mestert módosítja, és támogatja mind a négy helyfoglalótípust.

Használja a propagációt egy mester vagy elrendezés esetén, ha ugyanazt a beállítást az egész hierarchiában alkalmazni kell. Használjon egyedi diát vagy jegyzet-dia kezelőt, ha egyetlen oldalhoz helyi beállításra van szükség.

## **GYIK**

**Hozzáadhatok fejléct egy normál diához?**  
Nem. A PowerPoint nem definiál fejléchelyfoglalót a normál diákhoz. Normál diák esetén használja a lábléc, a dátum/idő és a diaszám helyfoglalókat. A fejléchelyfoglalók a jegyzetoldalakon és a kézjegyzékeken érhetők el.

**Mi a teendő, ha egy lábléc, dátum/idő vagy diaszám helyfoglaló nem látható?**  
Használja a megfelelő fejléc/lábléc kezelőt a láthatóság ellenőrzéséhez és engedélyezéshez, ha szükséges. Például a [`get_IsFooterVisible`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) jelzi, hogy a lábléc helyfoglaló jelen van-e, és a [`SetFooterVisibility`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) megváltoztatja a láthatóságát.

**Hogyan indíthatom a diaszámozást 1‑től eltérő értékkel?**  
Használja a [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/set_firstslidenumber/) metódust az első diaszám beállításához. A diaszám helyfoglalók ezután az új számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF‑re, képekre vagy HTML‑re exportáláskor?**  
A látható fejléc- és lábléc elemek a prezentáció többi tartalmával együtt kerülnek renderelésre a kimeneti formátumban. Megjelenésük attól függ, hogy mely oldaltípust exportálják, és a megfelelő helyfoglaló láthatósági beállításoktól.