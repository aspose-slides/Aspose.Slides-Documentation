---
title: जावा में प्रस्तुति चार्ट निर्यात
linktitle: चार्ट निर्यात
type: docs
weight: 90
url: /hi/java/export-chart/
keywords:
- चार्ट
- चित्र में चार्ट
- छवि के रूप में चार्ट
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति चार्ट को निर्यात करना सीखें, PPT और PPTX स्वरूपों को समर्थन देता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सुगम बनाएं।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति से चार्ट को चित्र के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट दृश्य को पुनः उपयोग करना हो।

मूल छवि निर्यात कार्यप्रवाह के अलावा, यह लेख सामान्य निर्यात‑संबंधी प्रश्नों को भी संबोधित करता है, जिसमें SVG में चार्ट सामग्री को सहेजना, रेंडरिंग विकल्पों के माध्यम से आउटपुट आकार नियंत्रित करना, लेबल और लिजेंड की उपस्थिति बनाए रखने के लिए फ़ॉन्ट लोड करना, और रेंडरिंग के दौरान थीम, स्टाइल, फ़िल और इफ़ेक्ट जैसी मूल प्रस्तुति फ़ॉर्मेटिंग को बनाए रखना शामिल है।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for Java विशिष्ट चार्ट की छवि निकालने के समर्थन प्रदान करता है। नीचे नमूना उदाहरण दिया गया है।  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **सामान्य प्रश्न**

**क्या मैं चार्ट को रास्टर चित्र के बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। चार्ट एक आकार (shape) है, और इसकी सामग्री को SVG के रूप में सहेजा जा सकता है [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) का उपयोग करके।

**मैं निर्यातित चार्ट का सटीक आकार पिक्सेल में कैसे सेट कर सकता हूँ?**

इमेज‑रेंडरिंग ओवरलोड का उपयोग करें जो आपको आकार या स्केल निर्दिष्ट करने की अनुमति देते हैं—लाइब्रेरी दिए गए आयाम/स्केल के साथ ऑब्जेक्ट्स को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल और लिजेंड में फ़ॉन्ट क्यों गलत दिख रहे हैं, मैं क्या करूँ?**

[Load the required fonts](/slides/hi/java/custom-font/) को [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/) के माध्यम से लोड करें ताकि चार्ट रेंडरिंग मीट्रिक और टेक्स्ट उपस्थिति को बनाए रखे।

**क्या निर्यात PowerPoint थीम, स्टाइल और इफ़ेक्ट्स को सम्मानित करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुति की फ़ॉर्मेटिंग (थीम, स्टाइल, फ़िल, इफ़ेक्ट्स) का पालन करता है, इसलिए चार्ट की उपस्थिति संरक्षित रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताएँ कहाँ मिलेंगी?**

आउटपुट टार्गेट के लिए [API](https://reference.aspose.com/slides/hi/java/com.aspose.slides/)/[documentation](/slides/hi/java/convert-powerpoint/) देखें ([PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [SVG](/slides/hi/java/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/java/convert-powerpoint-to-xps/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्प।