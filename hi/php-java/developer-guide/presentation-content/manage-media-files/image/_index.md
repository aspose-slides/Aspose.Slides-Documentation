---
title: PHP का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन करें
type: docs
weight: 10
url: /hi/php-java/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- छवि बदलें
- छवि संग्रह
- चित्र फ्रेम
- लिंक्ड छवि
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- SVG से आकृतियों में
- बाहरी SVG संसाधन
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for PHP via Java के साथ रास्टर और SVG छवियों को जोड़ने, पुन: उपयोग करने, लिंक करने, बदलने और प्रबंधित करने के बारे में जानें।"
---
## **परिचय**

Aspose.Slides for PHP via Java छवियों के साथ काम करने के कई तरीके प्रदान करता है, और प्रत्येक का अलग उद्देश्य है। आप प्रस्तुति में छवि को संग्रहीत कर सकते हैं, उसे चित्र फ्रेम में प्रदर्शित कर सकते हैं, स्लाइड पृष्ठभूमि के रूप में उपयोग कर सकते हैं, बाहरी छवि के लिए लिंक बना सकते हैं, साझा छवि संसाधन को बदल सकते हैं, या SVG सामग्री को संपादन योग्य आकृतियों में बदल सकते हैं।

यह लेख छवि संसाधनों और उनके प्रस्तुति में उपयोग पर केंद्रित है। क्रॉपिंग, पारदर्शिता, प्रभाव, स्ट्रेचिंग और व्यक्तिगत चित्र फ्रेम पर लागू अन्य स्वरूपण के लिए, देखें [Picture Frame](/slides/hi/php-java/picture-frame/)।

## **इमेज मॉडल को समझें**

निम्नलिखित API अवधारणाएँ निकटता से संबंधित हैं लेकिन आपस में बदलने योग्य नहीं हैं:

- [presentation image collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) प्रस्तुति द्वारा उपयोग की जाने वाली छवि संसाधनों को संग्रहीत करता है। छवि डेटा जोड़ने और एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) संसाधन प्राप्त करने के लिए [ImageCollection::addImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) का उपयोग करें।
- एक [picture frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) वह आकृति है जो स्लाइड, लेआउट या मास्टर पर छवि प्रदर्शित करती है। छवि संसाधन को स्लाइड पर रखने के लिए [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) का उपयोग करें।
- स्लाइड पृष्ठभूमि छवि को स्लाइड फ़िल के हिस्से के रूप में उपयोग करती है, न कि आकृति के रूप में। इसलिए इसका व्यवहार चित्र फ्रेम जैसा नहीं होता।
- [PPImage::replaceImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) छवि संसाधन को बदलता है। यदि कई प्रस्तुति तत्व उस संसाधन का उपयोग करते हैं, तो वे सभी प्रतिस्थापन को अपनाते हैं।
- SVG को आकृतियों में बदलने से संपादन योग्य स्लाइड आकृतियों का निर्माण होता है। परिवर्तन के बाद, सामग्री को अब एकल चित्र संसाधन के रूप में प्रबंधित नहीं किया जाता।

एक सामान्य कार्यप्रवाह इस प्रकार है: छवि डेटा को इमेज कलेक्शन में जोड़ें, एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) प्राप्त करें, और फिर उस संसाधन का उपयोग एक या अधिक चित्र फ्रेम या फ़िल में करें।

## **एक एंबेडेड चित्र जोड़ें**

स्थानीय छवि डालने के लिए फ़ाइल को लोड करें, उसे इमेज कलेक्शन में जोड़ें, और लौटाए गए `PPImage` का उपयोग करने वाला एक picture frame बनाएं।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

इस प्रकार जोड़ दी गई छवि प्रस्तुति में एंबेडेड रहती है, इसलिए परिणामस्वरूप फ़ाइल मूल छवि फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से छवि जोड़ें**

जब कोई छवि HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रस्तुति इमेज कलेक्शन में जोड़ें, और लौटाए गए छवि संसाधन का वही तरीका उपयोग करके स्थानीय छवि की तरह उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

दीर्घकालिक अनुप्रयोगों में, अनावश्यक नेटवर्किंग इंफ़्रास्ट्रक्चर को बार‑बार बनाने के बजाय अनुप्रयोग के अनुकूल HTTP क्लाइंट या कनेक्शन‑मैनेजमेंट रणनीति को पुन: उपयोग करें। साथ ही जब स्रोत विश्वसनीय न हो, तो रिमोट URL, प्रतिक्रिया आकार और कंटेंट टाइप की वैधता जांचें।

## **स्लाइड्स में छवियों का पुन: उपयोग करें**

यदि एक ही छवि की आवश्यकता कई बार है, तो उसे प्रस्तुति में एक बार जोड़ें और अतिरिक्त picture frame बनाते समय लौटाए गए [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) को पुन: उपयोग करें। यह समान स्रोत डेटा को बार‑बार लोड करने से बचाता है और साझा छवि संसाधन व उसके उपयोगों के बीच संबंध को स्पष्ट करता है।

ऐसे ग्राफ़िक्स जो कई स्लाइड्स पर स्वतः दिखने चाहिए, जैसे कंपनी का लोगो, प्रत्येक स्लाइड में समान आकृति जोड़ने के बजाय [slide master](/slides/hi/php-java/slide-master/) या लेआउट पर picture frame रखने पर विचार करें।

## **छवि को स्लाइड पृष्ठभूमि के रूप में उपयोग करें**

पृष्ठभूमि छवि स्लाइड फ़िल को असाइन की जाती है; इसे picture‑frame आकृति के रूप में नहीं जोड़ा जाता। यह उपयोगी है जब चित्र को स्लाइड पृष्ठभूमि पर पूरी तरह से कवर करना हो और उसे सामान्य स्लाइड ऑब्जेक्ट की तरह हेर‑फेर नहीं करना हो।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अधिक पृष्ठभूमि विकल्पों के लिए, जिसमें मास्टर और लेआउट पृष्ठभूमि शामिल हैं, देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।

## **एंबेडेड छवियाँ और लिंक्ड छवियाँ**

एंबेडेड और लिंक्ड छवियों में पोर्टेबिलिटी और फ़ाइल‑आकार के अलग‑अलग व्यापार‑ऑफ़ होते हैं:

- **एंबेडेड छवि:** छवि डेटा प्रस्तुति के भीतर संग्रहीत होता है। प्रस्तुति स्वयं‑समाहित होती है, पर फ़ाइल आकार में छवि डेटा शामिल होता है।
- **लिंक्ड छवि:** प्रस्तुति बाहरी छवि के पाथ या URL को संग्रहीत करती है। यह प्रस्तुति आकार को घटा सकता है, पर बाहरी संसाधन को खोलते या रेंडर करते समय उपलब्ध होना आवश्यक है।

बाहरी पाथ या URL को [Picture::setLinkPathLong](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/) के माध्यम से असाइन करके लिंक्ड चित्र बनाया जा सकता है, बजाय छवि डेटा को एंबेड करने के।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

केवल तब लिंक्ड छवियों का उपयोग करें जब डिप्लॉयमेंट वातावरण विश्वसनीय रूप से बाहरी संसाधन तक पहुँच सकता हो। जिन प्रस्तुतियों को ऑफलाइन काम करना है या सिस्टमों के बीच ले जाना है, उनके लिए एंबेडेड छवियां आमतौर पर सुरक्षित रहती हैं।

## **SVG छवियों के साथ काम करें**

SVG एक वेक्टर प्रारूप है, इसलिए आइकॉन, आरेख और अन्य ग्राफ़िक्स के लिए उपयोगी है जिन्हें रास्टर छवियों की तरह विवरण की हानि के बिना स्केल किया जा सके। Aspose.Slides SVG को छवि संसाधन और संपादन योग्य स्लाइड आकृतियों दोनों के स्रोत के रूप में समर्थन देता है।

### **SVG को छवि के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) बनाएं, उसे इमेज कलेक्शन में जोड़ें, और परिणामी छवि संसाधन को picture frame में रखें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **बाहरी संसाधनों वाले SVG फ़ाइलें**

एक SVG बाहरी छवियों, स्टाइलशीट्स या फ़ॉन्ट्स को संदर्भित कर सकता है। इन मामलों के लिए, [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) ऐसे कन्स्ट्रक्टर प्रदान करता है जो एक [ExternalResourceResolver](https://reference.aspose.com/slides/hi/php-java/aspose.slides/externalresourceresolver/) और बेस URI को स्वीकार करता है। रिज़ॉल्वर रिलेटिव URI को अनुमति प्राप्त एब्सोल्यूट URI में मैप कर सकता है और अनुरोधित संसाधन के लिए स्ट्रीम वापस कर सकता है।

रिज़ॉल्वर बाहरी संसाधनों को उपलब्ध कराता है जबकि Aspose.Slides SVG को प्रोसेस करता है, लेकिन यह SVG को स्वयं‑समाहित दस्तावेज़ में नहीं बदलता। यदि SVG को पोर्टेबल रखना है, तो आवश्यक संसाधनों को SVG के भीतर एंबेड करें, उदाहरण के लिए लिंक्ड छवियों के लिए `data:` URI का उपयोग करके।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रिज़ॉल्वर द्वारा एक्सेस किए जा सकने वाले स्कीम, फ़ाइल स्थान और होस्ट को सीमित करें। नेटवर्क रिज़ॉल्वर को टाइमआउट, प्रतिक्रिया‑आकार सीमाएँ और कंटेंट वैलिडेशन भी लागू करना चाहिए।

### **SVG को संपादन योग्य आकृतियों में बदलें**

Aspose.Slides SVG को संपादन योग्य स्लाइड आकृतियों के समूह में बदल सकता है, जो संबंधित PowerPoint कमांड जैसा है।

![PowerPoint Popup Menu](img_01_01.png)

परिवर्तन करने के लिए उस [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addgroupshape/) ओवरलोड का उपयोग करें जो एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) को स्वीकार करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

SVG‑to‑shapes परिवर्तन तब उपयोग करें जब व्यक्तिगत वेक्टर तत्वों को PowerPoint आकृतियों के रूप में संपादित करना हो। यदि SVG केवल दिखाने के लिए है, तो उसे छवि के रूप में रखना सरल है और अनेक अलग‑अलग आकृतियों के निर्माण से बचता है।

## **मौजूद छवि संसाधन को बदलें**

जब आप कोई मौजूदा छवि संसाधन बदलना चाहते हैं, तो [PPImage::replaceImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) का उपयोग करें। यह विशेष रूप से लोगो जैसे साझा ग्राफ़िक्स के लिए उपयोगी है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि कई picture frame, पृष्ठभूमि, मास्टर या लेआउट एक ही छवि संसाधन का उपयोग करते हैं, तो उस संसाधन को बदलने से सभी उपयोग अपडेट हो जाते हैं। यदि केवल एक picture frame को बदलना है, तो साझा संसाधन को बदलने के बजाय उस फ्रेम को अलग छवि असाइन करें।

`PPImage::replaceImage` बाइट एरे या किसी अन्य [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) को स्वीकार करने वाले ओवरलोड भी प्रदान करता है।

## **व्यावहारिक छवि प्रबंधन मार्गदर्शिका**

### **प्रस्तुति आकार को नियंत्रित करें**

बड़ी रास्टर छवियां प्रस्तुति को अनावश्यक रूप से बड़े आकार की बना सकती हैं। उपयोग के उद्देश्य के अनुसार उपयुक्त आयाम वाली स्रोत छवियों का उपयोग करें, जहाँ संभव हो साझा छवि संसाधनों को पुन: उपयोग करें, और समान पूर्ण‑रिज़ॉल्यूशन ग्राफ़िक की कई प्रतियों को एंबेड करने से बचें।

रास्टर चित्र जो पहले ही picture frame में रखे गए हैं, उनके लिए [PictureFillFormat::compressImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग्स के आधार पर छवि डेटा को कम कर सकता है। यह picture‑frame प्रोसेसिंग है, न कि इमेज‑कलेक्शन प्रबंधन, इसलिए संबंधित फ़ॉर्मेटिंग कार्यों के लिए देखें [Picture Frame](/slides/hi/php-java/picture-frame/)।

### **एंबेडेड और लिंक्ड कंटेंट के बीच चयन करें**

एंबेडिंग प्रस्तुति को पोर्टेबल बनाता है क्योंकि सभी आवश्यक छवि डेटा फ़ाइल के साथ रहता है। लिंकिंग फ़ाइल आकार को घटा सकता है, पर एक बाहरी निर्भरता पेश करता है। लिंक केवल तभी उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **साझा ब्रांडिंग का पुन: उपयोग करें**

बार‑बार प्रयुक्त लोगो, वॉटरमार्क या सजावटी ग्राफ़िक्स के लिए एक ही छवि संसाधन का उपयोग करें। यदि ग्राफ़िक प्रस्तुति डिजाइन का भाग है न कि स्लाइड कंटेंट, तो उसे मास्टर या लेआउट पर रखें ताकि संबंधित स्लाइड्स द्वारा विरासत में मिला सके।

### **SVG संसाधनों को पोर्टेबल रखें**

एक स्वयं‑समाहित SVG को बाहरी फ़ाइलों या नेटवर्क संसाधनों पर निर्भर SVG की तुलना में ले जाना और स्थिर रूप से रेंडर करना आसान होता है। संभव हो तो SVG आयात करने से पहले आवश्यक संसाधनों को एंबेड करें। केवल तब SVG को आकृतियों में बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करने की आवश्यकता हो।

### **आधुनिक क्रॉस‑प्लैटफ़ॉर्म इमेज API का उपयोग करें**

नए PHP via Java कोड के लिए, Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/php-java/aspose.slides/images/) API का उपयोग करें, न कि `java.awt.image.BufferedImage` पर आधारित पुरानी सार्वजनिक API का। माइग्रेशन मार्गदर्शन के लिए देखें [Modern API](/slides/hi/php-java/modern-api/)।

WMF और EMF को विशेष विचार की आवश्यकता होती है। जब ये फ़ॉर्मेट एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) के माध्यम से पास किए जाते हैं, तो [ImageCollection::addImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) मेटाफाइल को PNG रास्टर प्रतिनिधित्व में बदल देता है। यदि मेटाफाइल डेटा को संरक्षित रखना आवश्यक है, तो स्ट्रीम‑आधारित [ImageCollection::addImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री उत्पन्न करना एक अलग इंटीग्रेशन कार्यप्रवाह है और इस लेख के दायरे से बाहर है।

## **FAQ**

**इमेज कलेक्शन और picture frame में क्या अंतर है?**

इमेज कलेक्शन पुन: उपयोग योग्य छवि संसाधनों को संग्रहीत करता है। picture frame एक स्लाइड आकृति है जो उन संसाधनों में से एक को प्रदर्शित करती है और क्रॉपिंग तथा इफ़ेक्ट जैसी चित्र‑विशिष्ट स्वरूपण प्रदान करती है।

**सभी जगह एक ही लोगो बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से ही एक छवि संसाधन के रूप में साझा किया गया है, तो उसे [PPImage::replaceImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) से बदलें। प्रस्तुति‑व्यापी ब्रांडिंग के लिए, लोगो को मास्टर या लेआउट पर रखने से डुप्लिकेट स्लाइड कंटेंट कम किया जा सकता है।

**लिंक्ड छवि दूसरे कंप्यूटर पर क्यों गायब हो जाती है?**

लिंक्ड चित्र अपने बाहरी फ़ाइल या URL पर निर्भर करता है। यदि वह संसाधन दूसरे कंप्यूटर से पहुँचा नहीं जा सकता, तो लिंक्ड छवि अनुपलब्ध हो जाएगी। जब प्रस्तुति को स्वयं‑समाहित होना आवश्यक हो, तो छवि को एंबेड करें।

**क्या डाली गई SVG को PowerPoint आकृतियों के रूप में संपादित किया जा सकता है?**

हाँ। SVG को [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addgroupshape/) से बदलें; परिणामी समूह में संपादन योग्य स्लाइड आकृतियाँ होंगी, न कि एकल SVG चित्र।

**मैं कई छवियों वाली प्रस्तुतियों को छोटे कैसे रख सकता हूँ?**

साझा छवि संसाधनों का पुन: उपयोग करें, अनावश्यक बड़ी रास्टर स्रोतों से बचें, उपयुक्त रास्टर चित्रों को आवश्यकतानुसार संपीड़ित करें, ब्रांडिंग को मास्टर या लेआउट पर रखें, और लिंक्ड छवियों का उपयोग केवल तब करें जब बाहरी निर्भरता स्वीकार्य हो।