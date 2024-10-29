---
title: Export nach HTML5
type: docs
weight: 40
url: /de/cpp/export-to-html5/
keywords:
- PowerPoint nach HTML
- Folien nach HTML
- HTML5
- HTML-Export
- Präsentation exportieren
- Präsentation konvertieren
- Folien konvertieren
- C++
- Aspose.Slides für C++
description: "Exportieren von PowerPoint nach HTML5 in C++" 
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/cpp/aspose-slides-for-cpp-21-9-release-notes/) haben wir die Unterstützung für den HTML5-Export implementiert.

{{% /alert %}} 

Der Exportprozess nach HTML5 ermöglicht es Ihnen, PowerPoint in HTML zu konvertieren. Auf diese Weise können Sie mit Ihren eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie die resultierenden HTML-, CSS-, JavaScript- und Animationsattribute definieren. 

## **PowerPoint nach HTML5 exportieren**

Dieser C++-Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie möchten möglicherweise auf diese Weise Einstellungen für Formanimationen und Folienübergänge spezifizieren:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint nach HTML exportieren**

Dieser C++-Code demonstriert den Standardprozess von PowerPoint nach HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

In diesem Fall wird der Inhalt der Präsentation in einer Form wie dieser über SVG gerendert:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> DER FOLIENINHALT KOMMT HIER HIN </g>
     </svg>
</div>
</body>
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie diese Methode verwenden, um PowerPoint nach HTML zu exportieren, können Sie aufgrund des SVG-Renderings keine Stile anwenden oder spezifische Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5-Folienansicht exportieren**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint-Präsentation in ein HTML5-Dokument zu konvertieren, in dem die Folien im Modus für die Folienansicht präsentiert werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5-Datei in einem Browser die Präsentation im Modus für die Folienansicht auf einer Webseite. 

Dieser C++-Code demonstriert den Exportprozess von PowerPoint zur HTML5-Folienansicht:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## Eine Präsentation in ein HTML5-Dokument mit Kommentaren konvertieren

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Rückmeldungen zu Präsentationsfolien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, in denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, wodurch es einfach ist, nachzuvollziehen, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint-Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare zur Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint-Präsentation in ein HTML5-Dokument konvertieren, können Sie leicht angeben, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `get_NotesCommentsLayouting` der [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) Klasse angeben.

Das folgende Beispiel konvertiert eine Präsentation in ein HTML5-Dokument, in dem die Kommentare rechts von den Folien angezeigt werden.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Das Dokument "output.html" wird in der folgenden Abbildung angezeigt.

![Die Kommentare im ausgegebenen HTML5-Dokument](two_comments_html5.png)