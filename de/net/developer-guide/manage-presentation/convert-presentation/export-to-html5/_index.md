---
title: Export nach HTML5
type: docs
weight: 40
url: /net/export-to-html5/
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
description: "Exportieren Sie PowerPoint nach HTML5 in C# oder .NET"
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/net/aspose-slides-for-net-21-9-release-notes/) haben wir die Unterstützung für den HTML5-Export implementiert. Wenn Sie jedoch Ihre PowerPoint-Präsentation lieber mit WebExtensions nach HTML exportieren möchten, lesen Sie stattdessen [diesen Artikel](/slides/net/web-extensions/). 

{{% /alert %}} 

Der Exportprozess nach HTML5 ermöglicht es Ihnen, PowerPoint ohne WebExtensions oder Abhängigkeiten in HTML zu konvertieren. Auf diese Weise können Sie mit Ihren eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess und die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren. 

## **Exportieren von PowerPoint nach HTML5**

Dieser C#-Code zeigt, wie Sie eine Präsentation ohne WebExtensions und Abhängigkeiten nach HTML5 exportieren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können auf diese Weise Einstellungen für Formanimations und Folienübergänge festlegen:

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

#### **Exportieren von PowerPoint nach HTML**

Dieser C#-Code demonstriert den standardmäßigen PowerPoint nach HTML-Prozess:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

In diesem Fall wird der Inhalt der Präsentation in einer Form wie dieser durch SVG gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER FOLINENINHALT KOMMT HIER HINEIN </g>
     </svg>
</div>
</body>
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **Exportieren von PowerPoint nach HTML5-Folienansicht**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus präsentiert werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5-Datei in einem Browser die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser C#-Code demonstriert den Exportprozess von PowerPoint nach HTML5-Folienansicht:

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

## Konvertieren einer Präsentation in ein HTML5-Dokument mit Kommentaren

Kommentare in PowerPoint sind ein Werkzeug, mit dem Benutzer Notizen oder Feedback zu Präsentationsfolien hinterlassen können. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu spezifischen Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, was es einfach macht, nachzuvollziehen, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation, die in der Datei "sample.pptx" gespeichert ist.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint-Präsentation in ein HTML5-Dokument konvertieren, können Sie leicht angeben, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der `NotesCommentsLayouting`-Eigenschaft der [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5-Dokument, in dem die Kommentare rechts von den Folien angezeigt werden.
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

Das Dokument "output.html" wird im folgenden Bild angezeigt.

![Die Kommentare im ausgegebenen HTML5-Dokument](two_comments_html5.png)