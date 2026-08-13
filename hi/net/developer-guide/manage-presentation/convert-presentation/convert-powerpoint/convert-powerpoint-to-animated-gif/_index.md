---
title: .NET में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/net/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से GIF
- प्रेजेंटेशन से GIF
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
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में बदलें। तेज़, उच्च‑गुणवत्ता वाले परिणाम।"
---
## **सारांश**

Aspose.Slides आपको कुछ ही कोड लाइनों के साथ PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में बदलने की सुविधा देता है। जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना हो, जिसे वेब पेज, मैसेंजर्स या दस्तावेज़ों में एम्बेड किया जा सके, तब यह उपयोगी होता है। यह लेख समझाता है कि डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में कैसे निर्यात किया जाए और फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट जैसी विकल्पों को [GifOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/gifoptions/) के माध्यम से कॉन्फ़िगर करके आउटपुट को कैसे अनुकूलित किया जाए।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**

C# में यह नमूना कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाया जाएगा। 

{{%  alert  title="TIP"  color="info"  %}} 
यदि आप GIF के पैरामीटर को अनुकूलित करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/gifoptions) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें। 
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में परिवर्तित करें**

C# में यह नमूना कोड दिखाता है कि कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे बदलें:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // नतीजतन GIF का आकार
        DefaultDelay = 2000, // प्रत्येक स्लाइड कितनी देर तक प्रदर्शित होगी जब तक वह अगली स्लाइड में बदली नहीं जाती
        TransitionFps = 35 // बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
    });
}
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर देख सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### अगर प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम में स्थापित नहीं हैं तो क्या करें?

गायब फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/net/powerpoint-fonts/). Aspose.Slides प्रतिस्थापन करेगा, लेकिन दिखावट अलग हो सकती है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

### क्या मैं GIF फ्रेम्स पर वॉटरमार्क ओवरले कर सकता हूँ?

हां। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड्स में [Add a semi-transparent object/logo](/slides/hi/net/watermark/) जोड़ें — वॉटरमार्क हर फ्रेम पर दिखाई देगा।