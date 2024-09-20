---
title: Площадка для построения диаграмм
type: docs
url: /cpp/chart-plot-area/
---

## **Получить ширину и высоту площадки для построения диаграмм**
Aspose.Slides для C++ предоставляет простой API для.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод IChart::ValidateChartLayout() перед тем, как получить фактические значения.
1. Получите фактическое положение по оси X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую верхнюю часть элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую ширину элемента диаграммы.
1. Получите фактическую высоту элемента диаграммы.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Сохраните презентацию с диаграммой
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Установить режим компоновки площадки для построения диаграмм**
Aspose.Slides для C++ предоставляет простой API для установки режима компоновки площадки для построения диаграмм. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если компоновка площадки определена вручную, это свойство определяет, следует ли компонировать площадку по ее внутреннему содержимому (не включая оси и метки осей) или снаружи (включая оси и метки осей). Есть два возможных значения, определенных в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** - указывает, что размер площадки для построения должен определять размер площадки, не включая метки и оси.
- **LayoutTargetType.Outer** - указывает, что размер площадки для построения должен определять размер площадки, включая метки и оси.

Пример кода приведен ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}