---
title: Diagramm
type: docs
weight: 60
url: /de/cpp/examples/elements/chart/
keywords:
- Codebeispiel
- Diagramm
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Meistern Sie Diagramme mit Aspose.Slides für C++: Erstellen, formatieren, Daten binden und Diagramme in PPT, PPTX und ODP exportieren - mit C++-Beispielen."
---
Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for C++**. Die nachfolgenden Schnipsel demonstrieren grundlegende Diagramm-Operationen.

## **Diagramm hinzufügen**

Diese Methode fügt der ersten Folie ein einfaches Flächendiagramm hinzu.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Fügen Sie ein einfaches Flächendiagramm zur ersten Folie hinzu.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Zugriff auf ein Diagramm**

Nach dem Erstellen eines Diagramms können Sie es über die Formsammlung abrufen.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Greifen Sie auf das erste Diagramm der Folie zu.
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

## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Diagramm entfernen.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Diagrammtitel ändern.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```