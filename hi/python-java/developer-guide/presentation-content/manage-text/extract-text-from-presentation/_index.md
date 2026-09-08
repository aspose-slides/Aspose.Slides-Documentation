---
title: Python via Java में प्रस्तुतियों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/python-java/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट प्राप्त करें
- स्लाइड से टेक्स्ट प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट प्राप्त करें
- PowerPoint से टेक्स्ट प्राप्त करें
- OpenDocument से टेक्स्ट प्राप्त करें
- PPT से टेक्स्ट प्राप्त करें
- PPTX से टेक्स्ट प्राप्त करें
- ODP से टेक्स्ट प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से टेक्स्ट शीघ्रता से निकालें। समय बचाने के लिए हमारे सरल, क्रमिक चरणों वाले मार्गदर्शक का पालन करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना एक सामान्य लेकिन आवश्यक कार्य है उन डेवलपर्स के लिए जो स्लाइड सामग्री के साथ काम करते हैं। चाहे आप Microsoft PowerPoint फ़ाइलों (PPT या PPTX) के साथ काम कर रहे हों, या OpenDocument प्रेजेंटेशन (ODP) के साथ, टेक्स्ट डेटा तक पहुँच और उसे पुनः प्राप्त करना विश्लेषण, स्वचालन, इंडेक्सिंग, या सामग्री स्थानांतरण के उद्देश्य से महत्वपूर्ण हो सकता है।

यह लेख Aspose.Slides for Python via Java का उपयोग करके विभिन्न प्रेजेंटेशन फॉर्मैट—PPT, PPTX, और ODP—से टेक्स्ट को प्रभावी ढंग से निकालने के लिए एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रेजेंटेशन तत्वों में व्यवस्थित रूप से कैसे घूमें ताकि आवश्यक टेक्स्ट सामग्री को सही ढंग से प्राप्त किया जा सके।

## **एक स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for Python via Java [SlideUtil](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/) क्लास प्रदान करता है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड्स को उजागर करता है। किसी प्रेजेंटेशन की स्लाइड से टेक्स्ट निकालने के लिए, [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#getAllTextBoxes) मेथड का उपयोग करें। यह मेथड [BaseSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/) प्रकार के ऑब्जेक्ट को पैरामीटर के रूप में लेता है। जब निष्पादित किया जाता है, यह मेथड पूरे स्लाइड को टेक्स्ट के लिए स्कैन करता है और [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिससे सभी टेक्स्ट फ़ॉर्मेटिंग बरक़रार रहती है।

निम्न कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट निकालता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **पूरे प्रेजेंटेशन से टेक्स्ट निकालें**

पूरे प्रेजेंटेशन में टेक्स्ट स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/) क्लास द्वारा उजागर किए गए [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#getAllTextFrames) स्टैटिक मेथड का उपयोग करें। यह दो पैरामीटर लेता है:

1. पहला, एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन को दर्शाता है जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `bool` मान जो यह दर्शाता है कि टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन, साथ ही मास्टर स्लाइड्स, से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **वर्गीकृत और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशन से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# फ़ाइल से टेक्स्ट निकालें।
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# स्ट्रीम से टेक्स्ट निकालें।
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# लोड विकल्पों का उपयोग करके स्ट्रीम से टेक्स्ट निकालें।
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textextractionarrangingmode/) एन्ऊम आर्ग्युमेंट निष्कर्षित टेक्स्ट के परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में सेट किया जा सकता है:

- [Unarranged](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- [Arranged](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - टेक्स्ट उसी क्रम में व्यवस्थित होता है जैसा स्लाइड पर है।

जब गति महत्वपूर्ण हो तो अनारेंज्ड मोड का उपयोग किया जा सकता है; यह एरेंज्ड मोड की तुलना में तेज़ है।

[PresentationText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसका [getSlidesText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationtext/#getSlidesText) मेथड `SlideText` प्रकार के ऑब्जेक्ट्स की एरे लौटाता है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को दर्शाता है। `SlideText` प्रकार के ऑब्जेक्ट में निम्न मेथड्स होते हैं:

- `getText` - स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getMasterText` - इस स्लाइड से संबंधित मास्टर स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getLayoutText` - इस स्लाइड से संबंधित लेआउट स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getNotesText` - इस स्लाइड से संबंधित नोट्स स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `getCommentsText` - इस स्लाइड से जुड़े टिप्पणियों का टेक्स्ट।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बड़े प्रेजेंटेशन पर टेक्स्ट निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [बड़े प्रेजेंटेशन](/slides/hi/python-java/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बन जाता है।

**क्या Aspose.Slides प्रेजेंटेशन के भीतर तालिकाओं और चार्ट्स से भी टेक्स्ट निकाल सकता है?**

हाँ। Aspose.Slides कई स्लाइड तत्वों—जिसमें तालिकाएँ और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं—से टेक्स्ट निकाल सकता है, ताकि आप सामान्य प्रेजेंटेशन संरचनाओं में मौजूद टेक्स्ट सामग्री तक पहुँच और उसका विश्लेषण कर सकें।

**क्या प्रेजेंटेशन से टेक्स्ट निकालने के लिए विशेष Aspose.Slides लाइसेंस की आवश्यकता है?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/python-java/licensing/) होंगी, जैसे कि सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेजेंटेशन को संभालने के लिए पूर्ण लाइसेंस खरीदना अनुशंसित है।