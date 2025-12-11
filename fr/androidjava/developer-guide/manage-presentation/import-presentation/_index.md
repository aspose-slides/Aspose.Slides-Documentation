---
title: Importation de présentations depuis PDF ou HTML sur Android
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/androidjava/import-presentation/
keywords:
- importer une présentation
- importer une diapositive
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
- Android
- Java
- Aspose.Slides
description: "Importez des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en Java avec Aspose.Slides for Android pour un traitement des diapositives fluide et haute performance."
---

En utilisant [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), vous pouvez importer des présentations à partir de fichiers dans d’autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) qui vous permet d’importer des présentations à partir de PDF, de documents HTML, etc.

## **Importer PowerPoint depuis PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et transmettez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java montre l’opération de conversion PDF vers PowerPoint :
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert  title="Astuce" color="primary" %}} 
Vous voudrez peut-être consulter l’application web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s’agit d’une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint depuis HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/).
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et transmettez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java montre l’opération de conversion HTML vers PowerPoint :
```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Les tables sont-elles préservées lors de l’importation d’un PDF, et leur détection peut-elle être améliorée ?**

Les tables peuvent être détectées lors de l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/) comprend une méthode [setDetectTables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) qui active la reconnaissance des tables. L’efficacité dépend de la structure du PDF.

{{% alert title="Remarque" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir le HTML vers d’autres formats de fichiers populaires :

* [HTML vers image](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}