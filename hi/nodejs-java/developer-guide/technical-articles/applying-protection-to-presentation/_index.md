---
title: "Node.js में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें"
linktitle: "प्रस्तुति संपादन प्रतिबंधित करें"
type: docs
weight: 60
url: /hi/nodejs-java/applying-protection-to-presentation/
keywords:
- "संपादन रोकें"
- "संपादन से सुरक्षा"
- "आकार लॉक करें"
- "स्थिति लॉक करें"
- "चयन लॉक करें"
- "आकार बदलना लॉक करें"
- "समूह बनाना लॉक करें"
- "PowerPoint"
- "PPTX"
- "प्रस्तुति"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java का उपयोग करके PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें, जिससे चयन, चालना, आकार बदलना और समूह बनाना प्रतिबंधित हो सके।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java का एक सामान्य उपयोग PowerPoint (PPTX) प्रस्तुतियों को बनाने, अपडेट करने और सहेजने के लिए स्वचालित कार्यप्रवाह के हिस्से के रूप में है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख समझाता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाते हैं। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन ऑपरेशनों को सीमित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड ऑटोषेप्स, तालिकाएँ, OLE वस्तुएँ, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्वों से बनी होती है जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for Node.js via Java में, स्लाइड पर प्रत्येक तत्व को उस ऑब्जेक्ट द्वारा प्रतिनिधित्व किया जाता है जो [आकार](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) वर्ग से विरासत में प्राप्त करता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) वर्ग आकार लॉक के लिए आधार वर्ग है। Aspose.Slides for Node.js via Java निम्नलिखित लॉक वर्ग प्रदान करता है:
- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) कनेक्टर आकारों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट्स को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) समूह आकारों को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

किसी [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) के सभी स्लाइड्स पर लॉक लागू करने के लिए, उसकी स्लाइड्स के माध्यम से इटररेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करें और हटाएँ**

आकार लॉक चयन, चालना और आकार बदलने जैसे ऑपरेशनों को प्रतिबंधित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते।

### **PPTX आकारों पर सुरक्षा लागू करें**

Aspose.Slides for Node.js via Java [आकार](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) वर्ग प्रदान करता है ताकि स्लाइड पर आकारों के साथ काम किया जा सके।

उदाहरण में ऑटोषेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, और समूह आकार, कनेक्टर तथा चित्र फ्रेम के लिए समान लॉक लागू किए जाते हैं। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों को जाँचता है, और इन प्रतिबंधों के साथ एक प्रतिलिपि सेव करता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर के बाल आकारों को पार नहीं करता।

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

आकार लॉक को हटाने के लिए, उसके मान को `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक के साथ एक प्रस्तुति लोड करता है और [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) के माध्यम से चयन, चालना और आकार बदलने के प्रतिबंध को साफ़ करता है। यह समूह बनाने की प्रतिबंध को भी [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) को `false` पास करके हटाता है और प्रस्तुति की एक प्रतिलिपि सेव करता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **निष्कर्ष**

Aspose.Slides for Node.js via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन ऑपरेशनों को प्रतिबंधित करने या सभी स्लाइड्स पर समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं उसी प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा दोनों को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन ऑपरेशनों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/nodejs-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकती है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। लॉक केवल चयनित स्लाइड्स पर आकारों पर लागू करें। यह अन्य स्लाइड्स पर लॉक सेटिंग्स को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) विधि द्वारा लौटाए गए संग्रह के माध्यम से इटररेट करें और प्रत्येक बाल आकार पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह प्रक्रिया दोहराएँ। ऊपर के उदाहरण केवल स्लाइड के आकार संग्रह को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक नहीं सेट करते।