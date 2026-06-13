---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/python-net/examples/elements/text-box/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट बॉक्स जोड़ें
- टेक्स्ट बॉक्स एक्सेस करें
- टेक्स्ट बॉक्स हटाएं
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में टेक्स्ट बॉक्स बनाएं और फ़ॉर्मेट करें: फ़ॉन्ट, संरेखण, रैपिंग, ऑटोफ़िट सेट करें, तथा PowerPoint और OpenDocument के लिए स्लाइड्स को बेहतर बनाने के लिंक जोड़ें।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** `AutoShape` द्वारा दर्शाया जाता है। लगभग हर आकृति में टेक्स्ट हो सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई भराव या सीमा नहीं होती और यह केवल टेक्स्ट प्रदर्शित करता है।

यह गाइड प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को जोड़ने, एक्सेस करने और हटाने के तरीकों को समझाता है।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स सिर्फ एक `AutoShape` है जिसमें कोई भराव या सीमा नहीं होती और कुछ स्वरूपित टेक्स्ट होता है। इसे बनाने का तरीका इस प्रकार है:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # एक आयताकार आकार बनाएं (डिफ़ॉल्ट रूप से बॉर्डर के साथ भरा हुआ और कोई टेक्स्ट नहीं)।
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # भरण और बॉर्डर हटाएँ ताकि यह सामान्य टेक्स्ट बॉक्स जैसा दिखे।
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # टेक्स्ट फ़ॉर्मेटिंग सेट करें।
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # वास्तविक टेक्स्ट सामग्री असाइन करें।
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **ध्यान दें:** कोई भी `AutoShape` जिसमें खाली नहीं हुआ `TextFrame` हो, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री द्वारा टेक्स्ट बॉक्स एक्सेस करें**

किसी विशेष कीवर्ड (जैसे "Slide") को शामिल करने वाले सभी टेक्स्ट बॉक्स खोजने के लिए, आकृतियों के माध्यम से इटररेट करें और उनके टेक्स्ट की जाँच करें:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # केवल AutoShapes संपादनीय टेक्स्ट रख सकते हैं।
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # मिलते हुए टेक्स्ट बॉक्स के साथ कुछ करें।
                    pass
```

## **सामग्री द्वारा टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहले स्लाइड पर उन सभी टेक्स्ट बॉक्स को खोजता और हटाता है जो किसी विशेष कीवर्ड को शामिल करते हैं:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # हटाने के लिए आकार खोजें जो AutoShapes हैं और शब्द "Slide" शामिल करते हैं।
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # स्लाइड से प्रत्येक मिलते हुए आकार हटाएँ।
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **टिप:** इटररेशन के दौरान संशोधित करने से पहले हमेशा शेप कलेक्शन की एक कॉपी बनाएं ताकि कलेक्शन मॉडिफिकेशन त्रुटियों से बचा जा सके।