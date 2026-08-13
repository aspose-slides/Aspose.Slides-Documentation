---
title: C++ में PowerPoint प्रस्तुतियों को एनिमेटेड GIF में बदलें
linktitle: PowerPoint से GIF
type: docs
weight: 65
url: /hi/cpp/convert-powerpoint-to-animated-gif/
keywords:
- एनिमेटेड GIF
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
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
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) को आसानी से एनिमेटेड GIF में बदलें। तेज़, उच्च‑गुणवत्ता परिणाम।"
---
## **परिचय**

Aspose.Slides आपको कुछ ही पंक्तियों के कोड से PowerPoint प्रस्तुतियों को एनिमेटेड GIF फ़ाइलों में बदलने की सुविधा देती है। यह तब उपयोगी होता है जब आपको स्लाइड सामग्री को हल्के, व्यापक रूप से समर्थित एनिमेटेड फ़ॉर्मेट में साझा करना हो जिसे वेब पृष्ठों, मैसेजर्स या दस्तावेज़ों में एम्बेड किया जा सके। यह लेख डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुति को GIF में निर्यात करने और फ्रेम आकार, स्लाइड देरी, और ट्रांज़िशन फ्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को अनुकूलित करने की प्रक्रिया को समझाता है, जिसे आप [GifOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/gifoptions/) के माध्यम से कर सकते हैं।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलें**

यह C++ नमूना कोड आपको मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में बदलने का तरीका दिखाता है:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

एनिमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाई जाएगी। 

{{%  alert  title="TIP"  color="info"  %}} 
यदि आप GIF के पैरामीटर को अनुकूलित करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.export.gif_options) क्लास का उपयोग कर सकते हैं। नीचे नमूना कोड देखें। 
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनिमेटेड GIF में बदलें**

यह नमूना कोड C++ में कस्टम सेटिंग्स का उपयोग करके प्रस्तुति को एनिमेटेड GIF में बदलने का तरीका दिखाता है:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// उत्पन्न GIF का आकार
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// प्रत्येक स्लाइड कितनी देर तक दिखेगी जब तक वह अगली स्लाइड में नहीं बदलती
gifOptions->set_DefaultDelay(2000);
// बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक निःशुल्क [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर देखना चाह सकते हैं। 
{{% /alert %}}

## **प्रायः पूछे जाने वाले प्रश्न**

### यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम पर स्थापित नहीं हैं तो क्या होगा?

गुम फ़ॉन्ट स्थापित करें या [configure fallback fonts](/slides/hi/cpp/powerpoint-fonts/) करें। Aspose.Slides प्रतिस्थापन करेगा, लेकिन स्वरूप में अंतर हो सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

### क्या मैं GIF फ्रेमों पर वॉटरमार्क ओवरले कर सकता हूँ?

हाँ। आप निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइडों पर [Add a semi-transparent object/logo](/slides/hi/cpp/watermark/) जोड़ सकते हैं — वॉटरमार्क प्रत्येक फ्रेम पर दिखाई देगा।