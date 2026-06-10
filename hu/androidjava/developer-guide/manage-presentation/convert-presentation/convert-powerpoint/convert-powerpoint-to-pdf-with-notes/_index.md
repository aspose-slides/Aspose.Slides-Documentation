---
title: PowerPoint-prezentációk konvertálása PDF-re jegyzetekkel Androidon
linktitle: PowerPoint PDF-re jegyzetekkel
type: docs
weight: 50
url: /hu/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- prezentáció mentése PDFként
- PPT mentése PDFként
- PPTX mentése PDFként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF jegyzetekkel
- Android
- Java
- Aspose.Slides
description: "PPT és PPTX formátumok konvertálása PDF-re jegyzetekkel az Aspose.Slides for Android Java használatával. Megőrzi az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. A útmutató bemutatja a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony elvégzéséhez. A cikk végére képes lesz:

- A konverziós folyamat megvalósítására, amely a PowerPoint diákat PDF dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- A kimeneti PDF testreszabására, hogy az előadói jegyzetek benne legyenek és a kívánt módon legyenek formázva.

## **PowerPoint konvertálása PDF-re jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálására előadói jegyzetekkel. Az Aspose.Slides-nél egyszerűen betölti a prezentációt, beállítja az elrendezési lehetőségeket a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztály segítségével a jegyzetek belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑re Jegyzetes Diák nézetben.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// PDF beállítások konfigurálása az előadói jegyzetek rendereléséhez.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Az előadói jegyzetek megjelenítése a dia alján.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// A prezentáció mentése PDF-ként előadói jegyzetekkel.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Érdemes megtekinteni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}