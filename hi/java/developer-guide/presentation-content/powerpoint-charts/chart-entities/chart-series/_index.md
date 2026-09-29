---
title: जावा में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं को प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा बिंदु
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के साथ प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें सीखें।"
---
## **सारांश**

एक चार्ट अपने प्लॉटेड डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/) एक संबंधित मानों का सेट दर्शाता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स लेबल या समूहित मान प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल प्रदर्शित टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, कॉलम 0 को श्रेणी नामों के लिए, और शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए गए वर्कशीट, पंक्ति और कॉलम इंडेक्स शून्य‑आधारित हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाने पर उपयोगी है, लेकिन यह मानना सही नहीं है कि हर मौजूदा चार्ट इसे उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--), एक बिंदु के लिए श्रृंखला के रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप विड्थ जैसे विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुंचें।

जब स्पष्ट रूप से बिंदु या श्रृंखला भराई सेट नहीं की गई है, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फॉर्मेट मौजूद होते हैं, तो बिंदु फॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![चार्ट-श्रृंखला-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रोजेक्शन है। इस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ और मान शामिल करता है।
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला भराई रंग बदलें**

एक पूरी श्रृंखला के लिए डिफ़ॉल्ट भराई सेट करने के लिए [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी बिंदु की पहले से स्पष्ट भराई है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिए श्रृंखला भराई को ओवरराइड करता है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला भराई लागू करता है:

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

![श्रृंखला का रंग](series_color.png)

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लीजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर होती है और पहली श्रृंखला का नाम रखती है। नीचे के उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचता है:

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

![श्रृंखला नाम](series_name.png)

## **स्वतः उत्पन्न श्रृंखला भराई रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जिसे तब उपयोग किया जाता है जब श्रृंखला भराई स्पष्ट रूप से परिभाषित नहीं की गई हो। इस मेथड को बुलाने से रंग पढ़ा जाता है; यह नई भराई सेट नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वतः उत्पन्न रंग प्रिंट करता है:

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

डिफ़ॉल्ट चार्ट शैली के लिए उदाहरण आउटपुट:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

सटीक रंग चार्ट शैली और थीम पर निर्भर करते हैं।

## **श्रृंखला के लिए इनवर्ट भराई रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग भराई के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला भराई को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला में बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![इनवर्टेड ठोस भराई रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्शन को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इनवर्शन अक्षम है और केवल चयनित बिंदु के लिए सक्षम है। प्रभाव दिखाने के लिए बिंदु को नकारात्मक मान भी असाइन किया गया है:

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

## **एक विशिष्ट डेटा पॉइंट मान को साफ़ करें**

एक बिंदु को खाली बनाने के लिए (अन्य बिंदुओं को हटाए बिना) उसकी पृष्ठभूमि वाले वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉटेड मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध होता है। डेटा पॉइंट उसी श्रेणी स्थिति पर रहता है, लेकिन चार्ट ब्लैंक‑वैल्यू सेटिंग्स के अनुसार उसके मान को खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो हटाने वाले मान का प्रतिनिधित्व करता है। जब आप अन्य बिंदु रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) न बुलाएँ, क्योंकि यह मेथड पूरे संग्रह से सभी डेटा पॉइंट्स हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

छिपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग केस होते हैं। छिपी पंक्तियों और कॉलमों से डेटा को शामिल या बाहर करने के लिए देखें [छिपी पंक्तियों और कॉलमों से डेटा शामिल करें](/slides/hi/java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थिति डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। सेल को खाली करने के लिए [IChartDataCell.setValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) को `null` के साथ कॉल करें। शून्य मान ब्लैंक‑सेल सेटिंग के बावजूद शून्य ही रहता है।

खाली सेल्स के प्रदर्शन को चुनने के लिए [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वनिर्मित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ उसी चार्ट को सेव करता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल के लिए, और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा पॉइंट को बनाए रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजे जाने से पहले निर्धारित मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, वांछित मोड असाइन करें और प्रेजेंटेशन को एक बार सेव करें, सभी मोड्स पर इटरेट करने के बजाय।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![लाइन चार्ट्स में समान डेटा: गैप दिन 3 पर लाइन को तोड़ता है, ज़ीरो लाइन को शून्य पर ले जाता है, और स्पैन दिन 2 को दिन 4 से जोड़ता है।](display_blanks_as.png)

दृश्यमान प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड्स को आसानी से तुलना करने की सुविधा देता है। बार और कॉलम चार्ट्स में किसी मिसिंग श्रेणी के ऊपर जोड़ने के लिए लाइन नहीं होती, इसलिए `Span` उपरोक्त जैसा कनेक्टिंग सेगमेंट नहीं बना सकता; एक मिसिंग कॉलम और शून्य‑ऊंचाई कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग परिणामों की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिए आउटपुट जांचें।

## **श्रृंखला गैप विड्थ सेट करें**

गैप विड्थ बगल‑बगल बार या कॉलम क्लस्टर के बीच की दूरी है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना बना देता है।

निम्न उदाहरण गैप विड्थ बदलता है और केवल अंतिम प्रेजेंटेशन को सेव करता है:

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

![गैप विड्थ](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) एनेमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मान संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जुड़ता है। श्रृंखला प्रकार से मेल खाने वाले डेटा‑पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप विड्थ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

एक [IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर के प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को नहीं बदलता।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा शामिल होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। किसी संदर्भित सेल को बदलने से संबंधित चार्ट एलिमेंट अपडेट हो जाता है। कस्टम डेटा बनाते समय श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार व्यवस्थित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरे श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु का श्रेणी स्थान बना रहे, लेकिन वह एक खाली बिंदु बन जाए। केवल उस बिंदु को हटाने के लिए [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) का प्रयोग न करें; यह मेथड पूरी श्रृंखला के सभी बिंदुओं को हटा देता है।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या समीपस्थ बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रस्तुति में गायब डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) को कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) से प्राप्त रंग असाइन करें। आप [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के माध्यम से व्यक्तिगत बिंदु के लिए व्यवहार को अधिलेखित कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट किए जाएँ तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप विड्थ जैसी समूह सेटिंग्स लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के फ़ॉर्मेट ओवरराइड नहीं हैं।

**एक चार्ट में कितनी अधिकतम श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides में कोई अलग स्थिर श्रृंखला‑गणना सीमा नहीं है। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) को कॉल करें। मान बढ़ाने से क्लस्टर के बीच का अंतराल बढ़ेगा, घटाने से वे करीब आएँगे।