---
title: जावा का उपयोग करके प्रेजेंटेशन चार्ट में कॉलआउट प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/java/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में कॉलआउट बनाएँ और शैलीबद्ध करें संक्षिप्त कोड उदाहरणों के साथ, PPT और PPTX के साथ संगत ताकि प्रेजेंटेशन कार्यप्रवाह को स्वचालित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट के साथ कैसे काम करें, यह समझाता है। यह दिखाता है कि `setShowLabelAsDataCallout` मेथड का उपयोग करके लेबल को कॉलआउट के रूप में कैसे प्रदर्शित किया जाए, डॉनट चार्ट के लिए कॉलआउट‑संबंधी लेबल सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और यह नोट करता है कि जब प्रस्तुतियों को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मैट्स में निर्यात किया जाता है तो कॉलआउट और उनकी उपस्थिति संरक्षित रहती है।

## **कॉलआउट का उपयोग**

नई विधियाँ [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) और [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) को [DataLabelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/datalabelformat) वर्ग और [IDataLabelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatalabelformat) इंटरफ़ेस में जोड़ा गया है। ये विधियाँ निर्धारित करती हैं कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में प्रदर्शित होगा या डेटा लेबल के रूप में।

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **डोनट चार्ट के लिए कॉलआउट सेट करें**

Aspose.Slides for Java डोनट चार्ट के लिए सीरीज़ डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कॉलआउट को PDF, HTML5, SVG, या छवियों में प्रस्तुतिकरण परिवर्तित करने पर संरक्षित रखा जाता है?**

हां। कॉलआउट चार्ट रेंडरिंग का हिस्सा होते हैं, इसलिए जब आप इसे [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/java/export-to-html5/), [SVG](/slides/hi/java/render-a-slide-as-an-svg-image/), या [raster images](/slides/hi/java/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के स्वरूप के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट में काम करते हैं, और क्या उनका स्वरूप निर्यात पर संरक्षित रहता है?**

हां। Aspose.Slides [फ़ॉन्ट एम्बेडिंग](/slides/hi/java/embedded-font/) को प्रस्तुति में एम्बेड करने का समर्थन करता है और निर्यात जैसे [PDF](/slides/hi/java/convert-powerpoint-to-pdf/) के दौरान फ़ॉन्ट एम्बेडिंग नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।