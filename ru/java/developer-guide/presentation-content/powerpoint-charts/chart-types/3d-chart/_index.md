---
title: "Настройка 3D диаграмм в презентациях с помощью Java"
linktitle: "3D-диаграмма"
type: docs
url: /ru/java/3d-chart/
keywords:
- 3D диаграмма
- поворот
- глубина
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3‑D диаграммы в Aspose.Slides для Java с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---

## **Установите свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for Java предоставляет простой API для установки этих свойств. Эта статья поможет вам установить различные свойства, такие как **X,Y Rotation, DepthPercents** и т.п. Пример кода демонстрирует установку указанных свойств.

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
    
    // Добавить серии
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

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Для точного актуального списка см. члены [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) в справке API установленной версии.

**Могу ли я получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) или [render the entire slide](/slides/ru/java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен пиксель‑совершенный предпросмотр или необходимо встроить диаграмму в документы, панели мониторинга или веб‑страницы без использования PowerPoint.

**Насколько эффективна сборка и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для оптимальных результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенках и областях построения, по возможности ограничьте количество точек данных в серии и рендерьте в вывод соответствующего размера (разрешение и размеры), соответствующий целевому отображению или печати.