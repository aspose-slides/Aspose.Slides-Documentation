---
title: PPT & PPTX in PDF konvertieren in Python | Erweiterte Optionen
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
description: "Schritt-für-Schritt-Anleitung zum Konvertieren von PPT, PPTX und ODP in hochwertige, WCAG-konforme PDFs in Python mit Aspose.Slides - enthält Passwortschutz, Folienauswahl und Bildqualitätskontrolle."
showReadingTime: true
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität auf verschiedenen Geräten und das Beibehalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, wie versteckte Folien einbezogen, PDFs mit Passwort geschützt, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation mit Python in PDF zu konvertieren, übergeben Sie einfach den Dateinamen als Argument an die [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit der [speichern](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-Methode als PDF. Die [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse stellt die [speichern](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides für Python fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides für Python beim Konvertieren einer Präsentation in PDF das Feld *Application* mit dem Wert „*Aspose.Slides*“ und das Feld *PDF Producer* mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides für Python nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren:

* Ganzer Präsentationen in PDF
* Bestimmter Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die Inhalte der resultierenden PDFs dem ursprünglichen Präsentationsinhalt eng entsprechen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die übergebene Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exportoptionen als PDF.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Für eine Live‑Implementierung des hier beschriebenen Vorgehens können Sie den Konverter testen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)-Klasse – bereit, mit denen Sie das PDF (das aus dem Konvertierungsprozess entsteht) anpassen, das PDF mit einem Passwort sperren oder sogar festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint mit benutzerdefinierten Optionen in PDF konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Raster‑Bilder festlegen, bestimmen, wie Metadateien behandelt werden, eine Komprimierungsstufe für Text setzen, DPI für Bilder festlegen usw.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkomprimierung.

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

### **Automatische Auswahl der Bildkompression**

Enthält eine Präsentation viele Fotos oder Screenshots, kann das Reduzieren der Größe des exportierten PDFs das Versenden per E‑Mail oder den Download erleichtern. Setzen Sie [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) auf `True`, um während des PDF‑Exports automatisch den am besten geeigneten Kompressionsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Auswahl der Bildkompression und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte bei.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Diese Option wählt für jedes Bild einen Kompressionsalgorithmus aus. Das Senken von [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) reduziert die JPEG‑Bildqualität, während das Senken von [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) es ermöglicht, Bilder auf eine niedrigere Auflösung heruntersampling, was Details reduzieren kann. Das Aktivieren der automatischen Kompressionsauswahl verringert nicht selbst diese Einstellungen.

Das Auswählen von Bildkompressionsalgorithmen erfordert zusätzlichen Verarbeitungs‑ und Speicheraufwand. Die Größenreduktion hängt von den Bildern der Präsentation und den Export‑Einstellungen ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Setzen Sie [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) auf `True`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `False`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, die eingebettete Datei jedoch nicht als Anhang beigefügt. Durch Setzen der Option auf `True` wird zusätzlich die Dateidaten beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie mit der angehängten Arbeitsmappe als PDF.

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

Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsmappen. Das sind Anforderungen der Standards, keine Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint mit versteckten Folien in PDF konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie mit einer benutzerdefinierten Option – der [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)-Eigenschaft der [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)-Klasse – Aspose.Slides anweisen, die versteckten Folien als Seiten im resultierenden PDF aufzunehmen.

Das folgende Beispiel exportiert eine Präsentation nach PDF, einschließlich aller versteckten Folien.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich hochwertigen Drucks.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Umgang mit Schriftarten ohne dedizierten Fettdruck**

Eine Präsentation kann Fettdruck auf Text anwenden, selbst wenn die Schriftart keinen eigenen Fettdruck‑Schriftschnitt besitzt. Der Text kann dann synthetisch fett dargestellt werden, indem die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu stark oder anderweitig von der gewünschten Darstellung abweicht, setzen Sie [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) auf `True`. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen für bestimmte Schriftarten verbessern. Der Standardwert ist `False`.

Die Beispieldatei enthält zwei Textfelder: eines mit normalem Text und eines mit auf dieselbe Schriftart angewendetem Fettdruck, wobei diese Schriftart keinen eigenen Fettdruck‑Schriftschnitt besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterung nicht unterstützter Schriftschnitt‑Stile und exportiert sie nach PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Die nachfolgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option dichtere Striche; bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`False`, Standard) | Option aktiviert (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel wird bei aktivierter Option nur der fette Text in eine Bitmap umgewandelt: Er kann nicht ausgewählt, kopiert oder ohne OCR durchsucht werden, und seine Kanten wirken bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text.

Diese Option rastert Text, der als fett formatiert ist, wenn die Schriftart keinen eigenen Fettdruck‑Schriftschnitt besitzt. [Font substitution](/slides/de/python-net/font-substitution/) wählt stattdessen eine Ersatzschriftart, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien in PowerPoint nach PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folien‑Nummern in diesem Array beginnen bei 1, und die Eingabedatei muss mindestens drei Folien enthalten.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **PowerPoint mit benutzerdefinierter Foliengröße in PDF konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, um zu passen, und exportiert die einzelne Folie nach PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Entfernen Sie die leere Folie, die bei der Erstellung der neuen Präsentation angelegt wurde.
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

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Richtlinien für die Barrierefreiheit von Webinhalten (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt werden:

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

Aspose.Slides‑Unterstützung für PDF‑Konvertierungs‑Operationen ermöglicht Ihnen die Konvertierung von PDF in die gängigsten Dateiformate. Sie können [PDF zu HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungs‑Operationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das ausgegebene PDF ein. Diese Informationen können weder geändert noch entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die Folienindizes, die Sie konvertieren möchten, angeben, indem Sie ein Array mit den Folienpositionen an die [speichern](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-Methode übergeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können ein Passwort festlegen und Zugriffsrechte über die [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)-Klasse definieren, bevor Sie die Präsentation als PDF speichern.

**Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie kann ich sicherstellen, dass mein PDF den Barrierefreiheits‑Standards entspricht?**

Setzen Sie die [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/)-Eigenschaft in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Einhaltung der Barrierefreiheits‑Richtlinien sicherzustellen.

**Kann ich versteckte Folien in die PDF‑Ausgabe aufnehmen?**

Ja, indem Sie die [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)-Eigenschaft in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) auf `True` setzen, werden versteckte Folien im PDF enthalten sein.

**Wie stelle ich Bildqualität und Auflösung während der Konvertierung ein?**

Verwenden Sie die [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)‑ und [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)‑Eigenschaften in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), um Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Erkennt Aspose.Slides Schriftarten‑Ersetzungen automatisch?**

Aspose.Slides erkennt Schriftarten‑Ersetzungen während der Konvertierung und Sie können sie über die `warning_callback`‑Eigenschaft in `SaveOptions` (derzeit eingeschränkt) behandeln.

## **Weitere Ressourcen**

- [Aspose.Slides für Python via .NET Dokumentation](/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/python-net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)