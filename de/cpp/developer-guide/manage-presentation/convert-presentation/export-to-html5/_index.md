---
title: Präsentationen nach HTML5 konvertieren in C++
linktitle: Präsentation zu HTML5
type: docs
weight: 40
url: /de/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach responsive HTML5 mit Aspose.Slides für C++. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Überblick**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides in HTML5 konvertiert werden. Er behandelt den einfachen HTML5‑Export ohne Web‑Erweiterungen oder zusätzliche Abhängigkeiten sowie Optionen zur Steuerung von Form‑Animationen und Folien‑Übergängen. Der Artikel zeigt zudem den Standard‑PowerPoint‑zu‑HTML‑Exportprozess, erklärt, wie HTML5‑Ausgabe im Folien‑Ansichtsmodus erzeugt wird, und demonstriert, wie Kommentare im exportierten Dokument durch Konfiguration ihres Layouts eingebunden werden.

## **PowerPoint nach HTML5 exportieren**

Dieser C++‑Code zeigt, wie Sie eine Präsentation nach HTML5 exportieren.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 

In diesem Fall erhalten Sie sauberes HTML. 

{{% /alert %}}

Sie können die Einstellungen für Form‑Animationen und Folien‑Übergänge wie folgt festlegen:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint nach HTML exportieren**

Dieses C++‑Beispiel demonstriert den Standard‑PowerPoint‑zu‑HTML‑Prozess:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

In diesem Fall wird der Präsentationsinhalt über SVG in etwa folgender Form gerendert:

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

Wenn Sie diese Methode zum Exportieren von PowerPoint nach HTML verwenden, können Sie aufgrund der SVG‑Renderung keine Stile anwenden oder bestimmte Elemente animieren. 

{{% /alert %}}

## **PowerPoint nach HTML5‑Slide‑Ansicht exportieren**

**Aspose.Slides** ermöglicht die Konvertierung einer PowerPoint‑Präsentation in ein HTML5‑Dokument, bei dem die Folien im Slide‑View‑Modus dargestellt werden. Öffnen Sie das resultierende HTML5‑File in einem Browser, sehen Sie die Präsentation im Slide‑View‑Modus auf einer Webseite. 

Dieser C++‑Code demonstriert den Exportprozess von PowerPoint zu HTML5 Slide View:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Kommentare in PowerPoint sind ein Werkzeug, das es Benutzern ermöglicht, Notizen oder Feedback zu Folien zu hinterlassen. Sie sind besonders nützlich in kollaborativen Projekten, bei denen mehrere Personen ihre Vorschläge oder Anmerkungen zu bestimmten Folienelementen hinzufügen können, ohne den Hauptinhalt zu verändern. Jeder Kommentar zeigt den Namen des Autors an, sodass leicht nachverfolgt werden kann, wer die Anmerkung gemacht hat.

Angenommen, wir haben die folgende PowerPoint‑Präsentation in der Datei „sample.pptx“ gespeichert.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Wenn Sie eine PowerPoint‑Präsentation in ein HTML5‑Dokument konvertieren, können Sie einfach festlegen, ob Kommentare aus der Präsentation im Ausgabedokument enthalten sein sollen. Dafür müssen Sie die Anzeigeparameter für Kommentare in der `get_NotesCommentsLayouting`‑Methode der [Html5Options](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/)‑Klasse angeben.

Das folgende Code‑Beispiel konvertiert eine Präsentation in ein HTML5‑Dokument, bei dem Kommentare rechts neben den Folien angezeigt werden.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Das Dokument „output.html“ ist im Bild unten zu sehen.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **FAQ**

### Kann ich steuern, ob Objekt‑Animationen und Folien‑Übergänge in HTML5 abgespielt werden?

Ja, HTML5 bietet separate Optionen zum Aktivieren oder Deaktivieren von [shape animations](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animateshapes/) und [slide transitions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Wird die Ausgabe von Kommentaren unterstützt und wo können sie relativ zur Folie platziert werden?

Ja, Kommentare können in HTML5 hinzugefügt und (zum Beispiel rechts von der Folie) über Layout‑Einstellungen für Notizen und Kommentare positioniert werden.

### Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?

Ja, es gibt eine [Einstellung](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), die es ermöglicht, Hyperlinks mit JavaScript‑Aufrufen beim Speichern zu überspringen. Dies hilft, strenge Sicherheitsrichtlinien einzuhalten.