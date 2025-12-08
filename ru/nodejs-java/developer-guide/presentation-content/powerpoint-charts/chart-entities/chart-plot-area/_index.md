---
title: Область построения диаграммы
type: docs
url: /ru/nodejs-java/chart-plot-area/
---

## **Получить ширину и высоту области построения диаграммы**

Aspose.Slides for Node.js via Java предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) перед получением фактических значений.
1. Получите фактическое положение X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую позицию сверху элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получите фактическую ширину элемента диаграммы.
1. Получите фактическую высоту элемента диаграммы.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить режим расположения области построения диаграммы**

Aspose.Slides for Node.js via Java предоставляет простой API для установки режима расположения области построения диаграммы. В класс [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) добавлены методы [**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--). Если расположение области построения задаётся вручную, это свойство определяет, следует ли размещать область построения внутри (не включая оси и подписи осей) или снаружи (включая оси и подписи осей). Возможны два значения, определённые в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) — указывает, что размер области построения определяется без учёта делений и подписей осей.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) — указывает, что размер области построения определяется вместе с делениями и подписями осей.

Ниже приведён пример кода.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**В каких единицах возвращаются фактические X, фактические Y, фактическая ширина и фактическая высота?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем область построения отличается от области диаграммы по содержимому?**

Область построения — это регион рисования данных (ряды, линии сетки, линии тренда и т.д.); область диаграммы включает окружающие элементы (заголовок, легенду и т.д.). В 3‑D диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются X, Y, ширина и высота области построения при ручном расположении?**

Это доли (0–1) от общей размерности диаграммы; в этом режиме автоматическое позиционирование отключено, и используются задаваемые вами доли.

**Почему позиция области построения менялась после добавления/перемещения легенды?**

Легенда располагается в области диаграммы за пределами области построения, но влияет на расположение и доступное пространство, поэтому при включённом автоматическом позиционировании область построения может смещаться. (Это стандартное поведение диаграмм PowerPoint.)