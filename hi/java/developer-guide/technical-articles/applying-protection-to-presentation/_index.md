---
title: जावा में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/java/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से बचाएँ
- आकार को लॉक करें
- स्थिति को लॉक करें
- चयन को लॉक करें
- आकार बदलने को लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करने का तरीका सीखें, ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **पृष्ठभूमि**

Aspose.Slides for Java का एक सामान्य उपयोग यह है कि स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को रोकना इच्छित लेआउट और सामग्री को बनाए रखने में मदद कर सकता है।

यह लेख समझाता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाए। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को सीमित करने की अनुमति देते हैं।

## **स्लाइड का संघटन**

एक प्रस्तुति स्लाइड में ऑटोषेप्स, तालिकाएँ, OLE ऑब्जेक्ट्स, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर्स और प्रस्तुति बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटक होते हैं। Aspose.Slides for Java में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या किसी क्लास से विरासत में मिलता है जो करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) कनेक्टर आकार को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) समूह आकार को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) के सभी स्लाइड्स के माध्यम से पुनरावृति करके और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करके लॉक लागू किया जाता है।

## **रक्षा लागू करना और हटाना**

संगत प्रस्तुति संपादक व्यक्तिगत संपादन संचालन को सीमित करने के लिए आकार लॉक का उपयोग करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़‑स्तरीय लिखने की सुरक्षा अलग-अलग [presentation protection settings](/slides/hi/java/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for Java आकारों को संभालने के लिए [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोषेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल किया जाता है; समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समकक्ष लॉक होते हैं। कनेक्टर्स के गति को नियंत्रित करने के लिए [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) उपयोग किया जाता है; समूहों में समूह बनाने को रोकने के लिए [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का भी उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड की shape collection में आकारों की जाँच करता है, और इन प्रतिबंधों को लागू करके एक कॉपी सहेजता है। चार संभाले गए प्रकारों से बाहर के आकार अपरिवर्तित छोड़ दिए जाते हैं। लूप समूह के भीतर की चाइल्ड आकारों को पार नहीं करता।

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

एक आकार लॉक को हटाने के लिए, उसके मान को `false` सेट करें। नीचे दिया गया उदाहरण आकार लॉक वाले प्रस्तुति को लोड करता है और [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) के माध्यम से चयन, गति और आकार बदलने की प्रतिबंधों को साफ़ करता है। यह [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को `false` पास करके समूह बनाने की प्रतिबंध को भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र कप कॉपी रखना**

कार्यकारी निर्देशिका में `photo.jpg` नामक फ़ोटो रखें। उदाहरण बाएँ से 12 % और दाएँ से 8 % काटता है, फिर चित्र फ्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) को `true` के साथ कॉल करता है। `true` पास करने से आगे के क्रॉपिंग को प्रतिबंधित किया जाता है और मौजूदा क्रॉप संरक्षित रहता है।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में फोटो चयनित होने पर **Crop** कमांड निष्क्रिय हो जाता है।

### **डायग्राम को समूहित रखना**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) को `true` के साथ कॉल करके डायग्राम के घटकों को साथ रखने को मजबूर करता है। अन्य संपादन, जैसे समूह को ले जाना या किसी घटक के फ़िल को बदलना, उपलब्ध रहते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में पूरे डायग्राम के चयनित होने पर **Ungroup** कमांड निष्क्रिय हो जाता है।

### **निष्कर्ष**

Aspose.Slides for Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइड्स के पार समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आप उन प्रतिबंधों को हटाना चाहते हैं तो उनके मान को `false` सेट करें।

## **FAQ**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकार लॉक विशिष्ट संपादन संचालन को प्रतिबंधित करता है, जबकि [password protection](/slides/hi/java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हां। केवल चयनित स्लाइड्स के आकारों पर लॉक लागू करें। यह अन्य स्लाइड्स पर लॉक सेटिंग्स को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) विधि द्वारा लौटाई गई संग्रह के माध्यम से पुनरावृति करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की shape collection को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।