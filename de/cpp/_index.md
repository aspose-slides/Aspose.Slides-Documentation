---
title: Aspose.Slides für C++
second_title: Aspose.Slides für C++
type: docs
weight: 30
url: /de/cpp/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für C++, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API-Referenz und den Support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ ist eine native C++-Bibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen, ohne Microsoft PowerPoint oder Office‑Automation.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagenvarianten, und exportiert nach PDF, XPS, HTML, SVG, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/cpp/installation/">Installation</a></li>
<li><a href="/slides/de/cpp/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/cpp/getting-started/">Leitfaden für den Einstieg</a></li>
</ul>
<p>EVALUIEREN</p>
<ul>
<li><a href="/slides/de/cpp/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/cpp/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/cpp/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Entwickeln mit Slides</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/cpp/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/cpp/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/cpp/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/cpp/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/cpp/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES‑ARBEITSABLÄUFE</p>
<ul>
<li><a href="/slides/de/cpp/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/cpp/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/cpp/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/cpp/presentation-design/">Foliengestaltung</a></li>
<li><a href="/slides/de/cpp/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/cpp/examples/">Beispiele nach Folienelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Beispiele auf GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/de/cpp/">API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/de/cpp/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/cpp/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://releases.aspose.com/slides/de/cpp/">Herunterladen</a></li>
</ul>
<p>UNTERSTÜTZUNG</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/de/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Unter Windows erstellen Sie ein C++ **Console App**‑Projekt in Visual Studio und installieren das NuGet‑Paket in der Package‑Manager‑Konsole (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Unter Linux laden Sie das Linux‑ZIP‑Paket herunter und richten das in [Installation](/slides/de/cpp/installation/#linux) beschriebene CMake‑Projekt ein.

Verwenden Sie dann diesen Code als Haupt-Quellcodedatei Ihres Programms. Er erstellt eine Präsentation mit einem Textfeld und speichert sie:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Um es unter Windows auszuführen, wählen Sie die **x64**‑Plattform in der Symbolleiste und drücken **Strg+F5**. Unter Linux speichern Sie es als *main.cpp* im Projektordner, bauen es dort und führen es aus:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Das Programm speichert *hello.pptx* mit einer Folie, die ein Textfeld enthält. Ohne Lizenz enthält die gespeicherte Datei ein Evaluationswasserzeichen — siehe [Lizenzierung](/slides/de/cpp/licensing/). Weitere Möglichkeiten zum Erstellen und Befüllen einer Präsentation finden Sie unter [Präsentationen erstellen](/slides/de/cpp/create-presentation/).