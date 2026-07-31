---
title: Настройка осей диаграмм в презентациях с использованием C++
linktitle: Ось диаграммы
type: docs
url: /ru/cpp/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- положение оси
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для C++ для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм в Aspose.Slides. Показано, как получить фактические значения осей, поменять данные между осями, скрыть вертикальную или горизонтальную ось для линейных диаграмм, изменить тип оси категорий, задать формат даты для значений оси категорий, повернуть заголовок оси, задать положение оси и отобразить метку единицы измерения на оси значений.

## **Получить максимальные значения на вертикальной оси**
Aspose.Slides для C++ позволяет получить минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите фактическое максимальное значение на оси.
5. Получите фактическое минимальное значение на оси.
6. Получите фактическую основную единицу измерения оси.
7. Получите фактическую вторичную единицу измерения оси.
8. Получите фактический масштаб основной единицы измерения оси.
9. Получите фактический масштаб вторичной единицы измерения оси.

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Сохраняет презентацию
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Перестановка данных между осями**
Aspose.Slides позволяет быстро переставлять данные между осями — данные, отображаемые на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот.

``` cpp
// Создает пустую презентацию
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Переставляет строки и столбцы
chart->get_ChartData()->SwitchRowColumn();

// Сохраняет презентацию
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Отключить вертикальную ось для линейных диаграмм**

Этот код на C++ показывает, как скрыть вертикальную ось для линейной диаграммы:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Отключить горизонтальную ось для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось для линейной диаграммы:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Изменить ось категорий**

С помощью метода **set_CategoryAxisType()** вы можете указать желаемый тип оси категорий (**date** или **text**). Этот код на C++ демонстрирует эту операцию: 

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Установить формат даты для значений оси категорий**
Aspose.Slides для C++ позволяет задать формат даты для значения оси категорий. Операция демонстрируется в этом коде на C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Установить угол поворота заголовка оси**
Aspose.Slides для C++ позволяет задать угол поворота заголовка оси диаграммы. Этот код на C++ демонстрирует эту операцию:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Установить положение оси на оси категорий или значений**
Aspose.Slides для C++ позволяет задать позицию оси на оси категорий или значений. Этот код на C++ показывает, как выполнить задачу:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Включить отображение метки единицы измерения на оси значений диаграммы**
Aspose.Slides для C++ позволяет настроить диаграмму так, чтобы она показывала метку единицы измерения на оси значений. Этот код на C++ демонстрирует эту операцию:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Часто задаваемые вопросы**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/axis/set_crosstype/): вы можете выбрать пересечение в нуле, на максимальном значении категории/значения или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз либо для выделения базовой линии.

**Как разместить подписи делений относительно оси (рядом, снаружи, внутри)?**

Установите [позицию метки](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/axis/set_majortickmark/) в "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно на небольших диаграммах.