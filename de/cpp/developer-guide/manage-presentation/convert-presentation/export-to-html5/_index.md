---
title: Präsentationen in HTML5 mit C++ konvertieren
linktitle: Präsentation nach HTML5
type: docs
weight: 40
url: /de/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für C++. Bewahren Sie Formatierung, Animationen und Interaktivität."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/cpp/aspose-slides-for-cpp-21-9-release-notes/), haben wir Unterstützung für den HTML5‑Export implementiert.

{{% /alert %}} 

Der HTML5‑Exportprozess ermöglicht hier die Konvertierung von PowerPoint nach HTML. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportvorgang und das resultierende HTML, CSS, JavaScript sowie Animationsattribute festlegen. 

## **Export von PowerPoint nach HTML5**

Dieser C++‑Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können auf diese Weise Einstellungen für Form‑Animationen und Folienübergänge festlegen:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **Export von PowerPoint nach HTML**

Dieses C++‑Beispiel demonstriert den Standard‑PowerPoint‑nach‑HTML‑Prozess:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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

Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Darstellung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **Export von PowerPoint nach HTML5‑Slide‑Ansicht**

**Aspose.Slides** ermöglicht es Ihnen, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Slide‑View‑Modus angezeigt werden. In diesem Fall sehen Sie beim Öffnen der resultierenden HTML5‑Datei in einem Browser die Präsentation im Slide‑View‑Modus auf einer Webseite. 

Dieser C++‑Code demonstriert den PowerPoint‑nach‑HTML5‑Slide‑View‑Exportprozess:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Konvertieren einer Präsentation in ein HTML5‑Dokument mit Kommentaren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu ändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Two comments on the presentation slide](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der `get_NotesCommentsLayouting`‑Methode der [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/)‑Klasse angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei Kommentare rechts neben den Folien angezeigt werden.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Das Dokument "output.html" wird im Bild unten gezeigt.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) und [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über Layout‑Einstellungen für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links überspringen, die JavaScript aufrufen, aus Sicherheits‑ oder CSP-Gründen?**

Ja, es gibt eine [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.