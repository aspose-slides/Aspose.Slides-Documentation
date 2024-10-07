---
title: Datenpunkte von Treemap- und Sunburst-Diagramm
type: docs
url: /cpp/data-points-of-treemap-and-sunburst-chart/
keywords: "Sunburst-Diagramm"
description: "Sunburst-Diagramm, Sunburst-Diagramm, Sunburst-Chart, Radialdiagramm, Radialgraph oder Multi-Level-Kreisdiagramm mit Aspose.Slides."
---

Unter den verschiedenen Typen von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst-Diagramm, Sunburst-Diagramm, Radialdiagramm, Radialgraph oder Multi-Level-Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten an, die als Baum organisiert sind - von Blättern bis zur Spitze des Zweigs. Blätter werden durch die Serien-Datenpunkte definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für C++ ermöglicht die Formatierung von Datenpunkten im Sunburst-Diagramm und Treemap in C++.

Hier ist ein Sunburst-Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lass uns beginnen, ein neues Sunburst-Diagramm zur Präsentation hinzuzufügen:



``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sunburst-Diagramms**](/slides/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}


Wenn es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) Klassen 
und [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) Methode 
bieten Zugriff zur Formatierung von Datenpunkten von Treemap- und Sunburst-Diagrammen. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
wird verwendet, um auf mehrere Kategorien zuzugreifen - es repräsentiert den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) Objekten. 
Im Grunde genommen ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) mit 
den speziellen Eigenschaften, die für Datenpunkte hinzugefügt wurden. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) hat 
zwei Methoden: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) und 
[**get_Label()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25), 
die Zugriff auf die entsprechenden Einstellungen bieten.
## **Datenpunktwert anzeigen**
Zeige den Wert des Datenpunktes "Leaf 4" an:



``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Datenpunkt-Label und Farbe festlegen**
Setze das Datenpunkt-Label von "Branch 1", um den Seriennamen ("Series1") anstelle des Kategorienamens anzuzeigen. Dann setze die Textfarbe auf Gelb:



``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Datenpunkt-Zweigfarbe festlegen**

Ändere die Farbe des Zweigs "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)