---
title: Prezentáció fejlécek és láblécek kezelése JavaScriptben
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/nodejs-java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kézbeszámoló
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerkedjen meg azzal, hogyan kezelhetők a lábléc, dátum-idő, diaszám és fejléc helyőrzők diákon, jegyzetoldalakon és kézbeszámolókon az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

PowerPoint különböző fejléccel és lábléccel rendelkező helyőrzőket használ az oldal típusától függően. Az Aspose.Slides for Node.js via Java lehetővé teszi ezen helyőrzők szövegének és láthatóságának vezérlését a fejléc/lábléc kezelő osztályok segítségével.

Az elérhető helyőrzők a hatókörtől függenek:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Szokásos dia | Nem | Igen | Igen | Igen |
| Jegyzetmester | Igen | Igen | Igen | Igen |
| Jegyzetdia | Igen | Igen | Igen | Igen |
| Kézbeszámoló mester | Igen | Igen | Igen | Igen |

Egy szokásos prezentációs diának nincs fejléchelyőrzője. A fejlécek a jegyzetoldalakon és a kézbeszámolókon érhetők el. Szokásos diák esetén ehelyett a lábléc, dátum/idő és dia-szám helyőrzőket használja.

A módosítás hatóköre attól függ, hogy melyik kezelőt használja. A[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideheaderfootermanager/) osztály egy szokásos diát vezérel. A[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslideheaderfootermanager/) osztály egy jegyzetdiát vezérel. A mester‑ és elrendezéskezelők is képesek a beállításokat a függő diákra terjeszteni, míg a[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) osztály a kézbeszámoló mestert kezeli.

## **Lábléc, Dátum/Idő és Diaszámok beállítása a szokásos diákon**

Szokásos diák esetén az alapfolyamat: hozzáférni az egyes diák fejléc/lábléc kezelőjéhez, beállítani a lábléc és dátum/idő szövegét, engedélyezni a szükséges helyőrzőket, majd menteni a prezentációt. A diaszámokat a prezentáció generálja, ezért csak a láthatóságukat kell szabályozni.

Használja a[`setFooterText`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) és a[`setDateTimeText`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) metódusokat a szöveg beállításához, illetve a[`setFooterVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) és [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) metódusokat a megfelelő helyőrzők megjelenítéséhez.

Az alábbi végponttól végpontig tartó példa ugyanazt a láblécet, dátum/idő szöveget és diaszám láthatóságot alkalmazza az összes szokásos diára:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy diát kell frissíteni, akkor a[`getSlides`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslides/) metódussal közvetlenül érje el azt a diát, a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzetmesteren**

A jegyzetmester határozza meg a jegyzetoldalak közös formázását és helyőrző‑viselkedését. Használja a[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) osztályt, ha csak a jegyzetmestert szeretné módosítani.

Az alábbi példa a fejlécet, láblécet és dátum/idő szöveget állítja be a jegyzetmestre, és a támogatott helyőrzőket láthatóvá teszi azon a mesteren:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A[`getMasterNotesSlide`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) metódus `null` értéket ad vissza, ha a prezentáció nem tartalmaz jegyzetmestert.

## **Jegyzetmester beállításainak alkalmazása a gyermek jegyzetdiákra**

A jegyzetmester képes a fejléc‑ és láblécbeállításokat saját magára és az összes függő jegyzetdiára kiterjeszteni. Használja a megfelelő terjesztési metódusokat a[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) osztályon, ha ugyanazt a beállítást szeretné a jegyzethierarchia minden szintjén alkalmazni.

Például a[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) és a[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) frissíti a jegyzetmester fejlécét és az összes gyermekfejlécet. Hasonló metódusok állnak rendelkezésre a láblécek, dátum/idő és diaszámok kezelésére.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fent használt propagációs módszerek a[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) és a[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility) metódusok.

## **Fejlécek és láblécek beállítása egy egyedi jegyzetdián**

Egy jegyzetdia egy meghatározott szokásos diához tartozik. Használja a[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslideheaderfootermanager/) osztályt, ha csak azt a jegyzetoldalt szeretné testre szabni.

Az[`addNotesSlide`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) metódus visszaadja az aktuális dia jegyzetdiáját, és létrehozza azt, ha még nem létezik. Az alábbi példa az első prezentációs diához tartozó jegyzetoldalt konfigurálja:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha először a jegyzetmester beállításait terjeszti, majd egy egyedi jegyzetdiát módosít, akkor az utána történő diápontról szóló beállítások lehetővé teszik a jegyzetoldal független testreszabását.

## **Fejlécek és láblécek beállítása a Kézbeszámoló mesteren**

A kézbeszámoló oldalak a kézbeszámoló mestert használják a fejléc, lábléc, dátum/idő és oldalszám helyőrzőikhez. A jegyzetoldalakkal ellentétben a kézbeszámoló beállításokat a kézbeszámoló mester, nem pedig az egyedi kézbeszámoló diák irányítják.

Használja a[`getMasterHandoutSlide`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) metódust a kézbeszámoló mester eléréséhez. Ha nincs jelen, hívja meg a[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) metódust az alapértelmezett kézbeszámoló mester létrehozásához.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A hatókör és öröklődés megértése**

Válassza ki azt a fejléc/lábléc kezelőt, amely a módosítani kívánt hatókörnek megfelelő:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideheaderfootermanager/) módosítja a lábléc, dátum/idő és diaszám beállításait egy szokásos dián.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) egy elrendezésdát vezérel, és a támogatott beállításokat a függő diákra terjeszti.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterslideheaderfootermanager/) egy szabványos diamestert vezérel, és a támogatott beállításokat a függő diákra terjeszti.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) a jegyzetmestert vezérel, és a beállításokat az összes függő jegyzetdiára terjeszti.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslideheaderfootermanager/) egy jegyzetdiát módosít, és a fejléchelyőrzőt a lábléc, dátum/idő és diaszám mellett támogatja.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) a kézbeszámoló mestert módosítja, és mind a négy helyőrző típust támogatja.

Használjon propagációt egy mester‑ vagy elrendezéskezelőből, ha ugyanazt a beállítást kell alkalmazni a hierarchia minden szintjén. Használjon egyedi dia‑ vagy jegyzetdia‑kezelőt, ha egy oldalon helyi beállításra van szükség.

## **GYIK**

**Hozzáadhatok fejlécet egy szokásos diához?**

Nem. A PowerPoint nem definiál fejléchelyőrzőt a szokásos diákhoz. Szokásos diákon használja a lábléc, dátum/idő és diaszám helyőrzőket. Fejléchelyőrzők a jegyzetoldalakon és a kézbeszámolókon érhetők el.

**Mi van, ha egy lábléc, dátum/idő vagy diaszám helyőrző nem látható?**

Használja a megfelelő fejléc/lábléc kezelőt a láthatóság ellenőrzésére és engedélyezésére. Például az[`isFooterVisible`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) jelzi, hogy a lábléchelyőrző jelen van‑e, az[`setFooterVisibility`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) pedig módosítja annak láthatóságát.

**Hogyan indíthatom a diaszámozást 1‑nél különböző értékkel?**

Hívja meg a prezentáció[`setFirstSlideNumber`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) metódusát. A diaszám‑helyőrzők ezután az új számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF‑re, képekre vagy HTML‑re exportáláskor?**

A látható fejléc‑ és láblécelemek a prezentáció tartalmával együtt kerülnek renderelésre a kimeneti formátumban. Megjelenésük az exportált oldal típusától és a megfelelő helyőrző‑láthatósági beállításoktól függ.