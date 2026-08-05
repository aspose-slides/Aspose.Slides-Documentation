---
title: Dostosowywanie punktów danych w wykresach Treemap i Sunburst przy użyciu C++
linktitle: Punkty danych w wykresach Treemap i Sunburst
type: docs
url: /pl/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- wykres treemap
- wykres sunburst
- punkt danych
- kolor etykiety
- kolor gałęzi
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać punktami danych w wykresach treemap i sunburst przy użyciu Aspose.Slides dla C++, kompatybilnych z formatami PowerPoint."
---
## **Wprowadzenie**

Wśród innych typów wykresów PowerPoint istnieją dwa typy „hierarchiczne” – **Treemap** i **Sunburst** (chart (znany również jako wykres Sunburst, diagram Sunburst, wykres radialny, graf radialny lub wykres kołowy wielopoziomowy)). Te wykresy wyświetlają dane hierarchiczne zorganizowane jako drzewo – od liści do szczytu gałęzi. Liście są definiowane przez punkty danych serii, a każdy kolejny poziom grupowania jest określany przez odpowiednią kategorię. Aspose.Slides for C++ pozwala formatować punkty danych wykresu Sunburst i Treemap w C++.

To jest wykres Sunburst, w którym dane w kolumnie Series1 definiują węzły liści, podczas gdy inne kolumny definiują punkty danych hierarchicznych:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Rozpocznijmy od dodania nowego wykresu Sunburst do prezentacji:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Zobacz także" %}} 
- [**Tworzenie wykresu Sunburst**](/slides/pl/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Jeśli istnieje potrzeba sformatowania punktów danych wykresu, należy użyć następujących:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/) klasy i metoda [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) zapewniają dostęp do formatowania punktów danych wykresów Treemap i Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) jest używany do uzyskiwania dostępu do wielopoziomowych kategorii – reprezentuje kontener obiektów [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/) .  
W zasadzie jest to wrapper dla [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) z właściwościami dodanymi specjalnie dla punktów danych.  
Klasa [**IChartDataPointLevel**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/) posiada dwie metody: [**get_Format()**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) oraz [**get_Label()**](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) które zapewniają dostęp do odpowiednich ustawień.

## **Pokaż wartość punktu danych**

Pokaż wartość punktu danych „Leaf 4”:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ustaw etykietę i kolor punktu danych**

Ustaw etykietę danych „Branch 1”, aby wyświetlała nazwę serii („Series1”) zamiast nazwy kategorii. Następnie ustaw kolor tekstu na żółty:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ustaw kolor gałęzi punktu danych**

Zmień kolor gałęzi „Stem 4”:

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

## **Najczęściej Zadawane Pytania**

**Czy mogę zmienić kolejność (sortowanie) segmentów w wykresie Sunburst/Treemap?**

Nie. PowerPoint sortuje segmenty automatycznie (zazwyczaj malejąco, zgodnie z ruchem wskazówek zegara). Aspose.Slides odzwierciedla to zachowanie: nie można zmienić kolejności bezpośrednio; można to osiągnąć poprzez wstępne przetworzenie danych.

**Jak motyw prezentacji wpływa na kolory segmentów i etykiet?**

Kolory wykresu dziedziczą [motyw/paletę](/slides/pl/cpp/presentation-theme/) prezentacji, chyba że jawnie ustawisz wypełnienia/czcionki. Aby uzyskać spójne wyniki, ustal stałe wypełnienia i formatowanie tekstu na wymaganych poziomach.

**Czy eksport do PDF/PNG zachowa niestandardowe kolory gałęzi i ustawienia etykiet?**

Tak. Podczas eksportu prezentacji ustawienia wykresu (wypełnienia, etykiety) są zachowywane w formatach wyjściowych, ponieważ Aspose.Slides renderuje wykres z zastosowanym formatowaniem.

**Czy mogę obliczyć rzeczywiste współrzędne etykiety/elementu w celu umieszczenia własnej nakładki nad wykresem?**

Tak. Po zwalidowaniu układu wykresu dostępne są rzeczywiste wartości X i Y dla elementów (np. [DataLabel](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/datalabel/)), co ułatwia precyzyjne pozycjonowanie nakładek.