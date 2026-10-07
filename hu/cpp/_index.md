---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /hu/cpp/
keywords:
- dokumentáció
- prezentáció feldolgozás
- prezentáció konvertálás
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for C++-t, hozza létre az első bemutatót, és találja meg az útmutatókat a gyakori feladatokhoz, az API referenciához és a támogatáshoz."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for C++ egy natív C++ könyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához, Microsoft PowerPoint vagy Office Automation nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP fájlokat, beleértve a makrókat és sablonokat tartalmazó verziókat, és exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/cpp/installation/">Telepítés</a></li>
<li><a href="/slides/hu/cpp/create-presentation/">Készítse el első bemutatóját</a></li>
<li><a href="/slides/hu/cpp/getting-started/">Kezdő útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/cpp/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/cpp/evaluate-aspose-slides/">Próba korlátok</a></li>
<li><a href="/slides/hu/cpp/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Építés Slides használatával</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/cpp/open-presentation/">Bemutató megnyitása</a></li>
<li><a href="/slides/hu/cpp/save-presentation/">Bemutató mentése</a></li>
<li><a href="/slides/hu/cpp/convert-powerpoint-to-pdf/">Konvertálás PDF-be</a></li>
<li><a href="/slides/hu/cpp/convert-slide/">Diaok képként renderelése</a></li>
<li><a href="/slides/hu/cpp/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>DIÁK MUNKAFOLYAMA</p>
<ul>
<li><a href="/slides/hu/cpp/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/cpp/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/cpp/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/cpp/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/cpp/merge-presentation/">Bemutatók egyesítése</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/cpp/examples/">Példák diaelemek szerint</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/cpp/known-issues/">Ismert hibák</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első bemutatója**

Windows rendszeren hozza létre a C++ **Console App** projektet a Visual Studio-ban, és telepítse a NuGet csomagot a Package Manager Console-ban (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Linuxon töltse le a Linux ZIP csomagot, és állítsa be a [Telepítés](/slides/hu/cpp/installation/#linux) leírásában szereplő CMake projektet.

Ezután használja ezt a kódot programja fő forrásfájlként. Egy szövegdobozos bemutatót hoz létre, majd elmenti:

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

Windowson a **x64** platform kiválasztásával a szerszámsoron, majd nyomja meg a **Ctrl+F5**-öt. Linuxon mentse *main.cpp* néven a projekt mappájába, majd építse és futtassa ott:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

A program elmenti a *hello.pptx*-t, amely egy szövegdobozos diát tartalmaz. Licenc nélkül a mentett fájl értékelő vízjeleket kap — lásd a [Licencelés](/slides/hu/cpp/licensing/) részt. További módok a bemutató létrehozására és feltöltésére: lásd a [Bemutatók létrehozása](/slides/hu/cpp/create-presentation/) oldalt.