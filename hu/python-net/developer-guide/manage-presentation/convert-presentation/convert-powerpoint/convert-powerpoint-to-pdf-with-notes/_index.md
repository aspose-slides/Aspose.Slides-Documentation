---
title: Prezentációk konvertálása PDF-re jegyzetekkel Pythonban
linktitle: Prezentáció PDF-re jegyzettel
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
- PowerPoint PDF-re
- OpenDocument PDF-re
- prezentáció PDF-re
- PPT PDF-re
- PPTX PDF-re
- ODP PDF-re
- előadói jegyzetek
- PDF jegyzetekkel
- Python
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP formátumokat PDF-re jegyzetekkel az Aspose.Slides for Python használatával. Tartsa meg az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, amelyek segítenek hatékonyan elvégezni a feladatot. A cikk végére képes lesz:

- Megvalósítani a konvertálási folyamatot, amely a PowerPoint‑diákot PDF‑dokumentummá alakítja át, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy az előadói jegyzetek benne legyenek és a kívánt módon legyenek formázva.

## **PowerPoint konvertálása PDF‑re jegyzetekkel**

`save` metódus a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálására előadói jegyzetekkel. Az Aspose.Slides‑szel egyszerűen betölti a prezentációt, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/notescommentslayoutingoptions/) osztály segítségével beállítja a elrendezési lehetőségeket az előadói jegyzetek hozzáadásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy példaprezentációt PDF‑re Jegyzet-diák nézetben.

```py
with slides.Presentation("sample.pptx") as presentation:

    # PDF beállítások konfigurálása előadói jegyzetek rendereléséhez.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # A prezentáció mentése PDF-be előadói jegyzetekkel.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Érdemes megtekinteni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}