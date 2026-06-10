---
title: PowerPoint-prezentációk konvertálása SWF Flash formátumba Androidon
linktitle: PowerPoint -> SWF
type: docs
weight: 80
url: /hu/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) konvertálása SWF Flash formátumba Java-ban az Androidra készült Aspose.Slides segítségével. Lépésről-lépésre kódminták, gyors, minőségi kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat SWF formátumba konvertálni az Aspose.Slides használatával. Megmutatja, hogyan kell egy prezentációt SWF fájlként menteni a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódussal, és hogyan lehet az exportálást konfigurálni a [SwfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/) segítségével, beleértve a megjelenítő beállításait és a jegyzetek vagy megjegyzések elrendezését.

## **PPT(X) konvertálása SWF-re**

A [Save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódus, amelyet a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztály biztosít, használható az egész prezentáció **SWF** dokumentummá konvertálásához. Az alábbi példa megmutatja, hogyan lehet egy prezentációt **SWF** dokumentummá konvertálni a [**SWFOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SwfOptions) osztály által biztosított beállításokkal. A generált SWF‑be beilleszthetőek a megjegyzések is a [**ISWFOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISwfOptions) osztály és a [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) interfész használatával.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Prezentáció mentése
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Bele tudok-e foglalni rejtett diákot a SWF‑be?**

Igen. A rejtett diák engedélyezhetők a [setShowHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) metódussal a [SwfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nincsenek exportálva.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [setCompressed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) metódust és a [állítsa be a JPEG minőséget](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) metódust a fájlméret és a képminőség egyensúlyozásához.

**Mi a 'setViewerIncluded' funkció, és mikor kell letiltani?**

A [setViewerIncluded](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) egy beágyazott lejátszó felhasználói felületet (navigációs vezérlők, panelek, keresés) ad hozzá. Tiltsa le, ha saját lejátszót kíván használni, vagy egy UI nélküli egyszerű SWF keretre van szüksége.

**Mi történik, ha a forrás betűtípus hiányzik az exportáló gépen?**

Az Aspose.Slides a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) segítségével a [SwfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/swfoptions/)‑ban megadott betűtípust fogja helyettesíteni, hogy elkerülje a nem kívánt fallback‑et.