---
title: Python via Java में प्रस्तुति स्लाइड्स पर आकृतियों को रिसाइज़ करें
type: docs
weight: 110
url: /hi/python-java/re-sizing-shapes-on-slide/
keywords:
- आकृति रिसाइज़
- आकृति आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आकृतियों को आसान‑से‑रिसाइज़ करें—स्लाइड लेआउट समायोजनों को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **समीक्षा**

Aspose.Slides for Python via Java ग्राहकों के सबसे सामान्य प्रश्नों में से एक है कि स्लाइड आकार बदलने पर आकृतियों को कैसे रिसाइज़ किया जाए ताकि डेटा कट न हो। यह छोटा तकनीकी लेख दिखाता है कि यह कैसे किया जाए।

## **आकृतियों को रिसाइज़ करें**

स्लाइड आकार बदलने पर आकृतियों के विसंरेखित होने से बचने के लिए, प्रत्येक आकृति की स्थिति और आयामों को अपडेट करें ताकि वे नए स्लाइड लेआउट के अनुरूप हों।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# प्रस्तुति फ़ाइल लोड करें।
presentation = Presentation("sample.ppt")
try:
    # मूल स्लाइड आकार प्राप्त करें।
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # नया स्लाइड आकार प्राप्त करें।
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # प्रत्येक स्लाइड पर आकृतियों का आकार बदलें और पुनः स्थित करें।
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

टेबल्स को कोई विशेष उपचार नहीं चाहिए: टेबल की चौड़ाई और ऊँचाई सेट करने से उसके कॉलम और पंक्तियाँ अनुपातिक रूप से रिसाइज़ हो जाती हैं, इसलिए पंक्तियों की ऊँचाई और कॉलम की चौड़ाई को फिर से स्केल करने से अनुपात दो बार लागू हो जाएगा।

{{% /alert %}} 

उपरोक्त कोड केवल स्लाइड्स पर मौजूद आकृतियों को बदलता है। मास्टर स्लाइड्स और लेआउट स्लाइड्स अपनी स्वयं की आकृतियों को रखती हैं, इसलिए यदि आप पूरी प्रस्तुति को नए स्लाइड आकार के अनुसार बनाना चाहते हैं तो उन्हें भी स्केल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # मूल स्लाइड आकार प्राप्त करें।
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # मौजूदा आकृतियों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # नया स्लाइड आकार प्राप्त करें।
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # आकृति का आकार स्केल करें।
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # आकृति की स्थिति स्केल करें।
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # आकृति का आकार स्केल करें।
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # आकृति की स्थिति स्केल करें।
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड रिसाइज़ करने के बाद आकृतियाँ विकृत या कट क्यों जाती हैं?**

स्लाइड को रिसाइज़ करने पर, जब तक स्केल स्पष्ट रूप से नहीं बदला जाता, आकृतियों की मूल स्थिति और आकार बना रहता है। इससे सामग्री कट सकती है या आकृतियाँ विसंरेखित हो सकती हैं।

**क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?**

हां। ऊँचाई और चौड़ाई सेट करना टेक्स्ट बॉक्स, इमेज, चार्ट और टेबल सभी के लिए समान रूप से काम करता है।

**स्लाइड रिसाइज़ करने पर टेबल्स को कैसे रिसाइज़ करें?**

टेबल आकृति को अन्य किसी आकृति की तरह स्केल करें। उसकी पंक्तियाँ और कॉलम अनुपातिक रूप से अनुसरित करेंगे, इसलिए बाद में उन्हें फिर से स्केल न करें।

**क्या यह रिसाइज़िंग मास्टर स्लाइड्स और लेआउट स्लाइड्स पर भी लागू होगी?**

हां, लेकिन आपको [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) और [Presentation.getLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getLayoutSlides) के माध्यम से लूप करके उनकी आकृतियों पर भी वही स्केलिंग लॉजिक लागू करना चाहिए ताकि पूरी प्रस्तुति में एकरूपता बनी रहे।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को रिसाइज़िंग के साथ बदल सकता हूँ?**

हां। आप [SlideSize.setOrientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#setOrientation) का उपयोग करके अभिविन्यास बदल सकते हैं। लेआउट को सुरक्षित रखने के लिए स्केलिंग लॉजिक को उसी अनुसार सेट करें।

**क्या स्लाइड आकार सेट करने की कोई सीमा है?**

Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों के साथ संगतता को प्रभावित कर सकते हैं।

**मैं फिक्स्ड आस्पेक्ट रेशियो वाली आकृतियों को विकृत होने से कैसे बचा सकता हूँ?**

आप स्केल करने से पहले आकृति लॉक की [getAspectRatioLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) विधि जांच सकते हैं। यदि यह लॉक है, तो चौड़ाई या ऊँचाई को व्यक्तिगत रूप से स्केल करने की बजाय अनुपातिक रूप से समायोजित करें।