---
title: "PHP का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें"
linktitle: "पिक्चर फ्रेम"
type: docs
weight: 10
url: /hi/php-java/picture-frame/
keywords:
- "पिक्चर फ्रेम"
- "पिक्चर फ्रेम जोड़ें"
- "पिक्चर फ्रेम बनाएं"
- "एंबेडेड इमेज"
- "लिंक्ड इमेज"
- "इमेज निकालें"
- "रास्टर इमेज"
- "SVG इमेज"
- "इमेज क्रॉप करें"
- "क्रॉप्ड क्षेत्रों को हटाएँ"
- "इमेज संकुचित करें"
- "StretchOffset"
- "पिक्चर फ्रेम फ़ॉर्मेटिंग"
- "रिलेटिव स्केल"
- "इमेज इफ़ेक्ट"
- "अस्पेक्ट अनुपात"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **अवलोकन**

एक पिक्चर फ्रेम वह स्लाइड आकार है जो एक छवि को प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ होते हैं: एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) के माध्यम से एंबेडेड छवि संसाधनों का स्वामित्व रखता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) छवि की स्थिति, आकार, रेखा स्वरूपण, घुमाव, क्रॉपिंग, पिक्चर प्रभाव और अन्य फ्रेम‑स्तरीय सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही छवि को एकाधिक बार दर्शाया जाता है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाए गए PPImage को रखें, और पिक्चर फ्रेम बनाते समय उसी छवि संसाधन का उपयोग करें।

पिक्चर फ्रेम PNG या JPEG जैसे रास्टर इमेज और SVG जैसे वेक्टर इमेज दोनों को सम्मिलित कर सकते हैं। वे प्रस्तुति में छवि बाइट्स को संग्रहीत करने के बजाय लिंक्ड इमेज को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए स्वरूपण या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि छवि को कैसे संग्रहीत किया जाना चाहिए।

## **एम्बेडेड इमेज जोड़ें और स्वरूपित करें**

एक एंबेडेड इमेज के लिए, छवि डेटा को प्रस्तुति में जोड़ें और ShapeCollection::addPictureFrame के साथ एक पिक्चर फ्रेम बनाएं। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए जब इसे किसी अन्य कंप्यूटर पर ले जाया जाता है तो प्रस्तुति स्वयं‑संकुलित रहती है।

निम्नलिखित उदाहरण JPEG इमेज जोड़ता है, इमेज के मूल आयामों पर एक फ्रेम बनाता है, और रेखा स्वरूपण तथा घुमाव लागू करता है:
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

पिक्चर फ्रेम प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एंबेडेड इमेज संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर तब महत्वपूर्ण हो जाता है जब बाद में छवि को क्रॉप या संकुचित किया जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) फ्रेम के लिए relative width और height स्केलिंग को setRelativeScaleWidth और setRelativeScaleHeight के माध्यम से प्रस्तुत करता है। `1.0` का मान मूल चित्र के आकार के 100% के बराबर होता है। रिलेटिव स्केल उपयोगी है जब किसी वर्कफ़्लो को स्रोत इमेज आकार के संबंध को बनाए रखना होता है, बजाय मैन्युअल रूप से अंतिम आयामों की गणना करने के।

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

रिलेटिव स्केल फ्रेम के स्केल सेटिंग्स को बदलता है; यह एंबेडेड इमेज को री‑सैंपल या संकुचित नहीं करता।

## **एंबेडेड और लिंक्ड इमेजेज**

एक एंबेडेड पिक्चर इमेज डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और अनुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड पिक्चर Picture::setLinkPathLong मेथड के माध्यम से बाहरी स्थान को संग्रहीत करता है, बजाय उसी तरह इमेज डेटा को एंबेड करने के।

लिंक्ड इमेजेज PPTX में संग्रहीत इमेज डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन द्वारा सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदलता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं है, तो लिंक्ड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जो ईमेल, अभिलेख, या अलग‑अलग वातावरण में रेंडर की जानी हों, एंबेडेड इमेजेज सामान्यतः अधिक विश्वसनीय होते हैं।

### **लिंक्ड इमेज जोड़ें**

निम्नलिखित उदाहरण एक पिक्चर फ्रेम बनाता है और उसे एक स्थानीय इमेज फ़ाइल की ओर निर्देशित करता है। यह केवल इमेज लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और जानबूझकर इस उदाहरण में सम्मिलित नहीं किया गया है।

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

बाहरी फ़ाइल प्रबंधन इरादतन होने पर लिंक का उपयोग करें। उन्हें केवल संकुचन के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज निर्भरताओं के साथ छोटा PPTX अक्सर बड़े स्वयं‑संकुलित प्रस्तुति से कम उपयोगी होता है।

## **पिक्चर फ्रेम से इमेज निकालें**

मौजूदा प्रस्तुति से इमेज निकालने से पहले, जांचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) है और उसमें एंबेडेड इमेज है। लिंक्ड पिक्चर फ्रेम में वह इमेज बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **रास्टर इमेज निकालें**

आधुनिक इमेज API IImage को सीधे उपयोग करता है। निम्नलिखित उदाहरण स्लाइड पर पहली एंबेडेड रास्टर चित्र को खोजता है और उसे PNG के रूप में सहेजता है:
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

IImage::save के माध्यम से सहेजने से निकाली गई इमेज को अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित किया जाता है। यदि आपको परिवर्तित रास्टर फ़ाइल के बजाय प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो इमेज संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG इमेज निकालें**

एक SVG चित्र के लिए, PPImage एक SvgImage ऑब्जेक्ट प्रदान करता है। यह आपको पहले चित्र को रास्टराइज़ करने के बजाय सीधे SVG डेटा पुनः प्राप्त करने देता है।
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

SVG कंटेंट को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को सुरक्षित रखता है। PNG या JPEG जैसे रास्टर निर्यात अनिवार्य रूप से उस वेक्टर कंटेंट को पिक्सेल में रेंडर करता है। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एंबेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर रिसोर्स की आवश्यकता हो, तो एंबेडेड SvgImage::getSvgData डेटा का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के किस भाग को दिखाया जाए बदलता है। PictureFillFormat पर क्रॉप मान स्रोत इमेज आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारंभ में एंबेडेड इमेज से छिपे पिक्सेल को हटाता नहीं है; यह केवल दृश्यमान क्षेत्र को बदलता है।

निम्नलिखित उदाहरण एक पिक्चर फ्रेम को सुरक्षित रूप से खोजता है और क्रॉप मान लागू करता है:
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

क्योंकि छिपा हुआ इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार पुनर्स्थापन की तुलना में अधिक महत्वपूर्ण है, तो अगली सेक्शन में वर्णित अनुसार क्रॉप किए गए क्षेत्रों को भौतिक रूप से हटा दिया जा सकता है।

## **क्रॉप्ड इमेज डेटा हटाएँ**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) वर्तमान क्रॉप आयत के बाहर के इमेज डेटा को हटाता है और परिणामी इमेज संसाधन लौटाता है। इससे फ़ाइल आकार घट सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सहेजने के बाद, हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।
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

यह मेथड प्रस्तुति में एक नया इमेज संसाधन जोड़ सकता है। यदि मूल इमेज को अन्य पिक्चर फ्रेम भी उपयोग कर रहे हैं, तो उन फ्रेमों को अभी भी अपना मौजूदा संसाधन चाहिए, इसलिए क्रॉप्ड क्षेत्रों को हटाने से कुल इमेज संख्या जरूरी नहीं घटे। इस मेथड से WMF या EMF कंटेंट को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर इमेजेज को संकुचित करें**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) चित्र के प्रदर्शित आकार के अनुपात में रास्टर इमेज रिज़ॉल्यूशन को घटाता है। यह समान ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब इमेज को री‑साइज़ या क्रॉप किया गया हो और `false` लौटाता है जब कोई परिवर्तन आवश्यक नहीं था।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो एक प्री‑डिफ़ाइंड PicturesCompression मान का उपयोग करें:
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

जब विशेष लक्ष्य आवश्यक हो, तो प्री‑डिफ़ाइंड मान के बजाय कस्टम पॉज़िटिव DPI मान पास किया जा सकता है।

संकुचन रास्टर इमेजेज के लिए अभिप्रेत है। SVG और मेटाफाइल कंटेंट इस रास्टर संकुचन वर्कफ़्लो द्वारा घटाया नहीं जाता। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को ऑप्टिमाइज़्ड प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर इमेज वास्तव में देखी या निर्यात की जाएगी, बजाय वैश्विक रूप से सबसे कम DPI लागू करने के।

## **इमेज इफ़ेक्ट्स की जाँच करें**

पिक्चर इफ़ेक्ट्स फ्रेम द्वारा उपयोग किए गए पिक्चर पर संग्रहीत होते हैं। इमेज ट्रांसफ़ॉर्म कलेक्शन में ट्रांसपेरेंसी के लिए फिक्स्ड अल्फा मॉड्यूलेशन और ब्राइटनेस व कंट्रास्ट के लिए ल्यूमिनेंस जैसे इफ़ेक्ट्स हो सकते हैं। नीचे दिया गया उदाहरण स्लाइड पर पहले पिक्चर फ्रेम से दोनों प्रकार के इफ़ेक्ट्स को सुरक्षित रूप से पढ़ता है:
```php
use aspose\slides\Presentation;

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
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

ये इफ़ेक्ट्स फ्रेम में इमेज के रेंडर होने के तरीके को बदलते हैं; वे मूल एंबेडेड इमेज बाइट्स को पुनः नहीं लिखते।

## **पिक्चर फ्रेम ज्योमेट्री को लॉक करें**

PictureFrameLock सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम के लिए कौन सी एडिटिंग ऑपरेशन्स निष्क्रिय हैं। उदाहरण के तौर पर, setAspectRatioLocked आकार बदलते समय आकार के अनुपात को बरकरार रखता है।
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

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो PictureFillFormat पर स्ट्रेच‑ऑफ़सेट मान पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष फ़िल आयत को परिभाषित करते हैं। पॉज़िटिव प्रतिशत किनारे से इन्सेट बनाते हैं, जबकि नेगेटिव प्रतिशत आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत इमेज के किस भाग को दिखाया जाए चुनते हैं; स्ट्रेच ऑफ़सेट वह आयत बदलते हैं जिसमें दृश्यमान पिक्चर फ़िल को स्ट्रेच किया जाता है।
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

फ़िल प्लेसमेंट के लिए स्ट्रेच ऑफ़सेट का उपयोग करें। जब लक्ष्य स्रोत‑इमेज किनारों को छिपाना हो, तब क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार और एक्सपोर्ट विचार**

मुख्य ट्रेड‑ऑफ़ तब आसान प्रबंधन योग्य होते हैं जब इमेज स्टोरेज और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग माना जाये:
- **एंबेडेड इमेजेज** प्रस्तुति को स्वयं‑संकुलित बनाते हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे विश्वसनीय होते हैं, लेकिन बड़े रास्टर इमेजेज PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **लिंक्ड इमेजेज** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति उन बाहरी फ़ाइलों पर निर्भर करती है कि वे संग्रहीत पाथ या लोकेशन पर उपलब्ध रहें।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी होती है। छिपे पिक्सेल एंबेडेड रहते हैं जब तक कि क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संकुचन के दौरान न हटाए जाएँ।
- **संकुचन** बहुत बड़े रास्टर इमेजेज के लिए फ़ाइल आकार को काफी घटा सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन का त्याग करता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG इमेजेज** को तब SVG के रूप में रखा जाना चाहिए जब वेक्टर संरक्षण महत्वपूर्ण हो। जब आपको वेक्टर रिसोर्स स्वयं चाहिए, तो एंबेडेड SVG को सीधे निकालें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदलता है।
- **दोहराई गई इमेजेज** को संभव हो तो मौजूदा PPImage रिसोर्स को पुनः उपयोग करना चाहिए, बजाय एक ही फ़ाइल को बार‑बार प्रस्तुति वर्कफ़्लो में लोड करने के।

बड़ी प्रस्तुतियों के लिए, इमेज ऑप्टिमाइज़ेशन आमतौर पर तब सबसे प्रभावी होता है जब चयनित रूप में किया जाए: लोगो और डायग्राम को वेक्टर कंटेंट के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सेल को केवल तब हटाएँ जब बाद में एडिटिंग आवश्यक न हो, और बाहरी लिंक से बचें जब तक कि निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा न हो।

## **FAQ**

**पिक्चर फ्रेम और इमेज रिसोर्स में क्या अंतर है?**  
एक PPImage प्रस्तुति से जुड़ा इमेज रिसोर्स दर्शाता है। एक PictureFrame स्लाइड पर एक आकार है जो इमेज को प्रदर्शित करता है और फ्रेम‑स्तरीय ज्योमेट्री और स्वरूपण जैसे आकार, घुमाव, क्रॉप मान, इफ़ेक्ट्स और लॉक को संग्रहीत करता है।

**मुझे इमेजेज एंबेड करनी चाहिए या लिंक करनी चाहिए?**  
जब प्रस्तुति को पोर्टेबल, आर्काइव्ड या बाहरी संसाधनों तक पहुँच के बिना रेंडर करने की आवश्यकता हो, तब इमेजेज एंबेड करें। केवल तब इमेजेज को लिंक करें जब PPTX के बाहर इमेज फ़ाइलें रखना इरादतन हो और बाहर के स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को कम करती है?**  
स्वयं में नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के भागों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सकता है, तो PictureFillFormat::deletePictureCroppedAreas या क्रॉप्ड‑एरिया हटाने के साथ इमेज संकुचन का उपयोग करें।

**क्या मैं संकुचन के बाद इमेज क्वालिटी को पुनः स्थापित कर सकता हूँ?**  
नहीं। संकुचन संग्रहीत रास्टर रिज़ॉल्यूशन को घटा सकता है, और क्रॉप्ड क्षेत्रों को हटाने से इमेज डेटा हट जाता है। यदि बाद में हाई‑रेज़ोल्यूशन एडिटिंग की आवश्यकता हो, तो मूल स्रोत इमेज को प्रस्तुति के बाहर रखें।

**SVG इमेजेज को कैसे संभालना चाहिए?**  
जब वेक्टर फिडेलिटी महत्वपूर्ण हो, तो SVG कंटेंट को SVG के रूप में रखें। एंबेडेड SvgImage को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में रेंडर करने से SVG स्लाइड इमेज का हिस्सा बनकर रास्टराइज़ हो जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित कास्ट कैसे बचा सकता हूँ?**  
पिक्चर‑फ़्रेम‑विशिष्ट मेंबर का उपयोग करने से पहले आकार प्रकार की जांच करें। PictureFrame के खिलाफ `java_instanceof` जांच अवैध कास्ट से बचती है और कोड को उन स्लाइड्स को संभालने देती है जिनमें पिक्चर फ्रेम नहीं होते।