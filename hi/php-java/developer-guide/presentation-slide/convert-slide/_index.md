---
title: PHP में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/php-java/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PPT, PPTX और ODP की स्लाइड्स को इमेज में बदलें — तेज़, उच्च-गुणवत्ता रेंडरिंग के साथ स्पष्ट कोड उदाहरण।"
---
## **परिचय**

Aspose.Slides for PHP via Java आपको PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स जैसे BMP, PNG, JPG (JPEG), GIF और अन्य में आसानी से बदलने की सुविधा देता है।

स्लाइड को इमेज में बदलने के लिए, निम्नलिखित चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स को परिभाषित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इसके लिए उपयोग करें:
    - [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास, या
    - [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/) क्लास।
2. [getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) मेथड को कॉल करके स्लाइड इमेज बनाएं।

Aspose.Slides for PHP via Java में, एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) क्लास वह है जो पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की अनुमति देती है। आप इस क्लास का उपयोग करके BMP, JPG, PNG आदि सहित कई फ़ॉर्मेट्स में इमेज को सहेज सकते हैं।

## **स्लाइड्स को बिटमैप्स में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर फिर JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में इमेज सहेज सकते हैं।

यह कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG फ़ॉर्मेट में इमेज सहेजें:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // प्रेजेंटेशन की पहली स्लाइड को बिटमैप में बदलें।
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // इमेज को PNG फ़ॉर्मेट में सहेजें।
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में बदलें**

आपको किसी निश्चित आकार की इमेज चाहिए हो सकती है। [getImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getImage) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ इमेज में बदल सकते हैं।

यह नमूना कोड दिखाता है कि इसे कैसे किया जाता है:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // निर्दिष्ट आकार के साथ प्रस्तुति की पहली स्लाइड को बिटमैप में बदलें।
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें।
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **नोट्स और कमेंट्स वाली स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स शामिल हो सकते हैं।

Aspose.Slides दो क्लासेज़ प्रदान करता है[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) और [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/)—जो प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करने की अनुमति देती हैं। दोनों क्लासेज़ में `setSlidesLayoutOptions` मेथड मौजूद है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने में मदद करता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामस्वरूप इमेज में नोट्स और कमेंट्स की पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे बदलें:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // नोट्स की स्थिति निर्धारित करें।
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // टिप्पणियों की स्थिति निर्धारित करें।
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // टिप्पणी क्षेत्र की चौड़ाई निर्धारित करें।
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // टिप्पणी क्षेत्र का रंग निर्धारित करें.

    // रेंडरिंग विकल्प बनाएं।
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // प्रस्तुति की पहली स्लाइड को इमेज में बदलें।
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // इमेज को GIF फ़ॉर्मेट में सहेजें।
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-से-इमेज परिवर्तित प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड `BottomFull` लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता। 
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास आपको आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके उत्पन्न TIFF इमेज पर अधिक नियंत्रण प्रदान करती है।

यह कोड दर्शाता है कि एक परिवर्तन प्रक्रिया जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार वाली ब्लैक‑एंड‑व्हाइट इमेज आउटपुट की गई है:

```php
// प्रस्तुति फ़ाइल लोड करें।
$presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // इमेज का आकार निर्धारित करें।
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफेद)।
    $options->setDpiX(300);                                              // क्षैतिज रिज़ॉल्यूशन निर्धारित करें।
    $options->setDpiY(300);                                              // ऊर्ध्वाधर रिज़ॉल्यूशन निर्धारित करें।
    
    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
    $image = $slide->getImage($options);
    try {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें।
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
TIFF समर्थन JDK 9 से पहले के संस्करणों में गारंटी नहीं है। 
{{% /alert %}} 

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको एक प्रस्तुति में सभी स्लाइड्स को इमेज में बदलने की सुविधा देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड दर्शाता है कि PHP में एक प्रस्तुति की सभी स्लाइड्स को इमेज में कैसे बदलें:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति को स्लाइड दर स्लाइड इमेज में रेंडर करें।
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी हुई स्लाइड्स को रेंडर न करें)।
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // स्लाइड को इमेज में बदलें।
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें।
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides स्लाइड्स को एनीमेशन के साथ रेंडर करने का समर्थन करता है?**  
नहीं, `getImage` मेथड केवल स्लाइड की स्थिर इमेज सहेजता है, बिना एनीमेशन के।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**  
हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेज को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**  
हां, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय शैडो, ट्रांसपरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।