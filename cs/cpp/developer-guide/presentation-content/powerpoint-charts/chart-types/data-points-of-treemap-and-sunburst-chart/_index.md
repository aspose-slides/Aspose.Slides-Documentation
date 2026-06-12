---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst pomocí C++
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf treemap
- graf sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak spravovat datové body v grafech treemap a sunburst pomocí Aspose.Slides pro C++, kompatibilní s formáty PowerPoint."
---
## **Úvod**

Mezi ostatními typy grafů v PowerPointu existují dva „hierarchické“ typy – **Treemap** a **Sunburst** graf (také známý jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph nebo Multi Level Pie Chart). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až po vrchol větve. Listy jsou definovány datovými body řady a každá další vnořená úroveň seskupení je definována odpovídající kategorií. Aspose.Slides pro C++ umožňuje formátovat datové body grafu Sunburst a Treemap v C++.

Zde je graf Sunburst, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Začneme přidáním nového grafu Sunburst do prezentace:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Viz také" %}} 
- [**Vytvoření grafu Sunburst**](/slides/cs/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Pokud je potřeba formátovat datové body grafu, měli bychom použít následující:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/) třídy a [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) metoda poskytují přístup k formátování datových bodů grafů Treemap a Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) se používá pro přístup k víceúrovňovým kategoriím – představuje kontejner objektů [**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/).  
V podstatě jde o obal pro [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) s vlastnostmi přidanými specificky pro datové body.  
Třída [**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/) obsahuje dvě metody: [**get_Format()**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) a [**get_Label()**](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) které poskytují přístup k odpovídajícím nastavením.

## **Zobrazit hodnotu datového bodu**
Zobrazte hodnotu datového bodu „Leaf 4“:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Nastavit popisek a barvu datového bodu**
Nastavte popisek dat „Branch 1“ tak, aby zobrazoval název řady („Series1“) místo názvu kategorie. Poté nastavte barvu textu na žlutou:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Nastavit barvu větve datového bodu**
Změňte barvu větve „Stem 4“:

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

## **Často kladené otázky**

**Mohu změnit pořadí (třídění) segmentů v grafu Sunburst/Treemap?**

Ne. PowerPoint segmenty řadí automaticky (obvykle sestupně podle hodnot a ve směru hodinových ručiček). Aspose.Slides tuto funkci zrcadlí: nelze změnit pořadí přímo; dosáhnout toho lze předzpracováním dat.

**Jak motiv prezentace ovlivňuje barvy segmentů a popisků?**

Barvy grafu dědí [motiv/paletku](/slides/cs/cpp/presentation-theme/) prezentace, pokud výslovně nenastavíte výplně/písma. Pro konzistentní výsledky uzamkněte plné výplně a formátování textu na požadovaných úrovních.

**Zachová export do PDF/PNG vlastní barvy větví a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachována ve výstupních formátech, protože Aspose.Slides provádí vykreslení s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/elementu pro vlastní překrytí nad grafem?**

Ano. Po ověření rozvržení grafu jsou pro elementy dostupné skutečné souřadnice X a Y (například u [DataLabel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/datalabel/)), což usnadňuje přesné umístění překryvů.