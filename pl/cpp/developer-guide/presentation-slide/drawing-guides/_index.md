---
title: Zarządzanie liniami prowadzącymi w prezentacjach w C++
linktitle: Linie prowadzące
type: docs
weight: 85
url: /pl/cpp/drawing-guides/
keywords:
- linia prowadząca
- linia pozioma
- linia pionowa
- linia wyrównania
- widok slajdu
- slajd wzorca
- slajd układu
- wzorzec notatek
- wzorzec rozdania
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome oraz pionowe linie prowadzące w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Linie prowadzące to regulowane poziome i pionowe linie, które pomagają użytkownikom konsekwentnie wyrównywać kształty podczas edytowania prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie dopracowywać: aplikacja może zapisać te same pomoce wyrównania, których autorzy powinni używać przy dodawaniu lub przenoszeniu treści.

Linie prowadzące są pomocy edycyjnymi, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w renderowanym wyjściu. Aspose.Slides for C++ udostępnia je poprzez interfejs [IDrawingGuidesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguidescollection/) . Prowadząca jest reprezentowana przez [IDrawingGuide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguide/) i ma orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub wzorca. Prowadząca pionowa używa współrzędnej poziomej, zazwyczaj pomiędzy zero a szerokością slajdu. Prowadząca pozioma używa współrzędnej pionowej, zazwyczaj pomiędzy zero a wysokością slajdu.

## **Dodawanie linii prowadzących w widoku slajdu**

Użyj [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) aby zarządzać liniami prowadzącymi wyświetlanymi podczas edytowania zwykłych slajdów. Wywołaj [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguidescollection/add/) z wartością [Orientation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową linię prowadzącą po prawej stronie środka slajdu oraz jedną poziomą linię prowadzącą poniżej niej:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dostęp do linii prowadzących**

Metody [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguidescollection/get_count/) oraz [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguidescollection/idx_get/) zapewniają dostęp do istniejących linii prowadzących. Metody [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguide/get_position/) i [IDrawingGuide::get_Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguide/get_color/) zwracają bieżące właściwości linii prowadzącej. Odpowiednie metody ustawiające mogą zmienić te właściwości.

Poniższy przykład odczytuje linie prowadzące w widoku slajdu z prezentacji utworzonej powyżej:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Dodawanie linii prowadzących do slajdów wzorca i układu**

Wzorzec slajdu oraz każdy z jego slajdów układu mogą mieć własne kolekcje linii prowadzących. Użyj [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/get_drawingguides/) dla slajdu wzorca oraz [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_drawingguides/) dla slajdu układu.

Poniższy przykład dodaje pionową linię prowadzącą do pierwszego slajdu wzorca oraz poziomą linię prowadzącą do pierwszego slajdu układu:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dodawanie linii prowadzących do wzorców notatek i rozdania**

Wzorce notatek i wzorce rozdania również obsługują linie prowadzące. Użyj [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslide/get_drawingguides/) oraz [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych wzorców, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) lub [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) tworzy domyślny wzorzec i go zwraca.

Poniższy przykład dodaje poziomą linię prowadzącą do wzorca notatek oraz pionową linię prowadzącą do wzorca rozdania:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Usuwanie linii prowadzących**

Wywołaj [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idrawingguidescollection/clear/) , aby usunąć wszystkie linie prowadzące z określonej kolekcji. Czyszczenie jednej kolekcji nie wpływa na linie prowadzące przechowywane w innym zakresie.

Poniższy przykład usuwa linie prowadzące w widoku slajdu oraz wszystkie linie prowadzące na wzorcach slajdów, slajdach układu, wzorcu notatek i wzorcu rozdania, nie tworząc brakujących wzorców:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy linie prowadzące pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Linie prowadzące są pomocnikami wyrównania przy edycji i nie są renderowane jako treść prezentacji.

**Czy można dodać linię prowadzącą bezpośrednio do pojedynczego normalnego slajdu?**

Linie prowadzące używane przy edycji normalnych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje linii prowadzących są dostępne dla wzorców slajdów, slajdów układu, wzorców notatek i wzorców rozdania.

**Jakie jednostki są używane do określania pozycji linii prowadzących?**

Pozycje podawane są w punktach, przy czym 72 punkty to jeden cal. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy usunięcie linii prowadzących usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda `Clear` usuwa tylko linie prowadzące w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.