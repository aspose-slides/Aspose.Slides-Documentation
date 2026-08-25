---
title: PHP का उपयोग करके प्रेजेंटेशन्स में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/php-java/picture-frame/
keywords:
  - पिक्चर फ्रेम
  - पिक्चर फ्रेम जोड़ें
  - पिक्चर फ्रेम बनाएं
  - एम्बेडेड इमेज
  - लिंक्ड इमेज
  - इमेज निकालें
  - रास्टर इमेज
  - SVG इमेज
  - इमेज क्रॉप करें
  - क्रॉप्ड क्षेत्रों को हटाएँ
  - इमेज कम्प्रेस करें
  - StretchOffset
  - पिक्चर फ्रेम फ़ॉर्मेटिंग
  - रिलेटिव स्केल
  - इमेज इफ़ेक्ट
  - पहलू अनुपात
  - PowerPoint
  - OpenDocument
  - प्रेजेंटेशन
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रेजेंटेशन्स में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और कम्प्रेस करें।"
---
## **परिचय**

एक पिक्चर फ्रेम एक स्लाइड आकार है जो छवि प्रदर्शित करता है। Aspose.Slides में, इमेज रिसोर्स और उसे प्रदर्शित करने वाला आकार अलग-अलग ऑब्जेक्ट होते हैं: एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) अपने [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) के माध्यम से एम्बेडेड इमेज रिसोर्सेज को रखता है, जबकि एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) इमेज की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, रोटेशन, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑लेवल सेटिंग्स को नियंत्रित करता है।

एक ही छवि को कई बार दिखाने का मामला होने पर यह विभाजन उपयोगी होता है। छवि को प्रेजेंटेशन में एक बार जोड़ें, लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) को रखें, और पिक्चर फ्रेम बनाते समय उस इमेज रिसोर्स का प्रयोग करें।

पिक्चर फ्रेम में PNG या JPEG जैसे रास्टर इमेज तथा SVG जैसे वेक्टर इमेज दोनों हो सकते हैं। वे इमेज बाइट्स को प्रेजेंटेशन में संग्रहीत करने के बजाय लिंक्ड इमेज की ओर भी इशारा कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि इमेज कैसे संग्रहीत की जानी चाहिए।

## **एक एम्बेडेड इमेज जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड इमेज के लिये, इमेज डेटा को प्रेजेंटेशन में जोड़ें और [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) के साथ पिक्चर फ्रेम बनाएं। इमेज प्रेजेंटेशन पैकेज का हिस्सा बन जाता है, इसलिए प्रेजेंटेशन को किसी दूसरे कंप्यूटर पर ले जाने पर वह स्वनिहित बना रहता है।

निम्न उदाहरण JPEG इमेज जोड़ता है, इमेज के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग तथा रोटेशन लागू करता है:

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

पिक्चर फ्रेम प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम आकार बदलने से एम्बेडेड इमेज रिसोर्स में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में इमेज को क्रॉप या कॉम्प्रेस करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केलिंग को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/setrelativescalewidth/) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/setrelativescaleheight/) के माध्यम से उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के बराबर होता है। रिलेटिव स्केल तब उपयोगी होता है जब कार्यप्रवाह को स्रोत इमेज आकार के अनुपात को बनाए रखना हो, न कि अंतिम आयाम को मैन्युअल रूप से गणना करना।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड इमेज को री‑सैंपल या कॉम्प्रेस नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज**

एक एम्बेडेड पिक्चर इमेज डेटा को प्रेजेंटेशन के अंदर रखती है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिये सबसे सुरक्षित विकल्प है। एक लिंक्ड पिक्चर [Picture::setLinkPathLong](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/setlinkpathlong/) मेथड के माध्यम से बाहरी स्थान को संग्रहीत करता है, न कि इमेज डेटा को उसी तरह एम्बेड करता है।

लिंक्ड इमेजेज PPTX में संग्रहीत इमेज डेटा की मात्रा को कम कर सकती हैं, लेकिन वे बाहरी निर्भरता लाती हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिये सुलभ रहना चाहिए जो प्रेजेंटेशन खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या रिसोर्स अनुपलब्ध हो जाता है, तो लिंक्ड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रेजेंटेशन्स के लिये जो ई‑मेल, आर्काइव, या अलग‑थलग वातावरण में रेंडर किए जाने हैं, एम्बेडेड इमेजेज आमतौर पर अधिक भरोसेमंद होती हैं।

### **एक लिंक्ड इमेज जोड़ें**

निम्न उदाहरण पिक्चर फ्रेम बनाता है और उसे स्थानीय इमेज फ़ाइल की ओर इशारा करता है। यह केवल इमेज लिंकिंग को दर्शाता है; वीडियो लिंकिंग एक अलग मीडिया कार्यप्रवाह है और इस उदाहरण में जानबूझकर मिश्रित नहीं किया गया है।

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

बाहरी फ़ाइल प्रबंधन का इरादा हो तो लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज निर्भरताओं वाला छोटा PPTX आमतौर पर बड़े स्वनिहित प्रेजेंटेशन से कम उपयोगी होता है।

## **पिक्चर फ्रेम से इमेज निकालें**

किसी मौजूदा प्रेजेंटेशन से इमेज निकालने से पहले यह जाँचें कि आकार वास्तव में एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) है और उसमें एम्बेडेड इमेज शामिल है। लिंक्ड पिक्चर फ्रेम में वह इमेज बाइट्स नहीं हो सकते जिन्हें समान रूप से निकाला जा सके।

### **एक रास्टर इमेज निकालें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) का उपयोग करता है। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड रास्टर चित्र खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/#save) के माध्यम से सहेजने से निकाली गई इमेज अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित हो जाती है। यदि आपको प्रेजेंटेशन में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो इमेज रिसोर्स के बाइनरी डेटा का उपयोग करें, न कि परिवर्तित रास्टर फ़ाइल का।

### **एक SVG इमेज निकालें**

SVG चित्र के लिये, [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) ऑब्जेक्ट उजागर करता है। इस तरह आप SVG डेटा को सीधे प्राप्त कर सकते हैं, बिना पहले चित्र को रास्टराइज़ किए।

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

SVG कंटेंट को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे रास्टर एक्सपोर्ट स्वाभाविक रूप से उस वेक्टर कंटेंट को पिक्सेल में रेंडर करते हैं। PDF या SVG स्लाइड एक्सपोर्ट भी एक रेंडरिंग प्रक्रिया है, इसलिए निर्यातित ग्राफिक्स को मूल एम्बेडेड SVG की बाइट‑फॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर रिसोर्स आवश्यक हो तो एम्बेडेड [SvgImage::getSvgData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/getsvgdata/) डेटा का प्रयोग करें।

## **एक इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के किस भाग को दिखाया जाए, इसे बदलता है। [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) पर क्रॉप मान स्रोत इमेज आयामों के प्रतिशत होते हैं। क्रॉपिंग मूल एम्बेडेड इमेज से छिपे पिक्सेल को तुरंत नहीं हटाती; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से पिक्चर फ्रेम खोजता है और क्रॉप मान लागू करता है:

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

क्योंकि छिपा इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदल सकता है। यदि फ़ाइल आकार का महत्व रिवर्सिबिलिटी से अधिक है, तो अगले अनुभाग में वर्णित अनुसार क्रॉप्ड क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप्ड इमेज डेटा हटाएँ**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) वर्तमान क्रॉप आयत से बाहर के इमेज डेटा को हटाता है और परिणामी इमेज रिसोर्स लौटाता है। इससे फ़ाइल आकार घट सकता है, परन्तु यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रेजेंटेशन सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिये उपलब्ध नहीं रहते।

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

यह मेथड प्रेजेंटेशन में एक नया इमेज रिसोर्स जोड़ सकता है। यदि मूल इमेज अन्य पिक्चर फ्रेम द्वारा भी उपयोग की जाती है, तो उन फ्रेमों को अभी भी अपना मौजूदा रिसोर्स चाहिए होता है, इसलिए क्रॉप्ड क्षेत्रों को हटाने से कुल इमेज की संख्या अनिवार्य रूप से घटती नहीं है। WMF या EMF कंटेंट को इस मेथड से क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर इमेजेस को कम्प्रेस करें**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) रास्टर इमेज की रिज़ोल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर चित्र प्रदर्शित होता है। यह एक ही ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब इमेज रिसाइज़ या क्रॉप हुई हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब मानक लक्ष्य रिज़ोल्यूशन पर्याप्त हो, तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि विशिष्ट लक्ष्य आवश्यक हो तो एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

कम्प्रेशन रास्टर इमेजेस के लिये अभिप्रेत है। SVG और मेटाफाइल कंटेंट इस रास्टर कम्प्रेशन वर्कफ़्लो द्वारा नहीं घटते। साथ ही याद रखें कि कम रिज़ोल्यूशन और हटाए गए क्रॉप्ड क्षेत्र ऑप्टिमाइज़्ड प्रेजेंटेशन से पुनः प्राप्त नहीं किए जा सकते। लक्ष्य रिज़ोल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर इमेज वास्तव में देखी या एक्सपोर्ट की जाएगी, न कि पूरे प्रेजेंटेशन में सबसे कम DPI लागू करके।

## **इमेज ट्रांसफॉर्म इफ़ेक्ट्स को मैनेज करें**

पूर्ण कार्यप्रवाह जिसमें ब्राइटनेस, कंट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफ़ेक्ट्स, ऑर्डरड चेन, इंस्पेक्शन, रिमूवल और राउंड‑ट्रिप वेरिफिकेशन शामिल हैं, के लिये देखें [Image Transform Effects](/php-java/image-transform-effects/)।

## **पिक्चर फ्रेम जॉमेट्री को लॉक करें**

[PictureFrameLock](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/) सेटिंग्स निर्धारित करती हैं कि पिक्चर फ्रेम के कौन‑से संपादन कार्य निष्क्रिय हैं। उदाहरण के लिये, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) आकार बदलते समय आकृति के अनुपात को बनाए रखता है।

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

यह लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिये बाध्य नहीं करता।

## **StretchOffset मान समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [PictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) पर स्ट्रेच‑ऑफ़सेट मान पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष भराव आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक इनसेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत इमेज के किस भाग को दिखाया जाए, इसे चुनते हैं; स्ट्रेच ऑफ़सेट दृश्यमान पिक्चर फ़िल को किस आयत में खींचा जाए, इसे बदलते हैं।

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

फ़िल प्लेसमेंट के लिये स्ट्रेच ऑफ़सेट का उपयोग करें। जब लक्ष्य स्रोत‑इमेज किनारों को छुपाना हो, तो क्रॉप प्रॉपर्टी उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और एक्सपोर्ट पर विचार**

मुख्य ट्रेड‑ऑफ़ तब आसान हो जाते हैं जब इमेज स्टोरेज और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग संभाला जाए:

- **एम्बेडेड इमेजेज** प्रेजेंटेशन को स्वनिहित बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिये सबसे भरोसेमंद हैं, परंतु बड़ी रास्टर इमेजेज PPTX आकार और मेमोरी उपयोग को बढ़ा देती हैं।
- **लिंक्ड इमेजेज** पैकेज को छोटा रख सकती हैं, परंतु प्रेजेंटेशन को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर होना पड़ता है।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी है। छुपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक कि क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया न जाए या कॉम्प्रेशन के दौरान हटा न दिया जाए।
- **कम्प्रेशन** अत्यधिक बड़े रास्टर इमेजेज के फ़ाइल आकार को उल्लेखनीय रूप से घटा सकता है, परंतु स्रोत रिज़ोल्यूशन का त्याग करता है। इसे स्लाइड पर वास्तविक आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG इमेजेज** को वेक्टर संरक्षण आवश्यक होने पर SVG के रूप में रखना चाहिए। जब आपको स्वयं वेक्टर रिसोर्स चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदलते हैं।
- **दोहराए गए इमेजेज** संभव हो तो मौजूदा [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) रिसोर्स का पुनः उपयोग करें, बजाय कि एक ही फ़ाइल को बार‑बार प्रेजेंटेशन वर्कफ़्लो में लोड करने के।

बड़ी प्रेजेंटेशन्स के लिये इमेज ऑप्टिमाइज़ेशन आमतौर पर चयनात्मक रूप से अधिक प्रभावी होती है: लोगो और डायग्राम को वेक्टर कंटेंट के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार कॉम्प्रेस करें, क्रॉप्ड पिक्सेल तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी रखें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का भाग हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**पिक्चर फ्रेम और इमेज रिसोर्स में क्या अंतर है?**

एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) प्रेजेंटेशन से संबद्ध इमेज रिसोर्स का प्रतिनिधित्व करता है। एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) स्लाइड पर वह आकार है जो इमेज प्रदर्शित करता है और फ्रेम‑लेवल ज्योमेट्री तथा फ़ॉर्मेटिंग जैसे आकार, रोटेशन, क्रॉप मान, इफ़ेक्ट्स और लॉक को संग्रहीत करता है।

**इमेज को एम्बेड करना चाहिए या लिंक?**

जब प्रेजेंटेशन को पोर्टेबल, आर्काइव या बाहरी रिसोर्सेस के बिना रेंडर करने की जरूरत हो, तो इमेजेज को एम्बेड करें। लिंक्ड इमेजेज केवल तभी उपयोग करें जब इमेज फ़ाइलों को PPTX के बाहर रखना अभिप्रेत हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग से PPTX फ़ाइल आकार कम होता है?**

केवल क्रॉप सेटिंग्स से नहीं। सामान्य क्रॉप मान स्रोत इमेज के भागों को छुपाते हैं लेकिन नीचे के पिक्सेल को रखते हैं। जब इन पिक्सेल को स्थायी रूप से हटाया जा सके, तो [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) या क्रॉप्ड‑एरिया हटाने के साथ इमेज कॉम्प्रेशन का प्रयोग करें।

**कम्प्रेशन के बाद इमेज क्वालिटी पुनः प्राप्त की जा सकती है?**

नहीं। कम्प्रेशन स्टोर की गई रास्टर रिज़ोल्यूशन कम करता है, और क्रॉप्ड क्षेत्रों को हटाना इमेज डेटा को हटा देता है। यदि बाद में उच्च‑रिज़ोल्यूशन संपादन की आवश्यकता हो, तो मूल स्रोत इमेज को प्रेजेंटेशन के बाहर रखें।

**SVG इमेजेज को कैसे संभालें?**

जब वेक्टर फिडेलिटी महत्वपूर्ण हो, तो SVG कंटेंट को SVG के रूप में रखें। एम्बेडेड [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में एक्सपोर्ट करने से SVG पिक्सेल में रेंडर हो जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

शेप टाइप को उपयोग करने से पहले जांचें। [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) के विरुद्ध एक `java_instanceof` जांच असुरक्षित कास्ट को रोकती है और कोड को उन स्लाइड्स को संभालने देती है जिनमें पिक्चर फ्रेम नहीं होते।