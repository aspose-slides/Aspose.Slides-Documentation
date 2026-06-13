---
title: जाव में प्रस्तुतियों के लिए चार्ट गणनाओं को अनुकूलित करें
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/java/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- चाइल्ड तत्व
- पेरेंट तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट और सटीकता नियंत्रण को समझें, व्यावहारिक जावा कोड उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतियों में चार्ट गणनाओं और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दिखाता है कि चार्ट तत्वों के वास्तविक मान कैसे प्राप्त करें, जिसमें `IActualLayout` को लागू करने वाले तत्वों की वास्तविक स्थान और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह भी बताता है कि ये मान चार्ट लेआउट मान्यकरण के बाद भरे जाते हैं।

## **चार्ट तत्वों के वास्तविक मानों की गणना**
Aspose.Slides for Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [IAxis](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis) इंटरफ़ेस की प्रॉपर्टीज़ अक्ष चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी प्रदान करती हैं ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAxis#getActualMinorUnitScale--))। इन प्रॉपर्टीज़ को वास्तविक मानों से भरने के लिए पहले [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart#validateChartLayout--) मेथड को कॉल करना आवश्यक है।

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **माता चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [IActualLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IActualLayout) इंटरफ़ेस की प्रॉपर्टीज़ माता चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी देती हैं ([IActualLayout.getActualX](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IActualLayout#getActualHeight--))। इन प्रॉपर्टीज़ को वास्तविक मानों से भरने के लिए पहले [IChart.validateChartLayout()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChart#validateChartLayout--) मेथड को कॉल करना आवश्यक है।

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट तत्वों को छिपाएँ**
यह विषय आपको समझने में मदद करता है कि चार्ट से जानकारी कैसे छिपाएँ। Aspose.Slides for Java का उपयोग करके आप चार्ट से **शीर्षक, लंबवत अक्ष, क्षैतिज अक्ष** और **ग्रिड लाइन्स** छिपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन प्रॉपर्टीज़ का उपयोग कैसे करें।

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //चार्ट शीर्षक छिपाना
    chart.setTitle(false);

    ///मान अक्ष छिपाना
    chart.getAxes().getVerticalAxis().setVisible(false);

    //श्रेणी अक्ष दृश्यता
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //लेजेंड छिपाना
    chart.setLegend(false);

    //मुख्य ग्रिड रेखाएँ छिपाना
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी Excel कार्यपुस्तिकाएँ डेटा स्रोत के रूप में काम करती हैं, और इसका पुनर्गणना पर क्या प्रभाव पड़ता है?**

हां। एक चार्ट बाहरी कार्यपुस्तिका को संदर्भित कर सकता है: जब आप बाहरी स्रोत को कनेक्ट या रीफ़्रेश करते हैं, तो सूत्र और मान उस कार्यपुस्तिका से लिये जाते हैं, और चार्ट खुले/संपादित करने के दौरान अपडेट को दर्शाता है। API आपको [बाहरी कार्यपुस्तिका निर्दिष्ट करें](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) पथ को सेट करने और लिंक किए गए डेटा को प्रबंधित करने की अनुमति देती है।

**क्या मैं खुद रिग्रेशन लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूं?**

हां। [ट्रेंडलाइन](/slides/hi/java/trend-line/) (रैखिक, घातीय और अन्य) Aspose.Slides द्वारा जोड़ी और अपडेट की जाती हैं; उनके पैरामीटर श्रृंखला डेटा से स्वचालित रूप से पुनः गणना होते हैं, इसलिए आपको अपना स्वयं का गणना लागू करने की आवश्यकता नहीं है।

**यदि प्रस्तुति में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं नियंत्रित कर सकता हूं कि प्रत्येक चार्ट किस कार्यपुस्तिका को गणना किए गए मानों के लिए उपयोग करता है?**

हां। प्रत्येक चार्ट अपनी स्वयं की [बाहरी कार्यपुस्तिका](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) को निर्दिष्ट कर सकता है, या आप प्रत्येक चार्ट के लिए अलग-अलग बाहरी कार्यपुस्तिका बना/बदल सकते हैं, बिना अन्य चार्टों को प्रभावित किए।