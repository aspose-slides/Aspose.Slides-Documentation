---
title: Управление данными серий диаграмм в презентациях с помощью C++
linktitle: Серии данных
type: docs
url: /ru/cpp/chart-series/
keywords:
- серии диаграмм
- перекрытие серии
- цвет серии
- цвет категории
- имя серии
- точка данных
- зазор серии
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм в C++ для PowerPoint (PPT/PPTX) с практическими примерами кода и рекомендациями по лучшим практикам для улучшения ваших данных в презентациях."
---

Серия — это строка или столбец чисел, отображаемых на диаграмме.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установка перекрытия данных серии**

С помощью метода [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) можно указать, насколько столбцы и колонны должны перекрываться на 2‑D‑диаграмме (диапазон: -100 — 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы.

Используйте метод `get_ParentSeriesGroup()::set_Overlap()` для установки желаемого значения `Overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте сгруппированную колонную диаграмму на слайд.
1. Получите первую серию диаграммы.
1. Получите `ParentSeriesGroup` серии и задайте желаемое значение перекрытия.
1. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как задать перекрытие для серии диаграммы:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Добавляет диаграмму
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Устанавливает перекрытие серии
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Сохраняет файл презентации на диск
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```


## **Изменение цвета данных серии**

Aspose.Slides для C++ позволяет изменить цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте диаграмму на слайд.
1. Получите серию, цвет которой необходимо изменить.
1. Установите предпочтительный тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код C++ показывает, как изменить цвет серии:
```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Изменение цвета категории данных серии**

Aspose.Slides для C++ позволяет изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте диаграмму на слайд.
1. Получите категорию серии, цвет которой необходимо изменить.
1. Установите предпочтительный тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код C++ показывает, как изменить цвет категории серии:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Изменение имени данных серии** 

По умолчанию имена в легенде диаграммы берутся из ячеек, расположенных над каждым столбцом или строкой данных.

В нашем примере (изображение):

* столбцы — *Series 1*, *Series 2* и *Series 3*;
* строки — *Category 1*, *Category 2*, *Category 3* и *Category 4*.

Aspose.Slides для C++ позволяет обновлять или изменять имя серии в данных диаграммы и в легенде.

Этот код C++ показывает, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:
```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


Этот код C++ показывает, как изменить имя серии в легенде через `Series`:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```


## **Установка цвета заливки данных серии**

Aspose.Slides для C++ позволяет установить автоматический цвет заливки для серий диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, используя предпочитаемый тип (в примере ниже использовался `ChartType::ClusteredColumn`).
1. Получите серию диаграммы и установите цвет заливки — Automatic.
1. Сохраните презентацию в файл PPTX.

Этот код C++ показывает, как установить автоматический цвет заливки для серии диаграммы:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Создает сгруппированную столбчатую диаграмму
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Устанавливает автоматический формат заливки серии
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Записывает файл презентации на диск
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```


## **Установка инверсных цветов заливки данных серии**

Aspose.Slides позволяет задать инвертированный цвет заливки для серий диаграммы в области построения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию, используя предпочитаемый тип (в примере ниже использовался `ChartType::ClusteredColumn`).
1. Получите серию диаграммы и установите цвет заливки — invert.
1. Сохраните презентацию в файл PPTX.

Этот код C++ демонстрирует операцию:
```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Добавляет новые серии и категории
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Берет первую серию диаграммы и заполняет её данные.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```



## **Установка инвертированного цвета заливки для серии диаграммы**

Aspose.Slides позволяет задать инвертирование через методы `IChartDataPoint::set_InvertIfNegative()` и `ChartDataPoint.set_InvertIfNegative()`. Когда инвертирование включено, точка данных меняет цвета при получении отрицательного значения.

Этот код C++ демонстрирует операцию:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Очистка значений конкретных точек данных**

Aspose.Slides для C++ позволяет очистить данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по её индексу.
4. Пройдитесь по всем `DataPoints` диаграммы и установите `XValue` и `YValue` в null.
5. Очистите все `DataPoints` для выбранной серии.
6. Запишите изменённую презентацию в файл PPTX.

Этот код C++ демонстрирует операцию:
```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```


## **Установка ширины зазора данных серии**

Aspose.Slides для C++ позволяет задать ширину зазора серии через метод **`set_GapWidth()`** следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Перейдите к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите любую серию диаграммы.
1. Установите свойство `GapWidth`.
1. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как задать ширину зазора серии:
```cpp
// Создает пустую презентацию
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет диаграмму с данными по умолчанию
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Устанавливает индекс листа данных диаграммы
int32_t worksheetIndex = 0;

// Получает лист данных диаграммы
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Добавляет серии
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Добавляет категории
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Получает вторую серию диаграммы
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Заполняет данные серии
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Устанавливает значение GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Сохраняет презентацию на диск
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Есть ли ограничение на количество серий в одной диаграмме?**

Aspose.Slides не накладывает фиксированного ограничения на количество добавляемых серий. Практический предел определяется читаемостью диаграммы и доступной памяти приложения.

**Что делать, если столбцы в кластере находятся слишком близко друг к другу или слишком далеко?**

Отрегулируйте параметр ширины зазора (`gap width`) для этой серии (или её родительской группы серий). Увеличение значения расширяет промежуток между столбцами, уменьшение — сужает его.