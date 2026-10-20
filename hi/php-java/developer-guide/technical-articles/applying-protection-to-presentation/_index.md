---
title: PHP में आकार लॉक के साथ प्रस्तुति संपादन को प्रतिबंधित करें
linktitle: प्रस्तुति संपादन को प्रतिबंधित करें
type: docs
weight: 60
url: /hi/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PPTX प्रस्तुतियों में आकारों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **परिचय**

Aspose.Slides for PHP via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को सुरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड्स पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक कैसे लागू और हटाए जाएँ। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड autoshapes, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ्रेम, वीडियो फ्रेम, कनेक्टर, और अन्य तत्वों जैसे घटकों से बनी होती है, जो प्रस्तुति बनाने के लिए उपयोग होते हैं। Aspose.Slides for PHP via Java में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास से विरासत में मिलता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रस्तुत करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) क्लास आकार लॉक का बेस क्लास है। Aspose.Slides for PHP via Java निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ऑटोषेप्स को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) चित्र फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) पर सभी स्लाइड्स में लॉक लागू करने के लिए, उसकी स्लाइड्स पर इटरनेट करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

आकार लॉक चयन, गति और आकार बदलने जैसी संचालन को प्रतिबंधित करते हैं। वे पूरी प्रस्तुति को अपरिवर्तनीय नहीं बनाते।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for PHP via Java स्लाइड पर आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण ऑटोषेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल करता है, तथा समूह आकार, कनेक्टर और चित्र फ्रेम के लिए समकक्ष लॉक लागू करता है। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने हेतु [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड की आकार संग्रह में आकारों की जांच करता है, और इन प्रतिबंधों को लागू करके एक प्रतिलिपि सहेजता है। चार संभाली गई प्रकारों के बाहर के आकार अपरिवर्तित छोड़ दिए जाते हैं। लूप समूह के अंदर के चाइल्ड आकारों को पार नहीं करता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **सुरक्षा हटाना**

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक के साथ एक प्रस्तुति लोड करता है और चयन, गति और आकार बदलने के प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) के माध्यम से साफ करता है। यह [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) को `false` पास करके समूह बनाने के प्रतिबंध को भी हटाता है और प्रस्तुति की एक प्रतिलिपि सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **निष्कर्ष**

Aspose.Slides for PHP via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स पर समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको उन प्रतिबंधों को हटाना हो तो उनका मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/php-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को रोक सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हाँ। चयनित स्लाइड्स पर केवल आकारों पर लॉक लागू करें। यह अन्य स्लाइड्स की लॉक सेटिंग्स को नहीं बदलता।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा लौटाए गए संग्रह पर इटरनेट करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। इसके लिए किसी भी नेस्टेड समूह को दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की आकार संग्रह को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।