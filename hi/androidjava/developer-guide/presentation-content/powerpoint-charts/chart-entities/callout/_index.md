---
title: Android पर प्रेज़ेंटेशन चार्ट में कॉलआउट प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/androidjava/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में संक्षिप्त Java कोड उदाहरणों के साथ कॉलआउट बनाएं और उनका शैलीकरण करें, PPT और PPTX के साथ संगत, ताकि प्रेज़ेंटेशन वर्कफ़्लो को स्वचालित किया जा सके."
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट के साथ काम करने का तरीका समझाता है। यह `setShowLabelAsDataCallout` मेथड का उपयोग करके लेबल को कॉलआउट के रूप में प्रदर्शित करने, डोनट चार्ट के लिए कॉलआउट‑संबंधी लेबल सेटिंग्स को कॉन्फ़िगर करने, और यह नोट करता है कि जब प्रेज़ेंटेशन को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मैट में एक्सपोर्ट किया जाता है तो कॉलआउट और उनका स्वरूप संरक्षित रहता है।

## **कॉलआउट का उपयोग**

नए मेथड्स [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) और [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) को [DataLabelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/datalabelformat) क्लास और [IDataLabelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat) इंटरफ़ेस में जोड़ा गया है। ये मेथड निर्धारित करते हैं कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में प्रदर्शित होगा या डेटा लेबल के रूप में।

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

Aspose.Slides for Android via Java डोनट चार्ट के लिए सीरीज डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक उदाहरण दिया गया है।

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

**क्या प्रस्तुति को PDF, HTML5, SVG या छवियों में बदलने पर कॉलआउट संरक्षित रहते हैं?**

हां। कॉलआउट चार्ट रेंडरिंग का हिस्सा होते हैं, इसलिए जब आप इसे [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/androidjava/export-to-html5/), [SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/) या [raster images](/slides/hi/androidjava/convert-powerpoint-to-png/) में एक्सपोर्ट करते हैं, तो वे स्लाइड के फ़ॉर्मेटिंग के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट में काम करते हैं, और क्या उनका स्वरूप एक्सपोर्ट पर संरक्षित रह सकता है?**

हां। Aspose.Slides प्रस्तुति में [फ़ॉन्ट एम्बेडिंग](/slides/hi/androidjava/embedded-font/) को समर्थन देता है और PDF जैसी एक्सपोर्ट में फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।