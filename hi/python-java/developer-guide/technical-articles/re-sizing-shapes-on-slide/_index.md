---
title: Python द्वारा Java के माध्यम से प्रस्तुति स्लाइड पर आकृतियों का आकार बदलें
type: docs
weight: 110
url: /hi/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /hi/python-java/re-sizing-shapes-on-slide/
keywords:
- आकार बदलें आकृति
- आकृति आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument स्लाइड पर आकृतियों को आसानी से आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

जब आप प्रस्तुति के स्लाइड आकार को बदलते हैं, तो आपको उसकी आकृतियों को नई आयामों में फिट करने के लिए आकार बदलना और पुनःस्थिति निर्धारण करना पड़ सकता है। यह लेख दिखाता है कि आकृतियों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभालें।

## **आकृतियों का आकार बदलें**

प्रत्येक आकृति की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसकी क्षैतिज निर्देशांक और चौड़ाई को नए स्लाइड की चौड़ाई और मूल चौड़ाई के अनुपात से गुणा करें। उसके ऊर्ध्वाधर निर्देशांक और ऊँचाई पर समान ऊँचाई अनुपात लागू करें।

पहला उदाहरण एक प्रस्तुति लोड करता है जिसकी स्लाइड में कोई तालिका नहीं होती, स्लाइड आकार को A4 में बदलता है, और परिणाम को सहेजता है। यह [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) को [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) के साथ उपयोग करता है ताकि बाद की लूप स्केलिंग को नियंत्रित करे। अनुपात बिना इकाई के होते हैं; आकृति की स्थितियों और आयामों को पॉइंट में मापा जाता है। अलग-अलग चौड़ाई और ऊँचाई अनुपात आकृतियों को विकृत कर सकते हैं, और आकृति के आयाम बदलने से उसके फ़ॉन्ट आकार स्केल नहीं होते।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
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
तालिकाओं को अलग से संभालना आवश्यक है: तालिका की कुल चौड़ाई और ऊँचाई असाइन करने के बजाय उनके कॉलम की चौड़ाई और पंक्तियों की ऊँचाई को स्केल करें। यदि सेल की सामग्री को अधिक स्थान की आवश्यकता हो तो पंक्ति की ऊँचाई अनुरोधित से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट के साथ-साथ व्यक्तिगत स्लाइड पर भी प्रोसेस करता है, फिर आकार बदली प्रस्तुति को सहेजता है। इसका सहायक प्रत्येक [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) को कॉलम की चौड़ाई को [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) और न्यूनतम पंक्ति ऊँचाई को [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) से स्केल करके संभालता है। इसके बाद यह तालिका की स्थिति को उसके कुल आयामों को अलग से स्केल किए बिना स्केल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # टेबल के आयाम कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों द्वारा नियंत्रित होते हैं।
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
    # स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # मास्टर और लेआउट पर परिभाषित आकृतियों के साथ-साथ व्यक्तिगत स्लाइडों की भी आकार बदलें।
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

**स्लाइड का आकार बदलने के बाद आकृतियों क्यों विकृत या कट जाती हैं?**

यदि आप स्लाइड आकार बदलते हैं लेकिन आकृतियों को स्केल नहीं करते, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड के बाहर भी जा सकती हैं। चौड़ाई और ऊँचाई को अलग-अलग अनुपात से स्केल करने से भी आकृतियां विकृत हो सकती हैं।

**क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?**

पहला उदाहरण आकृति की सीमाओं को सीधे बदलता है और यह उन स्लाइडों के लिए है जिनमें तालिकाएँ नहीं होतीं। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामी लेआउट, विशेष रूप से पाठ और तालिकाओं, को जाँचें, क्योंकि इन उदाहरणों में फ़ॉन्ट आकार स्केल नहीं होते और तालिका की सामग्री पंक्ति की ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय तालिकाओं का आकार कैसे बदलूँ?**

चौड़ाई अनुपात के अनुसार कॉलम की चौड़ाई और ऊँचाई अनुपात के अनुसार न्यूनतम पंक्ति ऊँचाई को स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड और लेआउट स्लाइड दोनों पर काम करेगा?**

हाँ। दूसरा उदाहरण [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) और प्रत्येक मास्टर की [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) के माध्यम से इटरेट करता है और उनकी आकृतियों पर समान आकार बदलने की तर्क लागू करता है।

**क्या मैं स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) को आकार बदलने के साथ बदल सकता हूँ?**

हाँ। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) को कॉल करें, ताकि स्केल फ़ैक्टर अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार सेट करने की कोई सीमा है?**

आप [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) के साथ कस्टम स्लाइड माप निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति के फ़ॉर्मेट और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**मैं स्थिर अनुपात वाली आकृतियों को विकृत होने से कैसे रोक सकता हूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल फ़ैक्टर उपयोग करें। मूल लेआउट को नए स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा मान उपयोग करें। यह अनुपात को बनाए रखता है लेकिन एक किनारे पर अप्रयुक्त स्थान बचा सकता है।