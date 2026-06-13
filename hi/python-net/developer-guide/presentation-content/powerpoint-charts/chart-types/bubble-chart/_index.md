---
title: Python के साथ प्रस्तुतियों में बबल चार्ट को कस्टमाइज़ करें
linktitle: बबल चार्ट
type: docs
url: /hi/python-net/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument में Aspose.Slides for Python via .NET के साथ शक्तिशाली बबल चार्ट बनाएं और कस्टमाइज़ करें ताकि आप अपनी डेटा विज़ुअलाइज़ेशन को आसानी से बेहतर बना सकें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दिखाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `bubble_size_scale` प्रॉपर्टी के माध्यम से बबल आकार को स्केल करना और `bubble_size_representation` प्रॉपर्टी के माध्यम से बबल आकार मानों को कैसे दर्शाया जाता है, इसे नियंत्रित करना।

उदाहरण दिखाते हैं कि बबल चार्ट कैसे बनाया जाए, उसके आकार स्केलिंग को कैसे समायोजित किया जाए, और बबल आकार प्रतिनिधित्व को चौड़ाई (width) का उपयोग करने के लिए कैसे बदला जाए। लेख में एक संक्षिप्त FAQ अनुभाग भी شامل है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, बताता है कि व्यावहारिक चार्ट सीमाएं प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और यह समझाता है कि निर्यात Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को संरक्षित रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for Python via .NET बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for Python via .NET में **ChartSeries.bubble_size_scale** और **ChartSeriesGroup.bubble_size_scale** प्रॉपर्टी जोड़ी गई हैं। नीचे एक नमूना उदाहरण दिया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **डेटा को बबल चार्ट आकार के रूप में प्रस्तुत करना**
प्रॉपर्टी **bubble_size_representation** को ChartSeries और ChartSeriesGroup क्लासेज़ में जोड़ा गया है। **bubble_size_representation** यह निर्धारित करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रस्तुत किया जाता है। संभावित मान हैं: **BubbleSizeRepresentationType.AREA** और **BubbleSizeRepresentationType.WIDTH**। इसी अनुसार, **BubbleSizeRepresentationType** एनोम को डेटा को बबल चार्ट आकार के रूप में प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट करने के लिए जोड़ा गया है। नीचे नमूना कोड दिया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**क्या "3-D इफ़ेक्ट" वाला बबल चार्ट समर्थित है, और यह सामान्य चार्ट से कैसे अलग है?**

हाँ। एक अलग चार्ट प्रकार है, "Bubble with 3-D"। यह बबल पर 3-D स्टाइलिंग लागू करता है लेकिन किसी अतिरिक्त अक्ष को नहीं जोड़ता; डेटा X-Y-S (आकार) के रूप में रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/charttype/) एनोमरेशन में उपलब्ध है।

**क्या बबल चार्ट में श्रृंखला और बिंदुओं की संख्या पर कोई सीमा है?**

API स्तर पर कोई कठोर सीमा नहीं है; सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित होती हैं। पठनीयता और रेंडरिंग गति के लिए बिंदुओं की संख्या को यथार्थवादी रखने की सलाह दी जाती है।

**निर्यात बबल चार्ट (PDF, छवियों) की उपस्थिति को कैसे प्रभावित करेगा?**

समर्थित फ़ॉर्मैटों में निर्यात करने से चार्ट की उपस्थिति संरक्षित रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मैटों के लिए, सामान्य चार्ट-ग्राफ़िक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी-एलाइनिंग), इसलिए प्रिंटिंग के लिए पर्याप्त DPI चुनें।