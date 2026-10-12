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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के लिए सीखें, जिससे स्लाइड अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल चार्ट की श्रृंखला और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट समझने में मदद मिलती है। यह लेख बताता है कि मानों को कैसे फ़ॉर्मेट करें, प्रतिशत कैसे दिखाएँ, लेबल टेक्स्ट को कैसे पढ़ें, अक्ष अधिकतम से परे लेबल को कैसे नियंत्रित करें, श्रेणी अक्ष लेबल स्पेसिंग को कैसे समायोजित करें, और पाई चार्ट लेबल की स्थिति कैसे निर्धारित करें।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा वाले एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहली श्रृंखला के लिए वैल्यू लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजारों विभाजक और दो दशमलव अंक दिखाता है बिना मूल मानों को बदले।

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

## **लेबल के रूप में प्रतिशत दिखाएँ**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में जोड़ें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) द्वारा लौटाया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव अंकों के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुन: गणना करें।

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

## **चार्ट डेटा लेबल में प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) को `false` पास करें। यह उदाहरण चार श्रेणियों में लाल और नीले श्रृंखला के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मानों की जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि वर्टिकल अक्ष दो दशमलव अंकों का उपयोग करता है। दोनों श्रृंखलाएँ सफेद, 10 पॉइंट लेबल टेक्स्ट का उपयोग करती हैं।

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

## **डेटा लेबल के वास्तविक टेक्स्ट को पढ़ें**

[getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) का उपयोग करके डेटा लेबल सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल निकालने, प्रस्तुति सामग्री खोजने, या निर्मित चार्ट को वैध करने में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम, और मान को संयोजित करता है। एक बिंदु अपने मान को प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` दिखाए और साथ ही श्रेणी और श्रृंखला नाम भी। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) दोनों मामलों में परिणामस्वरूप लेबल स्ट्रिंग लौटाता है। जब आप केवल दृश्यमान लेबल निकालना चाहते हैं, तो जैसा ऊपर दिखाया गया है, अलग से [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) की जाँच करें।

## **अक्ष अधिकतम से परे डेटा लेबल नियंत्रित करें**

जब आप मैन्युअल रूप से एक अक्ष रेंज को सीमित करते हैं, तो कुछ डेटा बिंदु उसका अधिकतम पार कर सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) का उपयोग करें। यह सेटिंग लेबल की दृश्यता को बदलती है; यह अक्ष रेंज या मूल डेटा मानों को नहीं बदलती। नीचे दिया गया उदाहरण 60 और 120 मानों के साथ एक 2D क्लस्टरड कॉलम चार्ट बनाता है। यह [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) को `false` पास करता है और वर्टिकल अक्ष पर [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) से अधिकतम 100 सेट करता है। पहली स्लाइड अधिकतम से परे लेबल की अनुमति देती है; उस स्लाइड की एक कॉपी उन्हें अक्षम करती है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी जाती हैं।  
[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के साथ वैल्यू लेबल सक्षम करें। चार्ट-स्तर की यह सेटिंग स्वयं वैल्यू डिस्प्ले को सक्षम नहीं करती या व्यक्तिगत लेबल की अक्षम वैल्यू डिस्प्ले को अधिलेखित नहीं करती। यह उदाहरण पूरी श्रृंखला के लिए वैल्यू सक्षम करता है और लेबल को प्रत्येक कॉलम के बाहर के सिरे पर रखने के लिए [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) का उपयोग करता है।

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

निम्न छवियां Microsoft PowerPoint द्वारा रेंडर की गई सहेजी गई स्लाइड्स दिखाती हैं। `true` के साथ, लेबल **120** ऊपर की सीमा पर दिखता है; `false` के साथ, वह छुपा रहता है। लेबल **60** दिखाई रहता है, अक्ष अधिकतम **100** पर रहता है, और दूसरे डेटा बिंदु दोनों मामलों में **120** बना रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ वैल्यू लेबल 120 दिखा रहा है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ वैल्यू लेबल 120 को छुपा रहा है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण वैल्यू अक्ष वाले 2D कॉलम चार्ट का उपयोग करता है। वैल्यू अक्ष के बिना चार्ट, जैसे पाई और डोनट चार्ट, इस प्रकार के अक्ष अधिकतम को सीमित नहीं करते हैं।
{{% /alert %}}

## **अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) का उपयोग करके श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी नियंत्रित करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़ी लेबल के बजाय श्रेणी अक्ष लेबल को प्रभावित करती है।

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

पाई चार्ट पर, डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग बेहतर करें और लीडर लाइनों के लिए जगह बनाएं। यह उदाहरण पहले डेटा बिंदु का मान दिखाता है, उसके लेबल को स्लाइस के बाहर रखता है, और क्षैतिज तथा ऊर्ध्वाधर ऑफसेट को [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) का उपयोग करके समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाले कॉलम चार्ट बनाता है। श्रृंखला A दृश्यमान कॉलम दिखाती है, जबकि श्रृंखला B और श्रृंखला C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम को फ़िल और आउटलाइन हटाकर छिपा दिया जाता है। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) मेथड सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करता है।  
[ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए स्थान आरक्षित करती हैं। [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) के बाद डिफ़ॉल्ट स्थितियों की गणना करने पर, [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) क्षैतिज संरेखण को बरकरार रखती हैं और दो पंक्तियों में लेबल को व्यवस्थित करने के लिए ऊर्ध्वर्‌त ऑफसेट लागू करती हैं। संख्याएँ श्रृंखला मानों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप होते हैं।

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
            // B और C की कॉलम को छिपाएँ, लेकिन उनके डेटा लेबल रखें।
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

    // सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // इस कॉम्पैक्ट उदाहरण के लिए कम ग्रिडलाइन का उपयोग करें।
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
            // डिफ़ॉल्ट क्षैतिज स्थिति रखें। Y इसका ऑफ़सेट है
            // डिफ़ॉल्ट लेबल स्थिति से, जो चार्ट-ऊँचाई के अंश के रूप में व्यक्त किया गया है।
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // केवल पंक्ति शीर्षक एक अलग टेक्स्ट शैप है।
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

![प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल वाले कॉलम चार्ट](multiple-rows-of-labels.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कसघने चार्ट पर डेटा लेबल के ओवरलैप से कैसे बचा सकता हूँ?**  
स्वचालित लेबल प्लेसमेंट, लीडर लाइनों और छोटे फ़ॉन्ट आकार को मिलाएँ; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल अत्यधिक मानों या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए केवल लेबल कैसे अक्षम करूँ?**  
लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद कर दें।

**PDF/इमेज में एक्सपोर्ट करते समय एकसमान लेबल शैली कैसे सुनिश्चित करूँ?**  
फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध हो यह सत्यापित करें ताकि बैकअप फ़ॉन्ट का उपयोग न हो।