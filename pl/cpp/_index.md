---
title: Aspose.Slides dla C++
second_title: Aspose.Slides dla C++
type: docs
weight: 30
url: /pl/cpp/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides for C++, utwórz pierwszą prezentację i znajdź przewodniki dla typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ to natywna biblioteka C++ służąca do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint oraz OpenDocument, bez użycia Microsoft PowerPoint ani automatyzacji Office.

Obsługuje wczytywanie i zapisywanie plików PPT, PPTX, PPS, POT i ODP, w tym wersje z makrami oraz szablony, oraz umożliwia eksport do formatu PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/cpp/installation/">Instalacja</a></li>
<li><a href="/slides/pl/cpp/create-presentation/">Utwórz pierwszą prezentację</a></li>
<li><a href="/slides/pl/cpp/getting-started/">Przewodnik po rozpoczęciu pracy</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/cpp/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/cpp/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/cpp/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj za pomocą Slides</b></p>
<hr>
<p>WSPÓLNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/cpp/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/cpp/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/cpp/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/cpp/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/cpp/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PROCESY PRACY Z SLIDES</p>
<ul>
<li><a href="/slides/pl/cpp/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/cpp/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/cpp/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/cpp/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/cpp/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/cpp/examples/">Przykłady według elementu slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Przykłady na GitHubie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje i wsparcie</b></p>
<hr>
<p>REFERENCJE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Notatki o wydaniu</a></li>
<li><a href="/slides/pl/cpp/known-issues/">Znane problemy</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezpłatne forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

W systemie Windows utwórz projekt C++ **Console App** w Visual Studio i zainstaluj pakiet NuGet w konsoli Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

W systemie Linux pobierz pakiet ZIP dla Linuksa i skonfiguruj projekt CMake opisany w [Instalacja](/slides/pl/cpp/installation/#linux).

Następnie użyj tego kodu jako głównego pliku źródłowego programu. Tworzy on prezentację z jednym polem tekstowym i zapisuje ją:

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

Aby uruchomić go w systemie Windows, wybierz platformę **x64** na pasku narzędzi i naciśnij **Ctrl+F5**. W systemie Linux zapisz go jako *main.cpp* w folderze projektu, a następnie zbuduj i uruchom tam:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Program zapisuje *hello.pptx* z jednym slajdem zawierającym pole tekstowe. Bez licencji zapisany plik zawiera znak wodny wersji próbnej — zobacz [Licencjonowanie](/slides/pl/cpp/licensing/). Aby dowiedzieć się o innych sposobach tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/cpp/create-presentation/).