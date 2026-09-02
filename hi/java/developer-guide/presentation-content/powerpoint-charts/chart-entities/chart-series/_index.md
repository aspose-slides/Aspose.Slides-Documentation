---
title: प्रस्तुतियों में जावा का उपयोग करके चार्ट डेटा श्रृंखला प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा पॉइंट
- वर्कबुक सेल
- श्रृंखला अंतर
- नकारात्मक मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा पॉइंट्स, वर्कबुक कोशिकाओं, स्वरूपण, ओवरलैप, गैप चौड़ाई और नकारात्मक मानों को प्रबंधित करना सीखें।"
---
## **सारांश**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहीत करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक कोशिकाओं को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartcategory/) वस्तुएँ श्रृंखला द्वारा साझा किए गए लेबल या समूह मान प्रदान करती हैं। इसलिए श्रृंखला का नाम, श्रेणियाँ, और पॉइंट मान [IChartDataCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल प्रदर्शन टेक्स्ट के रूप में संग्रहीत।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक पंक्ति 0 का उपयोग श्रृंखला नामों के लिए, स्तम्भ 0 का उपयोग श्रेणी नामों के लिए, और शेष कोशिकाएँ श्रृंखला मानों के लिए करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए जाने वाले वर्कशीट, पंक्ति, और स्तम्भ अनुक्रमण शून्य‑आधारित हैं। यह लेआउट उन चार्टों के निर्माण में उपयोगी है जिनमें डिफ़ॉल्ट डेटा होता है, लेकिन यह मानना नहीं चाहिए कि प्रत्येक मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रस्तुति के लिये, वर्कबुक मानों को बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा पॉइंट द्वारा संदर्भित कोशिकाओं की जाँच करें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला‑स्तर की सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--), एक ही श्रृंखला के सभी पॉइंट के लिए डिफ़ॉल्ट स्वरूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--), एक पॉइंट के लिये श्रृंखला स्वरूप को ओवरराइड करती हैं।
- समूह सेटिंग्स समान [IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) में स्थित संगत श्रृंखलाओं पर लागू होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसी विकल्प सेट करने हों, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें।

जब स्पष्ट रूप से पॉइंट या श्रृंखला भराव नहीं सेट किया जाता, तो चार्ट शैली और थीम स्वचालित रूप से स्वरूप निर्धारित करती है। जब श्रृंखला और पॉइंट दोनों का स्वरूप मौजूद होता है, तो उस पॉइंट के लिये पॉइंट स्वरूप प्राथमिकता लेता है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितने प्रतिशत ओवरलैप होते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रोजेक्शन है। उस समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिये [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहले श्रृंखला को सम्मिलित करने वाले समूह के लिये ओवरलैप सेट करता है:

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

![सीरीज़ ओवरलैप](series_overlap.png)

## **सीरीज़ फिल रंग बदलें**

पूरी श्रृंखला के लिये डिफ़ॉल्ट फिल सेट करने के लिये [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी पॉइंट का फिल पहले से स्पष्ट रूप से सेट है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस पॉइंट के लिये श्रृंखला फिल को ओवरराइड करती है।

निम्न उदाहरण पहले श्रृंखला पर ठोस नीला फिल लागू करता है:

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

![सीरीज़ का रंग](series_color.png)

## **सीरीज़ नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लिजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिये निर्मित डिफ़ॉल्ट वर्कबुक में, कोशिका B1 पंक्ति 0, स्तम्भ 1 पर स्थित होती है और पहले श्रृंखला का नाम रखती है। निम्न उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट रूप से दर्शाते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित कोशिका को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और स्तम्भ को मानने से बचता है:

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

![सीरीज़ नाम](series_name.png)

## **स्वचालित सीरीज़ फिल रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) श्रृंखला अनुक्रमण और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फिल स्पष्ट रूप से परिभाषित नहीं है। यह विधि गणना किया गया रंग पढ़ती है; यह नया फिल असाइन नहीं करती।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग प्रिंट करता है:

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

## **चार्ट सीरीज़ के लिए इनवर्ट फिल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग फिल के साथ दिखा सकता है। नियमित श्रृंखला फिल को ठोस सेट करें, इनवर्शन सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तम्भ 0 में श्रेणी नाम, और स्तम्भ 1 में मान होते हैं:

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

![उल्टा सॉलिड फिल रंग](inverted_solid_fill_color.png)

एक पॉइंट के लिये इनवर्शन को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से सक्षम किया जा सकता है। निम्न उदाहरण में श्रृंखला के लिये इनवर्शन अक्षम किया गया है और केवल चयनित पॉइंट के लिये सक्षम किया गया है। प्रभाव दिखाने के लिये पॉइंट को नकारात्मक मान भी दिया गया है:

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

## **एक विशिष्ट डेटा पॉइंट मान साफ़ करें**

किसी पॉइंट को खाली बनाने के लिये, उसके समर्थन वर्कबुक सेल को `null` सेट करें, बिना अन्य पॉइंट हटाए। कॉलम चार्ट के लिये, प्लॉटेड मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध है। डेटा पॉइंट समान श्रेणी स्थिति पर रहता है, परन्तु चार्ट उसकी मान को ब्लैंक मान सेटिंग के अनुसार खाली मान लेता है।

निम्न उदाहरण पहले श्रृंखला में केवल दूसरे पॉइंट को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y कोशिकाएँ उपयोग करते हैं, और बबल चार्ट अतिरिक्त आकार कोशिका भी। केवल वह कोशिका साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य पॉइंट रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) न कॉल करें, क्योंकि यह विधि संग्रह से सभी डेटा पॉइंट हटाती है।

## **सीरीज़ गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर के बीच की जगह है, जिसे बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक सघन बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रस्तुति को सहेजता है:

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

**कौन से चार्ट प्रकार डेटा सीरीज़ को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, परन्तु उनकी श्रृंखलाओं की मूल्य संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट श्रेणियाँ और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान, और बबल चार्ट बबल आकार जोड़ते हैं। डेटा‑पॉइंट निर्माण विधि का चयन श्रृंखला प्रकार के अनुसार करें। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट सीरीज़ ग्रुप क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) उन संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर की प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं; इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नया बनाया गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखलाएँ, श्रेणियाँ और मान बनाता है। आप उन कोशिकाओं को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी संग्रह दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट वर्कबुक कोशिकाओं से कैसे जुड़े हैं?**

श्रृंखला नाम, श्रेणी लेबल, और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) में कोशिकाओं को संदर्भित करते हैं। किसी संदर्भित कोशिका को बदलने से संबंधित चार्ट तत्व अपडेट हो जाता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस प्रकार संरेखित रखें कि प्रत्येक पॉइंट इच्छित श्रेणी के अंतर्गत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक पॉइंट को कैसे साफ़ करूँ?**

संबंधित मान कोशिका को `null` सेट करें ताकि पॉइंट का श्रेणी स्थान खाली पॉइंट के रूप में बना रहे। केवल उस पॉइंट को हटाने के लिये [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग न करें; यह विधि पूरी श्रृंखला के सभी पॉइंट हटाती है। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली पॉइंट कैसे दिखाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली क्षेत्रों को गैप, शून्य मान या निकटवर्ती पॉइंट को जोड़कर दिखा सकते हैं। वह सेटिंग चुनें जो आपके प्रस्तुतीकरण में गुम डेटा के अर्थ से मेल खाती हो।

**नकारात्मक मानों का स्वरूप कैसे तय किया जाता है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) को कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) से प्राप्त रंग सेट करें। आप [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के माध्यम से व्यक्तिगत पॉइंट के लिये व्यवहार को ओवरराइड कर सकते हैं। ये विधियाँ स्वरूप को प्रभावित करती हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और पॉइंट दोनों स्वरूपित हों तो कौन जीतता है?**

स्पष्ट डेटा‑पॉइंट स्वरूपण उस पॉइंट के लिये प्राथमिकता लेता है। अन्य पॉइंट स्पष्ट श्रृंखला स्वरूप या, जब श्रृंखला स्वरूप परिभाषित न हो, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और पॉइंट‑स्तर के स्वरूप ओवरराइड नहीं करतीं।

**क्या किसी चार्ट में शामिल होने योग्य अधिकतम श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides कोई अलग‑थलग स्थिर श्रृंखला‑गिनती सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा तय करती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों तो क्या बदलना चाहिए?**

सम्बन्धित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाने से क्लस्टर के बीच की जगह बढ़ेगी, और घटाने से क्लस्टर एक‑दूसरे के करीब आ जाएंगे।