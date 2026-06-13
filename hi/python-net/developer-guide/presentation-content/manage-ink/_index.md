---
title: Python के साथ प्रस्तुतियों में इंक ऑब्जेक्ट्स प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/python-net/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक ड्रॉ करें
- ड्रॉइंग
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट्स प्रबंधित करें—Aspose.Slides for Python द्वारा .NET के माध्यम से डिजिटल इंक बनाएं, संपादित करें और स्टाइल करें। ट्रेसेस, ब्रश रंग और आकार के कोड नमूने प्राप्त करें।"
---
## **परिचय**

PowerPoint इंक फ़ंक्शन प्रदान करता है जिससे आप गैर‑मानक आकृतियों को ड्रॉ कर सकते हैं, जिसका उपयोग अन्य ऑब्जेक्ट्स को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड में विशिष्ट आइटमों पर ध्यान आकर्षित करने के लिए किया जा सकता है।  

Aspose.Slides [aspose.slides.ink](https://reference.aspose.com/slides/hi/python-net/aspose.slides.ink/) नेमस्पेस प्रदान करता है, जिसमें वे प्रकार शामिल हैं जिनकी आपको इंक ऑब्जेक्ट बनाने और प्रबंधित करने की आवश्यकता है।  

## **नियमित ऑब्जेक्ट और इंक ऑब्जेक्ट के बीच अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शेप ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं। एक शेप ऑब्जेक्ट, सबसे सरल रूप में, एक कंटेनर होता है जो ऑब्जेक्ट के स्वयं के क्षेत्र (उसका फ्रेम) और उसकी प्रॉपर्टीज़ को परिभाषित करता है। इसके अंतर्गत कंटेनर क्षेत्र का आकार, कंटेनर का आकार, कंटेनर की पृष्ठभूमि आदि शामिल हैं। अधिक जानकारी के लिए देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/python-net/shape-manipulations/#access-layout-formats-for-shape)।  

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट से निपट रहा होता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी प्रॉपर्टीज़ को उसकी आकार को छोड़कर अनदेखा कर देता है। कंटेनर क्षेत्र का आकार मानक `width` और `height` मानों द्वारा निर्धारित किया जाता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंकशेप ट्रेसेस**

ट्रेस वह मूल तत्व या मानक है जिसका उपयोग पेन की गति को रिकॉर्ड करने के लिए किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। ट्रेसेस उन रिकॉर्डिंग्स को कहते हैं जो आपस में जुड़े बिंदुओं के क्रम का वर्णन करती हैं।  

सबसे सरल एन्कोडिंग रूप प्रत्येक सैंपल पॉइंट के X और Y निर्देशांक को निर्दिष्ट करता है। जब सभी जुड़े बिंदु रेंडर होते हैं, तो वे इस प्रकार की छवि बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## ड्रॉइंग के लिए ब्रश गुण

आप ब्रश का उपयोग ट्रेस तत्वों के बिंदुओं को जोड़ती रेखाएँ ड्रॉ करने के लिए कर सकते हैं। ब्रश का अपना रंग और आकार होता है, जो `Brush.color` और `Brush.size` प्रॉपर्टीज़ के अनुरूप होते हैं।  

### **इंक ब्रश का रंग सेट करें**

यह Python कोड आपको ब्रश का रंग सेट करने का तरीका दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **इंक ब्रश का आकार सेट करें**

यह Python कोड आपको ब्रश का आकार सेट करने का तरीका दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश आकार को प्रदर्शित नहीं करता (डेटा सेक्शन ग्रे हो जाता है)। लेकिन जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint अपना आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टीकरण के लिए, चलिए इंक ऑब्जेक्ट की ऊँचाई बढ़ाते हैं और महत्वपूर्ण आयामों की समीक्षा करते हैं:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मानता है कि लाइन की मोटाई शून्य है (आखिरी छवि देखें)।  

इसलिए पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिए हमें ट्रेस ऑब्जेक्ट्स के ब्रश आकार को ध्यान में रखना होगा। यहाँ लक्ष्य ऑब्जेक्ट (हैंडरिटन टेक्स्ट ट्रेस ऑब्जेक्ट) को कंटेनर (फ़्रेम) के आकार के अनुसार स्केल किया गया है। जब कंटेनर (फ़्रेम) का आकार बदलता है, तो ब्रश आकार स्थिर रहता है और इसके विपरीत भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट के साथ भी वही व्यवहार प्रदर्शित करता है:

![ink_powerpoint6](ink_powerpoint6.png)

**अधिक पढ़ें**

* सामान्य रूप से शैप्स के बारे में पढ़ने के लिए, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/python-net/powerpoint-shapes/) अनुभाग।  
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/python-net/shape-effective-properties/#get-effective-font-height-value)।