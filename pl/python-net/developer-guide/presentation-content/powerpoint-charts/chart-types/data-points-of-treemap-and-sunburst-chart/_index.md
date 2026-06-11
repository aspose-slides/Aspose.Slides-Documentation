---
title: Dostosowanie punktów danych w wykresach Treemap i Sunburst w Pythonie
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst przy użyciu Aspose.Slides dla Pythona poprzez .NET, kompatybilnego z formatami PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint istnieją dwa hierarchiczne — **Treemap** i **Sunburst** (znane również jako wykres Sunburst, diagram Sunburst, wykres radialny, graf radialny lub wykres kołowy wielopoziomowy). Te wykresy wyświetlają dane hierarchiczne zorganizowane jako drzewo — od liści do góry gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny poziom zagnieżdżonej grupy jest definiowany przez odpowiednią kategorię. Aspose.Slides for Python via .NET umożliwia formatowanie punktów danych wykresów Sunburst i Treemap w języku Python.

Poniżej znajduje się wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, a pozostałe kolumny definiują punkty danych hierarchicznych:

![Sunburst chart example](sunburst_example.png)

Rozpocznijmy od dodania nowego wykresu Sunburst do prezentacji:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Zobacz także" %}}
- [**Utwórz wykresy Sunburst**](/slides/pl/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Jeśli musisz sformatować punkty danych wykresu, użyj następujących interfejsów API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/) oraz właściwość [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) zapewniają dostęp do formatowania punktów danych w wykresach Treemap i Sunburst. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) służy do dostępu do kategorii wielopoziomowych; reprezentuje kontener obiektów [ChartDataPointLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/). W zasadzie jest to opakowanie wokół [ChartCategoryLevelsManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartcategorylevelsmanager/) z dodatkowymi właściwościami specyficznymi dla punktów danych. Typ [ChartDataPointLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/) udostępnia dwie właściwości — [format](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/format/) i [label](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdatapointlevel/label/) — które zapewniają dostęp do odpowiednich ustawień.

## **Wyświetlanie wartości punktów danych**

Ta sekcja pokazuje, jak wyświetlić wartość poszczególnych punktów danych w wykresach Treemap i Sunburst. Zobaczysz, jak włączyć etykiety wartości dla wybranych punktów.

Wyświetl wartość punktu danych „Leaf 4”:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Ustawianie etykiet i kolorów punktów danych**

Ta sekcja pokazuje, jak ustawić niestandardowe etykiety i kolory dla poszczególnych punktów danych w wykresach Treemap i Sunburst. Nauczysz się, jak uzyskać dostęp do konkretnego punktu danych, przypisać etykietę oraz zastosować jednolite wypełnienie, aby wyróżnić ważne węzły.

Ustaw etykietę danych „Branch 1”, aby wyświetlała nazwę serii („Series1”) zamiast nazwy kategorii, a następnie ustaw kolor tekstu na żółty:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Ustawianie kolorów gałęzi dla punktów danych**

Użyj kolorów gałęzi, aby kontrolować, jak węzły nadrzędne i podrzędne są wizualnie grupowane w wykresach Treemap i Sunburst. Ta sekcja pokazuje, jak ustawić niestandardowy kolor gałęzi dla konkretnego punktu danych, aby wyróżnić ważne poddrzewa i poprawić czytelność wykresu.

Zmień kolor gałęzi „Stem 4”:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresach Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj według wartości malejących, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można zmienić kolejności bezpośrednio; należy to zrobić, przetwarzając dane wstępnie.

**Jak temat prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą temat/paletę prezentacji [theme/palette](/slides/pl/python-net/presentation-theme/), chyba że jawnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, ustal jednolite wypełnienia i formatowanie tekstu na wymaganych poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu do umieszczenia własnej nakładki na wykresie?**

Tak. Po zwalidowaniu układu wykresu dostępne są właściwości `actual_x`/`actual_y` dla elementów (na przykład dla [DataLabel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.