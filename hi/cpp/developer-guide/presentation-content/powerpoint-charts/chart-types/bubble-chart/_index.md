---
title: C++ का उपयोग करके प्रस्तुतियों में बबल चार्ट को अनुकूलित करें
linktitle: बबल चार्ट
type: docs
url: /hi/cpp/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint में शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें ताकि आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से बढ़ा सकें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने के तरीके को दर्शाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `set_BubbleSizeScale` मेथड के द्वारा बबल आकार को स्केल करना और `set_BubbleSizeRepresentation` मेथड के द्वारा बबल आकार मानों को कैसे प्रस्तुत किया जाता है, इसे नियंत्रित करना।

उदाहरण दर्शाते हैं कि बबल चार्ट कैसे बनाएं, उसका आकार स्केलिंग कैसे समायोजित करें, और बबल आकार प्रतिनिधित्व को चौड़ाई उपयोग करने के लिए कैसे बदलें। लेख में एक छोटा FAQ सेक्शन भी शामिल है जिसमें “Bubble with 3‑D” चार्ट प्रकार के समर्थन की व्याख्या की गई है, यह बताया गया है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और यह समझाया गया है कि निर्यात Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को संरक्षित रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for C++ बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** और **IChartSeriesGroup.BubbleSizeScale** प्रॉपर्टीज़ जोड़ी गई हैं। नीचे एक उदाहरण दिया गया है। 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **डेटा को बबल चार्ट आकारों के रूप में प्रस्तुत करना**
नया **get_BubbleSizeRepresentation()** मेथड **IChartSeries** और **ChartSeries** क्लासेज़ में जोड़ा गया है। **BubbleSizeRepresentation** निर्धारित करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रस्तुत किया जाता है। संभावित मान हैं: **BubbleSizeRepresentationType.Area** और **BubbleSizeRepresentationType.Width**। इस अनुसार, डेटा को बबल चार्ट आकारों के रूप में प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट करने के लिए **BubbleSizeRepresentationType** एनेम जोड़ा गया है। नीचे नमूना कोड दिया गया है।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

हां। एक अलग चार्ट प्रकार है, “Bubble with 3‑D।” यह बबल्स पर 3‑D शैली लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X‑Y‑S (आकार) ही रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) एनेमरेशन में उपलब्ध है।

**Is there a limit on the number of series and points in a bubble chart?**

API स्तर पर कोई कठोर सीमा नहीं है; प्रतिबंध प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित होते हैं। पठनीयता और रेंडरिंग गति के लिए बिंदुओं की संख्या को उचित रखना सलाहकार है।

**How will export affect the appearance of a bubble chart (PDF, images)?**

समर्थित फ़ॉर्मैटों में निर्यात करने पर चार्ट की उपस्थिति बनी रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मैटों के लिए, सामान्य चार्ट-ग्राफिक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी‑एलीसिंग), इसलिए प्रिंट के लिए पर्याप्त DPI चुनें।