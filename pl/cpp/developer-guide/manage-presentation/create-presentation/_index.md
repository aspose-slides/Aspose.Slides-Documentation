---
title: Tworzenie prezentacji w C++
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/cpp/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- tworzenie PPT
- nowy PPT
- tworzenie PPTX
- nowy PPTX
- tworzenie ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Twórz prezentacje w C++ za pomocą Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać pole tekstowe do jej pierwszego slajdu i zapisać wynik jako plik. Krótkie FAQ na końcu obejmuje typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątków, licencjonowania, podpisów cyfrowych i obsługi VBA.

Zanim rozpoczniesz, dodaj Aspose.Slides do swojego projektu: z NuGet w projekcie Visual Studio na Windows lub z pakietu ZIP przy użyciu CMake na Linux. Zobacz [Installation](/slides/pl/cpp/installation/).

## **Utworzenie prezentacji PowerPoint**

Aby utworzyć prezentację i umieścić na jej pierwszym slajdzie pole tekstowe, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Nowa prezentacja już zawiera jeden pusty slajd.
2. Pobierz ten slajd za pomocą metody [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) i jego indeksu, 0.
3. Dodaj prostokąt przy użyciu metody [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) i ustaw jego tekst metodą [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
4. Zapisz prezentację jako plik PPTX przy użyciu metody [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

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

Górny lewy róg prostokąta znajduje się 50 punktów od lewej krawędzi i 50 punktów od górnej krawędzi slajdu, a prostokąt ma szerokość 400 punktów i wysokość 100 punktów. Program zapisuje *hello.pptx* w bieżącym katalogu, zawierając jeden slajd z prostokątem i jego tekstem. Bez licencji Aspose.Slides dodaje znak wodny oceny do każdego zapisanego slajdu; zobacz [Licensing](/slides/pl/cpp/licensing/).

## **FAQ**

### Do jakich formatów mogę zapisać nową prezentację?

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/cpp/save-presentation/), oraz eksportować do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) i [obrazów](/slides/pl/cpp/convert-powerpoint-to-png/), oraz innych.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/cpp/supported-file-formats/).

### Jak kontrolować rozmiar slajdu/ proporcje obrazu przy tworzeniu prezentacji?

Ustaw [rozmiar slajdu](/slides/pl/cpp/slide-size/) (w tym predefiniowane 4:3 i 16:9 lub własne wymiary) i wybierz, jak treść ma być skalowana.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal to 72 jednostki.

### Jak obsługiwać bardzo duże prezentacje (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [BLOB management strategies](/slides/pl/cpp/manage-blob/), ogranicz przechowywanie w pamięci, wykorzystując pliki tymczasowe, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

### Czy mogę tworzyć/zapisywać prezentacje równolegle?

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) z [wielu wątków](/slides/pl/cpp/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

### Jak usunąć znak wodny wersji próbnej i ograniczenia?

[Zastosuj licencję](/slides/pl/cpp/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wiele wątków.

### Czy mogę cyfrowo podpisać utworzone PPTX?

Tak. [Digital signatures](/slides/pl/cpp/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [create/edit VBA projects](/slides/pl/cpp/presentation-via-vba/) i zapisać pliki z włączonymi makrami, takie jak PPTM/PPSM.