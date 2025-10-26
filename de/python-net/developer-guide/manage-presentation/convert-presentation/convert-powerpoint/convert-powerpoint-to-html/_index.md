---
title: PowerPoint-Präsentationen in HTML konvertieren mit Python
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
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
description: "PowerPoint-Präsentationen in responsives HTML mit Python konvertieren. Layout, Links und Bilder erhalten mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie PowerPoint‑Präsentationen mit Python in das HTML‑Format konvertieren. Er behandelt die folgenden Themen.

- PowerPoint zu HTML in Python
- PPT zu HTML in Python
- PPTX zu HTML in Python
- ODP zu HTML in Python
- PowerPoint‑Folie zu HTML in Python

## **Python PowerPoint zu HTML**

Beispielcode in Python zum Konvertieren von PowerPoint zu HTML finden Sie im Abschnitt unten, etwa unter [PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP in ein `Presentation`‑Objekt laden und dieses im HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet zahlreiche Optionen (meist aus der [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export.htmloptions/)-Klasse), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Gesamte PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* PowerPoint‑Präsentation in responsives HTML konvertieren. 
* PowerPoint‑Präsentation in HTML mit oder ohne Sprecher‑Notizen konvertieren. 
* PowerPoint‑Präsentation in HTML mit oder ohne Kommentare konvertieren. 
* PowerPoint‑Präsentation in HTML mit Original‑ oder eingebetteten Schriften konvertieren. 
* PowerPoint‑Präsentation in HTML unter Verwendung des neuen CSS‑Stils konvertieren. 

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)-Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) können Sie ebenfalls ausprobieren. 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides folgende Vorgänge im Zusammenhang mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse  
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Methode, um das Objekt als HTML‑Datei zu speichern.

Der folgende Code zeigt, wie Sie eine PowerPoint‑Datei in Python nach HTML konvertieren:

```python
import aspose.slides as slides

# Instanziieren eines Presentation‑Objekts, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichern der Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint zu Responsive HTML konvertieren**

Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.responsivehtmlcontroller/) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Der folgende Code demonstriert, wie Sie eine PowerPoint‑Präsentation in Python in responsives HTML konvertieren:

```py
# Instanziieren eines Presentation‑Objekts, das eine Präsentationsdatei repräsentiert
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichern der Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint zu HTML mit Notizen konvertieren**
Der folgende Code zeigt, wie Sie eine PowerPoint‑Datei in Python nach HTML mit Notizen konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint zu HTML mit Original‑Schriften konvertieren**
Aspose.Slides bietet die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/), mit der Sie beim Konvertieren einer Präsentation nach HTML alle Schriften einbetten können.

Um bestimmte Schriften vom Einbetten auszuschließen, können Sie dem parametrierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) ein Array von Schriftartnamen übergeben. Beliebte Schriften wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Werden sie trotzdem eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) unterstützt Vererbung und stellt die Methode `WriteFont` bereit, die überschrieben werden kann. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standard-Präsentationsschriften ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Folie zu HTML konvertieren**
Konvertieren Sie eine einzelne Folie einer Präsentation nach HTML. Verwenden Sie dazu dieselbe **Save**‑Methode der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, die zum Exportieren der gesamten PPT(X)-Präsentation in ein HTML‑Dokument dient. Die **HtmlOptions**‑Klasse kann ebenfalls verwendet werden, um zusätzliche Konvertierungsoptionen festzulegen:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **CSS und Bilder beim Export nach HTML speichern**
Mit den neuen CSS‑Stildateien können Sie das Erscheinungsbild der HTML‑Datei, die aus der PowerPoint‑zu‑HTML‑Konvertierung entsteht, leicht anpassen.

Der Python‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erzeugen:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Alle Schriften verlinken beim Konvertieren einer Präsentation nach HTML**
Wenn Sie Schriften nicht einbetten möchten (um die Dateigröße zu reduzieren), können Sie alle Schriften verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Implementierung bereitstellen.

Der folgende Python‑Code demonstriert, wie Sie eine PowerPoint‑Datei in HTML konvertieren und dabei alle Schriften verlinken, wobei „Calibri“ und „Arial“ ausgeschlossen werden (da sie bereits im System vorhanden sind):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Unterstützung der SVG‑Responsive‑Eigenschaft**
Das folgende Beispiel zeigt, wie Sie eine PPT(X)-Präsentation mit responsivem Layout nach HTML exportieren:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Mediendateien in HTML‑Datei exportieren**
Mit Aspose.Slides für Python können Sie Mediendateien folgendermaßen exportieren:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Referenz zur Folie.  
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

### **Wie kann ich eine PowerPoint‑Präsentation mit Python nach HTML konvertieren?**

Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und mit der `save()`‑Methode und `SaveFormat.HTML` nach HTML zu konvertieren.

### **Unterstützt Aspose.Slides das Konvertieren einzelner PowerPoint‑Folien nach HTML?**

Ja, Aspose.Slides ermöglicht das Konvertieren der gesamten Präsentation oder einzelner Folien nach HTML, indem Sie `HtmlOptions` entsprechend konfigurieren.

### **Kann ich aus PowerPoint‑Präsentationen responsives HTML erzeugen?**

Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

### **Ist es möglich, Sprecher‑Notizen oder Kommentare in das exportierte HTML einzubeziehen?**

Ja, Sie können `HtmlOptions` so konfigurieren, dass Sprecher‑Notizen und Kommentare ein‑ oder ausgeschlossen werden.

### **Kann ich Schriften beim Konvertieren einer Präsentation nach HTML einbetten?**

Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriften einbetten oder bestimmte Schriften ausschließen können, um die Dateigröße zu reduzieren.

### **Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediendateien wie Videos und Audios?**

Ja, Aspose.Slides ermöglicht das Exportieren von in Folien eingebetteten Mediendateien nach HTML mithilfe von `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

### **Welche Dateiformate werden für die Konvertierung nach HTML unterstützt?**

Aspose.Slides unterstützt die Konvertierung der Formate PPT, PPTX und ODP nach HTML. Zudem können Sie Folieninhalte als SVG speichern und Medienassets exportieren.

### **Kann ich das Einbetten von Schriften vermeiden, um die HTML‑Ausgabedatei zu verkleinern?**

Ja, Sie können gängige Systemschriften wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine eigene Implementierung des `HtmlController` bereitstellen.

### **Gibt es ein Online‑Tool, um PowerPoint nach HTML zu konvertieren?**

Ja, Sie können die kostenlosen Web‑Tools von Aspose nutzen, z. B. [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), um Präsentationen direkt im Browser zu konvertieren, ohne Code zu schreiben.

### **Kann ich benutzerdefinierte CSS‑Stile in die exportierte HTML‑Datei einbinden?**

Ja, Aspose.Slides ermöglicht das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Aussehen der resultierenden HTML‑Inhalte vollständig anpassen können.