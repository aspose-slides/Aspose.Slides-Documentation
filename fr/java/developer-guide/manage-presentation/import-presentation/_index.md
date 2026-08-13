---
title: Importer des présentations à partir de PDF ou HTML en Java
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/java/import-presentation/
keywords:
- importation de présentation
- importation de diapositive
- importation PDF
- importation HTML
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
- Java
- Aspose.Slides
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en Java avec Aspose.Slides pour un traitement de diapositives fluide et haute performance."
---
## **Introduction**

Avec Aspose.Slides, vous pouvez importer des présentations à partir de fichiers dans d’autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/) qui permet d’importer des présentations à partir de documents PDF et HTML.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous convertissez un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/).
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et passez le fichier PDF.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java illustre l’opération de conversion PDF vers PowerPoint :
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
Vous voudrez peut‑être consulter l’application web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fr/import/pdf-to-powerpoint) car il s’agit d’une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous convertissez un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/).
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et passez un flux contenant le document HTML.
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java illustre l’opération de conversion HTML vers PowerPoint : 
```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### Les tableaux sont‑ils conservés lors de l’importation d’un PDF, et leur détection peut‑elle être améliorée ?

Les tableaux peuvent être détectés lors de l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfimportoptions/) comprend une méthode [setDetectTables](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) qui active la reconnaissance des tableaux. L’efficacité dépend de la structure du PDF.

{{% alert title="Note" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir HTML vers d’autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/fr/java/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/fr/java/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/fr/java/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/fr/java/conversion/html-to-tiff/)

{{% /alert %}}