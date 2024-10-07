---
title: Exportieren nach HTML5
type: docs
weight: 40
url: /python-net/export-to-html5/
keywords:
- PowerPoint zu HTML
- Folien zu HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- Java
- Aspose.Slides für Python über .NET
description: "Exportieren Sie PowerPoint nach HTML5 in Python"
---

{{% alert title="Info" color="info" %}}

In **Aspose.Slides 21.9** haben wir die Unterstützung für den HTML5-Export implementiert. Wenn Sie jedoch Ihre PowerPoint-Präsentation mithilfe von WebExtensions nach HTML exportieren möchten, lesen Sie stattdessen [diesen Artikel](/slides/net/web-extensions/).

{{% /alert %}} 

Der Export nach HTML5-Prozess hier ermöglicht es Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten nach HTML zu konvertieren. Auf diese Weise können Sie mit Ihren eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess und die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren.

## **PowerPoint nach HTML5 exportieren**

Dieser Python-Code zeigt, wie Sie eine Präsentation ohne WebExtensions und Abhängigkeiten nach HTML5 exportieren:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie möchten möglicherweise die Einstellungen für Formanimations und Folienübergänge folgendermaßen angeben:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **PowerPoint nach HTML exportieren**

Dieser Python-Code demonstriert den Standardprozess zum Exportieren von PowerPoint nach HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

In diesem Fall wird der Inhalt der Präsentation durch SVG in einer Form wie dieser gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER INHALT DER FOLIE WIRD HIER ANGEZEIGT </g>
     </svg>
</div>
</body>
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund der SVG-Rendering nicht Stile anwenden oder spezifische Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5-Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Modus der Folienansicht präsentiert werden. In diesem Fall sehen Sie, wenn Sie die resultierende HTML5-Datei in einem Browser öffnen, die Präsentation im Modus der Folienansicht auf einer Webseite.

Dieser Python-Code demonstriert den Exportprozess von PowerPoint zur HTML5-Folienansicht:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportieren Sie eine Präsentation mit Folienübergängen, Animationen und Formanimationen nach HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Präsentation speichern
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## Konvertieren Sie eine Präsentation in ein HTML5-Dokument mit Kommentaren

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Präsentationsfolien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, was das Nachverfolgen erleichtert, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation, die in der Datei "sample.pptx" gespeichert ist.

![Zwei Kommentare zur Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint-Präsentation in ein HTML5-Dokument konvertieren, können Sie leicht angeben, ob Sie Kommentare aus der Präsentation im Ausgabedokument einfügen möchten. Dazu müssen Sie die Anzeigeparameter für Kommentare in der `notes_comments_layouting`-Eigenschaft der [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5-Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Das Dokument "output.html" wird in der folgenden Abbildung dargestellt.

![Die Kommentare im Ausgabedokument HTML5](two_comments_html5.png)