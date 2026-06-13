---
title: PHP का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/php-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें — सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन वे [भरण](/slides/hi/php-java/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाने आदि कर सकते हैं।

<img src="shape-effect.png" alt="आकार-प्रभाव" style="zoom:50%;" />

* PowerPoint आकारों पर लागू किए जा सकने वाले छह प्रभाव प्रदान करता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं। 

* कुछ प्रभाव संयोजन अन्य की तुलना में अधिक आकर्षक होते हैं। इसी कारण से, PowerPoint में **Preset** विकल्प होते हैं। Preset विकल्प मूल रूप से दो या दो से अधिक प्रभावों के एक ज्ञात सुंदर संयोजन होते हैं। इस प्रकार, एक Preset चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करके अच्छा संयोजन खोजने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/EffectFormat) क्लास के तहत ऐसी गुण और विधियां प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने देती हैं।

## **छाया प्रभाव लागू करें**

यह PHP कोड दिखाता है कि कैसे आयत पर बाहरी छाया प्रभाव ([OuterShadowEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) लागू किया जाए:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्रतिबिंब प्रभाव लागू करें**

यह PHP कोड दिखाता है कि कैसे किसी आकार पर प्रतिबिंब प्रभाव लागू किया जाए:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **चमक प्रभाव लागू करें**

यह PHP कोड दिखाता है कि कैसे किसी आकार पर चमक प्रभाव लागू किया जाए:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

यह PHP कोड दिखाता है कि कैसे किसी आकार पर सॉफ्ट एजेज़ प्रभाव लागू किया जाए:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों, जैसे छाया, प्रतिबिंब और चमक, को संयोजित करके अधिक गतिशील रूप दे सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहबद्ध आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहबद्ध आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।