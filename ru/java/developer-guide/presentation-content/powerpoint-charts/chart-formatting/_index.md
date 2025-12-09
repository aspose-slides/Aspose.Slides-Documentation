---
title: Форматирование диаграмм презентации в Java
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/java/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- сущность диаграммы
- свойства диаграммы
- настройки диаграммы
- параметры диаграммы
- свойства шрифта
- скруглённые границы
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Java и сделайте вашу презентацию PowerPoint профессиональной и привлекающей внимание."
---

## **Форматирование объектов диаграммы**
Aspose.Slides for Java позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. В этой статье объясняется, как форматировать различные объекты диаграммы, включая оси категорий и значений.

Aspose.Slides for Java предоставляет простой API для управления различными объектами диаграммы и их форматирования с использованием пользовательских значений:

1. Создать экземпляр класса [**Презентация**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию любого требуемого типа (в этом примере используется ChartType.LineWithMarkers).
1. Получить доступ к оси значений диаграммы и задать следующие свойства:
   1. Установить **формат линии** для основных линий сетки оси значений
   1. Установить **формат линии** для вспомогательных линий сетки оси значений
   1. Установить **формат чисел** для оси значений
   1. Установить **минимум, максимум, основные и вспомогательные деления** для оси значений
   1. Установить **свойства текста** для данных оси значений
   1. Установить **заголовок** для оси значений
   1. Установить **формат линии** для оси значений
1. Получить доступ к оси категорий диаграммы и задать следующие свойства:
   1. Установить **формат линии** для основных линий сетки оси категорий
   1. Установить **формат линии** для вспомогательных линий сетки оси категорий
   1. Установить **свойства текста** для данных оси категорий
   1. Установить **заголовок** для оси категорий
   1. Установить **позиционирование меток** для оси категорий
   1. Установить **угол поворота** меток оси категорий
1. Получить доступ к легенде диаграммы и задать **свойства текста** для неё
1. Отобразить легенды диаграммы без перекрытия диаграммы
1. Получить доступ к **вторичной оси значений** диаграммы и задать следующие свойства:
   1. Включить вторичную **ось значений**
   1. Установить **формат линии** для вторичной оси значений
   1. Установить **формат чисел** для вторичной оси значений
   1. Установить **минимум, максимум, основные и вспомогательные деления** для вторичной оси значений
1. Теперь построить первую серию диаграммы на вторичной оси значений
1. Установить цвет заливки задней стенки диаграммы
1. Установить цвет заливки области построения диаграммы
1. Записать изменённую презентацию в файл PPTX
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление образцовой диаграммы
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

    // Установка позиции меток оси категорий
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

    // Настройка отображения легенд диаграммы без перекрытия диаграммы

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

    // Сохранить презентацию
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка свойств шрифта для диаграммы**
Aspose.Slides for Java поддерживает установку свойств шрифта для диаграммы. Выполните следующие шаги для настройки шрифта диаграммы.

- Создать объект класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
- Добавить диаграмму на слайд.
- Установить высоту шрифта.
- Сохранить изменённую презентацию.

Ниже приведён пример.
```java
// Создать экземпляр класса Presentation
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
Aspose.Slides for Java предоставляет простой API для управления форматом данных диаграммы:

1. Создать экземпляр класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию любого требуемого типа (в этом примере используется **ChartType.ClusteredColumn**).
1. Установить предустановленный числовой формат из возможных предустановленных значений.
1. Пройти по ячейкам данных диаграммы в каждой серии и задать числовой формат данных диаграммы.
1. Сохранить презентацию.
1. Установить пользовательский числовой формат.
1. Пройти по ячейкам данных диаграммы в каждой серии и задать различный числовой формат данных.
1. Сохранить презентацию.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление диаграммы типа сгруппированный столбец по умолчанию
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Доступ к коллекции серий диаграммы
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Перебор каждой серии диаграммы
    for (IChartSeries ser : series) 
    {
        // Перебор каждой ячейки данных в серии
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


Возможные предустановленные значения числового формата вместе с их индексами:

|**0**|Общий|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**
Aspose.Slides for Java поддерживает настройку области диаграммы. Методы [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) и [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) добавлены в интерфейс [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) и класс [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) .

1. Создать объект класса [Презентация](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. Добавить диаграмму на слайд.
1. Установить тип заливки и цвет заливки диаграммы
1. Установить свойство скруглённых углов в **True**.
1. Сохранить изменённую презентацию.

Ниже приведён пример. 
```java
// Создать экземпляр класса Presentation
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

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как справиться с наложением подписей данных?**

Уменьшить размер шрифта, отключить необязательные компоненты подписи (например, категории), изменить смещение/позицию подписи, при необходимости отображать подписи только для выбранных точек или переключить формат на «значение + легенда».

**Можно ли применить градиентные или узорные заливки к сериям?**

Да. Как сплошные, так и градиентные/узорные заливки обычно доступны. На практике используйте градиенты умеренно и избегайте сочетаний, снижающих контраст с сеткой и текстом.