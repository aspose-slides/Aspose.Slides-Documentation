---
title: Диаграмма
type: docs
weight: 60
url: /ru/nodejs-java/examples/elements/chart/
keywords:
- пример кода
- диаграмма
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте работу с диаграммами в Aspose.Slides for Node.js via Java: создавайте, форматируйте, привязывайте данные и экспортируйте диаграммы в PPT, PPTX и ODP с примерами на JavaScript."
---
Примеры добавления, доступа, удаления и обновления разных типов диаграмм с помощью **Aspose.Slides for Node.js via Java**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## **Add a Chart**

Этот метод добавляет простую областную диаграмму на первый слайд.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Добавьте простую областную диаграмму на первый слайд.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Chart**

После создания диаграммы вы можете получить её через коллекцию фигур.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Доступ к первой диаграмме на слайде.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Chart**

Следующий код удаляет диаграмму со слайда.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Удалить диаграмму.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Update Chart Data**

Вы можете изменить свойства диаграммы, такие как заголовок.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Изменить заголовок диаграммы.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```