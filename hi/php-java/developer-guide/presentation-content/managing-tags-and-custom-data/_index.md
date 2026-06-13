---
title: PHP का उपयोग करके प्रस्तुतियों में टैग्स और कस्टम डेटा को प्रबंधित करें
linktitle: टैग्स और कस्टम डेटा
type: docs
weight: 300
url: /hi/php-java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- टैग जोड़ें
- जुड़ी हुई मान
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में टैग्स और कस्टम डेटा को जोड़ना, पढ़ना, अपडेट करना और हटाना सीखें, साथ ही PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग्स और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, यह नोट करता है कि प्रस्तुति‑विशिष्ट डेटा टैग्स और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग्स को कुंजी‑मान स्ट्रिंग जोड़े के रूप में वर्णित करता है।

यह भी दिखाता है कि टैग मान कैसे पढ़ें और प्रस्तुति, व्यक्तिगत स्लाइड या शैप में टैग कैसे जोड़ें। अतिरिक्त रूप से, लेख सामान्य टैग‑प्रबंधन कार्यों को कवर करता है जैसे सभी टैग्स को साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना।

## **डेटा संग्रहण प्रस्तुति फ़ाइलों में**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली वस्तुएँ—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML फ़ॉर्मेट प्रस्तुतियों में मौजूद डेटा की संरचना को परिभाषित करता है।

*स्लाइड* प्रस्तुतियों के तत्वों में से एक है, एक *स्लाइड पार्ट* एकल स्लाइड की सामग्री रखता है। एक स्लाइड पार्ट को ISO/IEC 29500 द्वारा परिभाषित कई भागों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति है।

कस्टम डेटा (प्रस्तुति‑विशिष्ट) या उपयोगकर्ता टैग्स ([TagCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/)) और CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/customxmlpartcollection/)) के रूप में मौजूद हो सकता है।

{{% alert color="primary" %}} 
टैग मूलतः स्ट्रिंग‑की जोड़ी मान होते हैं। 
{{% /alert %}} 

## **टैग्स के मान प्राप्त करें**

स्लाइड्स में, एक टैग [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getKeywords) और [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#setKeywords) विधियों के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for PHP via Java के साथ [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) के लिए टैग का मान कैसे प्राप्त किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्रस्तुतियों में टैग जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो आइटमों से बना होता है:

- कस्टम प्रॉपर्टी का नाम - `MyTag`
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रस्तुतियों को विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो आप उन प्रस्तुतियों में टैग जोड़कर लाभ उठा सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की सभी प्रस्तुतियों को एक साथ वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (U.S., Mexico, और Canada) को मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दर्शाता है कि Aspose.Slides for PHP via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) में टैग कैसे जोड़ें:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

टैग्स को [Slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

या किसी भी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) के लिए:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **सीमाएँ**

`getCustomData()->getTags()` का उपयोग करके कस्टम डेटा टैग संग्रह द्वारा जोड़े गए टैग केवल PowerPoint फ़ाइल के भीतर संग्रहीत होते हैं। जब प्रस्तुति को PDF में निर्यात किया जाता है, तो वे PDF टैग संरचना में **स्थानांतरित** नहीं होते। परिणामस्वरूप, टैग के रूप में सौंपा गया कस्टम पहचानकर्ता टैग्ड PDF से पुनः प्राप्त नहीं किया जा सकता।

**Workaround**: आप ऑब्जेक्ट के **Alt Text** (उदाहरण के लिए `$shape->setAlternativeText("MyId")`) में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **FAQ**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या शैप से सभी टैग हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़े को एक साथ हटाता है।

**मैं पूरे संग्रह को इटरेट किए बिना नाम द्वारा एकल टैग कैसे हटाऊं?**

[tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) पर [remove(name)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/remove/) ऑपरेशन का उपयोग करके टैग को उसकी कुंजी द्वारा हटाएं।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/) पर [getNamesOfTags](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tagcollection/getnamesoftags/) का उपयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।