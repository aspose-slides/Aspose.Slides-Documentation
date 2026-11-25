---
title: जावा में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/java/applying-protection-to-presentation/
keywords:
- संपादन रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- पावरपॉइंट
- PPTX
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करके चयन, गति, आकार बदलना और समूह बनाना को प्रतिबंधित करना सीखें।"
---
## **पृष्ठभूमि**

Aspose.Slides for Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को स्वचालित कार्यप्रवाह के हिस्से के रूप में बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता ये प्रस्तुतियां प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जा सकते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप, तालिका, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटकों का प्रयोग होता है। Aspose.Slides for Java में, स्लाइड पर प्रत्येक तत्व एक वस्तु द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में मिलता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्पों को उजागर करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए आधार इंटरफ़ेस है। Aspose.Slides for Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ऑटोशेप्स को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) समूह आकारों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) चित्र फ्रेम्स को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) में सभी स्लाइड्स पर इटरेट करके प्रत्येक समर्थित आकार पर उचित लॉक सेट करके लॉक लागू किए जा सकते हैं।

## **संरक्षण लागू और हटाएँ**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन क्रियाओं को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लेखन संरक्षण अलग [presentation protection settings](/slides/hi/java/password-protected-presentation/) होते हैं।

### **PPTX आकारों पर संरक्षण लागू करें**

Aspose.Slides for Java आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोशेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल किया गया है, और समूह आकार, कनेक्टर और चित्र फ्रेम्स के लिए समकक्ष लॉक लागू किए गए हैं। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) का प्रयोग करते हैं; समूह भी समूह बनाना प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहने देते हैं। लूप समूह के भीतर के बाल आकारों को नहीं पार करता।

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

### **संरक्षण हटाएँ**

एक आकार लॉक हटाने के लिए, उसका मूल्य `false` रखें। निम्नलिखित उदाहरण लॉक वाले प्रस्तुति को लोड करता है और [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) के माध्यम से चयन, गति और आकार बदलने की प्रतिबंधों को साफ़ करता है। यह [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को `false` पास करके समूह बनाना प्रतिबंध भी हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र कट को संरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नाम की फ़ोटो रखें। उदाहरण बाएँ से 12 % और दाएँ से 8 % काटता है, फिर चित्र फ्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) को कॉल करता है। `true` पास करने से आगे के काटने को प्रतिबंधित किया जाता है और मौजूदा कट संरक्षित रहता है।

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

`PictureLocked.pptx` कट लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में फोटो चयनित होने पर **Crop** कमांड निष्क्रिय हो जाता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) को कॉल करके डायग्राम के घटकों को साथ रखता है। समूह को ले जाना या घटक की भराव बदलना जैसी अन्य संपादन उपलब्ध रहती हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में संपूर्ण डायग्राम चयनित होने पर **Ungroup** कमांड निष्क्रिय हो जाता है।

### **मौजूदा आकार लॉक रिपोर्ट करें**

एक टेम्पलेट की समीक्षा करने के लिए, इसे खोलें और प्रत्येक आकार के लिए लॉक ऑब्जेक्ट पढ़ें। [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) मेथड तब `true` लौटाता है जब उस ऑब्जेक्ट पर सभी फ़्लैग निष्क्रिय होते हैं और `false` जब कम से कम एक सक्षम होता है। एक समूह और उसके बच्चों के पास अलग-अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह में कोई लॉक न होने पर भी बच्चों की जाँच करें।

यह उदाहरण ऑटोशेप्स, चित्र फ्रेम्स और समूहों की गति की जाँच करता है। यह चित्रों के लिए कटिंग और समूहों के लिए अनग्रुपिंग की भी जाँच करता है। रिपोर्ट पहचाने गए सक्षम फ़्लैग सूचीबद्ध करता है और उन आकार प्रकारों को चिह्नित करता है जिन्हें यह निरीक्षण नहीं करता।

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसमें अनग्रुपिंग लॉक है, उसके भीतर `Photo` नाम का एक चित्र है जिसमें कटिंग लॉक है, और `Free` नाम का एक अनलॉक्ड आयत है। रिपोर्ट `Free` को छोड़ देती है और इन दो पंक्तियों को प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहीत आकार-स्तरीय संपादन फ़्लैग को बिना बदले या प्रस्तुति को सहेजे पढ़ती है। दस्तावेज़-स्तर लेखन संरक्षण एक अलग सेटिंग है, और प्रत्येक फ़्लैग का प्रवर्तन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन क्रियाओं को प्रतिबंधित करने या स्लाइड्स के पार समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको ये प्रतिबंध हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **FAQ**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड संरक्षण को मिलाकर उपयोग कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन क्रियाओं को प्रतिबंधित करते हैं, जबकि [password protection](/slides/hi/java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना दूसरों को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स पर आकारों पर लॉक लागू करें। यह अन्य स्लाइड्स पर लॉक सेटिंग्स को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) मेथड द्वारा लौटाए गए संग्रह पर इटरेट करें और प्रत्येक बाल आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही प्रक्रिया दोहराएँ, जैसा कि रिपोर्ट उदाहरण में दर्शाया गया है।