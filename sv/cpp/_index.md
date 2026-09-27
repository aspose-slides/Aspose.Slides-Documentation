---
title: Aspose.Slides för C++
second_title: Aspose.Slides för C++
type: docs
weight: 30
url: /sv/cpp/
keywords:
- dokumentation
- presentationbearbetning
- presentationkonvertering
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för C++, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ är ett native C++-bibliotek för att skapa, läsa, redigera och konvertera PowerPoint- och OpenDocument-presentationer, utan Microsoft PowerPoint eller Office Automation.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makroaktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM I GÅNG</p>
<ul>
<li><a href="/slides/sv/cpp/installation/">Installation</a></li>
<li><a href="/slides/sv/cpp/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/cpp/getting-started/">Guide för att komma igång</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/cpp/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/cpp/evaluate-aspose-slides/">Begränsningar för provversion</a></li>
<li><a href="/slides/sv/cpp/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/cpp/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/cpp/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/cpp/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/cpp/convert-slide/">Rendera bilder som bildfiler</a></li>
<li><a href="/slides/sv/cpp/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES ARBETSGÅNGAR</p>
<ul>
<li><a href="/slides/sv/cpp/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/cpp/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/cpp/manage-media-files/">Ljud och video</a></li>
<li><a href="/slides/sv/cpp/presentation-design/">Slide-design</a></li>
<li><a href="/slides/sv/cpp/merge-presentation/">Sammanfoga presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/cpp/examples/">Exempel per slide-element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Exempel på GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API-referens</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Versionsanteckningar</a></li>
<li><a href="/slides/sv/cpp/known-issues/">Kända problem</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Nedladdning</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald supporthelpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

På Windows skapar du ett C++ **Console App**-projekt i Visual Studio och installerar NuGet-paketet i Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

På Linux laddar du ner Linux ZIP-paketet och konfigurerar CMake-projektet som beskrivs i [Installation](/slides/sv/cpp/installation/#linux).

Använd sedan denna kod som huvudkällfil för ditt program. Den skapar en presentation med en textruta och sparar den:

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

För att köra den på Windows, välj **x64**-plattformen i verktygsfältet och tryck **Ctrl+F5**. På Linux sparar du den som *main.cpp* i projektmappen, bygger och kör den där:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Programmet sparar *hello.pptx* med en slide som innehåller en textruta. Utan licens får den sparade filen ett utvärderingsvattenmärke — se [Licensiering](/slides/sv/cpp/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa presentationer](/slides/sv/cpp/create-presentation/).