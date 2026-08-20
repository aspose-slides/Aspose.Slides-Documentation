---
title: PHP में प्रस्तुति आकार प्रबंधित करें
linktitle: आकृति संचालन
type: docs
weight: 40
url: /hi/php-java/shape-manipulations/
keywords:
  - PowerPoint आकार
  - प्रस्तुति आकार
  - स्लाइड पर आकार
  - आकार खोजें
  - आकार क्लोन करें
  - आकार हटाएँ
  - आकार छुपाएँ
  - आकार क्रम बदलें
  - इंटरऑप आकार ID प्राप्त करें
  - आकार वैकल्पिक पाठ
  - आकार लेआउट फ़ॉर्मेट
  - आकार SVG रूप में
  - आकार को SVG में
  - आकार संरेखित करें
  - आकार फ्लिप करें
  - PowerPoint
  - प्रस्तुति
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति आकारों की पहचान, क्लोन, हटाना, छुपाना, क्रम बदलना, निर्यात, संरेखण और फ्लिप करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java स्लाइड पर आकृतियों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोज और संशोधित कर सकते हैं और उनका स्टैक क्रम निर्धारित होता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति है।

यह लेख उसी मॉडल का पालन करता है। यह पहले यह समझाता है कि आकृति की विश्वसनीय पहचान कैसे करें, फिर क्लोन, हटाना, छुपाना और क्रम बदलने को दर्शाता है। अंतिम भाग लेआउट-स्तरीय स्वरूपण, SVG निर्यात, संरेखण और फ्लिप सेटिंग्स को कवर करते हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल उन संचालन का उपयोग कर सकते हैं जो आपके कार्यप्रवाह के लिए आवश्यक हैं।

## **आकृतियों की पहचान और खोज**

संग्रह इंडेक्स एक ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। किसी आकृति को जोड़ना, हटाना या क्रम बदलना उसके इंडेक्स को बदल सकता है। पहचानकर्ता का चयन प्रस्तुति के निर्माण और रखरखाव के तरीके के अनुसार करें:

- [Name](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getname/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के सेलेक्शन पैन में आसानी से जांची जा सकती है। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड इन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getalternativetext/) तब उपयोगी है जब कोई अभिगम्यता विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, स्थानीयकृत या अभिगम्यता के लिए पुनः लिखा जा सकता है, और यह अद्वितीय नहीं होता। अर्थपूर्ण अभिगम्यता पाठ को डेटाबेस कुंजी के रूप में चुपचाप पुन: उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getofficeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होता है और PowerPoint इंटरऑप द्वारा उपयोग किए गए आकार ID से मेल खाता है। PowerPoint के साथ एकीकृत करते समय या किसी आकार के जीवनकाल के दौरान अस्पष्ट नहीं रहने वाले संदर्भ की आवश्यकता होने पर इसे उपयोग करें। एक क्लोन किया हुआ या पुनः निर्मित आकार अलग होता है और इसका अपना ID प्राप्त करता है।

संबंधित [Shape::getUniqueId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getuniqueid/) मेथड प्रस्तुति सीमा वाला पहचानकर्ता लौटाता है, लेकिन यह पहचानकर्ता ऐड‑इन के लिए अभिप्रेत है और पुनः सौंपा जा सकता है। इसे स्थायी बाहरी कुंजी रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो अनुप्रयोग डेटा में मैपिंग रखें और पुष्टि करें कि अपेक्षित आकार अभी भी मौजूद है।

निम्न उदाहरण नाम द्वारा सटीक तुलना के साथ खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकार नहीं होता, तो कोड उस परिणाम को रिपोर्ट करता है बजाय गलत वस्तु के साथ जारी रहने के।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

जब कोई संचालन किसी आकार प्रकार के लिए विशिष्ट हो, तो प्रकार‑विशिष्ट सदस्यों का उपयोग करने से पहले रनटाइम क्लास की जाँच करें। यह उदाहरण टेक्स्ट और वैकल्पिक टेक्स्ट को तभी अपडेट करता है जब नामित वस्तु एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) हो।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **आकार संग्रह को संशोधित करें**

add, clone, remove, और reorder मेथड्स तुरंत संग्रह पर कार्य करते हैं। यदि कोई संचालन आकारों की संख्या या क्रम बदलता है, तो उस संचालन से पहले प्राप्त किए गए इंडेक्स पर निर्भर नहीं रहें।

### **एक आकार को क्लोन करें**

[ShapeCollection::addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और इसे लक्ष्य संग्रह में जोड़ता है। [ShapeCollection::insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/insertclone/) भी प्रतिलिपि बनाता है लेकिन इसे निर्दिष्ट z‑order इंडेक्स पर रखता है। वे ओवरलोड जो निर्देशांक स्वीकार करते हैं, क्लोन को उसके आकार बदले बिना स्थानांतरित करते हैं; चौड़ाई और ऊँचाई वाले ओवरलोड इसे पुनः आकार भी दे सकते हैं।

उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबल वाले आयत को आगे की ओर क्लोन करता है, और दूसरे क्लोन को पीछे जोड़ता है। किसी भी क्लोन में परिवर्तन स्रोत आकार को संशोधित नहीं करता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

क्लोनिंग आकार की सामग्री और स्वरूपण को कॉपी करती है, जिसमें उसका नाम और वैकल्पिक पाठ भी शामिल है। जब इन मानों को अद्वितीय होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता असाइन करें। जटिल आकारों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन एक नया संग्रह आइटम रहता है जिसका नया आकार पहचान है।

### **आकृतियों को हटाएँ**

[ShapeCollection::remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/remove/) एक विशिष्ट आकार ऑब्जेक्ट को उसके संग्रह से हटा देता है। जब इंडेक्स्ड इटरेशन के दौरान कई मैच हटाए जा रहे हों, तो अंत से traverse करें ताकि प्रत्येक शेष इंडेक्स वैध बना रहे।

यह उदाहरण एक निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह वर्तमान इंडेक्स पर आकार पढ़ता है, न कि किसी निश्चित संग्रह आइटम को, और यह आकार को अनावश्यक रूप से कास्ट नहीं करता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

हटाने के बाद, आकारों की संख्या और बाद के आकारों के इंडेक्स बदल जाते हैं। अप्रभावित आकारों के संदर्भ बचाए गए इंडेक्स की तुलना में अधिक भरोसेमंद रहते हैं। साथ ही कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गए ऑब्जेक्ट का संदर्भ दे सकते हैं; एक दृश्यमान आकार को हटाने से स्लाइड की उपस्थिति से अधिक बदल सकता है।

### **एक आकार को छुपाएँ**

[Shape::setHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/sethidden/) को `true` पर सेट करने से आकार संग्रह में रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। इसका इंडेक्स, स्वरूपण और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए छुपाना वैकल्पिक तत्वों के लिए उपयुक्त है जिन्हें बाद में पुनर्स्थापित किया जा सकता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

छुपाना विलोपन या सुरक्षा नहीं है। ऑब्जेक्ट अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अनहिडन किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑क्रम बदलें**

ओवरलैपिंग आकारों को संग्रह क्रम में चित्रित किया जाता है। [ShapeCollection::reorder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/reorder/) एक मौजूदा आकार को क्लोन किए बिना लक्ष्य इंडेक्स पर ले जाता है। इंडेक्स `0` पीछे है; `size() - 1` आगे है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आयत पहले बनता है और प्रारंभ में दीर्घवृत्त के पीछे रहता है। इसे अंतिम इंडेक्स पर ले जाने से यह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद z‑order को समाप्त करें, क्योंकि ये संचालन नए संग्रह आइटम जोड़ते या डालते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के अलग-अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थान वाली आकृति के समान वस्तु नहीं होता। जब आपको लेआउट द्वारा प्रदान किए गए स्वरूपण को समझने या बदलने की आवश्यकता हो, तो लेआउट आकारों का निरीक्षण करें।

निम्न उदाहरण प्रत्येक लेआउट आकार के [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getfillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getlineformat/) को पढ़ता है, बिना यह मानते हुए कि हर आकार `AutoShape` है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

लेआउट को संपादित करने से उन कई स्लाइडों पर प्रभाव पड़ सकता है जो उसका उपयोग करती हैं। लेआउट आकार को बदलने से पहले निर्धारित करें कि क्या सामान्य स्लाइड वस्तु को विरासत में लेती है या स्थानीय ओवरराइड रखती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[Shape::writeAsSvg](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकार होता है, पूरे स्लाइड पृष्ठभूमि या पड़ोसी आकृतियों नहीं।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

रेंडरिंग के दौरान प्रस्तुति को खुले रखें। आउटपुट आकार के स्वरूपण और फ़ॉन्ट तथा इमेज जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर स्ट्रीम का मालिक होता है और उसे बंद करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/alignshapes/) ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। स्लाइड किनारों का उपयोग करने के लिए `alignToSlide` को `true` सेट करें; चुनी हुई आकृतियों को एक-दूसरे के सापेक्ष संरेखित करने के लिए इसे `false` सेट करें।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकार संदर्भों को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में बदल दिया जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

संरेखण स्थिति बदलता है, न कि z‑order। सापेक्ष संरेखण के लिए सामान्यतः कम से कम दो आकार चाहिए, जबकि क्षैतिज या ऊर्ध्विक वितरण के लिए अंतराल निर्धारित करने के लिए पर्याप्त आकार चाहिए। यदि आप मेथड को कॉल करने से पहले संग्रह को संशोधित करते हैं तो इंडेक्स पुनः गणना करें।

## **एक आकार को फ्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और ऊर्ध्विक फ्लिप सेटिंग्स, तथा घूर्णन को संग्रहीत करती है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/php-java/aspose.slides/nullablebool/): `True` फ्लिप सक्षम करता है, `False` इसे निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुतीकरण एक अनफ़्लिप्ड आकार शामिल करता है।

![फ्लिप करने से पहले की आकृति](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setframe/) असाइन करने से संपूर्ण फ्रेम प्रतिस्थापित हो जाता है।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजा गया आकार क्षैतिज और ऊर्ध्विक दोनों दिशा में प्रतिबिंबित हो जाता है जबकि उसकी स्थिति, आकार और घूर्णन बरकरार रहते हैं।

![फ्लिप करने के बाद की आकृति](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह इंडेक्स उपयोग होने से पहले नहीं बदलता। निर्मित टेम्पलेट्स के लिए मान्य `Name` या `AlternativeText` नामकरण नियम को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `OfficeInteropShapeId`।

**क्या एक आकार को छुपाने से वह z‑order से हट जाता है?**

नहीं। छुपाया गया आकार समान इंडेक्स पर संग्रह में रहता है। इसे खोजा, क्रम बदल सकता है, संपादित कर सकता है, या फिर से दृश्य बना सकता है।

**क्लोन किए गए आकार का दूसरे आकार के सामने प्रकट क्यों हुआ?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का अग्र भाग होता है। प्रारंभिक इंडेक्स चुनने के लिए `insertClone` का उपयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।