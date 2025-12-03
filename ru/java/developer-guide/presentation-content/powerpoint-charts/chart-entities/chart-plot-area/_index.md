---
title: Настройка областей построения диаграмм в презентациях на Java
linktitle: Область построения
type: docs
url: /ru/java/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим компоновки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: Узнайте, как настроить области построения диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Java. Улучшайте визуальное оформление слайдов без усилий.
---

## **Получить ширину и высоту области построения диаграммы**
Aspose.Slides for Java предоставляет простой API для .  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) перед получением фактических значений.
1. Получает фактическое положение по оси X (слева) элемента диаграммы относительно левого верхнего угла диаграммы.
1. Получает фактическое положение по оси Y (верх) элемента диаграммы относительно левого верхнего угла диаграммы.
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


## **Установить режим компоновки области построения диаграммы**
Aspose.Slides for Java предоставляет простой API для установки режима компоновки области построения диаграммы. Методы [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) и [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) были добавлены в класс [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) и интерфейс [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Если компоновка области построения задаётся вручную, это свойство определяет, следует ли компоновать область построения по её внутренней части (не включая оси и подписи осей) или внешней части (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) – указывает, что размер области построения определяется размером самой области, без учета делений и подписей осей.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) – указывает, что размер области построения определяется размером области, делений и подписей осей.

Пример кода приведён ниже.
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

**В каких единицах измерения возвращаются фактические x, фактические y, фактическая ширина и фактическая высота?**

В пунктах; 1 дюйм = 72 пункта. Это единицы координат Aspose.Slides.

**Чем отличается область построения от области диаграммы по содержимому?**

Область построения – это регион отображения данных (серии, сетка, линии тренда и т.д.); область диаграммы включает окружающие элементы (заголовок, легенду и т.д.). В 3D‑диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются x, y, ширина и высота области построения при ручной компоновке?**

Это доли (0–1) от общего размера диаграммы; в этом режиме авто‑позиционирование отключено, и используются заданные вами доли.

**Почему позиция области построения изменилась после добавления/перемещения легенды?**

Легенда располагается в области диаграммы за пределами области построения, но влияет на компоновку и доступное пространство, поэтому при включённом авто‑позиционировании область построения может сместиться. (Это стандартное поведение диаграмм PowerPoint.)