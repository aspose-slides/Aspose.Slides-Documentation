---
title: Android पर प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और स्वरूपित करने के लिए Aspose.Slides for Android को Java के माध्यम से उपयोग करना सीखें, जिससे स्लाइड्स अधिक आकर्षक बनें।"
---
## **परिचय**

डेटा लेबल चार्ट श्रृंखला और व्यक्तिगत डेटा बिंदुओं की जानकारी प्रदर्शित करते हैं, जिससे पाठकों को मान पहचानने और चार्ट को समझने में मदद मिलती है। इस लेख में बताया गया है कि मानों को कैसे स्वरूपित करें, प्रतिशत कैसे प्रदर्शित करें, लेबल पाठ कैसे पढ़ें, श्रेणी अक्ष लेबल स्पेसिंग कैसे समायोजित करें, और पाई चार्ट लेबल की स्थिति कैसे निर्धारित करें।

## **चार्ट डेटा लेबल में डेटा सटीकता सेट करें**

सीरीज़ मानों को स्वरूपित करने के लिए [setNumberFormatOfValues](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, उसकी डेटा टेबल को दिखाता है, और पहली श्रृंखला के लिए मान लेबल सक्षम करता है। फ़ॉर्मेट `#,##0.00` हजार विभाजक और दो दशमलव स्थान दिखाता है बिना अंतर्निहित मानों को बदले।

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

स्टैक्ड कॉलम चार्ट के लिए, प्रत्येक मान को उसकी श्रेणी कुल के प्रतिशत के रूप में गणना करें और टेक्स्ट फ्रेम को [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) द्वारा लौटाए गए ऑब्जेक्ट में असाइन करें। यह उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है और 8 पॉइंट फ़ॉन्ट में दो दशमलव स्थान के साथ प्रतिशत दिखाता है। कुल शून्य वाली श्रेणियों को शून्य से विभाजन से बचने के लिए छोड़ दिया जाता है। यदि चार्ट डेटा बदलता है तो कस्टम लेबल टेक्स्ट को पुनः गणना करें।

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

## **चार्ट डेटा लेबल के साथ प्रतिशत चिह्न सेट करें**

जब मान अंश के रूप में संग्रहीत होते हैं, तो प्रतिशत प्रदर्शित करने के लिए [setNumberFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) का उपयोग करें। स्रोत कोशिकाओं से स्वतंत्र रूप से लेबल फ़ॉर्मेट लागू करने के लिए [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) को `false` पास करें।

यह उदाहरण चार श्रेणियों में लाल और नीले श्रृंखलाओं के साथ 100% स्टैक्ड कॉलम चार्ट बनाता है। प्रत्येक मान की जोड़ी 1 के बराबर होती है। लेबल फ़ॉर्मेट `0.0%` `0.30` को 30.0% के रूप में दिखाता है, जबकि लंबवत अक्ष दो दशमलव स्थान का उपयोग करता है। दोनों श्रृंखलाओं में सफ़ेद, 10‑पॉइंट लेबल टेक्स्ट होता है।

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

## **डेटा लेबल का वास्तविक टेक्स्ट पढ़ें**

डेटा लेबल की सेटिंग्स द्वारा उत्पन्न टेक्स्ट प्राप्त करने के लिए [getActualLabelText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) का उपयोग करें। यह रिपोर्ट के लिए लेबल निकालते समय, प्रस्तुति सामग्री खोजते समय, या उत्पन्न चार्ट के सत्यापन में उपयोगी होता है। नीचे दिए गए उदाहरण में, डिफ़ॉल्ट [डेटा लेबल फ़ॉर्मेट](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat/) प्रत्येक श्रेणी नाम, श्रृंखला नाम और मान को संयोजित करता है। एक बिंदु अपना मान प्रतिशत के रूप में फ़ॉर्मेट करता है, और दूसरा [getTextFrameForOverriding](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) से कस्टम टेक्स्ट उपयोग करता है।

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

डेटा बिंदु में संग्रहीत संख्या `0.75` रहती है, भले ही उसका लेबल `75%` के साथ श्रेणी और श्रृंखला नाम दिखाए। कस्टम टेक्स्ट उत्पन्न लेबल टेक्स्ट को बदल देता है। [getActualLabelText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) दोनों मामलों में परिणामी लेबल स्ट्रिंग लौटाता है। केवल दृश्यमान लेबल निकालना चाहते हैं तो ऊपर दिखाए अनुसार [isVisible](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabel/#isVisible--) को अलग से जांचें।

## **अक्ष से लेबल की दूरी सेट करें**

श्रेणी अक्ष लेबल और अक्ष के बीच की दूरी को नियंत्रित करने के लिए [setLabelOffset](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) का उपयोग करें। मान अक्ष लेबल के अधिकतम फ़ॉन्ट आकार का प्रतिशत होता है। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और क्षैतिज अक्ष लेबल ऑफसेट को 500 पर सेट करता है। यह सेटिंग व्यक्तिगत डेटा बिंदुओं से जुड़े लेबलों के बजाय श्रेणी अक्ष लेबलों को प्रभावित करती है।

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

पाई चार्ट पर डेटा लेबल की स्थितियों को समायोजित करके स्पेसिंग बेहतर बनाएं और लीडर लाइन के लिए जगह बनाएं।

यह उदाहरण प्रथम डेटा बिंदु का मान दिखाता है, उसका लेबल स्लाइस के बाहर रखता है, और [setX](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutable/#setX-float-) और [setY](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutable/#setY-float-) का उपयोग करके उसके क्षैतिज और ऊर्ध्वाधर ऑफसेट को समायोजित करता है। ये ऑफसेट क्रमशः चार्ट की चौड़ाई और ऊँचाई के सापेक्ष होते हैं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट्स पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन और फ़ॉन्ट आकार घटाकर संयोजन करें; आवश्यक होने पर कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल चरम मानों या मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक, या खाली मानों के लिए केवल लेबल को कैसे अक्षम कर सकता हूँ?**

लेबल सक्रिय करने से पहले डेटा बिंदुओं को फ़िल्टर करें और 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें, एक परिभाषित नियम के अनुसार।

**जब PDF/छवियों में निर्यात करूँ तो स्थिर लेबल शैली कैसे सुनिश्चित करूँ?**

फ़ॉन्ट फ़ैमिली और आकार को स्पष्ट रूप से सेट करें और रेंडरिंग वातावरण में फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक न हो।