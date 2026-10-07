---
title: "जावा में प्रेजेंटेशन में चार्ट डेटा सीरीज़ को प्रबंधित करें"
linktitle: "डेटा सीरीज़"
type: docs
url: /hi/java/chart-series/
keywords:
- "चार्ट सीरीज़"
- "सीरीज़ ओवरलैप"
- "सीरीज़ रंग"
- "सीरीज़ नाम"
- "डेटा पॉइंट"
- "वर्कबुक सेल"
- "सीरीज़ गैप"
- "नकारात्मक मान"
- "PowerPoint"
- "प्रेजेंटेशन"
- "Java"
- "Aspose.Slides"
description: "जावा के साथ प्रेजेंटेशनों में चार्ट सीरीज़, डेटा पॉइंट, वर्कबुक सेल, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, यह सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉटेड डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और सीरीज़ में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो सीरीज़ द्वारा साझा किए जाते हैं। इसलिए सीरीज़ का नाम, श्रेणियाँ, और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को सीरीज़ नामों के लिये, कॉलम 0 को श्रेणी नामों के लिये, और शेष सेल्स को सीरीज़ मूल्यों के लिये उपयोग करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए जाने वाले वर्कशीट, पंक्ति, और कॉलम इंडेक्स शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह मानना नहीं चाहिए कि हर मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेज़ेंटेशन के लिये, वर्कबुक मान बदलने से पहले सीरीज़, श्रेणियों, और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग‑अलग स्कोप होते हैं:

- सीरीज़‑स्तर सेटिंग्स, जैसे कि [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), जो एक सीरीज़ के सभी पॉइंट्स के लिये डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे कि [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), जो एक पॉइंट के लिये सीरीज़ के रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत सीरीज़ पर लागू होती हैं जो समान [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। समूह तक पहुँचने के लिये [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) का उपयोग करें जब आपको ओवरलैप या गैप‑विथ जैसी विकल्प सेट करने हों।

जब कोई स्पष्ट पॉइंट या सीरीज़ फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों सीरीज़ और पॉइंट फॉर्मेट मौजूद हों, तो पॉइंट फॉर्मेट उस पॉइंट के लिये प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट सीरीज़ ग्रुप पर सेटिंग का केवल‑पढ़ने‑के‑लिए प्रोजेक्शन है। सभी संगत सीरीज़ को अपडेट करने के लिये [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित सीरीज़ ग्रुप को प्रभावित नहीं करता।

निम्न उदाहरण समूह के लिये ओवरलैप सेट करता है जिसमें पहली सीरीज़ शामिल है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना सीरीज़, श्रेणियां और मान शामिल करता है।
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The series overlap](series_overlap.png)

## **सीरीज़ फ़िल का रंग बदलें**

पूरी सीरीज़ के लिये डिफ़ॉल्ट फ़िल सेट करने के लिये [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी पॉइंट का पहले से स्पष्ट फ़िल है, तो उसके [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस पॉइंट के लिये सीरीज़ फ़िल को ओवरराइड करती है।

निम्न उदाहरण पहली सीरीज़ पर ठोस नीला फ़िल लागू करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The color of the series](series_color.png)

## **सीरीज़ का नाम बदलें**

सीरीज़ का नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिये बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित होता है और पहली सीरीज़ का नाम रखता है। निम्न उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट करते हैं:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम मानने से बचता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The series name](series_name.png)

### **कई सेल्स से नाम वाली सीरीज़ बनाएं**

जब उत्पाद का नाम और रिपोर्टिंग अवधि अलग‑अलग वर्कबुक सेल्स में संग्रहीत हों, तो कॉम्पोज़िट सीरीज़ नाम उपयोगी होता है। उदाहरण के लिये, आप `Product A` (सेल B1) और `2026` (सेल C1) को एकल सीरीज़ नाम में सम्मिलित कर सकते हैं जबकि दोनों हिस्से अपने स्रोत सेल्स से जुड़े रहें।

नाम रेंज प्राप्त करने के लिये [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) का उपयोग करें, फिर उस संग्रह को [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) को पास करें। `skipHiddenCells` तर्क नियंत्रण करता है कि छिपे सेल्स शामिल हों या नहीं: `true` उन्हें बाहर रखता है, जबकि `false` उन्हें शामिल करता है। यह उदाहरण `false` का उपयोग करके नाम रेंज में हर सेल को शामिल करता है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है जिसमें एक सीरीज़ और दो डेटा पॉइंट्स हैं। सेल B1:C1 केवल सीरीज़ नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल प्रदान करते हैं, और B2:B3 संख्यात्मक मान प्रदान करते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // ये दो सेल्स सीरीज़ नाम प्रदान करती हैं.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // अलग-अलग सेल्स श्रेणियों और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणामी सीरीज़ नाम `Product A 2026` होगा, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलम के लिये एक एंट्री के रूप में प्रदर्शित करता है। नीचे की छवि परिणाम दर्शाती है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित सीरीज़ फ़िल रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) वह रंग लौटाता है जो सीरीज़ इंडेक्स और चार्ट शैली से गणना किया जाता है। यह वह रंग है जो तब उपयोग किया जाता है जब सीरीज़ फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। यह विधि गणना किया गया रंग पढ़ती है; यह नया फ़िल असाइन नहीं करती।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट सीरीज़ का स्वचालित रंग प्रिंट करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट चार्ट शैली के लिये उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट सीरीज़ के लिये इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम, और बबल सीरीज़ के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित सीरीज़ फ़िल को ठोस सेट करें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक सीरीज़ से बदलता है। वर्कशीट पंक्ति 0 में सीरीज़ नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The inverted solid fill color](inverted_solid_fill_color.png)

एक पॉइंट के लिये इनवर्ज़न को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) द्वारा सक्षम किया जा सकता है। नीचे के उदाहरण में सीरीज़ के लिये इनवर्ज़न अक्षम है और केवल चयनित पॉइंट के लिये सक्षम है। पॉइंट को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को अन्य पॉइंट्स को हटाए बिना ख़ाली करने के लिये, उसके बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिये, प्लॉटेड मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध है। डेटा पॉइंट वही श्रेणी स्थिति पर रहता है, लेकिन चार्ट उसके मान को खाली मानता है जैसा कि चार्ट की खाली‑मान सेटिंग्स में निर्धारित है।

निम्न उदाहरण पहली सीरीज़ में केवल दूसरे पॉइंट को साफ़ करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य पॉइंट्स को रखना चाहते हैं तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) न कॉल करें, क्योंकि वह विधि संग्रह से सभी डेटा पॉइंट्स हटा देती है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान है, वे खाली सेल्स से अलग हैं। छिपी हुई वर्कशीट पंक्तियों और कॉलमों से डेटा शामिल या बाहर करने के लिये, देखें [Include Data from Hidden Rows and Columns](/slides/hi/java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल गायब डेटा का प्रतिनिधित्व करता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। एक सेल को खाली करने के लिये [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) को `null` के साथ कॉल करें। संख्यात्मक शून्य खाली‑सेल सेटिंग के बावजूद शून्य बना रहता है।

[ IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करके आप तय कर सकते हैं कि चार्ट खाली सेल्स को कैसे दिखाए। यह सेटिंग पूरे चार्ट पर लागू होती है। यह खाली मानों को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरते हुए।

निम्न स्व-निहित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक सीरीज़ है, Day 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ समान चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल और कॉलम 1 को मान के लिये उपयोग करता है; पंक्ति 0 में सीरीज़ नाम होता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // दिन 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा पॉइंट को बरकरार रखें।
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले सेट किया गया मोड सम्मिलित होता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड असाइन करें और प्रेज़ेंटेशन को एक बार सहेजें।

नीचे का तुलना चार फ़ाइलों में समान डेटा दर्शाता है। Day 3 हर केस में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखावा प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में कोई लाइन नहीं होती जो गायब श्रेणी को जोड़ सके, इसलिए `Span` ऊपर दिखाए गए कनेक्टिंग सेगमेंट को उत्पन्न नहीं कर सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। हर चार्ट प्रकार के लिये तीन विभिन्न परिणामों की उम्मीद न करें; आप जिस प्रकार का उपयोग कर रहे हैं उसकी आउटपुट जाँचें।

## **सीरीज़ गैप‑विथ सेट करें**

गैप‑विथ पास‑पास बार या कॉलम क्लस्टर के बीच की दूरी है, जो बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट सीरीज़ ग्रुप से सम्बंधित है, न कि किसी एक सीरीज़ से। समूह के लिये एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक स्पेस बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप‑विथ बदलता है और केवल अंतिम प्रेज़ेंटेशन को सहेजता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The gap width](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा सीरीज़ को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) एनेमरेशन द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी सीरीज़ सभी में समान मान संरचना या सेटिंग्स नहीं होतीं। उदाहरण के लिये, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट बबल आकार जोड़ते हैं। सीरीज़ प्रकार से मेल खाने वाली डेटा‑पॉइंट निर्मित विधि का उपयोग करें। ओवरलैप और गैप‑विथ जैसी विकल्प केवल संगत बार या कॉलम ग्रुप पर लागू होती हैं।

**चार्ट सीरीज़ ग्रुप क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) उन संगत सीरीज़ को समेटता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करते हैं। एक संयोजन चार्ट में एक से अधिक ग्रुप हो सकते हैं, इसलिए एक सीरीज़ के माध्यम से पहुँचा गया ग्रुप बदलना अनिवार्य नहीं है कि चार्ट की सभी सीरीज़ बदलें।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**

हाँ। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना सीरीज़, श्रेणियां और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले सीरीज़ और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी बिना डिफ़ॉल्ट डेटा के चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

सीरीज़ नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय श्रेणी पंक्तियों और सीरीज़‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक पॉइंट लक्ष्यित श्रेणी के तहत प्लॉट हो।

**मैं पूरे सीरीज़ के बजाय एक पॉइंट कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें जिससे पॉइंट की श्रेणी स्थिति खाली पॉइंट के रूप में बनी रहे। केवल तब [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग करें जब आप पूरी सीरीज़ को हटाना चाहते हों। यदि आप श्रेणियां भी हटाते हैं, तो सभी सीरीज़ को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट्स कैसे दर्शाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में गायब डेटा के अर्थ से मेल खाने वाला सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिये देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फॉर्मेट किया जाता है?**

समर्थित बार, कॉलम, और बबल सीरीज़ के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) को कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा प्राप्त रंग सेट करें। आप व्यक्तिगत पॉइंट के लिये [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से व्यवहार ओवरराइड कर सकते हैं। ये विधियां फ़ॉर्मेटिंग को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब सीरीज़ और पॉइंट दोनों फ़ॉर्मेट किए गए हों, तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेट उस पॉइंट के लिये प्राथमिकता लेता है। अन्य पॉइंट्स स्पष्ट सीरीज़ फ़ॉर्मेट या, यदि सीरीज़ फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग करते रहते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप‑विथ लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर फ़ॉर्मेट ओवरराइड नहीं होतीं।

**एक चार्ट में अधिकतम कितनी सीरीज़ हो सकती हैं?**

Aspose.Slides कोई अलग ठोस सीरीज़‑काउंट सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेज़ेंटेशन फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा तय करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट सीरीज़ ग्रुप पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाएँ ताकि क्लस्टर के बीच का अंतराल बढ़े, या घटाएँ ताकि क्लस्टर एक‑दूसरे के करीब आएँ।