---
title: Java में प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं का प्रबंधन
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
description: "Java के साथ प्रस्तुतियों में चार्ट श्रृंखलाओं, डेटा बिंदुओं, वर्कबुक सेल्स, फॉर्मेटिंग, ओवरलैप, गैप‑विथ और नकारात्मक मानों को प्रबंधित करना सीखें।"
---
## **परिचय**

एक चार्ट अपने प्लॉट किए गए डेटा को चार्ट डेटा वर्कबुक में संग्रहित करता है। एक [IChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/) एक संबंधित मानों के सेट का प्रतिनिधित्व करता है, और श्रृंखला में प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/) एक या अधिक वर्कबुक सेल्स को संदर्भित करता है। [IChartCategory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartcategory/) वस्तुएँ लेबल या समूहित मान प्रदान करती हैं जो श्रृंखलाओं द्वारा साझा किए जाते हैं। इस प्रकार श्रृंखला का नाम, श्रेणियाँ और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/) वस्तुओं से जुड़े होते हैं, न कि केवल दिखाने के पाठ के रूप में संग्रहीत होते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष सेल्स श्रृंखला मूल्यों के लिए उपयोग करती है। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए गए वर्कशीट, पंक्ति और स्तंभ अनुक्रमण शून्य‑आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ चार्ट बनाते हैं, लेकिन यह मानना नहीं चाहिए कि प्रत्येक मौजूदा चार्ट यही उपयोग करता है। लोड किए गए प्रेज़ेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियों और डेटा पॉइंट्स द्वारा संदर्भित सेल्स की जांच करें।

चार्ट सेटिंग्स के तीन विभिन्न दायरे होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--) सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑पॉइंट सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--) एक बिंदु के लिए श्रृंखला रूप को अधिलिखित करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। आप जब ओवरलैप या गैप‑विथ जैसी विकल्प सेट करना चाहते हैं, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला भराव सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से उपस्थिति निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getOverlap--) 2D चार्ट में बार या कॉलम के ओवरलैप प्रतिशत को रिपोर्ट करता है, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने‑योग्य प्रोजेक्शन है। समूह में सभी संगत श्रृंखलाओं को अपडेट करने के लिये [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम प्रदर्शित करते हैं; यह संयोजन चार्ट में असंबंधित श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण पहली श्रृंखला वाले समूह के लिये ओवरलैप सेट करता है:

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

![The series overlap](series_overlap.png)

## **श्रृंखला भराव रंग बदलें**

पूरा श्रृंखला के लिये डिफ़ॉल्ट भराव सेट करने हेतु [IChartSeries.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी बिंदु का पहले से स्पष्ट भराव निर्धारित है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिये श्रृंखला भराव को अधिलिखित करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला भराव लागू करता है:

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

## **श्रृंखला का नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में प्रदर्शित होता है। क्लस्टर्ड कॉलम चार्ट के लिये निर्मित डिफ़ॉल्ट वर्कबुक में, सेल B1 (पंक्ति 0, स्तंभ 1) पहली श्रृंखला का नाम रखता है। निम्न उदाहरण में नामित स्थिरांकों के द्वारा इस संरचना को स्पष्ट किया गया है:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति और स्तंभ को मानते हुए परिवर्तन से बचाता है:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) श्रृंखला क्रमांक और चार्ट शैली के आधार पर गणना किया गया रंग लौटाता है। यह वह रंग है जिसका उपयोग तब किया जाता है जब श्रृंखला भराव स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; नया भराव नहीं सौंपा जाता।

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

## **एक चार्ट श्रृंखला के लिये इनवर्ट भराव रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) नकारात्मक मानों को अलग भराव के साथ प्रदर्शित कर सकता है। नियमित श्रृंखला भराव को ठोस सेट करें, इनवर्जन को सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से निर्दिष्ट करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला में बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, तथा स्तंभ 1 में मान होते हैं:

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

आप एक बिंदु के लिये [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के द्वारा इनवर्जन सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिये इनवर्जन अक्षम है और केवल चयनित बिंदु के लिये सक्षम किया गया है। बिंदु को नकारात्मक मान भी दिया गया है जिससे प्रभाव दिखे:

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

## **एक विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिये उसकी बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदु बरकरार रहें। कॉलम चार्ट के लिये, प्लॉट किया गया मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getValue--) द्वारा उपलब्ध है। डेटा बिंदु वही श्रेणी स्थिति रखता है, लेकिन चार्ट ब्लैंक‑वैल्यू सेटिंग के अनुसार उसे खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के द्वितीय बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट में एक आकार सेल भी होता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु बरकरार रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) को कॉल न करें, क्योंकि यह मेथड सम्पूर्ण संग्रह को हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करें**

एक खाली वर्कबुक सेल अनुपलब्ध डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। सेल को खाली करने के लिये `null` के साथ [IChartDataCell.setValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) कॉल करें। शून्य मान हमेशा शून्य ही रहेगा, चाहे ब्लैंक‑सेल सेटिंग कुछ भी हो।

[ IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करके चुनें कि चार्ट खाली सेल्स को कैसे प्रदर्शित करे। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने के तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेटेड मान से भरने के।

निम्न स्वनिर्भर उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ समान चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं। [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल, और स्तंभ 1 को मान के लिये उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखता है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तविक रूप से खाली रखें, जबकि उसकी श्रेणी और डेटा बिंदु बनाए रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गये मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड सेट करें और प्रस्तुति को एक ही बार सहेजें, मोड पर इटरटेट करने की आवश्यकता नहीं।

नीचे का तुलनात्मक दृश्य सभी तीन फ़ाइलों में समान डेटा दर्शाता है। दिन 3 सभी मामलों में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखायी देने वाला प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में जुड़ाव के लिये कोई लाइन नहीं होती, इसलिए `Span` उपरोक्त जैसा कनेक्टिंग सेगमेंट नहीं बना पाता; एक खाली कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर्स वाले स्कैटर चार्ट में भी कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन अलग‑अलग परिणाम मिलने की उम्मीद न रखें; उपयोग किए गये प्रकार के लिये आउटपुट जाँचें।

## **श्रृंखला गैप‑विथ सेट करें**

गैप‑विथ बगल‑बगल बार या कॉलम क्लस्टर्स के बीच का अंतराल है, जिसे बार या कॉलम की चौड़ाई के प्रतिशत में व्यक्त किया जाता है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से सम्बंधित है, न कि व्यक्तिगत श्रृंखला से। समूह के लिये एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें घना करता है।

निम्न उदाहरण गैप‑विथ बदलता है और केवल अंतिम प्रस्तुति सहेजता है:

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

**कौन से चार्ट प्रकार डेटा श्रृंखला का समर्थन करते हैं?**

[ChartType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) ए़न्यूमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की मूल्य संरचना या सेटिंग्स समान नहीं होती। उदाहरण के लिये, श्रेणी चार्ट श्रेणियों और मानों का उपयोग करते हैं, स्कैटर चार्ट X और Y मानों का, और बबल चार्ट में बबल आकार भी जोड़ता है। डेटा‑पॉइंट निर्माण मेथड को श्रृंखला प्रकार के अनुसार चुनें। ओवरलैप और गैप‑विथ जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/) में संगत श्रृंखलाएँ होती हैं जो समूह‑स्तर के प्लॉट सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट एक से अधिक समूह रख सकता है, इसलिए एक श्रृंखला के माध्यम से पहुँचा गया समूह सभी श्रृंखलाओं को अनिवार्य रूप से नहीं बदलता।

**क्या नए बनाए गये चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखला, श्रेणियाँ और मान बनाता है। आप इन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला एवं श्रेणी संग्रह को साफ़ कर सकते हैं। एक ओवरलोड का उपयोग करके डिफ़ॉल्ट डेटा के बिना भी चार्ट बनाना संभव है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑पॉइंट मान [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट एलिमेंट अपडेट हो जाता है। कस्टम डेटा बनाते समय श्रेणी पंक्तियों और श्रृंखला‑मूल्य पंक्तियों को संरेखित रखें ताकि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें जिससे बिंदु की श्रेणी स्थिति एक खाली बिंदु के रूप में बनी रहे। केवल तब [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग करें जब आप पूरी श्रृंखला के सभी बिंदुओं को हटाना चाहते हों। यदि आप श्रेणियों को भी हटाते हैं, तो सभी श्रृंखलाओं को इस प्रकार अपडेट करें कि उनके मान श्रेणी संग्रह के साथ संरेखित रहें।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट खाली को गैप, शून्य मान या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपने प्रेज़ेंटेशन में गायब डेटा के अर्थ से मिलते‑जुलते सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिये [खाली सेल्स के प्रदर्शन को नियंत्रित करें](#control-the-display-of-empty-cells) देखें।

**नकारात्मक मान कैसे फॉर्मेट होते हैं?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत बिंदु के लिये [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) से व्यवहार बदल सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहित संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फॉर्मेट किए हों तो कौन जीतेगा?**

स्पष्ट डेटा‑पॉइंट फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, यदि श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप‑विथ लेआउट नियंत्रण करती हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को अधिलिखित नहीं करतीं।

**एक चार्ट में अधिकतम कितनी श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides कोई अलग‑से‑स्थिर श्रृंखला‑संख्या सीमा नहीं लगाता। व्यवहार में, प्रस्तुति फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों तो क्या बदलना चाहिए?**

उचित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच स्पेस विस्तृत होगा, मान घटाने से वे अधिक निकट आएँगे।