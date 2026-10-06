---
title: Prezentációk PDF-be konvertálása megjegyzésekkel Pythonban
linktitle: Prezentáció PDF-be megjegyzésekkel
type: docs
weight: 50
url: /hu/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
- PPT konvertálása
- PPTX konvertálása
- ODP konvertálása
- PowerPoint PDF-be
- OpenDocument PDF-be
- prezentáció PDF-be
- PPT PDF-be
- PPTX PDF-be
- ODP PDF-be
- előadói jegyzetek
- PDF megjegyzésekkel
- Python
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP formátumokat PDF-be megjegyzésekkel az Aspose.Slides for Python használatával. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató bemutatja a szükséges lépéseket, és kódrészleteket nyújt a feladat hatékony elvégzéséhez. A cikk végére képes lesz:

- Megvalósítani a konvertálási folyamatot, amely a PowerPoint‑diaikat PDF‑dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy a jegyzetek a kívánt módon legyenek belefoglalva és formázva.

A jegyzetoldal méretének és orientációjának beállításához exportálás előtt lásd a [Megjegyzésoldal mérete](/slides/hu/python-net/notes-size/) oldalt.

## **PowerPoint átalakítása PDF-be megjegyzésekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálására előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti a prezentációt, beállítja a elrendezési lehetőségeket a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével, hogy a jegyzetek benne legyenek, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑be Megjegyzés dia nézetben.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # A PDF beállítások konfigurálása az előadói jegyzetek rendereléséhez.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # A prezentáció mentése PDF-be előadói jegyzetekkel.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Megjegyzés" %}}
Érdemes lehet kipróbálni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást.
{{% /alert %}}