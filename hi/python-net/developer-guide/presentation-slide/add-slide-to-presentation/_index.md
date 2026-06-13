---
title: Python के साथ प्रेजेंटेशन में स्लाइड्स जोड़ें
linktitle: स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/python-net/add-slide-to-presentation/
keywords:
- स्लाइड जोड़ें
- स्लाइड बनाएं
- खाली स्लाइड
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके अपने PowerPoint और OpenDocument प्रेजेंटेशन में आसानी से स्लाइड जोड़ें—सेकंडों में सहज, प्रभावी स्लाइड सम्मिलन।"
---
## **परिचय**

प्रेजेंटेशन में स्लाइड्स जोड़ने से पहले, यह समझना उपयोगी होता है कि PowerPoint उन्हें कैसे व्यवस्थित करता है। प्रत्येक प्रेजेंटेशन में एक मास्टर स्लाइड, वैकल्पिक लेआउट स्लाइड्स, और एक या अधिक सामान्य स्लाइड्स होते हैं। प्रत्येक स्लाइड का एक विशिष्ट ID होता है, और सामान्य स्लाइड्स शून्य-आधारित अनुक्रमणिका के अनुसार क्रमबद्ध होती हैं। यह लेख दिखाता है कि Aspose.Slides for Python का उपयोग करके स्लाइड्स कैसे बनाएँ और उपयुक्त लेआउट कैसे चुनें।

## **प्रेजेंटेशन में स्लाइड्स जोड़ें**

Aspose.Slides आपको मौजूदा लेआउट स्लाइड्स के आधार पर नई स्लाइड्स जोड़ने की अनुमति देता है। नीचे दिया गया उदाहरण प्रेजेंटेशन में प्रत्येक लेआउट पर遍ित करता है, उस लेआउट का उपयोग करती हुई एक स्लाइड जोड़ता है, और फिर फ़ाइल को सहेजता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. [SlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) तक पहुंचें।
1. `presentation.layout_slides` में प्रत्येक आइटम के लिए, उस लेआउट का उपयोग करती हुई स्लाइड जोड़ने के लिए `add_empty_slide` कॉल करें।
1. वैकल्पिक रूप से नई जोड़ी गई स्लाइड्स को संशोधित करें।
1. प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाएँ।
with slides.Presentation() as presentation:
    # स्लाइड संग्रह तक पहुंचें।
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # स्लाइड संग्रह में एक खाली स्लाइड जोड़ें।
        slides.add_empty_slide(layout_slide)

    # नई जोड़ी गई स्लाइड्स पर कुछ कार्य करें।

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नई स्लाइड को अंत में ही नहीं, बल्कि किसी विशेष स्थिति पर भी डाल सकता हूँ?**

हां। लाइब्रेरी स्लाइड संग्रह और [insert](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/insert_clone/) ऑपरेशन्स को समर्थन देती है, जिससे आप आवश्यक अनुक्रमांक पर स्लाइड जोड़ सकते हैं, केवल अंत में नहीं।

**क्या लेआउट के आधार पर स्लाइड जोड़ते समय थीम/शैलियों को संरक्षित रखा जाता है?**

हां। एक लेआउट अपने मास्टर से फॉर्मेटिंग विरासत में लेता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित मास्टर से विरासत में लेती है।

**स्लाइड्स जोड़ने से पहले एक नई "खाली" प्रेजेंटेशन में कौन सी स्लाइड मौजूद रहती है?**

एक नई बनाई गई प्रेजेंटेशन में पहले से ही शून्य अनुक्रमांक वाली एक खाली स्लाइड होती है। सम्मिलन अनुक्रमांक की गणना करते समय इसे ध्यान में रखना महत्वपूर्ण है।

**यदि मास्टर में कई विकल्प हैं तो नई स्लाइड के लिए "सही" लेआउट कैसे चुनें?**

आमतौर पर आवश्यक संरचना से मेल खाता हुआ [LayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) चुनें ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidelayouttype/))। यदि ऐसा लेआउट मौजूद नहीं है, तो आप इसे [मास्टर में जोड़ें](/slides/hi/python-net/slide-layout/) कर सकते हैं और फिर उपयोग करें।