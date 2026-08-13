---
title: Android पर PowerPoint प्रस्तुतियों को एनिमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
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
description: "Aspose.Slides for Android के माध्यम से Java का उपयोग करके PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में बदलें। तेज़, उच्च-गुणवत्ता परिणाम।"
---
## **अवलोकन**

Aspose.Slides आपको कुछ ही पंक्तियों के कोड से PowerPoint प्रस्तुति को एनिमेटेड GIF फ़ाइलों में बदलने की अनुमति देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनीमेटेड फ़ॉर्मेट में साझा करना हो जिसे वेब पेज, मैसेंजर या दस्तावेज़ीकरण में एम्बेड किया जा सके। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में एक्सपोर्ट करने और फ़्रेम आकार, स्लाइड देरी, तथा ट्रांज़िशन फ़्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को कस्टमाइज़ करने के बारे में समझाता है, जिसे आप [GifOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/gifoptions/) के माध्यम से कर सकते हैं।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके एनिमेटेड GIF में प्रस्तुति को कनवर्ट करना**

Java में यह उदाहरण कोड आपको दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाया जाएगा।

{{%  alert  title="TIP"  color="info"  %}} 
यदि आप GIF के पैरामीटर को कस्टमाइज़ करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GifOptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया उदाहरण कोड देखें।
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके एनिमेटेड GIF में प्रस्तुति को कनवर्ट करना**

यह नमूना कोड आपको दिखाता है कि Java में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // परिणामस्वरूप GIF का आकार  
	gifOptions.setDefaultDelay(2000); // प्रत्येक स्लाइड कितनी देर तक दिखेगी जब तक अगली पर नहीं बदली जाती
	gifOptions.setTransitionFps(35); // बेहतर ट्रांज़िशन एनीमेशन क्वालिटी के लिए FPS बढ़ाएं
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर को भी देख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर इंस्टॉल नहीं हैं तो क्या करें?

ग़ायब फ़ॉन्ट स्थापित करें या [fallback फ़ॉन्ट कॉन्फ़िगर करें](/slides/hi/androidjava/powerpoint-fonts/)। Aspose.Slides प्रतिस्थापन करेगा, लेकिन रूप में अंतर हो सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

### क्या मैं GIF फ़्रेम पर वॉटरमार्क लगा सकता हूँ?

हां। एक्सपोर्ट से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड में [अर्ध-पारदर्शी ऑब्जेक्ट/लोगो](/slides/hi/androidjava/watermark/) जोड़ें — वॉटरमार्क हर फ़्रेम पर दिखाई देगा।