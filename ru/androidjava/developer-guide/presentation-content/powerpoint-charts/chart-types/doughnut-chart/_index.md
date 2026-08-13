---
title: Настройка кольцевых диаграмм в презентациях на Android
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/androidjava/doughnut-chart/
keywords:
- кольцевая диаграмма
- центральный разрыв
- размер отверстия
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для Android через Java, поддерживая форматы PowerPoint для динамических презентаций."
---
## **Обзор**

В этой статье показано, как работать с кольцевой диаграммой в Aspose.Slides, добавляя диаграмму на слайд, задавая размер центрального отверстия и сохранять презентацию. Она фокусируется на методе `setDoughnutHoleSize` и демонстрирует базовые шаги, необходимые для настройки этого типа диаграммы в коде.

В статье также приведён краткий раздел FAQ, охватывающий связанные сценарии работы с кольцевой диаграммой, такие как использование нескольких серий для создания нескольких колец, работа с «взорванными» кольцевыми диаграммами и экспорт диаграммы в растровое изображение или SVG.

## **Укажите центральный разрыв в кольцевой диаграмме**
{{% alert color="info" %}} 
Aspose.Slides for Android via Java теперь поддерживает указание размера отверстия в кольцевой диаграмме. В этом разделе мы на примере рассмотрим, как задать размер отверстия в кольцевой диаграмме.
{{% /alert %}} 

Для указания размера отверстия в кольцевой диаграмме выполните следующие шаги:

1. Создайте объект [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
2. Добавьте кольцевую диаграмму на слайд.
3. Укажите размер отверстия в кольцевой диаграмме.
4. Запишите презентацию на диск.

В приведённом ниже примере мы задали размер отверстия в кольцевой диаграмме.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Сохранить презентацию на диск
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Можно ли создать многоуровневую кольцевую диаграмму с несколькими кольцами?

Да. Добавьте несколько серий в одну кольцевую диаграмму — каждая серия станет отдельным кольцом. Порядок колец определяется порядком серий в коллекции.

### Поддерживается ли «взорванная» кольцевая диаграмма (отдельные сегменты)?

Да. Существует тип диаграммы Exploded Doughnut [тип диаграммы](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/charttype/) и свойство взрыва для точек данных; можно отдельными сегментами отделять отдельные части.

### Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?

Диаграмма является фигурой; её можно отрисовать в [растровое изображение](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) или экспортировать диаграмму в [изображение SVG](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).