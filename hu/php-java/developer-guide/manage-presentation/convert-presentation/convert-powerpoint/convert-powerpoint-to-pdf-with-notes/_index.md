---
title: PowerPoint-prezentációk konvertálása PDF-be jegyzetekkel PHP-ben
linktitle: PowerPoint PDF-be jegyzetekkel
type: docs
weight: 50
url: /hu/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- diák konvertálása
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
- PHP
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for PHP segítségével Java-n keresztül. Megőrzi az elrendezéseket és az előadói jegyzeteket professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides használatával. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít, hogy hatékonyan megvalósíthassa ezt a feladatot. A cikk végére képes lesz:

- Megvalósítani a konverziós folyamatot, amely a PowerPoint‑diákokat PDF‑dokumentummá alakítja, miközben megőrzi az előadói jegyzeteket.
- Testreszabni a kimeneti PDF‑et, hogy az előadói jegyzetek benne legyenek, és az igényei szerint legyenek formázva.

## **PowerPoint konvertálása PDF‑be jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálásához előadói jegyzetekkel. Az Aspose.Slides használatával egyszerűen betölti a prezentációt, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) osztály segítségével beállítja az elrendezési lehetőségeket az előadói jegyzetek felvételéhez, majd a fájlt PDF‑ként menti. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy mintaprezentációt PDF‑re Jegyzet diák nézetben.

```php
$presentation = new Presentation("sample.pptx");

// Konfigurálja a PDF beállításokat az előadói jegyzetek megjelenítéséhez.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Az előadói jegyzeteket a dia alá rendereli.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Mentse a prezentációt PDF-be előadói jegyzetekkel.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion) szolgáltatást. 
{{% /alert %}}