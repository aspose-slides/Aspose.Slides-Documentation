---
title: Python में आकार लॉक के साथ प्रस्तुति संपादन प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 60
url: /hi/python-java/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से बचाएँ
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Python via Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को बनाने, अपडेट करने और सहेजने के लिए एक स्वचालित वर्कफ़्लो के भाग के रूप में है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री संरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशेष संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड विभिन्न घटकों जैसे ऑटोशेप्स, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्वों से बना होता है जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Python via Java में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रस्तुत करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) क्लास आकार लॉक की बेस क्लास है। Aspose.Slides for Python via Java निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ऑटॉशेप्स को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

अनुकूल प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग-अलग [प्रेज़ेंटेशन सुरक्षा सेटिंग्स](/slides/hi/python-java/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Python via Java स्लाइड पर आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में ऑटॉशेप्स के लिए `True` के साथ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, समूह आकार, कनेक्टर, और चित्र फ्रेम के लिए समकक्ष लॉक के साथ। कनेक्टर्स गति के लिए [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जांच करता है, और इन प्रतिबंधों के लागू होने के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर के चाइल्ड आकारों को नहीं पार करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सुरक्षा हटाएँ**

एक आकार लॉक हटाने के लिए, उसका मान `False` सेट करें। निम्न उदाहरण आकार लॉक वाली एक प्रस्तुति लोड करता है और [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) के माध्यम से चयन, गति, और आकार बदलने के प्रतिबंध को साफ़ करता है। यह [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) को `False` पास करके समूह बनाने के प्रतिबंध को भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चित्र क्रॉप को संरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नामक एक फोटो रखें। उदाहरण बाईं ओर से 12% और दाईं ओर से 8% क्रॉप करता है, फिर [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) को `True` के साथ कॉल करता है ताकि क्रॉप संरक्षित रहे।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`PictureLocked.pptx` में, जब आप फोटो चुनते हैं तो PowerPoint **Crop** कमांड को निष्क्रिय कर देता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) को `True` के साथ कॉल करता है ताकि दोनों आकार एक साथ रहें। आप अभी भी समूह को स्थानांतरित कर सकते हैं या किसी घटक की भराव बदल सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`DiagramLocked.pptx` में, जब आप पूरी डायग्राम चुनते हैं तो PowerPoint **Ungroup** कमांड को निष्क्रिय कर देता है।

### **मौजूदा आकार लॉक की रिपोर्ट**

एक टेम्प्लेट की समीक्षा करने के लिए, उसे खोलें और प्रत्येक आकार के लिए लॉक ऑब्जेक्ट पढ़ें। [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) मेथड तब `True` लौटाता है जब उस ऑब्जेक्ट पर सभी फ़्लैग निष्क्रिय हों और `False` जब कम से कम एक सक्षम हो। एक समूह और उसके बच्चों के पास अलग-अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह में कोई लॉक न होने पर भी बच्चों की जाँच करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

यह उदाहरण ऑटॉशेप्स, चित्र फ्रेम, और समूहों के लिए गति की जाँच करता है। यह चित्रों के लिए क्रॉपिंग और समूहों के लिए अनग्रुपिंग की भी जाँच करता है। रिपोर्ट उन सक्षम फ़्लैगों को सूचीबद्ध करती है जिन्हें यह पहचानता है और उन आकार प्रकारों को चिह्नित करता है जिन्हें यह जांचता नहीं है।

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहित आकार-स्तर के संपादन फ़्लैगों को बिना बदलें या प्रस्तुति सहेजे पढ़ती है। दस्तावेज़-स्तर के लिखने की सुरक्षा एक अलग सेटिंग है, और प्रत्येक फ़्लैग का कार्यान्वयन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for Python via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स पर समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो उनके मान `False` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**  
हाँ। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**  
हाँ। केवल चयनित स्लाइड्स पर आकारों पर लॉक लागू करें। इससे अन्य स्लाइड्स की लॉक सेटिंग्स नहीं बदलती।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**  
समूह की [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा लौटाए गए संग्रह में इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह दोहराएँ, रिपोर्टिंग उदाहरण में दर्शाए गए ट्रैवर्सल का पालन करें।