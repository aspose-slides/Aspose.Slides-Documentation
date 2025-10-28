---
title: PowerPoint-Präsentationen in HTML konvertieren mit Python
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- Python
- Aspose.Slides
description: PowerPoint-Präsentationen in responsives HTML mit Python konvertieren. Layout, Links und Bilder erhalten mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse.
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen in das HTML-Format mit Python konvertiert. Er behandelt die folgenden Themen.

- PowerPoint zu HTML in Python konvertieren
- PPT zu HTML in Python konvertieren
- PPTX zu HTML in Python konvertieren
- ODP zu HTML in Python konvertieren
- PowerPoint-Folie zu HTML in Python konvertieren

## **Python PowerPoint zu HTML**

Für Beispielcode in Python zum Konvertieren von PowerPoint zu HTML siehe den folgenden Abschnitt, d. h. [PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und als HTML speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**. 

**Aspose.Slides** bietet viele Optionen (meist aus der [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) Klasse), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Pr⟩äsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei die Sprecher‑Notizen ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Kommentare ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, mit Original‑ oder eingebetteten Schriftarten.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei der neue CSS‑Stil verwendet wird.

{{% alert color="primary" %}} 

Mittels eigener API hat Aspose kostenlose [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides folgende HTML‑bezogene Vorgänge: 

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine komplette PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie man ein PowerPoint in Python zu HTML konvertiert:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint zu Responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in Python zu responsive HTML konvertiert:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie man ein PowerPoint in Python zu HTML mit Notizen konvertiert:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint zu HTML mit Originalschriftarten konvertieren**
Aspose.Slides bietet die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) an, mit der Sie alle Schriftarten einer Präsentation einbetten können, während Sie die Präsentation zu HTML konvertieren.

Um das Einbetten bestimmter Schriftarten zu verhindern, können Sie dem parametrierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) ein Array von Schriftartnamen übergeben. Häufig genutzte Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme sie bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) unterstützt Vererbung und stellt die Methode `WriteFont` zur Verfügung, die überschrieben werden soll. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Folie zu HTML konvertieren**
Eine einzelne Präsentationsfolie zu HTML konvertieren. Verwenden Sie dafür dieselbe [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die auch zum Konvertieren der gesamten PPT(X)-Präsentation in ein HTML‑Dokument genutzt wird. Die Klasse [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) kann ebenfalls verwendet werden, um zusätzliche Konvertierungsoptionen zu setzen:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **CSS und Bilder beim Export nach HTML speichern**
Durch neue CSS‑Stildateien können Sie das Aussehen der HTML‑Datei, die aus der PowerPoint‑zu‑HTML‑Konvertierung entsteht, leicht ändern. 

Der Python‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation zu HTML**
Falls Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu reduzieren), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren. 

Dieser Python‑Code zeigt, wie man ein PowerPoint zu HTML konvertiert, während alle Schriftarten verlinkt und „Calibri“ sowie „Arial“ (da sie bereits im System vorhanden sind) ausgeschlossen werden:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Unterstützung der SVG‑Responsive‑Eigenschaft**
Der nachfolgende Code demonstriert, wie man eine PPT(X)-Präsentation mit Responsive‑Layout zu HTML exportiert:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Mediendateien in HTML-Datei exportieren**
Mit Aspose.Slides für Python können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie eine Referenz zur Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser Python‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:

```py
import aspose.slides as slides

# Loading a presentation
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## Häufig gestellte Fragen

### **Wie kann ich eine PowerPoint‑Präsentation mit Python zu HTML konvertieren?**

Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und sie mittels der `save()`‑Methode mit `SaveFormat.HTML` in HTML zu konvertieren.

### **Unterstützt Aspose.Slides das Konvertieren einzelner PowerPoint‑Folien zu HTML?**

Ja, Aspose.Slides ermöglicht das Konvertieren sowohl der gesamten Präsentation als auch einzelner Folien zu HTML, indem `HtmlOptions` entsprechend konfiguriert werden.

### **Kann ich responsives HTML aus PowerPoint‑Präsentationen erzeugen?**

Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

### **Ist es möglich, Sprecher‑Notizen oder Kommentare in das exportierte HTML aufzunehmen?**

Ja, Sie können `HtmlOptions` so konfigurieren, dass Sprecher‑Notizen und Kommentare ein‑ oder ausgeschlossen werden.

### **Kann ich Schriftarten beim Konvertieren einer Präsentation zu HTML einbetten?**

Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriftarten einbetten oder bestimmte Schriftarten ausschließen können, um die Dateigröße zu reduzieren.

### **Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediadateien wie Videos und Audio?**

Ja, Aspose.Slides ermöglicht das Exportieren von in Folien eingebetteten Medieninhalten zu HTML mittels `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

### **Welche Dateiformate werden für die Konvertierung zu HTML unterstützt?**

Aspose.Slides unterstützt die Konvertierung der Formate PPT, PPTX und ODP zu HTML. Zudem können Sie Folieninhalte als SVG speichern und Mediendateien exportieren.

### **Kann ich das Einbetten von Schriftarten vermeiden, um die HTML‑Ausgabedatei zu verkleinern?**

Ja, Sie können gängige Systemschriftarten wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine benutzerdefinierte Implementierung des `HtmlController` verwenden.

### **Gibt es ein Online‑Tool zum Konvertieren von PowerPoint zu HTML?**

Ja, Sie können Asposes kostenlose Web‑Tools wie [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html) nutzen, um Präsentationen direkt im Browser zu konvertieren, ohne Code zu schreiben.

### **Kann ich benutzerdefinierte CSS‑Stile in der exportierten HTML‑Datei verwenden?**

Ja, Aspose.Slides erlaubt das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Erscheinungsbild des resultierenden HTML‑Inhalts vollständig anpassen können.