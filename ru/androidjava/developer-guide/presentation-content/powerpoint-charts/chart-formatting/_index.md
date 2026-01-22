---
title: Форматирование диаграмм презентаций на Android
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/androidjava/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Android через Java и повысите уровень вашей презентации PowerPoint с профессиональным, привлекающим внимание стилем."
---

## **Форматирование элементов диаграммы**
Aspose.Slides for Android via Java позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. Эта статья объясняет, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides for Android via Java предоставляет простой API для управления различными элементами диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и любым желаемым типом (в этом примере мы используем ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и установите следующие свойства:
   1. Установка **Line format** для основных линий сетки оси значений
   1. Установка **Line format** для вспомогательных линий сетки оси значений
   1. Установка **Number Format** для оси значений
   1. Установка **Min, Max, Major and Minor units** для оси значений
   1. Установка **Text Properties** для данных оси значений
   1. Установка **Title** для оси значений
   1. Установка **Line Format** для оси значений
1. Получите доступ к оси категорий диаграммы и установите следующие свойства:
   1. Установка **Line format** для основных линий сетки оси категорий
   1. Установка **Line format** для вспомогательных линий сетки оси категорий
   1. Установка **Text Properties** для данных оси категорий
   1. Установка **Title** для оси категорий
   1. Установка **Label Positioning** для оси категорий
   1. Установка **Rotation Angle** для подписей оси категорий
1. Получите доступ к легенде диаграммы и установите **Text Properties** для неё
1. Установите отображение легенд диаграммы без наложения на диаграмму
1. Получите доступ к **Secondary Value Axis** диаграммы и установите следующие свойства:
   1. Включите вторичную **Value Axis**
   1. Установка **Line Format** для вторичной оси значений
   1. Установка **Number Format** для вторичной оси значений
   1. Установка **Min, Max, Major and Minor units** для вторичной оси значений
1. Теперь построьте первую серию диаграммы на вторичной оси значений
1. Установите цвет заливки задней стены диаграммы
1. Установите цвет заливки области построения диаграммы
1. Запишите изменённую презентацию в файл PPTX
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление примерной диаграммы
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Установка заголовка диаграммы
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка формата основных линий сетки для оси значений
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Установка формата вспомогательных линий сетки для оси значений
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Установка числового формата оси значений
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Установка максимальных и минимальных значений диаграммы
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Установка текстовых свойств оси значений
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Установка заголовка оси значений
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка формата основных линий сетки для оси категорий
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Установка формата вспомогательных линий сетки для оси категорий
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Установка текстовых свойств оси категорий
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Установка заголовка категории
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка положения меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Установка угла поворота меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Установка текстовых свойств легенд
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Отображать легенды диаграммы без наложения на диаграмму

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Установка вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Установка числового формата вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Установка максимальных и минимальных значений диаграммы
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Установка цвета задней стенки диаграммы
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Установка цвета области построения
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Сохранение презентации
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить свойства шрифта для диаграммы**
Aspose.Slides for Android via Java предоставляет поддержку установки свойств шрифта для диаграммы. Пожалуйста, выполните следующие шаги для установки свойств шрифта диаграммы.

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Ниже приведён пример.
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить числовой формат**
Aspose.Slides for Android via Java предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и любым желаемым типом (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный числовой формат из доступных значений.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте числовой формат данных.
1. Сохраните презентацию.
1. Установите пользовательский числовой формат.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте отдельный числовой формат данных.
1. Сохраните презентацию.
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получите первый слайд презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление диаграммы кластерных столбцов по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Получение коллекции серий диаграммы
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Перебор всех серий диаграммы
    for (IChartSeries ser : series) 
    {
        // Перебор всех ячеек данных в серии
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Установка числового формата
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Сохранение презентации
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Возможные предустановленные значения числового формата вместе с их индексами, которые можно использовать, приведены ниже:

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Установить скруглённые границы области диаграммы**
Aspose.Slides for Android via Java поддерживает установку области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) добавлены в интерфейс [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) и класс [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart) .

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Добавьте диаграмму на слайд.
1. Установите тип и цвет заливки диаграммы
1. Установите свойство скруглённых углов в значение True.
1. Сохраните изменённую презентацию.

Ниже приведён пример.
```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли установить полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для улучшения читаемости сетки и данных в плотных визуализациях.

**Как справиться с наложением подписей данных?**

Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), задайте смещение/позицию подписи, при необходимости отображайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Можно ли применять градиентные или шаблонные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/шаблонные заливки. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контраст с сеткой и текстом.