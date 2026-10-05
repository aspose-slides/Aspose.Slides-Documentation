---
title: Präsentationen nach HTML5 konvertieren in C++
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
description: "Exportieren Sie PowerPoint‑ und OpenDocument‑Präsentationen nach responsivem HTML5 mit Aspose.Slides für C++. Bewahren Sie Formatierung, Animationen und Interaktivität."
---
## **Übersicht**

Dieser Artikel erklärt, wie PowerPoint‑Präsentationen mit Aspose.Slides für C++ nach HTML5 konvertiert werden. Er behandelt den Basis‑Export, die Steuerung von Formanimationen und Folienübergängen sowie das Layout von Kommentaren. Außerdem wird der HTML5‑Ausgabe mit der SVG‑basierten Ausgabe des Standard‑HTML‑Exports verglichen.

## **PowerPoint nach HTML5 exportieren**

Das folgende Beispiel lädt eine Präsentation aus dem Arbeitsverzeichnis und speichert sie im HTML5‑Format. Es verwendet die Standardeinstellungen für den Export; das nächste Beispiel zeigt, wie die Animationswiedergabe explizit gesteuert wird. Ersetzen Sie den Eingabepfad durch den Pfad zu Ihrer Präsentation.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Zusätzlich zum HTML‑Dokument schreibt der Export unterstützende CSS‑ und JavaScript‑Dateien für Folien‑Styling, Animationen, Effekte und Navigation. Bewahren Sie diese Dateien zusammen mit dem HTML‑Dokument auf, wenn Sie die Ausgabe verschieben oder veröffentlichen. Die erzeugte Seite lädt zudem jQuery und Anime.js von öffentlichen CDNs; ohne diese funktionieren Folien‑Navigation und Animationen nicht.

{{% /alert %}}

Um den Export ohne das Abspielen von Formanimationen oder Folienübergängen durchzuführen, übergeben Sie `false` an [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) und [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Diese Einstellungen sind unabhängig, sodass Sie eine aktivieren und die andere deaktivieren können. Das Beispiel exportiert die Präsentation mit beiden Animationsarten im erzeugten Dokument deaktiviert.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint nach HTML exportieren**

Der Standard‑HTML‑Export verwendet einen anderen Rendering‑Ansatz: Der Folieninhalt wird als SVG innerhalb einer HTML‑Seite dargestellt. Das folgende Beispiel konvertiert eine Präsentation in ein HTML‑Dokument mit diesem Rendering‑Ansatz.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Der vereinfachte Markup unten veranschaulicht die Struktur der erzeugten Seite. Das SVG‑Element enthält den gerenderten Folieninhalt; der Platzhalter‑Text steht für diesen Inhalt und ist nicht das wörtliche Export‑Ergebnis.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}

Der SVG‑basierte Export stellt PowerPoint‑Formen nicht als einzelne HTML‑Elemente bereit. Verwenden Sie den HTML5‑Export, wenn Sie die in diesem Artikel gezeigten Optionen für Formanimationen und Folienübergänge benötigen.

{{% /alert %}}

## **PowerPoint nach HTML5‑Folienansicht exportieren**

Der HTML5‑Export erzeugt eine Seite zum Betrachten und Navigieren der Präsentationsfolien in einem Browser. Dieses Beispiel übergibt `true` an sowohl [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) als auch [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/), sodass die exportierte Folienansicht Effekte aus der Quellpräsentation abspielen kann.

Verwenden Sie eine Präsentation, die bereits Formanimationen und Folienübergänge enthält, um die Wirkung dieser Einstellungen zu sehen. Das Aktivieren fügt keinen Folien ohne Animationen neue Effekte hinzu. Öffnen Sie nach dem Export das erzeugte HTML5‑Dokument in einem Browser, wobei die unterstützenden Dateien verfügbar sein müssen.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Präsentation in ein HTML5‑Dokument mit Kommentaren konvertieren**

Sie können vorhandene Folienkommentare in die HTML5‑Ausgabe einbinden, sodass Leser Feedback neben dem Folieninhalt sehen können. Das Beispiel in diesem Abschnitt erwartet, dass die Quellpräsentation Kommentare enthält, wie unten dargestellt. Es exportiert diese Kommentare; es werden keine neuen erstellt.

![Zwei Kommentare auf der Präsentationsfolie](two_comments_pptx.png)

Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)-Objekt an die Methode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) von [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Rufen Sie [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) mit `CommentsPositions::Right` aus der Aufzählung [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) auf, um die Kommentare rechts von jeder Folie zu platzieren.

Das folgende Beispiel exportiert die Präsentation nach HTML5 mit diesem Kommentar‑Layout. Eine Präsentation ohne Kommentare enthält keinen anzuzeigenden Kommentartext.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Das Bild unten zeigt das exportierte HTML5‑Dokument mit den neben der Folie angezeigten Kommentaren.

![Die Kommentare im ausgegebenen HTML5‑Dokument](two_comments_html5.png)

## **JavaScript‑Hyperlinks beim Export ausschließen**

Angenommen, `hyperlinks.pptx` enthält verknüpften Text mit dem Ziel `javascript:alert('Hello')` und einen gewöhnlichen `https://example.com/`‑Link. Um den JavaScript‑Hyperlink beim Export auszuschließen, rufen Sie [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) mit `true` auf. Der Standardwert ist `false`, sodass diese Links nur gefiltert werden, wenn Sie die Option aktivieren.

Das folgende Beispiel lädt die Präsentation aus dem Arbeitsverzeichnis und exportiert sie mit [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Die exportierte Datei lässt den JavaScript‑Hyperlink weg, behält jedoch dessen Text und den gewöhnlichen HTTPS‑Link bei. Die Quellpräsentation bleibt unverändert.

Diese Option filtert JavaScript‑Hyperlinks; sie entfernt nicht alle Skripte oder anderen aktiven Inhalt und garantiert keine CSP‑Konformität. Beispielsweise enthält die HTML5‑Ausgabe weiterhin Skripte für die Folien‑Navigation und -Animationen.

## **FAQ**

**Kann ich steuern, ob Formanimationen und Folienübergänge in HTML5 abgespielt werden?**

Ja, der HTML5‑Export bietet separate Optionen zum Aktivieren oder Deaktivieren von [Formanimationen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) und [Folienübergängen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Werden Kommentare unterstützt und wo können sie relativ zur Folie positioniert werden?**

Ja, vorhandene Kommentare können in die HTML5‑Ausgabe aufgenommen und über [Layout‑Einstellungen](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) für Notizen und Kommentare positioniert werden (z. B. rechts von der Folie).

**Kann ich Links, die JavaScript aufrufen, aus Sicherheits‑ oder CSP‑Gründen überspringen?**

Ja, die Methode [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) ermöglicht das Überspringen von Hyperlinks mit JavaScript‑Aufrufen beim Speichern. Der Standardwert ist `false`. Siehe [JavaScript‑Hyperlinks beim Export ausschließen](/slides/de/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) für ein HTML5‑Export‑Beispiel und den Geltungsbereich des Filters. Diese Einstellung entfernt nicht das JavaScript, das vom HTML5‑Viewer für Navigation und Animationen verwendet wird.