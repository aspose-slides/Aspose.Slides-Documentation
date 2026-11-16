---
title: Prezentáció nézetbeállításainak lekérdezése és frissítése JavaScript-ben
linktitle: Nézetbeállítások
type: docs
weight: 80
url: /hu/nodejs-java/presentation-view-properties/
keywords:
- nézetbeállítások
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó megtapadása
- egy nézet
- sáv állapot
- dimenzió mérete
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js Java-n keresztül használatával konfigurálhatja a normál nézet elrendezését, a dia és a jegyzetek nagyítását, a rács távolságát, valamint a megjegyzések láthatóságát a PowerPoint prezentációkban."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia egy oldalsó ablaktáblán (bélyegképek vagy vázlat) és az alatta lévő jegyzetek ablaktáblája között jelenik meg. Az Aspose.Slides for Node.js Java‑val elérhetővé teszi a prezentáció mentett szerkesztési beállításait a [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties)on keresztül. Ezek közé tartozik az ablaktáblák elrendezése, a nagyítási szintek, a rács távolsága és a megjegyzések láthatósága.

## **A NormalViewProperties-ról**

Használja a [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) a [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) osztály eléréséhez. A [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) szabályozza, hogy ikonok jelenjenek‑e meg a diacímek mellett a vázlatban. A [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) lehetővé teszi, hogy az oldalsó ablaktábla a felhasználó szűkítésekor a minimalizált állapotába csapódjon. A [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) egy előnyben részesítést jelez, hogy egy ablaktáblát jelenítsen meg a teljes ablakban.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) szabályozza az oldalsó ablaktábla és a dia közti elválasztót. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) szabályozza a jegyzetek ablaktáblája feletti elválasztót. Mindkettő a [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` vagy `Restored` értéket fogadja el.

## **A NormalViewProperties visszaállításáról**

Amikor egy elválasztót visszaállítanak, a [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) a oldalsó ablaktábla mentett méretét, a [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) pedig a felső dia terület mentett méretét adja. Mindkettő a [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) osztályt teszi elérhetővé. Ennek a [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) metódusa 0‑tól 100‑ig terjedő százalékot fogad, a [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) pedig szabályozza, hogy a szerkesztő módosítsa‑e a méretet az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a vízszintes elválasztót, a [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) által visszaadott méretet 80%-ra állítja be automatikus igazítással, és maximalizálja a függőleges elválasztót. Emellett meghívja a [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) metódust, hogy ikonokat jelenítsen meg a vázlat nézetben.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

A [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) és a [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) független nagyítási beállításokat tárolnak a szerkesztőnek. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a kép export felbontását.

Ez a példa megnyit egy meglévő prezentációt, és a [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) hívással a diát a szerkesztőablakhoz igazítja. A jegyzetoldalhoz letiltja az automatikus méretezést, és a [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) hívással rögzített 80%-os nagyítást állít be.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A rácstávolság beállítása**

A [setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) beállítja a szerkesztői rácsvonalak közti távolságot a teljes prezentációban. Pozitív értéket vár pontban, 72 pont egy hüvelyknek felel meg. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes rácsot ment 18 pontra állított intervállal.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rács egy rögzített intervállal ismétlődik. A [Drawing guides](/slides/hu/nodejs-java/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelöl. Mindkettő a szerkesztést segíti, és csak azokban a szerkesztőkben jelenik meg, amelyek támogatják őket. A diavetítések és a PDF, kép vagy SVG exportok kihagyják őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

A [setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) egy preferenciát tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy megjegyzésekkel ellátott meglévő prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy olyan másolatot ment, ahol a megjegyzések el vannak rejtve. Emellett a [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) meghívásával a [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) értéket használja, hogy a másolat dia nézetben nyíljon meg.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A megjegyzések elrejtése megőrzi azok szövegét, szerzőit, pozícióit, válaszait és állapotát. A megjegyzések módosításához lásd a [Presentation Comments](/slides/hu/nodejs-java/presentation-comments/) oldalt. Az export beállításai határozzák meg, hogy a megjegyzések megjelennek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy szórólapokban.

## **GYIK**

**Miért van a rács elrejtve, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A vonalas útmutatók törlése megváltoztatja a rács távolságát?**  
Nem. Útmutató hozzáadása, áthelyezése vagy törlése nem változtatja meg a rács intervallumát.

**Különböző szakaszok a prezentációban különböző nézetbeállításokkal rendelkezhetnek?**  
Nem. A [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) az egész prezentációra vonatkozik.

**Menthetek különböző nézetbeállításokat különböző felhasználók számára?**  
A fájl egyetlen nézetbeállítást tárol mindenki számára. Egy szerkesztő azonban alkalmazhatja a felhasználó helyi preferenciáit is.

**Menthetek nézetbeállításokat sablonba?**  
Igen. A sablonból létrehozott prezentációk öröklik annak mentett nézetbeállításait.