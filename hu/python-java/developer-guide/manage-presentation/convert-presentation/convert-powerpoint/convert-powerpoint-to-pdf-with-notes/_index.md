---
title: PowerPoint prezentációk PDF-be konvertálása jegyzetekkel Pythonban
linktitle: PowerPoint PDF-be konvertálása jegyzetekkel
type: docs
weight: 50
url: /hu/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-be
- prezentáció PDF-be
- PPT PDF-be
- PPTX PDF-be
- prezentáció mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadójegyzetek
- PDF jegyzetekkel
- Python
- Java
- Aspose.Slides
description: "Konvertálja a PPT és PPTX prezentációkat PDF-be előadójegyzetekkel az Aspose.Slides for Python via Java segítségével. Állítsa be a jegyzetek elhelyezését, és őrizze meg a hosszú jegyzeteket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat PDF‑be konvertálni előadó jegyzetekkel az Aspose.Slides for Python via Java segítségével. A jegyzeteket hozzáadhatja minden dia alá, és a hosszú jegyzetek folytathatók további oldalakra. A PDF‑exportálás egyéb beállításaiért lásd a [Convert PowerPoint to PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) oldalt.

A jegyzetoldal méretének és tájolásának beállításához az exportálás előtt lásd a [Notes Page Size](/slides/hu/python-java/notes-size/) oldalt.

## **PowerPoint átalakítása PDF-be jegyzetekkel**

A [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból használja a PPT vagy PPTX prezentáció PDF‑be exportálásához. A előadójegyzetek hozzáadásához hozzon létre egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot, és állítsa be a jegyzetek elhelyezését a [setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódussal. Ezt a layoutot rendelje a [PdfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/) osztályhoz a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódussal.

A következő példa betölti a `sample.pptx` fájlt, és exportálja `output.pdf`‑be a diák alatti előadójegyzetekkel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # A PDF beállításainak konfigurálása az előadójegyzetek megjelenítéséhez.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # A prezentáció mentése PDF-be előadójegyzetekkel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Próbálja ki a [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást is.
{{% /alert %}}

## **GYIK**

**Hogyan akadályozhatom meg, hogy a hosszú előadójegyzetek levágásra kerüljenek?**

Használja a [NotesPositions.BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull) opciót, ahogyan a fenti példában is látható. Ez a beállítás a jegyzetek teljes tartalmát jeleníti meg, szükség esetén további oldalakat használva.

**Minden diát és a hozzá tartozó jegyzetet egyetlen oldalon tarthatok?**

Használja a [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomTruncated) opciót. Ez a beállítás a jegyzeteket egy oldalra korlátozza, így a nem férő jegyzetek le lesznek vágva.

**Hogyan exportálhatok diákat előadójegyzetek nélkül?**

Hagyja ki a jegyzetelrendezés beállítását, és használja a standard PDF‑exportálást, amely a [Convert PowerPoint to PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) cikkben le van írva.