---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं को प्रबंधित करना
linktitle: डेटा श्रृंखला
type: docs
url: /hi/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "एंड्रॉइड पर प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों का प्रबंधन कैसे करें सीखें।"
---
## **समीक्षा**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं न कि केवल प्रदर्शित पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 को श्रृंखला नामों के लिए, स्तंभ 0 को श्रेणी नामों के लिए, और शेष कोशिकाओं को श्रृंखला मूल्यों के लिए उपयोग करती है। वर्कशीट, पंक्ति, और स्तंभ सूचकांक जो [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह मानें नहीं कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ, और डेटा बिंदुओं द्वारा संदर्भित कोशिकाओं का निरीक्षण करें।

चार्ट सेटिंग्स के तीन अलग-अलग दायरे होते हैं:

- श्रृंखला‑स्तरीय सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स वही संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फिल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती है। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![चार्ट‑श्रृंखला‑पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप होती है, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रोजेक्शन है। उस समूह की सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह कॉम्बिनेशन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिए ओवरलैप सेट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखला, श्रेणियाँ और मान शामिल करता है।
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

## **श्रृंखला भरने का रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फिल सेट करने हेतु [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट फिल हो, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिए श्रृंखला फिल को ओवरराइड करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फिल लागू करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लीजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित होता है और पहली श्रृंखला का नाम रखता है। निम्न उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तंभ को मानने से बचता है:

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

## **स्वचालित श्रृंखला भरने का रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) एक Android ARGB रंग पूर्णांक के रूप में श्रृंखला अनुक्रम और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला भर स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फिल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला के स्वचालित रंग पूर्णांक को प्रिंट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

सटीक पूर्णांक मान चार्ट शैली और थीम पर निर्भर करते हैं।

## **चार्ट श्रृंखला के लिए इनवर्ट भरने का रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग फिल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फिल को ठोस रखें, इनवर्ज़न सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![इनवर्टेड सॉलिड भरने का रंग](inverted_solid_fill_color.png)

आप एक बिंदु के लिए इनवर्ज़न को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में, श्रृंखला के लिए इनवर्ज़न अक्षम किया गया है और केवल चयनित बिंदु के लिए सक्षम किया गया है। प्रभाव दिखाने के लिये बिंदु को भी नकारात्मक मान असाइन किया गया है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **एक विशिष्ट डेटा बिंदु मान को साफ़ करें**

एक बिंदु को खाली बनाने के लिये, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, बिना अन्य बिंदुओं को हटाए। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध है। डेटा बिंदु वही श्रेणी स्थिति बनाए रखता है, लेकिन चार्ट अपनी ब्लैंक‑वैल्यू सेटिंग के अनुसार उसे खाली मानता है।

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाओं का उपयोग करते हैं, और बबल चार्ट में आकार कोशिका भी होती है। केवल उस कोशिका को साफ़ करें जो उस मान को दर्शाती है जिसे आप हटाना चाहते हैं। जब आप अन्य बिंदुओं को रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) को न कॉल करें, क्योंकि यह मेथड श्रृंखला से सभी डेटा बिंदुओं को हटा देता है।

## **खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक सेल अनुपलब्ध डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान को दर्शाता है। एक सेल को खाली बनाने हेतु [IChartDataCell.setValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) को `null` के साथ कॉल करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग की परवाह किए बिना शून्य ही रहता है।

चार्ट को खाली कोशिकाओं को कैसे प्रदर्शित करना है, चुनने के लिये [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरें।

निम्न स्वनिर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 के लिए मान को साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, श्रेणी लेबल के लिए स्तंभ 0, और मान के लिए स्तंभ 1 का उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // दिन 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बरकरार रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को संग्रहीत करती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड्स पर इटरेट करने के बजाय।

नीचे की तुलना में सभी तीन फ़ाइलों में एक ही डेटा दिखाया गया है। प्रत्येक मामले में वर्कबुक में दिन 3 खाली है:

![समान डेटा वाले लाइन चार्ट: गैप दिन 3 पर लाइन को तोड़ता है, ज़ीरो लाइन को शून्य तक ले जाता है, और स्पैन दिन 2 से दिन 4 तक जोड़ता है](display_blanks_as.png)

दृश्य प्रभाव चार्ट प्रकार पर निर्भर करता है। एक लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने योग्य बनाता है। बार और कॉलम चार्ट में किसी गायब श्रेणी के पार जोड़ने के लिये लाइन नहीं होती, इसलिए `Span` उपर्युक्त कनेक्टिंग सेगमेंट नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, सिर्फ़ मार्करों वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। प्रत्येक चार्ट प्रकार के लिये तीन अलग‑अलग परिणाम की उम्मीद न रखें; आप जिस प्रकार का उपयोग कर रहे हैं, उसके लिए आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई पड़ोसी बार या कॉलम क्लस्टर्स के बीच अंतराल है, जो बार या कॉलम की चौड़ाई के प्रतिशत के रूप में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से सम्बंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) को कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्न उदाहरण गैप चौड़ाई को बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**  
सभी चार्ट प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) एन्नुमरेशन द्वारा प्रतिनिधित्व किए गए हैं, डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट्स में श्रेणियाँ और मान होते हैं, स्कैटर चार्ट्स में X और Y मान होते हैं, और बबल चार्ट्स में बबल आकार जोड़ा जाता है। श्रृंखला प्रकार से मेल खाने वाली डेटा‑बिंदु निर्माण विधि का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**एक चार्ट श्रृंखला समूह क्या है?**  
एक [IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) में उन संगत श्रृंखलाओं को शामिल किया जाता है जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक रूप से नहीं बदलता।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा होता है?**  
हाँ। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखलाएँ, श्रेणियाँ, और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक कोशिकाओं से कैसे जुड़े होते हैं?**  
श्रृंखला नाम, श्रेणी लेबल, और डेटा‑बिंदु मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/) की कोशिकाओं को संदर्भित करते हैं। संदर्भित कोशिका बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरे श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**  
संबंधित मान कोशिका को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति एक खाली बिंदु के रूप में बनी रहे। केवल तब ही [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को इस तरह अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**  
परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर ब्लैंक्स प्रदर्शित कर सकते हैं। अपने प्रेजेंटेशन में गायब डेटा के अर्थ के अनुसार सेटिंग चुनें। विस्तृत उदाहरण और दृश्य तुलना के लिये देखें **[खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells)**।

**नकारात्मक मानों का फ़ॉर्मेट कैसे किया जाता है?**  
समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) को कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत बिंदु के लिये [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के साथ व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब दोनों श्रृंखला और बिंदु फ़ॉर्मेट किए गए हों तो कौन जीतेगा?**  
स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित न हो, स्वचालित चार्ट शैली और थीम को जारी रखते हैं। ओवरलैप और गैप चौड़ाई जैसे समूह सेटिंग्स लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**क्या किसी चार्ट में श्रृंखलाओं की संख्या पर कोई सीमा है?**  
Aspose.Slides कोई अलग‑से स्वतंत्र स्थिर श्रृंखला‑गणना सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता एक उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत पास या बहुत दूर हों तो मुझे क्या बदलना चाहिए?**  
सही पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) को कॉल करें। मान बढ़ाएँ ताकि क्लस्टर्स के बीच का अंतराल विस्तृत हो, या घटाएँ ताकि क्लस्टर एक‑दूसरे के निकट आएँ।