---
title: PDF vagy HTML importálása prezentációkba PHP-ben
linktitle: Prezentáció importálása
type: docs
weight: 60
url: /hu/php-java/import-presentation/
keywords:
- prezentáció importálása
- dia importálása
- PDF importálása
- HTML importálása
- PDF prezentációvá
- PDF PPT‑vé
- PDF PPTX‑vé
- PDF ODP‑vé
- HTML prezentációvá
- HTML PPT‑vé
- HTML PPTX‑vé
- HTML ODP‑vé
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importáljon PDF és HTML dokumentumokat PowerPoint és OpenDocument prezentációkba PHP-ben az Aspose.Slides segítségével a zökkenőmentes, nagy teljesítményű diáfeldolgozás érdekében."
---
## **Bevezetés**

Az [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/hu/php-java/) használatával importálhat prezentációkat más formátumú fájlokból. Az Aspose.Slides biztosítja a [SlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) osztályt, amely lehetővé teszi prezentációk importálását PDF‑ekből, HTML‑dokumentumokból stb.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF‑et PowerPoint‑prezentációvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/) osztályból.  
2. Hívja meg az [addFromPdf()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metódust, és adja meg a PDF fájlt.  
3. Használja a [save()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a PHP kód bemutatja a PDF‑ből PowerPoint‑ba átalakítást:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Tip" color="primary" %}} 
Érdemes megnézni az **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez a leírt folyamat élő megvalósítása. 
{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML‑dokumentumot PowerPoint‑prezentációvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/) osztályból.  
2. Hívja meg az [addFromHtml()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metódust, és adja meg a HTML fájlt.  
3. Használja a [save()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a PHP kód bemutatja a HTML‑ból PowerPoint‑ba átalakítást:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **GYIK**

**Megmaradnak-e a táblázatok PDF importálásakor, és javítható-e azok felismerése?**

Az importálás során felismerhetők a táblázatok; a [PdfImportOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfimportoptions/) tartalmaz egy [setDetectTables](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfimportoptions/#setDetectTables) metódust, amely engedélyezi a táblázatok felismerését. A hatékonyság a PDF struktúrájától függ.

{{% alert title="Note" color="warning" %}} 
Az Aspose.Slides segítségével HTML‑t más népszerű fájlformátumokra is konvertálhat: 

* [HTML to image](https://products.aspose.com/slides/hu/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hu/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hu/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hu/php-java/conversion/html-to-tiff/)

{{% /alert %}}