---
title: Настройка точек данных в диаграммах Treemap и Sunburst с использованием С++
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- точка данных
- цвет метки
- цвет ветки
- PowerPoint
- презентация
- С++
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах Treemap и Sunburst с помощью Aspose.Slides для С++, совместимого с форматами PowerPoint."
---

Среди других типов диаграмм PowerPoint есть два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные как дерево — от листьев к вершине ветви. Листья задаются точками данных серии, а каждый последующий уровень вложенной группы определяется соответствующей категорией. Aspose.Slides for C++ позволяет форматировать точки данных диаграмм Sunburst и Treemap в C++.

Ниже представлена диаграмма Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой диаграммы Sunburst в презентацию:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы Sunburst**](/slides/ru/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) classes и [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method предоставляют доступ к форматированию точек данных диаграмм Treemap и Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) используется для доступа к многоуровневым категориям — он представляет контейнер объектов [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/).  
По сути это оболочка для [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) со свойствами, специфичными для точек данных.  
Класс [**IChartDataPointLevel**] имеет два метода: [**get_Format()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) и [**get_Label()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/), которые предоставляют доступ к соответствующим настройкам.

## **Показать значение точки данных**
Показать значение точки данных «Leaf 4»:
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить метку и цвет точки данных**
Установить метку данных «Branch 1» так, чтобы отображалось имя серии ("Series1") вместо имени категории. Затем установить цвет текста в желтый:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветки точки данных**
Изменить цвет ветки «Stem 4»:
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

**Могу ли я изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint сортирует сегменты автоматически (обычно по убывающим значениям, по часовой стрелке). Aspose.Slides зеркалирует это поведение: изменить порядок напрямую невозможно; добиться его можно только предварительной обработкой данных.

**Как тема презентации влияет на цвета сегментов и меток?**

Цвета диаграмм наследуют [theme/palette](/slides/ru/cpp/presentation-theme/) презентации, если вы явно не задаете заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на требуемых уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета веток и настройки меток?**

Да. При экспорте презентации настройки диаграммы (заливки, метки) сохраняются в выходных форматах, так как Aspose.Slides рендерит их с примененным форматированием.

**Могу ли я вычислить реальные координаты метки/элемента для пользовательского размещения наложения поверх диаграммы?**

Да. После того как макет диаграммы проверен, доступны реальные X и Y для элементов (например, [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)), что помогает точно позиционировать наложения.