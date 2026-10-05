---
title: PPT & PPTX in PDF in Python konvertieren | Erweiterte Optionen
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation
- PowerPoint zu PDF
- PPT zu PDF
- PPTX zu PDF
- PowerPoint als PDF speichern
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Schritt-für-Schritt-Anleitung zum Konvertieren von PPT, PPTX und ODP in hochwertige, WCAG-konforme PDFs in Python mit Aspose.Slides — beinhaltet Passwortschutz, Folienauswahl und Bildqualitätskontrolle."
showReadingTime: true
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Sicherstellung der Kompatibilität auf verschiedenen Geräten und das Erhalten von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität genutzt werden, versteckte Folien einbezogen, PDF‑Dokumente passwortgeschützt werden, Schriftart‑Ersetzungen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python in PDF zu konvertieren, übergeben Sie einfach den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und speichern die Präsentation anschließend als PDF mit einer [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) Methode. Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse stellt die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides für Python beim Konvertieren einer Präsentation in PDF das Feld Application mit dem Wert '*Aspose.Slides*' und das Feld PDF Producer mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für Python nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Komplette Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass der Inhalt der resultierenden PDFs dem Original sehr nahekommt. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exporteinstellungen als PDF.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint-zu-PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Konvertierungsprozess demonstriert. Für eine Live‑Implementierung der hier beschriebenen Vorgehensweise können Sie den Konverter testen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) Klasse — zur Verfügung, mit denen Sie das Ergebnis‑PDF anpassen, mit einem Passwort schützen oder den Ablauf der Konvertierung festlegen können.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Raster‑Bilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, DPI für Bilder festlegen usw.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie vielleicht, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien ansehen können. Setzen Sie [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) auf `True`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `False`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei ist nicht als Anhang enthalten. Durch Setzen der Option auf `True` werden zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie als PDF mit der Arbeitsmappe als Anhang.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine Beschränkungen, die speziell für Aspose.Slides gelten. Dieses Beispiel verwendet die standardmäßige PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die benutzerdefinierte Option — die Eigenschaft [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) der [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) Klasse — verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich Druck in hoher Qualität.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation in PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Quell‑Präsentation muss mindestens drei Folien enthalten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird nach PDF exportiert.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Entferne die leere Folie, mit der die neue Präsentation erstellt wurde.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint zu PDF im Notizfolien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation in PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht Ihnen die Verwendung eines Konvertierungsverfahrens, das den [Richtlinien für barrierefreie Webinhalte (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Konformitätsstandards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erzeugt werden:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
Der Aspose.Slides‑Support für PDF‑Konvertierungen ermöglicht Ihnen, PDFs in die gängigsten Dateiformate zu konvertieren. Sie können [PDF zu HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF zu image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere Spezial‑Konvertierungen — [PDF zu SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), [PDF zu XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das ausgegebene PDF ein. Diese Informationen können nicht geändert oder entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die Folienindizes, die Sie konvertieren möchten, angeben, indem Sie ein Array von Folienpositionen an die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑Methode übergeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können vor dem Speichern der Präsentation als PDF ein Passwort festlegen und Zugriffsrechte über die [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)‑Klasse definieren.

**Unterstützt Aspose.Slides die Konvertierung von PDFs in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie kann ich sicherstellen, dass mein PDF den Barrierefreiheitsstandards entspricht?**

Setzen Sie die [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/)‑Eigenschaft in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Einhaltung der Barrierefreiheitsrichtlinien sicherzustellen.

**Kann ich versteckte Folien in die PDF‑Ausgabe einbeziehen?**

Ja, indem Sie die [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)‑Eigenschaft in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf `True` setzen, werden versteckte Folien im PDF enthalten sein.

**Wie stelle ich die Bildqualität und Auflösung während der Konvertierung ein?**

Verwenden Sie die [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)‑ und [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)‑Eigenschaften in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Handhabt Aspose.Slides die Schriftartersetzungen automatisch?**

Aspose.Slides erkennt Schriftart‑Ersetzungen während der Konvertierung, und Sie können sie über die `warning_callback`‑Eigenschaft in `SaveOptions` (derzeit eingeschränkt) verarbeiten.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Python via .NET Dokumentation](/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/python-net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)