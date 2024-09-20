---
title: Вычисления графика
type: docs
weight: 50
url: /cpp/chart-calculations/
---

## **Вычислить фактические значения элементов графика**
Aspose.Slides для C++ предоставляет простой API для получения этих свойств. Это поможет вам вычислить фактические значения элементов графика. Фактические значения включают позицию элементов, которые реализуют интерфейс IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) и фактические значения осей (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Сохранение презентации
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Вычислить фактическое положение родительских элементов графика**
Aspose.Slides для C++ предоставляет простой API для получения этих свойств. Методы IActualLayout предоставляют информацию о фактическом положении родительского элемента графика. Необходимо предварительно вызвать метод IChart::ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.

``` cpp
// Создание пустой презентации
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Скрыть информацию из графика**
Эта тема поможет вам понять, как скрыть информацию из графика. Используя Aspose.Slides для C++, вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Сетку** из графика. Ниже приведен пример кода, который показывает, как использовать эти свойства.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Установить диапазон данных для графика**
Aspose.Slides для C++ предоставил самый простой API для установки диапазона данных для графика самым простым способом. Чтобы установить диапазон данных для графика:

- Откройте экземпляр класса Presentation, содержащего график.
- Получите ссылку на слайд, используя его индекс.
- Пройдитесь по всем фигурам, чтобы найти нужный график.
- Получите доступ к данным графика и установите диапазон.
- Сохраните измененную презентацию в виде файла PPTX.

Кодовые примеры ниже показывают, как обновить график.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}