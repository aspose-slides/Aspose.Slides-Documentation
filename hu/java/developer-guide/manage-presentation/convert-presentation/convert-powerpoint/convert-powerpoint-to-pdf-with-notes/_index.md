---
title: PowerPoint-prezentációk konvertálása PDF-be jegyzetekkel Java-ban
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
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for Java segítségével. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató bemutatja a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony megoldásához. A cikk végére képes lesz:

- Valósítsa meg a konverziós folyamatot, amely a PowerPoint-diákat PDF‑dokumentummá alakítja, miközben megőrzi a jegyzeteket.
- Testreszabhatja a kimeneti PDF‑et, hogy a jegyzetek szerepeljenek és a kívánt módon legyenek formázva.

## **PowerPoint átalakítása PDF‑be jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályban felhasználható egy PPT vagy PPTX prezentáció PDF‑re konvertálásához előadói jegyzetekkel. Az Aspose.Slides‑szel egyszerűen betölti a prezentációt, beállítja a elrendezési lehetőségeket a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) osztály segítségével a jegyzetek belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy minta‑prezentációt PDF‑re a Jegyzetek Dia nézetben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Állítsa be a PDF opciókat a jegyzetek megjelenítéséhez.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Megjeleníti a jegyzeteket a dia alatt.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Mentse a prezentációt PDF-be a jegyzetekkel.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
Érdemes megtekinteni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion). 
{{% /alert %}}