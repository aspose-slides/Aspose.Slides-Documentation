---
title: आकृति लॉक के साथ प्रस्तुति संपादन को रोकें
linktitle: प्रस्तुति संपादन रोकें
type: docs
weight: 60
url: /hi/python-java/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- आकृति को लॉक करें
- स्थिति को लॉक करें
- चयन को लॉक करें
- आकार को लॉक करें
- समूहबद्धता को लॉक करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Python via Java PPT, PPTX और ODP फ़ाइलों में आकृतियों को लॉक या अनलॉक करता है, प्रस्तुतियों को सुरक्षित करता है जबकि नियंत्रित संपादन और तेज़ डिलीवरी की अनुमति देता है।"
---
## **पृष्ठभूमि**

Aspose.Slides का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के भाग के रूप में Microsoft PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। इस प्रकार Aspose.Slides का उपयोग करने वाले अनुप्रयोगों के उपयोगकर्ता उत्पन्न प्रस्तुतियों तक पहुंच रखते हैं, इसलिए उन्हें संपादन से बचाना एक सामान्य चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से उत्पन्न प्रस्तुतियों में उनका मूल फ़ॉर्मैटिंग और सामग्री बनी रहे।

यह लेख समझाता है कि प्रस्तुतियों और स्लाइडों की संरचना कैसे होती है और Aspose.Slides for Python via Java कैसे एक प्रस्तुति पर सुरक्षा लागू कर सकता है और बाद में उसे हटा सकता है। यह डेवलपर्स को यह नियंत्रित करने का तरीका प्रदान करता है कि उनके अनुप्रयोगों द्वारा उत्पन्न प्रस्तुतियों का उपयोग कैसे किया जाए।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटॉशेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकृतियाँ, चित्र फ्रेम, वीडियो फ़्रेम, कनेक्टर और प्रस्तुतियों को बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटक होते हैं। Aspose.Slides for Python via Java में स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [आकृति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) वर्ग से विरासत में लेता है।

PPTX की संरचना जटिल है, इसलिए PPT के विपरीत जहाँ सभी प्रकार की आकृतियों के लिए एक सामान्य लॉक प्रयुक्त किया जा सकता है, विभिन्न आकृति प्रकारों को विभिन्न लॉक की आवश्यकता होती है। [BaseShapeLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseshapelock/) वर्ग PPTX के लिए सामान्य लॉकिंग वर्ग है। निम्नलिखित प्रकार के लॉक Aspose.Slides for Python via Java में PPTX के लिए समर्थित हैं:

- [AutoShapeLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshapelock/) ऑटॉशेप को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connectorlock/) कनेक्टर आकृतियों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshapelock/) समूह आकृतियों को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट में सभी आकृति ऑब्जेक्ट्स पर किया गया कोई भी कार्रवाई पूरी प्रस्तुति पर लागू होती है।

## **सुरक्षा लागू करना और हटाना**

सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रस्तुति को संपादित नहीं किया जा सके। यह प्रस्तुति की सामग्री की सुरक्षा के लिए एक उपयोगी तकनीक है।

### **PPTX आकृतियों पर सुरक्षा लागू करें**

Aspose.Slides for Python via Java स्लाइड पर आकृतियों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) वर्ग प्रदान करता है।

जैसा कि पहले उल्लेख किया गया है, प्रत्येक आकृति वर्ग के लिए सुरक्षा हेतु एक सम्बंधित shape-lock वर्ग होता है। इस लेख में NoSelect, NoMove और NoResize लॉक पर ध्यान दिया गया है। ये लॉक यह सुनिश्चित करते हैं कि आकृतियों को चयन (माउस क्लिक या अन्य चयन विधियों द्वारा) नहीं किया जा सके और उन्हें स्थानांतरित या आकार बदलने से रोका जा सके।

नीचे दिया गया कोड नमूना प्रस्तुति में सभी आकृति प्रकारों पर सुरक्षा लागू करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इनस्टैंसिएट करें।
presentation = Presentation("Sample.pptx")
try:
    # प्रस्तुति में सभी स्लाइडों को पार करें।
    for slide in presentation.getSlides():
        # स्लाइड में सभी आकृतियों को पार करें।
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

    # प्रस्तुति फ़ाइल को सहेजें।
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सुरक्षा हटाएँ**

एक आकृति को अनलॉक करने के लिए, लागू किए गए लॉक का मान `False` सेट करें। नीचे दिया गया कोड नमूना दिखाता है कि लॉक की गई प्रस्तुति में आकृतियों को कैसे अनलॉक किया जाए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इनस्टैंसिएट करें।
presentation = Presentation("ProtectedSample.pptx")
try:
    # प्रस्तुति में सभी स्लाइडों को पार करें।
    for slide in presentation.getSlides():
        # स्लाइड में सभी आकृतियों को पार करें।
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

    # प्रस्तुति फ़ाइल को सहेजें।
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **निष्कर्ष**

Aspose.Slides प्रस्तुति में आकृतियों को सुरक्षित करने के कई विकल्प प्रदान करता है। आप एकल आकृति को लॉक कर सकते हैं या प्रस्तुति में सभी आकृतियों के माध्यम से क्रमशः जा कर प्रत्येक को लॉक कर पूरी फ़ाइल को प्रभावी रूप से सुरक्षित बना सकते हैं। लॉक का मान `False` सेट करके आप सुरक्षा हटा सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकृति लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। लॉक फ़ाइल के भीतर ऑब्जेक्ट्स के संपादन को सीमित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-java/password-protected-presentation/) खोलने और/या परिवर्तन सहेजने तक पहुंच को नियंत्रित करती है। ये तंत्र एक-दूसरे को पूरक करते हैं और साथ में काम करते हैं।

**क्या मैं विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**

हाँ। चयनित स्लाइडों पर आकृतियों पर लॉक लागू करें; शेष स्लाइडें संपादन योग्य बनी रहेंगी।

**क्या आकृति लॉक समूहित ऑब्जेक्ट और कनेक्टर पर लागू होते हैं?**

हाँ। समूह, कनेक्टर, ग्राफ़िक ऑब्जेक्ट और अन्य आकृति प्रकारों के लिए समर्पित लॉक प्रकार समर्थित हैं।