---
title: Android पर Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/androidjava/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PPTX प्रस्तुतियों में आकार को लॉक और अनलॉक करने का तरीका सीखें, जिससे चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित हो सके।"
---
## **अवलोकन**

Aspose.Slides for Android via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिल सकती है।

यह लेख समझाता है कि स्लाइड्स में आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की रचना**

एक प्रस्तुति स्लाइड में ऑटोषेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ़्रेम, वीडियो फ़्रेम, कनेक्टर, और अन्य तत्व जैसे घटकों का समावेश होता है जो प्रस्तुति बनाने में उपयोग होते हैं। Aspose.Slides for Android via Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प उजागर करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए बेस इंटरफ़ेस है। Aspose.Slides for Android via Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ऑटोषेप को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) कनेक्टर आकार को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) समूह आकार को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) पिक्चर फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटरेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **रक्षा लागू करना और हटाना**

आकार लॉक चयन, गति, और आकार बदलने जैसे कार्यों को प्रतिबंधित करते हैं। ये संपूर्ण प्रस्तुति को अप्राप्य नहीं बनाते।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Android via Java स्लाइड पर आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोषेप के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल किया गया है, तथा समूह आकार, कनेक्टर और पिक्चर फ्रेम के लिए समान लॉक का उपयोग किया गया है। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) का उपयोग करते हैं; समूहों के लिए भी ग्रुपिंग को प्रतिबंधित करने हेतु [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक प्रति सेव करता है। चार संभाली गई प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर के चाइल्ड आकारों को नहीं पार करता है।

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

### **सुरक्षा हटाना**

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक वाली प्रस्तुति लोड करता है और [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) के माध्यम से चयन, गति, और आकार बदलने के प्रतिबंध को साफ़ करता है। यह `false` पास करके [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को समूह प्रतिबंध भी हटाता है, और प्रस्तुति की एक प्रति सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

Aspose.Slides for Android via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स पर समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको ये प्रतिबंध हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/androidjava/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं अन्य स्लाइडों को प्रभावित किए बिना विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ?**

हां। केवल चयनित स्लाइडों पर आकारों पर लॉक लागू करें। यह अन्य स्लाइडों की लॉक सेटिंग को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) विधि द्वारा प्राप्त संग्रह को इटरेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के आकार संग्रह को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।