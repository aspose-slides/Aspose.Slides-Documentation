---
title: "एंड्रॉइड पर प्रस्तुतियों में चार्ट डेटा श्रृंखला प्रबंधित करें"
linktitle: "डेटा श्रृंखला"
type: docs
url: /hi/androidjava/chart-series/
keywords:
- "चार्ट श्रृंखला"
- "श्रृंखला ओवरलैप"
- "श्रृंखला रंग"
- "श्रेणी रंग"
- "श्रृंखला नाम"
- "डेटा पॉइंट"
- "श्रृंखला गैप"
- "PowerPoint"
- "प्रस्तुति"
- "Android"
- "Java"
- "Aspose.Slides"
description: "व्यावहारिक जावा कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ एंड्रॉइड पर PowerPoint (PPT/PPTX) के लिए चार्ट सीरीज़ को कैसे प्रबंधित करें, यह सीखें, ताकि आपकी डेटा प्रस्तुतियों को बेहतर बनाया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartseries/) की भूमिका का वर्णन करता है, जो प्रस्तुतियों में डेटा कैसे संरचित और दृश्यित होता है, इस पर केंद्रित है। ये ऑब्जेक्ट उन आधारभूत तत्वों को प्रदान करते हैं जो चार्ट में डेटा पॉइंट, श्रेणियों और रूप‑रंग पैरामीटर के व्यक्तिगत सेट को परिभाषित करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartseries/) के साथ काम करके, डेवलपर्स बुनियादी डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और जानकारी कैसे प्रदर्शित होती है, इस पर पूर्ण नियंत्रण रख सकते हैं, जिससे गतिशील, डेटा‑चालित प्रस्तुतियां बनती हैं जो स्पष्ट रूप से अंतर्दृष्टि और विश्लेषण को प्रस्तुत करती हैं।

एक श्रृंखला चार्ट में प्लॉट की गई संख्याओं की पंक्ति या स्तंभ होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#getOverlap--) मेथड के साथ आप निर्धारित कर सकते हैं कि 2D चार्ट में बार और कॉलम कितना ओवरलैप करेंगे (सीमा: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज़ समूह की सभी श्रृंखलाओं पर लागू होती है: यह उपयुक्त समूह प्रॉपर्टी का प्रोजेक्शन है। इसलिए, यह प्रॉपर्टी केवल‑पढ़ने योग्य है।

अपनी पसंदीदा ओवरलैप मान सेट करने के लिए `getParentSeriesGroup().setOverlap()` लिखने वाला मेथड उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. पहले चार्ट सीरीज़ तक पहुँचें।
1. चार्ट सीरीज़ के `ParentSeriesGroup` तक पहुँचें और श्रृंखला के लिए अपनी पसंदीदा ओवरलैप मान सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह Java कोड दिखाता है कि चार्ट सीरीज़ के ओवरलैप को कैसे सेट करें:

```java
Presentation pres = new Presentation();
try {
    // चार्ट जोड़ता है
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // श्रृंखला ओवरलैप सेट करता है
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ का रंग बदलें**

Aspose.Slides for Android via Java आपको सीरीज़ का रंग इस प्रकार बदलने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज़ तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपनी पसंदीदा भराव प्रकार और भराव रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दिखाता है कि सीरीज़ का रंग कैसे बदलें:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ श्रेणी का रंग बदलें**

Aspose.Slides for Android via Java आपको सीरीज़ श्रेणी का रंग इस प्रकार बदलने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज़ श्रेणी तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपनी पसंदीदा भराव प्रकार और भराव रंग सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दिखाता है कि सीरीज़ श्रेणी का रंग कैसे बदलें:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ का नाम बदलें**

डिफ़ॉल्ट रूप से, चार्ट की लेजेंड नाम प्रत्येक कॉलम या पंक्ति के ऊपर की सेल की सामग्री होते हैं।

हमारे उदाहरण (नमूना छवि) में,

* कॉलम हैं *Series 1, Series 2,* और *Series 3*;
* पंक्तियों में *Category 1, Category 2, Category 3,* और *Category 4* हैं।

Aspose.Slides for Android via Java आपको चार्ट डेटा और लेजेंड में सीरीज़ का नाम अपडेट या बदलने की अनुमति देता है।

यह Java कोड दिखाता है कि `ChartDataWorkbook` में चार्ट डेटा के भीतर सीरीज़ का नाम कैसे बदलें:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह Java कोड दिखाता है कि लेजेंड के माध्यम से `Series` के द्वारा सीरीज़ नाम कैसे बदलें:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट सीरीज़ भराव रंग सेट करें**

Aspose.Slides for Android via Java आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए स्वचालित भराव रंग इस प्रकार सेट करने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. अपनी पसंदीदा प्रकार (निचले उदाहरण में हमने `ChartType.ClusteredColumn` इस्तेमाल किया) के आधार पर डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें और भराव रंग को Automatic सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह Java कोड दिखाता है कि चार्ट सीरीज़ के लिए स्वचालित भराव रंग कैसे सेट करें:

```java
Presentation pres = new Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बनाता है
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // श्रृंखला भराव फ़ॉर्मेट को ऑटोमैटिक सेट करता है
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट सीरीज़ के लिए उल्टा भराव रंग सेट करें**

Aspose.Slides आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए उल्टा भराव रंग इस प्रकार सेट करने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. अपनी पसंदीदा प्रकार (निचले उदाहरण में हमने `ChartType.ClusteredColumn` इस्तेमाल किया) के आधार पर डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें और भराव रंग को invert सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // नई श्रृंखलाएँ और श्रेणियाँ जोड़ता है
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // पहली चार्ट श्रृंखला लेता है और उसकी श्रृंखला डेटा को भरता है।
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **नकारात्मक मान होने पर सीरीज़ को उल्टा सेट करें**

Aspose.Slides आपको `IChartDataPoint.InvertIfNegative` और `ChartDataPoint.InvertIfNegative` प्रॉपर्टी के माध्यम से उल्टा सेट करने की अनुमति देता है। जब इन प्रॉपर्टी के द्वारा उल्टा सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपना रंग बदल देता है।

यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट पॉइंट डेटा हटाएँ**

Aspose.Slides for Android via Java आपको किसी विशिष्ट चार्ट सीरीज़ के `DataPoints` डेटा को इस प्रकार साफ़ करने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. उसकी इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
3. उसकी इंडेक्स से चार्ट का संदर्भ प्राप्त करें.
4. सभी चार्ट `DataPoints` को इटररेट करें और `XValue` व `YValue` को null सेट करें।
5. विशिष्ट चार्ट सीरीज़ के सभी `DataPoints` को साफ़ करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह Java कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ का गैप चौड़ाई सेट करें**

Aspose.Slides for Android via Java आपको **`GapWidth`** प्रॉपर्टी के माध्यम से सीरीज़ की गैप चौड़ाई इस प्रकार सेट करने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. किसी भी चार्ट सीरीज़ तक पहुँचें।
1. `GapWidth` प्रॉपर्टी सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह Java कोड दिखाता है कि सीरीज़ की गैप चौड़ाई कैसे सेट करें:

```java
// खाली प्रस्तुति बनाता है 
Presentation pres = new Presentation();
try {
    // प्रस्तुति की पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // चार्ट डेटा शीट का इंडेक्स सेट करता है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // श्रंखला जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // श्रेणियाँ जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // दूसरी चार्ट श्रृंखला लेता है
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // श्रृंखला डेटा को भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // GapWidth मान सेट करता है
    series.getParentSeriesGroup().setGapWidth(50);
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक चार्ट में शामिल की जा सकने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा जोड़ने योग्य श्रृंखलाओं की संख्या पर कोई निश्चित सीमा निर्धारित नहीं की गई है। व्यावहारिक सीमा चार्ट की पठनीयता और आपके एप्लिकेशन में उपलब्ध मेमोरी द्वारा तय होती है।

**यदि क्लस्टर के भीतर कॉलम बहुत पास या बहुत दूर हों तो क्या करें?**

उस श्रृंखला (या उसके पैरेंट सीरीज़ समूह) के लिए `GapWidth` सेटिंग को समायोजित करें। मान बढ़ाने से कॉलम के बीच का अंतर बढ़ जाता है, जबकि मान घटाने से वे एक‑दूसरे के करीब आ जाते हैं।