---
title: PowerPoint prezentációk konvertálása PDF-re jegyzetekkel Java-ban
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-re
- prezentáció PDF-re
- dia PDF-re
- PPT PDF-re
- PPTX PDF-re
- prezentáció mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- Java
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-re jegyzetekkel az Aspose.Slides for Java segítségével. Tartsa meg az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulhatja, hogyan konvertálhatja a PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató bemutatja a szükséges lépéseket, és kódpéldákat biztosít a feladat hatékony megvalósításához. A cikk végére képes lesz:

- Megvalósítani a konverziós folyamatot, amely a PowerPoint‑diákot PDF‑dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy az előadói jegyzetek bele legyenek foglalva és a kívánt módon legyenek formázva.

## **PowerPoint átalakítása PDF‑re jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályban használható egy PPT vagy PPTX prezentáció PDF‑re konvertálásához előadói jegyzetekkel. Az Aspose.Slides‑szal egyszerűen betölti a prezentációt, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) osztály segítségével konfigurálja az elrendezési beállításokat a jegyzetek belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑re a Jegyzetdia nézetben.

```java
Presentation presentation = new Presentation("sample.pptx");

// Állítsa be a PDF beállításokat az előadói jegyzetek rendereléséhez.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Az előadói jegyzeteket a dia alá rendereli.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Mentse a prezentációt PDF-ként előadói jegyzetekkel.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 

Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatását. 

{{% /alert %}}