---
title: Android पर प्रस्तुतियों में बबल चार्ट को कस्टमाइज़ करें
linktitle: बबल चार्ट
type: docs
url: /hi/androidjava/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- प्रस्तुतीकरण
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint में शक्तिशाली बबल चार्ट बनाएं और कस्टमाइज़ करें, जिससे आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से सुधार सकें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दिखाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `setBubbleSizeScale` मेथड के माध्यम से बबल आकार का स्केलिंग और `setBubbleSizeRepresentation` मेथड के माध्यम से बबल आकार मानों का प्रतिनिधित्व नियंत्रित करना।  

उदाहरण दर्शाते हैं कि बबल चार्ट कैसे बनाएं, उसका आकार स्केलिंग कैसे समायोजित करें, और बबल आकार प्रतिनिधित्व को चौड़ाई उपयोग करने के लिए बदलें। लेख में एक छोटा FAQ अनुभाग भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, जानकारी देता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और यह समझाता है कि निर्यात Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को बरकरार रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for Android via Java बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for Android via Java में [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) और [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) मेथड जोड़े गए हैं। नीचे नमूना उदाहरण दिया गया है।

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **डेटा को बबल चार्ट आकार के रूप में प्रतिनिधित्व करें**
मेथड [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) और [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) को [IChartSeries](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartSeriesGroup) इंटरफ़ेस और संबंधित क्लासों में जोड़ा गया है। **BubbleSizeRepresentation** यह निर्दिष्ट करता है कि बबल चार्ट में बबल आकार मानों को कैसे दर्शाया जाता है। संभव मान हैं: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) और [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width)। Accordingly, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/BubbleSizeRepresentationType) enum डेटा को बबल चार्ट आकार के रूप में प्रतिनिधित्व करने के संभावित तरीकों को निर्दिष्ट करने के लिए जोड़ा गया है। नीचे नमूना कोड दिया गया है।

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "Bubble with 3-D" प्रभाव वाला बबल चार्ट समर्थित है, और यह साधारण बबल चार्ट से कैसे अलग है?**  
हाँ। एक अलग चार्ट प्रकार है, "Bubble with 3-D"। यह बबल्स पर 3‑डी शैली लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X‑Y‑S (आकार) ही रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) क्लास में उपलब्ध है।

**क्या बबल चार्ट में सीरीज़ और पॉइंट्स की संख्या पर कोई सीमा है?**  
API स्तर पर कोई कठोर सीमा नहीं है; सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित होती हैं। पठनीयता और रेंडरिंग गति के लिए पॉइंट्स की संख्या को उचित स्तर पर रखने की अनुशंसा की जाती है।

**निर्यात बबल चार्ट (PDF, इमेज) की उपस्थिति को कैसे प्रभावित करेगा?**  
समर्थित फ़ॉर्मेट में निर्यात चार्ट की उपस्थिति को बरकरार रखता है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मेट के लिए सामान्य चार्ट‑ग्राफ़िक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी‑एलियासिंग), इसलिए प्रिंटिंग के लिए पर्याप्त DPI चुनें।