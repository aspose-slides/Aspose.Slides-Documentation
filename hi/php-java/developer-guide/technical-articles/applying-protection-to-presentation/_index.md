---
title: "PHP में शैप लॉक के साथ प्रस्तुतीकरण संपादन को प्रतिबंधित करें"
linktitle: "प्रस्तुतीकरण संपादन को प्रतिबंधित करें"
type: docs
weight: 60
url: /hi/php-java/applying-protection-to-presentation/
keywords:
- "संपादन रोकें"
- "संपादन से सुरक्षा करें"
- "आकृति लॉक करें"
- "स्थिति लॉक करें"
- "चयन लॉक करें"
- "आकार बदलना लॉक करें"
- "समूह बनाना लॉक करें"
- PowerPoint
- PPTX
- "प्रस्तुति"
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PPTX प्रस्तुतियों में आकृतियों को लॉक और अनलॉक करना सीखें ताकि चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित किया जा सके।"
---
## **परिचय**

Aspose.Slides for PHP via Java का एक आम उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अपडेट करना और सहेजना है। जब उपयोगकर्ताओं को ये प्रस्तुतियाँ प्राप्त होती हैं, तो आकृतियों में बदलाव को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित रखने में मदद मिलती है।

यह लेख बताता है कि स्लाइड्स में आकृतियों को कैसे व्यवस्थित किया जाता है और PPTX प्रस्तुति में आकृति लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकृतियों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोषेप, तालिकाएँ, OLE ऑब्जेक्ट, समूहित आकृतियाँ, पिक्चर फ्रेम, वीडियो फ्रेम, कनेक्टर और अन्य तत्व जैसे घटक होते हैं जो प्रस्तुति बनाने के लिए उपयोग किए जाते हैं। Aspose.Slides for PHP via Java में, स्लाइड पर प्रत्येक तत्व को एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास से व्युत्पन्न होता है।

विभिन्न प्रकार की आकृतियों में विभिन्न लॉक विकल्प उपलब्ध होते हैं। [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) क्लास आकृति लॉक के लिए बेस क्लास है। Aspose.Slides for PHP via Java निम्नलिखित लॉक क्लासें प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ऑटोशेप्स को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) कनेक्टर आकृतियों को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ग्राफिकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) ग्रुप शैप को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) पिक्चर फ्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) पर लॉक लागू करने के लिए, उसकी स्लाइड्स पर क्रमबद्ध चलें और प्रत्येक समर्थित आकृति पर उपयुक्त लॉक सेट करें।

## **संरक्षा लागू करना और हटाना**

संगत प्रस्तुति संपादक व्यक्तिगत संपादन कार्यों को प्रतिबंधित करने के लिए आकृति लॉक का उपयोग करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर की लिखने की सुरक्षा अलग [प्रेजेंटेशन सुरक्षा सेटिंग्स](/slides/hi/php-java/password-protected-presentation/) हैं।

### **PPTX आकृतियों पर सुरक्षा लागू करें**

Aspose.Slides for PHP via Java स्लाइड पर आकृतियों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में ऑटोषेप्स के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, तथा समूह आकृतियों, कनेक्टर और पिक्चर फ्रेम के लिए समतुल्य लॉक का उपयोग किया जाता है। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूहों के लिए समूह बनाना प्रतिबंधित करने हेतु [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) का भी उपयोग किया जाता है।

उदाहरण एक मौजूदा PPTX प्रस्तुति लोड करता है, प्रत्येक स्लाइड के शैप कलेक्शन में आकृतियों की जाँच करता है, और इन प्रतिबंधों के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर की आकृतियों को अपरिवर्तित छोड़ दिया जाता है। लूप समूह के भीतर की चाइल्ड आकृतियों को पार नहीं करता।

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

### **सुरक्षा हटाएँ**

एक आकृति लॉक को हटाने के लिए, उसके मान को `false` सेट करें। निम्नलिखित उदाहरण आकृति लॉक के साथ एक प्रस्तुति लोड करता है और चयन, गति और आकार बदलने के प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) में `false` पास करके समूह बनाना प्रतिबंध भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र क्रॉप को संरक्षित रखें**

कार्य निर्देशिका में `photo.jpg` नाम की फोटो रखें। उदाहरण बाएँ से 12% और दाएँ से 8% क्रॉप करता है, फिर पिक्चर फ्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) को कॉल करता है। `true` पास करने से आगे का क्रॉप प्रतिबंधित हो जाता है और मौजूदा क्रॉप संरक्षित रहता है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` में क्रॉप लॉक `true` के रूप में संग्रहीत होता है। PowerPoint में, जब फोटो चयनित हो तो **Crop** कमांड निष्क्रिय रहता है।

### **डायग्राम को समूहित रखें**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) को कॉल करके डायग्राम के घटकों को साथ रखता है। अन्य संपादन, जैसे समूह को स्थानांतरित करना या घटक के भराव को बदलना, उपलब्ध रहते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` में अनग्रुपिंग लॉक `true` के रूप में संग्रहीत होता है। PowerPoint में, जब पूरा डायग्राम चयनित हो तो **Ungroup** कमांड निष्क्रिय रहता है।

### **निष्कर्ष**

Aspose.Slides for PHP via Java आपको व्यक्तिगत आकृतियों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइड्स के पूरे में समान प्रतिबंध लागू करने की अनुमति देता है। प्रत्येक आकृति प्रकार द्वारा समर्थित लॉक चुनें, और जब आपको इन प्रतिबंधों को हटाना हो तो उनके मान को `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकृति लॉक और पासवर्ड सुरक्षा को संयोजित कर सकता हूँ?**

हां। आकृति लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/php-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों का उपयोग एक ही फ़ाइल में कर सकते हैं।

**क्या मैं विशिष्ट स्लाइड्स पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइड्स को प्रभावित किए?**

हां। केवल चयनित स्लाइड्स की आकृतियों पर लॉक लागू करें। इससे अन्य स्लाइड्स की लॉक सेटिंग्स नहीं बदलतीं।

**मैं समूह के भीतर व्यक्तिगत आकृतियों पर लॉक कैसे लागू कर सकता हूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) विधि द्वारा लौटाई गई कलेक्शन पर क्रमबद्ध चलें और प्रत्येक चाइल्ड आकृति पर उपयुक्त लॉक लागू करें। किसी भी नेस्टेड समूह के लिए यह प्रक्रिया दोहराएँ। ऊपर के उदाहरण केवल स्लाइड की शैप कलेक्शन को प्रोसेस करते हैं, इसलिए वे व्यक्तिगत समूह सदस्यों पर लॉक सेट नहीं करते।