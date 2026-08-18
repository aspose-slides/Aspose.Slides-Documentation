---
title: Presentáció fejlécének és láblécének kezelése PHP-ben
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/php-java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- elosztó
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a lábléc, dátum-idő, dia-szám és fejléc helyfoglalókat diákon, jegyzetoldalakon és elosztókon az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A PowerPoint különböző fejléc- és lábléchelyfoglalókat használ az oldaltípus függvényében. Az Aspose.Slides for PHP via Java lehetővé teszi ezen helyfoglalók szövegének és láthatóságának kezelését fejléc/lábléckezelő osztályok segítségével.

A rendelkezésre álló helyfoglalók a hatókörtől függenek:

| Hatókör | Fejléc | Lábléc | Dátum/idő | Dia/oldalszám |
|---|---|---|---|---|
| Általános dia | Nem | Igen | Igen | Igen |
| Jegyzetmester | Igen | Igen | Igen | Igen |
| Jegyzetdia | Igen | Igen | Igen | Igen |
| Elosztó mester | Igen | Igen | Igen | Igen |

Az általános prezentációs diának nincs fejléchelyfoglalója. A fejléc a jegyzetoldalakon és az elosztókon érhető el. Általános diák esetén a lábléc, a dátum/idő és a dia-szám helyfoglalókat kell használni.

A változtatás hatóköre attól a menedzsertől függ, amelyet használ. A [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideheaderfootermanager/) osztály egy általános diát kezel. A [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslideheaderfootermanager/) osztály egy jegyzetdiát kezel. A mester- és elrendezésmenedzserek szintén képesek a beállításokat a függő diákra továbbadni, míg a [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) osztály az elosztó mestert kezeli.

## **Lábléc, Dátum/Idő és Diákszámok beállítása általános diákon**

Általános diák esetén az alapmunkafolyamat a következő: minden dia fejléc/lábléckezelőjének elérése, a lábléc és a dátum/idő szövegének beállítása, a szükséges helyfoglalók engedélyezése, majd a prezentáció mentése. A diákszámokat a prezentáció generálja, ezért csak a láthatóságukat kell szabályozni.

Használja a [`setFooterText`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) és a [`setDateTimeText`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) metódusokat a szöveg beállításához, illetve a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) és [`setSlideNumberVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) metódusokat a megfelelő helyfoglalók megjelenítéséhez.

Az alábbi vég-az-vegén példakód ugyanazt a láblécet, dátum/idő szöveget és dia-szám láthatóságot alkalmazza minden általános diára:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha csak egy diát szeretne frissíteni, a teljes gyűjtemény bejárása helyett a [`getSlides`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getslides/) metódussal közvetlenül érje el azt a diát.

## **Fejlécek és láblécek beállítása a Jegyzetmesteren**

A jegyzetmester határozza meg a jegyzetoldalak közös formázását és helyfoglaló‑viselkedését. Használja a [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/) osztályt, ha csak a jegyzetmestert szeretné megváltoztatni.

Az alábbi példa beállítja a fejlécet, láblécet és a dátum/idő szöveget a jegyzetmesteren, és láthatóvá teszi az összes támogatott helyfoglalót azon a mesteren:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A [`getMasterNotesSlide`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) metódus `null`‑t ad vissza, ha a prezentáció nem tartalmaz jegyzetmestert.

## **Jegyzetmester beállításainak alkalmazása a gyermek jegyzetdiákra**

A jegyzetmester képes a fejléc‑ és láblécbeállításokat saját magára és az összes függő jegyzetdiara alkalmazni. Használja a [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/) dedikált propagációs metódusait, ha ugyanazokat a beállításokat kell alkalmazni a jegyzet‑hierarchián belül.

Például a [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) és a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) frissíti a jegyzetmester fejléceit és az összes gyermekfejlécet. Hasonló metódusok érhetők el a láblécek, a dátum/idő és a dia‑számok esetében is.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A fent használt propagációs metódusok: [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), és a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Fejlécek és láblécek beállítása egy egyedi jegyzetdián**

Egy jegyzetdia egy adott általános diához tartozik. Használja a [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslideheaderfootermanager/) osztályt, ha csak azt a jegyzetoldalt szeretné testre szabni.

A [`addNotesSlide`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslidemanager/addnotesslide/) metódus visszaadja az aktuális dia jegyzetdiáját, és létrehozza azt, ha még nem létezik. Az alábbi példa az első prezentációs diahoz tartozó jegyzetoldalt konfigurálja:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha először a jegyzetmestertől propagálja a beállításokat, majd egyedi jegyzetdiát módosít, a későbbi diánkénti beállítások lehetővé teszik az adott jegyzetoldal önálló testreszabását.

## **Fejlécek és láblécek beállítása az Elosztó Mesteren**

Az elosztóoldalak a elosztó mestert használják fejlécek, láblécek, dátum/idő és oldalszám helyfoglalóikhoz. A jegyzetoldalakkal ellentétben az elosztó beállításait az elosztó mester kezeli, nem pedig az egyedi elosztó diák.

Használja a [`getMasterHandoutSlide`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) metódust az elosztó mester eléréséhez. Ha nincs jelen, hívja a [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) metódust a alapértelmezett elosztó mester létrehozásához.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hatókör és öröklődés megértése**

Válassza ki azt a fejléc/lábléc menedzsert, amely a kívánt hatókörnek megfelel:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideheaderfootermanager/) egy általános dián módosítja a lábléc, dátum/idő és dia‑szám beállításait.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslideheaderfootermanager/) egy elrendezésdiát kezel, és a támogatott beállításokat propagálhatja a függő diákra.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslideheaderfootermanager/) egy szabványos dia mestert kezel, és a támogatott beállításokat propagálhatja a függő diákra.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslideheaderfootermanager/) a jegyzetmestert kezeli, és a beállításokat az összes függő jegyzetdiára terjeszti ki.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notesslideheaderfootermanager/) egy jegyzetdiát módosít, és a fejléchelyfoglalót is támogatja a lábléc, dátum/idő és dia‑szám mellett.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) az elosztó mestert módosítja, és mind a négy helyfoglalót támogatja.

Használjon propagációt egy mester‑ vagy elrendezésmenedzserből, ha ugyanazt a beállítást kell alkalmazni a teljes hierarchiára. Használjon egyedi diamenedzsert vagy jegyzet‑diamenedzsert, ha helyi beállításra van szükség egy adott oldalon.

## **GYIK**

**Hozzáadhatok fejlécet egy általános diához?**

Nem. A PowerPoint nem határoz meg fejléchelyfoglalót az általános diákhoz. Általános diákon használja a lábléc, a dátum/idő és a dia‑szám helyfoglalókat. Fejléchelyfoglalók csak a jegyzetoldalakon és az elosztókon érhetők el.

**Mi a helyzet, ha egy lábléc, dátum/idő vagy dia‑szám helyfoglaló nem látszik?**

Használja a megfelelő fejléc/lábléc menedzsert a láthatóság ellenőrzéséhez, és engedélyezze szükség szerint. Például a [`isFooterVisible`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) azt jelzi, hogy a lábléc helyfoglaló jelen van-e, a [`setFooterVisibility`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) pedig megváltoztatja a láthatóságát.

**Hogyan indíthatom a diákszámozást 1‑nél eltérő értékkel?**

Hívja meg a prezentáció [`setFirstSlideNumber`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/setfirstslidenumber/) metódusát. Ezután a dia‑szám helyfoglalók az új számozási sorozatot használják.

**Mi történik a fejlécekkel és láblécekkel PDF‑re, képekre vagy HTML‑re exportáláskor?**

A látható fejléc‑ és lábléc elemek a prezentáció tartalmával együtt kerülnek renderelésre a kimeneti formátumban. Megjelenésük az exportált oldaltípustól és a megfelelő helyfoglaló láthatósági beállításoktól függ.