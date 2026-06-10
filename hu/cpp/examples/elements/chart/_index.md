---
title: Diagram
type: docs
weight: 60
url: /hu/cpp/examples/elements/chart/
keywords:
- kódpélda
- diagram
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Mesteri diagramok az Aspose.Slides for C++-val: diagramok létrehozása, formázása, adatkapcsolása és exportálása PPT, PPTX és ODP formátumban C++ példákkal."
---
Példák a különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére az **Aspose.Slides for C++** használatával. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első dián.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Egyszerű területdiagram hozzáadása az első diára.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Diagram elérése**

Diagram létrehozása után a alakzatgyűjteményen keresztül kérhető le.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Az első diagram elérése a dián.
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

## **Diagram eltávolítása**

Az alábbi kód egy diagramot távolít el egy diáról.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Távolítsa el a diagramot.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Diagram adatainak frissítése**

Megváltoztathatja a diagram tulajdonságait, például a címet.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // A diagram címének módosítása.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```