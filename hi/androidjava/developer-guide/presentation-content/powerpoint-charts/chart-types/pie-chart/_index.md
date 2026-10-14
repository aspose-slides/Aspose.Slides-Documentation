---
title: Android पर प्रस्तुतियों में पाई चार्ट को अनुकूलित करें
linktitle: पाई चार्ट
type: docs
url: /hi/androidjava/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट अनुकूलित करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ Android पर पाई चार्ट बनाएं और अनुकूलित करें। द्वितीयक प्लॉट कॉन्फ़िगर करें, डेटा लेबल प्रदर्शित करें, और PowerPoint में स्वचालित स्लाइस रंग लागू करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने के तरीकों को समझाता है। यह Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने तथा एक सामान्य पाई चार्ट के लिए स्वचालित स्लाइस रंग निर्धारित करने को दिखाता है।

उदाहरण चार्ट अनुकूलन कार्यों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, श्रेणी और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रस्तुति को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Android via Java, Pie of Pie और Bar of Pie चार्ट के लिए द्वितीयक प्लॉट विकल्पों का समर्थन करता है। ये विकल्प द्वितीयक प्लॉट का आकार तथा दो प्लॉट्स के बीच डेटा पॉइंट्स के विभाजन को नियंत्रित करते हैं।

निम्न उदाहरण नई प्रस्तुति में एक Pie of Pie चार्ट बनाता है और डेटा पॉइंट मानों को लेबल के रूप में प्रदर्शित करता है। [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) मेथड द्वितीयक प्लॉट का आकार मुख्य प्लॉट के 149% पर सेट करता है। [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) प्रतिशत‑आधारित विभाजन चुनता है, और [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) थ्रेशहोल्ड को 53% पर सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // मान प्रदर्शित करें और द्वितीयक प्लॉट को कॉन्फ़िगर करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **द्वितीयक प्लॉट के लिये श्रेणियों का चयन**

जब आप द्वितीयक प्लॉट में विशिष्ट श्रेणियों को समूहित करना चाहते हैं, चाहे उनके प्रतिशत मान कुछ भी हों, तब कस्टम विभाजन का उपयोग करें। उदाहरण के तौर पर, एक बिक्री रिपोर्ट Online और Events को साथ में दिखा सकती है ताकि पाठक इन दो चैनलों की तुलना कर सकें, भले ही वे कुल बिक्री के 35% और 10% के बराबर हों।

कस्टम विभाजन का उपयोग करने के लिये [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) को [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) के साथ कॉल करें और बिंदुओं को [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) के माध्यम से चुनें। कलेक्शन का [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) मेथड श्रृंखला में शून्य‑आधारित सूचकांक को स्वीकार करता है; डेटा पॉइंट ऑब्जेक्ट जोड़ने के लिये [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) का उपयोग करें। इस उदाहरण में, सूचकांक 1 Online को चुनता है, और सूचकांक 3 का बिंदु Events को चुनता है। Partners को भी अस्थायी रूप से जोड़ा जाता है, फिर इसे [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) द्वारा बाहर किया जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // डिफ़ॉल्ट डेटा को चैनल के अनुसार बिक्री से बदलें।
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // शून्य-आधारित सूचकांक द्वारा Online और डेटा पॉइंट ऑब्जेक्ट द्वारा Events चुनें।
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // चयन से Partners को बाहर करें बिना उसके स्रोत डेटा को हटाए।
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) और Events (10) द्वितीयक प्लॉट में अलग-अलग स्लाइस के रूप में दिखाई देते हैं। प्राथमिक प्लॉट में, वे 45 मान के साथ एक संयुक्त स्लाइस के रूप में दर्शाए जाते हैं, साथ ही Retail (40) और Partners (15) भी होते हैं। कस्टम चयन से Partners को हटाने से वह प्राथमिक प्लॉट में बना रहता है; यह श्रेणी या उसका मान चार्ट के स्रोत डेटा से नहीं हटाता।

निम्न छवि PowerPoint में सहेजी गई प्रस्तुति को दर्शाती है:
![द्वितीयक प्लॉट में Online और Events के साथ Pie of Pie चार्ट तथा प्राथमिक प्लॉट में उनका संयुक्त मान 45](pie_of_pie_custom.png)

## **स्वचालित पाई चार्ट स्लाइस रंग निर्धारित करें**

Aspose.Slides for Android via Java, पाई चार्ट के स्लाइस को स्वचालित रूप से विभिन्न रंग असाइन कर सकता है। निम्न उदाहरण केंद्रित शीर्षक वाले पाई चार्ट को बनाता है और डिफ़ॉल्ट डेटा को तीन तिमाही श्रेणियों और उनके मानों से बदलता है। [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) मेथड 20, 50 और 30 मानों को लेबल के रूप में दिखाता है, जबकि [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) प्रत्येक स्लाइस के लिये अलग रंग सक्षम करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // केंद्रित चार्ट शीर्षक जोड़ें।
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // प्रथम कार्यपत्रक का उपयोग करके डिफ़ॉल्ट डेटा को बदलें।
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // मान दिखाएँ और स्लाइस को विभिन्न रंग सौंपें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Pie of Pie और Bar of Pie विविधताएँ समर्थित हैं?**
हाँ, लाइब्रेरी [समर्थित करता है](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) पाई चार्ट के लिये द्वितीयक प्लॉट, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को छवि (उदाहरण के लिये, PNG) के रूप में निर्यात कर सकता हूँ?**
हाँ, आप [चार्ट को स्वयं छवि के रूप में निर्यात करें](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (जैसे PNG) पूरी प्रस्तुति को निर्यात किए बिना कर सकते हैं।