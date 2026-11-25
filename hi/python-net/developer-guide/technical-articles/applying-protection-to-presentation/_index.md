---
title: Python में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 70
url: /hi/python-net/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PPTX प्रस्तुतियों में आकार को लॉक और अनलॉक करने का तरीका जानें, जिससे चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Python via .NET का एक आम उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को सुरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोज़ेशेज़, तालिकाएं, OLE ऑब्जेक्ट्स, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और प्रस्तुति बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटकों से बनी होती है। Aspose.Slides for Python via .NET में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प उजागर करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) क्लास आकार लॉक के लिए बेस क्लास है। Aspose.Slides for Python via .NET निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ऑटोज़ेशेज़ को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) पिक्चर फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) के भीतर लॉक लागू करने के लिए, उसकी स्लाइड्स पर क्रमवार जाएँ और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

अनुकूल प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तरीय लेखन संरक्षण अलग-अलग [प्रस्तुति संरक्षण सेटिंग्स](/slides/hi/python-net/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for Python via .NET स्लाइड पर आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में ऑटोज़ेशेज़ के लिए [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/) , [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) , और [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) को `True` सेट किया गया है, साथ ही समूह आकार, कनेक्टर और पिक्चर फ्रेम के लिए समान लॉक लागू किए गए हैं। कनेक्टर गति के लिए [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) का उपयोग करते हैं; समूहों के लिए भी समूह बनाने को प्रतिबंधित करने हेतु [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) का प्रयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के shape संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के साथ एक प्रति सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के अंदर के चाइल्ड आकारों तक नहीं जाता।

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **सुरक्षा हटाना**

एक आकार लॉक को हटाने के लिए, उसके मान को `False` सेट करें। निम्नलिखित उदाहरण आकार लॉक के साथ एक प्रस्तुति लोड करता है और [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) , [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) , [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) , और [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) के माध्यम से चयन, गति, तथा आकार बदलने की प्रतिबंधों को साफ़ करता है। यह [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) को भी साफ़ करता है और प्रस्तुति की एक प्रति सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **चित्र क्रॉप को संरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नाम की फोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर पिक्चर फ्रेम पर [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) सेट करता है। यह फ़्लैग आगे के क्रॉप को प्रतिबंधित करता है और मौजूदा क्रॉप को संरक्षित रखता है।

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` क्रॉप लॉक को `True` के रूप में सहेजता है। PowerPoint में, जब फोटो चयनित होता है तो **Crop** कमांड निष्क्रिय हो जाता है।

### **डायग्राम को समूहित रखें**

उदाहरण आयत और तीर को समूहित करता है, फिर समूह पर स्वयं [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) सेट करता है ताकि डायग्राम के घटक साथ रहें। समूह को स्थानांतरित करने या किसी घटक का भराव बदलने जैसी अन्य संपादन उपलब्ध रहती हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `True` के रूप में सहेजता है। PowerPoint में, जब पूरा डायग्राम चयनित हो तो **Ungroup** कमांड निष्क्रिय हो जाता है।

### **मौजूदा आकार लॉक की रिपोर्ट**

एक टेम्पलेट की समीक्षा करने के लिए, उसे खोलें और प्रत्येक आकार के लिए लॉक ऑब्जेक्ट पढ़ें। [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) `True` होता है जब उस ऑब्जेक्ट पर सभी फ़्लैग बंद होते हैं और `False` जब कम से कम एक फ़्लैग सक्षम हो। समूह और उसके चाइल्ड्स के पास अलग-अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह में लॉक न होने पर भी चाइल्ड्स की जाँच करें।

यह उदाहरण ऑटोज़ेशेज़, पिक्चर फ्रेम और समूहों की गति, चित्रों की क्रॉपिंग, तथा समूहों की अनग्रुपिंग की जाँच करता है। यह उन फ़्लैग की रिपोर्ट करता है जिन्हें यह पहचानता है और उन आकार प्रकारों को चिन्हित करता है जिन्हें यह निरीक्षण नहीं करता।

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसमें अनग्रुपिंग लॉक है, उसके भीतर `Photo` नाम की एक तस्वीर है जिसमें क्रॉपिंग लॉक है, और `Free` नाम का एक अनलॉक्ड आयत है। रिपोर्ट `Free` को छोड़ देती है और ये दो पंक्तियाँ प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

रिपोर्ट संग्रहीत आकार-स्तर के संपादन फ़्लैग को पढ़ती है बिना उन्हें बदले या प्रस्तुति सहेजे। दस्तावेज़-स्तरीय लेखन संरक्षण एक अलग सेटिंग है, और प्रत्येक फ़्लैग का पालन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for Python via .NET आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स के बीच समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाने की आवश्यकता हो तो उनके मान को `False` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। लॉक केवल चयनित स्लाइड्स के आकारों पर लागू करें। इससे अन्य स्लाइड्स पर लॉक सेटिंग्स नहीं बदलती।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [आकार](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) संग्रह में क्रमवार जाएँ और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह प्रक्रिया दोहराएँ, रिपोर्टिंग उदाहरण में उपयोग किए गए ट्रैवर्सल का पालन करते हुए।