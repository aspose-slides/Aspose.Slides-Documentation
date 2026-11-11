---
title: Python via Java में प्रस्तुति ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/python-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- पॉवरपॉइंट
- प्रस्तुति
- पायथन
- जावा
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ ज़ूम बनाएं और कस्टमाइज़ करें — सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन PowerPoint प्रस्तुतियों में जोड़ें।"
---
## **परिचय**

PowerPoint ज़ूम आपको स्लाइड शो के दौरान विशिष्ट स्लाइड और सेक्शन के बीच नेविगेट करने देते हैं। Aspose.Slides for Python via Java के साथ, आप स्लाइड, सेक्शन और सारांश ज़ूम बना सकते हैं और उनके प्रीव्यू, बॉर्डर और ट्रांज़िशन को कस्टमाइज़ कर सकते हैं।

![PowerPoint ज़ूम अवलोकन](overview.png)

* एक ही स्लाइड पर पूरी प्रस्तुति का सारांश बनाने के लिए, [सारांश ज़ूम](#summary-zoom) का उपयोग करें।
* केवल चयनित स्लाइड्स दिखाने के लिए, [स्लाइड ज़ूम](#slide-zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, [सेक्शन ज़ूम](#section-zoom) का उपयोग करें।

## **स्लाइड ज़ूम**

एक स्लाइड ज़ूम आपकी प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप स्लाइड्स के बीच किसी भी क्रम में स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए उपयुक्त हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप इन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको एक ही अवलोकन स्लाइड से संबंधित जानकारी को खोजने की अनुमति देते हैं।

![स्लाइड ज़ूम के लिए स्लाइड चयन](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) enumeration, [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करता है।

### **ज़ूम फ्रेम बनाएं**

एक अवलोकन स्लाइड पर व्यक्तिगत स्लाइड्स के लिंक रखने के लिए [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) का उपयोग करें। यह उदाहरण दो लक्ष्य स्लाइड्स बनाता है जिनके पृष्ठभूमि अलग-अलग होते हैं और लेबल होते हैं, फिर प्रत्येक का प्रीव्यू पहली स्लाइड में जोड़ता है और प्रस्तुति को PPTX के रूप में सहेजता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**

लक्ष्य स्लाइड के डिफ़ॉल्ट प्रीव्यू को बदलने के लिए कस्टम इमेज को [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) में पास करें। यह उदाहरण एक स्थानीय इमेज की आवश्यकता रखता है, इसे [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) से लोड करता है, और [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) का उपयोग करके प्रस्तुति में जोड़ता है। परिणामी फ्रेम उस इमेज को दिखाता है जबकि अभी भी द्वितीय स्लाइड से लिंक रहता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ज़ूम फ्रेम को फॉर्मेट करें**

यह उदाहरण दो स्लाइड ज़ूम फ्रेम को कस्टमाइज़ करता है। यह पहले फ्रेम को एक स्थानीय इमेज [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) के माध्यम से असाइन करता है, और दूसरे फ्रेम को पाँच पॉइंट, डैश-डॉट पिंक बॉर्डर [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) के माध्यम से देता है। [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) में `False` पास करने से दूसरे फ्रेम की पृष्ठभूमि छिप जाती है। कस्टम प्रीव्यू के लिए एक स्थानीय इमेज आवश्यक है; दोनों फ्रेम अपने स्लाइड टारगेट को सहेजे गए PPTX में बरकरार रखते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सेक्शन ज़ूम**

एक सेक्शन ज़ूम आपकी प्रस्तुति में एक सेक्शन से लिंक करता है। इसका उपयोग किसी टॉपिक को फिर से देखने या यह दिखाने के लिए करें कि प्रस्तुति के विभिन्न भाग कैसे जुड़े हैं।

![सेक्शन ज़ूम के लिए सेक्शन चयन](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाएं**

एक सेक्शन बनाएं [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) के साथ, फिर लौटाए गए सेक्शन को [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) में पास करें। यह उदाहरण पहली स्लाइड पर एक सेक्शन ज़ूम रखता है और इसे एक रंगीन स्लाइड से शुरू होने वाले सेक्शन से लिंक करता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट होते हैं, और प्रस्तुति को PPTX के रूप में सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

[ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) का इमेज ओवरलोड आपको गंतव्य सेक्शन बदले बिना कस्टम प्रीव्यू दिखाने देता है। यह उदाहरण एक स्थानीय इमेज की आवश्यकता रखता है, जिसे [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) से लोड किया जाता है और [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) के माध्यम से जोड़ा जाता है। सहेजी गई प्रस्तुति में पहली स्लाइड पर एक सेक्शन ज़ूम होता है जो नए बनाए गए सेक्शन से लिंक्ड है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सेक्शन ज़ूम के लक्ष्य सेक्शन को बदलें**

एक मौजूदा सेक्शन ज़ूम को बिना पुनः निर्माण किए पुनः निर्देशित करने के लिए [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) का उपयोग करें। उसी प्रस्तुति के [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) संग्रह से एक भरा हुआ सेक्शन चुनें। खाली सेक्शन असाइन करने से वर्तमान लक्ष्य अपरिवर्तित रहता है, इसलिए असाइन करने से पहले [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) जांचें। सेक्शनों के बारे में अधिक जानकारी के लिए देखें [स्लाइड सेक्शन प्रबंधन](/slides/hi/python-java/slide-section/)।

निम्न उदाहरण एक प्रस्तुति फ़ाइल लोड करता है, जिसमें कई भरे हुए सेक्शन होने चाहिए, एक मौजूदा सेक्शन ज़ूम जिसका नाम `Section navigation` है, और `Results` नाम का एक यूनिक सेक्शन। यह सभी स्लाइड्स में ज़ूम को खोजता है और लक्ष्य को नाम द्वारा ढूँढता है न कि संग्रह इंडेक्स द्वारा, जो सेक्शन पुनः क्रमबद्ध होने पर बदल सकता है। यदि नाम यूनिक नहीं हैं, तो गंतव्य को पहचानने के लिए [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सेक्शन ज़ूम फ्रेम को फॉर्मेट करें**

यह उदाहरण एक सेक्शन ज़ूम को 100 बाय 75 पॉइंट्स पर ले जाता है और उसका आकार बदलता है, [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) के माध्यम से एक स्थानीय इमेज असाइन करता है, और 2.5 पॉइंट, डैश-डॉट ब्राउन बॉर्डर लागू करता है। यह [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) को सक्षम करता है ताकि सेक्शन के बाद मूल स्लाइड पर लौट सकें, [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) को अक्षम करता है, और [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड पर सेट करता है। कस्टम प्रीव्यू के लिए एक स्थानीय इमेज आवश्यक है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सारांश ज़ूम**

एक सारांश ज़ूम प्रस्तुति के सेक्शनों का अवलोकन प्रदान करता है। स्लाइड शो के दौरान, आप इसे सेक्शन में कूदने, आगे स्किप करने, या बिना स्लाइड क्रम के टॉपिक को फिर से देखने के लिए उपयोग कर सकते हैं।

![सारांश ज़ूम के लिए सेक्शन चयन](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) क्लासेस तथा [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करता है।

### **सारांश ज़ूम बनाएं**

[ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) का उपयोग करके प्रस्तुति के सेक्शनों का एक अवलोकन बनाएं। यह उदाहरण चार सेक्शन बनाता है जिनके स्लाइड बैकग्राउंड अलग हैं और पहली स्लाइड पर एक सारांश ज़ूम जोड़ता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट होते हैं, और परिणामी अवलोकन एक PPTX प्रस्तुति में सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

एक सारांश ज़ूम अपने [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) ऑब्जेक्ट्स को [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में सहेजता है। यह उदाहरण दो सेक्शनों का एक अवलोकन बनाता है, फिर [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) का उपयोग करके तीसरा सेक्शन जोड़ता है, और [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) से पहले सेक्शन की एंट्री हटाता है। एंट्री हटाने से प्रस्तुति सेक्शन और उसकी स्लाइड्स अपरिवर्तित रहती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सारांश ज़ूम सेक्शनों को फॉर्मेट करें**

यह उदाहरण [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में पहली एंट्री को फॉर्मेट करता है, शून्य-आधारित इंडेक्स `0` का उपयोग करते हुए। यह [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) के लिए एक स्थानीय इमेज आवश्यक करता है, 1.5 पॉइंट, डैश-डॉट ब्लैक बॉर्डर लागू करता है, और [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड पर सेट करता है। [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) में `False` पास करने से इस एंट्री के लिए स्वचालित रूप से सारांश स्लाइड पर वापसी निष्क्रिय हो जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हां। लक्ष्य सामग्री दिखाने के बाद मूल स्लाइड पर लौटने के लिए `True` के साथ [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) को कॉल करें।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि को समायोजित कर सकता हूँ?**

हां। ट्रांज़िशन अवधि को सेकंड में नियंत्रित करने के लिए [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) का उपयोग करें।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ में कोई कठोर API सीमा नहीं बताई गई है। व्यावहारिक सीमाएँ पूरी प्रस्तुति की जटिलता और दर्शक की प्रदर्शन क्षमता पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय पर विचार करें।