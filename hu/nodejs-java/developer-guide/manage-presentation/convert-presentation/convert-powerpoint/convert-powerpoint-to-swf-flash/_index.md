---
title: PowerPoint prezentációk konvertálása SWF Flash formátumba JavaScriptben
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint SWF-re
- prezentáció SWF-re
- dia SWF-re
- PPT SWF-re
- PPTX SWF-re
- PowerPoint Flash-re
- prezentáció Flash-re
- dia Flash-re
- PPT Flash-re
- PPTX Flash-re
- PPT mentése SWF-ként
- PPTX mentése SWF-ként
- PPT exportálása SWF-be
- PPTX exportálása SWF-be
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) konvertálása SWF Flash-be az Aspose.Slides Node.js-hez. Lépésről‑lépésre kódminták, gyors, minőségi kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat SWF formátumba konvertálni az Aspose.Slides használatával. Megmutatja, hogyan lehet a prezentációt SWF fájlként menteni a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódussal, és hogyan lehet konfigurálni az exportálást a [SwfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/) segítségével, beleértve a megjelenítő beállításait, valamint a jegyzetek vagy megjegyzések elrendezését.

## **PPT(X) konvertálása SWF-re**
A [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) metódus, amelyet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztály biztosít, használható a teljes prezentáció **SWF** dokumentummá konvertálására. Az alábbi példa bemutatja, hogyan lehet egy prezentációt **SWF** dokumentummá konvertálni a [**SWFOptions**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SwfOptions) osztály által biztosított beállítások használatával. A generált SWF-be megjegyzéseket is beilleszthet a [**SWFOptions**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SwfOptions) osztály és a [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) osztály segítségével.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Prezentáció mentése
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Bele lehet-e foglalni a rejtett diákot a SWF-be?**

Igen. Használja a [setShowHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) metódust a [SwfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nincsenek exportálva.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [setCompressed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/setcompressed/) metódust és a [setJpegQuality](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/setjpegquality/) metódust a fájlméret és a képminőség egyensúlyozásához.

**Mi a célja a 'setViewerIncluded' metódusnak, és mikor kellene használni?**

A [setViewerIncluded](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) egy beágyazott lejátszó felhasználói felületet (navigációs vezérlők, panelek, keresés) ad hozzá. Használja, ha saját lejátszót kíván használni, vagy egy UI nélküli egyszerű SWF keretre van szüksége.

**Mi történik, ha a forrásbetűtípus hiányzik az exportáló gépen?**

Az Aspose.Slides a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) segítségével a [SwfOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/swfoptions/) osztályban megadott betűtípust fogja helyettesíteni, hogy elkerülje a nem kívánt betűtípus‑helyettesítést.