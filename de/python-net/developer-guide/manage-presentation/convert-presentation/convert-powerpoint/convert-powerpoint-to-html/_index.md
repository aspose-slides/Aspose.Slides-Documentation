---
title: PowerPoint-Präsentationen in HTML mit Python konvertieren
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
description: "PowerPoint-Präsentationen in responsives HTML mit Python konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse erhalten."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie PowerPoint‑Präsentationen mit Python in das HTML‑Format konvertieren. Er behandelt die folgenden Themen.

- PowerPoint nach HTML in Python konvertieren
- PPT nach HTML in Python konvertieren
- PPTX nach HTML in Python konvertieren
- ODP nach HTML in Python konvertieren
- PowerPoint‑Folien nach HTML in Python konvertieren

## **Python PowerPoint nach HTML**

Für Beispielcode in Python zum Konvertieren von PowerPoint nach HTML siehe den untenstehenden Abschnitt, d. h. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP in ein Presentation‑Objekt laden und es im HTML‑Format speichern.

## **Über PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX nach HTML** oder **PPT nach HTML**. 

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine gesamte PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit eingebetteten oder ausgeschlossenen Sprecher­notizen konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit eingebetteten oder ausgeschlossenen Kommentaren konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit originalen oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren und dabei den neuen CSS‑Stil verwenden.

{{% alert color="primary" %}} 

Mit ihrer eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT nach HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX nach HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP nach HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch folgende Konvertierungsoperationen im HTML‑Format: 

* [HTML nach Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML nach JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML nach XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML nach TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint nach HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie ein PowerPoint in Python in HTML konvertieren:
```python
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichern der Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **PowerPoint nach Responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in Python in responsive HTML konvertieren:
```py
# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichern der Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **PowerPoint nach HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie ein PowerPoint in Python mit Notizen in HTML konvertieren:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **PowerPoint nach HTML mit Originalschriftarten konvertieren**
Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) bereit, mit der Sie beim Konvertieren einer Präsentation nach HTML alle Schriftarten einbetten können.

Um das Einbetten bestimmter Schriftarten zu verhindern, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) ein Array von Schriftartnamen übergeben. Populäre Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, wenn sie in einer Präsentation verwendet werden, da die meisten Systeme diese bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) unterstützt Vererbung und stellt die Methode `WriteFont` bereit, die überschrieben werden kann. 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standard-Schriftarten der Präsentation ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **Folien nach HTML konvertieren**
Konvertieren Sie eine einzelne Präsentationsfolie nach HTML. Verwenden Sie dafür dieselbe [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse bereitgestellt wird und zum Konvertieren der gesamten PPT(X)‑Präsentation in ein HTML‑Dokument verwendet wird. Die [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)‑Klasse kann ebenfalls verwendet werden, um zusätzliche Konvertierungsoptionen festzulegen:
```py
# [TODO[not_supported_yet]: python-Implementierung der .net-Schnittstelle]
```


## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Aussehen der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess resultierenden HTML‑Datei einfach ändern.

Der Python‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument mit einem Verweis auf eine CSS‑Datei zu erstellen:
```py
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


## **Alle Schriftarten beim Konvertieren einer Präsentation nach HTML verlinken**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu reduzieren), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Version implementieren.

Dieser Python‑Code zeigt, wie Sie ein PowerPoint nach HTML konvertieren, wobei alle Schriftarten verlinkt und „Calibri“ sowie „Arial“ (da sie bereits im System vorhanden sind) ausgeschlossen werden:
```py
# [TODO[not_supported_yet]: Python-Implementierung von .NET-Schnittstellen]
```


## **Unterstützung der SVG‑Responsive‑Eigenschaft**
Das nachstehende Codebeispiel zeigt, wie Sie eine PPT(X)-Präsentation mit responsivem Layout nach HTML exportieren:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides für Python können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich eine Referenz auf die Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser Python‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und dann als HTML speichern:
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


## **FAQ**

**Wie kann ich eine PowerPoint‑Präsentation mit Python in HTML konvertieren?**

Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und sie mit der Methode `save()` und dem Parameter `SaveFormat.HTML` in HTML zu konvertieren.

**Unterstützt Aspose.Slides das Konvertieren einzelner PowerPoint‑Folien nach HTML?**

Ja, Aspose.Slides ermöglicht das Konvertieren der gesamten Präsentation oder einzelner Folien nach HTML, indem `HtmlOptions` entsprechend konfiguriert werden.

**Kann ich aus PowerPoint‑Präsentationen responsives HTML erzeugen?**

Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

**Ist es möglich, Sprecher­notizen oder Kommentare in das exportierte HTML einzubeziehen?**

Ja, Sie können `HtmlOptions` so konfigurieren, dass Sprecher­notizen und Kommentare beim Export von PowerPoint‑Präsentationen nach HTML ein- oder ausgeschlossen werden.

**Kann ich Schriftarten beim Konvertieren einer Präsentation nach HTML einbetten?**

Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriftarten einbetten oder bestimmte Schriftarten ausschließen können, um die Dateigröße zu reduzieren.

**Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediendateien wie Videos und Audio?**

Ja, Aspose.Slides ermöglicht den Export von in Folien eingebetteten Medieninhalten nach HTML mithilfe von `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

**Welche Dateiformate werden für die Konvertierung nach HTML unterstützt?**

Aspose.Slides unterstützt die Konvertierung der Präsentationsformate PPT, PPTX und ODP nach HTML. Außerdem können Sie Folieninhalte als SVG speichern und Medien‑Assets exportieren.

**Kann ich das Einbetten von Schriftarten vermeiden, um die HTML‑Ausgabgröße zu reduzieren?**

Ja, Sie können gängige Systemschriftarten wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine benutzerdefinierte Implementierung des `HtmlController` verwenden.

**Gibt es ein Online‑Tool zum Konvertieren von PowerPoint nach HTML?**

Ja, Sie können Asposes kostenlose Web‑Tools wie [PPT nach HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX nach HTML](https://products.aspose.app/slides/conversion/pptx-to-html) ausprobieren, um Präsentationen direkt im Browser zu konvertieren, ohne Code zu schreiben.

**Kann ich benutzerdefinierte CSS‑Stile in der exportierten HTML‑Datei verwenden?**

Ja, Aspose.Slides ermöglicht das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Erscheinungsbild des resultierenden HTML‑Inhalts vollständig anpassen können.