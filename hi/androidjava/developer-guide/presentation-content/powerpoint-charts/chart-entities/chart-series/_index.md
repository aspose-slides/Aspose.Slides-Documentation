---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
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
description: "एंड्रॉइड पर प्रस्तुतियों में चार्ट श्रृंखला, डेटा बिंदु, वर्कबुक सेल, स्वरूपण, ओवरलैप, गैप चौड़ाई, और नकारात्मक मानों को कैसे प्रबंधित करें, सीखें।"
---
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए डेटा को एक चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स उन लेबल या ग्रुपिंग मानों को प्रदान करते हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। श्रृंखला का नाम, श्रेणियां, और बिंदु मान इसलिए [IChartDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स से जुड़े होते हैं, न कि केवल डिस्प्ले टेक्स्ट के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष सेल्स श्रृंखला मानों के लिए उपयोग करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए गए वर्कशीट, पंक्ति, और कॉलम इंडेक्स शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह न मानें कि हर मौजूदा चार्ट इसका उपयोग करता है। एक लोडेड प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखलाओं, श्रेणियों, और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जांच करें।

चार्ट सेटिंग्स के तीन अलग‑ अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--), एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), एक बिंदु के लिए श्रृंखला रूप को ओवरराइड करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) से संबंधित होते हैं। जब आपको ओवरलैप या गैप विथ जैसे विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट मौजूद हों, तो बिंदु फ़ॉर्मेट उस बिंदु के लिए प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2D चार्ट में बार या कॉलम कितनी ओवरलैप करते हैं, -100 से 100 % तक रिपोर्ट करता है। यह पैरेंट श्रृंखला समूह की सेटिंग का केवल‑पढ़ा प्रोजेक्शन है। समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्नलिखित उदाहरण पहले श्रृंखला को शामिल करने वाले समूह के लिए ओवरलैप सेट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएं, श्रेणियां, और मान शामिल करता है।
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

## **श्रृंखला भराव रंग बदलें**

पूरी श्रृंखला के लिए डिफ़ॉल्ट भराव सेट करने हेतु [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट भराव है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिए श्रृंखला भराव को ओवरराइड करती है।

निम्नलिखित उदाहरण पहली श्रृंखला पर ठोस नीला भराव लागू करता है:

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

![The color of the series](series_color.png)

## **श्रृंखला नाम बदलें**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत रहता है और आमतौर पर लीज़ेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, कॉलम 1) पहली श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानने से बचता है:

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

## **स्वचालित श्रृंखला भराव रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) श्रृंखला सूचकांक और चार्ट शैली के आधार पर गणना किया गया Android ARGB रंग पूर्णांक लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं होता। इस मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; यह नया भराव नहीं निर्धारित करता।

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

सटीक पूर्णांक मान चार्ट शैली और थीम पर निर्भर करते हैं।

## **एक चार्ट श्रृंखला के लिए उल्टा भराव रंग सेट करें**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग भराव के साथ दिखा सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, उलटाव को सक्षम करें, और नकारात्मक‑मान रंग [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। वर्कबुक में नकारात्मक संख्याएँ अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। कार्यपत्रक पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

आप एक बिंदु के लिए उलटाव को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से सक्षम कर सकते हैं। नीचे दिए गए उदाहरण में श्रृंखला के लिए उलटाव निष्क्रिय है और केवल चयनित बिंदु के लिये सक्रिय किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिख सके:

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

एक बिंदु को अन्य बिंदुओं को हटाए बिना खाली करने के लिए, उसकी बैकिंग वर्कबुक सेल को `null` सेट करें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध होता है। डेटा पॉइंट समान श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसकी मान को ब्लैंक मान सेटिंग्स के अनुसार खाली मान लेता है।

निम्नलिखित उदाहरण पहली श्रृंखला में केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) को न कॉल करें, क्योंकि यह मेथड संग्रह से सभी डेटा पॉइंट्स को हटा देता है।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई पड़ोसियों के बीच बार या कॉलम क्लस्टर के बीच का अंतराल है, जिसे बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एक श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक स्थान बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

निम्नलिखित उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

**कौन से चार्ट प्रकार डेटा श्रृंखलाओं का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) एनेमरेशन द्वारा दर्शाए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिए, श्रेणी चार्ट में श्रेणियां और मान होते हैं, स्कैटर चार्ट में X और Y मान होते हैं, और बबल चार्ट में बबल आकार जोड़ता है। डेटा‑पॉइंट निर्माण मेथड को श्रृंखला प्रकार के अनुसार चुनें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/) संगत श्रृंखलाओं को समाहित करता है जो समूह‑स्तरीय प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नई बनाई गई चार्ट में डिफ़ॉल्ट डेटा शामिल होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखलाएं, श्रेणियां, और मान बनाता है। आप इन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले दोनों श्रृंखला और श्रेणी संग्रह साफ़ कर सकते हैं। एक ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना भी चार्ट बनाया जा सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। एक संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट होता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो सके।

**मैं पूरी श्रृंखला नहीं बल्कि केवल एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति बनी रहे और वह एक खाली बिंदु बन जाए। केवल तब [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग करें जब आप उस श्रृंखला के सभी बिंदु हटाना चाहते हों। यदि आप श्रेणियां भी हटाते हैं, तो सभी श्रृंखलाओं को अपडेट करें ताकि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदुओं को कैसे प्रदर्शित किया जाता है?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली स्थानों को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपकी प्रस्तुति में अनुपस्थित डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मानों को कैसे फ़ॉर्मेट किया जाता है?**

समर्थित बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा लौटाए गए रंग को सेट करें। आप [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से व्यक्तिगत बिंदु के लिए व्यवहार ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेट किए गए हों तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित न हो, स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप विथ लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर के फ़ॉर्मेट ओवरराइड नहीं हैं।

**एक चार्ट में कितनी अधिकतम श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग से निश्चित श्रृंखला‑गणना सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट पठनीयता एक उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या बदलना चाहिए?**

संबंधित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाने से क्लस्टर के बीच का अंतराल चौड़ा होगा, और घटाने से क्लस्टर एक‑दूसरे के करीब आएँगे।