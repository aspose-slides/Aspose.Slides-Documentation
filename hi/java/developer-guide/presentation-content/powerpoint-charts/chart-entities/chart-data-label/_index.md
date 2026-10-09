---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल्स का प्रबंधन
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
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के बारे में जानें, जिससे स्लाइड्स अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल्स चार्ट श्रृंखलाओं और व्यक्तिगत डेटा बिंदुओं के बारे में जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मानों की पहचान करने और चार्ट को समझने में मदद मिलती है। यह लेख बताता है कि कैसे मानों को फ़ॉर्मेट करें, प्रतिशत दिखाएँ, लेबल टेक्स्ट पढ़ें, अक्ष अधिकतम से परे लेबल्स को नियंत्रित करें, श्रेणी अक्ष लेबल स्पेसिंग समायोजित करें, और पाई चार्ट लेबल्स की स्थिति निर्धारित करें।

## **चार्ट डेटा लेबल्स में डेटा सटीकता सेट करें**

सिरिज मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा टेबल प्रदर्शित करता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल का प्रतिशत के रूप में गणना करें और टेक्स्ट को उस टेक्स्ट फ्रेम में असाइन करें जो [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) द्वारा वापस किया जाता है। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। शून्य कुल वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिन्ह सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत दिखाने के लिए [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत कोशिकाओं से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीली श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मानों की जोड़ी का योग 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0% के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान उपयोग करता है। दोनों श्रृंखलाएँ सफेद, 10 पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

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

## **डेटा लेबल्स के वास्तविक टेक्स्ट को पढ़ें**

[getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) का उपयोग करके डेटा लेबल सेटिंग्स द्वारा निर्मित टेक्स्ट प्राप्त करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या जनरेट किए गए चार्ट को सत्यापित करते समय उपयोगी है। नीचे दिए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम, और मान को जोड़ता है। एक बिंदु अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` को श्रेणी और श्रृंखला नामों के साथ दिखाए। कस्टम टेक्स्ट जनरेट किए गए लेबल टेक्स्ट को प्रतिस्थापित करता है। [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। जब आप केवल दिखाई देने वाले लेबल निकालना चाहते हैं, तो ऊपर दिखाए अनुसार अलग से [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) जाँचें।

## **अक्ष अधिकतम से परे डेटा लेबल्स को नियंत्रित करें**

जब आप मैन्युअल रूप से एक अक्ष रेंज को सीमित करते हैं, तो कुछ डेटा बिंदु उसकी अधिकतम सीमा से अधिक हो सकते हैं। यह नियंत्रित करने के लिए कि उनके डेटा लेबल दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) का उपयोग करें। यह सेटिंग लेबल दृश्यता बदलती है; यह अक्ष रेंज या मूल डेटा मूल्यों को नहीं बदलती।

नीचे दिया उदाहरण 60 और 120 मानों के साथ 2D क्लस्टर्ड कॉलम चार्ट बनाता है। यह लंबवत अक्ष पर [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) को `false` पास करता है और [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) के साथ अधिकतम को 100 सेट करता है। पहला स्लाइड अधिकतम से परे लेबल की अनुमति देता है; उस स्लाइड की एक कॉपी उनमें से इन्हें अक्षम करती है। दोनों स्लाइड `DataLabelsOverMaximum.pptx` में सहेजे जाते हैं।

[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के साथ मान लेबल सक्षम करें। चार्ट-स्तर की सेटिंग स्वयं मान प्रदर्शन को सक्षम नहीं करती या व्यक्तिगत लेबल के अक्षम मान प्रदर्शन को ओवरराइड नहीं करती। यह उदाहरण पूरी श्रृंखला के लिए मानों को सक्षम करता है और [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) का उपयोग करके प्रत्येक कॉलम के बाहरी सिरे पर लेबल रखता है।

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

निम्न छवियाँ Microsoft PowerPoint द्वारा रेंडर किए गए सहेजे गए स्लाइड्स दिखाती हैं। `true` के साथ, लेबल **120** ऊपर की सीमा पर दिखाई देता है; `false` के साथ, यह छिपा रहता है। लेबल **60** दृश्यमान रहता है, अक्ष अधिकतम **100** पर बना रहता है, और दूसरा डेटा बिंदु दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ मान लेबल 120 दिखा रहा है](data-labels-over-maximum-true.png) | ![PowerPoint चार्ट जो अक्ष अधिकतम 100 के साथ मान लेबल 120 को छिपा रहा है](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण 2D कॉलम चार्ट को वैल्यू अक्ष के साथ उपयोग करता है। वैल्यू अक्ष के बिना चार्ट, जैसे कि पाई और डोनट चार्ट, इस प्रकार की सीमित करने के लिए अक्ष अधिकतम नहीं रखते हैं।
{{% /alert %}}

## **एक अक्ष से लेबल दूरी सेट करें**

[setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) का उपयोग करके श्रेणी अक्ष लेबलों और अक्ष के बीच की दूरी को नियंत्रित करें। मान अक्ष लेबलों के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफ़सेट को 500 सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबलों के बजाय श्रेणी अक्ष लेबलों को प्रभावित करती है।

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

पाई चार्ट पर, डेटा लेबल स्थितियों को समायोजित करके स्पेसिंग बेहतर करें और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) का उपयोग करके उसके क्षैतिज और लंबवत ऑफ़सेट को समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

![समायोजित डेटा लेबल स्थिति के साथ पाई चार्ट](pie-chart-adjusted-label.png)

## **कॉलम चार्ट के ऊपर डेटा लेबल्स की कई पंक्तियाँ जोड़ें**

यह उदाहरण प्लॉट एरिया के ऊपर दो पंक्तियों के डेटा लेबल्स के साथ एक कॉलम चार्ट बनाता है। श्रृंखला A दिखाई देने वाले कॉलम दिखाती है, जबकि श्रृंखला B और C अतिरिक्त लेबल प्रदान करती हैं। उनके कॉलम फ़िल और आउटलाइन हटाकर छिपाए जाते हैं। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) मेथड सभी तीन श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए जगह आरक्षित करती हैं। जब [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) डिफ़ॉल्ट स्थितियों की गणना करता है, तो [DataLabel.setX और DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) क्षैतिज संरेखण को बनाये रखते हैं और दो पंक्तियों में लेबल को व्यवस्थित करने के लिए लंबवत ऑफ़सेट लागू करते हैं। संख्याएँ श्रृंखला मूल्यों से जुड़ी डेटा लेबल ही रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप होते हैं।

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
            // B और C की कॉलम को छिपाएँ, लेकिन उनके डेटा लेबल रखे।
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

    // तीनों श्रृंखलाओं को समान श्रेणी केंद्रों के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन का उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // डेटा लेबल्स की दो पंक्तियों के लिए प्लॉट के ऊपर स्थान आरक्षित करें।
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
            // डिफ़ॉल्ट क्षैतिज स्थिति बनाए रखें। Y एक ऑफ़सेट है
            // डिफ़ॉल्ट लेबल स्थिति से, जो चार्ट-ऊँचाई के अंश के रूप में व्यक्त है।
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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट्स में डेटा लेबल ओवरलैप को कैसे रोक सकता हूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइनों और छोटे फ़ॉन्ट आकार को मिलाकर; यदि आवश्यक हो तो कुछ फ़ील्ड छिपाएँ (उदाहरण के लिए, श्रेणी) या केवल अत्यधिक मान या प्रमुख बिंदुओं के लिए लेबल दिखाएँ।

**मैं केवल शून्य, नकारात्मक या खाली मानों के लिए लेबल कैसे अक्षम करूँ?**

लेबल सक्षम करने से पहले डेटा बिंदुओं को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक मान, या गायब मानों के लिए प्रदर्शन बंद करें।

**PDF/छवियों में निर्यात करते समय लेबल शैली को सुसंगत कैसे रखें?**

फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।