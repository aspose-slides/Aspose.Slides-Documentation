---
title: Настройка 3D диаграмм в презентациях с помощью C++
linktitle: 3D Диаграмма
type: docs
url: /ru/cpp/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте 3D диаграммы в презентациях PowerPoint с помощью Aspose.Slides for C++. Регулируйте вращение, пропорции высоты, глубину диаграммы и промежуток между сериями с примерами на C++."
---
## **Обзор**

Aspose.Slides for C++ позволяет настраивать вид 3D‑диаграммы через [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). В этой статье демонстрируется, как настроить вращение, пропорции высоты, глубину, оси под прямым углом и промежуток между сериями, а затем сохранить презентацию в формате PPTX.

## **Установить вращение и глубину 3D‑диаграммы**

Ниже приведён пример, который создаёт [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и использует [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) для добавления сложенной 3D‑столбчатой диаграммы на первый слайд. Он заменяет серии и категории по умолчанию двумя сериями, содержащими по три значения каждая. Индекс листа `0` указывает на первый лист данных диаграммы; строка `0` содержит имена серий, а столбец `0` — метки категорий.

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) и [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) устанавливают вращение диаграммы соответственно в 40 и 270 градусов. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) задаёт её глубину как 150 % от ширины, а [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) включает оси под прямым углом вместо перспективы. Получившаяся презентация содержит заполненную диаграмму с этими настройками 3D‑вида.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Настроить пропорции высоты 3D‑диаграммы**

Используйте [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) для установки высоты 3D‑диаграммы в процентах от её ширины. Это изменяет пропорции 3D‑сцены без изменения размеров объекта диаграммы на слайде.

Следующий пример создаёт диаграмму [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) с данными по умолчанию: три серии и четыре категории. Он сохраняет три презентации с пропорциями высоты 50 %, 100 % и 200 %. Позиция, ширина и высота диаграммы остаются фиксированными. Данные, вращение, глубина, промежуток между сериями и форматирование идентичны во всех трёх файлах; меняется только процент высоты.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Следующие изображения из эквивалентного примера .NET были экспортированы из Microsoft PowerPoint и иллюстрируют одинаковые настройки высоты. При меньшем проценте сцена выглядит более плоской, при большем — более высокой внутри того же объекта диаграммы. PowerPoint также может корректировать интервалы делений осей и размещение подписей для лучшего соответствия сцене.

| Высота: 50% | Высота: 100% | Высота: 200% |
| --- | --- | --- |
| ![3D столбчатая диаграмма с высотой, установленной в 50 % от её ширины](height_percent_50.png) | ![3D столбчатая диаграмма с высотой, установленной в 100 % от её ширины](height_percent_100.png) | ![3D столбчатая диаграмма с высотой, установленной в 200 % от её ширины](height_percent_200.png) |

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Высота 3D‑сцены в процентах от её ширины. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Высота объекта диаграммы на слайде в пунктах. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Глубина 3D‑сцены в процентах от её ширины. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |

Настройка высоты влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая варианты цилиндр, конус и пирамида, а также 3D‑линейные, 3D‑областные, 3D‑круговые и 3D‑поверхностные диаграммы. Сравнение выше использует проверенный тип `Column3D`. Настройка не меняет внешний вид 2D‑диаграммы `ClusteredColumn` или `BubbleWith3D`; эти имена являются членами перечисления [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Для других параметров внешнего вида диаграмм см. [Форматирование диаграмм](/slides/ru/cpp/chart-formatting/).

## **Настроить промежуток между сериями**

Используйте [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) для управления расстоянием между сериями данных вдоль оси глубины 3D‑диаграммы, выраженным в процентах от ширины маркера. Допустимые значения от **0 до 500** включительно: `0` удаляет зазор, более высокие значения увеличивают промежуток. При фиксированной глубине диаграммы увеличение зазора делает маркеры тоньше вдоль оси глубины.

Получите группу через [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Настройка применяется ко всем сериям в этой группе, а не только к серии, через которую был выполнен доступ. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) возвращает значение настройки родительской группы.

Эта настройка влияет на 3D‑столбчатые и 3D‑полосовые диаграммы, включая их цилиндрические, конические и пирамидальные варианты, а также 3D‑линейные и 3D‑областные диаграммы. Внешний вид зависит от того, как серии расположены по глубине: в отдельности, группировано или сложено. Для наглядного сравнения зазоров между отдельными сериями используйте `ChartType::Column3D` из перечисления [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Эти методы управляют различными аспектами диаграммы:

| Метод | Эффект |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Расстояние между сериями вдоль оси глубины, в процентах от ширины маркера. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Расстояние между соседними кластерами столбцов или полос, в процентах от ширины столбца или полосы. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Общая глубина диаграммы, в процентах от её ширины. |

Ниже приведён автономный пример, использующий данные диаграммы по умолчанию (три серии и четыре категории). Он сохраняет две презентации с одинаковыми данными, вращением, шириной зазора и глубиной диаграммы; меняется только глубина зазора.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Следующие изображения из эквивалентного примера .NET были экспортированы из Microsoft PowerPoint и иллюстрируют одинаковые настройки глубины зазора.

| Глубина зазора: 0% | Глубина зазора: 500% |
| --- | --- |
| ![3D столбчатая диаграмма без зазора между сериями вдоль оси глубины](gap_depth_0.png) | ![3D столбчатая диаграмма с зазором 500 % между сериями вдоль оси глубины](gap_depth_500.png) |

## **Изменить тип 3D‑серии и форму столбца**

В кластерной цилиндрической диаграмме первая серия начинается с цилиндрических столбцов. Пример читает [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) и [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) до и после каждого изменения.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Изменение первой серии | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Создать диаграмму | `ClusteredCylinder` | `Cylinder` |
| Вызвать [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) с `ClusteredCone` | `ClusteredCone` | `Cone` |
| Вызвать [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) с `Box` | `ClusteredColumn3D` | `Box` |

Установка формы `Box` также изменяет тип серии на `ClusteredColumn3D`. Если ваш код ветвится в зависимости от типа серии, вызовите `series->get_Type()` после изменения формы. Значение, кэшированное до изменения, всё равно будет выбирать ветку `ClusteredCone`.

![Сравнение в PowerPoint, показывающее первую серию в виде цилиндров, конусов и прямоугольных столбцов слева направо](series-shapes.png)

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Для точного актуального списка проверьте элементы [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) или [отобразить весь слайд](/slides/ru/cpp/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен растровый превью или требуется встроить диаграмму в документы, приборные панели или веб‑страницы без необходимости использовать PowerPoint.

**Насколько эффективно создавать и рендерить большие 3D‑диаграммы?**

Эффективность зависит от объёма данных и визуальной сложности. Для лучшей производительности рекомендуется ограничивать 3D‑эффекты, избегать тяжёлых текстур на стенах и областях построения, минимизировать количество точек данных в каждой серии и рендерить в размере, соответствующем целевому дисплею или печати.