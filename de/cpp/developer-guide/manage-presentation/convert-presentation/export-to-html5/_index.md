---
title: Präsentationen in HTML5 konvertieren in C++
linktitle: Präsentation zu HTML5
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
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen in responsives HTML5 mit Aspose.Slides für C++. Formatierung, Animationen und Interaktivität beibehalten."
---

{{% alert title="Info" color="info" %}}

In [Aspose.Slides 21.9](/slides/de/cpp/aspose-slides-for-cpp-21-9-release-notes/), wir haben die Unterstützung für den HTML5-Export implementiert.

{{% /alert %}} 

Der Export nach HTML5 ermöglicht es Ihnen, PowerPoint in HTML zu konvertieren. Auf diese Weise können Sie mit eigenen Vorlagen sehr flexible Optionen anwenden, die den Exportprozess sowie das resultierende HTML, CSS, JavaScript und die Animationsattribute definieren. 

## **Export PowerPoint nach HTML5**

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

Sie können auf diese Weise Einstellungen für Formanimationen und Folienübergänge festlegen:
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

Dieser C++‑Code demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:
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

Wenn Sie diese Methode zum Export von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Renderung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **Export von PowerPoint zur HTML5‑Folienansicht**

**Aspose.Slides** ermöglicht es, eine PowerPoint‑Präsentation in ein HTML5‑Dokument zu konvertieren, in dem die Folien im Folienansichtsmodus dargestellt werden. Öffnen Sie die resultierende HTML5‑Datei in einem Browser, sehen Sie die Präsentation im Folienansichtsmodus auf einer Webseite. 

Dieser C++‑Code demonstriert den Exportprozess von PowerPoint zur HTML5‑Folienansicht:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Konvertieren einer Präsentation in ein HTML5‑Dokument mit Kommentaren**

Kommentare in PowerPoint sind ein Werkzeug, das Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders in kollaborativen Projekten nützlich, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors, sodass leicht nachverfolgt werden kann, wer die Anmerkung hinterlassen hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei "sample.pptx" gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie problemlos festlegen, ob Kommentare der Präsentation im Ausgabedokument enthalten sein sollen. Dazu müssen Sie die Anzeigeparameter für Kommentare in der Methode `get_NotesCommentsLayouting` der Klasse [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) angeben.

Das folgende Codebeispiel konvertiert eine Präsentation in ein HTML5‑Dokument, wobei die Kommentare rechts neben den Folien angezeigt werden.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


Das Dokument "output.html" wird im Bild unten gezeigt.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

**Kann ich steuern, ob Objektanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) und [Folienübergängen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, Kommentare können in HTML5 hinzugefügt und über Layout‑Einstellungen für Notizen und Kommentare positioniert werden (z. B. rechts neben der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), mit der Sie beim Speichern Hyperlinks mit JavaScript‑Aufrufen überspringen können. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.