---
title: Легенда графика
type: docs
url: /java/chart-legend/
---

## **Позиционирование легенды**
Для настройки свойств легенды выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте график на слайд.
- Настройте свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведенном ниже примере мы установили позицию и размер для легенды графика.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите ссылку на слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавьте групповой столбчатый график на слайд
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

## **Настройка размера шрифта легенды**
Aspose.Slides для Java позволяет разработчикам устанавливать размер шрифта легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создайте график по умолчанию.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Сохраните презентацию на диск.

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

## **Настройка размера шрифта отдельных элементов легенды**
Aspose.Slides для Java позволяет разработчикам устанавливать размер шрифта отдельных элементов легенды. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Создайте график по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Установите минимальное значение оси.
- Установите максимальное значение оси.
- Сохраните презентацию на диск.

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