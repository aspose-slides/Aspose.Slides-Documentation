---
title: Präsentationen in .NET in HTML5 konvertieren
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für .NET. Formatierung, Animationen und Interaktivität beibehalten."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/net/aspose-slides-for-net-21-9-release-notes/) haben wir die Unterstützung für den HTML5‑Export implementiert. Wenn Sie jedoch bevorzugen, Ihre PowerPoint‑Präsentation mit WebExtensions nach HTML zu exportieren, siehe [diesen Artikel](/slides/de/net/web-extensions/) stattdessen. 

{{% /alert %}} 

Der Export‑zu‑HTML5‑Prozess hier ermöglicht es Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten nach HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportvorgang und das resultierende HTML, CSS, JavaScript sowie Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser C#‑Code zeigt, wie Sie eine Präsentation ohne WebExtensions und Abhängigkeiten nach HTML5 exportieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Möglicherweise möchten Sie auf diese Weise Einstellungen für Formanimationen und Folienübergänge festlegen:
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

Dieses C#‑Beispiel demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:
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

## **PowerPoint nach HTML5‑Slide‑Ansicht exportieren**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien in einem Folien‑Ansichtsmodus präsentiert werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Folien‑Ansichtsmodus auf einer Webseite. 

Dieser C#‑Code demonstriert den Export‑Prozess von PowerPoint zur HTML5‑Slide‑Ansicht:
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

Kommentare in PowerPoint sind ein Werkzeug, das Benutzern erlaubt, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachvollziehbar ist, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei **sample.pptx** gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dafür müssen Sie die Anzeigeparameter für Kommentare in der `NotesCommentsLayouting`‑Eigenschaft der [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)‑Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts von den Folien angezeigt werden.
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


Das Dokument **output.html** wird im Bild unten gezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen, um [Formanimationen]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/ zu aktivieren oder zu deaktivieren, sowie [Folienübergänge]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/.

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über die [Layout‑Einstellungen]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/ für Notizen und Kommentare positioniert werden.

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits- oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung]https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/, die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.