---
title: Python में शैप लॉक के साथ प्रस्तुतिकरण संपादनों को प्रतिबंधित करें
linktitle: प्रस्तुतिकरण संपादनों को प्रतिबंधित करें
type: docs
weight: 70
url: /hi/python-net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- शैप लॉक
- स्थिति लॉक
- चयन लॉक
- आकार परिवर्तन लॉक
- समूहबद्धता लॉक
- PowerPoint
- PPTX
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PPTX प्रस्तुतियों में शैप्स को लॉक और अनलॉक करना सीखें ताकि चयन, स्थानांतरण, आकार परिवर्तन और समूहबद्धता को प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Python via .NET का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के भाग के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो शैप्स में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि शैप्स स्लाइड्स पर कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में शैप लॉक कैसे लागू और हटाए जा सकते हैं। ये लॉक आपको व्यक्तिगत शैप्स पर विशिष्ट संपादन क्रियाओं को सीमित करने की अनुमति देते हैं।

## **स्लाइड का संयोजन**

एक प्रस्तुति स्लाइड में ऑटोषेप्स, तालिकाएँ, OLE ऑब्जेक्ट्स, समूहित शैप्स, पिक्चर फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटक होते हैं जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Python via .NET में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा प्रतिनिधित्व किया जाता है जो [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास से विरासत में प्राप्त करता है।

विभिन्न शैप प्रकार अलग-अलग लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) क्लास शैप लॉक का बेस क्लास है। Aspose.Slides for Python via .NET निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) कनेक्टर शैप्स को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) समूह शैप्स को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) पिक्चर फ़्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर क्रम में जाकर प्रत्येक समर्थित शैप पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

शैप लॉक चयन, स्थानांतरण और आकार परिवर्तन जैसी क्रियाओं को सीमित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते।

### **PPTX शैप्स पर सुरक्षा लागू करें**

Aspose.Slides for Python via .NET स्लाइड पर शैप्स के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) और [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) को ऑटोषेप्स के लिए `True` सेट किया गया है, और समूह शैप्स, कनेक्टर और पिक्चर फ्रेम के लिए समान लॉक लागू किए गए हैं। कनेक्टर स्थानान्तरण के लिए [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) का उपयोग करता है; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड की शैप कलेक्शन में शैप्स की जाँच करता है, और इन प्रतिबंधों के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के शैप्स अपरिवर्तित रहते हैं। लूप समूह के अंदर की चाइल्ड शैप्स को नहीं पार करता।

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

### **सुरक्षा हटाएँ**

शैप लॉक को हटाने के लिए, उसके मान को `False` सेट करें। निम्न उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसमें शैप लॉक हैं और [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) और [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) के माध्यम से चयन, स्थानांतरण और आकार परिवर्तन प्रतिबंधों को साफ़ करता है। यह [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) को भी साफ़ करता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **निष्कर्ष**

Aspose.Slides for Python via .NET आपको व्यक्तिगत शैप्स पर विशिष्ट संपादन क्रियाओं को सीमित करने या स्लाइड्स के पार समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक शैप प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो मान को `False` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में शैप लॉक और पासवर्ड सुरक्षा दोनों को संयोजित कर सकता हूँ?**

हां। शैप लॉक विशिष्ट संपादन क्रियाओं को सीमित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों का एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हां। केवल चयनित स्लाइडों के शैप्स पर लॉक लागू करें। इससे अन्य स्लाइडों की लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के अंदर व्यक्तिगत शैप्स पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [शेप्स](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) कलेक्शन के माध्यम से क्रमबद्ध करके प्रत्येक चाइल्ड शैप पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए यह प्रक्रिया दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की शैप कलेक्शन को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्य पर लॉक नहीं लगाते।