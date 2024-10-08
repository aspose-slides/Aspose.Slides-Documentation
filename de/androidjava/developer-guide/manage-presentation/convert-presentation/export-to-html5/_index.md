---
title: Export nach HTML5
type: docs
weight: 40
url: /de/androidjava/export-nach-html5/
keywords:
- PowerPoint zu HTML
- Folien zu HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- Java
- Aspose.Slides für Android über Java
description: "Exportiere PowerPoint nach HTML5 in Java"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/androidjava/aspose-slides-for-java-21-9-release-notes/) haben wir die Unterstützung für den HTML5-Export implementiert.

{{% /alert %}} 

Der Export nach HTML5-Prozess hier ermöglicht es Ihnen, PowerPoint nach HTML ohne Weberweiterungen oder Abhängigkeiten zu konvertieren. Auf diese Weise können Sie mit Ihren eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser Java-Code zeigt, wie Sie eine Präsentation ohne Weberweiterungen und Abhängigkeiten in HTML5 exportieren:

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

Sie möchten möglicherweise Einstellungen für Formanimations und Folienübergänge auf diese Weise festlegen:

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

Dieser Java-Code demonstriert den Standardprozess zum Exportieren von PowerPoint nach HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

In diesem Fall wird der Inhalt der Präsentation durch SVG in einer Form wie dieser gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER FOLINENINHALT KOMMT HIER REIN </g>
     </svg>
</div>
</body>
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder spezifische Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5 Foliensicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Foliensichtmodus angezeigt werden. In diesem Fall sehen Sie, wenn Sie die resultierende HTML5-Datei in einem Browser öffnen, die Präsentation im Foliensichtmodus auf einer Webseite. 

Dieser Java-Code demonstriert den Exportprozess von PowerPoint nach HTML5 Foliensicht:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-foliensicht.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## Konvertierung einer Präsentation in ein HTML5-Dokument mit Kommentaren

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Präsentationsfolien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors, was es einfach macht, nachzuvollziehen, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation, die in der Datei "sample.pptx" gespeichert ist.

![Zwei Kommentare zur Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint-Präsentation in ein HTML5-Dokument konvertieren, können Sie leicht angeben, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `getNotesCommentsLayouting` der [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5-Dokument mit Kommentaren, die rechts von den Folien angezeigt werden.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Das Dokument "output.html" wird im Bild unten gezeigt.

![Die Kommentare im Ausgabedokument HTML5](two_comments_html5.png)