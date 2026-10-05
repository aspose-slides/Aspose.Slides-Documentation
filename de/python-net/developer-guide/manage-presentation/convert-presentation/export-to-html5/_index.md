---
title: Präsentationen in Python zu HTML5 konvertieren
linktitle: Präsentation zu HTML5
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
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT nach HTML5 exportieren
- PPTX nach HTML5 exportieren
- ODP nach HTML5 exportieren
- Python
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen zu responsive HTML5 mit Aspose.Slides für Python über .NET. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Python über .NET in HTML5 konvertiert werden. Er behandelt den einfachen Export, die Steuerung von Shape‑Animationen und Folienübergängen sowie das Kommentar‑Layout. Außerdem vergleicht er die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports.

## **Export von PowerPoint nach HTML5**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die standardmäßigen Exporteinstellungen; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert werden kann. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folienstyling, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren die Foliennavigation und -animationen nicht.
{{% /alert %}}

Um zu exportieren, ohne Shape‑Animationen oder Folienübergänge abzuspielen, setzen Sie [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) in [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) auf `False`. Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten in der erzeugten Seite deaktiviert.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Export von PowerPoint nach HTML**

Der standardmäßige HTML‑Export verwendet einen anderen Rendering‑Ansatz: Folieninhalte werden als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mit diesem Rendering‑Ansatz.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

Das vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhalter‑Text steht für diesen Inhalt und ist nicht die tatsächliche Exportausgabe.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Der SVG‑basierte Export stellt PowerPoint‑Shapes nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die im Artikel gezeigten Optionen für Shape‑Animationen und Folienübergänge benötigen.
{{% /alert %}}

## **Export von PowerPoint zur HTML5‑Folienansicht**

Der HTML5‑Export erzeugt eine Seite zum Anzeigen und Navigieren der Präsentationsfolien im Browser. Dieses Beispiel aktiviert sowohl [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) als auch [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/), sodass die exportierte Folienansicht Effekte aus der Ausgangspräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Shape‑Animationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien, die keine Effekte haben, keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, wobei die zugehörigen Unterstützungsdateien verfügbar sind.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Konvertieren einer Präsentation in ein HTML5‑Dokument mit Kommentaren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, damit Leser Rückmeldungen neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt setzt voraus, dass die Quelldatei Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es erstellt keine neuen.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Weisen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑Objekt der Eigenschaft [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) von [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) zu. Setzen Sie [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) auf `RIGHT` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/), um die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Das Bild unten zeigt das exportierte HTML5‑Dokument, in dem die Kommentare neben der Folie angezeigt werden.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verknüpften Text mit dem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, setzen Sie [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) auf `True`. Der Standardwert ist `False`, sodass diese Links nicht gefiltert werden, es sei denn, Sie aktivieren die Option.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder anderen aktiven Inhalt und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und -animationen.

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) und [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe einbezogen und über die [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Einstellung [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) ermöglicht das Überspringen von Hyperlinks mit JavaScript‑Aufrufen beim Speichern. Der Standardwert ist `False`. Siehe [JavaScript‑Hyperlinks beim Export ausschließen](/slides/de/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Export‑Beispiel und den Geltungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.