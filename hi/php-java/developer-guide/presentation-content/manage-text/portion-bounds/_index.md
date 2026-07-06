---
title: PHP में प्रस्तुतियों से टेक्स्ट पोर्शन सीमाएँ प्राप्त करें
linktitle: पोर्शन सीमाएँ
type: docs
weight: 47
url: /hi/php-java/portion-bounds/
keywords:
- टेक्स्ट पोर्शन सीमाएँ
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "जाव के माध्यम से PHP के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन सीमाओं को प्राप्त करने का तरीका सीखें।"
---
## **अवलोकन**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर टेक्स्ट के एक विशिष्ट अंश का प्रतिनिधित्व करता है और आपको उस अंश को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जा सकता है जब आपको टेक्स्ट अंश की सीमा प्राप्त करनी हो, पैराग्राफ के केवल हिस्से पर फॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

यह लेख दिखाता है कि कैसे [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/getrect/) का उपयोग करके पोर्शन का बाउंडिंग आयत प्राप्त किया जा सकता है। यह यह भी दर्शाता है कि कैसे [Portion::getCoordinates](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/getcoordinates/) का उपयोग करके पोर्शन की शुरुआत के निर्देशांक प्राप्त किए जा सकते हैं। अतिरिक्त रूप से, यह सामान्य पोर्शन-संबंधित परिदृश्यों को उजागर करता है, जैसे कि एकल टेक्स्ट अंश पर हाइपरलिंक लागू करना, यह समझना कि फॉर्मेटिंग पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से कैसे हल होती है, और उन मामलों को संभालना जहाँ निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं है।

## **टेक्स्ट पोर्शन की सीमा प्राप्त करें**

टेक्स्ट पोर्शन का बाउंडिंग आयत प्राप्त करने के लिए [Portion::getRect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/getrect/) का उपयोग करें:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**

टेक्स्ट पोर्शन की शुरुआत के निर्देशांक प्राप्त करने के लिए [Portion::getCoordinates](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/getcoordinates/) का उपयोग करें:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर केवल टेक्स्ट के हिस्से पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप [हाइपरलिंक असाइन करें](/slides/hi/php-java/manage-hyperlinks/) को एक व्यक्तिगत पोर्शन पर लागू कर सकते हैं; केवल वह अंश क्लिक करने योग्य होगा, पूरी पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करती है: पोर्शन क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से ली जाती है?**

पोर्टशन-स्तर की प्रॉपर्टीज़ को सबसे अधिक प्राथमिकता मिलती है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) पर सेट नहीं है, तो Aspose.Slides इसे [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) से लेता है। यदि वह भी सेट नहीं है, तो Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/theme/) शैली का उपयोग करता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[Font substitution rules](/slides/hi/php-java/font-selection-sequence/) लागू होते हैं। टेक्स्ट का रीफ़्लो हो सकता है: मीट्रिक, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोज़िशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपैरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्से से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) स्तर पर टेक्स्ट का रंग, फ़िल और ट्रांसपैरेंसी पड़ोसी अंशों से भिन्न हो सकते हैं।