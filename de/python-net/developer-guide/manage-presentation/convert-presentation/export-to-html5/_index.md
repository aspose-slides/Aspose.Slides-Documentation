---
title: Präsentationen in HTML5 konvertieren mit Python
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
- HTML5 Export
- Präsentation exportieren
- Folie exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Exportieren Sie PowerPoint- & OpenDocument‑Präsentationen in responsives HTML5 mit Aspose.Slides für Python via .NET. Formatierung, Animationen und Interaktivität beibehalten."
---

{{% alert title="Info" color="info" %}}
In **Aspose.Slides 21.9** haben wir die Unterstützung für den HTML5‑Export implementiert. Wenn Sie jedoch lieber Ihre PowerPoint‑Datei mit WebExtensions nach HTML exportieren möchten, siehe [diesen Artikel](/slides/de/net/web-extensions/) statt. 
{{% /alert %}} 

Der Export‑zu‑HTML5‑Prozess hier ermöglicht Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten nach HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportvorgang und das resultierende HTML, CSS, JavaScript sowie die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser Python‑Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren können, ohne WebExtensions und Abhängigkeiten:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
In diesem Fall erhalten Sie sauberes HTML. 
{{% /alert %}}

Sie können die Einstellungen für Form‑Animationen und Folienübergänge auf diese Weise festlegen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **PowerPoint nach HTML exportieren**

Dieser Python‑Code demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

In diesem Fall wird der Präsentationsinhalt über SVG in einer Form wie folgt gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Renderung keine Styles anwenden oder bestimmte Elemente animieren. 
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichts‑Modus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei im Browser die Präsentation im Folienansichts‑Modus auf einer Webseite. 

Dieser Python‑Code demonstriert den PowerPoint‑zu‑HTML5‑Folienansicht‑Exportprozess:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exportieren einer Präsentation mit Folienübergängen, Animationen und Form‑Animationen nach HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Präsentation speichern
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien der Präsentation zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachverfolgbar ist, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `notes_comments_layouting` der Klasse [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) festlegen.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts von den Folien angezeigt werden.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Das Dokument "output.html" wird im Bild unten gezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen, um [Form‑Animationen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [Folienübergänge](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) zu aktivieren oder zu deaktivieren.

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über [Layout‑Einstellungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript ausführen, aus Sicherheits- oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/), die es ermöglicht, beim Speichern Hyperlinks mit JavaScript‑Aufrufen zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.