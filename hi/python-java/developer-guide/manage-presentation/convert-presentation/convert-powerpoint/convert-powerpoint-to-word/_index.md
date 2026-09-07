---
title: Python के माध्यम से Java के साथ PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- PowerPoint से Word
- प्रस्तुति से Word
- PPT से Word
- PPTX से Word
- ODP से Word
- PowerPoint से DOCX
- PPT से DOCX
- PPTX से DOCX
- PowerPoint से DOC
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT को DOCX में निर्यात करें
- PPTX को DOCX में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides और Aspose.Words के साथ Python के माध्यम से Java में PowerPoint और OpenDocument प्रस्तुतियों को Word में परिवर्तित करें, स्लाइड छवियों को संपादनीय पाठ के साथ संयोजित करते हुए।"
---
## **समीक्षा**

यह लेख बताता है कि कैसे Aspose.Slides for Python via Java को Aspose.Words for Java के साथ मिलाकर PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित किया जाए। Aspose.Slides प्रत्येक स्लाइड को रेंडर करता है और उसका पाठ पढ़ता है, जबकि Aspose.Words JPype के माध्यम से Word दस्तावेज़ बनाता है। Microsoft Office की आवश्यकता नहीं है।

परिणामी दस्तावेज़ में स्लाइड की छवि के बाद उस स्लाइड की शीर्ष-स्तर ऑटो शेप्स से निकाला गया संपादनीय पाठ शामिल होता है। छवि स्लाइड की दृश्य उपस्थिति को बनाए रखती है; व्यक्तिगत शेप्स, चार्ट और टेबल्स को संपादनीय Word ऑब्जेक्ट्स में परिवर्तित नहीं किया जाता। निकाली गई पाठ मूल पाठ के स्वरूप या स्थिति को महसूस नहीं रखता।

## **PowerPoint को Word में परिवर्तित करें**

1. इंस्टॉल करें [Aspose.Slides for Python via Java](/slides/hi/python-java/installation/) और एक संगत Java रनटाइम।
2. डाउनलोड करें [Aspose.Words for Java](https://releases.aspose.com/words/java/)। इसका मुख्य JAR फ़ाइल अपने स्क्रिप्ट के बगल में `lib` डायरेक्टरी में रखें और उसका नाम `aspose-words.jar` रखें, या उदाहरण में पथ को अपने डाउनलोड किए गए फ़ाइल के साथ मेल खाने के लिए समायोजित करें।
3. इनपुट प्रस्तुति, `sample.pptx`, को कार्य निर्देशिका में रखें। `lib/aspose-words.jar` पथ भी उसी निर्देशिका के सापेक्ष है।
4. निम्नलिखित Python कोड चलाएँ ताकि `output.docx` निर्मित हो सके।

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # स्लाइड छवि को टेक्स्ट क्षेत्र की चौड़ाई के अनुसार फिट करें, इसके अनुपात को बनाए रखते हुए।
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # शीर्ष-स्तर ऑटो शेप्स, जिसमें टेक्स्ट बॉक्स शामिल हैं, से साधारण पाठ जोड़ें।
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

प्रत्येक स्लाइड नई पेज पर शुरू होती है। लम्बा निकाला गया पाठ या अत्यधिक ऊँची स्लाइड छवियों को अतिरिक्त पन्नों की आवश्यकता हो सकती है। कोड केवल स्लाइड्स के बीच पेज ब्रेक जोड़ता है और `finally` ब्लॉकों में प्रस्तुति और रेंडर की गई छवियों को रिलीज़ करता है। JVM उसी Python प्रक्रिया में बाद के रूपांतरणों के लिए उपलब्ध रहता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सी लाइब्रेरी आवश्यक हैं?**

Aspose.Slides for Python via Java, JPype, एक संगत Java रनटाइम, और Aspose.Words for Java का उपयोग करें। दोनों Aspose लाइब्रेरी एक ही JVM में चलती हैं। Aspose.Slides प्रस्तुति को संभालता है; Aspose.Words Word दस्तावेज़ लिखता है।

**क्या मैं PPT और ODP फ़ाइलों को PPTX के साथ परिवर्तित कर सकता हूँ?**

हाँ। `sample.pptx` को PPT या ODP फ़ाइल से बदलें। प्रस्तुति इनपुट फॉर्मेट्स के लिए [Supported File Formats](/slides/hi/python-java/supported-file-formats/) देखें।

**क्या सभी स्लाइड सामग्री Word में संपादनीय है?**

नहीं। प्रत्येक स्लाइड को एक स्थिर छवि के रूप में डाला जाता है, और शीर्ष-स्तर ऑटो शेप्स से निकाला गया साधारण पाठ नीचे जोड़ा जाता है। समूहों, टेबल्स, SmartArt, और चार्ट्स के भीतर का पाठ, साथ ही स्पीकर नोट्स, इस उदाहरण द्वारा निकाले नहीं जाते। एनीमेशन और ट्रांज़िशन Word दस्तावेज़ में पुनरुत्पादित नहीं होते।

**क्या मैं DOC को DOCX के बजाय सहेज सकता हूँ?**

हाँ। आउटपुट फ़ाइलनाम को `output.doc` में बदलें। इस सहेजने वाले ओवरलोड का उपयोग करते समय Aspose.Words फ़ाइलनाम एक्सटेंशन से आउटपुट फॉर्मेट चुनता है।