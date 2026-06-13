---
title: Python में प्रस्तुतियों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/python-net/extract-text-from-presentation/
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
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से तेज़ी से टेक्स्ट निकालें। समय बचाने के लिए हमारे सरल, चरण-दर-चरण गाइड का पालन करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना विकासकर्ताओं के लिए एक सामान्य लेकिन आवश्यक कार्य है जो स्लाइड सामग्री के साथ काम करते हैं। चाहे आप Microsoft PowerPoint फ़ाइलों को PPT या PPTX फॉर्मेट में संभाल रहे हों, या OpenDocument प्रेजेंटेशन (ODP) के साथ काम कर रहे हों, टेक्स्ट डेटा को एक्सेस करना और प्राप्त करना विश्लेषण, ऑटोमेशन, इंडेक्सिंग या कंटेंट माइग्रेशन उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फॉर्मेट्स जैसे PPT, PPTX और ODP से Aspose.Slides for Python via .NET का उपयोग करके कुशलतापूर्वक टेक्स्ट निकालने पर एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रेजेंटेशन तत्वों के माध्यम से व्यवस्थित रूप से कैसे इटरेंट करें ताकि आवश्यक टेक्स्ट सामग्री को सटीक रूप से पुनः प्राप्त किया जा सके।

## **स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for Python via .NET [aspose.slides.util](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/) नेमस्पेस प्रदान करता है, जिसमें [SlideUtil](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/) क्लास शामिल है। यह क्लास प्रस्तुति या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्थैतिक मेथड प्रदान करती है। प्रस्तुति में किसी स्लाइड से टेक्स्ट निकालने के लिए, [get_all_text_boxes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) मेथड का उपयोग करें। यह मेथड प्रकार [BaseSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/) का एक ऑब्जेक्ट पैरामीटर के रूप में स्वीकार करता है। निष्पादित होने पर, यह मेथड पूरी स्लाइड में टेक्स्ट को स्कैन करता है और प्रकार [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के ऑब्जेक्ट्स की एक एरे लौटाता है, जो किसी भी टेक्स्ट फ़ॉर्मेटिंग को बनाए रखता है।

निम्नलिखित कोड स्निपेट प्रस्तुति की पहली स्लाइड से सभी टेक्स्ट को निकालता है:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **प्रेजेंटेशन से टेक्स्ट निकालें**

पूरी प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/) क्लास द्वारा प्रदान किया गया [get_all_text_frames](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/get_all_text_frames/) स्थैतिक मेथड उपयोग करें। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन को दर्शाता है, जिससे टेक्स्ट निकाला जाएगा।
1. दूसरा, एक `Boolean` मान जो यह दर्शाता है कि प्रेजेंटेशन से टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड प्रकार [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के ऑब्जेक्ट्स की एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन से, साथ ही मास्टर स्लाइड्स से, टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **श्रेणीक्रमित और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशनों से सभी टेक्स्ट निकालने के मेथड प्रदान करती है:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textextractionarrangingmode/) Enum आर्ग्यूमेंट टेक्स्ट निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्नलिखित मानों में सेट किया जा सकता है:
- `UNARRANGED` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `ARRANGED` - टेक्स्ट स्लाइड पर जैसी क्रम में व्यवस्थित होता है।

जब गति महत्वपूर्ण हो तो `UNARRANGED` मोड का उपयोग किया जा सकता है; यह `ARRANGED` मोड की तुलना में तेज़ है।

[PresentationText](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट का प्रतिनिधित्व करता है। इसकी `slides_text` प्रॉपर्टी स्लाइड टेक्स्ट ऑब्जेक्ट्स की एक एरे लौटाती है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को दर्शाता है और इसमें निम्नलिखित प्रॉपर्टी होते हैं:

- `text` - स्लाइड के शेप्स के भीतर मौजूद टेक्स्ट।
- `master_text` - इस स्लाइड से संबंधित मास्टर स्लाइड के शेप्स के भीतर मौजूद टेक्ट।
- `layout_text` - इस स्लाइड से संबंधित लेआउट स्लाइड के शेप्स के भीतर मौजूद टेक्ट।
- `notes_text` - इस स्लाइड से संबंधित नोट्स स्लाइड के शेप्स के भीतर मौजूद टेक्स्ट।
- `comments_text` - इस स्लाइड से जुड़े टिप्पणी में मौजूद टेक्स्ट।

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बड़े प्रेजेंटेशनों को टेक्स्ट निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [large presentations](/slides/hi/python-net/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बड़े पैमाने पर प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशन में टेबल और चार्ट से टेक्स्ट निकाल सकता है?**

हाँ। Aspose.Slides कई स्लाइड तत्वों से टेक्स्ट निकाल सकता है, जिसमें टेबल और चार्ट‑से सम्बन्धित ऑब्जेक्ट्स शामिल हैं, इसलिए आप सामान्य प्रेजेंटेशन संरचनाओं में टेक्स्टुअल सामग्री को एक्सेस और विश्लेषण कर सकते हैं।

**क्या प्रेजेंटेशन से टेक्स्ट निकालने के लिए मुझे Aspose.Slides का विशेष लाइसेंस चाहिए?**

आप Aspose.Slides के मुफ्त ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [certain limitations](/slides/hi/python-net/licensing/) होंगी, जैसे कि केवल सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेजेंटेशनों को संभालने के लिए पूर्ण लाइसेंस खरीदना अनुशंसा किया जाता है।