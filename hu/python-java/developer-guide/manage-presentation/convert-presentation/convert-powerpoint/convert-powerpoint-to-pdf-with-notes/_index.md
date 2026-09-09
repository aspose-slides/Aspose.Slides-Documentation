---
title: PowerPoint bemutatók konvertálása PDF-re jegyzetekkel Pythonban
linktitle: PowerPoint PDF-re konvertálás jegyzetekkel
type: docs
weight: 50
url: /hu/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-re
- bemutató PDF-re
- PPT PDF-re
- PPTX PDF-re
- bemutató mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- Python
- Java
- Aspose.Slides
description: "Konvertálja a PPT és PPTX bemutatókat PDF-re előadói jegyzetekkel az Aspose.Slides for Python via Java használatával. Állítsa be a jegyzetek elhelyezését és őrizze meg a hosszú jegyzeteket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhat PowerPoint‑prezentációkat PDF‑be előadói jegyzetekkel az Aspose.Slides for Python via Java használatával. A jegyzetek elhelyezhetők minden dia alján, és a hosszú jegyzetek további oldalakon folytathatók. Egyéb PDF‑exportálási beállításokért lásd a [PowerPoint átalakítása PDF-re](/slides/hu/python-java/convert-powerpoint-to-pdf/) oldalt.

## **PowerPoint átalakítása PDF-re jegyzetekkel**

Használja a [save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból a PPT vagy PPTX prezentáció PDF‑be exportálásához. Az előadói jegyzetek mellőzéséhez hozzon létre egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/) objektumot, és állítsa be a jegyzetek elhelyezését a [setNotesPosition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódussal. Ezt a elrendezést rendelje a [PdfOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/) objektumhoz a [setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) metódussal.

Az alábbi példa betölti a `sample.pptx`‑t, és exportálja `output.pdf`‑be a diák alatti előadói jegyzetekkel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # A PDF beállítások konfigurálása az előadói jegyzetek megjelenítéséhez.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # A bemutató mentése PDF-be előadói jegyzetekkel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}}
Próbálja ki a [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást is.
{{% /alert %}}

## **GYIK**

**Hogyan akadályozhatom meg, hogy a hosszú előadói jegyzetek levágásra kerüljenek?**  
Használja a [NotesPositions.BottomFull](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomFull) beállítást, ahogy a fenti példában is. Ez a beállítás a teljes jegyzeteket jeleníti meg, szükség esetén további oldalakat használva.

**Megtarthatom, hogy minden dia és annak jegyzetei egy oldalon legyenek?**  
Használja a [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notespositions/#BottomTruncated) beállítást. Ez a beállítás a jegyzeteket egy oldalra korlátozza, ezért a nem férő rész levágásra kerül.

**Hogyan exportálhatom a diákat előadói jegyzetek nélkül?**  
Hagyja el a jegyzetelrendezés konfigurálását, és használja a szokásos PDF‑exportálást, amelyet a [PowerPoint átalakítása PDF-re](/slides/hu/python-java/convert-powerpoint-to-pdf/) leírásban talál.