---
title: Präsentation importieren
type: docs
weight: 60
url: /de/python-net/import-presentation/
keywords: "PowerPoint importieren, PDF in Präsentation, PDF in PPTX, PDF in PPT, Python, Aspose.Slides für Python über .NET"
description: "Importieren Sie eine PowerPoint-Präsentation aus PDF. Konvertieren Sie PDF in PowerPoint"
---

Mit [**Aspose.Slides für Python über .NET**](https://products.aspose.com/slides/python-net/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides bietet die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) Klasse, um Ihnen das Importieren von Präsentationen aus PDFs, HTML-Dokumenten usw. zu ermöglichen.

## **PowerPoint aus PDF importieren**

In diesem Fall konvertieren Sie eine PDF in eine PowerPoint-Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanziieren Sie ein Objekt der Präsentationsklasse. 
2. Rufen Sie die Methode `add_from_pdf` auf und übergeben Sie die PDF-Datei. 
3. Verwenden Sie die Methode `save`, um die Datei im PowerPoint-Format zu speichern.

Dieser Python-Code demonstriert den PDF zu PowerPoint-Vorgang:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tipp" color="primary" %}} 

Sie sollten die **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Webanwendung ausprobieren, da dies eine Live-Implementierung des hier beschriebenen Prozesses ist. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall konvertieren Sie ein HTML-Dokument in eine PowerPoint-Präsentation.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse. 
2. Rufen Sie die Methode `add_from_html` auf und übergeben Sie die HTML-Datei. 
3. Verwenden Sie die Methode `save`, um die Datei als PowerPoint-Dokument zu speichern.

Dieser Python-Code demonstriert den HTML zu PowerPoint-Vorgang:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Hinweis" color="warning" %}} 

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML in Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}