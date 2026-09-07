---
title: PowerPoint prezentációk konvertálása SWF Flash-re Python via Java
linktitle: PowerPoint SWF-re
type: docs
weight: 80
url: /hu/python-java/convert-powerpoint-to-swf-flash/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása SWF Flash-re Python via Java segítségével az Aspose.Slides használatával. Állítsa be a nézőt, a jegyzeteket, a rejtett diákot, a tömörítést és a betűtípusokat."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy a PowerPoint‑prezentációkat a Microsoft PowerPoint nélkül SWF‑re konvertálja. Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) a prezentáció exportálásához, valamint a [SwfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/) a néző beállításainak, a képminőségnek és a jegyzetek vagy megjegyzések elrendezésének konfigurálásához.

## **Prezentációk konvertálása Flash‑be**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/), konfigurálja a [SwfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/), majd mentse a [SaveFormat.Swf](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Swf) segítségével.

Az alábbi példa a `presentation.pptx`‑t `presentation.swf`‑be exportálja. Kikapcsolja a beágyazott nézőt a [setViewerIncluded](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setViewerIncluded)‑val, és a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) segítségével a diabok alatt megjeleníti az előadó jegyzeteit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

A példa futtatása előtt [telepítse az Aspose.Slides for Python via Java‑t](/slides/hu/python-java/installation/) és helyezze a `presentation.pptx`‑t a munkakönyvtárba. A JVM minden Python folyamat indításakor egyszer indul el.

A példa a [NotesPositions.BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull)‑t a [setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) segítségével alkalmazza, és a layoutra a [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions)‑t adja át. A hozzászólások belefoglalásához a [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)‑t kell beállítani az exportálás előtt.

## **GYIK**

**Bele tudok-e foglalni rejtett diákot az SWF‑be?**

Igen. Hívja a [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setShowHiddenSlides)‑t `True` értékkel. Alapértelmezés szerint a rejtett diák nem kerülnek exportálásra.

**Hogyan szabályozhatom a tömörítést és a végső SWF méretét?**

Használja a [SwfOptions.setCompressed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setCompressed)‑t a tömörítés engedélyezéséhez vagy letiltásához, illetve a [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setJpegQuality)‑t a JPEG képek minőségének beállításához. Az alacsonyabb JPEG minőség csökkentheti a fájlméretet, de a kép hűségét is rontja.

**Mi a beágyazott néző célja, és mikor kell letiltani?**

A [SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/#setViewerIncluded) határozza meg, hogy a létrehozott SWF tartalmazza‑e a nézőt. Adjon meg `False` értéket, ha a beágyazott néző nélküli exportált diákat szeretné, ahogy az előző példában is.

**Mi történik, ha a forrás betűtípus hiányzik az exportáló gépen?**

Megadhat egy alapértelmezett normál betűtípust a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) segítségével, amelyet a [SwfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/swfoptions/) örököl. Válasszon a exportfolyamat számára elérhető betűtípust; a betűkészlet helyettesítése megváltoztathatja a szöveg megjelenését és az elrendezést.