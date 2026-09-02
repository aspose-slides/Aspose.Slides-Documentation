---
title: PHP में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/php-java/convert-slide/
keywords:
- स्लाइड रूपांतरण
- स्लाइड निर्यात
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
description: "PPT, PPTX और ODP से स्लाइड्स को इमेज में बदलें Aspose.Slides for PHP via Java का उपयोग करके — तेज़, उच्च-गुणवत्ता वाला रेंडरिंग स्पष्ट कोड उदाहरणों के साथ."
---
## **परिचय**

Aspose.Slides for PHP via Java आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट, जैसे BMP, PNG, JPG (JPEG), GIF, आदि में परिवर्तित करने में सक्षम बनाता है।

एक स्लाइड को इमेज में बदलने के लिए, निम्नलिखित चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स निर्धारित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, उपयोग करके:
    - [TiffOptions] क्लास, या
    - [RenderingOptions] क्लास।
2. [getImage] मेथड को कॉल करके स्लाइड इमेज उत्पन्न करें।

Aspose.Slides for PHP via Java में, एक [IImage] क्लास वह है जो आपको पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की अनुमति देता है। आप इस क्लास का उपयोग करके इमेज को विभिन्न फ़ॉर्मेट (BMP, JPG, PNG, आदि) में सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में परिवर्तित करें और PNG में इमेज सहेजें**

आप एक स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर इमेज को JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में सहेज सकते हैं।

यह कोड दिखाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG फ़ॉर्मेट में इमेज सहेजें:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को बिटमैप में परिवर्तित करें।
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

## **कस्टम आकार के साथ स्लाइड्स को इमेज में परिवर्तित करें**

आपको निश्चित आकार की इमेज चाहिए हो सकती है। [getImage] के ओवरलोड का उपयोग करके, आप स्लाइड को निर्दिष्ट आयामों (चौड़ाई और ऊँचाई) वाली इमेज में बदल सकते हैं।

यह नमूना कोड इस प्रक्रिया को दिखाता है:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में परिवर्तित करें।
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

## **नोट्स और कमेंट्स वाली स्लाइड्स को इमेज में परिवर्तित करें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो क्लासेज़ [TiffOptions] और [RenderingOptions] प्रदान करता है—जिनसे आप प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित कर सकते हैं। दोनों क्लासेज़ में `setSlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देता है।

[NotesCommentsLayoutingOptions] क्लास के साथ, आप परिणामस्वरूप इमेज में नोट्स और कमेंट्स की पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे इमेज में बदलें:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // नोट्स की स्थिति सेट करें।
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // टिप्पणियों की स्थिति सेट करें।
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // टिप्पणियों के क्षेत्र की चौड़ाई सेट करें।
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // टिप्पणियों के क्षेत्र का रंग सेट करें.

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
किसी भी स्लाइड-से-इमेज रूपांतरण प्रक्रिया में, [setNotesPosition] मेथड `BottomFull` लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में परिवर्तित करें**

[TiffOptions] क्लास आपको परिणामस्वरूप TIFF इमेज पर अधिक नियंत्रण देती है, जिससे आप आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर को निर्दिष्ट कर सकते हैं।

यह कोड एक रूपांतरण प्रक्रिया दिखाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार वाली ब्लैक-एंड-व्हाइट इमेज उत्पन्न की जाती है:

```php
// प्रस्तुति फ़ाइल लोड करें।
$presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें।
    $slide = $presentation->getSlides()->get_Item(0);

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // इमेज का आकार सेट करें।
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // पिक्सेल फ़ॉर्मेट सेट करें (काले और सफ़ेद)।
    $options->setDpiX(300);                                              // क्षैतिज रिज़ॉल्यूशन सेट करें।
    $options->setDpiY(300);                                              // ऊर्ध्वाधर रिज़ॉल्यूशन सेट करें।
    
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
TIFF समर्थन JDK 9 से पहले के संस्करणों में गारंटी नहीं देता है।
{{% /alert %}} 

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड दिखाता है कि PHP में प्रस्तुति की सभी स्लाइड्स को इमेज में कैसे बदलें:

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

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="warning" %}} 
प्रस्तुति स्लाइड्स को इमेज में बदलते समय कलर इमोजी को सही ढंग से रेंडर करने के लिये, प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट्स को उस सिस्टम पर स्थापित और उपलब्ध होना चाहिए जो रूपांतरण कर रहा है। उदाहरण के लिए, यदि प्रस्तुति **Segoe UI Emoji** फ़ॉन्ट का उपयोग करती है और यह फ़ॉन्ट उपलब्ध नहीं है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिखाई दे सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर इमेज सेव करता है, एनीमेशन के बिना।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। केवल यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेज को शैडो और इफ़ेक्ट्स के साथ सेव किया जा सकता है?**

हां, Aspose.Slides स्लाइड्स को इमेज के रूप में सेव करते समय शैडो, ट्रांसपैरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।