---
title: Легенда диаграммы
type: docs
url: /androidjava/chart-legend/
---

## **Позиционирование легенды**
Для настройки свойств легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Настройте свойства легенды.
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы задали позицию и размер для легенды диаграммы.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте колонную диаграмму на слайд
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Установите свойства легенды
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Запишите презентацию на диск
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка размера шрифта легенды**
Aspose.Slides для Android через Java позволяет разработчикам устанавливать размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Создайте стандартную диаграмму.
- Установите размер шрифта.
- Установите минимальное значение по оси.
- Установите максимальное значение по оси.
- Запишите презентацию на диск.

```java
// Создайте экземпляр класса Presentation
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

## **Установка размера шрифта для отдельных записей легенды**
Aspose.Slides для Android через Java позволяет разработчикам устанавливать размер шрифта для отдельных записей легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Создайте стандартную диаграмму.
- Получите доступ к записям легенды.
- Установите размер шрифта.
- Установите минимальное значение по оси.
- Установите максимальное значение по оси.
- Запишите презентацию на диск.

```java
// Создайте экземпляр класса Presentation
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