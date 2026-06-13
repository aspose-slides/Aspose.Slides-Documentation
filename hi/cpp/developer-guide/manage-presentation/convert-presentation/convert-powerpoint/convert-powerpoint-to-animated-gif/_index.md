---
title: C++ में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में बदलें। तेज़, उच्च-गुणवत्ता वाले परिणाम।"
---
## **अवलोकन**

Aspose.Slides आपको कुछ ही कोड लाइनों के साथ PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में परिवर्तित करने की अनुमति देता है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना हो, जिसे वेब पेज, मैसेंजर या दस्तावेज़ों में एम्बेड किया जा सकता है। यह लेख बताता है कि डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में कैसे निर्यात किया जाए और कैसे फ़्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ़्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को अनुकूलित किया जाए, इसके लिए [GifOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/gifoptions/) का उपयोग किया जाता है।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में परिवर्तित करें**

C++ में यह नमूना कोड दिखाता है कि मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे परिवर्तित किया जाए:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटर के साथ बनाया जाएगा। 

{{%  alert  title="TIP"  color="primary"  %}} 

यदि आप GIF के लिए पैरामीटर को अनुकूलित करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.gif_options) क्लास का उपयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें। 

{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में परिवर्तित करें**

यह नमूना कोड दिखाता है कि C++ में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में कैसे परिवर्तित किया जाए:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// प्राप्त GIF का आकार 
gifOptions->set_FrameSize(Size(960, 720));
// हर स्लाइड कितनी देर दिखेगी, जब तक कि अगली स्लाइड पर नहीं बदलती
gifOptions->set_DefaultDelay(2000);
// ट्रांज़िशन एनीमेशन की गुणवत्ता बेहतर बनाने के लिए FPS बढ़ाएँ
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) परिवर्तक को भी देख सकते हैं। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?**

गुम फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/cpp/powerpoint-fonts/)। Aspose.Slides प्रतिस्थापन करेगा, लेकिन रूप में अंतर हो सकता है। ब्रांडिंग के लिए, हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ़्रेम पर वाटरमार्क ओवरले कर सकता हूँ?**

हाँ। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइडों पर [Add a semi-transparent object/logo](/slides/hi/cpp/watermark/) जोड़ें — वाटरमार्क प्रत्येक फ़्रेम पर दिखेगा।