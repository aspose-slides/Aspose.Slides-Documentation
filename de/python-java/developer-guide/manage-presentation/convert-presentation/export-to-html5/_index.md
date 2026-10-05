---
title: Präsentationen in HTML5 konvertieren in Python via Java
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/python-java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für Python via Java. Formatierung, Animationen und Interaktivität erhalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für Python via Java in HTML5 konvertiert werden. Er behandelt den Basisexport, die Steuerung von Form‑Animationen und Folienübergängen sowie das Layout von Kommentaren. Außerdem wird die HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des normalen HTML‑Exports verglichen.

Die Beispiele benötigen Aspose.Slides für Python via Java und eine kompatible Java‑Runtime. Legen Sie die Eingabe‑Präsentationen im aktuellen Arbeitsverzeichnis ab. Jedes Beispiel startet die JVM nur, wenn sie noch nicht läuft.

## **Exportieren von PowerPoint nach HTML5**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die standardmäßigen Exporteinstellungen; das nächste Beispiel zeigt, wie die Wiedergabe von Animationen explizit gesteuert wird. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Neben dem HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folienstil, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren Foliennavigation und Animationen nicht.
{{% /alert %}}

Um zu exportieren, ohne Form‑Animationen oder Folienübergänge abzuspielen, übergeben Sie `False` an [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) und [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) in [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten in der erzeugten Seite deaktiviert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Exportieren von PowerPoint nach HTML**

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Folieninhalt wird als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mit diesem Rendering‑Ansatz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Der vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhalter‑Text steht für diesen Inhalt und ist nicht das wörtliche Export‑Ergebnis.

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
Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die in diesem Artikel gezeigten Optionen für Form‑Animationen und Folienübergänge benötigen.
{{% /alert %}}

## **PowerPoint HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Betrachten und Navigieren der Präsentationsfolien im Browser. Dieses Beispiel aktiviert sowohl [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) als auch [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions), sodass die exportierte Folienansicht Effekte der Quellpräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Form‑Animationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt Folien ohne Effekte keine neuen Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, wobei die zugehörigen Unterstützungs‑Dateien verfügbar sind.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Eine Präsentation mit Kommentaren in ein HTML5‑Dokument konvertieren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, sodass Leser Feedback neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt erwartet, dass die Quellpräsentation Kommentare enthält, wie unten illustriert. Es exportiert diese Kommentare; es werden keine neuen erstellt.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) von [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Verwenden Sie [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), um `Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) auszuwählen und die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verknüpften Text mit dem Ziel `javascript:alert('Hello')` und einen normalen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, übergeben Sie `True` an [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Der Standardwert ist `False`, sodass diese Links nicht gefiltert werden, solange Sie die Option nicht aktivieren.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den normalen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder anderen aktiven Inhalt und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Foliennavigation und -animationen.

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen, um [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) und [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe aufgenommen und (zum Beispiel rechts von der Folie) über [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript ausführen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Einstellung [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ermöglicht das Überspringen von Hyperlinks mit JavaScript‑Aufrufen beim Speichern. Der Standardwert ist `False`. Siehe [Exclude JavaScript Hyperlinks During Export](/slides/de/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Export‑Beispiel und den Umfang des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.