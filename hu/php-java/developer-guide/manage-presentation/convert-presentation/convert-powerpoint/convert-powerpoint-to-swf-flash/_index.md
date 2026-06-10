---
title: PowerPoint előadások konvertálása SWF Flash-re PHP-ben
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/php-java/convert-powerpoint-to-swf-flash/
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
- PPT exportálása SWF-re
- PPTX exportálása SWF-re
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) konvertálása SWF Flash-re PHP-ben az Aspose.Slides segítségével. Lépés-ről-lépésre kódminták, gyors, minőségi kimenet, PowerPoint automatizálás nélkül."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint előadásokat SWF formátumba konvertálni az Aspose.Slides használatával. Megmutatja, hogyan lehet egy előadást SWF fájlként menteni a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/save/) módszerrel, és hogyan lehet beállítani az exportot a [SwfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/) segítségével, beleértve a néző beállításait és a jegyzetek vagy megjegyzések elrendezését.

## **Prezentációk konvertálása Flash-re**

A [save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/save/) metódus, amely a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban érhető el, használható az egész prezentáció **SWF** dokumentummá konvertálásához. A következő példa bemutatja, hogyan lehet egy prezentációt **SWF** dokumentummá konvertálni a [SWFOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/) osztály által biztosított beállítások használatával. A [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) osztály segítségével a generált SWF-be megjegyzéseket is belefoglalhat.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Prezentáció mentése
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Be tudom‑e vonni a rejtett diakat az SWF‑be?**

Igen. A rejtett diák engedélyezhetők a [setShowHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/setshowhiddenslides/) metódussal a [SwfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/) osztályban. Alapértelmezés szerint a rejtett diák nincsenek exportálva.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [setCompressed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/setcompressed/) metódust és a [adjust JPEG quality](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/setjpegquality/) módszert a fájlméret és a képminőség egyensúlyozásához.

**Mi a 'setViewerIncluded' funkció, és mikor kell letiltani?**

[setViewerIncluded](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/setviewerincluded/) beágyazott lejátszó felhasználói felületet (navigációs vezérlők, panelek, keresés) ad hozzá. Tiltsa le, ha saját lejátszót kíván használni, vagy ha UI nélküli tiszta SWF keretre van szüksége.

**Mi történik, ha az exportáló gépen hiányzik a forrás betűtípus?**

Az Aspose.Slides a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) segítségével a [SwfOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/swfoptions/) osztályban megadott betűtípust fogja helyettesíteni, hogy elkerülje a nem kívánt visszaesést.