---
title: प्रस्तुति चार्ट में कॉलआउट्स को С++ का उपयोग करके प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/cpp/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ में कॉलआउट बनाएं और स्टाइल करें, संक्षिप्त कोड उदाहरणों के साथ, PPT और PPTX के साथ संगत, ताकि प्रस्तुति कार्यप्रवाहों को स्वचालित किया जा सके।"
---
## **Overview**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट्स के साथ काम करने की विधि समझाता है। यह दर्शाता है कि `set_ShowLabelAsDataCallout` मेथड का उपयोग करके लेबल्स को कॉलआउट के रूप में कैसे दिखाया जाए, डोनट चार्ट के लिए कॉलआउट‑संबंधित लेबल सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और बताता है कि प्रस्तुतियों को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मेट में निर्यात करते समय कॉलआउट्स और उनका स्वरूप संरक्षित रहता है।

## **Using Callouts**
नया प्रॉपर्टी **ShowLabelAsDataCallout** **DataLabelFormat** क्लास और **IDataLabelFormat** इंटरफ़ेस में जोड़ा गया है, जो निर्धारित करता है कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में दिखाया जाएगा या डेटा लेबल के रूप में। नीचे दिए गए उदाहरण में हमने कॉलआउट सेट किए हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Set a Callout for a Doughnut Chart**
Aspose.Slides for C++ डोनट चार्ट के लिए सीरीज़ डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Yes. Callouts are part of the chart rendering, so when you export to [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/cpp/export-to-html5/), [SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/), or [raster images](/slides/hi/cpp/convert-powerpoint-to-png/), they are preserved together with the slide’s formatting.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Yes. Aspose.Slides supports [embedding fonts](/slides/hi/cpp/embedded-font/) into the presentation and controls font embedding during exports such as [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), ensuring the callouts look the same across different systems.