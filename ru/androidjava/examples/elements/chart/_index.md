---
title: Диаграмма
type: docs
weight: 60
url: /ru/androidjava/examples/elements/chart/
keywords:
- пример кода
- диаграмма
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте диаграммы с Aspose.Slides для Android: создавайте, форматируйте, привязывайте данные и экспортируйте диаграммы в PPT, PPTX и ODP с примерами на Java."
---
Примеры добавления, доступа, удаления и обновления различных типов диаграмм с помощью **Aspose.Slides for Android via Java**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## **Добавить диаграмму**

Этот метод добавляет простую областную диаграмму на первый слайд.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Добавьте простую областную диаграмму на первый слайд.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к диаграмме**

После создания диаграммы её можно получить через коллекцию фигур.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Получить первую диаграмму на слайде.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить диаграмму**

Следующий код удаляет диаграмму со слайда.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Удалить диаграмму.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Обновить данные диаграммы**

Можно изменить свойства диаграммы, например заголовок.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Изменить заголовок диаграммы.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```