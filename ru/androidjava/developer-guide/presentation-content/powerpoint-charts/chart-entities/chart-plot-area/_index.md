---
title: Настройка областей построения диаграмм презентаций на Android
linktitle: Область построения
type: docs
url: /ru/androidjava/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим расположения
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как настроить области построения диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Android через Java. Легко улучшайте визуальное оформление слайдов."
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides для Android через Java предоставляет простой API для .

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) перед получением фактических значений.
1. Получает фактическое положение X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получает фактическую позицию сверху элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получает фактическую ширину элемента диаграммы.
1. Получает фактическую высоту элемента диаграммы.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить режим расположения области построения диаграммы**
Aspose.Slides для Android через Java предоставляет простой API для установки режима расположения области построения диаграммы. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea). Если расположение области построения задаётся вручную, это свойство указывает, следует ли размещать область построения внутри (не включая оси и подписи осей) или снаружи (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType) .

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - указывает, что размер области построения определяется размером области построения без учета делений и подписей осей.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - указывает, что размер области построения определяется размером области построения, делений и подписей осей.

Ниже приведён пример кода.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**В каких единицах возвращаются actual x, actual y, actual width и actual height?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем область построения отличается от области диаграммы по содержимому?**

Область построения — это область рисования данных (серии, сетка, линии тренда и т.д.); область диаграммы включает окружающие элементы (заголовок, легенду и т.п.). В 3‑D диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются x, y, ширина и высота области построения при ручном расположении?**

Они задаются в виде долей (0–1) от общего размера диаграммы; в этом режиме авторазмещение отключено и используются указанные вами доли.

**Почему положение области построения меняется после добавления/перемещения легенды?**

Легенда располагается в области диаграммы за пределами области построения, но влияет на расположение и доступное пространство, поэтому область построения может смещаться, когда включено авторазмещение. (Это стандартное поведение диаграмм PowerPoint.)