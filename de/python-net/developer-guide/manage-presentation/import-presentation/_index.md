---
title: Präsentationen mit Python importieren
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/python-net/developer-guide/manage-presentation/import-presentation/
keywords:
- PowerPoint importieren
- Präsentation importieren
- Folie importieren
- PDF zu Präsentation
- PDF zu PPT
- PDF zu PPTX
- PDF zu ODP
- HTML zu Präsentation
- HTML zu PPT
- HTML zu PPTX
- HTML zu ODP
- Python
- Aspose.Slides
description: "Mühelos PDF- und HTML-Dokumente in PowerPoint- und OpenDocument-Präsentationen in Python mit Aspose.Slides importieren für nahtlose, leistungsstarke Folienverarbeitung."
---

## **Überblick**

Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) können Sie Inhalte aus anderen Dateiformaten in eine Präsentation importieren. Die Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bietet Methoden zum Importieren von Folien aus PDF, HTML und anderen Quellen.

## **PDF in eine Präsentation konvertieren**

Dieser Abschnitt zeigt, wie Sie ein PDF mithilfe von Aspose.Slides in eine Präsentation konvertieren. Er führt Sie durch das Importieren des PDFs, das Umwandeln seiner Seiten in Folien und das Speichern des Ergebnisses als PPTX-Datei.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie die Methode [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die Methode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), um die Präsentation im PowerPoint-Format zu speichern.

Das folgende Python‑Beispiel demonstriert die Konvertierung eines PDFs in eine Präsentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tipp" color="primary" %}}

Vielleicht möchten Sie die **kostenlose** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)‑Web‑App von Aspose ausprobieren – sie ist eine Live‑Implementierung des hier beschriebenen Prozesses.

{{% /alert %}}

## **HTML in eine Präsentation konvertieren**

Dieser Abschnitt zeigt, wie Sie HTML-Inhalte mithilfe von Aspose.Slides in eine Präsentation importieren. Er behandelt das Laden des HTML, die Umwandlung in Folien mit erhaltenem Text, Bildern und Grundformatierung und das Speichern des Ergebnisses als PPTX-Datei.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie die Methode [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) auf und übergeben Sie die HTML‑Datei.
3. Verwenden Sie die Methode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), um die Präsentation im PowerPoint-Format zu speichern.

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

**Werden Tabellen beim Importieren eines PDFs beibehalten und kann deren Erkennung verbessert werden?**

Tabellen können beim Import erkannt werden; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) enthält einen Parameter [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/), der die Tabellenerkennung aktiviert. Die Wirksamkeit hängt von der Struktur des PDFs ab.

{{% alert title="Hinweis" color="info" %}}

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren:

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}