---
title: जावा में प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें
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
description: "जावा के साथ प्रस्तुतियों में चार्ट श्रृंखलाएँ, डेटा बिंदु, वर्कबुक सेल, फ़ॉर्मेटिंग, ओवरलैप, गैप चौड़ाई, और नकारात्मक मान कैसे प्रबंधित करें।"
---
## **अवलोकन**

एक चार्ट अपनी प्लॉटेड मानों को वर्कबुक सेल में या सीधे संख्यात्मक लिटरेल्स के रूप में संग्रहीत कर सकता है। एक [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) एक संबंधित मानों का सेट दर्शाता है, और प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) उस श्रृंखला में एक बिंदु को दर्शाता है। [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) वस्तुएँ श्रृंखला द्वारा साझा किए गए लेबल या समूह मान प्रदान करती हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियाँ और बिंदु मान [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) वस्तुओं का उपयोग चार्ट वर्कबुक से करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए स्तंभ 0, और शेष सेल्स का उपयोग श्रृंखला मानों के लिए करती है। वर्कशीट, पंक्ति और स्तंभ सूचकांक जो [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए जाते हैं, शून्य‑आधारित होते हैं। यह लेआउट डिफ़ॉल्ट डेटा के साथ चार्ट बनाते समय उपयोगी है, लेकिन यह मानना उचित नहीं है कि हर मौजूदा चार्ट इसका उपयोग करता है। लोड किए गए प्रेजेंटेशन के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियाँ और डेटा बिंदुओं द्वारा संदर्भित सेल्स की जाँच करें।

चार्ट सेटिंग्स के तीन विभिन्न स्तर होते हैं:

- श्रृंखला‑स्तर सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) सभी बिंदुओं के लिए डिफ़ॉल्ट रूप प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) किसी एक बिंदु के लिए श्रृंखला रूप को अधिलेखित करती हैं।
- समूह सेटिंग्स उन संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) से संबंधित हैं। समूह तक पहुँचने के लिए [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) का उपयोग करें जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने हों।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल नहीं निर्धारित किया गया हो, तो चार्ट शैली और थीम स्वचालित रूप से रूप निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **संख्यात्मक लिटरेल्स का उपयोग करके श्रृंखला मान सेट करें**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और वर्कशीट सेल संदर्भों की आवश्यकता नहीं होती, तो संख्यात्मक लिटरेल्स का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) के साथ कॉल करें।

कलेक्शन सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान का [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) विधि चयनित प्रकार को दर्शाती है; इसे कलेक्शन सेटिंग के माध्यम से बदलें। `Worksheet` के साथ, संदर्भित सेल तक पहुँचने के लिए [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) का प्रयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिये [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) या `setAsLiteralDouble` का उपयोग करें।

निम्न उदाहरण एक कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट श्रृंखला और श्रेणियाँ होती हैं, फिर उसकी पहली श्रृंखला के मौजूदा बिंदुओं को क्रमशः 10, 20 आदि की गणना किए गए मान असाइन करता है। यह प्रेजेंटेशन को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

बिंदु मान स्रोत प्रकार [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) से अलग होता है, जो चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटरेल्स का उपयोग करने से स्वचालित रूप से एम्बेडेड वर्कबुक नहीं हटता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम और अन्य श्रृंखलाओं के लिये उपलब्ध रहता है। वर्कबुक प्रबंधन के लिये देखें [Chart Workbook](/slides/hi/java/chart-workbook/)।

स्कैटर और बबल चार्ट्स के लिये, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) का उपयोग करके क्रमशः [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) और [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) के स्रोत चुनें। बबल चार्ट्स [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) को भी उपयोग करते हैं ताकि [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) की स्रोत तय हो सके। प्रत्येक लागू स्रोत को `DoubleLiterals` में सेट करें और फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्याएँ असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप करते हैं, -100 से 100 प्रतिशत तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल‑पढ़ने योग्य प्रोज़ेक्शन है। सभी संगत श्रृंखलाओं को अपडेट करने के लिये [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दर्शाते हैं; संयोजन चार्ट में असंबद्ध श्रृंखला समूहों को यह प्रभावित नहीं करता।

निम्न उदाहरण पहली श्रृंखला को शामिल करने वाले समूह का ओवरलैप सेट करता है:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // नया चार्ट नमूना श्रृंखलाएँ, श्रेणियाँ, और मान शामिल करता है।
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

## **श्रृंखला फ़िल रंग बदलें**

पूरी श्रृंखला के लिये डिफ़ॉल्ट फ़िल सेट करने हेतु [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) का प्रयोग करें। यदि किसी बिंदु का पहले से स्पष्ट फ़िल सेट है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिये श्रृंखला फ़िल को अधिलेखित करती है।

निम्न उदाहरण पहली श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलें**

एक श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और सामान्यतः लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिये डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, स्तंभ 1 पर स्थित है और पहली श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में नामित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) द्वारा पहले से संदर्भित सेल को भी अपडेट कर सकते हैं। यह दृष्टिकोण मौजूदा चार्ट में किसी विशेष पंक्ति और स्तंभ का अनुमान लगाने से बचाता है:

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

### **एकाधिक सेल्स से नाम वाली श्रृंखला बनाएं**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग‑अलग वर्कबुक सेल में संग्रहीत हों, तो संयुक्त श्रृंखला नाम उपयोगी होता है। उदाहरण के लिये, आप B1 में `Product A` और C1 में `2026` को एक ही श्रृंखला नाम में सम्मिलित कर सकते हैं, जबकि दोनों भाग स्रोत सेल से जुड़े रहते हैं।

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) का उपयोग करके नाम रेंज को प्राप्त करें, फिर उसे [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) को पास करें। `skipHiddenCells` तर्क निर्धारित करता है कि छिपे हुए सेल्स शामिल हों या नहीं: `true` उन्हें बाहर करता है, जबकि `false` शामिल करता है। इस उदाहरण में `false` का उपयोग करके नाम रेंज के सभी सेल्स को शामिल किया गया है।

निम्न उदाहरण एक प्रेजेंटेशन बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल देते हैं, और B2:B3 संख्यात्मक मान देते हैं।

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

    // ये दो सेल्स श्रृंखला नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // अलग-अलग सेल्स श्रेणियाँ और संख्यात्मक डेटा पॉइंट्स प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` होगा, दो सेल मानों के मध्य एक स्पेस के साथ। लेजेंड इसे दोनों स्तंभों के लिये एक ही प्रविष्टि के रूप में दर्शाता है। नीचे की छवि परिणाम को दर्शाती है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करें**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) श्रृंखला इंडेक्स और चार्ट शैली से गणना किया गया रंग लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से केवल गणना किया गया रंग पढ़ा जाता है; नया फ़िल असाइन नहीं किया जाता।

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

## **एक चार्ट श्रृंखला के लिये इनवर्ट फ़िल रंग सेट करें**

बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) का उपयोग करके नकारात्मक मानों को एक अलग फ़िल के साथ दिखाया जा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इनवर्शन को सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) से असाइन करें। नकारात्मक संख्याएँ वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका प्रदर्शित रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से बदलता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, स्तंभ 0 में श्रेणी नाम, और स्तंभ 1 में मान होते हैं:

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

आप [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के द्वारा एक बिंदु के लिये इनवर्शन सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिये इनवर्शन अक्षम है और केवल चयनित बिंदु के लिये सक्षम किया गया है। बिंदु को नकारात्मक मान भी असाइन किया गया है ताकि प्रभाव दिखाई दे:

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

## **विशिष्ट डेटा बिंदु मान साफ़ करें**

एक बिंदु को खाली करने के लिये, उसके आधारभूत वर्कबुक सेल को `null` सेट करें, अन्य बिंदुओं को हटाए बिना। कॉलम चार्ट में, प्लॉटेड मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) के द्वारा उपलब्ध है। डेटा बिंदु वही श्रेणी स्थिति में रहता है, पर चार्ट अपने ब्लैंक‑वैल्यू सेटिंग के अनुसार इसे खाली मानता है।

निम्न उदाहरण पहली श्रृंखला के दूसरे बिंदु को ही साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु रखना चाहते हैं, तो [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) को न कॉल करें, क्योंकि यह मेथड कलेक्शन से सभी बिंदुओं को हटाता है।

## **खाली सेल्स के प्रदर्शन का नियंत्रण करें**

छिपे हुए सेल्स जो मान रखते हैं, खाली सेल्स से अलग होते हैं। छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा को शामिल या बहिष्कृत करने के लिये देखें [Include Data from Hidden Rows and Columns](/slides/hi/java/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा को दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान दर्शाता है। किसी सेल को खाली करने के लिये [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) को `null` पास करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग से स्वतंत्र रूप से शून्य ही रहेगा।

चार्ट को खाली सेल्स कैसे दिखाने हैं, यह चुनने के लिये [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करें। यह सेटिंग पूरी चार्ट पर लागू होती है और ब्लैंक्स के प्लॉटिंग तरीके को बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेशन मान से भरें।

निम्न स्वयं‑समावेशी उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ वही चार्ट सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं। [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, स्तंभ 0 को श्रेणी लेबल और स्तंभ 1 को मान हेतु उपयोग करता है; पंक्ति 0 श्रृंखला नाम रखती है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

    // Day 3 को वास्तव में खाली छोड़ें, जबकि उसकी श्रेणी और डेटा बिंदु को बनाए रखें।
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

प्रत्येक आउटपुट फ़ाइल सहेजने से पहले असाइन किए गए मोड को दर्शाती है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिये, इच्छित मोड असाइन करें और प्रेजेंटेशन को एक बार सहेजें, मोड्स पर क्रमिक रूप से नहीं।

नीचे का तुलना समान डेटा को सभी तीन फ़ाइलों में दिखाती है। दिन 3 हर मामले में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखाया गया प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट सभी तीन मोड को आसान तुलना के लिये दिखाता है। बार और कॉलम चार्ट में कोई लाइन नहीं होने के कारण `Span` उपर्युक्त कनेक्शन नहीं बना पाता; एक गायब कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी प्रकार, केवल मार्कर वाले स्कैटर चार्ट में कोई कनेक्टिंग लाइन नहीं होती। सभी चार्ट प्रकारों में तीन विशिष्ट परिणाम की अपेक्षा न रखें; अपने उपयोग के प्रकार के लिये आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई आसन्न बार या कॉलम क्लस्टर्स के बीच की जगह है, जो बार या कॉलम चौड़ाई के प्रतिशत के रूप में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि किसी एकल श्रृंखला से। समूह के लिये एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। उच्च मान क्लस्टर्स के बीच अधिक जगह बनाता है; कम मान उन्हें घना बनाता है।

निम्न उदाहरण गैप चौड़ाई बदलता है और केवल अंतिम प्रेजेंटेशन को सहेजता है:

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

[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) enumeration द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनके श्रृंखला सभी में समान मान संरचना या सेटिंग नहीं होती। उदाहरण के लिये, श्रेणी चार्ट श्रेणियाँ और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान उपयोग करते हैं, और बबल चार्ट बबल आकार जोड़ते हैं। श्रृंखला प्रकार से मेल खाने वाले डेटा‑बिंदु निर्माण मेथड का उपयोग करें। ओवरलैप और गैप चौड़ाई जैसे विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर प्लॉटिंग सेटिंग्स साझा करती हैं। एक संयोजन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला से पहुँचा गया समूह सभी श्रृंखलाओं को आवश्यक नहीं कि बदल दे।

**क्या नया बनाए गया चार्ट डिफ़ॉल्ट डेटा रखता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखला, श्रेणियाँ और मान बनाता है। आप इन सेल्स को संपादित कर सकते हैं या पूरी तरह कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी कलेक्शन को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) में सेल्स को संदर्भित करते हैं। संदर्भित सेल को बदलने से सम्बंधित चार्ट तत्व अपडेट होता है। कस्टम डेटा बनाते समय, श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के नीचे प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु को कैसे साफ़ करूँ?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु का श्रेणी स्थान खाली बिंदु के रूप में बना रहे। पूरी श्रृंखला के सभी बिंदुओं को हटाने के लिये केवल [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग करें।

**खाली बिंदु कैसे दर्शाए जाते हैं?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) के द्वारा कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान या निकटवर्ती बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपस्थिति डेटा के अर्थ के अनुसार उपयुक्त सेटिंग चुनें। विस्तृत उदाहरण और दृश्य तुलना के लिये देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मानों का फ़ॉर्मेट क्या है?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिये, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा लौटाए गए रंग को सेट करें। आप [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के द्वारा व्यक्तिगत बिंदु के लिये व्यवहार को ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहित संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों तो कौन जीतेगा?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिये प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित न हो, स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। समूह सेटिंग्स जैसे ओवरलैप और गैप चौड़ाई लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर की फ़ॉर्मेटिंग को ओवरराइड नहीं करतीं।

**क्या चार्ट में रखने योग्य श्रृंखलाओं की कोई सीमा है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑संख्या सीमा नहीं लगाती। व्यावहारिक रूप से, प्रेजेंटेशन फ़ाइल सीमाएँ, उपलब्ध मेमोरी, रेंडरिंग समय और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत करीब या बहुत दूर हों तो क्या बदलें?**

संगत पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाने से क्लस्टर्स के बीच की दूरी बढ़ेगी, घटाने से वे करीब आएँगे।