---
title: PowerPoint bemutatók konvertálása PDF-re megjegyzésekkel Androidon
linktitle: PowerPoint PDF-re megjegyzésekkel
type: docs
weight: 50
url: /hu/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PDF-re
- bemutató PDF-re
- dia PDF-re
- PPT PDF-re
- PPTX PDF-re
- bemutató mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- előadói jegyzetek
- PDF megjegyzésekkel
- Android
- Java
- Aspose.Slides
description: "PPT és PPTX formátumok konvertálása PDF-re megjegyzésekkel az Aspose.Slides for Android segítségével Java-ban. Megőrzi a elrendezéseket és az előadói jegyzeteket professzionális bemutatókhoz."
---
## **Áttekintés**

Ebben a cikkben meg fogod tanulni, hogyan konvertálhatod a PowerPoint‑bemutatókat PDF‑formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató bemutatja a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony megvalósításához. A cikk végére képes leszel:

- Megvalósítani a konverziós folyamatot, amely a PowerPoint‑diákat PDF‑dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy az előadói jegyzetek a kívánt módon legyenek belefoglalva és formázva.

## **PowerPoint konvertálása PDF‑re megjegyzésekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályban használható PPT vagy PPTX bemutató PDF‑re konvertálásához előadói jegyzetekkel. Az Aspose.Slides‑el egyszerűen betöltheted a bemutatót, konfigurálhatod a elrendezési beállításokat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztály segítségével, hogy belefoglalja az előadói jegyzeteket, majd mentheted a fájlt PDF‑ként. Az alábbi kódrészlet bemutatja, hogyan konvertálhatsz egy mintabemutatót PDF‑re Megjegyzés‑dia nézetben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Állítsa be a PDF beállításokat az előadói jegyzetek megjelenítéséhez.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// A bemutató mentése PDF-be előadói jegyzetekkel.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}