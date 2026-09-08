---
title: Präsentationen in Python über Java zu HTML5 konvertieren
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
- PPT zu HTML5 exportieren
- PPTX zu HTML5 exportieren
- ODP zu HTML5 exportieren
- Python
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen zu responsive HTML5 mit Aspose.Slides für Python über Java. Formatierungen, Animationen und Interaktivität beibehalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in HTML5 konvertiert werden. Er behandelt den einfachen HTML5‑Export ohne zusätzliche Web‑Erweiterungen sowie Optionen zur Steuerung von Formanimationen und Folienübergängen. Der Artikel zeigt außerdem den Standard‑Export von PowerPoint nach HTML, erklärt, wie HTML5‑Ausgabe im Folienansichtsmodus erzeugt wird, und demonstriert, wie Kommentare im exportierten Dokument durch Konfiguration ihres Layouts eingebunden werden können.

Die Beispiele erfordern Aspose.Slides für Python über Java und eine kompatible Java‑Laufzeitumgebung. Legen Sie `pres.pptx` (oder `sample.pptx` für das Kommentar‑Beispiel) im aktuellen Arbeitsverzeichnis ab. Jeder Beispiel startet die JVM nur, wenn sie noch nicht läuft.

## **PowerPoint nach HTML5 exportieren**

Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Html5](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Html5), um eine Präsentation ohne zusätzliche Web‑Erweiterungen zu exportieren:

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
Der HTML5‑Exporter erstellt HTML‑Inhalte zur Anzeige in einem Browser. 
{{% /alert %}}

Verwenden Sie [Html5Options](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/), um den Export zu konfigurieren. Rufen Sie [setAnimateShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateShapes) und [setAnimateTransitions](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateTransitions) mit `False` auf, um Formanimationen und Folienübergänge zu deaktivieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint nach HTML exportieren**

Verwenden Sie [SaveFormat.Html](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Html) für den Standard‑HTML‑Export. Siehe [PowerPoint nach HTML konvertieren](/slides/de/python-java/convert-powerpoint-to-html/) für weitere Optionen:

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

{{% alert title="Warning" color="warning" %}} 
Der Standard‑HTML‑Export rendert Folieninhalt über SVG und bietet keine HTML5‑Optionen für Formanimationen und Folienübergänge. 
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folienansichtsmodus auf einer Webseite.

Dieser Python‑Code demonstriert den PowerPoint‑nach‑HTML5‑Folienansicht‑Exportvorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Präsentationen in HTML5‑Dokumente mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Feedback zu Präsentationsfolien hinterlassen können. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie bequem festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu übergeben Sie die Anzeigeparameter für Kommentare an die Methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) der Klasse [Html5Options](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/).

Verwenden Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/) und [setCommentsPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) mit [CommentsPositions.Right](https://reference.aspose.com/slides/de/python-java/aspose.slides/commentspositions/#Right). Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts von den Folien angezeigt werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Das Dokument „output.html“ wird im Bild unten angezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateShapes) und [Folienübergängen](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über [Layout‑Einstellungen](https://reference.aspose.com/slides/de/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) (z. B. rechts von der Folie) positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), die es ermöglicht, beim Speichern Hyperlinks mit JavaScript‑Aufrufen zu überspringen. Dadurch werden diese Hyperlinks entfernt; sie garantiert jedoch nicht, dass alle erzeugten HTML5‑Skripte automatisch die Content‑Security‑Policy einer Website erfüllen.