---
title: PHP का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/php-java/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- आकार जोड़ें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP एप्लिकेशन को PowerPoint स्लाइड में रेखाओं को बनाना, जोड़ना और स्वचालित रूप से मार्ग निर्धारित करने में सक्षम बनाएँ — सीधी, कोहनी और वक्र कनेक्टरों पर पूर्ण नियंत्रण हासिल करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष रेखा है जो दो आकारों को आपस में जोड़ती या लिंक करती है और स्लाइड पर मूव या पुनःस्थापित किए जाने पर भी आकारों से जुड़ी रहती है। 

कनेक्टर आमतौर पर *कनेक्शन डॉट्स* (हरी बिंदु) से जुड़े होते हैं, जो डिफ़ॉल्ट रूप से सभी आकारों पर होते हैं। कनेक्शन डॉट्स तभी दिखाई देते हैं जब कर्सर उनके पास आता है।

*एडजस्टमेंट पॉइंट्स* (संतरीय बिंदु), जो केवल कुछ कनेक्टरों पर होते हैं, कनेक्टर की स्थितियों और आकारों को बदलने के लिए उपयोग किए जाते हैं।

## **कनेक्टर के प्रकार**

PowerPoint में, आप सीधें, कोहनी (कोणीय) और वक्र कनेक्टर का उपयोग कर सकते हैं। 

Aspose.Slides ये कनेक्टर प्रदान करता है:

| कनेक्टर | छवि | एडजस्टमेंट पॉइंट्स की संख्या |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **कनेक्टर के उपयोग से आकार जोड़ें**

1. एक [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `Shapes` ऑब्जेक्ट की `addAutoShape` मेथड का उपयोग करके स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AutoShape) जोड़ें।  
4. `Shapes` ऑब्जेक्ट की `addConnector` मेथड का उपयोग करके कनेक्टर टाइप को परिभाषित करते हुए एक कनेक्टर जोड़ें।  
5. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
6. सबसे छोटे कनेक्शन पाथ को लागू करने के लिए `reroute` मेथड को कॉल करें।  
7. प्रेजेंटेशन को सेव करें।  

यह PHP कोड दिखाता है कि दो आकारों (एक दीर्घवृत्त और एक आयत) के बीच एक कनेक्टर (एक बेंट कनेक्टर) कैसे जोड़ें:

```php
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टेंस बनाता है
  $pres = new Presentation();
  try {
    # किसी विशिष्ट स्लाइड के लिए शैप्स संग्रह तक पहुंचता है
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # एक दीर्घवृत्त ऑटोशेप जोड़ता है
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # एक आयत ऑटोशेप जोड़ता है
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # स्लाइड के शैप्स संग्रह में एक कनेक्टर आकार जोड़ता है
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # कनेक्टर का उपयोग करके आकारों को जोड़ता है
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # reroute को कॉल करता है जो आकारों के बीच स्वचालित सबसे छोटा रास्ता निर्धारित करता है
    $connector->reroute();
    # प्रस्तुति को सेव करता है
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` मेथड एक कनेक्टर को पुनः रूट करता है और उसे आकारों के बीच सबसे छोटा संभावित पाथ लेने के लिए मजबूर करता है। इस लक्ष्य को पाने के लिए, मेथड `setStartShapeConnectionSiteIndex` और `setEndShapeConnectionSiteIndex` पॉइंट्स को बदल सकता है। 
{{% /alert %}} 

## **कनेक्शन डॉट निर्दिष्ट करें**

यदि आप चाहते हैं कि कनेक्टर दो आकारों को विशिष्ट डॉट्स का उपयोग करके जोड़े, तो आपको अपनी पसंदीदा कनेक्शन डॉट्स इस प्रकार निर्दिष्ट करने होंगे:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `Shapes` ऑब्जेक्ट की `addAutoShape` मेथड का उपयोग करके स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AutoShape) जोड़ें।  
4. `Shapes` ऑब्जेक्ट की `addConnector` मेथड का उपयोग करके कनेक्टर टाइप को परिभाषित करते हुए एक कनेक्टर जोड़ें।  
5. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
6. आकारों पर अपनी पसंदीदा कनेक्शन डॉट्स सेट करें।  
7. प्रेजेंटेशन को सेव करें।  

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टेंस बनाता है
  $pres = new Presentation();
  try {
    # किसी विशिष्ट स्लाइड के लिए शैप्स संग्रह तक पहुंचता है
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # एक दीर्घवृत्त ऑटोशेप जोड़ता है
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # एक आयत ऑटोशेप जोड़ता है
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # स्लाइड के शैप्स संग्रह में एक कनेक्टर आकार जोड़ता है
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # कनेक्टर का उपयोग करके आकारों को जोड़ता है
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # दीर्घवृत्त आकार पर पसंदीदा कनेक्शन डॉट इंडेक्स सेट करता है
    $wantedIndex = 6;
    # जांचता है कि पसंदीदा इंडेक्स अधिकतम साइट इंडेक्स गिनती से कम है या नहीं
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # दीर्घवृत्त ऑटोशेप पर पसंदीदा कनेक्शन डॉट सेट करता है
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # प्रस्तुति को सहेजता है
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **कनेक्टर पॉइंट समायोजित करें**

आप मौजूदा कनेक्टर को इसके एडजस्टमेंट पॉइंट्स के माध्यम से समायोजित कर सकते हैं। केवल उन कनेक्टरों को जिनमें एडजस्टमेंट पॉइंट्स हैं, इस तरह बदला जा सकता है। देखें तालिका **[कनेक्टर के प्रकार](/slides/hi/php-java/connector/#types-of-connectors)**

### **सरल मामला**

एक स्थिति पर विचार करें जहाँ दो आकारों (A और B) के बीच कनेक्टर तीसरे आकार (C) के भीतर से गुजरता है:

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

तीसरे आकार से बचने या उसे बायपास करने के लिए, हम कनेक्टर को उसकी लंबवत रेखा को बाएं तरफ ले जाकर इस तरह समायोजित कर सकते हैं:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **जटिल मामलों** 

और अधिक जटिल समायोजन करने के लिए, आपको निम्नलिखित बातों का ध्यान रखना होगा:

* एक कनेक्टर के एडजस्टेबल पॉइंट का घनिष्ठ संबंध एक सूत्र से है जो उसकी स्थिति की गणना करता और निर्धारित करता है। इसलिए पॉइंट के स्थान में बदलाव कनेक्टर के आकार को बदल सकता है।  
* एक कनेक्टर के एडजस्टमेंट पॉइंट्स को एक एरे में एक कड़े क्रम में परिभाषित किया जाता है। एडजस्टमेंट पॉइंट्स को कनेक्टर के प्रारंभ बिंदु से अंत तक क्रमांकित किया जाता है।  
* एडजस्टमेंट पॉइंट मान कनेक्टर आकार की चौड़ाई/ऊँचाई के प्रतिशत को दर्शाते हैं।  
  * आकार कनेक्टर के प्रारंभ और अंत बिंदुओं को 1000 से गुणा करके सीमित किया जाता है।  
  * पहला पॉइंट, दूसरा पॉइंट, और तीसरा पॉइंट क्रमशः चौड़ाई से प्रतिशत, ऊँचाई से प्रतिशत, और फिर से चौड़ाई से प्रतिशत को परिभाषित करते हैं।  
* कनेक्टर के एडजस्टमेंट पॉइंट्स के निर्देशांक निर्धारित करने वाली गणनाओं के लिए, आपको कनेक्टर के रोटेशन और उसके प्रतिबिंब को ध्यान में रखना होगा। **ध्यान दें** कि **[कनेक्टर के प्रकार](/slides/hi/php-java/connector/#types-of-connectors)** में दिखाए गए सभी कनेक्टरों का रोटेशन एंगल 0 है।  

#### **मामला 1**

एक स्थिति पर विचार करें जहाँ दो टेक्स्ट फ्रेम ऑब्जेक्ट्स को एक कनेक्टर के माध्यम से जोड़ा गया है:

![connector-shape-complex](connector-shape-complex.png)

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टेंस बनाता है
  $pres = new Presentation();
  try {
    # प्रस्तुति में पहली स्लाइड प्राप्त करता है
    $sld = $pres->getSlides()->get_Item(0);
    # कनेक्टर के माध्यम से एक साथ जोड़े जाने वाले आकार जोड़ता है
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # एक कनेक्टर जोड़ता है
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # कनेक्टर की दिशा निर्दिष्ट करता है
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # कनेक्टर का रंग निर्दिष्ट करता है
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # कनेक्टर की लाइन की मोटाई निर्दिष्ट करता है
    $connector->getLineFormat()->setWidth(3);
    # कनेक्टर के साथ आकारों को एक साथ जोड़ता है
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # कनेक्टर के एडजस्टमेंट पॉइंट्स प्राप्त करता है
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**समायोजन**  
हम कनेक्टर के एडजस्टमेंट पॉइंट मानों को संबंधित चौड़ाई और ऊँचाई प्रतिशत को क्रमशः 20% और 200% बढ़ाकर बदल सकते हैं:

```php
  # समायोजन बिंदुओं के मान बदलता है
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

परिणाम:

![connector-adjusted-1](connector-adjusted-1.png)

एक मॉडल परिभाषित करने के लिए जो हमें कनेक्टर के व्यक्तिगत भागों के निर्देशांक और आकार निर्धारित करने की अनुमति देता है, चलिए एक ऐसा आकार बनाते हैं जो कनेक्टर के क्षैतिज घटक के अनुरूप हो, connector.getAdjustments().get_Item(0) पॉइंट पर:

```php
  # कनेक्टर का लंबवत घटक बनाएँ
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

परिणाम:

![connector-adjusted-2](connector-adjusted-2.png)

#### **मामला 2**

**मामला 1** में, हमने बुनियादी सिद्धांतों का उपयोग करके एक सरल कनेक्टर समायोजन ऑपरेशन दिखाया था। सामान्य परिस्थितियों में, आपको कनेक्टर के रोटेशन और उसके डिस्प्ले (जो connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() द्वारा सेट होते हैं) को ध्यान में रखना होगा। अब हम प्रक्रिया दिखाएंगे।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन हेतु) और एक नया (हरा) कनेक्टर बनाएं जो इसे पहले से बने ऑब्जेक्ट्स से जोड़ता है।

```php
  # एक नया बाइंडिंग ऑब्जेक्ट बनाता है
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # एक नया कनेक्टर बनाता है
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # नए बनाए गए कनेक्टर का उपयोग करके ऑब्जेक्ट्स को जोड़ता है
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # कनेक्टर के एडजस्टमेंट पॉइंट्स प्राप्त करता है
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # एडजस्टमेंट पॉइंट्स के मान बदलता है
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

परिणाम:

![connector-adjusted-3](connector-adjusted-3.png)

दूसरा, एक ऐसा आकार बनाएं जो नए कनेक्टर के एडजस्टमेंट पॉइंट connector.getAdjustments().get_Item(0) से गुजरते हुए कनेक्टर के क्षैतिज घटक के अनुरूप हो। हम कनेक्टर डेटा से connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() के मानों को उपयोग करेंगे और दिए गए बिंदु x0 के आसपास रोटेशन के लिए लोकप्रिय कोऑर्डिनेट परिवर्तन सूत्र लागू करेंगे।

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में, ऑब्जेक्ट का रोटेशन कोण 90 डिग्री है और कनेक्टर के रूप में वह लंबवत प्रदर्शित है, इसलिए यह संबंधित कोड है:

```php
  # कनेक्टर के निर्देशांक को सहेजता है
  $x = $connector->getX();
  $y = $connector->getY();
  # यदि यह दिखाई देता है तो कनेक्टर के निर्देशांक को सही करता है
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # समायोजन बिंदु मान को निर्देशांक के रूप में लेता है
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # निर्देशांकों को बदलता है क्योंकि Sin(90) = 1 और Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # दूसरे समायोजन बिंदु मान का उपयोग करके क्षैतिज घटक की चौड़ाई निर्धारित करता है
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

परिणाम:

![connector-adjusted-4](connector-adjusted-4.png)

हमने सरल समायोजन और जटिल एडजस्टमेंट पॉइंट्स (रोटेशन एंगल वाले एडजस्टमेंट पॉइंट्स) से जुड़े गणनाएँ प्रदर्शित कीं। प्राप्त ज्ञान का उपयोग करके, आप अपना खुद का मॉडल विकसित कर सकते हैं (या कोड लिख सकते हैं) जिससे आप `GraphicsPath` ऑब्जेक्ट प्राप्त कर सकते हैं या विशेष स्लाइड निर्देशांक के आधार पर कनेक्टर के एडजस्टमेंट पॉइंट मान सेट कर सकते हैं।

## **कनेक्टर लाइनों के कोण खोजें**

1. क्लास का एक इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. कनेक्टर लाइन आकार तक पहुँचें।  
4. लाइन की चौड़ाई, ऊँचाई, आकार फ़्रेम की ऊँचाई और फ़्रेम की चौड़ाई का उपयोग करके कोण की गणना करें।  

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि कोई कनेक्टर किसी विशेष आकार पर "चिपकाया" जा सकता है या नहीं?**

जाँचें कि आकार [connection sites](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getconnectionsitecount/) प्रदान करता है या नहीं। यदि कोई नहीं है या गिनती शून्य है, तो चिपकाना उपलब्ध नहीं है; ऐसी स्थिति में, मुक्त एंडपॉइंट्स का उपयोग करें और उन्हें मैन्युअल रूप से स्थित करें। संलग्न करने से पहले साइट की गिनती जाँचना समझदारी है।

**यदि मैं जुड़े हुए आकारों में से एक को हटाऊँ तो कनेक्टर के साथ क्या होता है?**

इसके सिरों का जुड़ाव टूट जाएगा; कनेक्टर स्लाइड पर एक साधारण रेखा के रूप में रह जाता है जिसके प्रारम्भ/अंत मुक्त होते हैं। आप इसे हटाना या कनेक्शन पुनः असाइन करना चुन सकते हैं और आवश्यक होने पर [reroute](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/reroute/) कर सकते हैं।

**क्या स्लाइड को दूसरे प्रेजेंटेशन में कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**

सामान्यतः हाँ, बशर्ते लक्ष्य आकार भी कॉपी किए जाएँ। यदि स्लाइड को किसी अन्य फ़ाइल में डाला जाता है बिना जुड़े हुए आकारों के, तो सिरें मुक्त हो जाती हैं और आपको उन्हें फिर से संलग्न करना पड़ेगा।