---
title: जावा में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PPTX प्रस्तुतियों में आकार को लॉक और अनलॉक करना सीखें ताकि चयन, मूवमेंट, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Java का एक सामान्य उपयोग स्वचालित वर्कफ़्लो का हिस्सा के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित करने में मदद मिल सकती है।

यह लेख बताता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जा सकते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोषेप, टेबल, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर्स और अन्य तत्व जैसे घटक शामिल होते हैं जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा प्रदर्शित किया जाता है जो [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रकट करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए बेस इंटरफ़ेस है। Aspose.Slides for Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ऑटोषेप को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) समूह आकारों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) पर लॉक लगाने के लिए, उसकी स्लाइड्स को इटरेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **संरक्षण लागू करें और हटाएँ**

आकार लॉक चयन, मूवमेंट और आकार बदलने जैसी क्रियाओं को सीमित करते हैं। वे पूरी प्रस्तुति को अनएडिटेबल नहीं बनाते हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Java स्लाइड पर आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण ऑटोषेप के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल करता है, तथा समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समान लॉक लागू करता है। कनेक्टर्स मूवमेंट के लिए [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) का उपयोग करते हैं; समूह भी ग्रुपिंग को प्रतिबन्धित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित छूट जाते हैं। लूप समूह के अंदर के चाइल्ड आकारों को पार नहीं करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सुरक्षा हटाएँ**

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। नीचे दिया गया उदाहरण आकार लॉक वाली प्रस्तुति को लोड करता है और चयन, मूवमेंट और आकार बदलने के प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को `false` पास करके ग्रुपिंग प्रतिबंध को भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **निष्कर्ष**

Aspose.Slides for Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने या स्लाइड्स में समान प्रतिबंध लागू करने की सुविधा देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको इन प्रतिबंधों को हटाने की जरूरत हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन क्रियाओं को प्रतिबंधित करते हैं, जबकि [पासवर्ड संरक्षण](/slides/hi/java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स पर मौजूद आकारों पर लॉक लागू करें। यह अन्य स्लाइड्स के लॉक सेटिंग्स को नहीं बदलता है।

**मैं समूह के अंदर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) मेथड द्वारा लौटाए गए संग्रह को इटरेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए इसे दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के आकार संग्रह को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्य पर लॉक नहीं सेट करते।