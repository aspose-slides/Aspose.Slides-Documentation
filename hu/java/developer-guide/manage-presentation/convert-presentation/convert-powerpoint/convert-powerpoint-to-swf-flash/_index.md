---
title: PowerPoint prezentációk konvertálása SWF Flash-re Java-ban
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) SWF Flash-re konvertálása Java-ban az Aspose.Slides segítségével. Lépésről‑lépésre kódminták, gyors, magas minőségű kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint előadásokat SWF formátumba konvertálni az Aspose.Slides segítségével. Megmutatja, hogyan lehet egy előadást SWF fájlként menteni a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódussal, és hogyan lehet a exportálást beállítani a [SwfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/) segítségével, beleértve a néző beállításait és a jegyzetek vagy megjegyzések elrendezését.

## **Előadások konvertálása Flash-re**

A [save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metódus, amely a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályban érhető el, használható a teljes előadás **SWF** dokumentummá konvertálásához. A következő példa azt mutatja, hogyan lehet egy előadást **SWF** dokumentummá konvertálni a [**SWFOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SwfOptions) osztály által biztosított beállítások használatával. A generált SWF-be megjegyzéseket is beilleszthet a [**ISWFOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISwfOptions) osztály és a [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/INotesCommentsLayoutingOptions) interfész segítségével.

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

**Tartalmazhatok rejtett diákat az SWF-ben?**

Igen. A rejtett diák engedélyezhetők a [setShowHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) metódus segítségével a [SwfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nem kerülnek exportálásra.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretet?**

Használja a [setCompressed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) metódust és a [adjust JPEG quality](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) beállítást a fájlméret és a kép pontosság egyensúlyozásához.

**Mi a célja a 'setViewerIncluded' metódusnak, és mikor kell letiltani?**

A [setViewerIncluded](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) beágyazott lejátszó felhasználói felületet ad hozzá (navigációs vezérlők, panelek, keresés). Tiltsa le, ha saját lejátszót kíván használni, vagy egy UI nélküli tiszta SWF keretre van szüksége.

**Mi történik, ha a forrási betűtípus hiányzik az exportáló gépen?**

Az Aspose.Slides a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) metódusban a [SwfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/swfoptions/) osztályban megadott betűtípust fogja helyettesíteni, hogy elkerülje a nem kívánt fallbacket.