---
title: PHP का उपयोग करके प्रस्तुतियों में टेक्स्ट भागों को प्रबंधित करें
linktitle: टेक्स्ट भाग
type: docs
weight: 70
url: /hi/php-java/portion/
keywords:
- टेक्स्ट भाग
- टेक्स्ट हिस्सा
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट भागों को कैसे प्रबंधित करें, जिससे प्रदर्शन और अनुकूलन में सुधार हो।"
---
## **परिचय**

एक टेक्स्ट भाग पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट खंड का प्रतिनिधित्व करता है और आपको उस भाग को आस-पास की सामग्री से स्वतंत्र रूप से काम करने की सुविधा देता है। Aspose.Slides में, भागों का उपयोग तब किया जा सकता है जब आपको टेक्स्ट खंड की स्थिति प्राप्त करनी हो, केवल पैराग्राफ के किसी भाग पर फ़ॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

## **टेक्स्ट भाग के निर्देशांक प्राप्त करें**
[**getCoordinates()**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/getcoordinates/) मेथड को [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) क्लास में जोड़ा गया है जो भाग की शुरुआत के निर्देशांक प्राप्त करने की अनुमति देता है।

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
  $pres = new Presentation();
  try {
    # प्रस्तुति के संदर्भ को पुनः आकार देना
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एकल पैराग्राफ के भीतर केवल टेक्स्ट के किसी भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप व्यक्तिगत भाग को [हाइपरलिंक असाइन करें](/slides/hi/php-java/manage-hyperlinks/) कर सकते हैं; केवल वही खंड क्लिक करने योग्य होगा, पूरे पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक Portion क्या ओवरराइड करता है, और क्या Paragraph/TextFrame से लिया जाता है?**

Portion‑स्तर की प्रॉपर्टीज़ की सबसे अधिक प्राथमिकता होती है। यदि कोई प्रॉपर्टी [Portion] पर सेट नहीं है, तो इंजन इसे [Paragraph] से लेता है; यदि वह भी सेट नहीं है, तो इसे [TextFrame] या [theme] स्टाइल से लिया जाता है।

**यदि किसी Portion के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[Font substitution rules](/slides/hi/php-java/font-selection-sequence/) लागू होते हैं। टेक्स्ट रीफ़्लो हो सकता है: मेट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोज़िशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पैराग्राफ के शेष हिस्से से स्वतंत्र रूप से Portion‑विशिष्ट टेक्स्ट फिल ट्रांसपेरेंसी या ग्रेडिएंट सेट कर सकता हूँ?**

हाँ, टेक्स्ट का रंग, फ़िल और ट्रांसपेरेंसी [Portion] स्तर पर आसपास के भागों से अलग हो सकती है।