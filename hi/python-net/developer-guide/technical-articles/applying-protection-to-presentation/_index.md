---
title: Python में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 70
url: /hi/python-net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से बचाएं
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
description: "Aspose.Slides for Python via .NET के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Python via .NET का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को बनाने, अपडेट करने और सहेजने के लिए एक स्वचालित कार्यप्रवाह का हिस्सा है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को सुरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की सुविधा देते हैं।

## **स्लाइड का निर्माण**

एक प्रस्तुति स्लाइड में ऑटोषेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटकों से बनी होती है जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Python via .NET में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रस्तुत करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) क्लास आकार लॉक के लिए बेस क्लास है। Aspose.Slides for Python via .NET निम्नलिखित लॉक क्लासें प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ऑटोषेप को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [प्रस्तुति](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) के across लॉक लागू करने के लिए, उसकी स्लाइड्स के माध्यम से इटररेट करें और प्रत्येक समर्थित आकार पर उचित लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग [प्रस्तुति सुरक्षा सेटिंग्स](/slides/hi/python-net/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Python via .NET स्लाइड पर आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण ऑटोषेप के लिए [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), और [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) को `True` पर सेट करता है, समूह आकार, कनेक्टर, और चित्र फ्रेम के लिए समान लॉक के साथ। कनेक्टर गति के लिए [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड की shape collection में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के अंदर के चाइल्ड आकारों को नहीं पार करता।

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

एक आकार लॉक हटाने के लिए, उसका मान `False` सेट करें। निम्नलिखित उदाहरण आकार लॉक वाले प्रस्तुति को लोड करता है और [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) , [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) , [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) , और [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) के माध्यम से चयन, गति, और आकार बदलने के प्रतिबंध को साफ़ करता है। यह [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) को भी साफ़ करता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को सुरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नाम की फ़ोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर चित्र फ्रेम पर [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) सेट करता है ताकि क्रॉप सुरक्षित रहे।

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

`PictureLocked.pptx` क्रॉप लॉक को `True` के रूप में संग्रहीत करता है। PowerPoint में, जब फोटो चयनित हो, तो **Crop** कमांड अक्षम हो जाता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह पर [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) सेट करता है ताकि डायग्राम के घटक एक साथ रहें। अन्य संपादन, जैसे समूह को ले जाना या घटक का भराव बदलना, उपलब्ध रहते हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `True` के रूप में संग्रहीत करता है। PowerPoint में, जब पूरा डायग्राम चयनित हो, तो **Ungroup** कमांड अक्षम हो जाता है।

### **निष्कर्ष**

Aspose.Slides for Python via .NET आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स के बीच समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो उनके मान को `False` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-net/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हां। चयनित स्लाइड्स पर केवल आकारों पर लॉक लागू करें। इससे अन्य स्लाइड्स के लॉक सेटिंग्स में कोई परिवर्तन नहीं होता।

**मैं समूह के अंदर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [आकार](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) कलेक्शन के माध्यम से इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए इसे दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की shape collection को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।