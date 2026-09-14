---
title: Python में प्रस्तुतियों में स्लाइड जोड़ें
linktitle: स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/python-java/add-slide-to-presentation/
keywords:
- स्लाइड जोड़ें
- स्लाइड बनाएं
- खाली स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके अपने PowerPoint और OpenDocument प्रस्तुतियों में आसानी से स्लाइड जोड़ें—सेकंडों में सहज और कुशल स्लाइड सम्मिलन।"
---
## **समावलोकन**

Aspose.Slides आपको प्रोग्रामैटिक रूप से PowerPoint प्रस्तुतियों में स्लाइड जोड़ने की अनुमति देता है। एक प्रस्तुति में मास्टर/लेआउट स्लाइड और सामान्य स्लाइड होते हैं, और सामान्य स्लाइड शून्य‑आधारित अनुक्रमांक द्वारा व्यवस्थित की जाती हैं। प्रत्येक स्लाइड का एक अनूठा ID होता है, और बिना स्लाइड वाली प्रस्तुतियों का समर्थन नहीं किया जाता।

यह लेख बताता है कि कैसे एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाया जाए, उसकी स्लाइड कलेक्शन तक पहुँच प्राप्त की जाए, एक खाली स्लाइड जोड़ी जाए, नई जोड़ी गई स्लाइड के साथ काम किया जाए, और अपडेटेड प्रस्तुति को सहेजा जाए। यह विशेष स्थितियों जैसे किसी निश्चित स्थान पर स्लाइड सम्मिलित करना, लेआउट का उपयोग करना, और नई बनाई गई प्रस्तुति में मौजूद खाली स्लाइड को समझना आदि को भी कवर करता है।

## **प्रस्तुति में स्लाइड जोड़ना**

प्रस्तुति फ़ाइलों में स्लाइड जोड़ने के बारे में चर्चा करने से पहले, आइए स्लाइड के बारे में कुछ तथ्यों की समीक्षा करें। प्रत्येक PowerPoint प्रस्तुति फ़ाइल में **मास्टर/लेआउट** स्लाइड और **सामान्य** स्लाइड होते हैं। एक प्रस्तुति फ़ाइल में कम से कम एक स्लाइड होती है। Aspose.Slides for Python via Java द्वारा स्लाइड‑रहित फ़ाइलों का समर्थन नहीं किया जाता। प्रत्येक स्लाइड का एक अनूठा ID होता है, और सभी सामान्य स्लाइड शून्य‑आधारित अनुक्रमांक द्वारा निर्दिष्ट क्रम में व्यवस्थित होती हैं।

Aspose.Slides for Python via Java डेवलपर्स को अपनी प्रस्तुतियों में खाली स्लाइड जोड़ने की सुविधा देता है। प्रस्तुति में एक खाली स्लाइड जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदान किए गए [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) मेथड का उपयोग करके [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
- [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [addEmptySlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addEmptySlide) मेथड को कॉल करके प्रस्तुति की स्लाइड कलेक्शन के अंत में एक खाली स्लाइड जोड़ें।
- नई जोड़ी गई खाली स्लाइड के साथ कुछ कार्य करें।
- अंत में, [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    # स्लाइड कलेक्शन प्राप्त करें।
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # स्लाइड कलेक्शन में एक खाली स्लाइड जोड़ें।
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # नई जोड़ी गई स्लाइड पर कुछ कार्य करें।

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड को अंत में जोड़ने के बजाय किसी विशिष्ट स्थान पर सम्मिलित कर सकता हूँ?**

हां। लाइब्रेरी स्लाइड कलेक्शन और [insert](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertClone) ऑपरेशन का समर्थन करती है, इसलिए आप आवश्यक अनुक्रमांक पर स्लाइड जोड़ सकते हैं, केवल अंत में नहीं।

**लेआउट के आधार पर स्लाइड जोड़ते समय थीम/शैलियाँ बनी रहती हैं क्या?**

हां। लेआउट अपने मास्टर से फ़ॉर्मेटिंग विरासत में लेता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित मास्टर से विरासत में प्राप्त करती है।

**नई "खाली" प्रस्तुति में स्लाइड जोड़ने से पहले कौन सी स्लाइड मौजूद होती है?**

नव निर्मित प्रस्तुति में पहले से ही शून्य अनुक्रमांक वाली एक खाली स्लाइड होती है। यह सम्मिलन अनुक्रमांक की गणना करते समय ध्यान में रखना महत्वपूर्ण है।

**यदि मास्टर में कई विकल्प हों तो नई स्लाइड के लिए सही लेआउट कैसे चुनें?**

आमतौर पर, आवश्यक संरचना से मेल खाने वाला [LayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/) चुनें ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidelayouttype/))। यदि ऐसा लेआउट उपलब्ध नहीं है, तो आप इसे [मास्टर में जोड़ सकते हैं](/slides/hi/python-java/slide-layout/) और फिर उसका उपयोग कर सकते हैं।