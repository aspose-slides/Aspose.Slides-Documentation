---
title: PHP का उपयोग करके प्रस्तुतियों में SmartArt शेप नोड्स प्रबंधित करें
linktitle: SmartArt शेप नोड
type: docs
weight: 30
url: /hi/php-java/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुंचें
- नोड हटाएं
- कस्टम स्थिति
- असिस्टेंट नोड
- फ़िल फ़ॉर्मेट
- नोड रेंडर
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PPT और PPTX में SmartArt शेप नोड्स प्रबंधित करें। स्पष्ट कोड नमूने और टिप्स प्राप्त करें ताकि आप अपनी प्रस्तुतियों को प्रभावी बना सकें।"
---
## **परिचय**

PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स को उन नोड्स के माध्यम से व्यवस्थित किया जाता है जिनमें टेक्स्ट होता है और जो आरेख की संरचना को निर्धारित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड्स और चाइल्ड नोड्स जोड़ना, किसी विशिष्ट स्थिति पर चाइल्ड नोड्स सम्मिलित करना, मौजूदा नोड्स तक पहुंचना, और उनका टेक्स्ट, स्तर और स्थिति पढ़ना।

यह लेख SmartArt शेप नोड्स को प्रबंधित करने के तरीकों को बताता है। यह दिखाता है कि नोड्स को कैसे हटाया जाए, इंडेक्स या स्थिति के आधार पर चाइल्ड नोड्स के साथ कैसे काम किया जाए, एक असिस्टेंट नोड को सामान्य नोड में कैसे बदला जाए, SmartArt नोड शेप्स की स्थिति, आकार और रोटेशन कैसे समायोजित किए जाएँ, नोड फ़िल फ़ॉर्मेट कैसे सेट किया जाए, और SmartArt चाइल्ड नोड की थंबनेल छवि कैसे जेनरेट की जाए।

## **SmartArt नोड जोड़ें**
Aspose.Slides for PHP via Java ने SmartArt शेप्स को आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। निम्नलिखित सैंपल कोड SmartArt शेप के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

1. एक नया [प्रस्तुति](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. [एक नया नोड जोड़ें](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnodecollection/#addNode) SmartArt शेप में [**NodeCollection**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/#getAllNodes) और टेक्स्टफ़्रेम में टेक्स्ट सेट करें।  
6. अब, [जोड़ें](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnodecollection/#addNode) एक [**चाइल्ड नोड**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getChildNodes) नवीन जोड़े गए [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) नोड में और टेक्स्टफ़्रेम में टेक्स्ट सेट करें।  
7. प्रस्तुति सहेजें।

```php
  # वांछित प्रस्तुति लोड करें
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        # एक नया SmartArt नोड जोड़ें
        $TemNode = $smart->getAllNodes()->addNode();
        # टेक्स्ट जोड़ें
        $TemNode->getTextFrame()->setText("Test");
        # पैरेंट नोड में नया चाइल्ड नोड जोड़ें। यह कलेक्शन के अंत में जोड़ा जाएगा
        $newNode = $TemNode->getChildNodes()->addNode();
        # टेक्स्ट जोड़ें
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # प्रस्तुति सहेजें
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
निम्नलिखित सैंपल कोड में हम यह समझाते हैं कि कैसे SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को विशेष स्थिति पर जोड़ा जाए।

1. Presentation वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. एक्सेस की गई स्लाइड में [**StackedList**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt शेप जोड़ें।  
4. जोड़े गए SmartArt शेप में पहला नोड एक्सेस करें।  
5. अब, चयनित [**नोड**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtNode) के लिए स्थिति 2 पर [**चाइल्ड नोड**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getChildNodes) जोड़ें और उसका टेक्स्ट सेट करें।  
6. प्रस्तुति सहेजें।

```php
  # प्रेजेंटेशन इंस्टेंस बना रहे हैं
  $pres = new Presentation();
  try {
    # प्रेजेंटेशन स्लाइड तक पहुंचें
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art IShape जोड़ें
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # इंडेक्स 0 पर SmartArt नोड एक्सेस कर रहे हैं
    $node = $smart->getAllNodes()->get_Item(0);
    # पैरेंट नोड में स्थिति 2 पर नया चाइल्ड नोड जोड़ें
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # टेक्स्ट जोड़ें
    $chNode->getTextFrame()->setText("Sample Text Added");
    # प्रेजेंटेशन सहेजें
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt नोड तक पहुंचें**
निम्नलिखित सैंपल कोड SmartArt शेप के अंदर नोड्स तक पहुंचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल शेप जोड़ते समय सेट किया जाता है।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. SmartArt शेप के अंदर सभी [**Nodes**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।  
6. SmartArt नोड की स्थिति, स्तर और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

```php
  # Presentation क्लास का इंस्टेंस बनाना
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # पहली स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($slide->getShapes() as $shape) {
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt के अंदर सभी नोड्स को ट्रैवर्स करें
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # इंडेक्स i पर SmartArt नोड एक्सेस कर रहे हैं
          $node = $smart->getAllNodes()->get_Item($i);
          # SmartArt नोड पैरामीटर प्रिंट कर रहे हैं
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt चाइल्ड नोड तक पहुंचें**
निम्नलिखित सैंपल कोड SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स तक पहुंचने में मदद करेगा।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. SmartArt शेप के अंदर सभी [**Nodes**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।  
6. प्रत्येक चयनित SmartArt शेप [**Node**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtNode) के लिए, विशेष नोड के अंदर सभी [**Child Nodes**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtNode#getChildNodes--) को ट्रैवर्स करें।  
7. [**Child Node**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getChildNodes) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

```php
  # Presentation क्लास का इंस्टेंस बनाना
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # पहली स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($slide->getShapes() as $shape) {
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt के अंदर सभी नोड्स को ट्रैवर्स करें
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # इंडेक्स i पर SmartArt नोड एक्सेस कर रहे हैं
          $node0 = $smart->getAllNodes()->get_Item($i);
          # इंडेक्स i पर SmartArt नोड के चाइल्ड नोड्स को ट्रैवर्स कर रहे हैं
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # SmartArt नोड में चाइल्ड नोड एक्सेस कर रहे हैं
            $node = $node0->getChildNodes()->get_Item($j);
            # SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड तक पहुंचें**
इस उदाहरण में हम जानेंगे कि कैसे विशेष स्थिति पर SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स तक पहुंचा जाए।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. [**StackedList**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt शेप जोड़ें।  
4. जोड़े गए SmartArt शेप को एक्सेस करें।  
5. एक्सेस किए गए SmartArt शेप के लिए इंडेक्स 0 पर नोड एक्सेस करें।  
6. अब, एक्सेस किए गए SmartArt नोड के लिए **get_Item()** मेथड का उपयोग कर स्थिति 1 पर [**Child Node**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getChildNodes) एक्सेस करें।  
7. [**Child Node**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/#getChildNodes) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

```php
  # प्रस्तुति को इंस्टैंशिएट कर रहे हैं
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुंच रहे हैं
    $slide = $pres->getSlides()->get_Item(0);
    # पहली स्लाइड में SmartArt आकृति जोड़ रहे हैं
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # इंडेक्स 0 पर SmartArt नोड तक पहुंच रहे हैं
    $node = $smart->getAllNodes()->get_Item(0);
    # पैरेंट नोड में स्थिति 1 पर चाइल्ड नोड तक पहुंच रहे हैं
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt नोड हटाएं**
इस उदाहरण में हम SmartArt शेप के अंदर नोड्स को हटाना सीखेंगे।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. जाँचें कि [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में 0 से अधिक नोड हैं।  
6. हटाए जाने वाले SmartArt नोड का चयन करें।  
7. अब, चयनित नोड को [**removeNode**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnodecollection/#removeNode) मेथड का उपयोग करके हटाएं।  
8. प्रस्तुति सहेजें।

```php
  # वांछित प्रस्तुति लोड करें
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # इंडेक्स 0 पर SmartArt नोड एक्सेस कर रहे हैं
          $node = $smart->getAllNodes()->get_Item(0);
          # चयनित नोड को हटा रहे हैं
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # प्रस्तुति सहेजें
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **विशिष्ट स्थिति से SmartArt नोड हटाएं**
इस उदाहरण में हम विशेष स्थिति पर SmartArt शेप के अंदर नोड्स को हटाना सीखेंगे।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. इंडेक्स 0 पर SmartArt शेप नोड का चयन करें।  
6. अब, जाँचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं।  
7. अब, **Position 1** पर नोड को [**removeNode**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnodecollection/#removeNode) मेथड का उपयोग करके हटाएं।  
8. प्रस्तुति सहेजें।

```php
  # वांछित प्रस्तुति लोड करें
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # इंडेक्स 0 पर SmartArt नोड एक्सेस कर रहे हैं
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # स्थिति 1 पर चाइल्ड नोड को हटा रहे हैं
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # प्रस्तुति सहेजें
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम स्थिति सेट करें**
Aspose.Slides for PHP via Java [SmartArtShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtShape) की [X](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setX) और [Y](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#setY) प्रॉपर्टी सेट करने का समर्थन करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape की स्थिति, आकार और रोटेशन सेट किया जाए। कृपया ध्यान दें कि नए नोड्स जोड़ने से सभी नोड्स की स्थितियों और आकारों की पुनः गणना होती है। कस्टम स्थिति सेटिंग के साथ उपयोगकर्ता आवश्यकता अनुसार नोड्स को सेट कर सकता है।

```php
  # प्रेजेंटेशन क्लास का इंस्टेंस बनाएं
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # SmartArt आकृति को नई स्थिति में ले जाएँ
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # SmartArt आकृति की चौड़ाई बदलें
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # SmartArt आकृति की ऊँचाई बदलें
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # SmartArt आकृति का घूर्णन बदलें
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **असिस्टेंट नोड जांचें**
{{% alert color="primary" %}} 

इस लेख में हम Aspose.Slides for PHP via Java का उपयोग करके प्रस्तुति स्लाइड्स में प्रोग्रामेटिक रूप से जोड़े गए SmartArt शेप्स की सुविधाओं की आगे जाँच करेंगे।

{{% /alert %}} 

हम इस लेख के विभिन्न भागों में जांच के लिए निम्नलिखित स्रोत SmartArt शेप का उपयोग करेंगे।

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड में स्रोत SmartArt शेप**|

निम्नलिखित सैंपल कोड में हम यह जांचेंगे कि कैसे **Assistant Nodes** को पहचानें और उन्हें बदलें।

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं और SmartArt शेप के साथ प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके दूसरी स्लाइड का संदर्भ प्राप्त करें।  
3. पहली स्लाइड के अंदर प्रत्येक शेप को ट्रैवर्स करें।  
4. जाँचें कि शेप [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) प्रकार का है और यदि वह SmartArt है तो चयनित शेप को [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) में टाइपकास्ट करें।  
5. SmartArt शेप के सभी नोड्स को ट्रैवर्स करें और जांचें कि क्या वे [**Assistant Nodes**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtNode#isAssistant--) हैं।  
6. Assistant Node की स्थिति को सामान्य नोड में बदलें।  
7. प्रस्तुति सहेजें।

```php
  # प्रेजेंटेशन इंस्टेंस बना रहे हैं
  $pres = new Presentation("AddNodes.pptx");
  try {
    # पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # जाँचें कि शेप SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # शेप को SmartArt में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt शेप के सभी नोड्स को ट्रैवर्स कर रहे हैं
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # जाँचें कि नोड Assistant नोड है
          if ($node->isAssistant()) {
            # Assistant नोड को false सेट कर रहे हैं और इसे सामान्य नोड बना रहे हैं
            $node->isAssistant();
          }
        }
      }
    }
    # प्रेजेंटेशन सहेजें
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**चित्र: स्लाइड में SmartArt शेप में बदल गए Assistant Nodes**|

## **नोड का Fill फ़ॉर्मेट सेट करें**
Aspose.Slides for PHP via Java कस्टम SmartArt शेप्स जोड़ने और उनके Fill फ़ॉर्मेट को सेट करने को संभव बनाता है। यह लेख बताता है कि कैसे SmartArt शेप्स बनाएं, एक्सेस करें और उनके Fill फ़ॉर्मेट को सेट करें।

कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स का उपयोग करके एक स्लाइड का संदर्भ प्राप्त करें।  
3. उसके [**LayoutType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) को सेट करके एक SmartArt शेप जोड़ें।  
4. SmartArt शेप नोड्स के लिए [**Fill Format**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getFillFormat) सेट करें।  
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```php
  # प्रस्तुति को इंस्टैंशिएट करें
  $pres = new Presentation();
  try {
    # स्लाइड तक पहुंच रहे हैं
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt आकृति और नोड्स जोड़ रहे हैं
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # नोड के फ़िल रंग सेट कर रहे हैं
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # प्रस्तुति सहेजें
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt चाइल्ड नोड की थंबनेल बनाएं**
विकासकर्ता नीचे दिए गए चरणों का पालन करके SmartArt के चाइल्ड नोड की थंबनेल जेनरेट कर सकते हैं:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का उदाहरण बनाएं।  
2. [SmartArt जोड़ें](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnodecollection/#addNode)।  
3. इंडेक्स का उपयोग करके नोड का संदर्भ प्राप्त करें।  
4. थंबनेल छवि प्राप्त करें।  
5. थंबनेल छवि को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

```php
  # PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टैंस बनाएं
  $pres = new Presentation();
  try {
    # SmartArt जोड़ें
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # इंडेक्स का उपयोग करके नोड का संदर्भ प्राप्त करें
    $node = $smart->getNodes()->get_Item(1);
    # थंबनेल प्राप्त करें
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # थंबनेल सहेजें
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**क्या SmartArt एनीमेशन समर्थित है?**

हां। SmartArt को एक सामान्य शेप माना जाता है, इसलिए आप [मानक एनीमेशन](/slides/hi/php-java/shape-animation/) (प्रवेश, निकास, ज़ोर, मोशन पथ) लागू कर सकते हैं और टाइमिंग को समायोजित कर सकते हैं। आवश्यकता पड़ने पर आप SmartArt नोड्स के अंदर शेप्स को भी एनीमेट कर सकते हैं।

**यदि SmartArt का आंतरिक ID अज्ञात हो तो स्लाइड पर किसी विशिष्ट SmartArt को विश्वसनीय रूप से कैसे खोजें?**

[वैकल्पिक टेक्स्ट](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getalternativetext/) के द्वारा असाइन और खोज करें। SmartArt पर विशिष्ट AltText सेट करने से आप इसे प्रोग्रामेटिक रूप से आंतरिक पहचानकर्ताओं पर निर्भर किए बिना ढूंढ़ सकते हैं।

**क्या प्रस्तुति को PDF में बदलते समय SmartArt का रूप बरकरार रहेगा?**

हां। Aspose.Slides PDF निर्यात के दौरान [PDF एक्सपोर्ट](/slides/hi/php-java/convert-powerpoint-to-pdf/) में उच्च दृश्य सटीकता के साथ SmartArt को रेंडर करता है, लेआउट, रंग और इफ़ेक्ट्स को संरक्षित रखता है।

**क्या मैं पूरी SmartArt की छवि निकाल सकता हूं (पूर्वावलोकन या रिपोर्ट के लिए)?**

हां। आप SmartArt शेप को [रास्टर फ़ॉर्मेट्स](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getImage) या [SVG](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उपयुक्त स्केलेबल वेक्टर आउटपुट मिलता है।