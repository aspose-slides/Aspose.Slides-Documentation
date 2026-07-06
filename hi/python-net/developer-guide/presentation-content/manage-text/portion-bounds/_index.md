---
title: "Python में प्रस्तुतियों से टेक्स्ट पोर्शन सीमाएँ प्राप्त करें"
linktitle: "पोर्शन सीमाएँ"
type: docs
weight: 47
url: /hi/python-net/portion-bounds/
keywords:
- "टेक्स्ट पोर्शन सीमाएँ"
- "टेक्स्ट पोर्शन"
- "टेक्स्ट भाग"
- "टेक्स्ट निर्देशांक"
- "टेक्स्ट स्थिति"
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट पोर्शन सीमाएँ कैसे प्राप्त करें, सीखें।"
---
## **अवलोकन**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर टेक्स्ट का एक विशिष्ट भाग दर्शाता है और आपको उस भाग को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन्स का उपयोग तब किया जा सकता है जब आपको टेक्स्ट फ़्रैगमेंट की सीमाएं प्राप्त करनी हों, पैराग्राफ के केवल हिस्से पर फॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो। यह लेख दिखाता है कि कैसे [Portion.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_rect/) का उपयोग करके पोर्शन का बाउंडिंग आयत प्राप्त किया जा सकता है। यह यह भी दर्शाता है कि कैसे [Portion.get_coordinates](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_coordinates/) का उपयोग करके पोर्शन की शुरुआत के निर्देशांक प्राप्त किए जा सकते हैं। इसके अतिरिक्त, यह सामान्य पोर्शन-संबंधी परिस्थितियों को उजागर करता है, जैसे एकल टेक्स्ट फ़्रैगमेंट पर हाइपरलिंक लागू करना, यह समझना कि फॉर्मेटिंग पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से कैसे हल होती है, और उन मामलों को संभालना जहाँ निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं है।

## **टेक्स्ट पोर्शन की सीमाएँ प्राप्त करें**

टेक्स्ट पोर्शन का बाउंडिंग आयत प्राप्त करने के लिए [Portion.get_rect](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_rect/) का उपयोग करें:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**

टेक्स्ट पोर्शन की शुरुआत के निर्देशांक प्राप्त करने के लिए [Portion.get_coordinates](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_coordinates/) का उपयोग करें:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एकल पैराग्राफ के भीतर टेक्स्ट के केवल भाग पर हाइपरलिंक लगा सकता हूँ?**

हाँ, आप व्यक्तिगत पोर्शन को [हाइपरलिंक असाइन करें](/slides/hi/python-net/manage-hyperlinks/) कर सकते हैं; केवल वह भाग क्लिक करने योग्य होगा, न कि पूरा पैराग्राफ।

**स्टाइल इनहेरिटेंस कैसे काम करता है: पोर्शन क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

पोर्शन-स्तर की प्रॉपर्टीज़ को सबसे उच्च प्राथमिकता मिलती है। यदि किसी प्रॉपर्टी को [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) पर सेट नहीं किया गया है, तो Aspose.Slides इसे [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) से लेता है। यदि वहाँ भी सेट नहीं है, तो Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/theme/) स्टाइल का उपयोग करता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/python-net/font-selection-sequence/) लागू होते हैं। टेक्स्ट पुन: प्रवाहित हो सकता है: मेट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपेरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, टेक्स्ट रंग, फ़िल, और ट्रांसपेरेंसी को [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) स्तर पर पड़ोसी फ़्रैगमेंट्स से अलग रखा जा सकता है।