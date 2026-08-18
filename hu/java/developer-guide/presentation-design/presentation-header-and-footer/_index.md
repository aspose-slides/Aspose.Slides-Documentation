---
title: Prezentáció fejlécek és láblécek kezelése Java-ban
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- nyomtatvány
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelheti a lábléc, dátum-idő, dia-szám és fejléc helyőrzőket diákon, jegyzetoldalakon és nyomtatványokon az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A PowerPoint a lap típusától függően különböző fejléc- és lábléchelyőrzőket használ. Az Aspose.Slides for Java lehetővé teszi ezen helyőrzők szövegének és láthatóságának vezérlését a fejléc/lábléc kezelői felületeken keresztül.

A rendelkezésre álló helyőrzők a hatókör (scope) függvényében változnak:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Normál dia | Nem | Igen | Igen | Igen |
| Jegyzetminta | Igen | Igen | Igen | Igen |
| Jegyzetdia | Igen | Igen | Igen | Igen |
| Nyomtatványminta | Igen | Igen | Igen | Igen |

Egy normál prezentációs dia nem rendelkezik fejléchelyőrzővel. A fejlécek a jegyzetoldalakon és a nyomtatványokon érhetők el. Normál diák esetén használja a lábléc, dátum/idő és dia‑szám helyőrzőket.

A módosítás hatóköre attól függ, melyik kezelőt használja. A [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideheaderfootermanager/) felület egyetlen normál diát szabályoz. A [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotesslideheaderfootermanager/) felület egyetlen jegyzetdát szabályoz. A minta‑ és elrendezéskezelők is képesek a beállításokat a függő diákra kiterjeszteni, míg a [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) felület a nyomtatvány‑mastert kezeli.

## **Lábléc, dátum/idő és dia‑szám beállítása normál diákon**

Normál diák esetén az alaplépések a következők: hozzáférünk az adott dia fejléc/lábléc kezelőjéhez, beállítjuk a lábléc‑ és dátum/idő‑szöveget, engedélyezzük a szükséges helyőrzőket, majd mentjük a prezentációt. A dia‑számokat a prezentáció generálja, ezért csak a láthatóságukat kell vezérelni.

Használja a [`setFooterText`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) és a [`setDateTimeText`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) metódusokat a szöveg beállításához, valamint a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), és a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) metódusokat a megfelelő helyőrzők megjelenítéséhez.

Az alábbi end‑to‑end példa ugyanazt a láblécet, dátum/idő‑szöveget és dia‑szám láthatóságot alkalmazza az összes normál diára:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egyetlen diát kell frissíteni, akkor a [`getSlides`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) metódussal közvetlenül érje el azt, a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzetmesteren**

A jegyzetmester meghatározza a jegyzetoldalak közös formázását és a helyőrzők viselkedését. Használja a [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/) felületet, ha csak a jegyzetmestert szeretné módosítani.

A következő példa beállítja a fejlécet, láblécet és dátum/idő‑szöveget a jegyzetmestre, és az összes támogatott helyőrzőt láthatóvá teszi azon a masteren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [`getMasterNotesSlide`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) metódus `null`‑t ad vissza, ha a prezentáció nem tartalmaz jegyzetmestert.

## **Jegyzetmester beállításainak alkalmazása az alárendelt jegyzetdiákra**

A jegyzetmester képes a fejléc‑ és lábléc‑beállításokat saját magára és az összes függő jegyzetdiára alkalmazni. Használja a [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/) dedikált terjesztési metódusait, ha ugyanazokat a beállításokat kell az egész jegyzet‑hierarchiában érvényesíteni.

Például a [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) és a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) frissíti a jegyzetmester fejlécét és az összes alárendelt fejlécet. Hasonló metódusok állnak rendelkezésre a láblécek, dátum/idő és dia‑számok kezelésére.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fent használt terjesztési metódusok:

- [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)
- [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)
- [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)
- [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)
- [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)

## **Fejlécek és láblécek beállítása egy egyedi jegyzetdian**

Egy jegyzetdia egy adott normál diához tartozik. Használja az [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotesslideheaderfootermanager/) felületet, ha csak az adott jegyzetoldalt kívánja testre szabni.

A [`addNotesSlide`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) metódus visszaadja az aktuális dia jegyzetdáját, és létrehoz egyet, ha még nem létezik. Az alábbi példa az első prezentációs diához társított jegyzetoldalt állítja be:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha először a jegyzetmester beállításait terjeszti, majd egy egyedi jegyzetdian módosít, az utólagos dia‑szintű beállítások lehetővé teszik a jegyzetoldal önálló testreszabását.

## **Fejlécek és láblécek beállítása a Nyomtatványmesteren**

A nyomtatványoldalak a nyomtatványmesterben tárolják a fejléc, lábléc, dátum/idő és oldalszám helyőrzőket. A jegyzetoldalakkal ellentétben a nyomtatvány beállításait a nyomtatványmester kezeli, nem pedig az egyes nyomtatványdiák.

A nyomtatványmester eléréséhez használja a [`getMasterHandoutSlide`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) metódust. Ha nincs jelen, hívja a [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) metódust az alapértelmezett nyomtatványmester létrehozásához.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A hatókör és az öröklődés megértése**

Válassza ki a kívánt hatókörnek megfelelő fejléc/lábléc kezelőt:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islideheaderfootermanager/) egy normál dia lábléc, dátum/idő és dia‑szám beállításait módosítja.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilayoutslideheaderfootermanager/) egy elrendezésdiót szabályoz, és a támogatott beállításokat a függő diákra terjeszti.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterslideheaderfootermanager/) egy normál diamastert vezérel, és a támogatott beállításokat a függő diákra terjeszti.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasternotesslideheaderfootermanager/) a jegyzetmestert irányítja, és a beállításokat az összes függő jegyzetdiára terjeszti.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/inotesslideheaderfootermanager/) egy jegyzetdiót módosít, és a fejléc‑helyőrzőt a lábléc, dátum/idő és dia‑szám mellett támogatja.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) a nyomtatványmestert változtatja, és minden négy helyőrző típust kezeli.

Használjon terjesztést egy mesterről vagy elrendezésről, ha ugyanazt a beállítást az egész hierarchiára szeretné alkalmazni. Használjon egyedi dia‑ vagy jegyzetdia‑kezelőt, ha helyi beállításra van szüksége egyetlen oldalra.

## **GYIK**

**Hozzáadhatok fejlécet egy normál diához?**

Nem. A PowerPoint nem definiál fejléc‑helyőrzőt normál diákon. Normál diákon a lábléc, dátum/idő és dia‑szám helyőrzőket használja. Fejléc‑helyőrzők csak a jegyzetoldalakon és nyomtatványokon érhetők el.

**Mi van, ha a lábléc, dátum/idő vagy dia‑szám helyőrző nem látható?**

Használja a megfelelő fejléc/lábléc kezelőt a láthatóság ellenőrzéséhez és engedélyezéséhez. Például az [`isFooterVisible`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) megmondja, hogy a lábléc‑helyőrző jelen van‑e, a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) módosítja annak láthatóságát.

**Hogyan indíthatom a dia‑számozást 1‑nél más értékről?**

Hívja a prezentáció [`setFirstSlideNumber`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) metódusát. Ezután a dia‑szám‑helyőrzők a frissített számozási sorozatot használják.

**Mi történik a fejléc‑ és lábléc‑elemekkel PDF, képek vagy HTML exportálásakor?**

A látható fejléc‑ és lábléc‑elemek a prezentáció többi tartalmával együtt kerülnek renderelésre a kimeneti formátumban. Megjelenésük az exportált oldal típusától és a megfelelő helyőrző láthatósági beállításoktól függ.