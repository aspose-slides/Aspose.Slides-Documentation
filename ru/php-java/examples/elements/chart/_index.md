---
title: Диаграмма
type: docs
weight: 60
url: /ru/php-java/examples/elements/chart/
keywords:
- диаграмма
- добавить диаграмму
- получить диаграмму
- удалить диаграмму
- обновить диаграмму
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в PHP с помощью Aspose.Slides: добавляйте данные, форматируйте серии, оси и подписи, меняйте типы и экспортируйте—работает с PPT, PPTX и ODP."
---
Примеры добавления, доступа, удаления и обновления различных типов диаграмм с **Aspose.Slides for PHP via Java**. Приведённые ниже фрагменты демонстрируют базовые операции с диаграммами.

## **Добавить диаграмму**

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавьте простую столбчатую диаграмму на слайд.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить диаграмму**

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить первую диаграмму на слайде.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить диаграмму**

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является диаграммой.
        $chart = $slide->getShapes()->get_Item(0);

        // Удалить диаграмму.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Обновить данные диаграммы**

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является диаграммой.
        $chart = $slide->getShapes()->get_Item(0);

        // Изменить заголовок диаграммы.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```