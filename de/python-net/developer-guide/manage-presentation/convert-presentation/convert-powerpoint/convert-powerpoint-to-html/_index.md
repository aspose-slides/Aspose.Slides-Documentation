---
title: PowerPoint Präsentationen in HTML mit Python konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
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
description: "PowerPoint‑Präsentationen in responsives HTML mit Python konvertieren. Layout, Links und Bilder mit dem Aspose.Slides‑Konvertierungsguide bewahren – schnell und fehlerfrei."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Python in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint zu HTML in Python konvertieren
- PPT zu HTML in Python konvertieren
- PPTX zu HTML in Python konvertieren
- ODP zu HTML in Python konvertieren
- PowerPoint‑Folien zu HTML in Python konvertieren

## **Python PowerPoint zu HTML**

Für Beispielcode in Python zur Konvertierung von PowerPoint zu HTML siehe bitte den untenstehenden Abschnitt, z. B. [PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP in ein Presentation‑Objekt laden und es im HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess festlegen:

* Eine gesamte PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Sprecher‑Notizen ein- oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Kommentare ein- oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, mit Original‑ oder eingebetteten Schriftarten.
* Eine PowerPoint‑Präsentation in HTML konvertieren und dabei den neuen CSS‑Stil verwenden.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose frei verfügbare [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich auch die anderen [kostenlosen Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch die folgenden Vorgänge mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation folgendermaßen in HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in Python zu HTML konvertieren:

```python
import aspose.slides as slides

# Instanziiert ein Presentation‑Objekt, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichert die Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint zu Responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsive HTML mit Python konvertieren:

```py
# Instanziiert ein Presentation‑Objekt, das eine Präsentationsdatei repräsentiert
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichert die Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in Python mit Notizen in HTML konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint zu HTML mit Original‑Schriftarten konvertieren**
Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) bereit, mit der Sie beim Konvertieren einer Präsentation in HTML alle Schriftarten einbetten können.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController] ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen bei einer Präsentation nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Werden diese Schriftarten dennoch eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController] unterstützt Vererbung und stellt die Methode `WriteFont` bereit, die überschrieben werden soll. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standard‑Präsentationsschriftarten ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Folie zu HTML konvertieren**
Eine einzelne Präsentationsfolie in HTML konvertieren. Verwenden Sie dafür dieselbe [**Save**]-Methode der [Presentation]-Klasse, die zum Konvertieren der gesamten PPT(X)-Präsentation in ein HTML‑Dokument verwendet wird. Die [**HtmlOptions**]-Klasse kann ebenfalls zum Festlegen zusätzlicher Konvertierungsoptionen verwendet werden:

```py
# [TODO[not_supported_yet]: Python-Implementierung der .net-Schnittstelle]
```

## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Aussehen der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess resultierenden HTML‑Datei leicht ändern.  

Der Python‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:

```py
# [TODO[not_supported_yet]: Python-Implementierung der .net‑Schnittstellen]
```

## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation zu HTML**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu verringern), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Version implementieren.  

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation zu HTML konvertieren, dabei alle Schriftarten verlinken und „Calibri“ sowie „Arial“ ausschließen (da sie bereits im System vorhanden sind): 

```py
# [TODO[not_supported_yet]: Python-Implementierung der .net‑Schnittstellen]
```

## **Unterstützung der SVG‑Responsive‑Eigenschaft**
Das nachstehende Code‑Beispiel zeigt, wie man eine PPT(X)-Präsentation mit responsive Layout nach HTML exportiert:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides für Python können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation].
2. Holen Sie sich eine Referenz zur Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser Python‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und sie anschließend als HTML speichern:

```py
import aspose.slides as slides

# Laden einer Präsentation
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
Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und sie mit der Methode `save()` und `SaveFormat.HTML` in HTML zu konvertieren.

### **Unterstützt Aspose.Slides die Konvertierung einzelner PowerPoint‑Folien zu HTML?**
Ja, Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einzelner Folien zu HTML, indem `HtmlOptions` entsprechend konfiguriert werden.

### **Kann ich aus PowerPoint‑Präsentationen responsives HTML erzeugen?**
Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

### **Ist es möglich, Sprecher‑Notizen oder Kommentare in das exportierte HTML einzubeziehen?**
Ja, Sie können `HtmlOptions` so konfigurieren, dass Sprecher‑Notizen und Kommentare beim Export von PowerPoint‑Präsentationen nach HTML ein- oder ausgeschlossen werden.

### **Kann ich Schriftarten einbetten, wenn ich eine Präsentation zu HTML konvertiere?**
Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriftarten einbetten oder bestimmte Schriftarten ausschließen können, um die Dateigröße zu reduzieren.

### **Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediendateien wie Videos und Audio?**
Ja, Aspose.Slides ermöglicht den Export von in Folien eingebetteten Medieninhalten nach HTML mittels `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

### **Welche Dateiformate werden für die Konvertierung zu HTML unterstützt?**
Aspose.Slides unterstützt die Konvertierung der Präsentationsformate PPT, PPTX und ODP nach HTML. Außerdem können Folieninhalte als SVG gespeichert und Medien‑Assets exportiert werden.

### **Kann ich das Einbetten von Schriftarten vermeiden, um die HTML‑Ausgabengröße zu reduzieren?**
Ja, Sie können gängige Systemschriftarten wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine benutzerdefinierte Implementierung des `HtmlController` verwenden.

### **Gibt es ein Online‑Tool, um PowerPoint zu HTML zu konvertieren?**
Ja, Sie können Asposes kostenlose Web‑Tools wie [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html) nutzen, um Präsentationen direkt im Browser zu konvertieren, ohne Code zu schreiben.

### **Kann ich benutzerdefinierte CSS‑Stile im exportierten HTML‑File verwenden?**
Ja, Aspose.Slides ermöglicht das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Erscheinungsbild des resultierenden HTML‑Inhalts vollständig anpassen können.