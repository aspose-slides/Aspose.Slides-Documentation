---
title: Node.js में Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रेजेंटेशन संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/nodejs-java/applying-protection-to-presentation/
keywords:
- संपादन को रोकें
- संपादन से सुरक्षा करें
- आकार को लॉक करें
- स्थिति को लॉक करें
- चयन को लॉक करें
- आकार बदलने को लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके."
---
## **अवलोकन**

Aspose.Slides for Node.js via Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को स्वचालित कार्यप्रवाह के भाग के रूप में बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिल सकती है।

यह लेख समझाता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोषेप, टेबल, OLE ऑब्जेक्ट, समूहित आकार, पिक्चर फ़्रेम, वीडियो फ़्रेम, कनेक्टर और प्रस्तुति बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटक शामिल होते हैं। Aspose.Slides for Node.js via Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) क्लास से विरासत में मिलता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) क्लास आकार लॉक के लिए बेस क्लास है। Aspose.Slides for Node.js via Java निम्नलिखित लॉक क्लास प्रदान करता है:
- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) ऑटोषेप को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) समूह आकारों को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) पिक्चर फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) पर लॉक लगाने के लिए, उसकी स्लाइड्स के माध्यम से इटरिटेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **लॉक लागू और हटाएँ**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग करके व्यक्तिगत संपादन कार्यों को प्रतिबंधित करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लेखन सुरक्षा अलग-अलग [प्रस्तुति सुरक्षा सेटिंग्स](/slides/hi/nodejs-java/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Node.js via Java [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) क्लास प्रदान करता है ताकि स्लाइड पर आकारों के साथ काम किया जा सके।

उदाहरण में ऑटोषेप के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, और समूह आकार, कनेक्टर और पिक्चर फ़्रेम के लिए समान लॉक लागू किए जाते हैं। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूहों के लिए समूह बनाने को प्रतिबंधित करने हेतु [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) भी उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर की चाइल्ड आकारों को पार नहीं करता।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सुरक्षा हटाएँ**

एक आकार लॉक को हटाने के लिए, उसके मान को `false` सेट करें। नीचे दिया गया उदाहरण आकार लॉक वाले प्रस्तुति को लोड करता है और चयन, गति और आकार बदलने की प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) में `false` पास करके समूह बनाने की प्रतिबंध को भी हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चित्र क्रॉप को संरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नाम की फ़ोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर पिक्चर फ्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) को कॉल करता है। `true` पास करने से आगे का क्रॉप प्रतिबंधित हो जाता है और मौजूदा क्रॉप संरक्षित रहता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, फोटो चयनित होने पर **Crop** कमांड निष्क्रिय रहता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) को कॉल करके डायग्राम के घटकों को साथ रखता है। समूह को स्थानांतरित करने या घटक के भराव को बदलने जैसे अन्य संपादन उपलब्ध रहते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, पूरी डायग्राम का चयन होने पर **Ungroup** कमांड निष्क्रिय रहता है।

### **मौजूदा आकार लॉक की रिपोर्ट**

एक टेम्पलेट की समीक्षा करने के लिए, उसे खोलें और प्रत्येक आकार के लॉक ऑब्जेक्ट को पढ़ें। [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) मेथड `true` लौटाता है जब उस ऑब्जेक्ट पर सभी ध्वज निष्क्रिय होते हैं और `false` जब कम से कम एक सक्रिय होता है। समूह और उसके बच्चों के पास अलग-अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह में कोई लॉक न होने पर भी बच्चों की जांच करें।

यह उदाहरण ऑटोषेप, पिक्चर फ्रेम और समूहों के लिए गति की जाँच करता है। यह चित्रों के लिए क्रॉपिंग और समूहों के लिए अनग्रुपिंग की भी जाँच करता है। रिपोर्ट उन सक्षम ध्वजों को सूचीबद्ध करती है जिन्हें यह पहचानती है और उन आकार प्रकारों को चिन्हित करती है जिन्हें यह जांच नहीं करती।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नाम का एक समूह है जिसके साथ अनग्रुपिंग लॉक है, उसके भीतर `Photo` नाम की एक तस्वीर है जिसके साथ क्रॉपिंग लॉक है, और एक अनलॉक्ड आयत `Free` नाम की है। रिपोर्ट `Free` को छोड़ देती है और इन दो पंक्तियों को प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहीत आकार-स्तरीय संपादन ध्वजों को पढ़ती है बिना उन्हें बदले या प्रस्तुति को सहेजे। दस्तावेज़-स्तर लेखन सुरक्षा एक अलग सेटिंग है, और प्रत्येक ध्वज का प्रवर्तन संपादक पर निर्भर करता है।

## **निष्कर्ष**

Aspose.Slides for Node.js via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स के बीच समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/nodejs-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना दूसरों को प्रभावित किए?**

हाँ। केवल चयनित स्लाइड्स पर आकारों को लॉक लागू करें। इससे अन्य स्लाइड्स की लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा लौटाई गई संग्रह के माध्यम से इटरिटेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही दोहराएँ, रिपोर्टिंग उदाहरण में दर्शाए गए ट्रैवर्सल का पालन करें।