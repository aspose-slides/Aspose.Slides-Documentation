---
title: Convert PowerPoint Presentations to HTML in Python
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- Python
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML in Python konvertieren. Layout, Links und Bilder erhalten mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse."
---

## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint-Präsentationen mit Python in das HTML-Format konvertiert werden. Er behandelt die folgenden Themen.

- PowerPoint in HTML mit Python konvertieren
- PPT in HTML mit Python konvertieren
- PPTX in HTML mit Python konvertieren
- ODP in HTML mit Python konvertieren
- PowerPoint-Folie in HTML mit Python konvertieren

## **Python PowerPoint zu HTML**

Für Python‑Beispielcode zur Konvertierung von PowerPoint zu HTML siehe den Abschnitt unten, d. h. [PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und in HTML speichern.


## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess bestimmen:

* Eine gesamte PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Sprecher‑Notizen konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Kommentare konvertieren. 
* Eine PowerPoint‑Präsentation in HTML mit Original‑ oder eingebetteten Schriften konvertieren. 
* Eine PowerPoint‑Präsentation in HTML konvertieren, während der neue CSS‑Stil verwendet wird. 

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Weitere kostenlose Konverter von Aspose finden Sie [hier](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Vorgänge mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), um das Objekt als HTML‑Datei zu speichern.

Der folgende Code zeigt, wie Sie in Python ein PowerPoint‑Dokument in HTML konvertieren:

```python
import aspose.slides as slides

# Instanziiert ein Presentation‑Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichert die Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint zu responsivem HTML konvertieren**

Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) zur Verfügung, mit der responsiven HTML‑Dateien erzeugt werden können. Der folgende Code zeigt, wie Sie in Python eine PowerPoint‑Präsentation in responsives HTML konvertieren:

```py
# Instanziiert ein Presentation‑Objekt, das eine Präsentationsdatei darstellt
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichert die Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint zu HTML mit Notizen konvertieren**
Der folgende Code zeigt, wie Sie in Python ein PowerPoint‑Dokument mit Notizen in HTML konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint zu HTML mit Original‑Schriften konvertieren**
Aspose.Slides bietet die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) an, mit der Sie beim Konvertieren einer Präsentation zu HTML alle Schriften einbetten können.

Um bestimmte Schriften vom Einbetten auszuschließen, können Sie dem parametrierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) ein Array von Schriftartnamen übergeben. Häufig genutzte Schriften wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Wenn diese Schriften dennoch eingebettet werden, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) unterstützt Vererbung und stellt die Methode `WriteFont` bereit, die überschrieben werden kann. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standard‑Präsentationsschriften ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Folie zu HTML konvertieren**
Eine einzelne Präsentationsfolie zu HTML konvertieren. Verwenden Sie dafür dieselbe [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Methode, die von der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bereitgestellt wird und die zum Konvertieren der gesamten PPT(X)-Präsentation in ein HTML‑Dokument verwendet wird. Die Klasse [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) kann ebenfalls benutzt werden, um zusätzliche Konvertierungsoptionen festzulegen:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Aussehen der HTML‑Datei, die aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess entsteht, leicht ändern.

Der Python‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Verweis auf eine CSS‑Datei zu erstellen:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Alle Schriften verlinken, wenn die Präsentation nach HTML konvertiert wird**
Wenn Sie Schriften nicht einbetten möchten (um die Größe der resultierenden HTML‑Datei zu reduzieren), können Sie alle Schriften verlinken, indem Sie Ihre eigene Variante des `LinkAllFontsHtmlController` implementieren.

Dieser Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument zu HTML konvertieren, dabei alle Schriften verlinken und „Calibri“ sowie „Arial“ ausschließen (da diese bereits im System vorhanden sind):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Unterstützung der SVG‑Responsive‑Eigenschaft**
Das folgende Beispiel zeigt, wie Sie eine PPT(X)-Präsentation mit responsive Layout‑Option ins HTML exportieren:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Mediendateien in HTML‑Datei exportieren**
Mit Aspose.Slides für Python können Sie Mediendateien wie folgt exportieren:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf die Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Der folgende Python‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:

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

### **Wie kann ich eine PowerPoint‑Präsentation mit Python in HTML konvertieren?**

Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und mit der `save()`‑Methode und `SaveFormat.HTML` in HTML zu konvertieren.

### **Unterstützt Aspose.Slides die Konvertierung einzelner PowerPoint‑Folien in HTML?**

Ja, Aspose.Slides ermöglicht sowohl die Konvertierung der gesamten Präsentation als auch einzelner Folien nach HTML, indem die `HtmlOptions` entsprechend konfiguriert werden.

### **Kann ich aus PowerPoint‑Präsentationen responsives HTML erzeugen?**

Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

### **Ist es möglich, Sprecher‑Notizen oder Kommentare in das exportierte HTML einzuschließen?**

Ja, Sie können die `HtmlOptions` so einstellen, dass Sprecher‑Notizen und Kommentare ein‑ oder ausgeschlossen werden, wenn Sie PowerPoint‑Präsentationen nach HTML exportieren.

### **Kann ich Schriften beim Konvertieren einer Präsentation nach HTML einbetten?**

Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriften einbetten oder bestimmte Schriften ausschließen können, um die Ausgabedateigröße zu reduzieren.

### **Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediendateien wie Videos und Audios?**

Ja, Aspose.Slides ermöglicht den Export von in Folien eingebetteten Medieninhalten nach HTML mithilfe von `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

### **Welche Dateiformate werden für die Konvertierung nach HTML unterstützt?**

Aspose.Slides unterstützt die Konvertierung der Präsentationsformate PPT, PPTX und ODP nach HTML. Zudem können Sie Folieninhalte als SVG speichern und Medienassets exportieren.

### **Kann ich das Einbetten von Schriften vermeiden, um die HTML‑Ausgabedatei zu verkleinern?**

Ja, Sie können gängige Systemschriften wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine benutzerdefinierte Implementierung des `HtmlController` verwenden.

### **Gibt es ein Online‑Tool, um PowerPoint nach HTML zu konvertieren?**

Ja, Sie können Asposes kostenlose Web‑Tools wie [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html) nutzen, um Präsentationen direkt im Browser zu konvertieren, ohne Code schreiben zu müssen.

### **Kann ich benutzerdefinierte CSS‑Stile in der exportierten HTML‑Datei verwenden?**

Ja, Aspose.Slides ermöglicht das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Aussehen des resultierenden HTML‑Inhalts vollständig anpassen können.