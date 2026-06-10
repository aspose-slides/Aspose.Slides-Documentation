---
title: Prezentáció fejlécek és láblécek kezelése JavaScript-ben
linktitle: Fejléc & Lábléc
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
- értesítő
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Használja a JavaScript-et és az Aspose.Slides for Node.js-t, hogy fejléceket és lábléceket adjon hozzá, valamint testre szabja őket PowerPoint és OpenDocument prezentációkban a professzionális megjelenés érdekében."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi a fejléc és lábléc beállításainak kezelését a PowerPoint prezentációkban. A fejlécek és láblécek a prezentáció mester szintjén kezelhetők, és az API metódusokat biztosít a lábléc szövegének beállításához, a lábléc láthatóságának módosításához, valamint a mester jegyzet diák fejléc szövegének frissítéséhez.

Aki szeretné, kezelheti a fejléceket és lábléceket az értesítő és jegyzet diákon is. Ez magában foglalja a fejléc, lábléc, dia szám és dátum-idő helyőrzőinek láthatóságának és szövegének módosítását a jegyzet mester, az összes gyermekjegyzet dia vagy egy adott jegyzet dia esetén.

## **Fejléc és lábléc kezelése a prezentációban**

Bizonyos diák jegyzetei eltávolíthatók, ahogy az alábbi példában látható:

```javascript
// Prezentáció betöltése
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Lábléc beállítása
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Fejléc elérése és frissítése
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Prezentáció mentése
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Fejléc és lábléc kezelése az értesítő és jegyzet diákon**

Aspose.Slides for Node.js Java-n keresztül támogatja a fejlécet és a láblécet az értesítő és jegyzet diákon. Kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) elemet, amely videót tartalmaz.
- Módosítsa a fejléc és lábléc beállításait a jegyzet mester és az összes jegyzet dia esetén.
- Állítsa be a mester jegyzet diát és az összes gyermek lábléc helyőrzőjét láthatóvá.
- Állítsa be a mester jegyzet diát és az összes gyermek dátum és idő helyőrzőjét láthatóvá.
- Csak az első jegyzet dián módosítsa a fejléc és lábléc beállításait.
- Állítsa be a jegyzet dia fejléc helyőrzőjét láthatóvá.
- Állítsa be a szöveget a jegyzet dia fejléc helyőrzőjéhez.
- Állítsa be a szöveget a jegyzet dia dátum-idő helyőrzőjéhez.
- Mentse a módosított prezentáció fájlt.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Módosítsa a fejléc és lábléc beállításait a jegyzet mester és az összes jegyzet dia esetén
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);//   tegye láthatóvá a mester jegyzet diát és az összes gyermek lábléc helyőrzőt
        headerFooterManager.setFooterAndChildFootersVisibility(true);//   tegye láthatóvá a mester jegyzet diát és az összes gyermek fejléc helyőrzőt
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);//   tegye láthatóvá a mester jegyzet diát és az összes gyermek dia szám helyőrzőt
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);//   tegye láthatóvá a mester jegyzet diát és az összes gyermek dátum és idő helyőrzőt
        headerFooterManager.setHeaderAndChildHeadersText("Header text");//   állítsa be a szöveget a mester jegyzet diára és az összes gyermek fejléc helyőrzőre
        headerFooterManager.setFooterAndChildFootersText("Footer text");//   állítsa be a szöveget a mester jegyzet diára és az összes gyermek lábléc helyőrzőre
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");//   állítsa be a szöveget a mester jegyzet diára és az összes gyermek dátum és idő helyőrzőre
    }
    // Módosítsa a fejléc és lábléc beállításait csak az első jegyzet dián
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }//   tegye láthatóvá ennek a jegyzet diának a fejléc helyőrzőjét
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }//   tegye láthatóvá ennek a jegyzet diának a lábléc helyőrzőjét
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }//   tegye láthatóvá ennek a jegyzet diának a dia szám helyőrzőjét
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }//   tegye láthatóvá ennek a jegyzet diának a dátum-idő helyőrzőjét
        headerFooterManager.setHeaderText("New header text");//   állítsa be a szöveget a jegyzet dia fejléc helyőrzőjére
        headerFooterManager.setFooterText("New footer text");//   állítsa be a szöveget a jegyzet dia lábléc helyőrzőjére
        headerFooterManager.setDateTimeText("New date and time text");//   állítsa be a szöveget a jegyzet dia dátum-idő helyőrzőjére
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hozzáadhatok "fejlécet" a normál diákhoz?**

PowerPoint-ban a „Fejléc” csak a jegyzeteknél és az értesítőknél létezik; a normál diákon a támogatott elemek a lábléc, a dátum/idő és a dia száma. Az Aspose.Slides esetében ez ugyanazokkal a korlátozásokkal egyezik: fejléc csak a Notes/Handout esetén, a diákon pedig – Footer/DateTime/SlideNumber.

**Mi van, ha a layout nem tartalmaz lábléc területet—bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelőn keresztül, és szükség esetén engedélyezze azt. Ezek az API jelzők és metódusok olyan esetekre lettek tervezve, amikor a helyőrző hiányzik vagy rejtett.

**Hogyan állíthatom be, hogy a dia száma 1 helyett más értékkel induljon?**

Állítsa be a prezentáció [first slide number](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) értékét; ezután az összes számozás újraszámolásra kerül. Például kezdhet 0-val vagy 10-zel, és elrejtheti a számot a cím dián.

**Mi történik a fejlécekkel/láblécekkel PDF/ kép/ HTML exportálásakor?**

A fejlécek és láblécek a prezentáció normál szövegelemeként kerülnek megjelenítésre. Vagyis ha az elemek láthatóak a diákon/jegyzet oldalakon, akkor azok is megjelennek a kimeneti formátumban a többi tartalommal együtt.