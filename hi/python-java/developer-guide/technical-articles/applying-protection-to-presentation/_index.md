---
title: Python में Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/python-java/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षित करें
- आकृति लॉक करें
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
description: Aspose.Slides for Python via Java के साथ PPTX प्रस्तुतियों में आकृतियों को लॉक और अनलॉक करना सीखें, जिससे चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित हो सके।
---
## **पृष्ठभूमि**

Aspose.Slides for Python via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकृतियों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड्स पर आकृतियों को कैसे व्यवस्थित किया जाता है और PPTX प्रस्तुति में शेप लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत आकृतियों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप, तालिका, OLE ऑब्जेक्ट, समूहित आकृतियाँ, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर, और अन्य तत्व शामिल होते हैं जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Python via Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) वर्ग से विरासत में मिलता है।

विभिन्न आकृति प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) वर्ग आकृति लॉक के लिए आधार वर्ग है। Aspose.Slides for Python via Java निम्नलिखित लॉक वर्ग प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ऑटोशेप को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) कनेक्टर आकृतियों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) समूह आकृतियों को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर पुनरावृत्ति करें और प्रत्येक समर्थित आकृति पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

आकृति लॉक चयन, गति और आकार बदलने जैसी क्रियाओं को प्रतिबंधित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते हैं।

### **PPTX आकृतियों पर सुरक्षा लागू करें**

Aspose.Slides for Python via Java [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) वर्ग प्रदान करता है जो स्लाइड पर आकृतियों के साथ कार्य करने के लिये है।

उदाहरण में ऑटोशेप्स के लिए `True` के साथ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) और [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, तथा समूह आकृतियों, कनेक्टर्स और चित्र फ्रेम के लिए समकक्ष लॉक लागू किए जाते हैं। कनेक्टर्स गति के लिए [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह आकृतियों के लिए समूहबद्धता को प्रतिबंधित करने हेतु [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) का भी उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के शेप कलेक्शन में आकृतियों की जाँच करता है, और इन प्रतिबंधों को लागू करके एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर की आकृतियों को अपरिवर्तित छोड़ दिया जाता है। लूप समूह के भीतर की चाइल्ड आकृतियों को पार नहीं करता।

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

एक आकृति लॉक को हटाने के लिए, उसके मान को `False` सेट करें। निम्न उदाहरण एक ऐसी प्रस्तुति को लोड करता है जिसमें आकृति लॉक हैं और चयन, गति और आकार बदलने प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) और [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) को `False` पास करके समूहबद्धता प्रतिबंध को भी हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स को अपरिवर्तित छोड़ दिया जाता है।

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

### **निष्कर्ष**

Aspose.Slides for Python via Java आपको व्यक्तिगत आकृतियों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने या स्लाइड्स के बीच समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकृति प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको ये प्रतिबंध हटाने हों तो उनके मान को `False` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकृति लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। आकृति लॉक विशिष्ट संपादन क्रियाओं को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स की आकृतियों पर लॉक लागू करें। यह अन्य स्लाइड्स की लॉक सेटिंग्स को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकृतियों पर लॉक कैसे लागू कर सकता हूँ?**

समूह के [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा वापस किए गए संग्रह पर पुनरावृत्ति करें और प्रत्येक चाइल्ड आकृति पर उपयुक्त लॉक लागू करें। इसे किसी भी नेस्टेड समूह के लिए दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के शेप कलेक्शन को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।