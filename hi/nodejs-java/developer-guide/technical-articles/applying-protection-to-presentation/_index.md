---
title: Node.js में Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रेजेंटेशन संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/nodejs-java/applying-protection-to-presentation/
keywords:
- संपादनों को रोकें
- संपादन से सुरक्षा
- आकार लॉक करें
- स्थिति लॉक करें
- चयन लॉक करें
- आकार बदलना लॉक करें
- समूह बनाना लॉक करें
- PowerPoint
- PPTX
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, आंदोलन, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अद्यतन करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि स्लाइड्स पर आकारों को कैसे व्यवस्थित किया जाता है और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोशेप, टेबल, OLE ऑब्जेक्ट, समूहित आकार, तस्वीर फ़्रेम, वीडियो फ़्रेम, कनेक्टर और अन्य तत्व जैसे घटक शामिल होते हैं। Aspose.Slides for Node.js via Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) क्लास से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार अलग-अलग लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) क्लास आकार लॉक का आधार क्लास है। Aspose.Slides for Node.js via Java निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) autoshapes को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) समूह आकारों को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) चित्र फ़्रेम को लॉक करता है।  

किसी [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) में लॉक लागू करने के लिए, उसके स्लाइड्स पर इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

अनुरूप प्रस्तुति संपादक व्यक्तिगत संपादन संचालन को प्रतिबंधित करने के लिए आकार लॉक का उपयोग करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग [presentation protection settings](/slides/hi/nodejs-java/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Node.js via Java आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में autoshapes के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) और [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया गया है, तथा समूह आकार, कनेक्टर और चित्र फ़्रेम के लिए समकक्ष लॉक उपयोग किए गए हैं। कनेक्टर आंदोलन के लिए [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह भी समूह बनावट को प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड के shape collection में आकारों की जाँच करता है, और इन प्रतिबंधों को लागू कर एक प्रतिलिपि सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहने देते हैं। यह लूप समूह के अंदर की चाइल्ड आकारों को पार नहीं करता।

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

किसी आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। नीचे दिया गया उदाहरण आकार लॉक के साथ एक प्रस्तुति लोड करता है और चयन, आंदोलन और आकार बदलने की प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) और [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह समूह बनावट प्रतिबंध को भी [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) को `false` पास करके हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप संरक्षित करें**

वर्किंग डायरेक्टरी में `photo.jpg` नामक एक फोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर चित्र फ़्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) को कॉल करता है। `true` पास करने से आगे के क्रॉपिंग को प्रतिबंधित किया जाता है और मौजूदा क्रॉप संरक्षित रहता है।

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

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, **Crop** कमांड तब निष्क्रिय हो जाता है जब फोटो चयनित हो।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) को कॉल करके डायग्राम के घटकों को साथ रखता है। समूह को स्थानांतरित करने या किसी घटक की भराव बदलने जैसी अन्य संपादन उपलब्ध रहती हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, **Ungroup** कमांड तब निष्क्रिय हो जाता है जब पूरा डायग्राम चयनित हो।

### **निष्कर्ष**

Aspose.Slides for Node.js via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन संचालन को प्रतिबंधित करने या स्लाइड्स के पूरे में समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब इन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में shape locks और password protection को मिलाकर उपयोग कर सकता हूँ?**

हाँ। Shape locks विशिष्ट संपादन संचालन को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/nodejs-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों को एक ही फ़ाइल में इस्तेमाल कर सकते हैं।

**क्या मैं विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**

हाँ। लॉक केवल चयनित स्लाइडों पर आकारों पर लागू करें। इससे अन्य स्लाइडों पर लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के भीतर व्यक्तिगत आकारों पर locks कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) विधि द्वारा लौटाई गई संग्रह पर इटररेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। इसे किसी भी नेस्टेड समूह के लिए दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के shape collection को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।