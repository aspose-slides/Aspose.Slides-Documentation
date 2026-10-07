---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /cs/cpp/
keywords:
- dokumentace
- zpracování prezentací
- konverze prezentací
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides for C++, vytvořte první prezentaci a najděte návody pro běžné úkoly, referenci API a podporu."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ je nativní knihovna C++ pro vytváření, čtení, úpravu a konverzi prezentací PowerPoint a OpenDocument, bez Microsoft PowerPoint nebo Office Automation.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/cpp/installation/">Instalace</a></li>
<li><a href="/slides/cs/cpp/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/cpp/getting-started/">Průvodce začátkem</a></li>
</ul>
<p>OHODNIT</p>
<ul>
<li><a href="/slides/cs/cpp/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/cpp/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/cpp/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytváření pomocí Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/cpp/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/cpp/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/cpp/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/cpp/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/cpp/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PRACOVNÍ POSTUPY</p>
<ul>
<li><a href="/slides/cs/cpp/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/cpp/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/cpp/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/cpp/presentation-design/">Design snímků</a></li>
<li><a href="/slides/cs/cpp/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/cpp/examples/">Příklady podle prvku snímku</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Příklady na GitHubu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Referencia API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/cpp/known-issues/">Známé problémy</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Stránka produktu</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Stáhnout</a></li>
</ul>
<p>PODPOŘA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Ve Windows vytvořte projekt C++ **Console App** ve Visual Studio a nainstalujte balíček NuGet v konzoli Správce balíčků (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

V Linuxu stáhněte balíček ZIP pro Linux a nastavte projekt CMake popsaný v [Instalace](/slides/cs/cpp/installation/#linux).

Poté použijte tento kód jako hlavní zdrojový soubor programu. Vytvoří prezentaci s jedním textovým polem a uloží ji:

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

Pro spuštění ve Windows vyberte platformu **x64** v nástrojové liště a stiskněte **Ctrl+F5**. V Linuxu jej uložte jako *main.cpp* ve složce projektu, poté jej sestavte a spusťte:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Program uloží *hello.pptx* s jedním snímkem obsahujícím textové pole. Bez licence obsahuje uložený soubor vodoznak hodnocení — viz [Licencování](/slides/cs/cpp/licensing/). Pro další způsoby, jak vytvářet a naplňovat prezentaci, viz [Vytvoření prezentací](/slides/cs/cpp/create-presentation/).