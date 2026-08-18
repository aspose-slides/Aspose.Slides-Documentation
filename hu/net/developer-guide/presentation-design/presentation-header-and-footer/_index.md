---
title: "Prezentációs fejlécek és láblécek kezelése .NET-ben"
linktitle: "Fejléc és lábléc"
type: docs
weight: 140
url: /hu/net/presentation-header-and-footer/
keywords:
- "fejléc"
- "fejléc szöveg"
- "lábléc"
- "lábléc szöveg"
- "fejléc beállítása"
- "lábléc beállítása"
- "szórólap"
- "jegyzet"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum-idő, dia-szám és fejléc helyőrzőket diákon, jegyzetoldalakon és szórólapokon az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A PowerPoint a lap típusa szerint különböző fejléc‑ és lábléchelyőrzőket használ. Az Aspose.Slides for .NET lehetővé teszi ezen helyőrzők szövegének és láthatóságának vezérlését a fejléc/lábléc‑kezelő interfészeken keresztül.

A rendelkezésre álló helyőrzők a hatótávolság („scope”) szerint változnak:

| Hatótávolság | Fejléc | Lábjegyzet | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Általános dia | Nem | Igen | Igen | Igen |
| Jegyzet mester | Igen | Igen | Igen | Igen |
| Jegyzet dia | Igen | Igen | Igen | Igen |
| Szórólap mester | Igen | Igen | Igen | Igen |

Egy általános prezentációs diának nincs fejléchelyőrzője. A fejlécek a jegyzetoldalakon és a szórólapokon érhetők el. Általános diák esetén a lábléc, a dátum/idő és a dia‑szám helyőrzőket használja.

A módosítás hatótávolsága attól függ, melyik kezelőt használja. Az [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/islideheaderfootermanager/) egyetlen általános diát szabályoz. Az [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/inotesslideheaderfootermanager/) egyetlen jegyzet diát szabályoz. A mester‑ és elrendezéskezelők a beállításokat a függő diákra is kiterjeszthetik, míg az [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslideheaderfootermanager/) a szórólap mestert irányítja.

## **Lábléc, dátum/idő és dia‑szám beállítása általános diákon**

Általános diák esetén az alapvető munkafolyamat a következő: minden dia fejléc/lábléc‑kezelőjéhez hozzáfér, beállítja a lábléc és a dátum/idő szövegét, engedélyezi a szükséges helyőrzőket, és menti a prezentációt. A dia‑számot a prezentáció generálja, csak a láthatóságát kell szabályozni.

Használja a [`SetFooterText`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) és a [`SetDateTimeText`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) metódusokat a szöveg beállításához, valamint a [`SetFooterVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) és a [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) metódusokat a megfelelő helyőrzők megjelenítéséhez.

Az alábbi végponttól‑végpontig tartó példa ugyanazt a láblécet, dátum/idő szöveget és dia‑szám láthatóságot alkalmazza minden általános diára:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Ha csak egyetlen diát kell frissíteni, érje el a diát közvetlenül a [`Slides`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjteményen keresztül a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzet mesteren**

A jegyzet mester határozza meg a jegyzetoldalak közös formázását és helyőrző‑viselkedését. Használja az [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslideheaderfootermanager/) interfészt, ha csak a jegyzet mestert szeretné módosítani.

Az alábbi példa beállítja a fejlécet, láblécet és a dátum/idő szöveget a jegyzet mesteren, és az összes támogatott helyőrzőt láthatóvá teszi ezen a mesteren:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

A [`MasterNotesSlide`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslidemanager/masternotesslide/) tulajdonság `null`‑t ad vissza, ha a prezentáció nem tartalmaz jegyzet mestert.

## **Jegyzet mester beállításainak alkalmazása a gyerek jegyzet diákra**

A jegyzet mester képes a fejléc‑ és lábléc‑beállításokat saját magára és az összes függő jegyzet diára kiterjeszteni. Használja a dedikált propagációs metódusokat az [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslideheaderfootermanager/) felületén, ha ugyanazokat a beállításokat akarja a jegyzet hierarchia minden szintjén alkalmazni.

Például a [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) és a [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) frissíti a jegyzet mester fejlécét és az összes gyermekfejlécet. Hasonló metódusok állnak rendelkezésre a láblécek, a dátum/idő és a dia‑számok esetén.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

A fent használt propagációs metódusok:
[`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/),
[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/),
[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/),
[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/),
és a [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Fejlécek és láblécek beállítása egyéni jegyzet dián**

Egy jegyzet dia egy konkrét általános dia része. Használja a saját [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/inotesslideheaderfootermanager/) interfészét, ha csak azt a jegyzetoldalt szeretné testre szabni.

A [`AddNotesSlide`](https://reference.aspose.com/slides/hu/net/aspose.slides/inotesslidemanager/addnotesslide/) metódus visszaadja az aktuális dia jegyzet diáját, és ha még nem létezik, létrehozza azt. Az alábbi példa az első prezentációs diahoz tartozó jegyzetoldalt konfigurálja:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Ha először a jegyzet mester beállításait propagálja, majd egy egyedi jegyzet diát módosít, az utóbbi per‑dia beállítások lehetővé teszik a jegyzetoldal független testreszabását.

## **Fejlécek és láblécek beállítása a Szórólap mesteren**

A szórólap oldalak a szórólap mestert használják a fejléc, lábléc, dátum/idő és oldalszám helyőrzőihez. A jegyzet oldalakkal ellentétben a szórólap beállításait a szórólap mester, nem pedig az egyes szórólap diák kezelik.

Használja a [`MasterHandoutSlide`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) tulajdonságot a szórólap mester eléréséhez. Ha nem létezik, hívja meg a [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) metódust az alapértelmezett szórólap mester létrehozásához.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Hatótávolság és öröklődés megértése**

Válassza ki a kívánt hatótávolságnak megfelelő fejléc/lábléc‑kezelőt:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/islideheaderfootermanager/) egyetlen általános dia lábléc, dátum/idő és dia‑szám beállításait módosítja.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslideheaderfootermanager/) egy elrendezés diasablont irányít, és a támogatott beállításokat a függő diákra továbbadhatja.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslideheaderfootermanager/) egy szabványos dia mestert szabályoz, és a támogatott beállításokat a függő diákra propagálja.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslideheaderfootermanager/) a jegyzet mestert irányítja, és beállításait az összes függő jegyzet diára terjeszti ki.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/inotesslideheaderfootermanager/) egyetlen jegyzet diát módosít, és a fejléc helyőrzőt is támogatja a lábléc, dátum/idő és dia‑szám mellett.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterhandoutslideheaderfootermanager/) a szórólap mestert módosítja, és mind a négy helyőrző típust támogatja.

Használja a propagációt egy mester‑ vagy elrendezéskezelőből, ha ugyanazt a beállítást szeretné a hierarchia minden szintjén alkalmazni. Használjon egyéni diát vagy jegyzet‑diakezelőt, ha lokális beállításra van szükség egyetlen oldalhoz.

## **GYIK**

**Hozzáadhatok fejlécet egy általános diához?**

Nem. A PowerPoint nem definiál fejléchelyőrzőt általános diákhoz. Általános diák esetén a lábléc, a dátum/idő és a dia‑szám helyőrzőket kell használni. A fejléchelyőrzők a jegyzetoldalakon és a szórólapokon érhetők el.

**Mi történik, ha egy lábléc, dátum/idő vagy dia‑szám helyőrző nem látható?**

Használja a megfelelő fejléc/lábléc‑kezelőt a láthatóság ellenőrzéséhez és engedélyezéséhez. Például az [`IsFooterVisible`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) azt jelzi, hogy a lábléchelyőrző jelen van‑e, a [`SetFooterVisibility`](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) pedig módosítja a láthatóságát.

**Hogyan indíthatom a dia‑számozást 1‑nél eltérő értékkel?**

Állítsa be a prezentáció [`FirstSlideNumber`](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/firstslidenumber/) tulajdonságát. Ezután a dia‑szám helyőrzők az új számozási sorrendet használják.

**Mi történik a fejléc‑ és lábléc‑elemekkel PDF, kép vagy HTML exportálásakor?**

A látható fejléc‑ és lábléc‑elemek a prezentáció többi tartalmával együtt kerülnek a kimeneti formátumba. Megjelenésük függ az exportált lap típusától és a megfelelő helyőrző láthatósági beállításoktól.