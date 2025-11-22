---
title: "PowerPoint aus PDF oder HTML importieren"
linktitle: "Präsentation importieren"
type: docs
weight: 60
url: /de/net/import-presentation/
keywords: "PowerPoint importieren, PDF zu PowerPoint, HTML zu PowerPoint, PDF zu PPT, HTML zu PPT, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint aus PDF oder HTML importieren. PDF zu PowerPoint konvertieren. HTML zu PowerPoint konvertieren."
---

Mit [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) bereit, mit der Sie Präsentationen aus PDF‑Dokumenten importieren können.

## **PowerPoint aus PDF importieren**

Hierbei konvertieren Sie ein PDF in eine PowerPoint‑Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Rufen Sie die Methode [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) auf und übergeben die PDF‑Datei. 
3. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), um die Datei im PowerPoint‑Format zu speichern.

Dieser C#‑Code demonstriert die PDF‑zu‑PowerPoint‑Operation:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Vielleicht möchten Sie die kostenlose **Aspose** PDF‑zu‑PowerPoint‑Web‑App ausprobieren, da sie eine Live‑Implementierung des hier beschriebenen Vorgangs bietet. 
{{% /alert %}} 

## **PowerPoint aus HTML importieren**

Hierbei konvertieren Sie ein HTML‑Dokument in eine PowerPoint‑Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) . 
2. Rufen Sie die Methode [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) auf und übergeben die HTML‑Datei. 
3. Verwenden Sie die Methode [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5), um die Datei als PowerPoint‑Dokument zu speichern.

Dieser C#‑Code demonstriert die HTML‑zu‑PowerPoint‑Operation: 
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


## **FAQ**

**Werden Tabellen beim Importieren einer PDF erhalten und kann ihre Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; PdfImportOptions enthält einen Parameter DetectTables, der die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur der PDF ab.

{{% alert title="Note" color="warning" %}} 
Sie können Aspose.Slides außerdem verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}