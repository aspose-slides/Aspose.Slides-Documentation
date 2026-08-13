---
title: Präsentationen nach HTML5 in .NET konvertieren
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
description: "Exportieren Sie PowerPoint- und OpenDocument‑Präsentationen in responsives HTML5 mit Aspose.Slides für .NET. Formatierung, Animationen und Interaktivität beibehalten."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in HTML5 konvertiert werden. Er behandelt den einfachen HTML5‑Export sowie Optionen zur Steuerung von Formanimationen und Folienübergängen. Der Artikel zeigt zudem den Standard‑PowerPoint‑zu‑HTML‑Exportprozess, erklärt, wie HTML5‑Ausgabe im Folienansichtsmodus erzeugt wird, und demonstriert, wie Kommentare im exportierten Dokument durch Konfiguration ihres Layouts eingebunden werden können.

## **PowerPoint nach HTML5 exportieren**

Dieser C#‑Code zeigt, wie eine Präsentation nach HTML5 exportiert wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

Zusätzlich zum HTML‑Dokument schreibt der Export die referenzierten Unterstützungsdateien: `pres.css`, `master.css`, `animation.js`, `effects.js` und `navigation.js`. Die erzeugte Seite lädt außerdem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren Foliennavigation und Animationen nicht. 

{{% /alert %}}

Sie können die Einstellungen für Formanimationen und Folienübergänge auf folgende Weise festlegen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Dieser C#‑Code demonstriert den standardmäßigen PowerPoint‑nach‑HTML‑Prozess:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, bei dem die Folien im Folienansichtsmodus dargestellt werden. Öffnen Sie die resultierende HTML5‑Datei in einem Browser, sehen Sie die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser C#‑Code demonstriert den Export von PowerPoint nach HTML5‑Folienansicht:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Rückmeldungen zu Folien hinterlassen können. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgbar ist, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Eigenschaft `NotesCommentsLayouting` der Klasse [Html5Options](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/) angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, bei dem Kommentare rechts neben den Folien angezeigt werden.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Das Dokument „output.html“ ist im Bild unten zu sehen.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

### Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animateshapes/) und [Folienübergängen](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animatetransitions/).

### Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?

Ja, Kommentare können in HTML5 hinzugefügt und (z. B. rechts von der Folie) über [Layout‑Einstellungen](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/notescommentslayouting/) für Notizen und Kommentare positioniert werden.

### Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), die es ermöglicht, beim Speichern Hyperlinks mit JavaScript‑Aufrufen zu überspringen. Dies unterstützt die Einhaltung strenger Sicherheitsrichtlinien.