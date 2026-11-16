---
title: Prezentáció nézetbeállításainak lekérése és frissítése PHP-ban
linktitle: Nézetbeállítások
type: docs
weight: 80
url: /hu/php-java/presentation-view-properties/
keywords:
- nézetbeállítások
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyszemélyes nézet
- panel állapota
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP via Java segítségével állítsa be a normál nézet elrendezését, a dia és a jegyzetek nagyítását, a rács távolságát, valamint a megjegyzések láthatóságát a PowerPoint prezentációkban."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia egy oldalsó panel és egy jegyzetpanel között jelenik meg, ahol az oldalsó panel bélyegképek vagy vázlatok számára szolgál, a jegyzetpanel pedig alul található. Az Aspose.Slides for PHP via Java a prezentáció mentett szerkesztési beállításait teszi elérhetővé a [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Ezek közé tartozik a panel elrendezése, a nagyítási szintek, a rácstávolság és a megjegyzések láthatósága.

## **A NormalViewProperties tulajdonságairól**

Használja a [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) metódust a [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) osztály eléréséhez. A [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) szabályozza, hogy az ikonok megjelennek-e a diacímek mellett a vázlatban. A [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) lehetővé teszi, hogy az oldalsó panel a felhasználó szűkítésekor az összecsukott állapotba „rácsapjon”. A [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) egy olyan preferenciát jelöl, amely egy panelek megjelenítését preferálja a teljes ablakban.

A [setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) szabályozza az oldalsó panel és a dia közötti elválasztót. A [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) szabályozza a jegyzetpanel feletti elválasztót. Mindkettő a [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` vagy `Restored` értéket fogadja el.

## **A NormalViewProperties helyreállításáról**

Amikor egy elválasztó visszaállításra kerül, a [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) a mentett oldalsó panel méretét, a [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) pedig a felső dia terület mentett méretét adja vissza. Mindkettő a [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) osztályt teszi elérhetővé. Ennek a [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) metódusa 0‑tól 100‑ig terjedő százalékot fogad, a [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) pedig szabályozza, hogy a szerkesztő a méretet automatikusan módosítsa‑e az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a vízszintes elválasztót, a [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) által visszaadott méretet 80 %-ra állítja automatikus méretezés engedélyezésével, és maximalizálja a függőleges elválasztót. Emellett meghívja a [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) metódust, hogy ikonokat jelenítsen meg a vázlat nézetben.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

A [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) és a [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) a szerkesztő számára független nagyítási beállításokat tárolnak. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a kép export felbontását.

Ez a példa megnyit egy meglévő prezentációt, és a [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) metódust hívja meg, hogy a dia a szerkesztőablakhoz igazodjon. A jegyzetoldalhoz letiltja az automatikus méretezést, és a [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) metódussal 80 %-os rögzített nagyítást állít be.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **A rácstávolság beállítása**

A `setGridSpacing` metódus a [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) osztályban beállítja a szerkesztési rácsvonalak közti távolságot a teljes prezentációban. Pozitív értéket vár pontban, ahol hüvelykenként 72 pont van. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes rácsot ment 18 pont intervallummal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A rács fix intervallumban ismétlődik. A [Drawing guides](/slides/hu/php-java/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő szerkesztési segédeszköz, és csak azokat megjelenítő szerkesztőkben látható. A diavetítések és a PDF‑, kép‑ vagy SVG‑exportok nem tartalmazzák őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

A [setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) egy olyan beállítást tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor alkalmaznak. Egy megjegyzésekkel rendelkező meglévő prezentációra ez a példa kiírja az aktuális beállítást, és egy olyan másolatot ment, amelyben a megjegyzések rejtve vannak. Emellett meghívja a [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) metódust a [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) értékkel, hogy a másolat dia nézetben nyíljon meg.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A megjegyzések elrejtése megőrzi azok szövegét, szerzőit, pozícióit, válaszait és állapotait. A megjegyzések módosításához tekintse meg a [Presentation Comments](/slides/hu/php-java/presentation-comments/) oldalt. Az export beállítások határozzák meg, hogy a megjegyzések megjelenjenek-e PDF‑ben, HTML‑ben, képeken, jegyzetekben vagy anyagokban.

## **GYIK**

**Miért van a rács rejtve, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzsegédletek törlése megváltoztatja a rács távolságát?**  
Nem. Segédlet hozzáadása, áthelyezése vagy törlése nem változtatja meg a rács intervallumát.

**A prezentáció különböző részei különböző nézetbeállításokkal rendelkezhetnek?**  
Nem. A [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) az egész prezentációra érvényes.

**Menthetek különböző nézetbeállításokat különböző felhasználók számára?**  
A fájl mindenkinek egyetlen nézetbeállítási halmazt tárol. Egy szerkesztő azonban alkalmazhatja a felhasználó helyi preferenciáit is.

**Menthetek nézetbeállításokat egy sablonban?**  
Igen. A sablonból létrehozott prezentációk öröklik a mentett nézetbeállításokat.