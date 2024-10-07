---
title: Präsentation importieren
type: docs
weight: 60
url: /androidjava/import-presentation/
keywords: "Import PowerPoint, PDF in Präsentation, PDF in PPTX, PDF in PPT, Java, Aspose.Slides für Android über Java"
description: "Importieren Sie eine PowerPoint-Präsentation aus PDF. Konvertieren Sie PDF in PowerPoint"
---

Mit [**Aspose.Slides für Android über Java**](https://products.aspose.com/slides/androidjava/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides bietet die [SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) Klasse, um Ihnen zu ermöglichen, Präsentationen aus PDFs, HTML-Dokumenten usw. zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall konvertieren Sie eine PDF in eine PowerPoint-Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) Klasse.
2. Rufen Sie die Methode [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) um die Datei im PowerPoint-Format zu speichern.

Dieser Java-Code demonstriert die PDF- zu PowerPoint-Operation:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tipp" color="primary" %}} 

Sie sollten die **Aspose kostenlose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web-App ausprobieren, da sie eine Live-Implementierung des hier beschriebenen Prozesses ist. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall konvertieren Sie ein HTML-Dokument in eine PowerPoint-Präsentation.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) Klasse.
2. Rufen Sie die Methode [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die Methode [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) um die Datei im PowerPoint-Format zu speichern.

Dieser Java-Code demonstriert die HTML- zu PowerPoint-Operation: 

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

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}