---
title: Форматирование диаграмм
type: docs
weight: 60
url: /ru/androidjava/chart-formatting/
---

## **Форматирование сущностей диаграммы**
Aspose.Slides для Android через Java позволяет разработчикам добавлять пользовательские диаграммы на свои слайды с нуля. Эта статья объясняет, как форматировать различные сущности диаграммы, включая оси категорий и значений диаграммы.

Aspose.Slides для Android через Java предоставляет простой API для управления различными сущностями диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и любым желаемым типом (в этом примере мы используем ChartType.LineWithMarkers).
1. Получите доступ к оси значений диаграммы и установите следующие свойства:
   1. Установите **формат линий** для основных сеточных линий оси значений
   1. Установите **формат линий** для вспомогательных сеточных линий оси значений
   1. Установите **формат числа** для оси значений
   1. Установите **мин, макс, основные и вспомогательные единицы** для оси значений
   1. Установите **свойства текста** для данных оси значений
   1. Установите **заголовок** для оси значений
   1. Установите **формат линий** для оси значений
1. Получите доступ к оси категорий диаграммы и установите следующие свойства:
   1. Установите **формат линий** для основных сеточных линий оси категорий
   1. Установите **формат линий** для вспомогательных сеточных линий оси категорий
   1. Установите **свойства текста** для данных оси категорий
   1. Установите **заголовок** для оси категорий
   1. Установите **позиционирование меток** для оси категорий
   1. Установите **угол поворота** для меток оси категорий
1. Получите доступ к легенде диаграммы и установите **свойства текста** для них
1. Убедитесь, что легенды диаграммы не перекрывают диаграмму
1. Получите доступ к **вторичной оси значений** диаграммы и установите следующие свойства:
   1. Включите вторичную **ось значений**
   1. Установите **формат линий** для вторичной оси значений
   1. Установите **формат числа** для вторичной оси значений
   1. Установите **мин, макс, основные и вспомогательные единицы** для вторичной оси значений
1. Теперь постройте первую серию диаграммы на вторичной оси значений
1. Установите цвет заливки задней стены диаграммы
1. Установите цвет заливки области построения диаграммы
1. Запишите измененную презентацию в файл PPTX

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление примера диаграммы
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Установка заголовка диаграммы
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Пример диаграммы");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка формата основных сеточных линий для оси значений
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Установка формата вспомогательных сеточных линий для оси значений
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Установка формата числа оси значений
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

    // Установка свойств текста для оси значений
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
    valtitle.setText("Основная ось");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка формата основных сеточных линий для оси категорий
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Установка формата вспомогательных сеточных линий для оси категорий
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Установка свойств текста для оси категорий
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
    catTitle.setText("Пример категории");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Установка позиции меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Установка угла поворота меток оси категорий
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Установка свойств текста легенды
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Убедитесь, что легенды диаграммы не перекрывают диаграмму

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Установка вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Установка формата числа вторичной оси значений
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

    // Установка цвета задней стены диаграммы
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

## **Установка свойств шрифта для диаграммы**
Aspose.Slides для Android через Java предоставляет поддержку для установки свойств, связанных со шрифтом, для диаграммы. Пожалуйста, следуйте нижеприведенным шагам для установки свойств шрифта для диаграммы.

- Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните измененную презентацию.

Ниже приведен пример.

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

## **Установка формата чисел**
Aspose.Slides для Android через Java предоставляет простой API для управления форматом данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого желаемого типа (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный формат числа из возможных предустановленных значений.
1. Пройдитесь по ячейкам данных в каждой серии диаграммы и установите формат числа для данных диаграммы.
1. Сохраните презентацию.
1. Установите пользовательский формат числа.
1. Пройдитесь по ячейкам данных внутри каждой серии диаграммы и установите другой формат числа для данных диаграммы.
1. Сохраните презентацию.

```java
// Создайте экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление диаграммы с типом clustered column по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Получение коллекции серий диаграммы
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Пройдите по каждой серии диаграммы
    for (IChartSeries ser : series) 
    {
        // Пройдите по каждой ячейке данных в серии
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Установка формата числа
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Сохранение презентации
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Возможные предустановленные значения формата числа вместе с их индексом и используемыми значениями приведены ниже:

|**0**|Общие|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Красный$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Красный$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|м/д/гг|
|**15**|д-ммм-гг|
|**16**|д-ммм|
|**17**|ммм-гг|
|**18**|ч:мм ДП/ПМ|
|**19**|ч:мм:с ДП/ПМ|
|**20**|ч:мм|
|**21**|ч:мм:с|
|**22**|м/д/гг ч:мм|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Красный-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Красный-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|мм:сс|
|**46**|ч :мм:сс|
|**47**|[мм:сс.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка закругленных границ области диаграммы**
Aspose.Slides для Android через Java предоставляет поддержку для установки области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) были добавлены в интерфейс [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) и класс [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart). 

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Добавьте диаграмму на слайд.
1. Установите тип заливки и цвет заливки диаграммы
1. Установите свойство закругленных углов True.
1. Сохраните измененную презентацию.

Ниже приведен пример. 

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