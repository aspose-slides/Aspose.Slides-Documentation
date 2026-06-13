---
title: Java में PowerPoint प्रस्तुतियों को एनीमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/java/convert-powerpoint-to-animated-gif/
keywords:
- एनीमेटेड GIF
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से GIF
- प्रस्तुति से GIF
- स्लाइड से GIF
- PPT से GIF
- PPTX से GIF
- PPT को GIF के रूप में सहेजें
- PPTX को GIF के रूप में सहेजें
- PPT को GIF के रूप में निर्यात करें
- PPTX को GIF के रूप में निर्यात करें
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनीमेटेड GIF में बदलें। तेज़, उच्च‑गुणवत्ता परिणाम।"
---
## **Overview**

Aspose.Slides आपको कुछ ही पंक्तियों के कोड के साथ PowerPoint प्रस्तुतियों को एनीमेटेड GIF फ़ाइलों में बदलने की सुविधा देता है। यह उपयोगी है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनीमेटेड फ़ॉर्मेट में साझा करने की आवश्यकता हो जिसे वेब पेज, मैसेंजर, या दस्तावेज़ में एम्बेड किया जा सके। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में निर्यात करने और फ़्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ़्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को कस्टमाइज़ करने के बारे में बताता है, जिसे आप [GifOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/gifoptions/) के माध्यम से कर सकते हैं।

## **Convert Presentations to Animated GIF Using Default Settings**

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

एनीमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाया जाएगा। 

{{%  alert  title="TIP"  color="primary"  %}} 
यदि आप GIF के पैरामीटर को कस्टमाइज़ करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GifOptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें। 
{{% /alert %}} 

## **Convert Presentations to Animated GIF Using Custom Settings**

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // निर्मित GIF का आकार
	gifOptions.setDefaultDelay(2000); // हर स्लाइड कितनी देर दिखेगी जब तक कि वह अगली स्लाइड में बदली न जाए
	gifOptions.setTransitionFps(35); // बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर देख सकते हैं। 
{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation aren’t installed on the system?**

गुम फ़ॉन्ट को स्थापित करें या [configure fallback fonts](/slides/hi/java/powerpoint-fonts/). Aspose.Slides प्रतिस्थापित करेगा, लेकिन दिखावट अलग हो सकती है। ब्रांडिंग के लिए, हमेशा सुनिश्चित करें कि आवश्यक टाइपफेस स्पष्ट रूप से उपलब्ध हों।

**Can I overlay a watermark on the GIF frames?**

हाँ। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड्स में [Add a semi-transparent object/logo](/slides/hi/java/watermark/) जोड़ें — वॉटरमार्क प्रत्येक फ्रेम पर दिखेगा।