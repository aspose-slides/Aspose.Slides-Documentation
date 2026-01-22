---
title: Форматирование диаграмм презентации в JavaScript
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/nodejs-java/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённые границы
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Node.js на JavaScript и улучшите свою презентацию PowerPoint с профессиональным, броским оформлением."
---

## **Форматирование элементов диаграммы**

Aspose.Slides for Node.js via Java позволяет разработчикам добавлять пользовательские диаграммы в слайды с нуля. В этой статье объясняется, как форматировать различные элементы диаграммы, включая категориальную и ось значений.

Aspose.Slides for Node.js via Java предоставляет простой API для управления различными элементами диаграммы и их форматирования с помощью пользовательских значений:

1. Создайте экземпляр класса [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого требуемого типа (в этом примере мы используем ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и задайте следующие свойства:
   1. Установка **Line format** для основных линий сетки оси значений
   1. Установка **Line format** для вспомогательных линий сетки оси значений
   1. Установка **Number Format** для оси значений
   1. Установка **Min, Max, Major and Minor units** для оси значений
   1. Установка **Text Properties** для данных оси значений
   1. Установка **Title** для оси значений
   1. Установка **Line Format** для оси значений
1. Получите доступ к категориальной оси диаграммы и задайте следующие свойства:
   1. Установка **Line format** для основных линий сетки категориальной оси
   1. Установка **Line format** для вспомогательных линий сетки категориальной оси
   1. Установка **Text Properties** для данных категориальной оси
   1. Установка **Title** для категориальной оси
   1. Установка **Label Positioning** для категориальной оси
   1. Установка **Rotation Angle** для подписей категориальной оси
1. Получите доступ к легенде диаграммы и задайте **Text Properties** для неё
1. Установите отображение легенд диаграммы без перекрытия графика
1. Получите доступ к **Secondary Value Axis** диаграммы и задайте следующие свойства:
   1. Включить вторичную **Value Axis**
   1. Установка **Line Format** для вторичной оси значений
   1. Установка **Number Format** для вторичной оси значений
   1. Установка **Min, Max, Major and Minor units** для вторичной оси значений
1. Теперь построьте первую серию диаграммы на вторичной оси значений
1. Установите цвет заливки задней стенки диаграммы
1. Установите цвет заливки области построения диаграммы
1. Запишите изменённую презентацию в файл PPTX
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получение первого слайда
    var slide = pres.getSlides().get_Item(0);
    // Добавление образцовой диаграммы
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Установка заголовка диаграммы
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установка формата основных линий сетки оси значений
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Установка формата вспомогательных линий сетки оси значений
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Установка числового формата оси значений
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Установка максимальных и минимальных значений диаграммы
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Установка свойств текста оси значений
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Установка заголовка оси значений
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установка формата основных линий сетки оси категорий
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Установка формата вспомогательных линий сетки оси категорий
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Установка свойств текста оси категорий
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Установка заголовка оси категорий
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Установка позиции меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Установка угла поворота меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Установка свойств текста легенд
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Настроить отображение легенд диаграммы без наложения на диаграмму
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Установка вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Установка числового формата вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Установка максимальных и минимальных значений диаграммы
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Установка цвета задней стенки диаграммы
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Установка цвета области построения
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Сохранить презентацию
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка свойств шрифта для диаграммы**

Aspose.Slides for Node.js via Java поддерживает установку свойств шрифта для диаграммы. Следуйте этим шагам, чтобы задать свойства шрифта.

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Ниже приведён пример.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка формата чисел**

Aspose.Slides for Node.js via Java предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого требуемого типа (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный числовой формат из доступных значений.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте числовой формат данных.
1. Сохраните презентацию.
1. Установите пользовательский числовой формат.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте различный числовой формат данных.
1. Сохраните презентацию.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавить диаграмму группированных столбцов по умолчанию
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Получить коллекцию серий диаграммы
    var series = chart.getChartData().getSeries();
    // Перебрать все серии диаграммы
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Перебрать все ячейки данных в серии
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Установить числовой формат
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Сохранить презентацию
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Возможные предустановленные значения числового формата вместе с их индексами:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**

Aspose.Slides for Node.js via Java поддерживает настройку области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) добавлены в класс [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart).

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы.
1. Установите свойство скруглённых углов в **True**.
1. Сохраните изменённую презентацию.

Ниже приведён пример.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли задать полупрозрачные заливки для столбцов/областей, оставив границы непрозрачными?**

Да. Прозрачность заливки и обводка настраиваются независимо. Это удобно для повышения читаемости сетки и данных в плотных визуализациях.

**Как поступить с подписью данных, если они перекрываются?**

Уменьшить размер шрифта, отключить несущественные компоненты подписи (например, категории), задать смещение/позицию подписи, показывать подписи только для выбранных точек или переключить формат на «значение + легенда».

**Можно ли применять градиентные или узорные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/узорные заливки. На практике используйте градиенты умеренно и избегайте сочетаний, снижающих контрастность с сеткой и текстом.