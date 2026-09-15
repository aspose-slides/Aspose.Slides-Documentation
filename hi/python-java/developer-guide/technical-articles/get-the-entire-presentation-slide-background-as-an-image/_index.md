---
title: प्रेजेंटेशन से पूरे स्लाइड पृष्ठभूमि को एक छवि के रूप में प्राप्त करें
linktitle: संपूर्ण स्लाइड पृष्ठभूमि
type: docs
weight: 95
url: /hi/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- स्लाइड पृष्ठभूमि
- अंतिम पृष्ठभूमि
- पृष्ठभूमि निकालें
- पूर्ण पृष्ठभूमि
- पृष्ठभूमि को छवि में
- PPT पृष्ठभूमि
- PPTX पृष्ठभूमि
- ODP पृष्ठभूमि
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से पूरे स्लाइड पृष्ठभूमियों को छवियों के रूप में निकालें, जिससे दृश्य कार्यप्रवाह सुगम बनता है।"
---
## **सारांश**

PowerPoint प्रस्तुतियों में, स्लाइड पृष्ठभूमि कई तत्वों से बन सकती है, जिसमें स्लाइड पृष्ठभूमि छवि, प्रस्तुति थीम, रंग योजना, और मास्टर स्लाइड या लेआउट स्लाइड पर रखी गई वस्तुएँ शामिल हैं।

यह लेख Aspose.Slides for Python via Java का उपयोग करके पूरे स्लाइड पृष्ठभूमि को छवि के रूप में निकालने का तरीका दिखाता है। क्योंकि इस कार्य के लिए कोई एकल विधि नहीं है, इस दृष्टिकोण में चयनित स्लाइड को एक अस्थायी प्रस्तुति में क्लोन करना, स्लाइड के आकार हटाना, और फिर परिणामस्वरूप स्लाइड पृष्ठभूमि को छवि में बदलना शामिल है।

## **पूरी स्लाइड पृष्ठभूमि प्राप्त करें**

Aspose.Slides for Python via Java पूरे प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालने की सरल विधि प्रदान नहीं करता है, लेकिन आप नीचे दिए गए चरणों का पालन करके यह कर सकते हैं:

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. प्रस्तुति से स्लाइड आकार प्राप्त करें।
1. एक स्लाइड चुनें।
1. एक अस्थायी प्रस्तुति बनाएं।
1. अस्थायी प्रस्तुति में समान स्लाइड आकार सेट करें।
1. चयनित स्लाइड को अस्थायी प्रस्तुति में क्लोन करें।
1. क्लोन किए गए स्लाइड से आकार हटाएँ।
1. क्लोन किए गए स्लाइड को छवि में बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मास्टर स्लाइड से जटिल ग्रेडिएंट, बनावट, या चित्र भराव परिणामस्वरूप पृष्ठभूमि छवि में संरक्षित रहेंगे?**

हां। Aspose.Slides स्लाइड, लेआउट या मास्टर पर परिभाषित ग्रेडिएंट, चित्र और बनावट भराव को रेंडर करता है। यदि आपको विरासत में मिली मास्टर से लुक को अलग करना है, तो निर्यात करने से पहले वर्तमान स्लाइड पर [कस्टम पृष्ठभूमि सेट करें](/slides/hi/python-java/presentation-background/)।

**क्या मैं परिणामस्वरूप पृष्ठभूमि छवि को सहेजने से पहले उसमें वॉटरमार्क जोड़ सकता हूँ?**

हां। आप कार्यशील स्लाइड की [कॉपी](/slides/hi/python-java/clone-slides/) पर [वॉटरमार्क जोड़ें](/slides/hi/python-java/watermark/) आकार या छवि (अन्य सामग्री के पीछे रखी) रख सकते हैं और फिर निर्यात कर सकते हैं। इससे आप वॉटरमार्क सम्मिलित पृष्ठभूमि छवि बना सकते हैं।

**क्या मैं किसी विशिष्ट लेआउट या मास्टर की पृष्ठभूमि को किसी मौजूदा स्लाइड से जोड़े बिना प्राप्त कर सकता हूँ?**

हां। वांछित मास्टर या लेआउट तक पहुंचें, इसे आवश्यक आकार के साथ एक [अस्थायी स्लाइड](/slides/hi/python-java/clone-slides/) पर लागू करें, और उस स्लाइड को निर्यात करें ताकि उस लेआउट या मास्टर से निकाली गई पृष्ठभूमि प्राप्त हो सके।

**क्या ऐसी लाइसेंसिंग सीमाएँ हैं जो छवि निर्यात को प्रभावित करती हैं?**

रेंडरिंग सुविधाएँ [वैध लाइसेंस](/slides/hi/python-java/licensing/) के साथ पूरी तरह उपलब्ध हैं। मूल्यांकन मोड में, आउटपुट में वॉटरमार्क जैसी सीमाएँ हो सकती हैं। बैच निर्यात चलाने से पहले प्रक्रिया में एक बार लाइसेंस सक्रिय करें।