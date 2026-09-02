---
title: PHP का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम को प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/php-java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रास्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएँ
- छवि संकुचित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- छवि इफ़ेक्ट
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **अवलोकन**

एक पिक्चर फ्रेम स्लाइड का वह आकार है जो छवि प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग‑अलग वस्तु होते हैं: एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का मालिक होता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) छवि की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घुमा‌व, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑स्तर सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब वही छवि एक से अधिक बार दिखानी हो। छवि को प्रस्तुति में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) को रखें, और पिक्चर फ्रेम बनाते समय उसी छवि संसाधन का उपयोग करें।

पिक्चर फ्रेम रास्टर छवियों जैसे PNG या JPEG तथा वेक्टर SVG छवियों को सम्मिलित कर सकते हैं। वे लिंक्ड छवियों की ओर भी इशारा कर सकते हैं, जिससे छवि बाइट्स प्रस्तुति में संग्रहीत नहीं होते। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एक एम्बेडेड छवि जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) के साथ पिक्चर फ्रेम बनाएं। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को किसी अन्य कंप्यूटर पर ले जाने पर भी वह स्वयं‑समाहित रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आकार पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग व घुमा‌व लागू करता है:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

पिक्चर फ्रेम प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या संकुचित करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केलिंग को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/setrelativescalewidth/) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/setrelativescaleheight/) के द्वारा उजागर करता है। `1.0` का मान मूल छवि आकार के 100 % के बराबर है। जब वर्कफ़्लो को स्रोत छवि आकार के अनुपात को बनाए रखना हो, तो रिलेटिव स्केल उपयोगी होता है, बजाय इसके कि अंतिम आयाम मैन्युअल रूप से गणना किए जाएँ।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स बदलता है; यह एम्बेडेड छवि को री‑सैंपल या संकुचित नहीं करता।

## **एम्बेडेड और लिंक्ड छवियाँ**

एक एम्बेडेड पिक्चर छवि डेटा को सीधे प्रस्तुति में संग्रहीत करता है और इसलिए पोर्टेबिलिटी तथा अनुमानयोग्य रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड पिक्चर [Picture::setLinkPathLong](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/setlinkpathlong/) मेथड के माध्यम से बाह्य स्थान को संदर्भित करता है, बजाय इसके कि छवि डेटा को समान रूप से एम्बेड किया जाए।

लिंक्ड छवियाँ PPTX में संग्रहीत छवि डेटा की मात्रा को घटा सकती हैं, लेकिन वे बाह्य निर्भरता लाती हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल स्थानांतरित हो गई है, या संसाधन उपलब्ध नहीं है, तो लिंक्ड पिक्चर अपेक्षित रूप से नहीं दिखेगा। उन प्रस्तुतियों के लिए जो ई‑मेल, अभिलेखीय या अलग‑थलग वातावरण में रेंडर की जानी हों, एम्बेडेड छवियाँ आमतौर पर अधिक भरोसेमंद होती हैं।

### **एक लिंक्ड छवि जोड़ें**

निम्न उदाहरण पिक्चर फ्रेम बनाता है और उसे स्थानीय छवि फ़ाइल की ओर इंगित करता है। यह केवल छवि लिंकिंग को दर्शाता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इसे जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

बाहरी फ़ाइल प्रबंधन को इरादा होने पर ही लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में न उपयोग करें: टूटे हुए छवि निर्भरताओं के साथ छोटा PPTX अक्सर बड़े, स्वयं‑समाहित प्रस्तुति की तुलना में कम उपयोगी होता है।

## **पिक्चर फ्रेम से छवियों को एक्सट्रैक्ट करें**

किसी मौजूदा प्रस्तुति से छवि निकालने से पहले, सुनिश्चित करें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) है और उसमें एम्बेडेड छवि सम्मिलित है। लिंक्ड पिक्चर फ्रेम में वह छवि बाइट्स नहीं हो सकते जो समान तरीके से एक्सट्रैक्ट किए जा सकते हैं।

### **रास्टर छवि निकालें**

आधुनिक छवि API सीधे [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) का उपयोग करता है। निम्न उदाहरण स्लाइड पर पहली एम्बेडेड रास्टर तस्वीर खोजता है और उसे PNG के रूप में सहेजता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

[IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save) के माध्यम से सहेजने से एक्सट्रैक्टेड छवि को इच्छित आउटपुट फ़ॉर्मेट में बदला जाता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो परिवर्तित रास्टर फ़ाइल के बजाय छवि संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG छवि निकालें**

SVG पिक्चर के लिए, [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने की अनुमति देता है, बिना पहले तस्वीर को रास्टराइज़ किए।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसी रास्टर एक्सपोर्ट्स उस वेक्टर सामग्री को पिक्सेल में रेंडर करती हैं। PDF या SVG स्लाइड एक्सपोर्ट भी एक रेंडरिंग ऑपरेशन है, इसलिए एक्सपोर्ट की गई ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; मूल वेक्टर संसाधन स्वयं आवश्यक होने पर एम्बेडेड [SvgImage::getSvgData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/getsvgdata/) डेटा का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर दिखाई देने वाले हिस्से को बदलती है। [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भिक रूप से एम्बेडेड छवि से छिपे पिक्सेल को हटाती नहीं है; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से एक पिक्चर फ्रेम खोजता है और क्रॉप मान लागू करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

क्योंकि छिपा हुआ छवि डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनर्स्थापन की आवश्यकता नहीं है, तो अगले भाग में बताया गया है कि कैसे क्रॉप किए गए क्षेत्रों को शारीरिक रूप से हटाया जाए।

## **क्रॉप किए गए छवि डेटा को हटाएँ**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) वर्तमान क्रॉप आयत के बाहर की छवि डेटा को हटा देता है और परिणामी छवि संसाधन लौटाता है। यह फ़ाइल आकार घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद के अन‑क्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

यह मेथड प्रस्तुति में नया छवि संसाधन जोड़ सकता है। यदि मूल छवि अन्य पिक्चर फ्रेमों द्वारा भी उपयोग की जा रही है, तो उन फ्रेमों को अभी भी अपना मौजूदा संसाधन चाहिए होता है, इसलिए क्रॉप किए गए क्षेत्रों को हटाना जरूरी नहीं कि कुल छवियों की संख्या घटाए। इस मेथड से WMF या EMF सामग्री को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर छवियों को संकुचित करें**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) रास्टर छवि रिजॉल्यूशन को उस आकार के सापेक्ष कम करता है जिस पर तस्वीर प्रदर्शित होती है। यह समान ऑपरेशन में क्रॉप किए गए क्षेत्रों को भी हटा सकता है। यदि छवि को रिसाइज़ या क्रॉप किया गया हो तो मेथड `true` लौटाता है, अन्यथा कोई परिवर्तन न होने पर `false`।

जब मानक लक्ष्य रिजॉल्यूशन पर्याप्त हो, तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturescompression/) मान का उपयोग करें:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

यदि विशिष्ट लक्ष्य आवश्यक हो तो एक कस्टम सकारात्मक DPI मान भी पास किया जा सकता है।

संकुचन केवल रास्टर छवियों के लिये अभिप्रेत है। SVG और मेटा‑फ़ाइल सामग्री इस रास्टर संकुचन वर्कफ़्लो द्वारा नहीं घटती। यह भी याद रखें कि कम रिजॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को ऑप्टिमाइज़्ड प्रस्तुति से पुनर्प्राप्त नहीं किया जा सकता। लक्ष्य रिजॉल्यूशन चुनें उस सबसे बड़े आकार के आधार पर जिस पर छवि वास्तव में देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करके।

## **छवि ट्रांसफ़ॉर्म इफ़ेक्ट्स का प्रबंधन करें**

ब्राइटनेस, कॉन्ट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफ़ेक्ट्स, ऑर्डर्ड चेन, निरीक्षण, हटाना और राउंड‑ट्रिप वैरिफिकेशन को कवर करने वाले पूर्ण वर्कफ़्लो के लिये, देखें [Image Transform Effects](/slides/hi/php-java/image-transform-effects/)।

## **पिक्चर फ्रेम ज्यामिति को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम के लिये कौन‑सी संपादन कार्य अक्षम हों। उदाहरण के लिये, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) आकार बदलते समय आकार अनुपात को सुरक्षित रखती है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत छवि को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने को बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) पर स्ट्रेच‑ऑफ़सेट मान पिक्चर फ्रेम की बाउंडिंग बॉक्स के सापेक्ष फ़िल आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक इन्सेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के किस भाग को दिखाया जाए तय करता है; स्ट्रेच‑ऑफ़सेट दिखाए जाने वाले पिक्चर फ़िल को किन आयत में स्ट्रेच किया जाना है, उसे बदलते हैं।

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

फ़िल प्लेसमेंट के लिये स्ट्रेच‑ऑफ़सेट का उपयोग करें। जब लक्ष्य स्रोत‑छवि के किनारे छुपाना हो तो क्रॉप प्रॉपर्टी प्रयोग करें।

## **स्टोरेज, फ़ाइल आकार और एक्सपोर्ट विचार**

मुख्य ट्रेड‑ऑफ़ तब प्रबंधनीय होते हैं जब छवि स्टोरेज और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग माना जाए:

- **एम्बेडेड छवियाँ** प्रस्तुति को स्वयं‑समाहित बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिये सबसे भरोसेमंद होती हैं, लेकिन बड़े रास्टर छवियों से PPTX आकार और मेमोरी प्रयोग बढ़ता है।
- **लिंक्ड छवियाँ** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को बाह्य फ़ाइलों के निर्दिष्ट पाथ या स्थान पर उपलब्ध रहने पर निर्भर करती हैं।
- **क्रॉपिंग** प्रारम्भिक रूप से नॉन‑डिस्ट्रक्टिव होती है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक क्रॉप्ड एरिया स्पष्ट रूप से हटाए न जाएँ या संकुचन के दौरान हटाए न जाएँ।
- **संकुचन** अत्यधिक बड़े रास्टर छवियों के फ़ाइल आकार को काफी कम कर सकता है, लेकिन स्रोत रिजॉल्यूशन का त्याग होता है। इसे स्लाइड पर वास्तविक आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG छवियाँ** वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में ही रखी जानी चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एम्बेडेड SVG को सीधे एक्सट्रैक्ट करें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदलते हैं।
- **बार‑बार उपयोग होने वाली छवियाँ** संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) संसाधन को पुनः उपयोग करें, बजाय बार‑बार समान फ़ाइल को प्रस्तुति वर्कफ़्लो में लोड करने के।

बड़ी प्रस्तुतियों के लिये, छवि ऑप्टिमाइज़ेशन आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और डायग्राम को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सेल केवल तब हटाएँ जब बाद की संपादन आवश्यक न हो, और बाह्य लिंक तभी उपयोग करें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा हो।

## **FAQs**

**एक पिक्चर फ्रेम और एक छवि संसाधन में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) प्रस्तुति से जुड़ा छवि संसाधन दर्शाता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) स्लाइड पर वह आकार है जो छवि प्रदर्शित करता है तथा फ्रेम‑स्तरीय ज्यामिति और फ़ॉर्मेटिंग जैसे आकार, घुमा‌व, क्रॉप मान, इफ़ेक्ट्स और लॉक संग्रहीत करता है।

**मुझे छवियों को एम्बेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, आर्काइव्ड या बाह्य संसाधनों तक पहुँच के बिना रेंडर करना हो, तब छवियों को एम्बेड करें। केवल तब लिंक करें जब छवि फ़ाइलों को PPTX के बाहर रखना इरादा हो और बाह्य स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार घटाती है?**

केवल क्रॉप सेटिंग स्वयं फ़ाइल आकार नहीं घटाती। सामान्य क्रॉप सेटिंग स्रोत छवि के भाग को छिपाती है परन्तु अंतर्निहित पिक्सेल रखती है। जब उन पिक्सेल को स्थायी रूप से हटाया जा सके, तब [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) या क्रॉप्ड‑एरिया हटाने के साथ छवि संकुचन का उपयोग करें।

**क्या मैं संकुचन के बाद छवि गुणवत्ता पुनर्स्थापित कर सकता हूँ?**

नहीं। संकुचन संग्रहीत रास्टर रिजॉल्यूशन को कम कर देती है, और क्रॉप्ड क्षेत्रों को हटाने से छवि डेटा समाप्त हो जाता है। यदि बाद में हाई‑रिजॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG छवियों को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) को सीधे एक्सट्रैक्ट किया जा सकता है। स्लाइड को PNG या JPEG जैसी रास्टर फ़ॉर्मेट में निर्यात करने से SVG का रेंडरिंग पिक्सेल में बदल जाता है।

**मौजूदा स्लाइड्स पढ़ते समय अन‑सेफ़ कास्ट से कैसे बचें?**

आकार का प्रकार उपयोग करने से पहले जाँचें। एक `java_instanceof` जांच [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) के विरुद्ध अन‑सेफ़ कास्ट को रोकती है और कोड को उन स्लाइड्स को हैंडल करने देती है जिनमें पिक्चर फ्रेम नहीं होते।