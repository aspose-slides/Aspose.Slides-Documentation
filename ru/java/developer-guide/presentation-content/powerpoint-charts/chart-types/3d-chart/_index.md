---
title: Настройка 3D-диаграмм в презентациях с использованием Java
linktitle: 3D-диаграмма
type: docs
url: /ru/java/3d-chart/
keywords:
- 3D-диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3-D диаграммы в Aspose.Slides для Java с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---

## **Установите свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for Java предоставляет простой API для установки этих свойств. В следующей статье показано, как задать различные свойства, такие как **X, Y Rotation, DepthPercents** и т.д. Пример кода применяет указанные свойства.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите свойства Rotation3D.
1. Запишите изменённую презентацию в файл PPTX.
```java
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить диаграмму с данными по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Установка индекса листа данных диаграммы
    int defaultWorksheetIndex = 0;
    
    // Получение листа данных диаграммы
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Добавить серию
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Добавить категории
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Установить свойства Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Получить вторую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Сейчас заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Установить значение Overlap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Сохранить презентацию на диск
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Для точного и актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение через [chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) или [рендерить весь слайд](/slides/ru/java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это полезно, когда нужен пиксель‑точный предпросмотр или требуется вставить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов минимизируйте 3D‑эффекты, избегайте тяжелых текстур на стенах и областях графика, по возможности ограничивайте количество точек данных в серии и рендерите с подходящим разрешением и размерами, соответствующими требованиям отображения или печати.