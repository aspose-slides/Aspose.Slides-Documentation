---
title: PowerPoint prezentációk konvertálása PDF-be jegyzetekkel PHP-ban
linktitle: PowerPoint PDF-be konvertálás jegyzetekkel
type: docs
weight: 50
url: /hu/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "Konvertálja a PPT és PPTX formátumokat PDF-be jegyzetekkel az Aspose.Slides for PHP Java-on keresztül. Tartsa meg az elrendezéseket és az előadói jegyzeteket a professzionális prezentációkhoz."
---
## **Áttekintés**

Ebben a cikkben megtanulja, hogyan konvertálhat PowerPoint‑prezentációkat PDF formátumba előadói jegyzetekkel az Aspose.Slides segítségével. Ez az útmutató lefedi a szükséges lépéseket, és kódrészleteket biztosít a feladat hatékony megvalósításához. A cikk végére képes lesz:

- Implementálja a konverziós folyamatot, hogy a PowerPoint‑diák PDF‑dokumentumokká alakuljanak, miközben megőrzik az előadói jegyzeteket.
- Testreszabhatja a kimeneti PDF‑et, hogy az előadói jegyzetek szerepeljenek benne, és a kívánt módon legyenek formázva.

A jegyzetoldal méretének és tájolásának beállításához exportálás előtt tekintse meg a [Notes Page Size](/slides/hu/php-java/notes-size/) oldalt.

## **PowerPoint konvertálása PDF‑be jegyzetekkel**

A `save` metódus a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályban használható PPT vagy PPTX prezentáció PDF‑re konvertálásához előadói jegyzetekkel. Az Aspose.Slides segítségével egyszerűen betölti a prezentációt, a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) osztály használatával beállítja az elrendezési opciókat az előadói jegyzetek belefoglalásához, majd PDF‑ként menti a fájlt. Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy minta‑prezentációt PDF‑re a Jegyzetdiák nézetben.

```php
$presentation = new Presentation("sample.pptx");

// Állítsa be a PDF beállításokat az előadói jegyzetek megjelenítéséhez.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Az előadói jegyzetek megjelenítése a dia alatt.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Mentse a prezentációt PDF-be előadói jegyzetekkel.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Érdemes megnézni az Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/hu/conversion).
{{% /alert %}}