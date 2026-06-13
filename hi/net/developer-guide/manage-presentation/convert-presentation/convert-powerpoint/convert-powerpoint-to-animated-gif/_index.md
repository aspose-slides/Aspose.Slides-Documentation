---
title: .NET में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/net/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से GIF
- प्रेज़ेंटेशन से GIF
- स्लाइड से GIF
- PPT से GIF
- PPTX से GIF
- PPT को GIF के रूप में सहेजें
- PPTX को GIF के रूप में सहेजें
- PPT को GIF के रूप में निर्यात करें
- PPTX को GIF के रूप में निर्यात करें
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में परिवर्तित करें। तेज़, उच्च‑गुणवत्ता वाले परिणाम।"
---
## **अवलोकन**

Aspose.Slides आपको केवल कुछ पंक्तियों के कोड से PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में बदलने की अनुमति देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना हो, जिसे वेब पेज, मैसेन्ज़र या दस्तावेज़ों में एम्बेड किया जा सकता है। यह लेख डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को GIF में निर्यात करने और फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को कस्टमाइज़ करने की प्रक्रिया को [GifOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/gifoptions/) के माध्यम से समझाता है।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलें**

यह C# में उदाहरण कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटर के साथ बनाई जाएगी।

{{%  alert  title="TIP"  color="primary"  %}} 
यदि आप GIF के पैरामीटर को कस्टमाइज़ करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/gifoptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूनाकृत कोड देखें। 
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलें**

यह C# में नमूना कोड दिखाता है कि कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // परिणामी GIF का आकार  
        DefaultDelay = 2000, // प्रत्येक स्लाइड को कितना समय दिखाया जाएगा जब तक कि अगली स्लाइड पर न बदला जाए
        TransitionFps = 35 // बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
    });
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर को भी देख सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या करेंगे?**

गुम फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/net/powerpoint-fonts/) करें। Aspose.Slides प्रतिस्थापन करेगा, लेकिन स्वरूप में अंतर हो सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ़्रेम पर वॉटरमार्क ओवरले कर सकता हूँ?**

हाँ। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड्स में [Add a semi-transparent object/logo](/slides/hi/net/watermark/) जोड़ें — वॉटरमार्क हर फ़्रेम पर दिखाई देगा।