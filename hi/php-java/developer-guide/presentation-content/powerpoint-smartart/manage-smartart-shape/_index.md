---
title: PHP का उपयोग करके प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/php-java/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफिक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुंचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके PHP में PowerPoint SmartArt निर्माण, संपादन और शैलीकरण को स्वचालित करें, संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में प्रोग्रामेटिक रूप से SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि स्लाइड में SmartArt आकार कैसे जोड़ा जाए, मौजूदा SmartArt आकारों तक कैसे पहुंचा जाए, विशिष्ट लेआउट प्रकार द्वारा SmartArt कैसे पाया जाए, और SmartArt शैली या रंग शैली बदलकर इसकी दृश्य उपस्थिति कैसे अपडेट की जाए।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के shape संग्रह के माध्यम से SmartArt आकारों के साथ कैसे काम किया जाए, यह जांचा जाए कि कोई आकार SmartArt है या नहीं और फिर उसकी गुणधर्मों को संशोधित या निरीक्षण किया जाए।

## **SmartArt आकार बनाना**
Aspose.Slides for PHP via Java ने SmartArt आकार बनाने के लिए एक API प्रदान किया है। स्लाइड में SmartArt आकार बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएँ।
1. उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. [SmartArt आकार जोड़ें](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addSmartArt) और उसे [LayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArtLayoutType) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```php
  # प्रस्तुति क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art आकार जोड़ें
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # प्रस्तुति सहेजें
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: स्लाइड में जोड़ा गया SmartArt आकार**|

## **स्लाइड पर SmartArt आकार तक पहुँचना**
निम्नलिखित कोड प्रस्तुति स्लाइड में जोड़े गए SmartArt आकारों तक पहुँचने के लिए उपयोग किया जाएगा। नमूना कोड में हम स्लाइड के प्रत्येक आकार को पार करेंगे और जांचेंगे कि क्या वह एक [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) आकार है। यदि आकार SmartArt प्रकार का है तो हम उसे [**SmartArt**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) इंस्टेंस में टाइपकास्ट करेंगे।

```php
  # वांछित प्रस्तुति लोड करें
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # पहली स्लाइड के सभी आकारों के माध्यम से चलें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # जाँचें कि आकार SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # आकार को SmartArtEx में टाइपकास्ट करें
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **विशिष्ट लेआउट प्रकार के साथ SmartArt आकार तक पहुँचना**
निम्नलिखित नमूना कोड आपको विशिष्ट LayoutType वाले [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) आकार तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt की LayoutType को नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल तब सेट होती है जब [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) आकार जोड़ा जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएँ और SmartArt आकार वाली प्रस्तुति लोड करें।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के सभी आकारों को पार करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
1. विशिष्ट LayoutType वाले SmartArt आकार की जाँच करें और उसके बाद आवश्यक कार्य करें।

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से चलें
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # जाँचें कि आकार SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # आकार को SmartArtEx में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt लेआउट की जाँच
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt आकार शैली बदलना**
इस उदाहरण में, हम किसी भी SmartArt आकार के लिए त्वरित शैली (quick style) बदलना सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएँ और SmartArt आकार वाली प्रस्तुति लोड करें।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के सभी आकारों को पार करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
1. विशिष्ट Style वाले SmartArt आकार को खोजें।
1. SmartArt आकार के लिए नई Style सेट करें।
1. प्रस्तुति सहेजें।

```php
  # प्रेजेंटेशन क्लास का उदाहरण बनाएं
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # पहली स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से चलें
    foreach($slide->getShapes() as $shape) {
      # जाँचें कि आकार SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # आकार को SmartArtEx में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt शैली की जाँच
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt शैली बदलना
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # प्रस्तुति सहेजें
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: बदली हुई Style के साथ SmartArt आकार**|

## **SmartArt आकार रंग शैली बदलना**
इस उदाहरण में, हम किसी भी SmartArt आकार की रंग शैली बदलना सीखेंगे। निम्नलिखित नमूना कोड विशिष्ट रंग शैली वाले SmartArt आकार तक पहुँचता है और उसकी शैली बदलता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएँ और SmartArt आकार वाली प्रस्तुति लोड करें।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के सभी आकारों को पार करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SmartArt) प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
1. विशिष्ट Color Style वाले SmartArt आकार को खोजें।
1. SmartArt आकार के लिए नई Color Style सेट करें।
1. प्रस्तुति सहेजें।

```php
  # प्रेजेंटेशन क्लास का उदाहरण बनाएं
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # पहली स्लाइड प्राप्त करें
    $slide = $pres->getSlides()->get_Item(0);
    # पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से चलें
    foreach($slide->getShapes() as $shape) {
      # जाँचें कि आकार SmartArt प्रकार का है
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # आकार को SmartArtEx में टाइपकास्ट करें
        $smart = $shape;
        # SmartArt रंग प्रकार की जाँच
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt रंग प्रकार बदलना
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # प्रस्तुति सहेजें
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: बदली हुई Color Style के साथ SmartArt आकार**|

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SmartArt को एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**

हाँ। SmartArt एक आकार है, इसलिए आप अन्य आकारों की तरह ही [मानक एनीमेशन](/slides/hi/php-java/powerpoint-animation/) (प्रवेश, निकास, जोर, गति पथ) एनीमेशन API के माध्यम से लागू कर सकते हैं।

**यदि मैं स्लाइड में किसी विशिष्ट SmartArt का आँतरभुक्त ID नहीं जानता तो उसे कैसे खोजूँ?**

Alternative Text (AltText) सेट करें और उस मान के आधार पर आकार को खोजें—यह लक्ष्य आकार को खोजने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य आकारों के साथ समूहित कर सकता हूँ?**

हाँ। आप SmartArt को अन्य आकारों (छवियों, तालिकाओं आदि) के साथ समूहित कर सकते हैं और फिर समूह को [हैंडल](/slides/hi/php-java/group/) कर सकते हैं।

**मैं किसी विशिष्ट SmartArt की छवि (जैसे प्रीव्यू या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**

आकार की थंबनेल/छवि निर्यात करें; लाइब्रेरी [व्यक्तिगत आकारों को रास्टर फ़ाइलों (PNG/JPG/TIFF) में रेंडर](/slides/hi/php-java/create-shape-thumbnails/) कर सकती है।

**जब पूरी प्रस्तुति को PDF में बदलते हैं तो क्या SmartArt की उपस्थिति बनी रहती है?**

हाँ। रेंडरिंग इंजन [PDF निर्यात](/slides/hi/php-java/convert-powerpoint-to-pdf/) के लिए उच्च सटीकता लक्ष्य करता है, जिसमें विभिन्न गुणवत्ता और संगतता विकल्प होते हैं।