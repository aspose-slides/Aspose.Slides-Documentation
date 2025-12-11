---
title: Настройка легенд диаграмм в презентациях на Android
linktitle: Легенда диаграммы
type: docs
url: /ru/androidjava/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for Android via Java для оптимизации презентаций PowerPoint с индивидуальным форматированием легенд."
---

## **Позиционирование легенды**
Для установки свойств легенды. Пожалуйста, выполните указанные ниже шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Установите свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы задали позицию и размер легенды диаграммы.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить на слайд кластеризованную столбчатую диаграмму
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
Aspose.Slides для Android через Java позволяет разработчикам установить размер шрифта легенды. Пожалуйста, выполните указанные ниже шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.
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
Aspose.Slides для Android через Java позволяет разработчикам установить размер шрифта отдельного элемента легенды. Пожалуйста, выполните указанные ниже шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Запишите презентацию на диск.
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

**Могу ли я включить легенду так, чтобы диаграмма автоматически выделяла для неё место вместо наложения?**

Да. Используйте режим без наложения ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); в этом случае область построения будет уменьшаться, чтобы разместить легенду.

**Могу ли я сделать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные разрывы строки поддерживаются символами новой строки в имени серии.

**Как заставить легенду следовать цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Тогда они будут наследоваться из темы и корректно обновляться при изменении дизайна.