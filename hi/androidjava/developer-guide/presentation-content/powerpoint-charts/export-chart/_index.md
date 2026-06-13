---
title: Android पर प्रस्तुति चार्ट निर्यात करें
linktitle: चार्ट निर्यात करें
type: docs
weight: 90
url: /hi/androidjava/export-chart/
keywords:
- चार्ट
- चार्ट से छवि
- चार्ट को छवि के रूप में
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति चार्ट निर्यात करना सीखें, जो PPT और PPTX फ़ॉर्मेट का समर्थन करता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सरल बनाता है।"
---
## **समीक्षा**

Aspose.Slides आपको प्रस्तुति से चार्ट को छवि के रूप में निर्यात करने देता है। यह लेख दर्शाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट दृश्य का पुनः उपयोग करना हो।

बेसिक इमेज एक्सपोर्ट वर्कफ़्लो के अलावा, लेख सामान्य एक्सपोर्ट‑संबंधी प्रश्नों को भी संबोधित करता है, जिसमें चार्ट सामग्री को SVG में सहेजना, रेंडरिंग विकल्पों के माध्यम से आउटपुट आकार नियंत्रित करना, लेबल और लेजेंड की उपस्थिति को बनाये रखने के लिए फ़ॉन्ट लोड करना, और रेंडरिंग के दौरान थीम, स्टाइल, फ़िल्स और इफ़ेक्ट्स जैसी मूल प्रस्तुति फ़ॉर्मेटिंग को बनाए रखना शामिल है।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for Android via Java विशिष्ट चार्ट की छवि निकालने के लिए समर्थन प्रदान करता है। नीचे उदाहरण दिया गया है।  

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को रास्टर छवि के बजाय एक वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। एक चार्ट एक shape है, और इसकी सामग्री को SVG में सहेजा जा सकता है [shape-to-SVG सहेजने की विधि](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)।

**मैं निर्यात किए गए चार्ट का सटीक आकार पिक्सेल में कैसे सेट कर सकता हूँ?**

छवि‑रेंडरिंग ओवरलोड का उपयोग करें जो आपको आकार या स्केल निर्दिष्ट करने देता है—लाइब्रेरी दी गई आयाम/स्केल के साथ ऑब्जेक्ट रेंडर करने का समर्थन करती है।

**यदि निर्यात के बाद लेबल और लेजेंड में फ़ॉन्ट्स गलत दिखें तो मुझे क्या करना चाहिए?**

[आवश्यक फ़ॉन्ट लोड करें](/slides/hi/androidjava/custom-font/) [FontsLoader](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/) के माध्यम से ताकि चार्ट रेंडरिंग मेट्रिक्स और टेक्स्ट उपस्थिति को बनाए रखे।

**क्या निर्यात PowerPoint थीम, शैली और प्रभावों का सम्मान करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुति की फ़ॉर्मेटिंग (थीम, शैली, फ़िल्स, इफ़ेक्ट्स) का पालन करता है, इसलिए चार्ट की उपस्थिति बनी रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताएँ मैं कहां पा सकता हूँ?**

आउटपुट टार्गेट्स के लिए [API](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/)/[दस्तावेज़ीकरण](/slides/hi/androidjava/convert-powerpoint/) देखें ([PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्प।