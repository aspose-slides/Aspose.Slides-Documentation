---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट डेटा श्रृंखलाओं को प्रबंधित करें
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
## **अवलोकन**

एक चार्ट अपने प्लॉट किए गए मानों को वर्कबुक सेल्स में या सीधे संख्यात्मक लिटरल के रूप में संग्रहीत कर सकता है। एक [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) संबंधित मानों का एक सेट दर्शाता है, और प्रत्येक [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) उस श्रृंखला में एक बिंदु दर्शाता है। [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) ऑब्जेक्ट्स लेबल या समूह मान प्रदान करते हैं जो श्रृंखला द्वारा साझा किए जाते हैं। डिफ़ॉल्ट डेटा के साथ बनाए गए चार्ट्स में, श्रृंखला नाम, श्रेणियां, और बिंदु मान चार्ट वर्कबुक से [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) ऑब्जेक्ट्स का उपयोग करते हैं।

एक सामान्य श्रेणी चार्ट के लिए, डिफ़ॉल्ट वर्कबुक में श्रृंखला नामों के लिए पंक्ति 0, श्रेणी नामों के लिए कॉलम 0, और शेष सेल्स श्रृंखला मानों के लिए उपयोग होते हैं। [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) को पास किए जाने वाले वर्कशीट, पंक्ति, और कॉलम सूचकांक शून्य-आधारित होते हैं। यह लेआउट तब उपयोगी होता है जब आप डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाते हैं, लेकिन यह न मानें कि हर मौजूदा चार्ट इसका उपयोग करता है। लोडेड प्रस्तुति के लिए, वर्कबुक मान बदलने से पहले श्रृंखला, श्रेणियां, और डेटा बिंदुओं द्वारा संदर्भित सेल्स को जाँचें।

चार्ट सेटिंग्स के तीन अलग-अलग स्कोप होते हैं:

- श्रृंखला-स्तर सेटिंग्स, जैसे [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) एक श्रृंखला के सभी बिंदुओं के लिए डिफ़ॉल्ट दिखावट प्रदान करती हैं।
- डेटा‑बिंदु सेटिंग्स, जैसे [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) एक बिंदु के लिए श्रृंखला की दिखावट को अधिलेखित करती हैं।
- समूह सेटिंग्स संगत श्रृंखलाओं पर लागू होती हैं जो एक ही [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) से संबंधित होती हैं। जब आपको ओवरलैप या गैप चौड़ाई जैसे विकल्प सेट करने की आवश्यकता हो, तो [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें।

जब कोई स्पष्ट बिंदु या श्रृंखला फ़िल सेट नहीं किया गया हो, तो चार्ट शैली और थीम स्वचालित दिखावट निर्धारित करती हैं। जब दोनों श्रृंखला और बिंदु फ़ॉर्मेटिंग मौजूद हों, तो बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता रखती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

एक क्लस्टर्ड सिलिंडर चार्ट के लिए, देखें कि कैसे [3D श्रृंखला प्रकार या बार आकार बदलना](/slides/hi/androidjava/3d-chart/#change-the-3d-series-type-and-bar-shape) पहले श्रृंखला को प्रभावित करता है।

## **संख्यात्मक लिटरल का उपयोग करके श्रृंखला मान सेट करना**

जब श्रृंखला मान एप्लिकेशन डेटा या गणनाओं से आते हैं और उन्हें वर्कशीट सेल संदर्भों की आवश्यकता नहीं होती, तब संख्यात्मक लिटरल का उपयोग करें। प्रत्येक बिंदु के [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) परिणाम को [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) के माध्यम से असाइन करने से पहले [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) को [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) के साथ कॉल करें।

कलेक्शन सेटिंग उस श्रृंखला में सभी बिंदु मानों के स्रोत प्रकार को नियंत्रित करती है। प्रत्येक बिंदु मान की [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) मेथड चयनित प्रकार को रिपोर्ट करती है; कलेक्शन सेटिंग के माध्यम से इसे बदलें। `Worksheet` के साथ, संदर्भित सेल तक पहुँचने के लिए [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) का उपयोग करें। `DoubleLiterals` के साथ, संख्या को सीधे पढ़ने या लिखने के लिए [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) या `setAsLiteralDouble` का उपयोग करें।

निम्न उदाहरण डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ एक कॉलम चार्ट बनाता है, फिर प्रथम श्रृंखला के मौजूदा बिंदुओं को 10, 20, इत्यादि की गणना किए गए मान असाइन करता है। यह प्रस्तुति को सहेजता है, पुनः खोलता है, और संग्रहीत मानों को प्रिंट करता है।

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

बिंदु मान स्रोत प्रकार [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) से अलग है, जो चार्ट की आंतरिक या बाह्य वर्कबुक कॉन्फ़िगरेशन को पहचानता है। संख्यात्मक लिटरल का उपयोग करने से स्वंयं एम्बेडेड वर्कबुक नहीं हटता। इस उदाहरण में, वर्कबुक श्रेणी लेबल, श्रृंखला नाम, और अन्य श्रृंखलाओं के लिए उपलब्ध रहती है। वर्कबुक प्रबंधन के लिए देखें [Chart Workbook](/slides/hi/androidjava/chart-workbook/)।

स्कैटर और बबल चार्ट के लिए, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) और [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) का उपयोग करके क्रमशः [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) और [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) के स्रोत चुनें। बबल चार्ट के लिए [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) का उपयोग करके [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) के स्रोत चुनें। प्रत्येक लागू स्रोत को `DoubleLiterals` में सेट करें, फिर उस मान के `setAsLiteralDouble` मेथड के माध्यम से संख्या असाइन करें।

## **चार्ट श्रृंखला ओवरलैप सेट करना**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) रिपोर्ट करता है कि 2D चार्ट में बार या कॉलम कितनी ओवरलैप करते हैं, -100 से 100 % तक। यह पैरेंट श्रृंखला समूह पर सेटिंग का केवल-पढ़ने योग्य प्रोजेक्शन है। उस समूह की सभी संगत श्रृंखलाओं को अपडेट करने के लिए [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) का उपयोग करें। यह विकल्प उन चार्ट प्रकारों पर लागू होता है जो समूहित बार या कॉलम दिखाते हैं; यह कॉम्बिनेशन चार्ट में असंबद्ध श्रृंखला समूहों को प्रभावित नहीं करता।

निम्न उदाहरण प्रथम श्रृंखला वाले समूह के लिए ओवरलैप सेट करता है:

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

![The series overlap](series_overlap.png)

## **श्रृंखला फ़िल रंग बदलना**

पूरी श्रृंखला के लिए डिफ़ॉल्ट फ़िल सेट करने के लिए [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) का उपयोग करें। यदि किसी बिंदु के पास पहले से स्पष्ट फ़िल है, तो उसका [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) सेटिंग उस बिंदु के लिए श्रृंखला फ़िल को अधिलेखित करता है।

निम्न उदाहरण प्रथम श्रृंखला पर ठोस नीला फ़िल लागू करता है:

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

## **श्रृंखला नाम बदलना**

श्रृंखला नाम चार्ट डेटा वर्कबुक में संग्रहीत होता है और आमतौर पर लेजेंड में दिखाया जाता है। क्लस्टर्ड कॉलम चार्ट के लिए बनाए गए डिफ़ॉल्ट वर्कबुक में, सेल B1 पंक्ति 0, कॉलम 1 पर स्थित होता है और प्रथम श्रृंखला का नाम रखता है। नीचे दिए गए उदाहरण में नामांकित स्थिरांक इस संरचना को स्पष्ट करते हैं:

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

आप [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) द्वारा पहले ही संदर्भित सेल को भी अपडेट कर सकते हैं। यह तरीका मौजूदा चार्ट में किसी विशिष्ट पंक्ति और कॉलम को मानते हुए समस्या से बचाता है:

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

### **एकाधिक सेल्स से नाम वाली श्रृंखला बनाना**

जब उत्पाद नाम और रिपोर्टिंग अवधि अलग-अलग वर्कबुक सेल्स में संग्रहीत हों, तो मिश्रित श्रृंखला नाम उपयोगी होता है। उदाहरण के लिए, आप B1 में `Product A` और C1 में `2026` को मिलाकर एकल श्रृंखला नाम बना सकते हैं, जबकि दोनों भाग अपने स्रोत सेल्स से जुड़े रहें।

नाम रेंज प्राप्त करने के लिए [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) का उपयोग करें, फिर उस कलेक्शन को [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) को पास करें। `skipHiddenCells` तर्क यह नियंत्रित करता है कि छिपे हुए सेल्स शामिल हों या नहीं: `true` उन्हें बाहर करता है, जबकि `false` उन्हें शामिल करता है। यह उदाहरण नाम रेंज में प्रत्येक सेल को शामिल करने के लिए `false` का उपयोग करता है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें एक श्रृंखला और दो डेटा बिंदु होते हैं। सेल B1:C1 केवल श्रृंखला नाम प्रदान करते हैं; A2:A3 श्रेणी लेबल देते हैं, और B2:B3 संख्यात्मक मान देते हैं।

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

    // ये दो सेल्स श्रृंखला का नाम प्रदान करती हैं।
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // अलग-अलग सेल्स श्रेणियों और संख्यात्मक डेटा बिंदुओं को प्रदान करती हैं।
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

परिणामी श्रृंखला नाम `Product A 2026` है, दो सेल मानों के बीच एक स्पेस के साथ। लेजेंड इसे दोनों कॉलमों के लिए एक ही प्रविष्टि के रूप में दिखाता है। नीचे की छवि परिणाम दर्शाती है:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **स्वचालित श्रृंखला फ़िल रंग प्राप्त करना**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) एन्ड्रॉइड ARGB रंग पूर्णांक के रूप में श्रृंखला इंडेक्स और चार्ट शैली से गणना किए गए रंग को लौटाता है। यह वह रंग है जो तब उपयोग होता है जब श्रृंखला फ़िल स्पष्ट रूप से परिभाषित नहीं किया गया हो। इस मेथड को कॉल करने से गणना किया गया रंग पढ़ा जाता है; यह नया फ़िल असाइन नहीं करता।

निम्न उदाहरण प्रत्येक डिफ़ॉल्ट श्रृंखला का स्वचालित रंग पूर्णांक प्रिंट करता है:

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

## **एक चार्ट श्रृंखला के लिए इनवर्ट फ़िल रंग सेट करना**

बार, कॉलम, और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) का उपयोग करके नकारात्मक मानों को अलग फ़िल के साथ दिखाया जा सकता है। नियमित श्रृंखला फ़िल को ठोस सेट करें, इन्भर्जन सक्षम करें, और नकारात्मक‑मान रंग को [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) के माध्यम से असाइन करें। नकारात्मक संख्याएं वर्कबुक में अपरिवर्तित रहती हैं; केवल उनका डिस्प्ले रंग बदलता है।

निम्न उदाहरण डिफ़ॉल्ट चार्ट डेटा को एक श्रृंखला से प्रतिस्थापित करता है। वर्कशीट पंक्ति 0 में श्रृंखला नाम, कॉलम 0 में श्रेणी नाम, और कॉलम 1 में मान होते हैं:

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

आप एक बिंदु के लिए इन्भर्जन को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के माध्यम से सक्षम कर सकते हैं। नीचे के उदाहरण में श्रृंखला के लिए इन्भर्जन अक्षम किया गया है और केवल चयनित बिंदु के लिए सक्षम किया गया है। बिंदु को भी नकारात्मक मान असाइन किया गया है ताकि प्रभाव दृश्य हो:

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

## **विशिष्ट डेटा बिंदु मान साफ़ करना**

एक बिंदु को खाली करने के लिए, उसके बैकिंग वर्कबुक सेल को `null` सेट करें, जबकि अन्य बिंदुओं को हटाए बिना रखें। कॉलम चार्ट के लिए, प्लॉट किया गया मान [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) के माध्यम से उपलब्ध होता है। डेटा बिंदु समान श्रेणी स्थिति पर बना रहता है, लेकिन चार्ट उसकी वैल्यू को ब्लैंक मान सेटिंग के अनुसार खाली मानता है।

निम्न उदाहरण प्रथम श्रृंखला में केवल दूसरे बिंदु को साफ़ करता है:

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

स्कैटर चार्ट अलग‑अलग X और Y सेल्स का उपयोग करते हैं, और बबल चार्ट एक आकार सेल भी उपयोग करता है। केवल उस सेल को साफ़ करें जो आप हटाना चाहते हैं। जब आप अन्य बिंदु रखना चाहते हैं, तब [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) को कॉल न करें, क्योंकि यह मेथड पूरी श्रृंखला के सभी बिंदुओं को हटा देता है।

## **खाली सेल्स के प्रदर्शन को नियंत्रित करना**

छिपे हुए सेल्स जिनमें मान होते हैं, वे खाली सेल्स से अलग होते हैं। छिपी हुई वर्कशीट पंक्तियों और कॉलम्स से डेटा को शामिल या बाहर करने के लिए देखें [Include Data from Hidden Rows and Columns](/slides/hi/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)।

एक खाली वर्कबुक सेल अनुपस्थित डेटा दर्शाता है; `0` वाला सेल ज्ञात संख्यात्मक मान का प्रतिनिधित्व करता है। किसी सेल को खाली बनाने के लिए [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) को `null` पास करें। संख्यात्मक शून्य ब्लैंक‑सेल सेटिंग के बावजूद शून्य ही रहता है।

[ IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) का उपयोग करके निर्धारित करें कि चार्ट खाली सेल्स को कैसे दिखाए। यह सेटिंग पूरे चार्ट पर लागू होती है। यह ब्लैंक्स को प्लॉट करने का तरीका बदलती है, बिना खाली वर्कबुक सेल को शून्य या इंटरपोलेशन मान से भरते हुए।

निम्न स्वतंत्र उदाहरण एक लाइन चार्ट बनाता है जिसमें एक श्रृंखला होती है, दिन 3 का मान साफ़ करता है, और प्रत्येक मोड के साथ उसी चार्ट को सहेजता है। कोई इनपुट फ़ाइल आवश्यक नहीं है। [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) वर्कशीट 0, कॉलम 0 को श्रेणी लेबल के लिए, और कॉलम 1 को मान के लिए उपयोग करता है; पंक्ति 0 में श्रृंखला नाम रखी होती है। अंतिम डेटा `10, 20, empty, 30, 40` है।

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

प्रत्येक आउटपुट फ़ाइल में सहेजे जाने से पहले असाइन किया गया मोड सम्मिलित होता है: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, और `empty_cells_Span.pptx`। केवल एक संस्करण सहेजने के लिए, इच्छित मोड असाइन करें और प्रस्तुति को एक बार सहेजें, मोड पर इटररेट करने के बजाय।

नीचे तुलना में सभी तीन फ़ाइलों में समान डेटा दिखाया गया है। दिन 3 प्रत्येक केस में वर्कबुक में खाली है:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

दिखा प्रभाव चार्ट प्रकार पर निर्भर करता है। लाइन चार्ट तीनों मोड को आसानी से तुलना करने देता है। बार और कॉलम चार्ट में एक गुम श्रेणी के ऊपर कनेक्ट करने के लिए कोई लाइन नहीं होती, इसलिए `Span` ऊपर दिखाया गया कनेक्टिंग सेगमेंट उत्पन्न नहीं कर सकता; एक गुम कॉलम और शून्य‑ऊँचाई वाला कॉलम भी समान दिख सकते हैं। इसी तरह, केवल मार्कर वाला स्कैटर चार्ट भी कोई कनेक्टिंग लाइन नहीं रखता। सभी चार्ट प्रकारों में तीन अलग-अलग परिणाम की उम्मीद न रखें; अपने उपयोग किए गए प्रकार के लिए आउटपुट जाँचें।

## **श्रृंखला गैप चौड़ाई सेट करना**

गैप चौड़ाई निकटवर्ती बार या कॉलम क्लस्टर्स के बीच की दूरी है, जो बार या कॉलम चौड़ाई के प्रतिशत में व्यक्त की जाती है। ओवरलैप की तरह, यह पैरेंट श्रृंखला समूह से संबंधित है, न कि एकल श्रृंखला से। समूह के लिए एक बार [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। बड़ा मान क्लस्टर्स के बीच अधिक जगह बनाता है; छोटा मान उन्हें अधिक घना बनाता है।

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

![The gap width](gap_width.png)

## **श्रृंखला लाइन्स दिखाएँ या छुपाएँ**

श्रृंखला लाइन्स चार्ट के संबंधित भागों को दृश्य रूप से जोड़ती हैं। समर्थित स्टैक्ड बार और OfPie चार्ट्स में इन्हें दिखाने या छुपाने के लिए [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) का उपयोग करें। दो‑आयामी स्टैक्ड बार और कॉलम चार्ट्स में, वे श्रेणियों के पार संबंधित स्टैक सीमाओं को जोड़ते हैं। Pie of Pie और Bar of Pie चार्ट्स में, वे मुख्य प्लॉट को द्वितीयक प्लॉट से जोड़ते हैं। यह सेटिंग अन्य चार्ट प्रकारों के लिए सामान्य कनेक्टर नहीं है।

[ IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुंचें। सेटिंग समूह की हर श्रृंखला पर लागू होती है। [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#hasSeriesLines--) केवल-पढ़ने योग्य है और पैरेंट समूह की सेटिंग को दर्शाता है; इसे अपडेट करने के लिए समूह के सेटर को कॉल करें।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [PieOfPie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#PieOfPie) चार्ट बनाता है। यह श्रृंखला लाइन्स को सक्षम और फिर अक्षम करके दो प्रस्तुति सहेजता है, तुलना के लिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| दो लाइन्स मुख्य पाई को द्वितीयक पाई से जोड़ती हैं। | दोनों पाई दिखाई देती हैं, लेकिन कनेक्टिंग लाइन्स छिपी हुई हैं। |

श्रृंखला लाइन्स डेटा लेबल लीडर लाइन्स से अलग होती हैं, जो लेबल को उनके डेटा बिंदुओं से जोड़ती हैं; ग्रिडलाइन, जो चार्ट एक्सिस के साथ अंतराल चिह्नित करती हैं; और लाइन चार्ट में लाइन्स, जो डेटा मानों को प्रदर्शित करती हैं। यह सेटिंग इन तत्वों को नियंत्रित नहीं करती।

## **FAQ**

**कौन से चार्ट प्रकार डेटा श्रृंखला को सपोर्ट करते हैं?**

[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) एनेमरेशन द्वारा प्रतिनिधित्व किए गए सभी चार्ट प्रकार डेटा का उपयोग करते हैं, लेकिन उनकी श्रृंखलाओं की संरचना या सेटिंग्स समान नहीं होतीं। उदाहरण के लिए, श्रेणी चार्ट श्रेणियां और मान उपयोग करते हैं, स्कैटर चार्ट X और Y मान, और बबल चार्ट बबल आकार जोड़ता है। डेटा‑बिंदु निर्माण मेथड को उस श्रृंखला प्रकार से मिलाएं। ओवरलैप और गैप चौड़ाई जैसी विकल्प केवल संगत बार या कॉलम समूहों पर लागू होते हैं।

**चार्ट श्रृंखला समूह क्या है?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) संगत श्रृंखलाओं को सम्मिलित करता है जो समूह‑स्तर प्लॉटिंग सेटिंग्स साझा करती हैं। एक कॉम्बिनेशन चार्ट में एक से अधिक समूह हो सकते हैं, इसलिए एक श्रृंखला के माध्यम से पहुंचा गया समूह सभी श्रृंखलाओं को आवश्यक रूप से बदल नहीं सकता।

**क्या नई बनी चार्ट में डिफ़ॉल्ट डेटा होता है?**

हां। डिफ़ॉल्ट रूप से, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) नमूना श्रृंखलाएं, श्रेणियां और मान बनाता है। आप उन सेल्स को संपादित कर सकते हैं या पूरी तरह से कस्टम डेटा सेट जोड़ने से पहले श्रृंखला और श्रेणी कलेक्शन दोनों को साफ़ कर सकते हैं। एक ओवरलोड भी डिफ़ॉल्ट डेटा के बिना चार्ट बना सकता है।

**चार्ट ऑब्जेक्ट्स वर्कबुक सेल्स से कैसे जुड़े होते हैं?**

श्रृंखला नाम, श्रेणी लेबल और डेटा‑बिंदु मान [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) में सेल्स का संदर्भ लेते हैं। संदर्भित सेल को बदलने से संबंधित चार्ट तत्व अपडेट होता है। जब आप कस्टम डेटा बनाते हैं, तो श्रेणी पंक्तियों और श्रृंखला‑मान पंक्तियों को इस तरह संरेखित रखें कि प्रत्येक बिंदु इच्छित श्रेणी के तहत प्लॉट हो।

**मैं पूरी श्रृंखला के बजाय एक बिंदु कैसे साफ़ करूं?**

संबंधित मान सेल को `null` सेट करें ताकि बिंदु की श्रेणी स्थिति खाली बिंदु के रूप में बनी रहे। केवल उस बिंदु को हटाने के लिए [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) का उपयोग न करें, क्योंकि यह मेथड पूरी श्रृंखला से सभी बिंदु हटा देता है।

**खाली बिंदु कैसे प्रदर्शित होते हैं?**

परिणाम चार्ट प्रकार और [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) में कॉन्फ़िगर किए गए मान पर निर्भर करता है। समर्थित चार्ट ब्लैंक्स को गैप, शून्य मान, या पड़ोसी बिंदुओं को जोड़कर दिखा सकते हैं। अपनी प्रस्तुति में अनुपलब्ध डेटा के अर्थ के अनुसार सेटिंग चुनें। पूर्ण उदाहरण और दृश्य तुलना के लिए देखें [Control the Display of Empty Cells](#control-the-display-of-empty-cells)।

**नकारात्मक मान कैसे फ़ॉर्मेट होते हैं?**

समर्थित बार, कॉलम और बबल श्रृंखलाओं के लिए, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) को कॉल करें और [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) द्वारा लौटाए गए रंग को सेट करें। आप व्यक्तिगत बिंदु के लिए इन्भर्जन को [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) के साथ ओवरराइड कर सकते हैं। ये मेथड फ़ॉर्मेटिंग को प्रभावित करते हैं, न कि संग्रहीत संख्यात्मक मानों को।

**जब श्रृंखला और बिंदु दोनों फ़ॉर्मेटेड हों तो कौन जीतेगा?**

स्पष्ट डेटा‑बिंदु फ़ॉर्मेटिंग उस बिंदु के लिए प्राथमिकता लेती है। अन्य बिंदु स्पष्ट श्रृंखला फ़ॉर्मेट या, जब श्रृंखला फ़ॉर्मेट परिभाषित नहीं है, तो स्वचालित चार्ट शैली और थीम का उपयोग जारी रखते हैं। ओवरलैप और गैप चौड़ाई जैसी समूह सेटिंग्स लेआउट को नियंत्रित करती हैं और बिंदु‑स्तर फ़ॉर्मेटिंग को अधिलेखित नहीं करतीं।

**क्या किसी चार्ट में शामिल की जा सकने वाली श्रृंखलाओं की सीमा है?**

Aspose.Slides कोई अलग स्थिर श्रृंखला‑गिनती सीमा नहीं लगाता। व्यावहारिक रूप से, प्रस्तुति फ़ाइल सीमाएं, उपलब्ध मेमोरी, रेंडरिंग समय, और चार्ट की पठनीयता उपयोगी सीमा निर्धारित करती हैं।

**जब कॉलम बहुत निकट या बहुत दूर हों तो मैं क्या बदलूं?**

उचित पैरेंट श्रृंखला समूह पर [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) कॉल करें। मान बढ़ाकर क्लस्टर्स के बीच की जगह बढ़ाएँ, या मान घटा कर उन्हें करीब लाएँ।