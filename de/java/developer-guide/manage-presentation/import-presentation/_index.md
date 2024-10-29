---
title: Präsentation importieren
type: docs
weight: 60
url: /de/java/import-presentation/
keywords: "PowerPoint importieren, PDF zu Präsentation, PDF zu PPTX, PDF zu PPT, Java, Aspose.Slides für Java"
description: "Importieren Sie eine PowerPoint-Präsentation aus PDF. Konvertieren Sie PDF in PowerPoint"
---

Mit [**Aspose.Slides für Java**](https://products.aspose.com/slides/java/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides bietet die [SlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) Klasse, um Ihnen den Import von Präsentationen aus PDFs, HTML-Dokumenten usw. zu ermöglichen.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie eine PDF in eine PowerPoint-Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/) Klasse. 
2. Rufen Sie die [addFromPdf()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) Methode auf und übergeben Sie die PDF-Datei. 
3. Verwenden Sie die [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser Java-Code demonstriert die PDF zu PowerPoint-Operation:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}} 

Sie möchten möglicherweise die **kostenlose Aspose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web-App ausprobieren, da es sich um eine Live-Implementierung des hier beschriebenen Prozesses handelt. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML-Dokument in eine PowerPoint-Präsentation konvertieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/) Klasse. 
2. Rufen Sie die [addFromHtml()](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) Methode auf und übergeben Sie die HTML-Datei. 
3. Verwenden Sie die [save()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser Java-Code demonstriert die HTML zu PowerPoint-Operation: 

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

{{% alert title="Hinweis" color="warning" %}} 

Sie können auch Aspose.Slides verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}