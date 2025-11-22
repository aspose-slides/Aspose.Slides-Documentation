---
title: Область построения диаграммы
type: docs
url: /ru/net/chart-plot-area/
keywords: "Область построения диаграммы PowerPoint презентация, C#, Csharp, Aspose.Slides for .NET"
description: "Получить ширину и высоту области построения диаграммы. Установить режим размещения. Презентация PowerPoint на C# или .NET"
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides for .NET предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод IChart.ValidateChartLayout() перед получением фактических значений.
1. Получает фактическое положение X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получает фактическую верхнюю позицию элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получает фактическую ширину элемента диаграммы.
1. Получает фактическую высоту элемента диаграммы.
```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Сохранить презентацию с диаграммой
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **Установить режим размещения области построения диаграммы**
Aspose.Slides for .NET предоставляет простой API для установки режима размещения области построения диаграммы. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если размещение области построения определено вручную, это свойство указывает, размещать область построения внутри (не включая оси и подписи осей) или снаружи (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** - указывает, что размер области построения определяет размер области построения без учёта отметок и подписей осей.
- **LayoutTargetType.Outer** - указывает, что размер области построения определяет размер области построения, отметки и подписи осей.

Пример кода приведён ниже.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**В каких единицах возвращаются ActualX, ActualY, ActualWidth и ActualHeight?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем отличается область построения от области диаграммы по содержимому?**

Область построения — это область рисования данных (серии, линии сетки, линии тренда и т.д.); область диаграммы включает окружающие элементы (заголовок, легенду и т.д.). В 3D‑диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются X, Y, Width и Height области построения при ручном расположении?**

Это доли (0–1) общего размера диаграммы; в этом режиме автоматическое позиционирование отключено, и используются заданные вами доли.

**Почему положение области построения изменилось после добавления/перемещения легенды?**

Легенда размещается в области диаграммы за пределами области построения, но влияет на расположение и доступное пространство, поэтому при включённом автоматическом позиционировании область построения может сдвигаться. (Это стандартное поведение диаграмм PowerPoint.)