---
title: "Python में प्रस्तुतियों को एनीमेटेड GIF में बदलें"
linktitle: "प्रेज़ेंटेशन से GIF"
type: docs
weight: 65
url: /hi/python-net/convert-powerpoint-to-animated-gif/
keywords:
- एनीमेटेड GIF
- PowerPoint रूपांतरित करें
- OpenDocument रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- ODP रूपांतरित करें
- PowerPoint से GIF
- OpenDocument से GIF
- प्रस्तुति से GIF
- स्लाइड से GIF
- PPT से GIF
- PPTX से GIF
- ODP से GIF
- डिफ़ॉल्ट सेटिंग्स
- कस्टम सेटिंग्स
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के साथ PowerPoint प्रस्तुतियों (PPT, PPTX) और OpenDocument फ़ाइलों (ODP) को आसानी से एनीमेटेड GIF में बदलें। तेज, उच्च गुणवत्ता वाले परिणाम।"
---
## **समीक्षा**

Aspose.Slides आपको कुछ ही पंक्तियों के कोड से PowerPoint प्रस्तुतियों को एनीमेटेड GIF फ़ाइलों में परिवर्तित करने की सुविधा देता है। यह तब उपयोगी होता है जब आपको स्लाइड की सामग्री को हल्के, व्यापक रूप से समर्थित एनीमेटेड फ़ॉर्मेट में साझा करना हो, जिसे वेब पेज, मैसेन्ज़र या डॉक्यूमेंटेशन में एम्बेड किया जा सकता है। यह लेख डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को GIF में निर्यात करने और फ़्रेम आकार, स्लाइड देरी, तथा ट्रांज़िशन फ़्रेम रेट जैसी विकल्पों को कॉन्फ़िगर करके आउटपुट को अनुकूलित करने के बारे में बताता है, जो आप [GifOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/gifoptions/) के माध्यम से कर सकते हैं।

## **डिफ़ॉल्ट सेटिंग्स का उपयोग करके प्रस्तुतियों को एनीमेटेड GIF में परिवर्तित करें**

यह Python में दिया गया नमूना कोड दिखाता है कि कैसे मानक सेटिंग्स का उपयोग करके प्रस्तुति को एनीमेटेड GIF में बदला जाता है:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

एनीमेटेड GIF डिफ़ॉल्ट पैरामीटरों के साथ बनाई जाएगी। 

{{%  alert  title="TIP"  color="primary"  %}} 
यदि आप GIF के पैरामीटरों को अनुकूलित करना चाहते हैं, तो आप [GifOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/gifoptions/) क्लास का प्रयोग कर सकते हैं। नीचे दिया गया नमूना कोड देखें। 
{{% /alert %}} 

## **कस्टम सेटिंग्स का उपयोग करके प्रस्तुतियों को एनीमेटेड GIF में परिवर्तित करें**

यह नमूना कोड आपको दिखाता है कि कैसे Python में कस्टम सेटिंग्स के साथ प्रस्तुति को एनीमेटेड GIF में बदला जाता है:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # उत्पन्न GIF का आकार  
options.default_delay = 2000 # प्रत्येक स्लाइड कितनी देर तक दिखाई देगी जब तक कि उसे अगली स्लाइड से बदल दिया न जाए
options.transition_fps = 35  # बेहतर ट्रांज़िशन एनीमेशन गुणवत्ता के लिए FPS बढ़ाएँ

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
आप Aspose द्वारा विकसित एक मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर को भी देख सकते हैं। 
{{% /alert %}}

## **FAQ**

**यदि प्रस्तुति में उपयोग किए गए फ़ॉन्ट सिस्टम में स्थापित नहीं हैं तो क्या होगा?**

गुम फ़ॉन्ट इंस्टॉल करें या [fallback फ़ॉन्ट कॉन्फ़िगर करें](/slides/hi/python-net/powerpoint-fonts/)। Aspose.Slides प्रतिस्थापन करेगा, लेकिन रूप दिखने में अंतर आ सकता है। ब्रांडिंग के लिए हमेशा सुनिश्चित करें कि आवश्यक टाइपफ़ेस स्पष्ट रूप से उपलब्ध हों।

**क्या मैं GIF फ़्रेम्स पर वॉटरमार्क ओवरले कर सकता हूँ?**

हां। निर्यात से पहले मास्टर स्लाइड या व्यक्तिगत स्लाइड में [अर्ध-पारदर्शी ऑब्जेक्ट/लोगो](/slides/hi/python-net/watermark/) जोड़ें — वॉटरमार्क प्रत्येक फ़्रेम पर दिखेगा।