---
title: Python के माध्यम से Java के द्वारा प्रस्तुति स्लाइड्स पर आकार बदलें
type: docs
weight: 110
url: /hi/python-java/resizing-shapes-on-slide/
aliases:
  - /hi/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
  - आकार बदलें
  - आकार का आकार बदलें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument स्लाइड्स पर आसानी से आकार बदलें — स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादनशीलता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति के स्लाइड आकार को बदलते हैं, तो आपको नए आयामों के अनुसार आकार को पुन: आकार देना और उनकी स्थिति बदलनी भी पड़ सकती है। यह लेख दिखाता है कि आकार को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड्स, मास्टर्स और लेआउट्स में तालिकाओं को कैसे संभालें।

## **आकार बदलें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को संरक्षित करने के लिए, उसके क्षैतिज निर्देशांक और चौड़ाई को नई स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। समान अनुपात को ऊँचाई के लिए उसके लंबवत निर्देशांक और ऊँचाई पर लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसकी स्लाइड्स में कोई तालिका नहीं है, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद के लूप द्वारा स्केलिंग को नियंत्रित किया जा सके। अनुपात इकाईहीन होते हैं; आकार की स्थितियों और आयामों को पॉइंट्स में मापा जाता है। विभिन्न चौड़ाई और ऊँचाई के अनुपात आकार को विकृत कर सकते हैं, और आकार के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर की गणना करें।
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
तालिकाओं को अलग तरीके से संभालना आवश्यक है: तालिका की कुल चौड़ाई और ऊँचाई निर्धारित करने के बजाय उनके कॉलम की चौड़ाई और पंक्तियों की ऊँचाई को स्केल करें। यदि कोशिका की सामग्री को अधिक स्थान चाहिए तो पंक्तियों की ऊँचाई अनुरोधित से अधिक रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकार बदलने से पहले मास्टर और लेआउट की स्लाइड्स तथा व्यक्तिगत स्लाइड्स में आकारों को प्रोसेस करता है। इसका हेल्पर प्रत्येक [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) को कॉलम की चौड़ाई को [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) और न्यूनतम पंक्ति ऊँचाई को [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) से स्केल करके संभालता है। फिर यह तालिका की स्थिति को उसके कुल आयामों को अलग से स्केल किए बिना स्केल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # तालिका के आयाम कॉलम की चौड़ाई और पंक्ति की ऊँचाई द्वारा नियंत्रित होते हैं।
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल फैक्टर की गणना करें।
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # मास्टर और लेआउट तथा व्यक्तिगत स्लाइड्स पर परिभाषित आकार को पुनः आकार दें।
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकार क्यों विकृत या कटे हुए दिखते हैं?**

यदि आप स्लाइड का आकार बदलते हैं बिना आकारों को स्केल किए, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड से बाहर निकल सकते हैं। चौड़ाई और ऊँचाई को विभिन्न अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए काम करता है?**

पहला उदाहरण आकार की सीमाएँ सीधे बदलता है और बिना तालिकाओं वाली स्लाइड्स के लिए है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेषकर पाठ और तालिकाएँ, को जाँचें, क्योंकि ये उदाहरण फ़ॉन्ट आकार नहीं स्केल करते हैं और तालिका की सामग्री पंक्तियों की ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं को कैसे पुन: आकार दूँ?**

कॉलम की चौड़ाई को चौड़ाई के अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई के अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगा?**

हाँ। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) और प्रत्येक मास्टर की [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) के माध्यम से इटररेट करता है और उनके आकारों पर वही आकार बदलने की लॉजिक लागू करता है।

**क्या मैं आकार बदलते समय स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) बदल सकता हूँ?**

हाँ। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) को कॉल करें, zodat स्केल फैक्टर्स अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार में कोई सीमा है जिसे मैं सेट कर सकता हूँ?**

आप [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) के साथ कस्टम स्लाइड आयाम निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाले आकारों को विकृत होने से कैसे रोकूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर उपयोग करें। मूल लेआउट को नए स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई में से छोटे अनुपात को उपयोग करें। इससे अनुपात बना रहता है लेकिन एक किनारे पर अप्रयुक्त स्थान रह सकता है।