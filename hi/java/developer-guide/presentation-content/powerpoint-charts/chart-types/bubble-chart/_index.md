---
title: प्रस्तुतियों में Java का उपयोग करके बबल चार्ट को अनुकूलित करें
linktitle: बबल चार्ट
type: docs
url: /hi/java/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- पावरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint में शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें, जिससे आप अपनी डेटा विज़ुअलाइज़ेशन को आसानी से सुधार सकें।"
---
## **परिचय**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दर्शाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `setBubbleSizeScale` विधि के माध्यम से बबल आकार को स्केल करना और `setBubbleSizeRepresentation` विधि के माध्यम से बबल आकार मानों को कैसे दर्शाया जाता है, इसे नियंत्रित करना।

उदाहरण दर्शाते हैं कि बबल चार्ट कैसे बनायें, उसके आकार स्केलिंग को समायोजित करें, और बबल आकार प्रतिनिधित्व को चौड़ाई (width) उपयोग करने के लिए बदलें। लेख में एक छोटा FAQ अनुभाग भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, बताता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और समझाता है कि निर्यात Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को संरक्षित रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for Java बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) और [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) विधियों को जोड़ा गया है। नीचे उदाहरण दिया गया है। 

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

## **डेटा को बबल चार्ट आकार के रूप में दर्शाएँ**
विधियों [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) और [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) को [IChartSeries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartSeriesGroup) इंटरफ़ेस और संबंधित क्लासों में जोड़ा गया है। **BubbleSizeRepresentation** यह निर्दिष्ट करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रस्तुत किया जाता है। संभावित मान हैं: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/BubbleSizeRepresentationType#Area) और [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/BubbleSizeRepresentationType#Width). इसीलिए, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/BubbleSizeRepresentationType) एनम को बबल चार्ट आकारों के रूप में डेटा प्रस्तुत करने के संभावित तरीकों को बताने के लिए जोड़ा गया है। नीचे नमूना कोड दिया गया है।

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

**क्या “3-D इफ़ेक्ट वाला बबल चार्ट” समर्थित है, और यह सामान्य चार्ट से कैसे अलग है?**

हाँ। एक अलग चार्ट प्रकार “Bubble with 3-D” उपलब्ध है। यह बबल पर 3-D शैली लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X-Y-S (आकार) रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) क्लास में उपलब्ध है।

**क्या बबल चार्ट में श्रृंखलाओं और बिंदुओं की संख्या पर कोई सीमा है?**

API स्तर पर कोई कठोर सीमा नहीं है; सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित होती हैं। पठनीयता और रेंडरिंग गति के लिये बिंदुओं की संख्या को उचित रखना सुझाया जाता है।

**निर्यात बबल चार्ट (PDF, इमेज) की उपस्थिति को कैसे प्रभावित करेगा?**

समर्थित फ़ॉर्मैट में निर्यात करने से चार्ट की उपस्थिति बनी रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मैट के लिये, सामान्य चार्ट‑ग्राफ़िक्स रेंडरिंग नियम (रेज़ॉल्यूशन, एंटी‑एलिएसिंग) लागू होते हैं, इसलिए प्रिंटिंग के लिये पर्याप्त DPI चुनें।