---
title: PowerPoint bemutatók átalakítása PDF-re jegyzetekkel Pythonban
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint átalakítása
- bemutató átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint PDF-re
- bemutató PDF-re
- PPT PDF-re
- PPTX PDF-re
- bemutató mentése PDF-ként
- PPT exportálása PDF-re
- PPTX exportálása PDF-re
- előadói jegyzetek
- jegyzetekkel ellátott PDF
- Python
- Java
- Aspose.Slides
description: "PPT és PPTX bemutatókat konvertál PDF-re előadói jegyzetekkel az Aspose.Slides for Python via Java segítségével. Konfigurálja a jegyzetek elhelyezését, és őrizze meg a hosszú jegyzeteket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhat PowerPoint bemutatókat PDF-re előadói jegyzetekkel az Aspose.Slides for Python via Java használatával. A jegyzetek minden dia alá helyezhetők, és a hosszú jegyzetek további oldalakra folytathatók. A PDF export egyéb beállításai a [PowerPoint átalakítása PDF-re](/slides/hu/python-java/convert-powerpoint-to-pdf/) cikkben találhatók.

## **PowerPoint átalakítása PDF-re jegyzetekkel**

Használja a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusát a PPT vagy PPTX bemutató PDF-re exportálásához. Az előadói jegyzetek hozzáadásához hozza létre a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot, és állítsa be a [setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódusát. Ezt a layoutot adja a [PdfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/) osztályhoz a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódussal.

Az alábbi példa betölti a `sample.pptx` fájlt, és exportálja `output.pdf` néven, a diák alatti előadói jegyzetekkel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Állítsa be a PDF beállításokat az előadói jegyzetek rendereléséhez.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Mentse a bemutatót PDF-be előadói jegyzetekkel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}}
Próbálja ki a [Online PowerPoint PDF konvertálót](https://products.aspose.app/slides/hu/conversion).
{{% /alert %}}

## **GYIK**

**Hogyan kerülhetem el, hogy a hosszú előadói jegyzetek levágásra kerüljenek?**

Használja a [NotesPositions.BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull) beállítást, ahogyan a fenti példában is látható. Ez a beállítás a jegyzetek teljes megjelenítését biztosítja, szükség esetén további oldalakat használva.

**Tarthatom-e minden diát és a hozzá tartozó jegyzeteket egyetlen oldalon?**

Használja a [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomTruncated) beállítást. Ez a beállítás a jegyzeteket egy oldalra korlátozza, így a nem férő részek levágásra kerülnek.

**Hogyan exportálhatom a diákat előadói jegyzetek nélkül?**

Hagyja ki a jegyzetek elrendezésének konfigurációját, és használja a [PowerPoint átalakítása PDF-re](/slides/hu/python-java/convert-powerpoint-to-pdf/) cikkben leírt szabványos PDF exportot.