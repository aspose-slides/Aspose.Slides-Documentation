---
title: PowerPoint bemutatók konvertálása PDF-re megjegyzésekkel Androidon
linktitle: PowerPoint PDF-re megjegyzésekkel
type: docs
weight: 50
url: /hu/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint átalakítás
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
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
- előadói megjegyzések
- PDF megjegyzésekkel
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-re megjegyzésekkel az Aspose.Slides for Android Java segítségével. Tartsa meg az elrendezéseket és az előadói megjegyzéseket a professzionális bemutatókhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálja a PowerPoint bemutatókat PDF formátumba előadói megjegyzésekkel az Aspose.Slides használatával. Ez az útmutató bemutatja a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony elvégzéséhez. A cikk végére képes lesz:

- A konvertálási folyamat megvalósítására, amely a PowerPoint diát PDF dokumentummá alakítja, miközben megőrzi az előadói megjegyzéseket.
- A kimeneti PDF testreszabására, hogy az előadói megjegyzések a kívánt módon legyenek belefoglalva és formázva.

A jegyzetoldal méreteinek és tájolásának exportálás előtti beállításához tekintse meg a [Notes Page Size](/slides/hu/androidjava/notes-size/).

## **PowerPoint konvertálása PDF-re megjegyzésekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályban használható PPT vagy PPTX bemutató PDF-re konvertálásához előadói megjegyzésekkel. Az Aspose.Slides segítségével egyszerűen betölti a bemutatót, beállítja az elrendezési opciókat a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) osztály használatával az előadói megjegyzések belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan lehet egy mintabemutatót PDF‑re konvertálni a Jegyzet Dia nézetben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// PDF beállítások konfigurálása az előadói megjegyzések rendereléséhez.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Az előadói megjegyzéseket a dia alá rendereli.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// A bemutató mentése PDF-be előadói megjegyzésekkel.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion).
{{% /alert %}}