---
title: Настройка легенд диаграмм в презентациях с использованием Java
linktitle: Легенда диаграммы
type: docs
url: /ru/java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---

## **Позиционирование легенды**
Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Задайте свойства легенды.
- Сохраните презентацию как файл PPTX.

В приведённом ниже примере мы задали положение и размер легенды диаграммы.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить кластеризованную столбчатую диаграмму на слайд
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Установить свойства легенды
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Сохранить презентацию на диск
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить размер шрифта легенды**
Aspose.Slides for Java позволяет разработчикам задавать размер шрифта легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить размер шрифта отдельного элемента легенды**
Aspose.Slides for Java позволяет разработчикам задавать размер шрифта отдельных элементов легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Могу ли я включить легенду, чтобы диаграмма автоматически выделяла место для неё, а не перекрывала её?**

Да. Используйте режим без перекрытия ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); в этом случае область построения уменьшится, чтобы разместить легенду.

**Могу ли я сделать многострочные метки легенды?**

Да. Длинные метки автоматически переносятся, если места недостаточно; принудительные разрывы строки поддерживаются символами новой строки в имени серии.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте явные цвета/заполнения/шрифты для легенды или её текста. Тогда они будут наследоваться из темы и корректно обновятся при изменении дизайна.