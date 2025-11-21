---
title: Легенда диаграммы
type: docs
url: /ru/nodejs-java/chart-legend/
---

## **Расположение легенды**

Чтобы задать свойства легенды, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд.
- Добавьте диаграмму на слайд.
- Задайте свойства легенды.
- Сохраните презентацию в файл PPTX.

В приведённом ниже примере мы задали позицию и размер легенды диаграммы.
```javascript
// Создайте экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получите ссылку на слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавьте кластеризованную столбчатую диаграмму на слайд
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Задайте свойства легенды
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Сохраните презентацию на диск
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка размера шрифта легенды**

Aspose.Slides для Node.js via Java позволяет разработчикам задавать размер шрифта легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
```javascript
// Создайте экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка размера шрифта отдельного элемента легенды**

Aspose.Slides для Node.js via Java позволяет разработчикам задавать размер шрифта отдельного элемента легенды. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Создайте диаграмму по умолчанию.
- Получите доступ к элементу легенды.
- Установите размер шрифта.
- Задайте минимальное значение оси.
- Задайте максимальное значение оси.
- Сохраните презентацию на диск.
```javascript
// Создайте экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Можно ли включить легенду так, чтобы диаграмма автоматически выделяла место для неё, а не накладывала её?**

Да. Используйте режим без наложения ([setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)); в этом случае область построения сожмётся, чтобы вместить легенду.

**Можно ли сделать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, если места недостаточно; принудительные разрывы строк поддерживаются символами новой строки в имени серии.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**

Не задавайте явные цвета/заливки/шрифты для легенды или её текста. Они будут наследоваться из темы и корректно обновятся при изменении дизайна.