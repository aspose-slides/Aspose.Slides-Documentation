---
title: PowerPoint aus PDF oder HTML importieren
linktitle: Präsentation importieren
type: docs
weight: 60
url: /net/import-presentation/
keywords: "PowerPoint importieren, PDF zu PowerPoint, HTML zu PowerPoint, PDF zu PPT, HTML zu PPT, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint aus PDF oder HTML importieren. PDF in PowerPoint konvertieren. HTML in PowerPoint konvertieren"
---

Mit [**Aspose.Slides für .NET**](https://products.aspose.com/slides/net/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides bietet die [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) Klasse an, die es Ihnen ermöglicht, Präsentationen aus PDF-Dokumenten zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall konvertieren Sie eine PDF-Datei in eine PowerPoint-Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Rufen Sie die Methode [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), um die Datei im PowerPoint-Format zu speichern.

Dieser C#-Code demonstriert die PDF-zu-PowerPoint-Operation:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIPP" color="primary" %}} 

Sie sollten die **Aspose kostenlose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Webanwendung ausprobieren, da sie eine live Implementierung des hier beschriebenen Prozesses ist. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall konvertieren Sie ein HTML-Dokument in eine PowerPoint-Präsentation.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Rufen Sie die Methode [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) auf und übergeben Sie die HTML-Datei.
3. Verwenden Sie die Methode [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), um die Datei als PowerPoint-Dokument zu speichern.

Dieser C#-Code demonstriert die HTML-zu-PowerPoint-Operation:

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Hinweis" color="warning" %}} 

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}