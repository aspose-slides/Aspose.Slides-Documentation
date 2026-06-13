---
title: "PHP में प्रस्तुतियों में अंडाकार जोड़ें"
linktitle: "अंडाकार"
type: docs
weight: 30
url: /hi/php-java/ellipse/
keywords:
- अंडाकार
- आकार
- अंडाकार जोड़ें
- अंडाकार बनाएं
- अंडाकार बनाना
- स्वरूपित अंडाकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के माध्यम से PPT और PPTX प्रस्तुतियों में अंडाकार आकार बनाना, स्वरूपित करना और संशोधित करना सीखें — कोड उदाहरण सहित."
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में अंडाकार आकार जोड़ने का तरीका दर्शाता है। यह एक सरल अंडाकार बनाने, स्वरूपित अंडाकार बनाने, और अपडेटेड प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजने को कवर करता है। इसमें अंडाकार की स्थिति और आकार, स्टैकिंग क्रम को नियंत्रित करने, और एनीमेशन प्रभाव लागू करने से संबंधित प्रश्नों को भी छुआ गया है।

## **एक अंडाकार बनाएँ**
एक चयनित स्लाइड में सरल अंडाकार जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
- उसकी Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा एक्सपोज़ किए गए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

निचे दिए गए उदाहरण में, हमने पहली स्लाइड में एक अंडाकार जोड़ा है

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # एलीप्स प्रकार का AutoShape जोड़ें
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX फ़ाइल को डिस्क पर लिखें
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **एक स्वरूपित अंडाकार बनाएँ**
स्लाइड में बेहतर स्वरूपित अंडाकार जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
- उसकी Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) ऑब्जेक्ट द्वारा एक्सपोज़ किए गए [addAutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addAutoShape) मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें।
- अंडाकार का Fill Type सॉलिड सेट करें।
- अंडाकार का रंग `SolidFillColor::setColor` मेथड का उपयोग करके सेट करें, जो [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है और [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट से जुड़ा है।
- अंडाकार की लाइनों का रंग सेट करें।
- अंडाकार की लाइनों की चौड़ाई सेट करें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

निचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की पहली स्लाइड में एक स्वरूपित अंडाकार जोड़ा है।

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करें
    $sld = $pres->getSlides()->get_Item(0);
    # एलीप्स प्रकार का AutoShape जोड़ें
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # अंडाकार आकार पर कुछ स्वरूपण लागू करें
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # अंडाकार की रेखा पर कुछ स्वरूपण लागू करें
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX फ़ाइल को डिस्क पर लिखें
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड की इकाइयों के संदर्भ में अंडाकार की सटीक स्थिति और आकार कैसे सेट करूँ?**

निर्देशांक और आकार सामान्यतः **पॉइंट्स** में निर्दिष्ट किए जाते हैं। पूर्वानुमानित परिणामों के लिए, अपने गणना स्लाइड के आकार पर आधारित रखें और मान असाइन करने से पहले आवश्यक मिलीमीटर या इंच को पॉइंट्स में परिवर्तित करें।

**मैं अंडाकार को अन्य वस्तुओं के ऊपर या नीचे (स्टैकिंग क्रम नियंत्रित) कैसे रखूँ?**

ऑब्जेक्ट के ड्रॉइंग क्रम को आगे लाकर या पीछे भेजकर समायोजित करें। इससे अंडाकार अन्य वस्तुओं के ऊपर ओवरले हो सकता है या उनके नीचे की वस्तु को उजागर कर सकता है।

**मैं अंडाकार की उपस्थिति या ज़ोर को कैसे एनीमेट करूँ?**

[Apply](/slides/hi/php-java/shape-animation/) के माध्यम से आकार पर प्रवेश, ज़ोर या निकास प्रभाव लागू करें, और ट्रिगर एवं टाइमिंग कॉन्फ़िगर करें ताकि एनीमेशन कब और कैसे चलना है उसे निर्धारित किया जा सके।