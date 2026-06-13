---
title: PHP में समूह प्रस्तुति आकार
linktitle: आकार समूह
type: docs
weight: 40
url: /hi/php-java/group/
keywords:
- समूह आकार
- आकार समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint डेक में आकार को समूहित और अनसमूहित करना सीखें — तेज़, चरण-दर-चरण गाइड मुफ्त कोड के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में समूह आकारों के साथ काम करने का तरीका समझाता है। यह दिखाता है कि स्लाइड में समूह आकार कैसे जोड़ें, उसके भीतर आकार रखें, और अपडेटेड प्रस्तुति को सहेजें। यह यह भी दर्शाता है कि समूह के भीतर संग्रहीत आकारों तक कैसे पहुँचें और उनके `AlternativeText` मान पढ़ें। अतिरिक्त रूप से, लेख संक्षेप में संबंधित समूह‑आकार क्षमताओं जैसे नेस्टेड समूह, ज़‑ऑर्डर, और लॉकिंग विकल्पों को कवर करता है।

## **समूह आकार जोड़ें**
Aspose.Slides स्लाइड पर समूह आकारों के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रस्तुतियों का समर्थन करने में मदद करती है। Aspose.Slides for PHP via Java समूह आकारों को जोड़ने या एक्सेस करने का समर्थन करता है। जोड़े गए समूह आकार में आकार जोड़ना संभव है ताकि उसे भर सकें या समूह आकार की कोई भी प्रॉपर्टी एक्सेस कर सकें। Aspose.Slides for PHP via Java का उपयोग करके स्लाइड में समूह आकार जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
3. स्लाइड में एक समूह आकार जोड़ें।
4. जोड़े गए समूह आकार में आकार जोड़ें।
5. संशोधित प्रस्तुति को एक PPTX फ़ाइल के रूप में सहेजें।

```php
  # Presentation क्लास को इंस्टैंटिएट करें
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # स्लाइड्स के आकार संग्रह तक पहुंचना
    $slideShapes = $sld->getShapes();
    # स्लाइड में समूह आकार जोड़ना
    $groupShape = $slideShapes->addGroupShape();
    # जोड़े गए समूह आकार के भीतर आकार जोड़ना
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # समूह आकार फ्रेम जोड़ना
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTX फ़ाइल को डिस्क पर लिखें
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **AltText प्रॉपर्टी तक पहुँचें**
यह विषय सरल कदम दिखाता है, कोड उदाहरणों के साथ, समूह आकार जोड़ने और स्लाइड पर समूह आकारों की AltText प्रॉपर्टी तक पहुँचने के लिए। Aspose.Slides for PHP via Java का उपयोग करके स्लाइड में समूह आकार की AltText तक पहुँचने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
2. स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
3. स्लाइड्स के आकार संग्रह तक पहुँचें।
4. समूह आकार तक पहुँचें।
5. [वैकल्पिक पाठ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getAlternativeText) प्रॉपर्टी तक पहुँचें।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
  $pres = new Presentation("AltText.pptx");
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # स्लाइड्स के आकार संग्रह तक पहुंचना
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # समूह आकार तक पहुंचना।
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # AltText प्रॉपर्टी तक पहुंचना
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या नेस्टेड ग्रुपिंग (एक समूह के अंदर एक समूह) समर्थित है?**

हाँ। [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/) में [getParentGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getparentgroup/) मेथड है, जो सीधे पदानुक्रम समर्थन को दर्शाता है (एक समूह दूसरे समूह का चाइल्ड हो सकता है)।

**समूह के z-order को स्लाइड पर अन्य वस्तुओं के सापेक्ष कैसे नियंत्रित करें?**

डिस्प्ले स्टैक में उसकी स्थिति को निरीक्षण करने के लिए [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/) की [getZOrderPosition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getzorderposition/) मेथड का उपयोग करें।

**क्या मैं मूविंग/एडिटिंग/अन्ग्रुपिंग को रोक सकता हूँ?**

हाँ। समूह का लॉक सेक्शन [GroupShapeLock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/getgroupshapelock/) के माध्यम से उजागर किया गया है, जिससे आप ऑब्जेक्ट पर कार्यों को प्रतिबंधित कर सकते हैं।