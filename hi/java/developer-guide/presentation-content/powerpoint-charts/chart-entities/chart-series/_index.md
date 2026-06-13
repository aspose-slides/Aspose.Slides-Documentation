---
title: Java का उपयोग करके प्रस्तुतियों में चार्ट डेटा सीरीज़ प्रबंधित करें
linktitle: डेटा सीरीज़
type: docs
url: /hi/java/chart-series/
keywords:
- चार्ट सीरीज़
- सीरीज़ ओवरलैप
- सीरीज़ रंग
- श्रेणी रंग
- सीरीज़ नाम
- डेटा पॉइंट
- सीरीज़ अंतराल
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) के लिए Java में चार्ट सीरीज़ को प्रबंधित करना सीखें, व्यावहारिक कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ, ताकि आपके डेटा प्रस्तुतियों को बेहतर बनाया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartseries/) की भूमिका का वर्णन करता है, जिसमें प्रस्तुतियों में डेटा कैसे संरचित और दृश्यित किया जाता है, इस पर ध्यान केंद्रित किया गया है। ये ऑब्जेक्ट चार्ट में व्यक्तिगत डेटा बिंदुओं, श्रेणियों और प्रदर्शन पैरामीटरों की परिभाषा करने वाले आधारभूत तत्व प्रदान करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartseries/) के साथ काम करके, डेवलपर अंतर्निहित डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और यह सुनिश्चित कर सकते हैं कि जानकारी कैसे प्रदर्शित होती है, इस पर पूर्ण नियंत्रण रख सकते हैं, जिससे गतिशील, डेटा-चालित प्रस्तुतियाँ मिलती हैं जो अंतर्दृष्टि और विश्लेषण को स्पष्ट रूप से व्यक्त करती हैं।

एक सीरीज़ चार्ट में प्लॉट किए गए संख्याओं की पंक्ति या स्तंभ होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट सीरीज़ ओवरलैप सेट करें**

इस [IChartSeriesOverlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/properties/overlap) प्रॉपर्टी के साथ, आप 2D चार्ट में बार और कॉलम के ओवरलैप की मात्रा निर्दिष्ट कर सकते हैं (रेंज: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज़ ग्रुप की सभी सीरीज़ पर लागू होती है: यह उपयुक्त ग्रुप प्रॉपर्टी का प्रोजेक्शन है। इसलिए, यह प्रॉपर्टी केवल‑पढ़ने योग्य है।

`ParentSeriesGroup.Overlap` पढ़ने/लिखने योग्य प्रॉपर्टी का उपयोग करके आप `Overlap` के लिए अपनी पसंदीदा मान सेट कर सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. स्लाइड पर क्लस्टर्ड कॉलम चार्ट जोड़ें।  
3. पहली चार्ट सीरीज़ तक पहुंचें।  
4. चार्ट सीरीज़ के `ParentSeriesGroup` तक पहुंचें और सीरीज़ के ओवरलैप मान को अपनी पसंद के अनुसार सेट करें।  
5. संशोधित प्रस्तुति को PPTX फाइल में लिखें।  

यह Java कोड दिखाता है कि चार्ट सीरीज़ के लिए ओवरलैप कैसे सेट करें:

```java
Presentation pres = new Presentation();
try {
    // चार्ट जोड़ता है
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // सीरीज़ ओवरलैप सेट करता है
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीरीज़ रंग बदलें**

Aspose.Slides for Java आपको इस तरह से सीरीज़ का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. स्लाइड पर चार्ट जोड़ें।  
3. उस सीरीज़ तक पहुंचें जिसका रंग आप बदलना चाहते हैं।  
4. अपना पसंदीदा फ़िल प्रकार और फ़िल रंग सेट करें।  
5. संशोधित प्रस्तुति को सेव करें।  

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

Aspose.Slides for Java आपको इस तरह से सीरीज़ श्रेणी का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. स्लाइड पर चार्ट जोड़ें।  
3. उस सीरीज़ श्रेणी तक पहुंचें जिसका रंग आप बदलना चाहते हैं।  
4. अपना पसंदीदा फ़िल प्रकार और फ़िल रंग सेट करें।  
5. संशोधित प्रस्तुति को सेव करें।  

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

## **सीरीज़ नाम बदलें** 

डिफ़ॉल्ट रूप से, चार्ट की लेजेंड नाम प्रत्येक कॉलम या डेटा पंक्ति के ऊपर स्थित कोशिकाओं की सामग्री होती है।  

उदाहरण में (नमूना छवि),  

* कॉलम *Series 1, Series 2,* और *Series 3* हैं;  
* पंक्तियाँ *Category 1, Category 2, Category 3,* और *Category 4* हैं।  

Aspose.Slides for Java आपको अपने चार्ट डेटा और लेजेंड में सीरीज़ नाम को अपडेट या बदलने की अनुमति देता है।  

यह Java कोड दिखाता है कि चार्ट डेटा `ChartDataWorkbook` में सीरीज़ का नाम कैसे बदलें:

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

यह Java कोड दिखाता है कि लेजेंड में `Series` के माध्यम से सीरीज़ नाम कैसे बदलें:

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

## **चार्ट सीरीज़ फ़िल रंग सेट करें**

Aspose.Slides for Java आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए ऑटोमैटिक फ़िल रंग इस तरह सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. अपनी पसंद के प्रकार (नीचे उदाहरण में हमने `ChartType.ClusteredColumn` उपयोग किया) के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें और फ़िल रंग को Automatic सेट करें।  
5. प्रस्तुति को PPTX फ़ाइल में सेव करें।  

यह Java कोड दिखाता है कि चार्ट सीरीज़ के लिए ऑटोमैटिक फ़िल रंग कैसे सेट करें:

```java
Presentation pres = new Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बनाता है
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // सीरीज़ फ़िल फ़ॉर्मेट को ऑटोमैटिक सेट करता है
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

## **चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग सेट करें**

Aspose.Slides आपको प्लॉट एरिया के भीतर चार्ट सीरीज़ के लिए इनवर्ट फ़िल रंग इस तरह सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. अपनी पसंद के प्रकार (नीचे उदाहरण में हमने `ChartType.ClusteredColumn` उपयोग किया) के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें और फ़िल रंग को invert सेट करें।  
5. प्रस्तुति को PPTX फ़ाइल में सेव करें।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // नई सीरीज़ और श्रेणियाँ जोड़ता है
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // पहली चार्ट सीरीज़ लेता है और उसके डेटा को भरता है।
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

## **मूल्य नकारात्मक होने पर सीरीज़ को इनवर्ट सेट करें**

Aspose.Slides आपको `IChartDataPoint.InvertIfNegative` और `ChartDataPoint.InvertIfNegative` प्रॉपर्टी के माध्यम से इनवर्ट सेट करने की अनुमति देता है। जब इन प्रॉपर्टी का उपयोग करके इनवर्ट सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपने रंगों को उलट देता है।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

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

## **विशिष्ट बिंदु डेटा साफ़ करें**

Aspose.Slides for Java आपको विशिष्ट चार्ट सीरीज़ के `DataPoints` डेटा को इस तरह साफ़ करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. इंडेक्स के माध्यम से चार्ट का संदर्भ प्राप्त करें।  
4. सभी चार्ट `DataPoints` पर इटरेट करें और `XValue` तथा `YValue` को null सेट करें।  
5. विशिष्ट चार्ट सीरीज़ के लिए सभी `DataPoints` साफ़ करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

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

## **सीरीज़ गैप चौड़ाई सेट करें**

Aspose.Slides for Java आपको **`GapWidth`** प्रॉपर्टी के माध्यम से सीरीज़ की गैप चौड़ाई इस तरह सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।  
2. पहली स्लाइड तक पहुंचें।  
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।  
4. किसी भी चार्ट सीरीज़ तक पहुंचें।  
5. `GapWidth` प्रॉपर्टी सेट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।  

यह Java कोड दिखाता है कि सीरीज़ की गैप चौड़ाई कैसे सेट करें:

```java
// खाली प्रस्तुति बनाता है 
Presentation pres = new Presentation();
try {
    // प्रस्तुति की पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // डिफॉल्ट डेटा के साथ चार्ट जोड़ता है
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // चार्ट डेटा शीट का इंडेक्स सेट करता है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // सीरीज़ जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // श्रेणियाँ जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // दूसरी चार्ट सीरीज़ लेता है
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // गैप चौड़ाई मान सेट करता है
    series.getParentSeriesGroup().setGapWidth(50);
    
    // प्रस्तुति को डिस्क पर सेव करता है
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक चार्ट में शामिल किए जाने वाले सीरीज़ की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा सीरीज़ की संख्या पर कोई स्थिर सीमा नहीं लगाई गई है। व्यावहारिक प्रतिबंध चार्ट की पठनीयता और आपके एप्लीकेशन में उपलब्ध मेमोरी द्वारा निर्धारित होते हैं।

**यदि क्लस्टर के भीतर कॉलम बहुत करीब या बहुत दूर हों तो क्या करें?**

उस सीरीज़ (या उसके पैरेंट सीरीज़ ग्रुप) के लिए `GapWidth` सेटिंग को समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ेगी, जबकि घटाने से वे करीब आ जाएँगे।