---
title: Importer une présentation
type: docs
weight: 60
url: /fr/java/import-presentation/
keywords: "Importer PowerPoint, PDF vers présentation, PDF vers PPTX, PDF vers PPT, Java, Aspose.Slides pour Java"
description: "Importer une présentation PowerPoint à partir d'un PDF. Convertir PDF en PowerPoint"
---

En utilisant [**Aspose.Slides pour Java**](https://products.aspose.com/slides/java/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) pour vous permettre d'importer des présentations à partir de PDF, de documents HTML, etc.

## **Importer PowerPoint à partir d'un PDF**

Dans ce cas, vous allez convertir un PDF en une présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/). 
2. Appelez la méthode [addFromPdf()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) et passez le fichier PDF. 
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java illustre l'opération de conversion de PDF à PowerPoint :

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Conseil" color="primary" %}} 

Vous voudrez peut-être consulter l'application web **Aspose gratuite** [PDF vers PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car c'est une mise en œuvre en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous allez convertir un document HTML en une présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/). 
2. Appelez la méthode [addFromHtml()](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) et passez le fichier HTML. 
3. Utilisez la méthode [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) pour enregistrer le fichier au format PowerPoint.

Ce code Java illustre l'opération de conversion de HTML à PowerPoint :

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

{{% alert title="Remarque" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML en d'autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}