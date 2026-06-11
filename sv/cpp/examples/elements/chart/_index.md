---
title: Diagram
type: docs
weight: 60
url: /sv/cpp/examples/elements/chart/
keywords:
- kodexempel
- diagram
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska diagram med Aspose.Slides for C++: skapa, formatera, binda data och exportera diagram i PPT, PPTX och ODP med C++-exempel."
---
Exempel på att lägga till, komma åt, ta bort och uppdatera olika diagramtyper med **Aspose.Slides for C++**. Nedanstående kodsnuttar visar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Denna metod lägger till ett enkelt ytdiagram på den första bilden.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägg till ett enkelt ytdiagram på den första bilden.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Kom åt ett diagram**

Efter att du har skapat ett diagram kan du hämta det via formsamlingen.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Kom åt det första diagrammet på bilden.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Ta bort ett diagram**

Följande kod tar bort ett diagram från en bild.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Ta bort diagrammet.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Uppdatera diagramdata**

Du kan ändra diagramegenskaper, till exempel titeln.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Ändra diagramtiteln.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```