---
title: PHP में प्रस्तुति आकारों को प्रबंधित करें
linktitle: आकार हेरफेर
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
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार लेआउट फ़ॉर्मेट्स
- आकार SVG रूप में
- आकार को SVG में
- आकार संरेखित करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में आकार बनाने, संपादित करने और अनुकूलित करने के तरीके सीखें और उच्च-प्रदर्शन PowerPoint प्रस्तुतियों को वितरित करें।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में आकारों (Shapes) के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड पर आकार कैसे खोजें, उसे क्लोन करें, हटाएँ, छुपाएँ, क्रम बदलें, उसका Interop Shape ID प्राप्त करें, और पहचान तथा आगे की प्रोसेसिंग के लिए विकल्पात्मक टेक्स्ट (Alternative Text) सेट करें।

यह भी बताता है कि आकारों के लेआउट फ़ॉर्मेट तक कैसे पहुँचें, आकार को SVG के रूप में रेंडर करें, स्लाइड पर आकारों को संरेखित करें, तथा क्षैतिज और ऊर्ध्वाधर मिररिंग के लिए फ्लिप प्रॉपर्टी का उपयोग करें। इसके अतिरिक्त, लेख में आकार संयोजन, स्टैकिंग क्रम, और आकार लॉकिंग के बारे में एक छोटा FAQ शामिल है।

## **स्लाइड पर आकार खोजें**
यह विषय एक सरल तकनीक का विवरण देगा जिससे डेवलपर्स को स्लाइड पर किसी विशिष्ट आकार को उसके आंतरिक Id का उपयोग किए बिना ढूँढ़ना आसान हो जाता है। यह जानना महत्वपूर्ण है कि PowerPoint प्रस्तुति फ़ाइलों में स्लाइड पर आकारों की पहचान करने का कोई तरीका नहीं है सिवाय आंतरिक अनोखे Id के। डेवलपर्स के लिए आंतरिक अनोखे Id के आधार पर आकार खोजना मुश्किल हो सकता है। सभी आकारों में कुछ Alt Text होता है। हम डेवलपर्स को सुझाव देते हैं कि वे विशिष्ट आकार खोजने के लिए Alternative Text का उपयोग करें। आप भविष्य में बदलने की योजना वाले ऑब्जेक्ट्स के लिए Microsoft PowerPoint का उपयोग करके वैकल्पिक टेक्स्ट निर्धारित कर सकते हैं।

किसी भी इच्छित आकार का Alternative Text सेट करने के बाद, आप Aspose.Slides for PHP via Java का उपयोग करके वह प्रस्तुति खोल सकते हैं और स्लाइड में जोड़ें गए सभी आकारों के माध्यम से इटरट कर सकते हैं। प्रत्येक इटरशन में आप आकार का Alternative Text जाँच सकते हैं और वही आकार जिसका Alternative Text मिल रहा है, वही वह आकार होगा जिसकी आपको आवश्यकता है। इस तकनीक को बेहतर तरीके से प्रदर्शित करने के लिए हमने एक मेथड बनाया है, [findShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) जो स्लाइड में विशिष्ट आकार खोजने का काम करता है और फिर वह आकार वापस देता है।

```php
  # एक Presentation क्लास का इंस्टेंस बनाएं जो प्रस्तुति फ़ाइल को दर्शाता है
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # खोजे जाने वाले आकार का वैकल्पिक टेक्स्ट
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **आकार को क्लोन करें**
Aspose.Slides for PHP via Java का उपयोग करके स्लाइड पर आकार को क्लोन करने के लिए:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्रोत स्लाइड के Shape Collection तक पहुँचें।
1. प्रस्तुति में एक नई स्लाइड जोड़ें।
1. स्रोत स्लाइड के Shape Collection से नई स्लाइड में आकार क्लोन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में एक Group Shape जोड़ता है।

```php
  # Presentation क्लास का इंस्टेंस बनाएं
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX फाइल को डिस्क पर लिखें
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार हटाएँ**
Aspose.Slides for PHP via Java डेवलपर्स को किसी भी आकार को हटाने की अनुमति देता है। किसी स्लाइड से आकार हटाने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार हटाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```php
  # Presentation ऑब्जेक्ट बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle प्रकार का ऑटोशेप जोड़ें
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार छुपाएँ**
Aspose.Slides for PHP via Java डेवलपर्स को किसी भी आकार को छुपाने की अनुमति देता है। स्लाइड पर आकार छुपाने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार छुपाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```php
  # PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # rectangle प्रकार का ऑटोशेप जोड़ें
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार का क्रम बदलें**
Aspose.Slides for PHP via Java डेवलपर्स को आकारों को पुनः क्रमित करने की सुविधा देता है। क्रम बदलने से यह निर्धारित होता है कि कौन‑सा आकार आगे है और कौन‑सा पीछे। किसी स्लाइड में आकार का क्रम बदलने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. एक आकार जोड़ें।
1. आकार के टेक्स्ट फ्रेम में कुछ पाठ जोड़ें।
1. समान निर्देशांक के साथ दूसरा आकार जोड़ें।
1. आकारों का क्रम बदलें।
1. फ़ाइल को डिस्क पर सहेजें।

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop Shape ID प्राप्त करें**
Aspose.Slides for PHP via Java डेवलपर्स को स्लाइड स्कोप में एक अनोखा Shape Identifier प्राप्त करने की अनुमति देता है, जो [getUniqueId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getuniqueid/) मेथड के विपरीत है, जो प्रेज़ेंटेशन स्कोप में अनोखा Identifier देता है। मेथड [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getofficeinteropshapeid/) को [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास में जोड़ा गया है। [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getofficeinteropshapeid/) मेथड द्वारा लौटाया गया मान Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id मान के बराबर होता है। नीचे एक नमूना कोड दिया गया है।

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # स्लाइड स्कोप में अद्वितीय आकार पहचानकर्ता प्राप्त करना
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार के लिए Alternative Text सेट करें**
Aspose.Slides for PHP via Java डेवलपर्स को किसी भी आकार का AlternateText सेट करने की अनुमति देता है। प्रस्तुति में आकारों को `Alternative Text` या [Shape Name](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setname/) मेथड द्वारा अलग‑अलग पहचाना जा सकता है। [setAlternativeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setalternativetext/) और [getAlternativeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getalternativetext/) मेथड को Aspose.Slides के साथ-साथ Microsoft PowerPoint द्वारा भी पढ़ा या सेट किया जा सकता है। इस मेथड का उपयोग करके आप किसी आकार को टैग कर सकते हैं और विभिन्न ऑपरेशन्स जैसे आकार हटाना, आकार छुपाना या स्लाइड पर आकारों को पुनः क्रमित करना कर सकते हैं। आकार का AlternateText सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. स्लाइड में कोई भी आकार जोड़ें।
1. नए जोड़े गए आकार के साथ कुछ कार्य करें।
1. आकारों के माध्यम से इटरट करके इच्छित आकार खोजें।
1. AlternativeText सेट करें।
1. फ़ाइल को डिस्क पर सहेजें।

```php
  # PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टेंस बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # rectangle प्रकार का ऑटोशेप जोड़ें
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार के लिए Layout Formats तक पहुँचें**
Aspose.Slides for PHP via Java आकार के लिए Layout Formats तक पहुँचने के लिए एक सरल API प्रदान करता है। यह लेख दर्शाता है कि आप Layout Formats कैसे एक्सेस कर सकते हैं।

नीचे एक नमूना कोड दिया गया है।

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार को SVG के रूप में रेंडर करें**
अब Aspose.Slides for PHP via Java आकार को SVG के रूप में रेंडर करने का समर्थन करता है। मेथड [writeAsSvg](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) (और उसका ओवरलोड) को [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास में जोड़ा गया है। यह मेथड आकार की सामग्री को SVG फ़ाइल के रूप में सहेजने की अनुमति देता है। नीचे दिया गया कोड स्निपेट स्लाइड के आकार को SVG फ़ाइल में एक्सपोर्ट करने का तरीका दिखाता है।

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **आकार को संरेखित करें**
Aspose.Slides आकारों को स्लाइड मार्जिन के सापेक्ष या एक‑दूसरे के सापेक्ष संरेखित करने की सुविधा देता है। इस उद्देश्य के लिए ओवरलोडेड मेथड [SlidesUtil::alignShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/alignshapes/) जोड़ा गया है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapesalignmenttype/) एन्यूमरेशन संभावित संरेखण विकल्पों को परिभाषित करता है।

**उदाहरण 1**

नीचे का स्रोत कोड आकारों को इंडेक्स 1,2 और 4 के साथ स्लाइड के शीर्ष किनारे के साथ संरेखित करता है।

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**उदाहरण 2**

निम्न उदाहरण दिखाता है कि संपूर्ण आकार संग्रह को संग्रह में सबसे नीचे स्थित आकार के सापेक्ष कैसे संरेखित किया जाए।

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Flip प्रॉपर्टी**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/) क्लास `flipH` और `flipV` प्रॉपर्टी के माध्यम से आकारों के क्षैतिज और ऊर्ध्वत मिररिंग को नियंत्रित करती है। दोनों प्रॉपर्टी का प्रकार [NullableBool](https://reference.aspose.com/slides/hi/php-java/aspose.slides/nullablebool/) है, जहाँ `True` का अर्थ है फ़्लिप, `False` का अर्थ है कोई फ़्लिप नहीं, और `NotDefined` का अर्थ है डिफ़ॉल्ट व्यवहार। ये मान आकार की [Frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getFrame) से उपलब्ध होते हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/) इंस्टेंस वर्तमान स्थिति, आकार, वांछित `flipH` और `flipV` मान, तथा रोटेशन एंगल के साथ निर्मित किया जाता है। इस इंस्टेंस को आकार की [Frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getFrame) में असाइन करने और प्रस्तुति को सहेजने से मिरर ट्रांसफ़ॉर्मेशन लागू हो जाता है और आउटपुट फ़ाइल में कमिट हो जाता है।

मान लीजिए हमारे पास sample.pptx फ़ाइल है जिसमें पहली स्लाइड में एकल आकार डिफ़ॉल्ट फ़्लिप सेटिंग के साथ है, जैसा कि नीचे दिखाया गया है।

![फ़्लिप करने के लिए आकार](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टी को प्राप्त करता है और उसे क्षैतिज तथा ऊर्ध्वत दोनों दिशा में फ़्लिप करता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // आकार की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // आकार की लंबवत फ़्लिप प्रॉपर्टी प्राप्त करें।
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // क्षैतिज रूप से फ़्लिप करें।
    $flipV = NullableBool::True; // क्षैतिज रूप से फ़्लिप करें।
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![फ़्लिप किया हुआ आकार](flipped_shape.png)

## **FAQ**

**क्या मैं डेस्कटॉप एडिटर की तरह स्लाइड पर आकारों को (union/intersect/subtract) संयोजित कर सकता हूँ?**

बिल्ट‑इन Boolean ऑपरेशन API नहीं है। आप वांछित आउटलाइन स्वयं बना कर इसे सन्निकट कर सकते हैं—उदाहरण के तौर पर GeometryPath (https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/) का उपयोग करके resulting geometry की गणना करें और उस कोंटूर के साथ एक नया आकार बनाएँ, वैकल्पिक रूप से मूल आकारों को हटा दें।

**मैं स्टैकिंग क्रम (z‑order) को कैसे नियंत्रित करूँ ताकि कोई आकार हमेशा “सबसे ऊपर” बना रहे?**

स्लाइड के [shapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getShapes) संग्रह में इन्सर्शन/मूव क्रम बदलें। पूर्वानुमानित परिणामों के लिए सभी अन्य स्लाइड परिवर्तन के बाद z‑order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को आकार संपादित करने से रोकने के लिए उसे “लॉक” कर सकता हूँ?**

हाँ। आकार‑स्तर की प्रोटेक्शन फ़्लैग सेट करें (जैसे चयन, मूवमेंट, री‑साइज़, टेक्स्ट एडिट को लॉक करना)। यदि आवश्यक हो तो मास्टर या लेआउट पर समान प्रतिबंध लगाएँ। यह UI‑स्तर की सुरक्षा है, पूर्ण सुरक्षा के लिए फ़ाइल‑स्तर प्रतिबंध जैसे [read‑only recommendations or passwords](/slides/hi/php-java/password-protected-presentation/) के साथ संयोजन करें।