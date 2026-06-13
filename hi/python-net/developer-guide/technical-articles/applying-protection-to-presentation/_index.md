---
title: Python में Shape Locks के साथ प्रस्तुति संपादन को रोकें
linktitle: प्रस्तुति संपादन को रोकें
type: docs
weight: 70
url: /hi/python-net/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार लॉक करें
- समूह लॉक करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Python via .NET PPT, PPTX और ODP फ़ाइलों में शेप्स को लॉक या अनलॉक करता है, प्रस्तुतियों को सुरक्षित बनाते हुए नियंत्रित संपादन और तेज़ डिलीवरी की अनुमति देता है।"
---
## **पृष्ठभूमि**

Aspose.Slides का एक सामान्य उपयोग माइक्रोसॉफ्ट पॉवरपॉइंट (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है, जो एक स्वचालित कार्यप्रवाह का हिस्सा है। इस प्रकार Aspose.Slides का उपयोग करने वाले एप्लिकेशन के उपयोगकर्ताओं को उत्पन्न प्रस्तुतियों तक पहुँच मिलती है, इसलिए उन्हें संपादन से बचाना एक सामान्य चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से निर्मित प्रस्तुतियों में उनका मूल स्वरूप और सामग्री बनी रहे।

यह लेख समझाता है कि प्रस्तुतियों और स्लाइड्स की संरचना कैसे होती है और Aspose.Slides for Python कैसे एक प्रस्तुति पर सुरक्षा लागू कर सकता है और बाद में उसे हटा सकता है। यह डेवलपर्स को एक तरीका प्रदान करता है जिससे वे नियंत्रित कर सकें कि उनके एप्लिकेशन द्वारा निर्मित प्रस्तुतियों का कैसे उपयोग किया जाए।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोज़ैप, टेबल, OLE ऑब्जेक्ट, ग्रुप्ड शेप्स, पिक्चर फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटक होते हैं जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Python में स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास से विरासत में मिलता है।

PPTX की संरचना जटिल है, इसलिए PPT के विपरीत, जहाँ सभी प्रकार के शेप्स के लिए एक सामान्य लॉक उपयोग किया जा सकता है, विभिन्न शेप प्रकारों के लिए अलग-अलग लॉक आवश्यक होते हैं। [BaseShapeLock](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseshapelock/) क्लास PPTX के लिए सामान्य लॉकिंग क्लास है। निम्न प्रकार के लॉक Aspose.Slides for Python में PPTX के लिए समर्थित हैं:

- [AutoShapeLock] ऑटोज़ैप को लॉक करता है।  
- [ConnectorLock] कनेक्टर शेप्स को लॉक करता है।  
- [GraphicalObjectLock] ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।  
- [GroupShapeLock] ग्रुप शेप्स को लॉक करता है।  
- [PictureFrameLock] पिक्चर फ्रेम्स को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट में सभी शेप ऑब्जेक्ट्स पर किया गया कोई भी कार्य पूरी प्रस्तुति पर लागू होता है।

## **सुरक्षा लागू करना और हटाना**

सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रस्तुति को संपादित नहीं किया जा सकता। यह प्रस्तुति की सामग्री को सुरक्षित रखने की एक उपयोगी तकनीक है।

### **PPTX शेप्स पर सुरक्षा लागू करें**

Aspose.Slides for Python [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास प्रदान करता है ताकि स्लाइड पर शेप्स के साथ काम किया जा सके।

जैसा कि पहले बताया गया, प्रत्येक शेप क्लास के साथ एक संबंधित शेप‑लॉक क्लास सुरक्षा के लिए जुड़ी होती है। यह लेख NoSelect, NoMove, और NoResize लॉक पर केंद्रित है। ये लॉक सुनिश्चित करते हैं कि शेप्स को चुना नहीं जा सके (माउस क्लिक या अन्य चयन विधियों द्वारा) और उन्हें नहीं घुमा या आकार बदल सकें।

नीचे दिया गया कोड स्निपेट प्रस्तुति में सभी शेप प्रकारों पर सुरक्षा लागू करता है।

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("Sample.pptx") as presentation:
    # प्रस्तुति में सभी स्लाइड्स को पार करें।
    for slide in presentation.slides:
        # स्लाइड में सभी आकारों को पार करें।
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # प्रस्तुति फ़ाइल को सहेज रहे हैं।
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **सुरक्षा हटाएँ**

किसी शेप को अनलॉक करने के लिए, लागू किए गए लॉक का मान `False` सेट करें। नीचे दिया गया कोड स्निपेट दर्शाता है कि लॉक की गई प्रस्तुति में शेप्स को कैसे अनलॉक किया जाए।

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # प्रस्तुति में सभी स्लाइड्स को पार कर रहे हैं।
    for slide in presentation.slides:
        # स्लाइड में सभी आकारों को पार कर रहे हैं।
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # प्रस्तुति फ़ाइल को सहेजा जा रहा है।
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **निष्कर्ष**

Aspose.Slides प्रस्तुतियों में शेप्स को सुरक्षित करने के कई विकल्प प्रदान करता है। आप एक व्यक्तिगत शेप को लॉक कर सकते हैं या प्रस्तुति में सभी शेप्स को इटरनेट करके प्रत्येक को लॉक कर सकते हैं ताकि पूरी फ़ाइल प्रभावी रूप से सुरक्षित हो सके। आप लॉक के मान को `False` सेट करके सुरक्षा हटा सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में शेप लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। लॉक फ़ाइल के अंदर ऑब्जेक्ट्स के संपादन को सीमित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/python-net/password-protected-presentation/) खोलने और/या परिवर्तन सहेजने की पहुँच को नियंत्रित करता है। ये तंत्र एक‑दूसरे को पूरक होते हैं और साथ मिलकर काम करते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य को प्रभावित किए?**

हाँ। चयनित स्लाइड्स पर शेप्स को लॉक करें; शेष स्लाइड्स संपादन योग्य रहेंगी।

**क्या शेप लॉक ग्रुपेड ऑब्जेक्ट्स और कनेक्टर्स पर लागू होते हैं?**

हाँ। ग्रुप, कनेक्टर, ग्राफिकल ऑब्जेक्ट्स और अन्य शेप प्रकारों के लिए समर्पित लॉक प्रकार समर्थित हैं।