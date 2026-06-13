---
title: Android पर PowerPoint प्रस्तुतियों को एनीमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java के माध्यम से PowerPoint प्रस्तुतियों (PPT, PPTX) को एनीमेटेड GIF में आसानी से बदलें। तेज़, उच्च-गुणवत्ता परिणाम।"
---
## **अवलोकन**

Aspose.Slides आपको कुछ ही कोड लाइनों में PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में बदलने की सुविधा देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनीमेटेड फ़ॉर्मेट में साझा करने की आवश्यकता होती है जिसे वेब पृष्ठों, मैसेंजर या दस्तावेज़ों में एम्बेड किया जा सकता है। यह लेख बताता है कि डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में कैसे निर्यात करें और कैसे फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को कस्टमाइज़ करें, यह सब [GifOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/gifoptions/) के माध्यम से किया जाता है।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनीमेटेड GIF में बदलें**

Java में यह नमूना कोड आपको मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनीमेटेड GIF में बदलना दिखाता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

एनीमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाई जाएगी।

{{% alert title="TIP" color="primary" %}} 
यदि आप GIF के पैरामीटर को कस्टमाइज़ करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GifOptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें।
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनीमेटेड GIF में बदलें**

यह नमूना कोड आपको Java में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनीमेटेड GIF में बदलना दिखाता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // परिणामस्वरूप GIF का आकार  
	gifOptions.setDefaultDelay(2000); // प्रत्येक स्लाइड कितनी देर तक दिखेगी, जब तक यह अगली स्लाइड में बदल न जाए
	gifOptions.setTransitionFps(35); // बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरण उपकरण देख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?**

गुम फ़ॉन्ट स्थापित करें या [फॉलबैक फ़ॉन्ट कॉन्फ़िगर](/slides/hi/androidjava/powerpoint-fonts/) करें। Aspose.Slides प्रतिस्थापन करेगा, लेकिन स्वरूप में अंतर हो सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ़्रेमों पर वॉटरमार्क ओवरले कर सकता हूँ?**

हाँ। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड में [अर्ध-पारदर्शी ऑब्जेक्ट/लोगो](/slides/hi/androidjava/watermark/) जोड़ें — वॉटरमार्क प्रत्येक फ़्रेम पर दिखाई देगा।