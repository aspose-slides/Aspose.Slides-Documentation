---
title: "PHP में Shape Locks के साथ प्रस्तुति संपादन को प्रतिबंधित करें"
linktitle: "प्रस्तुति संपादन को प्रतिबंधित करें"
type: docs
weight: 60
url: /hi/php-java/applying-protection-to-presentation/
keywords:
- "संपादन को रोकें"
- "संपादन से सुरक्षित रखें"
- "आकार को लॉक करें"
- "स्थिति को लॉक करें"
- "चयन को लॉक करें"
- "आकार बदलने को लॉक करें"
- "समूह बनाना लॉक करें"
- PowerPoint
- PPTX
- "प्रस्तुति"
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PPTX प्रस्तुतियों में आकार को लॉक और अनलॉक करना सीखें, जिससे चयन, गति, आकार बदलना और समूह बनाना प्रतिबंधित हो सके।"
---
## **समीक्षा**

Aspose.Slides for PHP via Java का एक सामान्य उपयोग स्वचालित कार्यप्रवाह के हिस्से के रूप में PowerPoint (PPTX) प्रस्तुतियों को बनाना, अद्यतन करना और सहेजना है। जब उपयोगकर्ता इन प्रस्तुतियों को प्राप्त करते हैं, तो आकारों में परिवर्तन को प्रतिबंधित करने से इच्छित लेआउट और सामग्री को संरक्षित करने में मदद मिलती है।

यह लेख समझाता है कि स्लाइडों पर आकार कैसे व्यवस्थित होते हैं और PPTX प्रस्तुति में आकार लॉक को कैसे लागू और हटाया जाता है। ये लॉक आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने की अनुमति देते हैं।

## **स्लाइड की संरचना**

एक प्रस्तुति स्लाइड में ऑटोषेप, तालिका, OLE ऑब्जेक्ट, समूहित आकार, चित्र फ़्रेम, वीडियो फ़्रेम, कनेक्टर, और प्रस्तुति बनाने के लिए उपयोग किए जाने वाले अन्य तत्व जैसे घटक होते हैं। Aspose.Slides for PHP via Java में, स्लाइड पर प्रत्येक तत्व एक ऑब्जेक्ट द्वारा दर्शाया जाता है जो [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास को विरासत में लेता है।

विभिन्न आकार प्रकार विभिन्न लॉक विकल्प प्रदान करते हैं। [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) क्लास आकार लॉक के लिए आधार क्लास है। Aspose.Slides for PHP via Java निम्नलिखित लॉक क्लास प्रदान करता है:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ऑटोषेप को लॉक करता है।  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) कनेक्टर आकार को लॉक करता है।  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ग्राफ़िकल ऑब्जेक्ट को लॉक करता है।  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) समूह आकार को लॉक करता है।  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) चित्र फ़्रेम को लॉक करता है।  

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) के ओवर सभी स्लाइडों पर लॉक लागू करने के लिए, उसके स्लाइडों को क्रमबद्ध करें और प्रत्येक समर्थित आकार पर उपयुक्त लॉक सेट करें।

## **सुरक्षा लागू करना और हटाना**

संगत प्रस्तुति संपादक आकार लॉक का उपयोग करके व्यक्तिगत संपादन कार्यों को प्रतिबंधित करते हैं। फ़ाइल एन्क्रिप्शन और दस्तावेज़-स्तर लिखने की सुरक्षा अलग [प्रस्तुति संरक्षण सेटिंग्स](/slides/hi/php-java/password-protected-presentation/) हैं।

### **PPTX आकारों पर सुरक्षा लागू करना**

Aspose.Slides for PHP via Java स्लाइड पर आकारों के साथ काम करने के लिए [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास प्रदान करता है।

उदाहरण में ऑटोषेप के लिए `true` के साथ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), और [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) को कॉल किया जाता है, समूह आकार, कनेक्टर और चित्र फ़्रेम के लिए समान लॉक लागू होते हैं। कनेक्टर गति के लिए [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) का उपयोग करते हैं; समूह भी समूह बनाने को प्रतिबंधित करने के लिए [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) का उपयोग करते हैं।

उदाहरण एक मौजूदा PPTX प्रस्तुति को लोड करता है, प्रत्येक स्लाइड के आकार संग्रह में आकारों की जाँच करता है, और इन प्रतिबंधों के लागू होने के साथ एक कॉपी सहेजता है। चार संभाले गए प्रकारों के बाहर के आकार अपरिवर्तित रहते हैं। लूप समूह के भीतर के चाइल्ड आकारों को पार नहीं करता।

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

एक आकार लॉक को हटाने के लिए, उसका मान `false` सेट करें। निम्नलिखित उदाहरण आकार लॉक के साथ एक प्रस्तुति को लोड करता है और चयन, गति, और आकार बदलने की प्रतिबंधों को [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), और [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) के माध्यम से साफ़ करता है। यह [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) को `false` पास करके समूह बनाने की प्रतिबंध को भी हटाता है और प्रस्तुति की एक कॉपी सहेजता है। अन्य लॉक सेटिंग्स अपरिवर्तित रहती हैं।

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

### **चित्र कटाव को संरक्षित करना**

कार्य निर्देशिका में `photo.jpg` नामक फोटो रखें। उदाहरण बाएँ से 12 % और दाएँ से 8 % कटाव करता है, फिर चित्र फ़्रेम के लॉक पर [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) को कॉल करता है। `true` पास करने से आगे के कटाव को प्रतिबंधित किया जाता है और मौजूदा कटाव संरक्षित रहता है।

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

`PictureLocked.pptx` क्रॉप लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब फोटो चयनित होता है तो **Crop** कमांड अक्षम हो जाता है।

### **डायग्राम को समूहित रखना**

उदाहरण एक आयत और एक तीर को समूहित करता है, फिर समूह के लॉक पर [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) को कॉल करके डायग्राम के घटकों को एक साथ रखता है। समूह को स्थानांतरित करने या किसी घटक के भराव को बदलने जैसी अन्य कार्रवाइयाँ उपलब्ध रहती हैं।

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

`DiagramLocked.pptx` अनग्रुपिंग लॉक को `true` के रूप में संग्रहीत करता है। PowerPoint में, जब पूरा डायग्राम चयनित होता है तो **Ungroup** कमांड अक्षम हो जाता है।

### **मौजूदा आकार लॉक रिपोर्ट करें**

एक टेम्पलेट की समीक्षा करने के लिए, उसे खोलें और प्रत्येक आकार के लिए लॉक ऑब्जेक्ट पढ़ें। [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) मेथड `true` लौटाता है जब उस ऑब्जेक्ट पर सभी फ़्लैग अक्षम होते हैं और `false` जब कम से कम एक सक्षम हो। एक समूह और उसके बच्चों के पास अलग लॉक ऑब्जेक्ट होते हैं, इसलिए समूह में कोई लॉक न होने पर भी बच्चों की जांच करें।

यह उदाहरण ऑटोषेप, चित्र फ़्रेम, और समूहों के लिए गति की जाँच करता है। यह चित्रों के लिए कटाव और समूहों के लिए अनग्रुपिंग भी जाँचता है। रिपोर्ट उन सक्षम फ़्लैगों को सूचीबद्ध करती है जिन्हें यह पहचानता है और उन आकार प्रकारों को चिह्नित करती है जिन्हें यह जांचता नहीं है।

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

मान लीजिए `Sample.pptx` की स्लाइड 1 में `Layout` नामक एक समूह है जिसका अनग्रुपिंग लॉक है, उसके अंदर `Photo` नामक एक चित्र है जिसका कटाव लॉक है, और `Free` नामक एक अनलॉक आयत है। रिपोर्ट `Free` को छोड़ देती है और ये दो पंक्तियाँ प्रिंट करती है:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

रिपोर्ट संग्रहित आकार-स्तर संपादन फ़्लैग को बदले बिना या प्रस्तुति को सहेजे बिना पढ़ती है। दस्तावेज़-स्तर लिखने की सुरक्षा एक अलग सेटिंग है, और प्रत्येक फ़्लैग का प्रवर्तन संपादक पर निर्भर करता है।

### **निष्कर्ष**

Aspose.Slides for PHP via Java आपको व्यक्तिगत आकारों पर विशिष्ट संपादन कार्यों को प्रतिबंधित करने या स्लाइडों के बीच समान प्रतिबंध लागू करने की सुविधा देता है। प्रत्येक आकार प्रकार द्वारा समर्थित लॉक चुनें, और जब आप इन प्रतिबंधों को हटाना चाहते हों तो उनके मान `false` सेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही प्रस्तुति में आकार लॉक और पासवर्ड सुरक्षा को मिलाकर उपयोग कर सकता हूँ?**

हाँ। आकार लॉक विशिष्ट संपादन कार्यों को प्रतिबंधित करते हैं, जबकि [पासवर्ड सुरक्षा](/slides/hi/php-java/password-protected-presentation/) प्रस्तुति को खोलने या संशोधित करने को प्रतिबंधित कर सकता है। आप दोनों को एक ही फ़ाइल में उपयोग कर सकते हैं।

**क्या मैं विशिष्ट स्लाइडों पर संपादन को प्रतिबंधित कर सकता हूँ बिना अन्य स्लाइडों को प्रभावित किए?**

हाँ। केवल चुनी गई स्लाइडों पर आकारों को लॉक लागू करें। यह अन्य स्लाइडों पर लॉक सेटिंग्स को बदलता नहीं है।

**मैं समूह के भीतर व्यक्तिगत आकारों पर लॉक कैसे लागू करूँ?**

समूह की [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) मेथड द्वारा लौटाए गए संग्रह के माध्यम से क्रमबद्ध करें और प्रत्येक चाइल्ड आकार पर उपयुक्त लॉक लागू करें। नेस्टेड समूहों के लिए भी यही प्रक्रिया दोहराएँ, रिपोर्टिंग उदाहरण में देखे गए क्रमबद्धन का पालन करें।