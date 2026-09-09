---
title: Python के माध्यम से Java के जरिए प्रस्तुतियों में टेक्स्ट पोर्शन की सीमाएँ प्राप्त करें
linktitle: पोर्शन सीमाएँ
type: docs
weight: 47
url: /hi/python-java/portion-bounds/
keywords:
- टेक्स्ट पोर्शन सीमाएँ
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन की सीमाएँ प्राप्त करने के तरीके जानें।"
---
## **परिचय**

टेक्स्ट पोर्शन पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट टुकड़े का प्रतिनिधित्व करता है और आपको उस टुकड़े को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जाता है जब आपको टेक्स्ट टुकड़े की सीमाएँ प्राप्त करनी हों, पैराग्राफ के केवल भाग पर फॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

यह लेख दिखाता है कि किस प्रकार आप [Portion.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getRect) का उपयोग करके पोर्शन का बाउंडिंग रेक्टैंगल प्राप्त कर सकते हैं। यह यह भी दर्शाता है कि आप [Portion.getCoordinates](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getCoordinates) का उपयोग करके पोर्शन की शुरुआत के निर्देशांक कैसे प्राप्त कर सकते हैं। इसके अतिरिक्त, यह आम पोर्शन‑संबंधी परिदृश्यों को उजागर करता है, जैसे एकल टेक्स्ट टुकड़े पर हाइपरलिंक लागू करना, पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से फॉर्मेटिंग कैसे हल होती है, और जब निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं हो तो उन स्थितियों को संभालना।

## **टेक्स्ट पोर्शन की सीमाएँ प्राप्त करें**

टेक्स्ट पोर्शन का बाउंडिंग रेक्टैंगल प्राप्त करने के लिए [Portion.getRect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getRect) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**

टेक्स्ट पोर्शन की शुरुआत के निर्देशांक प्राप्त करने के लिए [Portion.getCoordinates](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getCoordinates) का उपयोग करें:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक पैराग्राफ के भीतर केवल टेक्स्ट के किसी भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप एक व्यक्तिगत पोर्शन को [हाइपरलिंक असाइन करें](/slides/hi/python-java/manage-hyperlinks/) कर सकते हैं; केवल वही टुकड़ा क्लिक करने योग्य होगा, पूरी पैराग्राफ नहीं।

**स्टाइल विरासत कैसे काम करती है: पोर्शन क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

पोर्शन‑स्तर की प्रॉपर्टीज़ की सबसे अधिक प्राथमिकता होती है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) पर सेट नहीं है, तो Aspose.Slides उसे [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) से लेता है। यदि वह भी वहाँ सेट नहीं है, तो Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/theme/) स्टाइल का उपयोग करता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/python-java/font-selection-sequence/) लागू होते हैं। टेक्स्ट रीफ़्लो हो सकता है: मेट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन‑विशिष्ट टेक्स्ट फIll पारदर्शिता या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, टेक्स्ट रंग, फIll और पारदर्शिता [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) स्तर पर पड़ोसी टुकड़ों से भिन्न हो सकती है।