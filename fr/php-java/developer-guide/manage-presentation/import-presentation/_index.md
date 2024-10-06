---
title: Importer une présentation
type: docs
weight: 60
url: /php-java/import-presentation/
keywords: "Importer PowerPoint, PDF vers Présentation, PDF vers PPTX, PDF vers PPT, Java, Aspose.Slides pour PHP via Java"
description: "Importer une présentation PowerPoint depuis un PDF. Convertir PDF en PowerPoint"
---

En utilisant [**Aspose.Slides pour PHP via Java**](https://products.aspose.com/slides/php-java/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) qui vous permet d'importer des présentations à partir de PDF, de documents HTML, etc.

## **Importer PowerPoint depuis PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et passez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code PHP démontre l'opération de conversion de PDF en PowerPoint :

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

{{% alert title="Astuce" color="primary" %}} 

Vous pouvez consulter l'application web **Aspose gratuite** [PDF vers PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car c'est une mise en œuvre en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint depuis HTML**

Dans ce cas, vous allez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et passez le fichier HTML.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code PHP démontre l'opération de conversion de HTML en PowerPoint :

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

{{% alert title="Note" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML vers d'autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}