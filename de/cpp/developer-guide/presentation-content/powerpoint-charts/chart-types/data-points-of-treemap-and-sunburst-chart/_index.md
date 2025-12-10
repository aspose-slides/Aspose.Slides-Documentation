---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen mit C++
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Zweigfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für C++ verwalten, kompatibel mit PowerPoint-Formaten."
---

Unter den anderen Diagrammtypen von PowerPoint gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Grafik, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Grafik oder Mehrstufiges‑Kreis‑Diagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für C++ ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in C++.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Beginnen wir damit, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sunburst‑Diagramms**](/slides/de/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Falls ein Bedarf besteht, Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:
Die [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), [IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) Klassen und die [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) Methode bieten Zugriff auf das Formatieren von Datenpunkten von Treemap‑ und Sunburst‑Diagrammen.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) wird verwendet, um mehrstufige Kategorien zuzugreifen – er stellt den Container der [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)‑Objekte dar. Im Wesentlichen ist er ein Wrapper für [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) mit den speziell für Datenpunkte hinzugefügten Eigenschaften.
Die [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)‑Klasse hat zwei Methoden: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) und [**get_Label()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25), die Zugriff auf die entsprechenden Einstellungen bieten.

## **Datenpunktwert anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktbeschriftung und -farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Setzen Sie anschließend die Textfarbe auf Gelb:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe des Datenpunktzweigs festlegen**
Farbe des Zweigs „Stem 4“ ändern:
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

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**  
Nein. PowerPoint sortiert Segmente automatisch (in der Regel nach absteigenden Werten, im Uhrenzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies, indem Sie die Daten vorverarbeiten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**  
Diagrammfarben übernehmen das Präsentationsthema [theme/palette](/slides/de/cpp/presentation-theme/), sofern Sie nicht explizit Füllungen oder Schriftarten setzen. Für konsistente Ergebnisse sollten Sie feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**  
Ja. Beim Exportieren der Präsentation werden Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien beibehalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um ein benutzerdefiniertes Overlay über dem Diagramm zu platzieren?**  
Ja. Nach der Validierung des Diagrammlayouts stehen tatsächliche X‑ und Y‑Koordinaten für Elemente (zum Beispiel für ein [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)) zur Verfügung, die bei der genauen Positionierung von Overlays helfen.