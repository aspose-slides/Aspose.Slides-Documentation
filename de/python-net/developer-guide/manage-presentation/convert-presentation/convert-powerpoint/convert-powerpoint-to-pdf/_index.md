---
title: PPT & PPTX zu PDF in Python | Erweiterte Optionen
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
- Aspose.Slides für Python
description: "Schritt‑für‑Schritt‑Anleitung zum Konvertieren von PPT, PPTX und ODP in hochwertige, WCAG‑konforme PDFs in Python mit Aspose.Slides – beinhaltet Passwortschutz, Folienausswahl und Bildqualitäts‑Kontrolle."
showReadingTime: true
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität auf verschiedenen Geräten und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Kontrolle der Bildqualität nutzen, versteckte Folien einbeziehen, PDF‑Dokumente mit einem Passwort schützen, Schriftart‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Konformitätsstandards auf Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python in PDF zu konvertieren, müssen Sie lediglich den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse übergeben und die Präsentation dann mit einer [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑Methode als PDF speichern. Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise verwendet wird, um eine Präsentation in PDF zu konvertieren.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides für Python beim Konvertieren einer Präsentation in PDF das Feld **Application** mit dem Wert '*Aspose.Slides*' und das Feld **PDF Producer** mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für Python nicht anweisen, diese Informationen in Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen, folgendes zu konvertieren:

* Gesamte Präsentationen nach PDF
* Bestimmte Folien einer Präsentation nach PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass der Inhalt der resultierenden PDFs dem Original sehr nahe kommt. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchstmöglicher Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mithilfe der Standard‑Exporteinstellungen als PDF.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint zu PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentations‑zu‑PDF‑Konvertierungsprozess demonstriert. Für eine Live‑Umsetzung des hier beschriebenen Verfahrens können Sie den Konverter testen.
{{% /alert %}}

## **PowerPoint mit Optionen in PDF konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) – die es Ihnen ermöglichen, das PDF (das aus dem Konvertierungsprozess entsteht) anzupassen, das PDF mit einem Passwort zu schützen oder sogar den Ablauf des Konvertierungsprozesses zu steuern.

### **PowerPoint mit benutzerdefinierten Optionen in PDF konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Text setzen, die DPI für Bilder festlegen usw.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkompression.

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

### **Eingebettete OLE‑Dateien als PDF‑Anhänge beibehalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten der Arbeitsmappe als auch auf die Folien zugreifen können. Setzen Sie [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) auf `True`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF beizubehalten.

Der Standardwert ist `False`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang einbezogen. Durch Setzen der Option auf `True` wird zusätzlich die Dateidaten eingebunden. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie nach PDF mit angehängter Arbeitsmappe.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und finden Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Einschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge und PDF/A‑3 gestattet andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Vorgaben der Standards, keine spezifischen Beschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint mit versteckten Folien in PDF konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie eine benutzerdefinierte Option – die Eigenschaft [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) – verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten in das resultierende PDF einzubeziehen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle versteckten Folien ein.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` benötigt. Die Zugriffsrechte erlauben das Drucken, einschließlich Druck in hoher Qualität.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Umgang mit Schriftarten ohne eigene fette Schriftart**

Eine Präsentation kann fettes Format auf Text anwenden, selbst wenn die Schriftart keine eigene fette Variante besitzt. Der Text kann dennoch durch synthetisches Fett werden, das die regulären Glyphen künstlich verdickt. Wenn dieser Text im PDF zu schwer wirkt oder von der gewünschten Darstellung abweicht, versuchen Sie, [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) auf `True` zu setzen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Erscheinungsbild für bestimmte Schriftarten verbessern. Der Standardwert ist `False`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines, bei dem auf derselben Schriftart, die keine eigene fette Variante hat, fette Formatierung angewendet wurde. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstil‑Eigenschaften und exportiert sie nach PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Die folgenden Vorschaubilder zeigen die Ausgabe bei deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`False`, der Standard) | Option aktiviert (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text in eine Bitmap umgewandelt wird: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keine eigene fette Variante hat. [Font substitution](/slides/de/python-net/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die ursprüngliche nicht verfügbar ist.

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabedatei muss mindestens drei Folien enthalten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint mit benutzerdefinierter Foliengröße in PDF konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkt (8,5 × 11 Zoll). Es skaliert den Folieninhalt passend und exportiert die einzelne Folie nach PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Entferne die leere Folie, die beim Erstellen der neuen Präsentation hinzugefügt wurde.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF im Notizfolien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren unter Verwendung der folgenden Konformitätsstandards: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs basierend auf verschiedenen Konformitätsstandards erzeugt werden:

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
Aspose.Slides Unterstützung für PDF‑Konvertierungsoperationen ermöglicht es Ihnen, PDF in die gängigsten Dateiformate zu konvertieren. Sie können [PDF zu HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen in Spezialformate – [PDF zu SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als ein einzelnes Objekt. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für das gesamte Objekt bereitgestellt.

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das Ausgabepdf ein. Diese Informationen können nicht geändert oder entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die Folienindizes, die Sie konvertieren möchten, angeben, indem Sie ein Array von Folienpositionen an die [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑Methode übergeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können ein Passwort festlegen und Zugriffsrechte definieren, indem Sie vor dem Speichern der Präsentation als PDF die Klasse [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) verwenden.

**Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie kann ich sicherstellen, dass mein PDF den Barrierefreiheitsstandards entspricht?**

Setzen Sie die Eigenschaft [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Konformität mit den Barrierefreiheitsrichtlinien sicherzustellen.

**Kann ich versteckte Folien in die PDF‑Ausgabe einbeziehen?**

Ja, indem Sie die Eigenschaft [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf `True` setzen, werden versteckte Folien in das PDF aufgenommen.

**Wie kann ich die Bildqualität und Auflösung während der Konvertierung anpassen?**

Verwenden Sie die Eigenschaften [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) und [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Handhabt Aspose.Slides Schriftart‑Ersetzungen automatisch?**

Aspose.Slides erkennt während der Konvertierung Schriftart‑Ersetzungen und Sie können diese über die Eigenschaft `warning_callback` in `SaveOptions` (derzeit eingeschränkt) handhaben.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Python via .NET Dokumentation](/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/python-net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)