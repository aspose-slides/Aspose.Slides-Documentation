---
title: Präsentationen in Java nach HTML5 konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen in responsives HTML5 mit Aspose.Slides für Java. Behalten Sie Formatierung, Animationen und Interaktivität bei."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in HTML5 konvertiert werden. Er behandelt den grundlegenden HTML5‑Export ohne Web‑Erweiterungen oder zusätzliche Abhängigkeiten sowie Optionen zur Steuerung von Formanimationen und Folienübergängen. Der Artikel zeigt außerdem den Standard‑PowerPoint‑zu‑HTML‑Exportprozess, erklärt, wie HTML5‑Ausgabe im Folien‑Ansichtsmodus erzeugt wird, und demonstriert, wie Kommentare in das exportierte Dokument eingebunden werden können, indem deren Layout konfiguriert wird.

## **PowerPoint nach HTML5 exportieren**

Dieser Java‑Code zeigt, wie Sie eine Präsentation ohne Web‑Erweiterungen und Abhängigkeiten nach HTML5 exportieren:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}}In diesem Fall erhalten Sie sauberes HTML.{{% /alert %}}

Sie können auf diese Weise Einstellungen für Formanimationen und Folienübergänge festlegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint nach HTML exportieren**

Dieses Java‑Beispiel demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
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

{{% alert title="Note" color="warning" %}}Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren.{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht die Konvertierung einer PowerPoint‑Präsentation in ein HTML5‑Dokument, in dem die Folien im Folien‑Ansichtsmodus dargestellt werden. Öffnen Sie die resultierende HTML5‑Datei in einem Browser, wird die Präsentation im Folien‑Ansichtsmodus auf einer Webseite angezeigt.

Dieser Java‑Code demonstriert den Export von PowerPoint nach HTML5‑Folienansicht:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Präsentationen in HTML5‑Dokumente mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Feedback zu Folien hinterlassen können. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachvollziehbar ist, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu übergeben Sie die Anzeigparameter für Kommentare an die Methode `setSlidesLayoutOptions` der Klasse [Html5Options](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/).

Das folgende Code‑Beispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Das Dokument "output.html" wird im Bild unten angezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

### Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?

Ja, HTML5 bietet separate Optionen, um [Formanimationen](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Folienübergänge](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) zu aktivieren oder zu deaktivieren.

### Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie positioniert werden?

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden.

### Kann ich Links, die JavaScript aufrufen, aus Sicherheits- oder CSP‑Gründen überspringen?

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), mit der Sie beim Speichern Hyperlinks mit JavaScript‑Aufrufen überspringen können. Dies unterstützt die Einhaltung strenger Sicherheitsrichtlinien.