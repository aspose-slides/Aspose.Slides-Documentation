---
title: शेप लॉक के साथ प्रस्तुति संपादन रोकें
linktitle: प्रस्तुति संपादन रोकें
type: docs
weight: 60
url: /hi/java/applying-protection-to-presentation/
keywords:
  - संपादन रोकें
  - संपादन से रक्षा करें
  - शेप लॉक करें
  - स्थिति लॉक करें
  - चयन लॉक करें
  - आकार लॉक करें
  - समूहबद्धता लॉक करें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Java
  - Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Java PPT, PPTX और ODP फ़ाइलों में शैप्स को लॉक या अनलॉक करता है, प्रस्तुति को सुरक्षित रखते हुए नियंत्रित संपादन और तेज़ वितरण की अनुमति देता है।"
---
## **पृष्ठभूमि**

Aspose.Slides का सामान्य उपयोग स्वचालित वर्कफ़्लो के हिस्से के रूप में Microsoft PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जिन अनुप्रयोगों में Aspose.Slides का इस प्रकार उपयोग किया जाता है, उनके उपयोगकर्ताओं को निर्मित प्रस्तुतियों तक पहुँच मिलती है, इसलिए उन्हें संपादन से बचाना एक सामान्य चिंता है। यह महत्वपूर्ण है कि स्वचालित रूप से बनाई गई प्रस्तुतियों अपना मूल फ़ॉर्मेटिंग और सामग्री बनाए रखें।

यह लेख बताता है कि प्रस्तुतियों और स्लाइड्स की संरचना कैसे होती है और Aspose.Slides for Java प्रस्तुति पर सुरक्षा कैसे लागू कर सकता है और बाद में उसे हटा सकता है। यह डेवलपर्स को एक तरीका प्रदान करता है जिससे वे नियंत्रित कर सकें कि उनके अनुप्रयोगों द्वारा उत्पन्न प्रस्तुतियों का उपयोग कैसे किया जाता है।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में autoshapes, तालिकाएँ, OLE ऑब्जेक्ट्स, समूहित शैप्स, पिक्चर फ्रेम, वीडियो फ्रेम, कनेक्टर्स और अन्य तत्व जैसे घटक शामिल होते हैं जो प्रस्तुति बनाने के लिए उपयोग किए जाते हैं। Aspose.Slides for Java में, स्लाइड के प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस को लागू करता है या किसी क्लास से उत्तराधिकार प्राप्त करता है।

The structure of PPTX जटिल है, इसलिए PPT के विपरीत, जहाँ सभी शैप प्रकारों के लिए एक सामान्य लॉक उपयोग किया जा सकता है, विभिन्न शैप प्रकारों को विभिन्न लॉक की आवश्यकता होती है। [IBaseShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseshapelock/) इंटरफ़ेस PPTX के लिए सामान्य लॉकिंग क्लास है। निम्नलिखित प्रकार के लॉक Aspose.Slides for Java में PPTX के लिए समर्थित हैं:

- [IAutoShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshapelock/) autoshapes को लॉक करता है।  
- [IConnectorLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnectorlock/) कनेक्टर शैप्स को लॉक करता है।  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igraphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट्स को लॉक करता है।  
- [IGroupShapeLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igroupshapelock/) समूह शैप्स को लॉक करता है।  
- [IPictureFrameLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/) पिक्चर फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट में सभी शैप ऑब्जेक्ट्स पर किया गया कोई भी कार्य पूरी प्रस्तुति पर लागू होता है।

## **सुरक्षा लागू करें और हटाएँ**

सुरक्षा लागू करने से यह सुनिश्चित होता है कि प्रस्तुति को संपादित नहीं किया जा सकता। यह प्रस्तुति की सामग्री की सुरक्षा के लिए एक उपयोगी तरीका है।

### **PPTX शैप्स पर सुरक्षा लागू करें**

Aspose.Slides for Java स्लाइड पर शैप्स के साथ काम करने के लिए [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस प्रदान करता है।

जैसा कि पहले बताया गया है, प्रत्येक शैप क्लास की सुरक्षा के लिए एक संबंधित शैप-लॉक क्लास होती है। यह लेख NoSelect, NoMove, और NoResize लॉक पर केंद्रित है। ये लॉक सुनिश्चित करते हैं कि शैप्स को चयनित (माउस क्लिक या अन्य चयन विधियों से) नहीं किया जा सकता और उन्हें स्थानांतरित या आकार बदलने से रोका जा सकता है।

निम्नलिखित कोड नमूना प्रस्तुति में सभी शैप प्रकारों पर सुरक्षा लागू करता है।

```java
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
Presentation presentation = new Presentation("Sample.pptx");

// प्रस्तुति की सभी स्लाइड्स पर इटररेट कर रहे हैं।
for (ISlide slide : presentation.getSlides()) {

    // स्लाइड में सभी शैप्स पर इटररेट कर रहे हैं।
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // शैप को ऑटोशेप में टाइप-कास्ट कर रहे हैं और इसका शैप लॉक प्राप्त कर रहे हैं।
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // शैप को ग्रुप शैप में टाइप-कास्ट कर रहे हैं और इसका शैप लॉक प्राप्त कर रहे हैं।
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // शैप को कनेक्टर शैप में टाइप-कास्ट कर रहे हैं और इसका शैप लॉक प्राप्त कर रहे हैं।
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // शैप को पिक्चर फ़्रेम में टाइप-कास्ट कर रहे हैं और इसका शैप लॉक प्राप्त कर रहे हैं।
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// प्रस्तुति फ़ाइल को सहेजा जा रहा है।
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **सुरक्षा हटाएँ**

किसी शैप को अनलॉक करने के लिए, लागू किए गए लॉक का मान `false` सेट करें। निम्नलिखित कोड नमूना दिखाता है कि कैसे लॉक किए गए प्रस्तुति में शैप्स को अनलॉक किया जाता है।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
Presentation presentation = new Presentation("ProtectedSample.pptx");

// प्रस्तुति की सभी स्लाइड्स पर इटररेट कर रहे हैं।
for (ISlide slide : presentation.getSlides()) {

    // स्लाइड में सभी शैप्स पर इटररेट कर रहे हैं।
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // शैप को ऑटोशेप में टाइप-कास्ट कर रहे हैं और उसका शैप लॉक प्राप्त कर रहे हैं।
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // शैप को ग्रुप शैप में टाइप-कास्ट कर रहे हैं और उसका शैप लॉक प्राप्त कर रहे हैं।
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // शैप को कनेक्टर शैप में टाइप-कास्ट कर रहे हैं और उसका शैप लॉक प्राप्त कर रहे हैं।
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // शैप को पिक्चर फ़्रेम में टाइप-कास्ट कर रहे हैं और उसका शैप लॉक प्राप्त कर रहे हैं।
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// प्रस्तुति फ़ाइल को सहेजा जा रहा है।
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **निष्कर्ष**

Aspose.Slides प्रस्तुति में शैप्स की सुरक्षा के लिए कई विकल्प प्रदान करता है। आप व्यक्तिगत शैप को लॉक कर सकते हैं या प्रस्तुति में सभी शैप्स पर इटरेट करके प्रत्येक को लॉक कर पूरी फ़ाइल को प्रभावी रूप से सुरक्षित कर सकते हैं। आप लॉक मान को `false` सेट करके सुरक्षा हटा सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में शैप लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। लॉक फाइल के अंदर के ऑब्जेक्ट्स के संपादन को सीमित करते हैं, जबकि [password protection](/slides/hi/java/password-protected-presentation/) खोलने और/या परिवर्तन सहेजने तक पहुँच को नियंत्रित करता है। ये तंत्र एक-दूसरे को पूरक करते हैं और मिलकर काम करते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को सीमित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। चयनित स्लाइड्स पर शैप्स के लिए लॉक लागू करें; शेष स्लाइड्स संपादन योग्य रहेंगी।

**क्या शैप लॉक समूहित ऑब्जेक्ट्स और कनेक्टर्स पर लागू होते हैं?**

हाँ। समूह, कनेक्टर्स, ग्राफ़िकल ऑब्जेक्ट्स और अन्य शैप प्रकारों के लिए विशेष लॉक प्रकार समर्थित हैं।