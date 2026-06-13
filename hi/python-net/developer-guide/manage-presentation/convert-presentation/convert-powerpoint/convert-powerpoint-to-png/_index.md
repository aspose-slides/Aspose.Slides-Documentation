---
title: Python में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: स्लाइड से PNG
type: docs
weight: 30
url: /hi/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint को PNG में बदलें
- प्रस्तुति को PNG में बदलें
- स्लाइड को PNG में बदलें
- PPT को PNG में बदलें
- PPTX को PNG में बदलें
- ODP को PNG में बदलें
- PowerPoint से PNG
- प्रस्तुति से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- ODP से PNG
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को तेज़ी से उच्च-गुणवत्ता वाली PNG छवियों में बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET PowerPoint प्रस्तुतियों को PNG में परिवर्तित करना सरल बनाता है। आप एक प्रस्तुति लोड करते हैं, उसकी स्लाइड्स पर इटरेट करते हैं, प्रत्येक को एक रास्टर छवि में रेंडर करते हैं, और परिणाम को PNG फ़ाइलों के रूप में सहेजते हैं। यह स्लाइड प्रीव्यू उत्पन्न करने, वेब पेजों में स्लाइड्स एम्बेड करने, या डाउनस्ट्रीम प्रोसेसिंग के लिए स्थिर संसाधन बनाने हेतु आदर्श है।

## **स्लाइड्स को PNG में बदलें**

यह सेक्शन Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुति को PNG छवियों में बदलने का सबसे सरल उदाहरण दिखाता है।

इन चरणों का पालन करें:

1. Presentation वर्ग को इंस्टैंशिएट करें।  
1. `Presentation.slides` संग्रह से एक स्लाइड प्राप्त करें (वर्ग [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) देखें)।  
1. `Slide.get_image` मेथड का उपयोग करके स्लाइड का थंबनेल बनाएं।  
1. `Presentation.save` मेथड का उपयोग करके स्लाइड थंबनेल को PNG फ़ॉर्मेट में सहेजें।  

यह Python कोड दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे बदलें:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **कस्टम आयामों के साथ स्लाइड्स को PNG में बदलें**

कस्टम स्केल पर स्लाइड्स को PNG में निर्यात करने के लिए, क्षैतिज और लंबवत स्केल फैक्टर के साथ `Slide.get_image` को कॉल करें। ये गुणक आउटपुट का आकार स्लाइड के मूल आयामों के अनुपात में बदलते हैं—उदाहरण के लिए, `2.0` चौड़ाई और ऊँचाई दोनों को दोगुना कर देता है। अनुपात बनाए रखने के लिए `scale_x` और `scale_y` के मान बराबर रखें।

यह Python कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **कस्टम आकार के साथ स्लाइड्स को PNG में बदलें**

यदि आप विशिष्ट आकार में PNG फ़ाइलें बनाना चाहते हैं, तो अपने इच्छित `width` और `height` मान पास करें। नीचे दिया गया कोड दर्शाता है कि इमेज आकार निर्दिष्ट करते हुए PowerPoint को PNG में कैसे बदलें:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
आप Aspose के मुफ्त **PowerPoint-to-PNG कनवर्टर**—[PPTX to PNG](https://products.aspose.app/slides/hi/conversion/pptx-to-png) और [PPT to PNG](https://products.aspose.app/slides/hi/conversion/ppt-to-png) को आज़मा सकते हैं। वे इस पृष्ठ पर वर्णित प्रक्रिया का लाइव कार्यान्वयन प्रदान करते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय केवल एक विशिष्ट आकृति (जैसे चार्ट या चित्र) को कैसे निर्यात कर सकता हूँ?**  
Aspose.Slides व्यक्तिगत आकृतियों के लिए थंबनेल उत्पन्न करने का समर्थन करता है](/slides/hi/python-net/create-shape-thumbnails/); आप एक आकृति को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**  
हां, लेकिन एकल प्रस्तुति इंस्टेंस को थ्रेड्स के बीच [न साझा](/slides/hi/python-net/multithreading/) करें। प्रत्येक थ्रेड या प्रक्रिया के लिए अलग इंस्टेंस उपयोग करें।

**PNG निर्यात करते समय ट्रायल-वर्शन की सीमाएँ क्या हैं?**  
मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/python-net/licensing/) लागू करता है।