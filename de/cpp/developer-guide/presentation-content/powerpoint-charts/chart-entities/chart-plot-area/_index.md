---
title: Diagramm Plotbereich
type: docs
url: /de/cpp/chart-plot-area/
---

## **Breite und Höhe des Diagramm Plotbereichs erhalten**
Aspose.Slides für C++ bietet eine einfache API für. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode IChart::ValidateChartLayout() auf, um die tatsächlichen Werte zu erhalten.
1. Erhält die tatsächliche X-Position (links) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Oberkante des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Breite des Diagrammelements.
1. Erhält die tatsächliche Höhe des Diagrammelements.

```cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Präsentation mit Diagramm speichern
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Layoutmodus des Diagramm Plotbereichs festlegen**
Aspose.Slides für C++ bietet eine einfache API, um den Layoutmodus des Diagramm Plotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich innerhalb (ohne Achsen und Achsenbeschriftungen) oder außerhalb (einschließlich Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im Enum **LayoutTargetType** definiert sind.

- **LayoutTargetType.Inner** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmen soll, ohne die Tick-Marks und Achsenbeschriftungen.
- **LayoutTargetType.Outer** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick-Marks und die Achsenbeschriftungen bestimmen soll.

Beispielcode ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}