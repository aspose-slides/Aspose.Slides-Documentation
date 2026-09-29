---
title: Android पर प्रेजेंटेशन में चार्ट डेटा श्रृंखलाएँ प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/androidjava/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा पॉइंट
- वर्कबुक सेल
- श्रृंखला गैप
- नकारात्मक मान
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Android पर प्रेजेंटेशन में चार्ट श्रृंखलाएँ, डेटा पॉइंट, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपनी प्लॉटेड डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। इसलिए श्रृंखला नाम, श्रेणियाँ, और पॉइंट वैल्यूज़ [IChartDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स से जुड़ी होती हैं, न कि केवल डिस्प्ले टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0 तथा शेष सेल्स को श्रृंखला मानों के लिए उपयोग करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए गए वर्कशीट, पंक्ति और कॉलम इंडेक्स शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह मानना न रखें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन विभिन्न स्तर होते हैं:

- सीरीज-स्तर की सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--), एक श्रृंखला में सभी पॉइंट्स के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा-पॉइंट सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), एक पॉइंट के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- ग्रुप सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से ग्रुप तक पहुंचें।

जब कोई स्पष्ट पॉइंट या श्रृंखला फ़िल सेट नहीं किया जाता, तो चार्ट स्टाइल और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब श्रृंखला और पॉइंट दोनों का फ़ॉर्मेट मौजूद होता है, तो उस पॉइंट के लिए पॉइंट फ़ॉर्मेट को प्राथमिकता दी जाती है।

![चार्ट-श्रृंखला-पावरपॉइंट](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी प्रतिशत (-100 से 100) ओवरलैप करते हैं। यह पैरेंट सीरीज ग्रुप पर सेटिंग का केवल पढ़ने‑योग्य प्रोजेक्शन है। उसी ग्रुप की सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो ग्रुप्ड बार या कॉलम प्रदर्शित करते हैं; यह कॉम्बिनेशन चार्ट में असंबंधित श्रृंखला ग्रुप को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएं, श्रेणियां और मान शामिल करता है।
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

## **श्रृंखला फ़िल रंग बदलें**

[IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करके पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करें। यदि किसी पॉइंट का स्पष्ट फ़िल पहले से मौजूद है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस पॉइंट के लिए श्रृंखला फ़िल को ओवरराइड करता है।

निम्नलिखित उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर होती है और पहली श्रृंखला का नाम रखती है। नीचे दिए गए उदाहरण में स्थायी कॉन्स्टैंट्स इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानते हुए होने वाले अनुमान से बचता है:

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

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) क्रमांक को Android ARGB रंग पूर्णांक के रूप में वापस करता है, जो श्रृंखला इंडेक्स और चार्ट स्टाइल से गणना किया गया होता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्नलिखित उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग पूर्णांक प्रिंट करता है:

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

सटीक पूर्णांक मान चार्ट स्टाइल और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग फ़िल के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन को सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ वैसी ही रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![इनवर्टेड ठोस फ़िल रंग](inverted_solid_fill_color.png)

आप एक पॉइंट के लिए इनवर्शन को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के द्वारा सक्षम कर सकते हैं। नीचे दिए गए उदाहरण में श्रृंखला के लिए इनवर्शन निष्क्रिय है और केवल चयनित पॉइंट के लिए सक्रिय है। प्रभाव दिखाने हेतु पॉइंट को नकारात्मक मान भी असाइन किया गया है:

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

## **विशिष्ट डेटा पॉइंट मान साफ़ करें**

एक पॉइंट को खाली करने के लिए, लेकिन अन्य पॉइंट्स को नहीं हटाने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉटेड मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) द्वारा उपलब्ध होता है। डेटा पॉइंट अपनी श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसकी वैल्यू को ब्लैंक मानते हुए दर्शाता है।

निम्नलिखित उदाहरण पहली श्रृंखला में केवल दूसरा पॉइंट साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट अतिरिक्त आकार सेल भी रखता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। यदि आप अन्य पॉइंट्स को बरकरार रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) को कॉल न करें, क्योंकि यह कलेक्शन से सभी डेटा पॉइंट्स हटा देता है।

## **खाली सेल्स के डिस्प्ले को नियंत्रित करें**

छिपे हुए सेल्स जो मूल्यों को रखते हैं, वह खाली सेल्स से अलग मामला है। छिपे हुए वर्कशीट पंक्तियों और कॉलम्स के डेटा को शामिल या बाहर करने के लिए देखें: [Include Data from Hidden Rows and Columns](/slides/hi/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली करने के लिए `[IChartDataCell.setValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)` को `null` पास करें। शून्य मान ब्लैंक‑सेल सेटिंग के बावजूद शून्य ही रहता है।

खाली सेल्स के डिस्प्ले मोड को चुनने के लिए `[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)` का उपयोग करें। यह सेटिंग पूरे चार्ट पर लागू होती है और ब्लैंक्स को कैसे प्लॉट किया जाए, बदलती है, बिना खाली सेल को शून्य या इंटरपोलेटेड वैल्यू से भरने के।

निम्नलिखित स्व-निहित उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, तीसरे दिन का मान साफ़ करता है, और प्रत्येक मोड के साथ समान चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। `[IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/)` वर्कशीट 0, कॉलम 0 को श्रेणी लेबल्स और कॉलम 1 को मानों के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रहता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ दें, जबकि उसकी श्रेणी और डेटा पॉइंट को बरकरार रखें।
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

प्रत्येक आउटपुट फ़ाइल में सहेजने से पहले असाइन किया गया मोड दर्शाया गया है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। यदि केवल एक संस्करण चाहिए, तो इच्छित मोड असाइन करें और प्रेज़ेंटेशन को एक बार सहेजें, मोड पर लूप न करें।

नीचे का तुलनात्मक चित्र तीनों फ़ाइलों में समान डेटा दिखाता है। प्रत्येक फ़ाइल में दिन 3 वर्कबुक में खाली है:

![लाइन चार्ट में समान डेटा: गैप के कारण लाइन दिन 3 पर टूटती है, ज़ीरो लाइन को शून्य पर गिराता है, और स्पैन दिन 2 से दिन 4 को जोड़ता है।](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना योग्य बनाता है। बार और कॉलम चार्ट्स के पास कोई लाइन नहीं होती जिससे गायब श्रेणी को जोड़ सके, इसलिए `Span` इस तरह का कनेक्टिंग सेगमेंट नहीं बना सकता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह स्कैटर चार्ट में केवल मार्कर्स होने पर कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग‑अलग परिणाम मिलने की उम्मीद न रखें; आप जिस प्रकार का उपयोग कर रहे हैं, उसके लिए आउटपुट की जाँच करें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई समीपस्थ बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट सीरीज ग्रुप से जुड़ी होती है, किसी एक श्रृंखला से नहीं। ग्रुप के लिए एक बार `[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)` कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक अंतराल बनाता है; छोटा मान उन्हें अधिक सघन बनाता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेज़ेंटेशन को सहेजता है:

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

## **FAQ**

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) एनेमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की वैल्यू संरचना और सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट्स में श्रेणियाँ और मान होते हैं, स्कैटर में X और Y मान, तथा बबल में बबल साइज जोड़ते हैं। श्रृंखला प्रकार से मेल खाने वाले डेटा‑पॉइंट निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम ग्रुप पर लागू होते हैं।

**चार्ट श्रृंखला ग्रुप क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) संगत श्रृंखलाओं को रखता है जो ग्रुप‑लेवल प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक ग्रुप हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया ग्रुप बदलना जरूरी नहीं कि चार्ट की सभी श्रृंखलाओं को बदल दे।

**क्या नए बनाए गए चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, `[IShapeCollection.addChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)` नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला एवं श्रेणी कलेक्शन को साफ़ कर सकते हैं। ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना भी चार्ट बनाया जा सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट वैल्यूज़ `[IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/)` में सेल्स को संदर्भित करती हैं। किसी संदर्भित सेल को बदलने से सम्बंधित चार्ट एलिमेंट अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑वैल्यू पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला नहीं बल्कि केवल एक पॉइंट कैसे साफ़ करूँ?**

संबंधित वैल्यू सेल को `null` सेट करें ताकि पॉइंट अपनी श्रेणी स्थिति को खाली पॉइंट के रूप में बनाए रखे। केवल उस पॉइंट को हटाने के लिए `[IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)` का उपयोग न करें; यह पूरी श्रृंखला के सभी पॉइंट्स हटा देगा। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करके मानों को श्रेणी कलेक्शन के साथ संरेखित रखें।

**खाली पॉइंट्स कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और `[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)` द्वारा सेट किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान या पड़ोसी पॉइंट्स को जोड़कर दिखा सकते हैं। अपने प्रेज़ेंटेशन की आवश्यकताओं के अनुसार उपयुक्त सेटिंग चुनें। पूरी प्रक्रिया और दृश्य तुलना के लिए देखें: [खाली सेल्स के डिस्प्ले को नियंत्रित करें](#control-the-display-of-empty-cells)।

**नकारात्मक मानों का फ़ॉर्मेट कैसे किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, `[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)` कॉल करें और `[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)` द्वारा प्राप्त रंग सेट करें। आप `[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)` के द्वारा व्यक्तिगत पॉइंट पर इस व्यवहार को ओवरराइड कर सकते हैं। ये मेथड्स फ़ॉर्मेटिंग को बदलते हैं, न कि स्टोर किए गए संख्यात्मक मानों को।

**जब दोनों श्रृंखला और पॉइंट फ़ॉर्मेटेड हों तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस पॉइंट के लिए प्राथमिकता लेती है। अन्य पॉइंट्स स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट स्टाइल और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप चौड़ाई जैसी ग्रुप सेटिंग्स लेआउट को नियंत्रित करती हैं और पॉइंट‑लेवल फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**एक चार्ट में कितनी अधिकतम श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग‑थलग निश्चित श्रृंखला‑गणना सीमा नहीं लगाता। व्यावहारिक रूप से, प्रेज़ेंटेशन फ़ाइल की सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या करें?**

उचित पैरेंट सीरीज ग्रुप पर `[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)` कॉल करें। मान बढ़ाकर क्लस्टर्स के बीच अंतराल विस्तृत करें, या घटाकर उन्हें अधिक पास लाएँ।