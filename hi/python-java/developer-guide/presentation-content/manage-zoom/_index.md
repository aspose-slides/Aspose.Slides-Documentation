---
title: Python के माध्यम से Java में प्रस्तुति ज़ूम प्रबंधन
linktitle: ज़ूम प्रबंधन
type: docs
weight: 60
url: /hi/python-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ़्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- पावरपॉइंट
- प्रस्तुति
- पाइथन
- जावा
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ ज़ूम बनाएं और अनुकूलित करें — स्लाइड, PPT, PPTX और ODP प्रस्तुतियों में सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति के विशिष्ट स्लाइड, सेक्शन और हिस्सों के बीच कूदने की सुविधा देता है। जब आप प्रस्तुति दे रहे होते हैं, तो सामग्री में तेज़ी से नेविगेट करने की यह क्षमता बहुत उपयोगी साबित हो सकती है।

![overview_image](overview.png)

* संपूर्ण प्रस्तुति को एक ही स्लाइड पर सारांशित करने के लिए, एक [सारांश ज़ूम](#summary-zoom) का उपयोग करें।
* केवल चयनित स्लाइड दिखाने के लिए, एक [स्लाइड ज़ूम](#slide-zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [सेक्शन ज़ूम](#section-zoom) का उपयोग करें।

## **स्लाइड ज़ूम**
एक स्लाइड ज़ूम आपकी प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप किसी भी क्रम में स्लाइड के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए बहुत उपयुक्त होते हैं जिनमें अधिक सेक्शन नहीं होते, लेकिन आप इन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के भागों में गहराई से प्रवेश करने में मदद करते हैं जबकि आप ऐसा महसूस करते हैं कि आप एक ही कैनवास पर हैं।

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम वस्तुओं के लिए, Aspose.Slides प्रदान करता है [ZoomImageType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomimagetype/) एन्यूमरेशन, [ZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) क्लास में कुछ मेथड्स।

### **ज़ूम फ्रेम बनाएं**

आप स्लाइड पर ज़ूम फ्रेम इस तरह जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिन्हें आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
3. बनाए गए स्लाइड में पहचानने योग्य टेक्स्ट और बैकग्राउंड जोड़ें।
4. पहले स्लाइड में ज़ूम फ्रेम (बनाए गए स्लाइड के रेफ़रेंस सहित) जोड़ें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # नई स्लाइड्स को प्रस्तुति में जोड़ता है
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # ZoomFrame ऑब्जेक्ट जोड़ता है
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**
Aspose.Slides for Python via Java के साथ, आप अलग स्लाइड प्रीव्यू इमेज के साथ ज़ूम फ्रेम इस तरह बना सकते हैं:
1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
3. स्लाइड में पहचानने योग्य टेक्स्ट और बैकग्राउंड जोड़ें।
4. एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, इसे उस इमेज को जोड़कर जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट की इमेज कलेक्शन में है, जो फ्रेम को भरने के लिए उपयोग होगी।
5. पहले स्लाइड में ज़ूम फ्रेम (बनाए गए स्लाइड के रेफ़रेंस सहित) जोड़ें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि अलग इमेज के साथ ज़ूम फ्रेम कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Adds a new slide to the presentation
    # प्रस्तुति में नई स्लाइड जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Creates a background for the second slide
    #  दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Creates a text box for the second slide
    #  दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Creates a new image for the zoom object
    #  ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Adds the ZoomFrame object
    # ZoomFrame ऑब्जेक्ट जोड़ता है
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Saves the presentation
    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **ज़ूम फ्रेम का स्वरूप बदलें**
पिछले हिस्सों में हमने सरल ज़ूम फ्रेम बनाने का तरीका दिखाया था। अधिक जटिल ज़ूम फ्रेम बनाने के लिए आपको सरल फ्रेम के स्वरूप को बदलना होगा। ज़ूम फ्रेम पर लागू करने के लिए कई स्वरूप विकल्प उपलब्ध हैं।

आप स्लाइड पर ज़ूम फ्रेम के स्वरूप को इस तरह नियंत्रित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिन्हें आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
3. बनाए गए स्लाइड में पहचानने योग्य टेक्स्ट और बैकग्राउंड जोड़ें।
4. पहले स्लाइड में ज़ूम फ्रेम (बनाए गए स्लाइड के रेफ़रेंस सहित) जोड़ें।
5. एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, इसे उस इमेज को जोड़कर जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट की इमेज कलेक्शन में है, जो फ्रेम को भरने के लिए उपयोग होगी।
6. पहले ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7. दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन स्वरूप बदलें।
8. दूसरे ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएं।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम के स्वरूप को कैसे बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Adds new slides to the presentation
    # प्रस्तुति में नई स्लाइड्स जोड़ता है
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Creates a background for the second slide
    #  दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Creates a text box for the second slide
    #  दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Creates a background for the third slide
    #  तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Creates a text box for the third slide
    #  तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Adds ZoomFrame objects
    # ZoomFrame ऑब्जेक्ट जोड़ता है
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Creates a new image for the zoom object
    #  ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Sets custom image for first_zoom_frame object
    #  first_zoom_frame ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
    first_zoom_frame.setZoomImage(picture)

    #  Sets a zoom frame format for the second_zoom_frame object
    #  second_zoom_frame ऑब्जेक्ट के लिए ज़ूम फ्रेम स्वरूप सेट करता है
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Setting for Do not show background for second_zoom_frame object
    #  second_zoom_frame ऑब्जेक्ट के लिए पृष्ठभूमि न दिखाने की सेटिंग
    second_zoom_frame.setShowBackground(False)

    #  Saves the presentation
    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सेक्शन ज़ूम**

सेक्शन ज़ूम आपका प्रस्तुति में किसी सेक्शन से लिंक करता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शन पर वापस जाने के लिए कर सकते हैं जिन्हें आप वास्तव में जोर देना चाहते हैं। या आप इसका उपयोग यह दिखाने के लिए कर सकते हैं कि आपकी प्रस्तुति के विभिन्न भाग कैसे जुड़ते हैं।

![overview_image](seczoomsel.png)

सेक्शन ज़ूम वस्तुओं के लिए, Aspose.Slides प्रदान करता है [SectionZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) क्लास में कुछ मेथड्स।

### **सेक्शन ज़ूम फ्रेम बनाएं**

आप स्लाइड पर सेक्शन ज़ूम फ्रेम इस तरह जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं।
3. बनाई गई स्लाइड में एक विशेष बैकग्राउंड जोड़ें।
4. नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
5. पहले स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # प्रस्तुति में नई स्लाइड जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame ऑब्जेक्ट जोड़ता है
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

Aspose.Slides for Python via Java के साथ, आप अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम इस तरह बना सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं।
3. बनाई गई स्लाइड में एक विशेष बैकग्राउंड जोड़ें।
4. नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
5. एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, इसे उस इमेज को जोड़कर जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट की इमेज कलेक्शन में है, जो फ्रेम को भरने के लिए उपयोग होगी।
6. पहले स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि अलग इमेज के साथ सेक्शन ज़ूम फ्रेम कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # प्रस्तुति में नई स्लाइड जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    #  ज़ूम ऑब्जेक्ट के लिए नई छवि बनाता है
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  SectionZoomFrame ऑब्जेक्ट जोड़ता है
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **सेक्शन ज़ूम फ्रेम का स्वरूप बदलें**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए आपको सरल फ्रेम के स्वरूप को बदलना होगा। सेक्शन ज़ूम फ्रेम पर लागू करने के लिए कई स्वरूप विकल्प उपलब्ध हैं।

आप स्लाइड पर सेक्शन ज़ूम फ्रेम के स्वरूप को इस तरह नियंत्रित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं।
3. बनाई गई स्लाइड में एक विशेष बैकग्राउंड जोड़ें।
4. नया सेक्शन बनाएं जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं।
5. पहले स्लाइड में सेक्शन ज़ूम फ्रेम (बनाए गए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6. बनाए गए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7. एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, इसे उस इमेज को जोड़कर जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट की इमेज कलेक्शन में है, जो फ्रेम को भरने के लिए उपयोग होगी।
8. बनाए गए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9. *लिंक किए गए सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें।
10. सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से बैकग्राउंड हटाएं।
11. सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन स्वरूप बदलें।
12. ट्रांज़िशन अवधि बदलें।
13. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि सेक्शन ज़ूम फ्रेम के स्वरूप को कैसे बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # प्रस्तुति में नई स्लाइड जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    #  SectionZoomFrame ऑब्जेक्ट जोड़ता है
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  SectionZoomFrame के लिए स्वरूपण
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज जैसा है जहाँ आपकी प्रस्तुति के सभी भाग एक साथ दिखाए जाते हैं। जब आप प्रस्तुति दे रहे होते हैं, तो आप ज़ूम का उपयोग करके अपनी प्रस्तुति के किसी भी हिस्से से किसी भी क्रम में दूसरे हिस्से पर जा सकते हैं। आप रचनात्मक हो सकते हैं, आगे कूद सकते हैं, या स्लाइड शो के भागों को फिर से देख सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए।

![overview_image](sumzoomsel.png)

सारांश ज़ूम वस्तुओं के लिए, Aspose.Slides प्रदान करता है [SummaryZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsectioncollection/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/) क्लास में कुछ मेथड्स।

### **सारांश ज़ूम बनाएं**

आप स्लाइड पर सारांश ज़ूम फ्रेम इस तरह जोड़ सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिनमें विशेष बैकग्राउंड और नई सेक्शन हों।
3. पहले स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि स्लाइड पर सारांश ज़ूम फ्रेम कैसे बनाएं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # प्रस्तुति में नई स्लाइड जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adds a new section to the presentation
    presentation.getSections().addSection("Section 2", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adds a new section to the presentation
    presentation.getSections().addSection("Section 3", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adds a new section to the presentation
    presentation.getSections().addSection("Section 4", slide)

    #  Adds a SummaryZoomFrame object
    #  SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Saves the presentation
    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएं**

सारांश ज़ूम फ्रेम में सभी सेक्शन [SummaryZoomSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsection/) ऑब्जेक्ट द्वारा दर्शाए जाते हैं, जो [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsectioncollection/) ऑब्जेक्ट में संग्रहित होते हैं। आप [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsectioncollection/) क्लास के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को जोड़ या हटा सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिनमें विशेष बैकग्राउंड और नई सेक्शन हों।
3. पहले स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. प्रस्तुति में एक नई स्लाइड और सेक्शन जोड़ें।
5. बनाये गये सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6. सारांश ज़ूम फ्रेम से पहली सेक्शन हटाएं।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि सारांश ज़ूम फ्रेम में सेक्शन कैसे जोड़ें और हटाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # नई स्लाइड को प्रस्तुति में जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    # नई स्लाइड को प्रस्तुति में जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # नई स्लाइड को प्रस्तुति में जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Summary Zoom में एक सेक्शन जोड़ता है
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Summary Zoom से सेक्शन हटाता है
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सारांश ज़ूम सेक्शन का स्वरूप बदलें**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए आपको सरल फ्रेम के स्वरूप को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर लागू करने के लिए कई स्वरूप विकल्प उपलब्ध हैं।

आप सारांश ज़ूम फ्रेम में सारांश ज़ूम सेक्शन ऑब्जेक्ट के स्वरूप को इस तरह नियंत्रित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. नई स्लाइड बनाएं जिनमें विशेष बैकग्राउंड और नई सेक्शन हों।
3. पहले स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4. [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/summaryzoomsectioncollection/) से पहली सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
5. एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं, इसे उस इमेज को जोड़कर जो [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट की इमेज कलेक्शन में है, जो फ्रेम को भरने के लिए उपयोग होगी।
6. सारांश ज़ूम सेक्शन ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7. *लिंक किए गए सेक्शन से मूल स्लाइड पर लौटने* की क्षमता सेट करें।
8. सारांश ज़ूम सेक्शन ऑब्जेक्ट के लिए लाइन स्वरूप बदलें।
9. ट्रांज़िशन अवधि बदलें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि सारांश ज़ूम सेक्शन ऑब्जेक्ट के स्वरूप को कैसे बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # नई स्लाइड को प्रस्तुति में जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में नया सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 1", slide)

    # नई स्लाइड को प्रस्तुति में जोड़ता है
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  प्रस्तुति में दूसरा सेक्शन जोड़ता है
    presentation.getSections().addSection("Section 2", slide)

    #  SummaryZoomFrame ऑब्जेक्ट जोड़ता है
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  पहला SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  SummaryZoomSection ऑब्जेक्ट के लिए स्वरूपण
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  प्रस्तुति को सहेजता है
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हाँ। [ZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomframe/) या [SectionZoomFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sectionzoomframe/) [setReturnToParent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomobject/#setReturnToParent) के माध्यम से मूल स्लाइड पर लौटने का समर्थन करता है, जो सक्षम होने पर दर्शकों को लक्ष्य सामग्री देखने के बाद वापस भेजता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ज़ूम [setTransitionDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zoomobject/#setTransitionDuration) के साथ ट्रांज़िशन अवधि सेट करने का समर्थन करता है, जिससे आप कूद एनीमेशन की अवधि को नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट की संख्या पर कोई सीमा है?**

दस्तावेज़ में कोई कठोर API सीमा नहीं बताई गई है। व्यावहारिक सीमाएँ कुल प्रस्तुति की जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय पर ध्यान दें।