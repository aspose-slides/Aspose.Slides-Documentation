---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में बबल चार्ट को अनुकूलित करें
linktitle: बबल चार्ट
type: docs
url: /hi/nodejs-java/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js via Java के साथ PowerPoint में शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें ताकि आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से बेहतर बना सकें।"
---
## **समग्र अवलोकन**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दर्शाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `setBubbleSizeScale` मेथड के माध्यम से बबल आकार को स्केल करना और `setBubbleSizeRepresentation` मेथड के माध्यम से बबल आकार मानों को कैसे प्रदर्शित किया जाता है, इसे नियंत्रित करना।

उदाहरण दर्शाते हैं कि बबल चार्ट कैसे बनाते हैं, उसके आकार स्केलिंग को कैसे समायोजित करते हैं, और बबल आकार प्रतिनिधित्व को चौड़ाई का उपयोग करने के लिए कैसे बदलते हैं। लेख में एक संक्षिप्त FAQ अनुभाग भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, यह नोट करता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्ष्य PowerPoint संस्करण पर निर्भर करती हैं, और यह समझाता है कि एक्सपोर्ट Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को बनाए रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for Node.js via Java बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for Node.js via Java में [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) और [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) मेथड जोड़े गए हैं। नीचे उदाहरण दिया गया है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **डेटा को बबल चार्ट आकारों के रूप में दर्शाएँ**
मेथड [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) और [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) को [ChartSeries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartSeriesGroup) क्लास और संबंधित क्लासों में जोड़ा गया है। **BubbleSizeRepresentation** यह निर्दिष्ट करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रदर्शित किया जाता है। संभावित मान हैं: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) और [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width)। उसी अनुसार, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BubbleSizeRepresentationType) एनीम को डेटा को बबल चार्ट आकारों के रूप में प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट करने के लिए जोड़ा गया है। नीचे नमूना कोड दिया गया है।

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "3-D प्रभाव वाला बबल चार्ट" समर्थित है, और यह सामान्य चार्ट से कैसे अलग है?**

हां। एक अलग चार्ट प्रकार है, "Bubble with 3-D." यह बबल्स पर 3-D शैली लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X-Y-S (आकार) ही रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) एन्युमरेशन में उपलब्ध है।

**क्या बबल चार्ट में श्रृंखला और बिंदुओं की संख्या पर कोई सीमा है?**

API स्तर पर कोई हार्ड सीमा नहीं है; प्रतिबंध प्रदर्शन और लक्ष्य PowerPoint संस्करण द्वारा निर्धारित होते हैं। पठनीयता और रेंडरिंग गति के लिए बिंदुओं की संख्या को यथोचित रखना अनुशंसित है।

**एक्सपोर्ट बबल चार्ट की उपस्थिति (PDF, इमेज) को कैसे प्रभावित करेगा?**

समर्थित स्वरूपों में एक्सपोर्ट करने से चार्ट की उपस्थिति बना रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर स्वरूपों के लिए सामान्य चार्ट-ग्राफ़िक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी-अलियासिंग), इसलिए प्रिंटिंग के लिए पर्याप्त DPI चुनें।