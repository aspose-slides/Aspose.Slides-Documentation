---
title: Zarządzanie SmartArt w prezentacjach PowerPoint w .NET
linktitle: Zarządzanie SmartArt
type: docs
weight: 10
url: /pl/net/manage-smartart/
keywords:
- SmartArt
- Tekst SmartArt
- Typ układu
- Właściwość ukryta
- Diagram organizacyjny
- Diagram organizacyjny z obrazem
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się tworzyć i edytować SmartArt w PowerPoint przy użyciu Aspose.Slides dla .NET, korzystając z przejrzystych przykładów C#, które przyspieszają projektowanie i automatyzację slajdów."
---
## **Przegląd**

SmartArt to diagram programu PowerPoint składający się z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides dla .NET możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, przeglądać ukryte węzły, konfigurować układy diagramów organizacyjnych oraz tworzyć diagramy organizacyjne z obrazami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać widoczny tekst, przeiteruj [ISmartArt.AllNodes](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartart/allnodes/), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) zwrócony przez [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt określa, jak węzły są rozmieszczane i łączone. Poniższy przykład tworzy obiekt SmartArt z wartością [SmartArtLayoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, zmienia ją na wartość `BasicProcess` i zapisuje prezentację.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Sprawdzanie, czy węzeł SmartArt jest ukryty**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, i sprawdza stan ukrycia węzła.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Pobieranie lub ustawianie układu diagramu organizacyjnego**

Dla diagramów SmartArt używających układu diagramu organizacyjnego, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) określa, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić węzły podrzędne, aby zwisały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/organizationchartlayouttype/).

Poniższy przykład tworzy diagram organizacyjny i ustawia układ pierwszego węzła na wartość [OrganizationChartLayoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Tworzenie diagramu organizacyjnego z obrazem**

Diagram organizacyjny z obrazem to układ SmartArt przeznaczony dla diagramów hierarchicznych zawierających miejsca na obrazy. Użyj wartości [SmartArtLayoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` przy dodawaniu obiektu SmartArt do slajdu.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwracanie dla języków RTL?**

Tak. Właściwość [IsReversed](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartart/isreversed/) zmienia kierunek diagramu z lewej na prawą (left-to-right) na prawą na lewą (right-to-left) lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwracanie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [klonować kształt SmartArt](/slides/pl/net/shape-manipulations/) za pomocą [ShapeCollection.AddClone](https://reference.aspose.com/slides/pl/net/aspose.slides/shapecollection/addclone/) albo [sklonować cały slajd](/slides/pl/net/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, położenie i formatowanie.

**Jak wyrenderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu na stronę?**

[Renderuj slajd](/slides/pl/net/convert-powerpoint-to-png/) lub całą prezentację do formatu PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw unikalną wartość [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/alternativetext/) lub [Name](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/name/) na kształcie SmartArt, wyszukaj tę wartość w [Slide.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide/shapes/), a następnie sprawdź, czy pasujący kształt jest [ISmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartart/).