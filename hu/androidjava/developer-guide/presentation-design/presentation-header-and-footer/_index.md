---
title: Prezentáció fejlécek és láblécek kezelése Androidon
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/androidjava/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kiosztott anyag
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum-idő, dia-szám és fejléc helyőrzőket a diákon, jegyzetoldalakon és kiosztott anyagokon az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

A PowerPoint a diavetípus függvényében különböző fej- és lábléchelyőrzőket használ. Az Aspose.Slides for Android via Java lehetővé teszi, hogy ezen helyőrzők szövegét és láthatóságát a fej/lábléckezelő interfészeken keresztül szabályozza.

Az elérhető helyőrzők a hatókör függvényei:

| Hatókör | Fejléc | Lábléc | Dátum/Idő | Dia/oldalszám |
|---|---|---|---|---|
| Általános dia | Nem | Igen | Igen | Igen |
| Jegyzet-mester | Igen | Igen | Igen | Igen |
| Jegyzet dia | Igen | Igen | Igen | Igen |
| Tájékoztató mester | Igen | Igen | Igen | Igen |

Egy általános bemutató dia nem rendelkezik fejléchelyőrzővel. Fejlécek a jegyzetoldalakon és a tájékoztatókban érhetők el. Általános diák esetén a lábléc, dátum/idő és dia‑szám helyőrzőket kell használni.

A változás hatóköre attól a kezelőtől függ, amelyet használ. A [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideheaderfootermanager/) interfész egy általános diát vezérel. A [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) interfész egy jegyzet diát vezérel. A mester- és elrendezéskezelők a beállításokat a függő diákra is továbbíthatják, míg a [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) interfész a tájékoztató mestert kezeli.

## **Lábléc, Dátum/Idő és Dia Számok beállítása az általános diákon**

Általános diák esetén az alapmunkafolyamat, hogy elérjük az egyes diák fej/lábléckezelőjét, beállítjuk a lábléc és dátum/idő szövegét, engedélyezzük a szükséges helyőrzőket, és elmentjük a bemutatót. A dia számokat a bemutató generálja, így csak a láthatóságukat kell szabályozni.

Használja a [`setFooterText`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) és a [`setDateTimeText`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) metódusokat a szöveg beállításához, illetve a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), a [`setDateTimeVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), és a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) metódusokat a megfelelő helyőrzők megjelenítéséhez.

A következő végponttól végpontig terjedő példa ugyanazt a láblécet, dátum/idő szöveget és dia‑szám láthatóságot alkalmazza az összes általános diára:

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

Ha csak egy diát kell frissíteni, közvetlenül érje el azt a [`getSlides`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) metódussal, a teljes gyűjtemény bejárása helyett.

## **Fejlécek és láblécek beállítása a Jegyzet mesteren**

A jegyzet mester közös formázást és helyőrző‑viselkedést határoz meg a jegyzetoldalak számára. Használja a [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) interfészt, ha csak a jegyzet mestert szeretné módosítani.

A következő példa beállítja a fejlécet, láblécet és dátum/idő szöveget a jegyzet mesteren, és minden támogatott helyőrzőt láthatóvá tesz azon a mesteren:

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

A [`getMasterNotesSlide`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) metódus `null` értéket ad vissza, ha a bemutató nem tartalmaz jegyzet mestert.

## **Jegyzet mester beállításainak alkalmazása a gyermek jegyzet diákra**

A jegyzet mester alkalmazhatja a fejléc‑ és láblécbeállításokat saját magára és az összes függő jegyzet diára. Használja a dedikált propagációs metódusokat a [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) interfészen, ha ugyanazokat a beállításokat a jegyzet hierarchián belül kell alkalmazni.

Például a [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) és a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) frissíti a jegyzet mester fejlécét és az összes gyermekfejlécet. Hasonló metódusok állnak rendelkezésre a láblécek, dátum/idő és dia számok esetén.

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

A fent használt propagációs metódusok a [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), a [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), a [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), a [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), és a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-) metódusok.

## **Fejlécek és láblécek beállítása egyes jegyzet dián**

Egy jegyzet dia egy konkrét általános diához tartozik. Használja annak [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) interfészét, ha csak azt a jegyzet oldalt kívánja testre szabni.

A [`addNotesSlide`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) metódus visszaadja a jelenlegi dia jegyzet diáját, és létrehoz egyet, ha még nem létezik. A következő példa az első bemutató diahoz kapcsolódó jegyzet oldalt konfigurálja:

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

Ha először a jegyzet mesterből propagálja a beállításokat, majd módosít egy adott jegyzet diát, a későbbi egyedi diabeállítások lehetővé teszik, hogy az adott jegyzet oldalt önállóan testre szabja.

## **Fejlécek és láblécek beállítása a Tájékoztató mesteren**

A tájékoztató oldalak a tájékoztató mestert használják a fej‑, lábléc‑, dátum/idő‑ és oldalszám‑helyőrzőkhöz. A jegyzet oldalakkal ellentétben a tájékoztató beállításokat a tájékoztató mester, nem pedig az egyes tájékoztató diák kezelik.

Használja a [`getMasterHandoutSlide`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) metódust a tájékoztató mester eléréséhez. Ha nincs jelen, hívja meg a [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) metódust az alapértelmezett tájékoztató mester létrehozásához.

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

## **A hatókör és öröklődés megértése**

Válassza ki a fej/lábléckezelőt, amely megfelel a módosítani kívánt hatókörnek:

- a [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islideheaderfootermanager/) módosítja a lábléc, dátum/idő és dia‑szám beállításokat egy általános dián.
- a [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) egy elrendezés diát vezérel, és a támogatott beállításokat a függő diákra továbbíthatja.
- a [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) egy általános dia mestert kezel, és a támogatott beállításokat a függő diákra továbbíthatja.
- a [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) a jegyzet mestert kezeli, és a beállításokat minden függő jegyzet diára propagálja.
- a [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) egy jegyzet diát módosít, és a lábléc, dátum/idő és dia‑szám mellett fejléchelyőrzőt is támogat.
- a [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) a tájékoztató mestert módosítja, és mind a négy helyőrző típust támogatja.

Használja a propagációt egy mester vagy elrendezés esetén, ha ugyanazt a beállítást szeretné a hierarchián belül mindenhol alkalmazni. Használjon egyedi diakezelőt vagy jegyzet‑diakezelőt, ha egy oldalra helyi beállításra van szükség.

## **GYIK**

**Hozzáadhatok fejlécet egy általános diához?**

Nem. A PowerPoint nem definiál fejléchelyőrzőt általános diák számára. Általános diákon a lábléc, dátum/idő és dia‑szám helyőrzőket kell használni. Fejléchelyőrzők a jegyzetoldalakon és a tájékoztatókón érhetők el.

**Mi van, ha egy lábléc, dátum/idő vagy dia‑szám helyőrző nem látható?**

Használja a megfelelő fej/lábléckezelőt a láthatóság ellenőrzéséhez, és szükség esetén engedélyezze azt. Például a [`isFooterVisible`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) jelzi, hogy a lábléchelyőrző jelen van‑e, és a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) megváltoztatja a láthatóságát.

**Hogyan indítsam a dia számolását 1‑nél eltérő értékkel?**

Hívja meg a bemutató [`setFirstSlideNumber`](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) metódusát. A dia‑szám helyőrzők ezt követően a frissített számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF‑re, képekre vagy HTML‑re exportáláskor?**

A látható fejléc‑ és lábléc elemek a kimeneti formátumban a bemutató egyéb tartalmával együtt kerülnek megjelenítésre. Megjelenésük az exportált oldal típusától és a megfelelő helyőrző láthatósági beállításoktól függ.