---
title: Präsentationen in HTML5 konvertieren in .NET
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
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für .NET. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/net/aspose-slides-for-net-21-9-release-notes/) haben wir die Unterstützung für den HTML5‑Export implementiert. Wenn Sie jedoch lieber Ihr PowerPoint mit WebExtensions nach HTML exportieren möchten, lesen Sie stattdessen [diesen Artikel](/slides/de/net/web-extensions/). 

{{% /alert %}} 

Der HTML5‑Export‑Prozess hier ermöglicht es Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten nach HTML zu konvertieren. Dabei können Sie mit eigenen Vorlagen sehr flexible Optionen festlegen, die den Exportvorgang sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute bestimmen. 

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

So können Sie Einstellungen für Form‑Animationen und Folienübergänge festlegen:
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

Dieses C#‑Beispiel demonstriert den klassischen PowerPoint‑nach‑HTML‑Prozess:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


In diesem Fall wird der Präsentationsinhalt über SVG wie folgt gerendert:
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

Wenn Sie diese Methode zum Export nach HTML verwenden, können Sie aufgrund des SVG‑Renderings keine Stile anwenden oder einzelne Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Slide‑View exportieren**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Slide‑View‑Modus angezeigt werden. Öffnen Sie die resultierende HTML5‑Datei im Browser, sehen Sie die Präsentation im Slide‑View‑Modus auf einer Webseite. 

Dieses C#‑Beispiel demonstriert den Export der PowerPoint‑Präsentation in den HTML5‑Slide‑View:
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

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Feedback zu Folien hinterlassen können. Sie sind besonders in kollaborativen Projekten nützlich, weil mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachverfolgt werden kann, wer die Anmerkung gemacht hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie leicht festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `NotesCommentsLayouting` der Klasse [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, bei dem die Kommentare rechts neben den Folien angezeigt werden.
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

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objekt‑Animationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen, um [Form‑Animationen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) bzw. [Folienübergänge](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) zu aktivieren oder zu deaktivieren.

**Werden Kommentare unterstützt und wo können sie relativ zur Folie platziert werden?**

Ja, Kommentare können in HTML5 eingefügt und über die [Layout‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), mit der Sie beim Speichern Hyperlinks mit JavaScript‑Aufrufen überspringen können. Das unterstützt die Einhaltung strenger Sicherheitsrichtlinien.