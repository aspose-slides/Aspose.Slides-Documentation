---
title: Настройка 3D диаграмм в презентациях на Android
linktitle: 3D Диаграмма
type: docs
url: /ru/androidjava/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3-D диаграммы в Aspose.Slides для Android через Java, с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---

## **Установить свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for Android via Java предоставляет простой API для задания этих свойств. В этой статье показано, как установить различные свойства, такие как **X,Y Rotation, DepthPercents** и т.д. Пример кода демонстрирует задание перечисленных свойств.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получить первый слайд.
1. Добавить диаграмму с данными по умолчанию.
1. Установить свойства Rotation3D.
1. Сохранить изменённую презентацию в файл PPTX.
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
    
    // Выбрать вторую серию диаграммы
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Теперь заполняем данные серии
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Установить значение OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Сохранить презентацию на диск
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100% Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Для точного и актуального списка см. члены [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) в справочнике API вашей установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение через [chart API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) или [render the entire slide](/slides/ru/androidjava/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен пиксельный просмотр или требуется встроить диаграмму в документы, панели мониторинга или веб‑страницы без использования PowerPoint.

**Насколько производительно создание и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов ограничьте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности уменьшайте количество точек данных в серии и рендерите в размер, соответствующий целевому экрану или печати.