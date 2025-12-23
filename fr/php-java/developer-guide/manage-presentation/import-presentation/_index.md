---
title: Importer des présentations depuis PDF ou HTML en PHP
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/php-java/import-presentation/
keywords:
- importer présentation
- importer diapositive
- importer PDF
- importer HTML
- PDF vers présentation
- PDF vers PPT
- PDF vers PPTX
- PDF vers ODP
- HTML vers présentation
- HTML vers PPT
- HTML vers PPTX
- HTML vers ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importez des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en PHP avec Aspose.Slides pour un traitement des diapositives fluide et haute performance."
---

Using [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

En utilisant [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) pour vous permettre d'importer des présentations à partir de PDF, de documents HTML, etc.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et transmettez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code PHP montre l'opération de conversion PDF vers PowerPoint :
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
Vous voudrez peut-être consulter l'application web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s'agit d'une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et transmettez le fichier HTML.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

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


## **FAQ**

**Les tables sont-elles conservées lors de l'importation d'un PDF, et leur détection peut-elle être améliorée ?**

Les tables peuvent être détectées lors de l'importation ; [PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) comprend une méthode [setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/#setDetectTables) qui active la reconnaissance des tables. L'efficacité dépend de la structure du PDF.

{{% alert title="Note" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir du HTML vers d'autres formats de fichiers populaires :

* [HTML vers image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}