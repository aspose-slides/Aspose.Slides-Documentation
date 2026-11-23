---
title: शैप लॉक के साथ Python में प्रस्तुति संपादन प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 60
url: /hi/python-java/applying-protection-to-presentation/
keywords:
- संपादन रोकें
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
description: "Aspose.Slides for Python via Java के साथ PPTX प्रस्तुतियों में आकार को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Python via Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को स्वचालित कार्यप्रवाह के हिस्से के रूप में बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करना इच्छित लेआउट और सामग्री को सुरक्षित रखने में मदद कर सकता है।

यह लेख समझाता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोहैश, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटकों का समूह होता है। Aspose.Slides for Python via Java में स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा प्रदर्शित किया जाता है जो [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) क्लास से विरासत में मिलता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) क्लास आकार लॉक का बेस क्लास है। Aspose.Slides for Python via Java निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ऑटोहैश को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

[PPTX प्रस्तुति](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) में लॉक लागू करने के लिए उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **संरक्षण लागू करें और हटाएँ**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन संचालन को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज‑स्तर लिखने की सुरक्षा अलग‑अलग [presentation protection settings](/slides/hi/python-java/password-protected-presentation/) होते हैं।

### **PPTX आकारों पर संरक्षण लागू करें**

Aspose.Slides for Python via Java आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण `True` के साथ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) और [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) को ऑटोहैश के लिये कॉल करता है, समूह आकार, कनेक्टर और चित्र फ्रेम के लिये समकक्ष लॉक सेट करता है। कनेक्टर गति के लिये [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करता है; समूह भी समूह‑बद्धता को प्रतिबंधित करने के लिये [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों को लागू करके एक प्रतिलिपि सहेजता है। चार संभाले गये प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर की बच्ची आकारों को नहीं घुमाता।

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

### **संरक्षण हटाएँ**

एक आकार लॉक को हटाने के लिये उसका मान `False` सेट करें। नीचे दिया गया उदाहरण आकार लॉक के साथ एक प्रस्तुति लोड करता है और चयन, गति और आकार‑बदलाव प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) और [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह समूह‑बद्धता प्रतिबंध को भी [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) को `False` पास करके हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को सुरक्षित रखें**

कार्यशील निर्देशिका में `photo.jpg` नाम की फ़ोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) को `True` के साथ कॉल करके क्रॉप को सुरक्षित रखता है।

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

`PictureLocked.pptx` में, PowerPoint फोटो का चयन करने पर **Crop** कमांड को अक्षम कर देता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) को `True` के साथ कॉल करके दो आकारों को साथ रखते हैं। आप अभी भी समूह को ले जा सकते हैं या घटक का भराव बदल सकते हैं।

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

`DiagramLocked.pptx` में, PowerPoint पूरे डायग्राम का चयन करने पर **Ungroup** कमांड को अक्षम कर देता है।

### **निष्कर्ष**

Aspose.Slides for Python via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइड‑दर‑स्लाइड समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको प्रतिबंध हटाने की आवश्यकता हो तो उनके मान `False` सेट करें।

## **FAQ**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड संरक्षण को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/python-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं अन्य स्लाइडों को प्रभावित किए बिना विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ?**

हाँ। केवल चयनित स्लाइडों पर आकारों के लिए लॉक लागू करें। यह अन्य स्लाइडों पर लॉक सेटिंग को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा लौटाए गए संग्रह पर इटररेट करें और प्रत्येक बच्ची आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिये इस प्रक्रिया को दोहराएँ। ऊपर दिए गए उदाहरण केवल स्लाइड के आकार संग्रह को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।