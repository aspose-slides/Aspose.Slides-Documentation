---
title: Präsentationen auf Android in HTML5 konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen in responsives HTML5 mit Aspose.Slides für Android über Java. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in HTML5 konvertiert werden. Er behandelt den einfachen HTML5‑Export ohne Web‑Erweiterungen oder zusätzliche Abhängigkeiten sowie Optionen zur Steuerung von Formanimationen und Folienübergängen. Der Artikel zeigt außerdem den Standard‑PowerPoint‑zu‑HTML‑Exportprozess, erklärt, wie HTML5‑Ausgabe im Folienansichtsmodus erzeugt wird, und demonstriert, wie Kommentare im exportierten Dokument durch Konfiguration ihres Layouts eingebunden werden können.

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

{{% alert color="info" %}} 
In diesem Fall erhalten Sie sauberes HTML. 
{{% /alert %}}

Sie können die Einstellungen für Formanimationen und Folienübergänge auf diese Weise festlegen:

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

Dieser Java‑Code demonstriert den Standardprozess zum Exportieren von PowerPoint nach HTML:

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

{{% alert title="Hinweis" color="warning" %}} 
Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 
{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus präsentiert werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei im Browser die Präsentation im Folienansichtsmodus auf einer Webseite.

Dieser Java‑Code demonstriert den Export einer PowerPoint‑Präsentation in die HTML5‑Folienansicht:

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

## **Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders in kollaborativen Projekten nützlich, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachvollziehbar ist, wer die Anmerkung gemacht hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei **"sample.pptx"** gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie ganz einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare an die Methode `setSlidesLayoutOptions` der Klasse [Html5Options](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/) übergeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts neben den Folien angezeigt werden.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Das Dokument **"output.html"** wird im Bild unten angezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

### Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [Folienübergängen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden.

### Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.