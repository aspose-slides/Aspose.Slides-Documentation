---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu C++
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/cpp/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- właściwość ukryta
- diagram organizacyjny
- diagram organizacyjny ze zdjęciami
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla C++ korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint składający się z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for C++ możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, sprawdzać ukryte węzły, konfigurować układy diagramów organizacyjnych i tworzyć diagramy organizacyjne z obrazkami.

## **Pobierz tekst z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj poprzez [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) zwrócony przez [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Przykład wymaga prezentacji zawierającej co najmniej jeden slajd oraz obiekt SmartArt jako pierwszy kształt na tym slajdzie. Wypisuje każdy dostępny klatkę tekstową w konsoli.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Zmień typ układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczania i łączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) są mierzone w punktach. Użyj [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/), aby zmienić układ.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sprawdź, czy węzeł SmartArt jest ukryty**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` i sprawdza stan ukrycia dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty i zapisuje diagram.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pobierz lub ustaw układ diagramu organizacyjnego**

Dla diagramów SmartArt wykorzystujących układ diagramu organizacyjnego, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) i [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) definiują, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały z lewej, prawej lub obu stron, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego rozmieszczenia. Zmieniona prezentacja jest następnie zapisywana.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Utwórz diagram organizacyjny ze zdjęciami**

Diagram organizacyjny ze zdjęciami to układ SmartArt przeznaczony do diagramów hierarchii, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt na slajd. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia tych miejsc obrazami.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Konwertuj starsze diagramy na grupy kształtów**

Podczas modernizacji istniejącej prezentacji możesz potrzebować zaktualizować diagram organizacyjny pierwotnie utworzony w PowerPoint 97–2003. Aspose.Slides reprezentuje te starsze diagramy jako obiekty [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Użyj [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/), aby przekonwertować diagram na grupę kształtów, co umożliwia edycję pojedynczych elementów wizualnych. Zobacz [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) po szczegóły.

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania oryginalnego diagramu. Po udanej konwersji usuń oryginał za pomocą [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/), aby uniknąć duplikacji treści. Zbierz starsze diagramy w wektor przed ich konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zapisana prezentacja zawiera edytowalne grupy kształtów zamiast skonwertowanych starszych diagramów, bez pozostawionych oryginalnych diagramów. Otwórz plik PPTX w PowerPoint, aby edytować pojedyncze elementy w każdej grupie, takie jak ich tekst, wypełnienie czy pozycję.

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwracanie dla języków RTL?**

Tak. Metoda [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) przełącza kierunek diagramu z lewo‑prawo na prawo‑lewo (lub odwrotnie), gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [klonować kształt SmartArt](/slides/pl/cpp/shape-manipulations/) przy użyciu [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) lub [klonować cały slajd](/slides/pl/cpp/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu sieciowego?**

[Renderuj slajd](/slides/pl/cpp/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw wyjątkową wartość [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) lub [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) na kształcie SmartArt, wyszukaj tę wartość w [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), a następnie sprawdź, czy dopasowany kształt jest [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).