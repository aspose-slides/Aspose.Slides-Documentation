---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /nl/cpp/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides for C++, maak een eerste presentatie, en vind de handleidingen voor algemene taken, de API-referentie en ondersteuning."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ is een native C++-bibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties, zonder Microsoft PowerPoint of Office‑automatisering.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>Eerste stappen</p>
<ul>
<li><a href="/slides/nl/cpp/installation/">Installatie</a></li>
<li><a href="/slides/nl/cpp/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/cpp/getting-started/">Gids voor aan de slag</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/cpp/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/cpp/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/cpp/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/cpp/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/cpp/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/cpp/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/cpp/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/cpp/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/cpp/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/cpp/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/cpp/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/cpp/presentation-design/">Dia-ontwerp</a></li>
<li><a href="/slides/nl/cpp/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/cpp/examples/">Voorbeelden per dia‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Voorbeelden op GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Support</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nl/cpp/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nl/cpp/release-notes/">Release‑notities</a></li>
<li><a href="/slides/nl/cpp/known-issues/">Bekende problemen</a></li>
<li><a href="https://releases.aspose.com/slides/nl/cpp/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Je eerste presentatie**

Op Windows maakt u een C++ **Console App**‑project in Visual Studio en installeert u het NuGet‑pakket in de Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Op Linux downloadt u het Linux‑ZIP‑pakket en stelt u het CMake‑project in zoals beschreven in [Installatie](/slides/nl/cpp/installation/#linux).

Gebruik vervolgens deze code als de hoofdbroncode van uw programma. Het maakt een presentatie met één tekstvak en slaat deze op:

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

Om het op Windows uit te voeren, selecteert u het **x64**‑platform in de werkbalk en drukt u op **Ctrl+F5**. Op Linux slaat u het op als *main.cpp* in de projectmap, bouwt en voert u het daar uit:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Het programma slaat *hello.pptx* op met één dia die een tekstvak bevat. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/cpp/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/cpp/create-presentation/).