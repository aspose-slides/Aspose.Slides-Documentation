---
title: Export nach HTML5
type: docs
weight: 40
url: /de/net/export-to-html5/
keywords:
- PowerPoint nach HTML
- Folien nach HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- C#
- Csharp
- Aspose.Slides für .NET
description: "Exportiere PowerPoint nach HTML5 in C# oder .NET"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/net/aspose-slides-for-net-21-9-release-notes/), haben wir die Unterstützung für den HTML5-Export implementiert. Wenn Sie jedoch lieber Ihre PowerPoint‑Präsentation mit WebExtensions nach HTML exportieren möchten, sehen Sie sich stattdessen [diesen Artikel](/slides/de/net/web-extensions/) an. 

{{% /alert %}} 

Der Export nach HTML5 ermöglicht hier die Konvertierung von PowerPoint nach HTML ohne WebExtensions oder Abhängigkeiten. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportvorgang und das resultierende HTML, CSS, JavaScript sowie die Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser C#‑Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren können, ohne WebExtensions und Abhängigkeiten:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Auf diese Weise können Sie Einstellungen für Formanimationen und Folienübergänge festlegen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```


## **PowerPoint nach HTML exportieren**

Dieser C#‑Code demonstriert den standardmäßigen PowerPoint‑zu‑HTML‑Prozess:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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


{{% alert title="Note" color="warning" %}} 

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus dargestellt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser C#‑Code demonstriert den PowerPoint‑zu‑HTML5‑Folienansicht‑Exportprozess:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```


## **Eine Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind insbesondere in kollaborativen Projekten nützlich, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `NotesCommentsLayouting` der Klasse [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts von den Folien angezeigt werden.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


Das Dokument „output.html“ wird im Bild unten gezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen, um [Formanimationen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [Folienübergänge](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) zu aktivieren oder zu deaktivieren.

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über [Layout‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript ausführen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), mit der Sie beim Speichern Hyperlinks mit JavaScript‑Aufrufen überspringen können. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.