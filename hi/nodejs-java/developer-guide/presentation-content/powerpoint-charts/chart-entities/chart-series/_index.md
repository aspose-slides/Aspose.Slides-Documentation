---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट डेटा श्रृंखला का प्रबंधन
linktitle: डेटा श्रृंखला
type: docs
url: /hi/nodejs-java/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रेणी रंग
- श्रृंखला रंग
- श्रृंखला नाम
- डेटा पॉइंट
- श्रृंखला गैप
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: PowerPoint (PPT/PPTX) के लिए जावास्क्रिप्ट में चार्ट श्रृंखला को प्रबंधित करना सीखें, व्यावहारिक कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ अपनी डेटा प्रस्तुतियों को बेहतर बनाएं।
---
## **अवलोकन**

यह लेख Aspose.Slides में [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/) की भूमिका का वर्णन करता है, जिसमें प्रस्तुतियों में डेटा कैसे संरचित और दृश्य बनाया जाता है, इस पर ध्यान केंद्रित किया गया है। ये ऑब्जेक्ट्स बुनियादी तत्व प्रदान करते हैं जो चार्ट में व्यक्तिगत डेटा पॉइंट सेट, श्रेणियाँ और उपस्थिति पैरामीटर को परिभाषित करते हैं। [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/) के साथ काम करके, डेवलपर्स अंतर्निहित डेटा स्रोतों को आसानी से एकीकृत कर सकते हैं और जानकारी कैसे प्रदर्शित होती है, इस पर पूर्ण नियंत्रण बनाए रख सकते हैं, जिससे गतिशील, डेटा-चालित प्रस्तुतियां प्राप्त होती हैं जो स्पष्ट रूप से अंतर्दृष्टि और विश्लेषण को संप्रेषित करती हैं।

एक श्रृंखला चार्ट में प्लॉट किए गए संख्याओं की पंक्ति या स्तंभ होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#getOverlap) मेथड के साथ, आप निर्धारित कर सकते हैं कि 2D चार्ट में बार और कॉलम कितने ओवरलैप हों (रेंज: -100 से 100)। यह प्रॉपर्टी पैरेंट सीरीज ग्रुप की सभी श्रृंखलाओं पर लागू होती है: यह उपयुक्त समूह प्रॉपर्टी का प्रोजेक्शन है। इसलिए, यह प्रॉपर्टी केवल-रेड है।

अपने इच्छित `Overlap` मान को सेट करने के लिए `ParentSeriesGroup.getOverlap` रीड/राइट प्रॉपर्टी का उपयोग करें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. पहले चार्ट सीरीज तक पहुँचें।
1. चार्ट सीरीज की `ParentSeriesGroup` तक पहुँचें और सीरीज के लिए अपना इच्छित ओवरलैप मान सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि चार्ट सीरीज के लिए ओवरलैप कैसे सेट किया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // चार्ट जोड़ता है
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // श्रृंखला ओवरलैप सेट करता है
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीरीज का रंग बदलें**

Aspose.Slides for Node.js via Java आपको इस प्रकार सीरीज का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपनी इच्छित फ़िल टाइप और फ़िल रंग सेट करें।
1. परिवर्तित प्रस्तुति सहेजें।

यह JavaScript कोड दिखाता है कि सीरीज का रंग कैसे बदला जाता है:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीरीज श्रेणी का रंग बदलें**

Aspose.Slides for Node.js via Java आपको इस प्रकार सीरीज श्रेणी का रंग बदलने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड पर चार्ट जोड़ें।
1. उस सीरीज श्रेणी तक पहुँचें जिसका रंग आप बदलना चाहते हैं।
1. अपनी इच्छित फ़िल टाइप और फ़िल रंग सेट करें।
1. परिवर्तित प्रस्तुति सहेजें।

यह JavaScript कोड दिखाता है कि सीरीज श्रेणी का रंग कैसे बदला जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीरीज का नाम बदलें**

डिफ़ॉल्ट रूप से, चार्ट के लेजेंड नाम प्रत्येक कॉलम या डेटा पंक्तियों के ऊपर वाले सेल की सामग्री होते हैं।

हमारे उदाहरण (नमूना छवि) में,

* कॉलम हैं *Series 1, Series 2,* और *Series 3*;
* पंक्तियाँ हैं *Category 1, Category 2, Category 3,* और *Category 4.* 

Aspose.Slides for Node.js via Java आपको चार्ट डेटा और लेजेंड में सीरीज का नाम अपडेट या बदलने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि चार्ट डेटा `ChartDataWorkbook` में सीरीज का नाम कैसे बदला जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह JavaScript कोड दिखाता है कि लेजेंड के माध्यम से `Series` के माध्यम से सीरीज नाम कैसे बदला जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट श्रृंखला भरने का रंग सेट करें**

Aspose.Slides for Node.js via Java आपको इस प्रकार प्लॉट क्षेत्र के भीतर चार्ट श्रृंखला के लिए स्वचालित भराव रंग सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी पसंदीदा प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें (निचले उदाहरण में, हमने `ChartType.ClusteredColumn` का उपयोग किया)।
1. चार्ट सीरीज तक पहुँचें और भराव रंग को Automatic सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह JavaScript कोड दिखाता है कि चार्ट सीरीज के लिए स्वचालित भराव रंग कैसे सेट किया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बनाता है
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // श्रृंखला भराव फ़ॉर्मेट को स्वचालित सेट करता है
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // प्रस्तुति फ़ाइल को डिस्क पर लिखता है
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट श्रृंखला उलटा भराव रंग सेट करें**

Aspose.Slides आपको इस प्रकार प्लॉट क्षेत्र के भीतर चार्ट श्रृंखला के लिए उलटा भराव रंग सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. अपनी पसंदीदा प्रकार के आधार पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें (निचले उदाहरण में, हमने `ChartType.ClusteredColumn` का उपयोग किया)।
1. चार्ट सीरीज तक पहुँचें और भराव रंग को उलटा सेट करें।
1. प्रस्तुति को PPTX फ़ाइल में सहेजें।

यह JavaScript कोड संचालन को प्रदर्शित करता है:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // नई श्रृंखला और श्रेणियाँ जोड़ता है
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // पहली चार्ट श्रृंखला लेता है और उसकी श्रृंखला डेटा भरता है।
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मूल्य नकारात्मक होने पर श्रृंखला को उलटा सेट करें**

Aspose.Slides आपको `ChartDataPoint.setInvertIfNegative` मेथड के माध्यम से उलटे सेट करने की अनुमति देता है। जब प्रॉपर्टियों का उपयोग करके उलटा सेट किया जाता है, तो डेटा पॉइंट नकारात्मक मान मिलने पर अपने रंग उलट लेता है।

यह JavaScript कोड संचालन को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **विशिष्ट डेटा पॉइंट्स का डेटा साफ़ करें**

Aspose.Slides for Node.js via Java आपको इस प्रकार विशिष्ट चार्ट सीरीज के लिए `DataPoints` डेटा को साफ़ करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. इंडेक्स के द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. इंडेक्स के द्वारा चार्ट का रेफ़रेंस प्राप्त करें।
4. सभी चार्ट `DataPoints` पर इटरिटेट करें और `XValue` तथा `YValue` को null सेट करें।
5. विशिष्ट चार्ट सीरीज के लिए सभी`DataPoints` साफ़ करें।
6. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड संचालन को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सीरीज गैप की चौड़ाई सेट करें**

Aspose.Slides for Node.js via Java आपको इस प्रकार **`GapWidth`** प्रॉपर्टी के माध्यम से सीरीज की गैप चौड़ाई सेट करने की अनुमति देता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. पहले स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. किसी भी चार्ट सीरीज तक पहुँचें।
1. `GapWidth` प्रॉपर्टी सेट करें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि सीरीज की गैप चौड़ाई कैसे सेट की जाती है:

```javascript
// खाली प्रस्तुति बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति की पहली स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ता है
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // चार्ट डेटा शीट का इंडेक्स सेट करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // श्रृंखला जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // श्रेणियाँ जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // दूसरी चार्ट श्रृंखला लेता है
    var series = chart.getChartData().getSeries().get_Item(1);
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
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **पूछे जाने वाले प्रश्न**

**क्या एक एकल चार्ट में रखे जा सकने वाली श्रृंखलाओं की संख्या पर कोई सीमा है?**

Aspose.Slides द्वारा जोड़ी जाने वाली श्रृंखलाओं की संख्या पर कोई निश्चित सीमा नहीं लगाई गई है। व्यावहारिक सीमा चार्ट की पठनीयता और आपके अनुप्रयोग में उपलब्ध मेमोरी द्वारा निर्धारित होती है।

**यदि क्लस्टर के भीतर कॉलम बहुत करीब या बहुत दूर हों तो क्या किया जाए?**

उन श्रृंखलाओं (या उनके पैरेंट सीरीज ग्रुप) के लिए Gap Width सेटिंग को समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ेगी, जबकि घटाने से वे एक-दूसरे के अधिक नज़दीक आ जाएँगे।