---
title: Android पर आकार लॉक के साथ प्रस्तुति संपादनों को प्रतिबंधित करें
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
description: "Aspose.Slides for Android via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, आंदोलन, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **सारांश**

Aspose.Slides for Android via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को सीमित करने से इच्छित लेआउट और सामग्री को संरक्षित करने में मदद मिलती है।

यह लेख समझाता है कि स्लाइडों पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड ऑटोषेप्स, तालिकाएं, OLE ऑब्जेक्ट्स, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर, और अन्य तत्वों जैसे घटकों से बनी होती है जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Android via Java में, स्लाइड में प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या उस क्लास से विरासत में लेता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प उजागर करते हैं। [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस आकार लॉक के लिए बुनियादी इंटरफ़ेस है। Aspose.Slides for Android via Java निम्नलिखित लॉक इंटरफ़ेस प्रदान करता है:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) समूह आकारों को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) में लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उचित लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

अनुकूल प्रस्तुति संपादक आकार लॉक का उपयोग व्यक्तिगत संपादन संचालन को प्रतिबंधित करने के लिए करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़‑स्तरीय लिखने की सुरक्षा अलग [प्रेजेंटेशन सुरक्षा सेटिंग्स](/slides/hi/androidjava/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Android via Java आकारों के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

उदाहरण में ऑटोषेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), और [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) को कॉल किया जाता है, और समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समान लॉक लागू किए जाते हैं। कनेक्टर आंदोलन के लिए [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) का उपयोग करते हैं; समूह ग्रुपिंग को सीमित करने के लिए भी [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के साथ एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित छोड़ दिए जाते हैं। लूप समूह के अंदर के चाइल्ड आकारों को पार नहीं करता।

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

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक के साथ एक प्रस्तुति को लोड करता है और चयन, आंदोलन, और आकार बदलने की प्रतिबंधों को [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), और [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) के माध्यम से साफ़ करता है। यह [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) को `false` पास करके ग्रुपिंग प्रतिबंध भी हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को संरक्षित रखें**

कार्यशील निर्देशिका में `photo.jpg` नामक फ़ोटो रखें। उदाहरण बाएँ से 12 % और दाएँ से 8 % क्रॉप करता है, फिर चित्र फ्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) को कॉल करता है। `true` पास करने से आगे के क्रॉप को प्रतिबंधित किया जाता है और मौजूदा क्रॉप संरक्षित रहता है।

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

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब फोटो चयनित हो, तो **क्रॉप** कमांड निष्क्रिय हो जाता है।

### **आरेख को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) को कॉल करके आरेख के घटकों को साथ रखता है। समूह को स्थानांतरित करने या किसी घटक के फ़िल को बदलने जैसे अन्य संपादन उपलब्ध रहते हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब पूरा आरेख चयनित हो, तो **अलग करें** कमांड निष्क्रिय हो जाता है।

### **मौजूदा आकार लॉक की रिपोर्ट**

एक टेम्पलेट की समीक्षा करने के लिए, उसे खोलें और प्रत्येक आकार के लिए लॉक ऑब्जेक्ट पढ़ें। [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) मेथड `true` लौटाता है जब उस ऑब्जेक्ट पर सभी फ्लैग निष्क्रिय होते हैं और `false` जब कम से कम एक सक्रिय हो। एक समूह और उसके चाइल्ड के पास अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह के पास कोई लॉक न होने पर भी चाइल्ड का निरीक्षण करें।

यह उदाहरण ऑटोषेप्स, चित्र फ़्रेम और समूहों के आंदोलन की जाँच करता है। यह चित्रों के क्रॉपिंग और समूहों के अनग्रुपिंग की भी जाँच करता है। रिपोर्ट उन सक्षम फ्लैगों को सूचीबद्ध करती है जिन्हें यह पहचानता है और उन आकार प्रकारों को चिह्नित करती है जिन्हें यह जांचता नहीं है।

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

मान लें कि `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसमें अनग्रुपिंग लॉक है, उसके अंदर `Photo` नाम की एक तस्वीर है जिसमें क्रॉपिंग लॉक है, और एक अनलॉक्ड आयत `Free` है। रिपोर्ट `Free` को छोड़ देती है और इन दो पंक्तियों को प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहित आकार‑स्तर के संपादन फ्लैग को बिना बदले या प्रस्तुति सहेजे पढ़ती है। दस्तावेज़‑स्तर की लिखने की सुरक्षा एक अलग सेटिंग है, और प्रत्येक फ्लैग का प्रवर्तन संपादक पर निर्भर करता है।

## **निष्कर्ष**

Aspose.Slides for Android via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइडों के पार समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाने की आवश्यकता हो तो उनके मान `false` सेट करें।

## **FAQ**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को जोड़ सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/androidjava/password-protected-presentation/) प्रस्तुति के खोलने या संशोधित करने को सीमित कर सकती है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं अन्य स्लाइडों को प्रभावित किए बिना विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ?**

हाँ। केवल चयनित स्लाइडों पर आकारों पर लॉक लागू करें। इससे अन्य स्लाइडों पर लॉक सेटिंग नहीं बदलती।

**मैं समूह के अंदर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) मेथड द्वारा लौटाए गए संग्रह में इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह प्रक्रिया दोहराएँ, जैसा कि रिपोर्ट उदाहरण में दर्शाया गया है।