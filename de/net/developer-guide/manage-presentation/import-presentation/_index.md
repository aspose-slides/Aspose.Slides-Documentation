---
title: Importieren von Präsentationen aus PDF oder HTML in .NET
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/net/import-presentation/
keywords:
- Präsentation importieren
- Folien importieren
- PDF importieren
- HTML importieren
- PDF zu Präsentation
- PDF zu PPT
- PDF zu PPTX
- PDF zu ODP
- HTML zu Präsentation
- HTML zu PPT
- HTML zu PPTX
- HTML zu ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importieren Sie mühelos PDF- und HTML-Dokumente in PowerPoint- und OpenDocument-Präsentationen in .NET mit Aspose.Slides für nahtlose, leistungsstarke Folienverarbeitung."
---

Mit [**Aspose.Slides für .NET**](https://products.aspose.com/slides/net/) können Sie Präsentationen aus Dateien anderer Formate importieren. Aspose.Slides stellt die Klasse [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) zur Verfügung, mit der Sie Präsentationen aus PDF‑Dokumenten importieren können.

## **PowerPoint aus PDF importieren**

In diesem Fall können Sie ein PDF in eine PowerPoint‑Präsentation konvertieren.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. 
2. Rufen Sie die [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1)‑Methode auf und übergeben Sie die PDF‑Datei. 
3. Verwenden Sie die [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5)‑Methode, um die Datei im PowerPoint‑Format zu speichern.

Dieser C#‑Code demonstriert die PDF‑zu‑PowerPoint‑Operation:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Vielleicht möchten Sie die kostenlose Aspose‑Web‑App [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) ausprobieren, da sie eine Live‑Implementierung des hier beschriebenen Vorgangs bietet. 
{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall können Sie ein HTML‑Dokument in eine PowerPoint‑Präsentation konvertieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. 
2. Rufen Sie die [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml)‑Methode auf und übergeben Sie die HTML‑Datei. 
3. Verwenden Sie die [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5)‑Methode, um die Datei als PowerPoint‑Dokument zu speichern.

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

**Werden Tabellen beim Importieren eines PDFs beibehalten, und kann ihre Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) enthält einen Parameter [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/), der die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.

{{% alert title="Hinweis" color="warning" %}} 
Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}