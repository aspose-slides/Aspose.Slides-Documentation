---
title: Diagramm-Berechnungen
type: docs
weight: 50
url: /cpp/chart-calculations/
---

## **Berechnung der tatsächlichen Werte von Diagrammelementen**
Aspose.Slides für C++ bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die tatsächlichen Werte von Diagrammelementen zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout-Interface implementieren (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) und die tatsächlichen Achsenwerte (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Präsentation speichern
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Berechnung der tatsächlichen Position von übergeordneten Diagrammelementen**
Aspose.Slides für C++ bietet eine einfache API zum Abrufen dieser Eigenschaften. Methoden von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist erforderlich, die Methode IChart::ValidateChartLayout() vorher aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.

``` cpp
// Leere Präsentation erstellen
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Informationen aus dem Diagramm ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Sie Informationen aus dem Diagramm ausblenden können. Mit Aspose.Slides für C++ können Sie **Titel, vertikale Achse, horizontale Achse** und **Rasterlinien** aus dem Diagramm ausblenden. Das folgende Codebeispiel zeigt, wie Sie diese Eigenschaften verwenden können.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Datenbereich für das Diagramm festlegen**
Aspose.Slides für C++ hat die einfachste API bereitgestellt, um den Datenbereich für das Diagramm auf die einfachste Weise festzulegen. Um den Datenbereich für das Diagramm festzulegen:

- Öffnen Sie eine Instanz der Klasse Präsentation, die das Diagramm enthält.
- Erhalten Sie das Referenz eines Slides, indem Sie seinen Index verwenden.
- Durchlaufen Sie alle Shapes, um das gewünschte Diagramm zu finden.
- Greifen Sie auf die Diagrammdaten zu und legen Sie den Bereich fest.
- Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Die folgenden Codebeispiele zeigen, wie man ein Diagramm aktualisiert.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}