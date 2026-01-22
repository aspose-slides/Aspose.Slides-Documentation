---
title: Importer des présentations à partir de PDF ou HTML en JavaScript
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Importez des documents PDF et HTML dans des présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js, pour un traitement des diapositives fluide et haute performance."
---

En utilisant [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), vous pouvez importer des présentations à partir de fichiers dans d’autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) pour vous permettre d’importer des présentations depuis des PDF, des documents HTML, etc.

## **Importer PowerPoint depuis un PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et transmettez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code JavaScript montre l’opération de conversion PDF vers PowerPoint :
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert  title="Tip" color="primary" %}} 

Vous voudrez peut‑être consulter l’application web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s’agit d’une implémentation en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint depuis HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) .
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et transmettez le fichier HTML.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Les tables sont‑elles préservées lors de l’importation d’un PDF, et leur détection peut‑elle être améliorée ?**

Les tables peuvent être détectées lors de l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) inclut une méthode [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) qui active la reconnaissance des tables. L’efficacité dépend de la structure du PDF.