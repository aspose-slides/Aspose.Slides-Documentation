---
title: PHP में प्रस्तुति थीम का प्रबंधन
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/php-java/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP (Java के माध्यम से) में प्रस्तुति थीम का मास्टर प्रबंधन करके, PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की विशेषताओं को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूल रूप से दृश्य तत्वों और उनकी विशेषताओं का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/php-java/powerpoint-fonts/), [पृष्ठभूमि शैलियाँ](/slides/hi/php-java/presentation-background/), और प्रभाव शामिल होते हैं।

![थीम-घटक](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड के विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SchemeColor) एनीमरेशन के तहत मान प्रदान करता है।

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

आप इस प्रकार परिणामी रंग का प्रभावी मान निर्धारित कर सकते हैं:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

रंग परिवर्तन ऑपरेशन को और दर्शाने के लिए, हम एक और तत्व बनाते हैं और उसे प्रारंभिक ऑपरेशन के एक्सेंट रंग को सौंपते हैं। फिर हम थीम में रंग बदलते हैं:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

नया रंग स्वचालित रूप से दोनों तत्वों पर लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग (1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट (2) से रंग बनते हैं। उसके बाद आप उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![अतिरिक्त-पैलेट-रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग

**2** - अतिरिक्त पैलेट से रंग।

यह PHP कोड एक ऑपरेशन दर्शाता है जिसमें अतिरिक्त पैलेट के रंग मुख्य थीम रंग से प्राप्त किए जाते हैं और फिर आकारों में उपयोग किए जाते हैं:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # एक्सेंट 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # एक्सेंट 4, हल्का 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # एक्सेंट 4, हल्का 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # एक्सेंट 4, हल्का 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # एक्सेंट 4, गहरा 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # एक्सेंट 4, गहरा 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor` को `ColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान होते हैं:

`Background1`, `Background2`, `Text1`, और `Text2`।

हालांकि, `Presentation::getMasterTheme()::getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) को इस प्रकार प्रकट करता है:

`Dark1`, `Dark2`, `Light1`, और `Light2`।

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट्स को संदर्भित करते हैं और नकाशा निश्चित है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील परिवर्तन नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आया है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग किए जाते थे, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य प्रयोजनों के लिए फ़ॉन्ट चुनने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में उपयोग किए गए के समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (मेजर ईस्ट एशियन फ़ॉन्ट)

यह PHP कोड दिखाता है कि कैसे लैटिन फ़ॉन्ट को एक थीम तत्व को सौंपा जाए:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

यह PHP कोड दिखाता है कि कैसे प्रस्तुति थीम फ़ॉन्ट बदलें:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

सभी टेक्स्ट बॉक्स में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाह सकते हैं [PowerPoint फ़ॉन्ट्स](/slides/hi/php-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint एप्लिकेशन 12 पूर्वनिर्धारित पृष्ठभूमियाँ प्रदान करता है, लेकिन इन 12 में से केवल 3 पृष्ठभूमियों को सामान्य प्रस्तुति में सहेजा जाता है।

![उदाहरण छवि](presentation-design_8.png)

उदाहरण के लिए, जब आप PowerPoint एप में एक प्रस्तुति सहेजते हैं, तो आप इस PHP कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) प्रॉपर्टी का उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली जोड़ या एक्सेस कर सकते हैं, जो [FormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme) क्लास से प्राप्त होती है। 
{{% /alert %}} 

यह PHP कोड दिखाता है कि कैसे प्रस्तुति के लिए पृष्ठभूमि सेट करें:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);

```

**इंडेक्स गाइड**: 0 का उपयोग कोई भराव नहीं के लिए किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="primary" title="TIP" %}} 
आप देखना चाह सकते हैं [PowerPoint पृष्ठभूमि](/slides/hi/php-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव बदलें**

PowerPoint थीम सामान्यतः प्रत्येक शैली एरे के लिए 3 मान रखती है। इन एरे को मिलाकर 3 प्रभाव बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब प्रभाव एक विशिष्ट आकार पर लागू होते हैं तो यह परिणाम मिलता है:

![उदाहरण छवि](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme) क्लास से 3 प्रॉपर्टीज़ ([FillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FormatScheme#getEffectStyles--)) का उपयोग करके थीम के तत्वों को बदल सकते हैं (PowerPoint में उपलब्ध विकल्पों से भी अधिक लचीले ढंग से)।

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

परिणामस्वरूप भराव रंग, भराव प्रकार, छाया प्रभाव आदि में परिवर्तन होते हैं:

![उदाहरण छवि](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर को बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। Aspose.Slides स्लाइड-स्तरीय थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर एक स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं (via the [SlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidethememanager/))।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

[Clone slides](/slides/hi/php-java/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में ले जाएँ। यह मूल मास्टर, लेआउट और साथ की थीम को संरक्षित रखता है ताकि रूपरेखा समान बनी रहे।

**सभी इनहेरिटेंस और ओवरराइड्स के बाद "इफ़ेक्टिव" मान कैसे देख सकते हैं?**

API के ["effective" view](/slides/hi/php-java/shape-effective-properties/) का उपयोग करके थीम/रंग/फ़ॉन्ट/प्रभाव के इफ़ेक्टिव मान देखें। ये मास्टर लागू होने के बाद तथा किसी भी स्थानीय ओवरराइड के बाद प्राप्त अंतिम गुण लौटाते हैं।