---
title: Python के साथ प्रस्तुतियों में प्लेसहोल्डर प्रबंधन
linktitle: प्लेसहोल्डर प्रबंधन
type: docs
weight: 10
url: /hi/python-net/manage-placeholder/
keywords:
- प्लेसहोल्डर
- पाठ प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के साथ .NET के माध्यम से प्लेसहोल्डर को आसानी से प्रबंधित करें: पाठ को बदलें, प्रॉम्प्ट को अनुकूलित करें और PowerPoint एवं OpenDocument में छवि की पारदर्शिता सेट करें।"
---
## **समीक्षा**

Aspose.Slides आपको प्रस्तुति के प्लेसहोल्डर को प्रोग्रामैटिक रूप से प्रबंधित करने की अनुमति देता है। यह लेख स्लाइड्स पर प्लेसहोल्डर खोजने, उनके टेक्स्ट को बदलने, प्लेसहोल्डर लेआउट्स के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करने, और प्लेसहोल्डर पृष्ठभूमि के रूप में उपयोग की गई छवि की पारदर्शिता समायोजित करने के तरीके को समझाता है। इसमें एक संक्षिप्त FAQ भी शामिल है जो बेस प्लेसहोल्डर और लोकल शैप के बीच अंतर को स्पष्ट करता है, बताता है कि प्लेसहोल्डर परिवर्तन लेआउट या मास्टर के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर व फ़ूटर प्लेसहोल्डर प्रबंधन की ओर संकेत करता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

Aspose.Slides for Python का उपयोग करके, आप प्रस्तुति की स्लाइड्स में प्लेसहोल्डर खोज और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर के टेक्स्ट को बदलने की सुविधा देता है।

**पूर्वापेक्षा:** आपके पास एक ऐसी प्रस्तुति होनी चाहिए जिसमें प्लेसहोल्डर हो। आप ऐसी प्रस्तुति माइक्रोसॉफ्ट पॉवरपॉइंट में बना सकते हैं।

यहाँ Aspose.Slides का उपयोग करके प्लेसहोल्डर में टेक्स्ट बदलने का तरीका दिया गया है:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और प्रस्तुति को आर्गुमेंट के रूप में पास करें।
1. उसके इंडेक्स से स्लाइड का रेफ़रेंस प्राप्त करें।
1. शैप को इटरेट करके प्लेसहोल्डर खोजें।
1. [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) से जुड़े [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) का उपयोग करके टेक्स्ट बदलें।
1. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दिखाता है कि प्लेसहोल्डर में टेक्स्ट कैसे बदलें:

```python
import aspose.slides as slides

# Presentation क्लास को इनस्टैंशिएट करें।
with slides.Presentation("ReplacingText.pptx") as presentation:
    # पहला स्लाइड एक्सेस करें।
    slide = presentation.slides[0]

    # प्लेसहॉल्डर खोजने के लिए शेप्स पर इटरेट करें।
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # प्रत्येक प्लेसहॉल्डर में टेक्स्ट बदलें।
            shape.text_frame.text = "This is Placeholder"

    # प्रस्तुति को डिस्क पर सेव करें।
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **प्लेसहोल्डर के लिए प्रॉम्प्ट टेक्स्ट सेट करें**

स्टैण्डर्ड और प्री‑बिल्ट लेआउट्स में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट जैसे **Click to add a title** या **Click to add a subtitle** शामिल होते हैं। Aspose.Slides के साथ, आप इन प्रॉम्प्ट को अपने स्वयं के टेक्स्ट से प्लेसहोल्डर लेआउट में बदल सकते हैं।

निम्नलिखित Python उदाहरण दर्शाता है कि प्लेसहोल्डर के लिए प्रॉम्प्ट टेक्स्ट कैसे सेट करें:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # प्लेसहोल्डर खोजने के लिए शेप्स पर इटरेट करें।
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **प्लेसहोल्डर में छवि की पारदर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर के पृष्ठभूमि छवि की पारदर्शिता सेट करने की अनुमति देता है। उस फ्रेम में चित्र की पारदर्शिता समायोजित करके, आप टेक्स्ट या छवि को उनके रंगों के आधार पर अधिक प्रमुख बना सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि शैप के भीतर चित्र पृष्ठभूमि की पारदर्शिता कैसे सेट करें:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**एक बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर स्थानीय शैप से कैसे भिन्न है?**

एक बेस प्लेसहोल्डर लेआउट या मास्टर पर मूल शैप होता है जिससे स्लाइड की शैप टाइप, पोजीशन, और कुछ फ़ॉर्मेटिंग विरासत में लेती है। एक स्थानीय शैप स्वतंत्र होता है; यदि बेस प्लेसहोल्डर नहीं है तो विरासत लागू नहीं होती।

**मैं पूरी प्रस्तुति में सभी शीर्षक या कैप्शन को बिना प्रत्येक स्लाइड पर इटरशन किए कैसे अपडेट करूँ?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को संपादित करें। उन लेआउट/मास्टर पर आधारित स्लाइड्स स्वचालित रूप से परिवर्तन को विरासत में ले लेगी।

**मैं मानक हेडर/फ़ूटर प्लेसहोल्डर—तारीख एवं समय, स्लाइड नंबर, और फ़ूटर टेक्स्ट—को कैसे नियंत्रित करूँ?**

उपयुक्त स्कोप (सामान्य स्लाइड्स, लेआउट्स, मास्टर, नोट्स/हैंडआउट्स) पर HeaderFooter मैनेजर्स का उपयोग करके इन प्लेसहोल्डर को ऑन या ऑफ करें और उनकी सामग्री सेट करें।