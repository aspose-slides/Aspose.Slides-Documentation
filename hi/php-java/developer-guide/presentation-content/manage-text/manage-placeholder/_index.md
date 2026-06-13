---
title: PHP में प्रेज़ेंटेशन प्लेसहोल्डर्स प्रबंधित करें
linktitle: प्लेसहोल्डर्स प्रबंधित करें
type: docs
weight: 10
url: /hi/php-java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- इमेज प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में प्लेसहोल्डर्स को सहजता से प्रबंधित करें: टेक्स्ट बदलें, प्रॉम्प्ट को कस्टमाइज़ करें और PowerPoint तथा OpenDocument में इमेज की पारदर्शिता सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रेज़ेंटेशन प्लेसहोल्डर्स को प्रोग्रामेटिकली प्रबंधित करने की सुविधा देता है। यह लेख समझाता है कि स्लाइड्स पर प्लेसहोल्डर्स को कैसे ढूँढ़ें और उनका टेक्स्ट बदलें, प्लेसहोल्डर लेआउट्स के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करें, और प्लेसहोल्डर बैकग्राउंड के रूप में उपयोग की गई चित्र की पारदर्शिता को कैसे समायोजित करें। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर्स और स्थानीय शैप्स के अंतर को स्पष्ट करता है, बताता है कि प्लेसहोल्डर में परिवर्तन लेआउट या मास्टर के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर एवं फुटर प्लेसहोल्डर प्रबंधन की ओर इशारा करता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**
आप [Aspose.Slides for PHP via Java](/slides/hi/php-java/) का उपयोग करके प्रेज़ेंटेशन की स्लाइड्स पर प्लेसहोल्डर्स को खोज और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर के टेक्स्ट में बदलाव करने की अनुमति देता है।

**पूर्वापेक्षा**: आपको एक ऐसा प्रेज़ेंटेशन चाहिए जिसमें प्लेसहोल्डर हो। आप यह प्रेज़ेंटेशन मानक Microsoft PowerPoint एप्लिकेशन में बना सकते हैं।

यहाँ बताया गया है कि आप Aspose.Slides का उपयोग करके उस प्रेज़ेंटेशन में प्लेसहोल्डर के टेक्स्ट को कैसे बदल सकते हैं:

1. [`Presentation`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास को इंस्टैंसिएट करें और प्रेज़ेंटेशन को आर्ग्यूमेंट के रूप में पास करें।  
2. इंडेक्स के माध्यम से एक स्लाइड रेफ़रेंस प्राप्त करें।  
3. शेप्स को इटररेट करके प्लेसहोल्डर खोजें।  
4. [`AutoShape`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AutoShape) में प्लेसहोल्डर शेप को टाइपकास्ट करें और उस [`AutoShape`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AutoShape) से जुड़े [`TextFrame`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TextFrame) का उपयोग करके टेक्स्ट बदलें।  
5. संशोधित प्रेज़ेंटेशन को सेव करें।

यह PHP कोड प्लेसहोल्डर में टेक्स्ट बदलने का तरीका दिखाता है:

```php
  # एक Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # शेप्स के माध्यम से इटरिटेट करके प्लेसहोल्डर ढूँढ़ता है
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # प्रत्येक प्लेसहोल्डर में टेक्स्ट बदलता है
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # प्रेज़ेंटेशन को डिस्क पर सेव करता है
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें**
स्टैण्डर्ड और प्री-बिल्ट लेआउट्स में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट होते हैं जैसे कि ***Click to add a title*** या ***Click to add a subtitle***। Aspose.Slides का उपयोग करके आप अपनी पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट्स में डाल सकते हैं।

यह PHP कोड आपको दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट करें:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # स्लाइड के माध्यम से इटरिटेट करता है
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint दिखाता है "Click to add title"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // उपशीर्षक जोड़ता है
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्लेसहोल्डर इमेज की पारदर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर में बैकग्राउंड इमेज की पारदर्शिता सेट करने की अनुमति देता है। इस फ्रेम में चित्र की पारदर्शिता को समायोजित करके आप टेक्स्ट या इमेज को उभारा बना सकते हैं (टेक्स्ट और चित्र के रंगों पर निर्भर करता है)।

यह PHP कोड आपको दिखाता है कि कैसे एक शैप के अंदर चित्र बैकग्राउंड की पारदर्शिता सेट की जा सकती है:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर स्थानीय शैप से कैसे अलग है?**  
बेस प्लेसहोल्डर वह मूल शैप है जो लेआउट या मास्टर पर स्थित होता है और स्लाइड का शैप उससे विरासत में प्राप्त करता है—प्रकार, स्थिति और कुछ फ़ॉर्मेटिंग उससे आती है। स्थानीय शैप स्वतंत्र होता है; यदि बेस प्लेसहोल्डर मौजूद नहीं है, तो विरासत लागू नहीं होती।

**मैं पूरे प्रेज़ेंटेशन में सभी शीर्षक या कैप्शन को बिना प्रत्येक स्लाइड पर इटररेट किए कैसे अपडेट कर सकता हूँ?**  
लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को एडिट करें। उन लेआउट्स/मास्टर पर आधारित स्लाइड्स अपने आप परिवर्तन को विरासत में ले लेंगी।

**मैं मानक हेडर/फूटर प्लेसहोल्डर्स—तारीख एवं समय, स्लाइड क्रमांक, और फूटर टेक्स्ट—को कैसे नियंत्रित कर सकता हूँ?**  
उपयुक्त स्कोप (सामान्य स्लाइड्स, लेआउट्स, मास्टर, नोट्स/हैंडआउट्स) में HeaderFooter मैनेजर्स का उपयोग करके इन प्लेसहोल्डर्स को ऑन या ऑफ कर सकते हैं और उनका कंटेंट सेट कर सकते हैं।