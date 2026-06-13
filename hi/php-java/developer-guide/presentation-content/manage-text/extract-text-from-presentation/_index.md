---
title: PHP में प्रेजेंटेशन्स से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/php-java/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट प्राप्त करें
- स्लाइड से टेक्स्ट प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट प्राप्त करें
- PowerPoint से टेक्स्ट प्राप्त करें
- OpenDocument से टेक्स्ट प्राप्त करें
- PPT से टेक्स्ट प्राप्त करें
- PPTX से टेक्स्ट प्राप्त करें
- ODP से टेक्स्ट प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशन्स से तेज़ी से टेक्स्ट निकालें। समय बचाने के लिए हमारी सरल, चरण-दर-चरण मार्गदर्शिका का पालन करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना स्लाइड सामग्री पर काम करने वाले डेवलपर्स के लिए एक सामान्य लेकिन आवश्यक कार्य है। चाहे आप Microsoft PowerPoint फ़ाइलों को PPT या PPTX फ़ॉर्मेट में संभाल रहे हों, या OpenDocument प्रेजेंटेशन (ODP) के साथ काम कर रहे हों, टेक्स्ट डेटा तक पहुंच और उसे प्राप्त करना विश्लेषण, ऑटोमेशन, इंडेक्सिंग या कंटेंट माइग्रेशन जैसे उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख Aspose.Slides for PHP via Java का उपयोग करके PPT, PPTX और ODP सहित विभिन्न प्रेजेंटेशन फ़ॉर्मेट से टेक्स्ट को प्रभावी ढंग से निकालने के बारे में एक व्यापक मार्गदर्शिका प्रदान करता है। आप सीखेंगे कि प्रेजेंटेशन तत्वों के माध्यम से क्रमबद्ध रूप से कैसे इटररेट करें ताकि आवश्यक टेक्स्ट सामग्री को सटीक रूप से प्राप्त किया जा सके।

## **Extract Text from a Slide**

Aspose.Slides for PHP via Java [SlideUtil](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/) क्लास प्रदान करता है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड्स एक्सपोज़ करता है। प्रेजेंटेशन में किसी स्लाइड से टेक्स्ट निकालने के लिए, [getAllTextBoxes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#getAllTextBoxes) मेथड का उपयोग करें। यह मेथड पैरामीटर के रूप में [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) प्रकार का एक ऑब्जेक्ट लेता है। निष्पादित होने पर, यह मेथड पूरे स्लाइड में टेक्स्ट को स्कैन करता है और [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें सभी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निचे दिया गया कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट को निकालता है:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extract Text from a Presentation**

पूरे प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/) क्लास द्वारा एक्सपोज़ किया गया [getAllTextFrames](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/#getAllTextFrames) स्टैटिक मेथड उपयोग करें। यह दो पैरामीटर लेता है:

1. पहला, एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन को दर्शाता है जिससे टेक्स्ट निकाला जाएगा।
1. दूसरा, एक `boolean` मान जो निर्धारित करता है कि मास्टर स्लाइड्स को टेक्स्ट स्कैनिंग के दौरान शामिल किया जाए या नहीं।

यह मेथड [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग की जानकारी भी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन, जिसमें मास्टर स्लाइड्स भी शामिल हैं, से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है:

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Categorized and Fast Text Extraction**

[PresentationFactory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशन्स से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करता है:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textextractionarrangingmode/) एन्‍युम आर्ग्यूमेंट टेक्स्ट एक्सट्रैक्शन परिणाम को व्यवस्थित करने के मोड को दर्शाता है और निम्नलिखित मानों में सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट स्लाइड पर उसी क्रम में व्यवस्थित है जैसा वह दिखता है।

जब गति महत्वपूर्ण हो तो अनएरेंज्ड मोड का उपयोग किया जा सकता है; यह एरेंज्ड मोड की तुलना में तेज है।

[PresentationText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट का प्रतिनिधित्व करता है। इसका `getSlidesText` मेथड ऑब्जेक्ट्स की एक एरे लौटाता है जहाँ प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को दर्शाता है। प्रत्येक लौटाए गए ऑब्जेक्ट में निम्नलिखित मेथड्स होते हैं:

- `getText` - स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getMasterText` - इस स्लाइड से जुड़े मास्टर स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getLayoutText` - इस स्लाइड से जुड़े लेआउट स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getNotesText` - इस स्लाइड से जुड़े नोट्स स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `getCommentsText` - इस स्लाइड से जुड़े कमेंट्स के भीतर का टेक्स्ट।

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Aspose.Slides बड़े प्रेजेंटेशन्स को टेक्स्ट एक्सट्रैक्शन के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [बड़े प्रेजेंटेशन्स](/slides/hi/php-java/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशन्स के भीतर तालिकाओं और चार्ट्स से टेक्स्ट निकाल सकता है?**

हाँ। Aspose.Slides कई स्लाइड तत्वों, जिसमें टेबल्स और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, जिससे आप सामान्य प्रेजेंटेशन संरचनाओं में मौजूद टेक्स्ट सामग्री तक पहुंच और विश्लेषण कर सकते हैं।

**क्या प्रेजेंटेशन्स से टेक्स्ट निकालने के लिए मुझे Aspose.Slides का विशेष लाइसेंस चाहिए?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ प्रतिबंध](/slides/hi/php-java/licensing/) होते हैं, जैसे केवल सीमित संख्या में स्लाइड्स को प्रोसेस करना। पूर्ण लाइसेंस खरीदने से अपरिबंधित उपयोग और बड़े प्रेजेंटेशन्स को संभालने की सुविधा मिलती है।