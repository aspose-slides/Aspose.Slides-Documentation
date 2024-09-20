---
title: Серия диаграмм
type: docs
url: /cpp/chart-series/
---

Серия – это строка или столбец чисел, нанесенных на диаграмму.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серий диаграммы**

С помощью метода [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) вы можете задать, насколько бары и столбцы должны перекрываться на 2D диаграмме (диапазон: -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы.

Используйте метод `get_ParentSeriesGroup()::set_Overlap()` для установки желаемого значения для `Overlap`. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте кластеризованную столбчатую диаграмму на слайд.
1. Получите доступ к первой серии диаграммы.
1. Получите доступ к `ParentSeriesGroup` серии диаграммы и установите предпочтительное значение перекрытия для серии. 
1. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как установить перекрытие для серии диаграммы:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Добавляет диаграмму
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Устанавливает перекрытие серий
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Записывает файл презентации на диск
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Изменить цвет серии**
Aspose.Slides для C++ позволяет вам изменять цвет серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к серии, цвет которой вы хотите изменить. 
1. Установите предпочтительный тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как изменить цвет серии:

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

## **Изменить цвет категории серии**
Aspose.Slides для C++ позволяет вам изменять цвет категории серии следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Добавьте диаграмму на слайд.
1. Получите доступ к категории серии, цвет которой вы хотите изменить.
1. Установите предпочтительный тип заливки и цвет заливки.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как изменить цвет категории серии:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Изменить имя серии** 

По умолчанию названия легенд для диаграммы – это содержимое ячеек над каждым столбцом или строкой данных. 

В нашем примере (образец изображения), 

* столбцы – это *Серия 1, Серия 2,* и *Серия 3*;
* строки – это *Категория 1, Категория 2, Категория 3,* и *Категория 4.* 

Aspose.Slides для C++ позволяет вам обновить или изменить имя серии в данных диаграммы и легенде. 

Этот код на C++ показывает, как изменить имя серии в данных диаграммы `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"Новое имя"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Этот код на C++ показывает, как изменить имя серии в легенде с помощью `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"Новое имя"));
```

## **Установить цвет заливки серии диаграммы**

Aspose.Slides для C++ позволяет вам установить автоматический цвет заливки для серий диаграммы внутри области графика следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с умолчательными данными на основе вашего предпочтительного типа (в приведенном ниже примере мы использовали `ChartType::ClusteredColumn`).
1. Получите доступ к сериям диаграммы и установите цвет заливки на автоматический.
1. Сохраните презентацию в файл PPTX.

Этот код на C++ показывает, как установить автоматический цвет заливки для серии диаграммы:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Создает кластеризованную столбчатую диаграмму
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Устанавливает формат заливки серий на автоматический
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Записывает файл презентации на диск
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Установить инвертированные цвета заливки серий диаграммы**
Aspose.Slides позволяет вам установить инвертированные цвета заливки для серий диаграммы внутри области графика следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с умолчательными данными на основе вашего предпочтительного типа (в приведенном ниже примере мы использовали `ChartType::ClusteredColumn`).
1. Получите доступ к сериям диаграммы и установите цвет заливки на инвертированный.
1. Сохраните презентацию в файл PPTX.

Этот код на C++ демонстрирует операцию:

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
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Серия 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Категория 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Категория 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Категория 3")));

// Берет первую серию диаграммы и заполняет ее данными.
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


## **Установить инвертацию серии, когда значение отрицательное**
Aspose.Slides позволяет вам устанавливать инвертацию через методы `IChartDataPoint::set_InvertIfNegative()` и `ChartDataPoint.set_InvertIfNegative()`. Когда инвертация установлена с использованием методов, точка данных инвертирует свои цвета, когда получает отрицательное значение. 

Этот код на C++ демонстрирует операцию:

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

## **Очистить данные конкретных точек данных**
Aspose.Slides для C++ позволяет вам очищать данные `DataPoints` для конкретной серии диаграммы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на диаграмму по ее индексу.
4. Переберите все `DataPoints` диаграммы и установите `XValue` и `YValue` в null.
5. Очистите все `DataPoints` для конкретной серии диаграммы.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C++ демонстрирует операцию:

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

## **Установить ширину промежутка серии**
Aspose.Slides для C++ позволяет вам установить ширину промежутка серии с помощью метода **`set_GapWidth()`** следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с умолчательными данными.
1. Получите доступ к любой серии диаграммы.
1. Установите свойство `GapWidth`.
1. Запишите измененную презентацию в файл PPTX.

Этот код на C++ показывает, как установить ширину промежутка серии:

```cpp
// Создает пустую презентацию 
auto presentation = System::MakeObject<Presentation>();

// Получает первый слайд презентации
auto slide = presentation->get_Slides()->idx_get(0);

// Добавляет диаграмму с умолчательными данными
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Устанавливает индекс рабочего листа данных диаграммы
int32_t worksheetIndex = 0;

// Получает рабочий лист данных диаграммы
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Добавляет серии
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Серия 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Серия 2")), chart->get_Type());

// Добавляет категории
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Категория 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Категория 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Категория 3")));

// Берет вторую серию диаграммы
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