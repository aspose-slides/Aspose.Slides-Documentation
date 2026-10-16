---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/java/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के बारे में सीखें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे स्वरूपित किया जाए, प्रतिशत कैसे दिखाए जाएँ, लेबल टेक्स्ट कैसे पढ़ा जाए, अक्ष अधिकतम से परे लेबल को कैसे नियंत्रित किया जाए, श्रेणी अक्ष लेबल स्पेसिंग कैसे समायोजित की जाए, और पाई चार्ट लेबल की स्थिति कैसे निर्धारित की जाए।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

[setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) का उपयोग करके सीरीज़ मानों को स्वरूपित करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसका डेटा टेबल प्रदर्शित करता है, और पहली सीरीज़ के लिए मान लेबल सक्रिय करता है। स्वरूप `#,##0.00` हजारों विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लेबल के रूप में प्रतिशत प्रदर्शित करें**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) द्वारा लौटाया गया है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8‑पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से भाग देने से बचने के लिए छोड़ दिया जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट को पुनः गणना करें।

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट डेटा लेबल में प्रतिशत चिन्ह सेट करें**

जब मान अंश के रूप में संग्रहीत हों, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) का उपयोग करें। लेबल स्वरूप को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) में `false` पास करें।

यह उदाहरण चार श्रेणियों के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है, जिसमें लाल और नीली सीरीज़ हैं। प्रत्येक मान का जोड़ा 1 के बराबर होता है। लेबल स्वरूप `0.0%` 0.30 को 30.0% दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10‑पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

[getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) का उपयोग करके डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या निर्मित चार्ट को मान्य करने में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [डेटा लेबल स्वरूप](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक पॉइंट अपना मान प्रतिशत के रूप में स्वरूपित करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) से कस्टम टेक्स्ट उपयोग करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` श्रेणी और सीरीज़ नामों के साथ दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। केवल दृश्य लेबल निकालना चाहते हैं तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) को अलग से जांचें।

## **अक्ष अधिकतम से परे डेटा लेबल को नियंत्रित करें**

जब आप मैन्युअल रूप से अक्ष रेंज सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसका अधिकतम पार कर सकते हैं। तय करें कि उनके डेटा लेबल दिखाए जाएँ या नहीं, इसके लिए [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) का उपयोग करें। यह सेटिंग लेबल की दृश्यता बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती।

निम्न उदाहरण 60 और 120 मानों वाला 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) में `false` पास करता है और वर्टिकल अक्ष पर [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) से अधिकतम 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उसकी एक प्रति उन्हें निष्क्रिय करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।

[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के साथ मान लेबल सक्रिय करें। चार्ट‑स्तर की यह सेटिंग स्वयं मान प्रदर्शन को सक्रिय नहीं करती और न ही व्यक्तिगत लेबल के निष्क्रिय मान प्रदर्शन को ओवरराइड करती है। यह उदाहरण पूरी सीरीज़ के लिए मान सक्रिय करता है और [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) का उपयोग करके लेबल को प्रत्येक कॉलम के बाहर के अंत में रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर की गई सहेजी गई स्लाइडें दिखाती हैं। `true` के साथ लेबल **120** ऊपरी सीमा पर दिखाई देता है; `false` के साथ वह छुपा रहता है। लेबल **60** दिखाई रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![अक्ष अधिकतम 100 के साथ मान लेबल 120 दिखाने वाला PowerPoint चार्ट](data-labels-over-maximum-true.png) | ![अक्ष अधिकतम 100 के साथ मान लेबल 120 छुपाने वाला PowerPoint चार्ट](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण मूल्य अक्ष के साथ 2D कॉलम चार्ट का उपयोग करता है। ऐसे चार्ट जिनमें मूल्य अक्ष नहीं होता, जैसे पाई और डोनट चार्ट, इस प्रकार के अक्ष अधिकतम को सीमित नहीं कर सकते।

{{% /alert %}}

## **अक्ष से लेबल की दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार के प्रतिशत में दिया जाता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग श्रेणी अक्ष लेबल को प्रभावित करती है, न कि व्यक्तिगत डेटा पॉइंट के साथ जुड़े लेबल को।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लेबल स्थान समायोजित करें**

पाई चार्ट में, डेटा लेबल की स्थिति समायोजित करके स्पेसिंग सुधारा जा सकता है और लीडर लाइनों के लिए जगह बनाई जा सकती है।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) तथा [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) का उपयोग करके उसकी क्षैतिज और ऊर्ध्वाधर ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के अनुपात में होते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![समायोजित डेटा लेबल स्थिति वाला पाई चार्ट](pie-chart-adjusted-label.png)

## **लीडर लाइनों को स्वरूपित करें**

जब पाई चार्ट लेबल अपने स्लाइस के बाहर होते हैं, तो लीडर लाइनों से प्रत्येक मान को सही स्लाइस से मिलाना आसान हो जाता है। विरोधी रंग और थोड़ा मोटी रेखा इन कनेक्शन को पढ़ने में मदद करती है, जबकि पारदर्शिता और डैश्ड स्टाइल रेखाओं को दृश्य रूप से कम परेशान करने वाला बनाते हैं।

[getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) का उपयोग करके सीरीज़ की डेटा लेबल कलेक्शन स्तर पर लीडर लाइनों को स्वरूपित करें। `series.getLabels().getLeaderLinesFormat().getLine()` में सेटिंग्स कलेक्शन पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, स्लाइस के बाहर मान दिखाता है, और [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) सक्रिय करता है। यह दो लेबल को उनके स्लाइस से दूर ले जाने के लिए [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) ऑफ़सेट का उपयोग करता है, जो चार्ट की चौड़ाई और ऊँचाई के अंश में व्यक्त होते हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है।

लाइन की [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) 255 में से 191 α मान के साथ ठोस नीला रंग सेट करती है, जिससे लगभग 25% पारदर्शिता मिलती है। [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) रेखा की मोटाई को 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) रेखा को डैश्ड बनाता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // दो लेबल को उनके स्लाइस से और दूर ले जाएँ।
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(new Color(30, 90, 160, 191));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लीडर लाइनों को सक्षम करने से यह गारंटी नहीं मिलती कि प्रत्येक लेबल के लिए रेखा दिखाई देगी। दृश्यता लेबल के स्थान और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो विस्थापित लेबलों की लीडर लाइने दिखाई देती हैं; जो लेबल अपने स्लाइस के पास रहते हैं, उन्हें उनकी आवश्यकता नहीं होती।

निम्न छवि `FormattedLeaderLines.pptx` को Aspose.Slides द्वारा रेंडर किया गया दिखाती है:

![दो बाहर के लेबल को उनके स्लाइस से जोड़ने वाली नीली, अर्द्धपारदर्शी, डैश्ड लीडर लाइनों वाला पाई चार्ट](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण दो पंक्तियों के डेटा लेबल के साथ एक कॉलम चार्ट बनाता है, जो प्लॉट एरिया के ऊपर स्थित होते हैं। सीरीज़ A दृश्यमान कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल प्रदान करते हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छुपा दिया जाता है। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) मेथड सभी तीन सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) के द्वारा डिफ़ॉल्ट स्थितियों की गणना के बाद, [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल व्यवस्थित करने के लिए ऊर्ध्वाधर ऑफ़सेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैलियों के रूप में होते हैं।

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // B और C की कॉलम को छुपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // तीनों सीरीज़ को समान श्रेणी केंद्रों के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // प्लॉट के ऊपर दो पंक्तियों के डेटा लेबल के लिए स्थान आरक्षित करें।
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y एक ऑफ़सेट है ...
            // ... डिफ़ॉल्ट लेबल स्थिति से, चार्ट-ऊँचाई भाग के रूप में व्यक्त।
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // केवल पंक्ति शीर्षक एक अलग टेक्स्ट आकृति है।
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाला कॉलम चार्ट](multiple-rows-of-labels.png)

## **FAQ**

**घने चार्ट में डेटा लेबल के ओवरलैप को कैसे रोकें?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइनों, और फ़ॉन्ट आकार को घटाकर संयोजन करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) छुपाएँ या केवल अत्यधिक मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक, या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय करें?**

लेबल सक्रिय करने से पहले डेटा पॉइंट फ़िल्टर करें और 0, नकारात्मक मान, या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, जो पूर्व निर्धारित नियम पर आधारित हो।

**PDF/इमेज में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट फ़ैमिली और आकार स्पष्ट रूप से सेट करें और यह सत्यापित करें कि रेंडरिंग पर्यावरण में फ़ॉन्ट उपलब्ध है, ताकि फ़ॉलबैक से बचा जा सके।