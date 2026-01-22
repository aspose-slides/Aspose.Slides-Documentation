---
title: Präsentationen in HTML5 mit JavaScript konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen in responsives HTML5 mit Aspose.Slides für Node.js. Bewahren Sie Formatierungen, Animationen und Interaktivität."
---

Aspose.Slides unterstützt den HTML5-Export. Der hier beschriebene Export nach HTML5 ermöglicht es Ihnen, PowerPoint in HTML zu konvertieren, ohne Web-Erweiterungen oder Abhängigkeiten. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess und das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser JavaScript‑Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren, ohne Web‑Erweiterungen und Abhängigkeiten zu verwenden:
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

Auf diese Weise können Sie Einstellungen für Formanimationen und Folienübergänge festlegen:
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

Dieser JavaScript‑Code demonstriert den Standard‑PowerPoint‑nach‑HTML‑Prozess:
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


In diesem Fall wird der Präsentationsinhalt über SVG in einer Form wie dieser gerendert:
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
Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Rendarbeitung keine Stile anwenden oder bestimmte Elemente animieren. 
{{% /alert %}}

## **PowerPoint nach HTML5-Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser JavaScript‑Code demonstriert den Exportprozess von PowerPoint zur HTML5‑Folienansicht:
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

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Präsentationsfolien zu hinterlassen. Sie sind besonders in kollaborativen Projekten nützlich, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `notes_comments_layouting` der Klasse [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


Das Dokument "output.html" wird im Bild unten angezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) und [Folienübergängen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über [Layout‑Einstellungen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) (z. B. rechts von der Folie) positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), mit der Sie beim Speichern Hyperlinks, die JavaScript‑Aufrufe enthalten, überspringen können. Dies unterstützt die Einhaltung strenger Sicherheitsrichtlinien.