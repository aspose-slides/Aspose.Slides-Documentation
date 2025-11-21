---
title: Präsentationen in Python nach HTML5 konvertieren
linktitle: Export nach HTML5
type: docs
weight: 40
url: /de/python-net/export-to-html5/
keywords:
- PowerPoint zu HTML5
- OpenDocument zu HTML5
- Präsentation zu HTML5
- Folie zu HTML5
- PPT zu HTML5
- PPTX zu HTML5
- ODP zu HTML5
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- HTML5-Export
- Präsentation exportieren
- Folie exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für Python über .NET. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

{{% alert title="Info" color="info" %}}
In **Aspose.Slides 21.9** haben wir die Unterstützung für den HTML5‑Export implementiert. Wenn Sie jedoch lieber Ihre PowerPoint‑Präsentation mit WebExtensions nach HTML exportieren möchten, lesen Sie stattdessen [diesen Artikel](/slides/de/net/web-extensions/).
{{% /alert %}} 

Der hier beschriebene Export nach HTML5 ermöglicht es Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten nach HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser Python‑Code zeigt, wie Sie eine Präsentation ohne WebExtensions und Abhängigkeiten nach HTML5 exportieren können:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```


{{% alert color="primary" %}} 
In diesem Fall erhalten Sie sauberes HTML. 
{{% /alert %}}

Möglicherweise möchten Sie die Einstellungen für Form‑Animationen und Folienübergänge auf diese Weise festlegen:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```


## **PowerPoint nach HTML exportieren**

Dieser Python‑Code demonstriert den Standardprozess zum Export von PowerPoint nach HTML:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```


In diesem Fall wird der Präsentationsinhalt über SVG in folgender Form gerendert:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Hinweis" color="warning" %}} 
Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folien‑Ansichtsmodus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folien‑Ansichtsmodus auf einer Webseite. 

Dieser Python‑Code demonstriert den Export von PowerPoint zur HTML5‑Folienansicht:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportieren Sie eine Präsentation mit Folienübergängen, Animationen und Form‑Animationen nach HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Präsentation speichern
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```


## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgbar ist, wer die Anmerkung gemacht hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `notes_comments_layouting` der Klasse [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) angeben.

Das folgende Code‑Beispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts neben den Folien angezeigt werden.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```


Das "output.html"-Dokument ist im Bild unten zu sehen.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen, um [Form‑Animationen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [Folien‑Übergänge](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über die [Layout‑Einstellungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.