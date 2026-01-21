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

Unter anderem gibt es bei PowerPoint-Diagrammen zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Grafik, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Grafik oder Mehrstufiges Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für C++ ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap in C++.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:
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

Falls es notwendig ist, Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) classes und [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method provide access to format data points of Treemap and Sunburst charts.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) wird verwendet, um auf mehrstufige Kategorien zuzugreifen – es stellt den Container von [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/)‑Objekten dar. Im Grunde ist es ein Wrapper für [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) mit den für Datenpunkte spezifisch hinzugefügten Eigenschaften.
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) besitzt zwei Methoden: [**get_Format()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) und [**get_Label()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/), die Zugriff auf die entsprechenden Einstellungen bieten.

## **Wert eines Datenpunkts anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktbeschriftung und -farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Anschließend setzen Sie die Textfarbe auf Gelb:
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

Nein. PowerPoint sortiert Segmente automatisch (in der Regel nach absteigenden Werten, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeiten der Daten.

**Wie beeinflusst das Präsentationsthema die Farben von Segmenten und Beschriftungen?**

Diagrammfarben übernehmen das [theme/palette](/slides/de/cpp/presentation-theme/) der Präsentation, sofern Sie nicht explizit Füllungen/Schriften festlegen. Für konsistente Ergebnisse sollten Sie solide Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben die Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateiformaten erhalten, da Aspose.Slides das Diagramm mit angewendeter Formatierung rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um benutzerdefinierte Überlagerungen über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen für Elemente die tatsächlichen X‑ und Y‑Koordinaten zur Verfügung (z. B. für ein [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)), was bei der genauen Platzierung von Überlagerungen hilft.