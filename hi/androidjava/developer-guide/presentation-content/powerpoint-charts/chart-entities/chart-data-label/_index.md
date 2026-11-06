---
title: एन्ड्रॉइड पर प्रस्तुतियों में चार्ट डेटा लेबल्स प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/androidjava/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- एन्ड्रॉइड
- जावा
- Aspose.Slides
description: "एन्ड्रॉइड के लिए जावा के माध्यम से Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के तरीके सीखें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल्स चार्ट सीरीज़ और व्यक्तिगत डेटा पॉइंट्स की जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में सहायता मिलती है। यह लेख मानों के फ़ॉर्मेट, प्रतिशत प्रदर्शित करने, लेबल टेक्स्ट पढ़ने, एक्सिस अधिकतम के बाहर लेबल नियंत्रण, कैटेगरी एक्सिस लेबल स्पेसिंग समायोजित करने, और पाई चार्ट लेबल्स के स्थान निर्धारण के तरीकों को समझाता है।

## **दृश्यमान डेटा लेबल्स की गणना करें**

प्रेजेंटेशन प्रकाशित करने से पहले कितने डेटा लेबल्स दिखाने के लिए सक्षम हैं, यह जांचने के लिए [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getCountOfVisibleDataLabels--) का उपयोग करें। यह [getCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getCount--) से अलग है, जो कलेक्शन में कुल लेबलों की संख्या लौटाता है; यह सीरीज़ डिफ़ॉल्ट और व्यक्तिगत लेबल सेटिंग्स को ध्यान में रखता है।

यह उदाहरण एक कॉलम चार्ट बनाता है जिसमें एक सीरीज़ और तीन डेटा पॉइंट्स होते हैं। यह [getLabels](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getLabels--) के माध्यम से सीरीज़ की लेबल कलेक्शन तक पहुंचता है और सेटिंग बदलने पर दृश्य गणना को प्रिंट करता है: **0, 3, 2, 3**। कुल गणना **3** बनी रहती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesCell = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

    for (int i = 0; i < 3; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IDataLabelCollection labels = series.getLabels();
    System.out.println("Total: " + labels.getCount() + "; visible: " + labels.getCountOfVisibleDataLabels()); // कुल: 3; दृश्यमान: 0

    labels.getDefaultDataLabelFormat().setShowValue(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // दृश्यमान: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(false);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // दृश्यमान: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(true);
    System.out.println("Visible: " + labels.getCountOfVisibleDataLabels()); // दृश्यमान: 3
} finally {
    presentation.dispose();
}
```

सीरीज़ का [getDefaultDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getDefaultDataLabelFormat--) डिफ़ॉल्ट सेटिंग्स प्रदान करता है। वहाँ `true` को [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) में पास करने से सभी तीन लेबल्स के लिए मान प्रदर्शित होते हैं। किसी एक लेबल के [getDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getDataLabelFormat--) के माध्यम से `false` पास करने से चयनित लेबल के लिए यह सेटिंग ओवरराइड हो जाती है। `true` को [setShowLegendKey](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLegendKey-boolean-) में पास करने से वह लेबल फिर से दृश्यमान माना जाता है, जबकि उसका मान छिपा रहता है।

दृश्यमान गणना दृश्यता सेटिंग्स को दर्शाती है। यह नहीं मापती कि लेबल ओवरलैप होते हैं, क्लिप होते हैं, या रेंडर किए गए चार्ट में पढ़ने योग्य हैं या नहीं।

## **चार्ट डेटा लेबल्स में डेटा सटीकता सेट करें**

सीरीज़ मानों को फ़ॉर्मेट करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा वाला एक लाइन चार्ट बनाता है, उसका डेटा टेबल दिखाता है, और पहली सीरीज़ के लिए वैल्यू लेबल्स को सक्षम करता है। फ़ॉर्मेट `#,##0.00` हज़ार विभाजक और दो दशमलव स्थान दिखाता है बिना मूल मानों को बदले।

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

चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक सेल्स को फ़ॉर्मेट करने के लिए देखें [Set Custom Number Formats for Workbook Cells](/slides/hi/androidjava/chart-workbook/#set-custom-number-formats-for-workbook-cells)। वह उदाहरण भी दिखाता है कि स्रोत सेल फ़ॉर्मेट के अनुसार वैल्यू लेबल्स कैसे दिखते हैं जबकि संग्रहीत संख्यात्मक मान अपरिवर्तित रहते हैं।

## **प्रतिशत को लेबल्स के रूप में प्रदर्शित करें**

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी के कुल का प्रतिशत गणना करें और टेक्स्ट को [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) द्वारा लौटाए गए टेक्स्ट फ्रेम में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और दो दशमलव स्थान के साथ 8‑पॉइंट फ़ॉन्ट में प्रतिशत प्रदर्शित करता है। शून्य कुल वाली श्रेणियों को विभाजन शून्य से बचने के लिए छोड़ दिया जाता है। चार्ट डेटा बदलने पर कस्टम लेबल टेक्स्ट पुनः गणना करें।

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

## **चार्ट डेटा लेबल्स के साथ प्रतिशत संकेत सेट करें**

जब मान अंशों के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) का उपयोग करें। लेबल फ़ॉर्मेट को स्रोत सेल्स से स्वतंत्र रूप से लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) में `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले सीरीज़ के साथ 100 % स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान का जोड़ 1 होता है। लेबल फ़ॉर्मेट `0.0%` 0.30 को 30.0 % के रूप में दिखाता है, जबकि वर्टिकल एक्सिस दो दशमलव स्थान उपयोग करता है। दोनों सीरीज़ सफेद, 10‑पॉइंट लेबल टेक्स्ट उपयोग करती हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

## **डेटा लेबल्स का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालने, प्रेजेंटेशन सामग्री खोजने, या जेनरेटेड चार्ट्स को वैलिडेट करने में उपयोगी है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [data label format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) प्रत्येक श्रेणी नाम, सीरीज़ नाम, और मान को संयोजित करता है। एक पॉइंट अपना मान प्रतिशत में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा पॉइंट में संग्रहीत संख्या `0.75` रहती है, जबकि उसका लेबल `75%` दिखा सकता है साथ में श्रेणी और सीरीज़ नामों के। कस्टम टेक्स्ट जेनरेटेड लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) दोनों स्थितियों में परिणामी लेबल स्ट्रिंग लौटाता है। दृश्यमान लेबल्स को ही निकालना चाहते हैं तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) को अलग से जांचें।

## **एक्सिस अधिकतम से परे डेटा लेबल्स को नियंत्रित करें**

जब आप एक्सिस रेंज को मैन्युअल रूप से सीमित करते हैं, तो कुछ डेटा पॉइंट्स उसकी अधिकतम से अधिक हो सकते हैं। यह निर्धारित करने के लिए कि उनके डेटा लेबल्स दिखाए जाएँ या नहीं, [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) का उपयोग करें। यह सेटिंग लेबल की दृश्यता को बदलती है; यह एक्सिस रेंज या मूल डेटा मानों को नहीं बदलती।

निचला उदाहरण 60 और 120 मानों के साथ 2D क्लस्टरड कॉलम चार्ट बनाता है। यह वर्टिकल एक्सिस पर [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) में `false` पास करता है और [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) से अधिकतम 100 सेट करता है। पहला स्लाइड अधिकतम के बाहर लेबल्स को अनुमति देता है; उसकी एक कॉपी में इसे अक्षम किया गया है। दोनों स्लाइड्स `DataLabelsOverMaximum.pptx` में सहेजी गई हैं।

[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के साथ वैल्यू लेबल्स सक्रिय करें। चार्ट-लेवल सेटिंग स्वयं वैल्यू डिस्प्ले को सक्षम नहीं करती और न ही व्यक्तिगत लेबल की डिसेबल्ड वैल्यू डिस्प्ले को ओवरराइड करती है। यह उदाहरण पूरी सीरीज़ के लिए वैल्यूज़ सक्रिय करता है और [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) का उपयोग करके प्रत्येक कॉलम के बाहर के छोर पर लेबल्स को रखता है।

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

नीचे दिखाए गए इमेज़ Microsoft PowerPoint द्वारा सहेजे गए स्लाइड्स को रेंडर करते हैं। `true` के साथ लेबल **120** ऊपरी सीमा पर दृश्यमान है; `false` के साथ वह छिपा रहता है। लेबल **60** दृश्यमान रहता है, एक्सिस अधिकतम **100** बना रहता है, और दूसरा डेटा पॉइंट दोनों मामलों में **120** रहता है।

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
यह उदाहरण वैल्यू एक्सिस वाले 2D कॉलम चार्ट का उपयोग करता है। वैल्यू एक्सिस न रखने वाले चार्ट, जैसे पाई और डोनट चार्ट, के पास इस तरह का एक्सिस अधिकतम नहीं होता।
{{% /alert %}}

## **लेबल की एक्सिस से दूरी सेट करें**

कैटेगरी एक्सिस लेबल्स और एक्सिस के बीच दूरी नियंत्रित करने के लिए [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) का उपयोग करें। मान एक्सिस लेबल्स के अधिकतम फ़ॉन्ट आकार का प्रतिशत है। यह उदाहरण क्लस्टरड कॉलम चार्ट बनाता है और हॉरिज़ॉन्टल एक्सिस लेबल ऑफ़सेट को 500 पर सेट करता है। यह सेटिंग कैटेगरी एक्सिस लेबल्स को प्रभावित करती है, न कि व्यक्तिगत डेटा पॉइंट्स से जुड़े लेबल्स को।

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

पाई चार्ट पर, डेटा लेबल की स्थिति को समायोजित करके स्पेसिंग बेहतर बनाएं और लीडर लाइनों के लिए जगह बनाएं।

यह उदाहरण पहले डेटा पॉइंट का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) का उपयोग करके क्षैतिज एवं ऊर्ध्वाधर ऑफ़सेट समायोजित करता है। ये ऑफ़सेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **लीडर लाइनों को फ़ॉर्मेट करें**

जब पाई चार्ट लेबल्स स्लाइसेस के बाहर होते हैं, तो लीडर लाइन्स पाठकों को प्रत्येक मान को सही स्लाइस से मिलाने में मदद करती हैं। कंट्रास्टिंग रंग और थोड़ा मोटी लाइन इन कनेक्शनों को आसानी से समझने योग्य बनाती है, जबकि ट्रांसपेरेंसी और डैश्ड शैली लाइन्स को दृश्यात्मक रूप से कम प्रमुख रखती है।

सीरीज़ के डेटा लेबल कलेक्शन स्तर पर लीडर लाइन्स को फ़ॉर्मेट करने के लिए [getLeaderLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) का उपयोग करें। `series.getLabels().getLeaderLinesFormat().getLine()` में सेटिंग्स कलेक्शन पर लागू होती हैं, न कि व्यक्तिगत लेबल पर।

यह उदाहरण डिफ़ॉल्ट डेटा वाला पाई चार्ट बनाता है, स्लाइसेस के बाहर मान दिखाता है, और [setShowLeaderLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) को सक्षम करता है। यह दो लेबल्स को उनके स्लाइसेस से अधिक दूरी पर ले जाता है, जिसमें ऑफ़सेट [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) से निर्धारित होते हैं, जो चार्ट की चौड़ाई और ऊँचाई के अंश होते हैं। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं है।

लाइन की [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) एक ठोस नीला रंग 191/255 अल्फा वैल्यू के साथ सेट करती है, जिससे लगभग 25 % ट्रांसपेरेंसी मिलती है। [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) लाइन की मोटाई 2 पॉइंट सेट करता है, और [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) लाइन को डैश्ड बनाता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // अपने स्लाइसों से दो लेबल्स को अधिक दूरी पर ले जाएँ।
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(Color.argb(191, 30, 90, 160));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लीडर लाइन्स को सक्षम करने से यह गारंटी नहीं होती कि प्रत्येक लेबल के लिए एक लाइन दिखेगी। दृश्यता लेबल प्लेसमेंट और चार्ट के लेआउट व्यवहार पर निर्भर करती है। इस उदाहरण में, दो हटाए गए लेबल्स के पास दृश्यमान लीडर लाइन्स हैं; स्लाइसेस के निकट रहने वाले लेबल्स को उनकी आवश्यकता नहीं होती।

निम्न छवि `FormattedLeaderLines.pptx` को Aspose.Slides द्वारा रेंडर किया गया दिखाती है:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **कॉलम चार्ट के ऊपर कई पंक्तियों के डेटा लेबल्स जोड़ें**

यह उदाहरण दो पंक्तियों के डेटा लेबल्स के साथ कॉलम चार्ट बनाता है, जो प्लॉट एरिया के ऊपर स्थित होते हैं। सीरीज़ A दृश्यमान कॉलम दिखाता है, जबकि सीरीज़ B और सीरीज़ C अतिरिक्त लेबल्स प्रदान करते हैं। उनके कॉलम फ़िल और आउटलाइन हटाकर छिपे हुए रहते हैं। [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) मेथड सभी तीन सीरीज़ को समान कैटेगरी सेंटर के साथ संरेखित करता है।

[ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) सेटिंग्स लेबल पंक्तियों के लिए जगह आरक्षित करती हैं। [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) डिफ़ॉल्ट स्थितियों की गणना करने के बाद, [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) और [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) क्षैतिज संरेखण को बनाए रखते हैं और दो पंक्तियों में लेबल्स को व्यवस्थित करने के लिए ऊर्ध्वाधर ऑफ़सेट लागू करते हैं। संख्याएँ सीरीज़ मानों से जुड़ी डेटा लेबल्स रहती हैं; केवल पंक्ति शीर्षक अलग टेक्स्ट शैप्स होते हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        IChartDataCell categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // B और C के कॉलम को छिपाएँ, लेकिन उनके डेटा लेबल रखें।
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.InsideBase);
        }
    }

    // सभी तीन सीरीज़ को समान कैटेगरी सेंटर के साथ संरेखित करें।
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // इस संक्षिप्त उदाहरण के लिए कम ग्रिडलाइन उपयोग करें।
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // प्लॉट के ऊपर दो पंक्तियों के डेटा लेबल्स के लिए जगह आरक्षित करें।
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
            // डिफ़ॉल्ट क्षैतिज स्थिति को रखें। Y एक ऑफ़सेट है
            // डिफ़ॉल्ट लेबल स्थिति से, जो चार्ट-ऊँचाई के अंश के रूप में व्यक्त किया गया है।
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // केवल पंर्ति शीर्षक एक अलग टेक्स्ट शैप है।
        IAutoShape rowHeading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**घने चार्ट्स पर डेटा लेबल्स के ओवरलैप को कैसे रोकूँ?**

ऑटोमैटिक लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट साइज को मिलाकर उपयोग करें; आवश्यक हो तो कुछ फ़ील्ड्स (जैसे कैटेगरी) को छिपाएँ या केवल अत्यधिक मान या प्रमुख पॉइंट्स के लिए लेबल्स दिखाएँ।

**शून्य, नकारात्मक या खाली मानों के लिए लेबल्स को कैसे अक्षम करूँ?**

लेबल्स को सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले को बंद करें, जैसा कि निर्धारित नियम के अनुसार हो।

**PDF/इमेज में एक्सपोर्ट करने पर लेबल स्टाइल को स्थिर कैसे बनाऊँ?**

फ़ॉन्ट फ़ैमिली और साइज को स्पष्ट रूप से सेट करें और यह सुनिश्चित करें कि रेंडरिंग पर्यावरण में वह फ़ॉन्ट उपलब्ध हो, ताकि फ़ॉलबैक से बचा जा सके।