---
title: PowerPoint prezentációk konvertálása PDF-be jegyzetekkel Java-ban
linktitle: PowerPoint PDF-be jegyzetekkel
type: docs
weight: 50
url: /hu/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-be
- prezentáció PDF-be
- dia PDF-be
- PPT PDF-be
- PPTX PDF-be
- prezentáció mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- Java
- Aspose.Slides
description: "PPT és PPTX formátumok konvertálása PDF-be jegyzetekkel az Aspose.Slides for Java használatával. Elrendezések és előadói jegyzetek megőrzése professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhatja a PowerPoint‑prezentációkat PDF formátumba előadásjegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészletekkel segíti a feladat hatékony megoldását. A cikk végére képes lesz:

- Implementálni a konverziós folyamatot, amely a PowerPoint‑diaikat PDF‑dokumentummá alakítja át, miközben megőrzi az előadásjegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy a jegyzetek a kívánt módon legyenek benne és formázva.

Az exportálás előtti jegyzetoldal méretének és orientációjának beállításához lásd [Megjegyzés oldal mérete](/slides/hu/java/notes-size/).

## **PowerPoint konvertálása PDF‑be jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑be konvertálására előadásjegyzetekkel. Az Aspose.Slides‑szel egyszerűen betölti a prezentációt, beállítja a felületelrendezési beállításokat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) osztály segítségével a jegyzetek feltüntetéséhez, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑be Jegyzet Dia nézetben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// PDF beállítások konfigurálása az előadói jegyzetek rendereléséhez.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Az előadói jegyzeteket a dia alá rendereli.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Érdemes megtekinteni az Aspose [Online PowerPoint PDF konvertáló](https://products.aspose.app/slides/hu/conversion) szolgáltatást.
{{% /alert %}}