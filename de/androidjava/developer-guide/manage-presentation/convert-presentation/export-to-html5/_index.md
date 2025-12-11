---
title: Präsentationen nach HTML5 auf Android konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/androidjava/export-to-html5/
keywords:
- PowerPoint nach HTML5
- OpenDocument nach HTML5
- Präsentation nach HTML5
- Folie nach HTML5
- PPT nach HTML5
- PPTX nach HTML5
- ODP nach HTML5
- PPT als HTML5 speichern
- PPTX als HTML5 speichern
- ODP als HTML5 speichern
- PPT nach HTML5 exportieren
- PPTX nach HTML5 exportieren
- ODP nach HTML5 exportieren
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen zu responsive HTML5 mit Aspose.Slides für Android über Java. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

{{% alert title="Info" color="info" %}}

In Aspose.Slides 21.9 haben wir die Unterstützung für den HTML5‑Export implementiert.

{{% /alert %}} 

Der Export nach HTML5 ermöglicht es Ihnen, PowerPoint ohne Web‑Erweiterungen oder Abhängigkeiten in HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen festlegen, die den Exportvorgang sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser Java‑Code zeigt, wie Sie eine Präsentation ohne Web‑Erweiterungen und Abhängigkeiten nach HTML5 exportieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können auf diese Weise Einstellungen für Shape‑Animationen und Folienübergänge festlegen:
```java
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

Dieses Java‑Beispiel demonstriert den Standard‑Export von PowerPoint nach HTML:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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

Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Styles anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Slide‑View exportieren**

**Aspose.Slides** ermöglicht das Konvertieren einer PowerPoint‑Präsentation in ein HTML5‑Dokument, in dem die Folien in einem Slide‑View‑Modus angezeigt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei im Browser die Präsentation im Slide‑View‑Modus auf einer Webseite. 

Dieser Java‑Code demonstriert den Exportprozess von PowerPoint nach HTML5 Slide View:
```java
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

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien hinzuzufügen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachvollziehbar ist, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `getNotesCommentsLayouting` der Klasse [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) angeben.

Das nachstehende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


Das Dokument „output.html“ wird im Bild unten dargestellt.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) und [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), mit der Sie Hyperlinks mit JavaScript‑Aufrufen beim Speichern überspringen können. Dies unterstützt die Einhaltung strenger Sicherheitsrichtlinien.