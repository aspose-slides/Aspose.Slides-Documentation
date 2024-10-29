---
title: Export nach HTML5
type: docs
weight: 40
url: /de/java/export-to-html5/
keywords:
- PowerPoint nach HTML
- Folien nach HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- Java
- Aspose.Slides für Java
description: "Exportieren Sie PowerPoint nach HTML5 in Java"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/java/aspose-slides-for-java-21-9-release-notes/) haben wir die Unterstützung für den HTML5-Export implementiert.

{{% /alert %}} 

Der Exportprozess nach HTML5 ermöglicht es Ihnen, PowerPoint ohne Weberweiterungen oder Abhängigkeiten in HTML zu konvertieren. Auf diese Weise können Sie mithilfe Ihrer eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren. 

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

Möglicherweise möchten Sie auf diese Weise Einstellungen für Formanimations und Folienübergänge festlegen:

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

Dieser Java-Code demonstriert den Standardprozess der PowerPoint-zu-HTML-Konvertierung:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

In diesem Fall wird der Inhalt der Präsentation durch SVG in folgender Form gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER FOLIENINHALT KOMMT HIERHIN </g>
     </svg>
</div>
</body>
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5 Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus angezeigt werden. In diesem Fall sehen Sie, wenn Sie die resultierende HTML5-Datei in einem Browser öffnen, die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser Java-Code demonstriert den Exportprozess von PowerPoint in die HTML5-Folienansicht:

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

## Konvertieren einer Präsentation in ein HTML5-Dokument mit Kommentaren

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Anmerkungen oder Feedback zu Präsentationsfolien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors an, was es einfach macht, nachzuvollziehen, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation, die in der Datei "sample.pptx" gespeichert ist.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Beim Konvertieren einer PowerPoint-Präsentation in ein HTML5-Dokument können Sie leicht angeben, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `getNotesCommentsLayouting` der [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) Klasse festlegen.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5-Dokument mit Kommentaren, die rechts von den Folien angezeigt werden.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Das Dokument "output.html" wird im Bild unten angezeigt.

![Die Kommentare im Ausgabedokument HTML5](two_comments_html5.png)