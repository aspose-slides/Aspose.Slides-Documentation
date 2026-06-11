---
title: Zarządzanie SmartArt w prezentacjach PowerPoint przy użyciu C++
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/cpp/manage-smartart/
keywords:
- SmartArt
- Tekst SmartArt
- typ układu
- ukryta właściwość
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj tworzenie i edycję SmartArt w PowerPoint przy użyciu Aspose.Slides dla C++ korzystając z przejrzystych przykładów kodu, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint zbudowany z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for C++ możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać układ, przeglądać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć wykresy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeiteruj po [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/get_allnodes/), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) zwrócony przez [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Zmienianie typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczenia i połączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, zmienia go na wartość `BasicProcess` i zapisuje prezentację.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, i sprawdza stan ukrycia węzła.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

W diagramach SmartArt wykorzystujących układ diagramu organizacyjnego, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) oraz [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) określają, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne tak, aby zwisały po lewej, po prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tworzenie diagramu organizacyjnego ze zdjęciem**

Diagram organizacyjny ze zdjęciem to układ SmartArt przeznaczony dla diagramów hierarchicznych, które zawierają miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt do slajdu.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lub odwrócenie dla języków RTL?**

Tak. Metoda [SmartArt::set_IsReversed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/set_isreversed/) zmienia kierunek diagramu z left-to-right na right-to-left lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [sklonować kształt SmartArt](/slides/pl/cpp/shape-manipulations/) za pomocą [ShapeCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapecollection/addclone/) lub [sklonować cały slajd](/slides/pl/cpp/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, położenie i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu na stronę internetową?**

[Wyrenderuj slajd](/slides/pl/cpp/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw charakterystyczną wartość [Shape::set_AlternativeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/set_alternativetext/) lub [Shape::set_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/set_name/) na kształcie SmartArt, wyszukaj tę wartość w [BaseSlide::get_Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseslide/get_shapes/), a następnie sprawdź, czy pasujący kształt jest typu [ISmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/ismartart/).