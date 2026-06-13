---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/python-net/examples/elements/layout-slide/
keywords:
- लेआउट स्लाइड
- लेआउट स्लाइड जोड़ें
- लेआउट स्लाइड एक्सेस करें
- लेआउट स्लाइड हटाएँ
- अप्रयुक्त लेआउट स्लाइड
- लेआउट स्लाइड क्लोन करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ लेआउट स्लाइड्स को प्रबंधित करने के लिए Python का उपयोग करें: PPT, PPTX और ODP के प्रस्तुतियों में प्लेसहोल्डर और थीम को बनाने, लागू करने, क्लोन करने, नाम बदलने और अनुकूलित करने के लिए।"
---
यह लेख Aspose.Slides for Python via .NET में **Layout Slides** के साथ कैसे काम किया जाए, दर्शाता है। एक लेआउट स्लाइड सामान्य स्लाइड्स द्वारा विरासत में मिले डिज़ाइन और फ़ॉर्मेटिंग को परिभाषित करती है। आप लेआउट स्लाइड्स को जोड़, एक्सेस, क्लोन और हटाया कर सकते हैं, साथ ही प्रस्तुति का आकार कम करने के लिए अप्रयुक्त स्लाइड्स को साफ़ भी कर सकते हैं।

## **लेआउट स्लाइड जोड़ें**

आप पुन: उपयोग योग्य फ़ॉर्मेटिंग को परिभाषित करने के लिए एक कस्टम लेआउट स्लाइड बना सकते हैं।

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # निर्दिष्ट प्रकार और नाम के साथ एक लेआउट स्लाइड बनाएं।
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** लेआउट स्लाइड्स व्यक्तिगत स्लाइड्स के टेम्पलेट के रूप में कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित कर कई स्लाइड्स में पुन: उपयोग कर सकते हैं।

> 💡 **Tip 2:** जब आप लेआउट स्लाइड में आकार या टेक्स्ट जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइड्स स्वचालित रूप से इस साझा सामग्री को प्रदर्शित करेंगे।  
> नीचे का स्क्रीनशॉट दो स्लाइड्स दिखाता है, प्रत्येक एक ही लेआउट स्लाइड से टेक्स्ट बॉक्स विरासत में लेती है।

![लेआउट सामग्री को विरासत में लेने वाली स्लाइड्स](layout-slide-result.png)


## **लेआउट स्लाइड एक्सेस करें**

लेआउट स्लाइड्स को इंडेक्स या लेआउट प्रकार (जैसे `Blank`, `Title`, `SectionHeader`, आदि) द्वारा एक्सेस किया जा सकता है।

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # इंडेक्स द्वारा एक्सेस करें।
        first_layout_slide = presentation.layout_slides[0]

        # लेआउट प्रकार द्वारा एक्सेस करें।
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **लेआउट स्लाइड हटाएँ**

यदि कोई लेआउट स्लाइड अब आवश्यक नहीं है, तो आप उसे हटा सकते हैं।

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और हटाएँ।
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

प्रस्तुति का आकार कम करने के लिए, आप उन लेआउट स्लाइड्स को हटाना चाह सकते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की जातीं।

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # स्वचालित रूप से सभी लेआउट स्लाइड्स को हटाता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **लेआउट स्लाइड क्लोन करें**

`AddClone` मेथड का उपयोग करके आप लेआउट स्लाइड को डुप्लिकेट कर सकते हैं।

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें।
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # लेआउट स्लाइड संग्रह के अंत में लेआउट स्लाइड को क्लोन करें।
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Summary:** लेआउट स्लाइड्स स्लाइड्स में निरंतर फ़ॉर्मेटिंग प्रबंधन के लिए शक्तिशाली उपकरण हैं। Aspose.Slides लेआउट स्लाइड्स को बनाने, प्रबंधित करने और अनुकूलित करने पर पूर्ण नियंत्रण प्रदान करता है।