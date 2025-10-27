---
title: Präsentationen mit Python importieren
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/python-net/import-presentation/
keywords:
- import PowerPoint
- import presentation
- import slide
- PDF to presentation
- PDF to PPT
- PDF to PPTX
- PDF to ODP
- HTML to presentation
- HTML to PPT
- HTML to PPTX
- HTML to ODP
- Python
- Aspose.Slides
description: "Importieren Sie mühelos PDF- und HTML-Dokumente in PowerPoint‑ und OpenDocument‑Präsentationen in Python mit Aspose.Slides für eine nahtlose, hochleistungsfähige Folienverarbeitung."
---

## **Übersicht**

Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) können Sie Inhalte aus anderen Dateiformaten in eine Präsentation importieren. Die Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bietet Methoden zum Importieren von Folien aus PDF, HTML und anderen Quellen.

## **PDF in eine Präsentation konvertieren**

Dieser Abschnitt zeigt, wie ein PDF in eine Präsentation konvertiert wird. Er führt Sie durch das Importieren des PDFs, das Umwandeln seiner Seiten in Folien und das Speichern des Ergebnisses als PPTX‑Datei.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie die Methode [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) auf und übergeben Sie die PDF‑Datei.
3. Verwenden Sie die Methode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), um die Präsentation im PowerPoint‑Format zu speichern.

Das folgende Python‑Beispiel demonstriert die Konvertierung eines PDFs in eine Präsentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tipp" color="primary" %}}

Sie können die kostenlose PDF‑zu‑PowerPoint‑Web‑App von Aspose ausprobieren – sie ist eine Live‑Implementierung des hier beschriebenen Vorgangs.

{{% /alert %}}

## **HTML in eine Präsentation konvertieren**

Dieser Abschnitt zeigt, wie HTML‑Inhalte in eine Präsentation importiert werden. Er behandelt das Laden des HTML, das Umwandeln in Folien mit erhaltenem Text, Bildern und Grundformatierung und das Speichern des Ergebnisses als PPTX‑Datei.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie die Methode [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) auf und übergeben Sie die HTML‑Datei.
3. Verwenden Sie die Methode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), um die Präsentation im PowerPoint‑Format zu speichern.

Das folgende Python‑Beispiel demonstriert die Konvertierung von HTML in eine Präsentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Werden Tabellen beim Importieren eines PDFs beibehalten, und kann deren Erkennung verbessert werden?**

Tabellen können während des Imports erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) enthält einen Parameter [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/), der die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.

{{% alert title="Hinweis" color="info" %}}

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren:

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}