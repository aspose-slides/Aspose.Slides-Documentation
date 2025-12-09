---
title: Präsentationen in .NET zu HTML5 konvertieren
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
description: "Exportieren Sie PowerPoint- & OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für .NET. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/net/aspose-slides-for-net-21-9-release-notes/) haben wir die Unterstützung für HTML5‑Export implementiert. Wenn Sie jedoch lieber Ihre PowerPoint‑Präsentation mit WebExtensions nach HTML exportieren möchten, lesen Sie stattdessen [diesen Artikel](/slides/de/net/web-extensions/).

{{% /alert %}} 

Der Export nach HTML5 ermöglicht hier die Konvertierung von PowerPoint nach HTML ohne WebExtensions oder Abhängigkeiten. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen festlegen, die den Exportvorgang und das resultierende HTML, CSS, JavaScript sowie die Animationsattribute bestimmen. 

## **Export von PowerPoint nach HTML5**

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

Sie können auf diese Weise Einstellungen für Form‑Animationen und Folienübergänge festlegen:
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


## **Export von PowerPoint nach HTML**

Dieses C#‑Beispiel demonstriert den klassischen PowerPoint‑nach‑HTML‑Prozess:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Rendereigenschaften keine Stile anwenden oder einzelne Elemente animieren. 

{{% /alert %}}

## **Export von PowerPoint nach HTML5‑Folienansicht**

**Aspose.Slides** ermöglicht die Konvertierung einer PowerPoint‑Präsentation in ein HTML5‑Dokument, in dem die Folien im Folienansichtsmodus angezeigt werden. Öffnen Sie das resultierende HTML5‑File in einem Browser, sehen Sie die Präsentation in diesem Modus auf einer Webseite. 

Dieser C#‑Code demonstriert den Exportvorgang von PowerPoint zur HTML5‑Folienansicht:
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


## **Konvertieren einer Präsentation in ein HTML5‑Dokument mit Kommentaren**

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Feedback zu Folien hinterlassen können. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachverfolgt werden kann, wer die Anmerkung gemacht hat.

Nehmen wir an, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigedetails für Kommentare in der `NotesCommentsLayouting`‑Eigenschaft der [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)‑Klasse angeben.

Der folgende Code konvertiert eine Präsentation in ein HTML5‑Dokument, in dem Kommentare rechts von den Folien angezeigt werden.
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


Das Dokument „output.html“ ist im Bild unten zu sehen.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) und [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 eingefügt und über [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [setting](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.