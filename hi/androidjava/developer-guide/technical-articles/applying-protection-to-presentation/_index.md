---
title: Android पर Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन प्रतिबंधित करें
type: docs
weight: 60
url: /hi/androidjava/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षित रखें
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
description: "Aspose.Slides for Android via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **परिचय**

Aspose.Slides for Android via Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है, जो स्वचालित कार्यप्रवाह का हिस्सा होते हैं। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को सीमित करने से इच्छित लेआउट और सामग्री को बनाए रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड को ऑटोशेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ़्रेम, वीडियो फ़्रेम, कनेक्टर और अन्य तत्वों जैसे घटकों द्वारा बनाया जाता है, जो प्रस्तुति बनाने में उपयोग होते हैं। Aspose.Slides for Android via Java में, स्लाइड पर प्रत्येक तत्व को उस ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार अलग-अलग लॉक विकल्प प्रदान करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for Android via Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ऑटोशेप को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) कनेक्टर आकार को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) समूह आकार को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) चित्र फ़्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) के भीतर लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन संचालन को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग [प्रेजेंटेशन सुरक्षा सेटिंग्स](/slides/hi/androidjava/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for Android via Java स्लाइड पर आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोशेप के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल किया जाता है, तथा समूह आकार, कनेक्टर और चित्र फ़्रेम के लिए समकक्ष लॉक का उपयोग किया जाता है। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड की shape collection में आकारों को जांचता है, और इन प्रतिबंधों के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर की चाइल्ड आकारों को पार नहीं करता।

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

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक वाली एक प्रस्तुति को लोड करता है और चयन, गति और आकार बदलने के प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को `false` पास करके समूह बनाने के प्रतिबंध को भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को संरक्षित करना**

`photo.jpg` नाम की एक फोटो को कार्य निर्देशिका में रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर चित्र फ़्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) को कॉल करता है। `true` पास करने से आगे का क्रॉप प्रतिबंधित हो जाता है और मौजूदा क्रॉप संरक्षित रहता है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, फोटो चयनित होने पर **Crop** कमांड अक्षम हो जाता है।

### **डायाग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) को कॉल करके डायाग्राम के घटकों को एक साथ रखता है। समूह को स्थानांतरित करने या घटक की भराव को बदलने जैसी अन्य संपादन उपलब्ध रहती हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, पूरी डायाग्राम चयनित होने पर **Ungroup** कमांड अक्षम हो जाता है।

### **निष्कर्ष**

Aspose.Slides for Android via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइड्स पर एक ही प्रतिबंध लागू करने की सुविधा देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/androidjava/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों का एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स पर आकारों को लॉक लागू करें। इससे अन्य स्लाइड्स पर लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूं?**

समूह की [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) विधि द्वारा लौटाए गए संग्रह पर इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए इसे दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की shape collection को प्रक्रिया करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।