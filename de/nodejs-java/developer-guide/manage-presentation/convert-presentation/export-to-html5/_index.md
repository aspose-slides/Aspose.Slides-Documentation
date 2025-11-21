---
title: Export nach HTML5
type: docs
weight: 40
url: /de/nodejs-java/export-to-html5/
keywords:
- PowerPoint zu HTML
- Folien zu HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- Java
- Aspose.Slides für Node.js via Java
description: "Export von PowerPoint nach HTML5 in JavaScript"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/nodejs-java/aspose-slides-for-java-21-9-release-notes/), haben wir die Unterstützung für den HTML5‑Export implementiert.

{{% /alert %}} 

Der Export nach HTML5 ermöglicht es Ihnen, PowerPoint ohne Web‑Erweiterungen oder Abhängigkeiten in HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen festlegen, die den Exportprozess und das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser JavaScript‑Code zeigt, wie Sie eine Präsentation nach HTML5 ohne Web‑Erweiterungen und Abhängigkeiten exportieren:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können auf diese Weise Einstellungen für Form‑Animationen und Folienübergänge festlegen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint nach HTML exportieren**

Dieses JavaScript demonstriert den Standard‑PowerPoint‑nach‑HTML‑Prozess:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
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


{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht das Konvertieren einer PowerPoint‑Präsentation in ein HTML5‑Dokument, in dem die Folien im Folienansichtsmodus präsentiert werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei im Browser die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser JavaScript‑Code demonstriert den Export‑Prozess PowerPoint → HTML5‑Folienansicht:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das Benutzern ermöglicht, Notizen oder Feedback zu Folien hinzuzufügen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Nehmen wir an, wir haben die folgende PowerPoint‑Präsentation in der Datei **sample.pptx** gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabendokument enthalten sein sollen. Dazu geben Sie die Anzeige‑Parameter für Kommentare in der Eigenschaft `notes_comments_layouting` der [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/)‑Klasse an.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts von den Folien angezeigt werden.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


Das Dokument **output.html** ist im Bild unten zu sehen.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folien‑Übergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) und [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Werden Kommentare im Ausgabe‑HTML unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und (z. B. rechts von der Folie) über [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies unterstützt die Einhaltung strenger Sicherheitsrichtlinien.