---
title: Android पर प्रस्तुतियों में चार्ट धुरियों को अनुकूलित करें
linktitle: चार्ट धुरी
type: docs
url: /hi/androidjava/chart-axis/
keywords:
- चार्ट धुरी
- लंबवत धुरी
- क्षैतिज धुरी
- धुरी को अनुकूलित करें
- धुरी को संचालित करें
- धुरी का प्रबंधन
- धुरी गुण
- अधिकतम मान
- न्यूनतम मान
- धुरी रेखा
- तिथि स्वरूप
- धुरी शीर्षक
- धुरी स्थिति
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट धुरियों को अनुकूलित करने हेतु Java के माध्यम से Android के लिए Aspose.Slides का प्रयोग कैसे करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android via Java के साथ चार्ट धुरियों को अनुकूलित करने का तरीका बताता है। इसमें गणना किए गए धुरी मान, चार्ट पंक्तियों और स्तंभों का परिवर्तन, धुरी का दृश्यमान होना, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियां और फ़ॉर्मेटिंग, शीर्षक का घुमाव, धुरी की स्थिति, डिस्प्ले इकाइयाँ, और लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट में लंबवत धुरी पर अधिकतम मान प्राप्त करें**

Create a [प्रेजेंटेशन](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) and add an area chart with default data. Call [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) before reading calculated axis values so that the chart layout is up to date.

Read [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) and [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) for the axis limits, and [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) and [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) for the tick intervals. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) and [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) provide time-unit scales, which are relevant to date axes. The example stores these values in local variables and saves the chart.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **धुरियों के बीच डेटा बदलें**

Use [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) to exchange the roles of series and categories in chart data. Each former category becomes a series, and each former series becomes a category. This changes how the data is grouped; it does not exchange the horizontal and vertical axes. The example uses [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) to bind the default data to `Sheet1!A1:D5`, including the header row and category column, before switching rows and columns. It saves a chart with four series and three categories.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **धुरी की प्लॉटिंग क्रम को उलटें**

Use [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) to reverse a category or value axis. For example, a horizontal bar chart can show project stages from top to bottom in the same order as the worksheet: Planning, Development, Testing. Reversing an axis changes the plotting direction; it does not sort or rearrange the workbook data. By comparison, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) exchanges the roles of series and categories.

The following example creates a horizontal bar chart with three stages and one series. It saves a presentation with three slides: normal order, reversed categories, and reversed values. Each copy uses the same dataset, and only one axis is reversed on each copy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // स्लाइड 2: पहली श्रेणी को शीर्ष पर प्रदर्शित करें।
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान धुरी को नीचे रखें।
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Reversing an axis can also move the perpendicular axis to the opposite side of the plot. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) controls where the other axis crosses the axis being configured. In slide 2, calling it with `CrossesType.Maximum` on the reversed category axis keeps the horizontal value axis at the bottom. For a specific crossing point, use [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Check the crossing settings when changing direction, especially if the chart already has a custom crossing point. Call `setPlotOrderReversed` with `false` to restore the normal plotting direction; crossing settings are separate.

| सामान्य क्रम (स्लाइड 1) | उलटी श्रेणियाँ (स्लाइड 2) | उलटे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान धुरी क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे की ओर प्रदर्शित श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उलटे मान धुरी और दाएँ शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण ऊपर से नीचे तक चलते हैं। मान और वर्कबुक पंक्तियों का क्रम नहीं बदला है। | श्रेणियों का सामान्य क्रम बना रहता है; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी धुरी दाएँ ओर शून्य पर पार करती है। |

## **लाइन चार्ट्स के लिए लंबवत धुरी को अक्षम करें**

Call [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) with `false` on the vertical axis to hide it. The example creates a line chart with default data and saves it with the vertical axis hidden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लाइन चार्ट्स के लिए क्षैतिज धुरी को अक्षम करें**

Call [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) with `false` on the horizontal axis to hide it. The example creates a line chart with default data and saves it with the horizontal axis hidden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक श्रेणी धुरी बदलें**

Use [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) to choose a date or text category axis. This example requires `ExistingChart.pptx`, with a chart as the first shape on the first slide and category cells containing numeric Excel date values. It changes the horizontal axis to a date axis. Calling [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) with `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) with `1`, and [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) with `TimeUnitType.Months` places major ticks at one-month intervals.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी धुरी लेबल अंतराल नियंत्रित करें**

When a chart has many categories, reduce the number of visible axis labels without removing categories or data points. Call [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) with `false`, then pass the desired category interval to [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). For text categories in their normal order, counting starts at the first category:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

An interval of `3` displays every third label, leaving two labels hidden between displayed labels. It does not remove the corresponding columns. Automatic spacing chooses an interval based on the available space; it does not necessarily display every label.

Tick marks have separate controls. Call [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) with `false` and use [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) to set their interval. For example, `1` keeps a tick mark at every category interval while labels appear only every third category. Use [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) with a visible style so you can see the result. Calling either automatic-spacing setter with `true` again lets the chart choose that interval again.

The following self-contained example creates 24 categories and one series, then saves three slides in `CategoryAxisIntervals.pptx`: automatic spacing, manual label spacing with independent tick marks, and restored automatic spacing. The two copies retain the original chart data. No input presentation is required. Horizontal label text makes the difference in density easy to see.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन हर श्रेणी के लिए एक टिक‑मार्क रखें।
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**स्वचालित स्पेसिंग (स्लाइड 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![सभी 24 कॉलम दृश्यमान के साथ स्वचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![सभी 24 कॉलम दृश्यमान के साथ मैन्युअल श्रेणी लेबल अंतराल तीन](category-axis-manual.png)

### **सही धुरी और अंतराल चुनें**

Use this category-count interval for a text category axis, such as the category axis of a column, line, area, or bar chart. In a column chart, it is the horizontal axis. In a horizontal bar chart, the category axis is vertical, so apply these settings to the axis returned by [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Tick-mark spacing also applies to a series axis in charts that have one.

Do not use category label spacing to set the numeric scale of a value axis. On a value axis, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) specifies a difference in values: for example, a major unit of `10` produces ticks at 0, 10, 20, and so on when the axis starts at zero. A category label interval of `3` instead counts category positions, regardless of their data values. Scatter and bubble charts use value axes rather than a text category axis. For a date axis, use time-based major units and scales as described in [Change a Category Axis](#change-a-category-axis).

## **श्रेणी धुरी मानों के लिए तिथि प्रारूप सेट करें**

The example replaces the default chart data with four annual values. Dates are stored as OLE Automation serial numbers in the first worksheet (index `0`), calculated as the number of days since December 30, 1899, for these dates. Both calendars use UTC and are cleared before setting the dates so daylight saving time and the current time of day do not affect the calculation. Use [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) with `CategoryAxisType.Date`, call [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) with `false`, and pass `yyyy` to [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) so the category labels display four-digit years independently of the cell formatting.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक चार्ट धुरी शीर्षक के लिए घूर्णन कोण सेट करें**

Call [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) with `true` on the vertical axis, provide title text, and use [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) to rotate the title. The angle is measured in degrees; this example saves a column chart with its value-axis title rotated by 90 degrees.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी या मान धुरी पर धुरी स्थिति सेट करें**

Use [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) to control whether the value axis crosses the category axis between categories or at category tick marks. This setting applies to category axes. The example sets it to `true` on the horizontal category axis of a column chart and saves the result.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट मान धुरी पर डिस्प्ले इकाई सेट करें**

Use [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) to scale the labels on a value axis without changing the underlying data. With [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) set to `Millions`, a value of 60,000,000 is displayed as 60. The example creates a column chart and applies the millions display unit to its vertical axis.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक लघुगणकीय मान धुरी कॉन्फ़िगर करें**

A logarithmic value axis is useful when positive values span several orders of magnitude. For example, a service might receive 10, 100, 1,000, 10,000, and 100,000 requests over five periods. On a linear scale, the smaller values appear close together near zero. A logarithmic scale makes their relative growth easier to compare: equal distances represent equal ratios rather than equal differences.

Call [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) with `true` on the value axis and use [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) to choose the base. This changes how the existing values are displayed; it does not change the data or add a logarithmic trend line. A trend line represents a fitted relationship in the data and is a separate feature.

### **मान धुरी और आधार चुनें**

For a line or column chart, the value axis is returned by [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). For a horizontal bar chart, it is returned by [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Scatter and bubble charts have two value axes, so choose the horizontal axis for X values, the vertical axis for Y values, or both. Do not apply logarithmic scaling to a category axis.

The default logarithmic base is `10`. For PPTX charts, use a base from `2` through `1000`, inclusive; fractional bases such as `2.5` are also supported. With base `10`, successive powers such as 10, 100, 1,000, and 10,000 are equally spaced.

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

The following self-contained example creates a line chart with the five request counts on the first slide, then clones that slide and enables a base-10 logarithmic value axis on the second. Both slides retain the same data.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // पहली स्लाइड को रैखिक रखें और केवल कॉपी की मान‑धुरी स्केल बदलें।
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**रैखिक स्केल (स्लाइड 1):** Equal vertical distances represent equal differences in request counts. The largest value dominates the chart, making the smaller values difficult to distinguish.

![पावरपॉइंट में रैखिक मान धुरी पर पाँच अनुरोध गिनती दिखाने वाला लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** Equal vertical distances represent equal ratios. Each period has ten times as many requests as the previous one, so the points form a straight rising line on the base-10 scale. The axis labels still show the original request counts.

![पावरपॉइंट में बेस-10 लघुगणकीय मान धुरी पर वही पाँच अनुरोध गिनती](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

A logarithmic scale can display only strictly positive values. Check the data before enabling it. If zero or negative values are meaningful, keep a linear scale or show them separately. If excluding those values is appropriate for the analysis, explain the omission. Do not silently replace them with small positive numbers, as this changes the meaning of the data. Any manually configured minimum or maximum for a logarithmic axis must also be positive.

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक धुरी को दूसरी धुरी के साथ कहाँ क्रॉस हो, वह मान कैसे सेट करूँ?**

Use [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) to select the crossing behavior. To specify a numeric crossing value, use [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). These settings let you move the axis crossing to a suitable baseline.

**मैं टिक लेबल को धुरी के सापेक्ष कैसे स्थित करूँ?**

Call [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) using [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, or `None`. To control the tick marks themselves, use [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) or [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); these are separate from label positioning.