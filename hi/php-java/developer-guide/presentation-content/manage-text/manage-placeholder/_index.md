---
title: PHP में प्रस्तुति प्लेसहोल्डर प्रबंधन
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/php-java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- चित्र प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ टेक्स्ट, चित्र, चार्ट और कंटेंट प्लेसहोल्डर की जांच और संपादन करना और प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **अवलोकन**

एक प्लेसहोल्डर वह आकृति है जो प्रस्तुति टेम्पलेट में किसी विशिष्ट प्रकार की सामग्री के लिए स्थिति आरक्षित करता है। सामान्य उदाहरण हैं शीर्षक, बॉडी, चित्र, चार्ट और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर। सामान्य आकृति के विपरीत, प्लेसहोल्डर अपने स्थान, आकार, स्वरूपण और अन्य सेटिंग्स को लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) मेथड द्वारा उजागर करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य आकृति के लिए `null` लौटाता है। प्लेसहोल्डर में क्या होना चाहिए, यह निर्धारित करने के लिए [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) का उपयोग करें।

प्लेसहोल्डर प्रकार जानने के बाद भी आकृति वर्ग महत्वपूर्ण रहता है:

- एक खाली टेक्स्ट, चित्र, चार्ट या कंटेंट प्लेसहोल्डर आमतौर पर एक [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) द्वारा प्रतिनिधित्व किया जाता है।
- एक भरे हुए चित्र प्लेसहोल्डर को एक [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरे हुए चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को केवल [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) मानने के बजाय दोनों [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) और रन‑टाइम आकृति वर्ग को जांचें।

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकृति के रन‑टाइम वर्ग की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, तालिका या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार जाँचें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: प्रयोज्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर भी।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइड द्वारा उपयोग की जाने वाली व्यवस्था निर्धारित करती है और मास्टर से विरासत ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर रखती है और अपने लेआउट से विरासत ले सकती है।

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जाएँ। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। यदि आकृति का कोई बेस प्लेसहोल्डर नहीं है तो मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर की सूची देता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइडों पर प्रभाव पड़ सकता है जो अभी भी वह सेटिंग विरासत में लेती हैं। एक स्थानीय सामान्य आकृति का कोई बेस प्लेसहोल्डर नहीं होता और केवल समान निर्देशांक होने के कारण वह विरासत नहीं शुरू करता।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्प्लेट को अनुकूलित करते समय, किसी मौजूदा ऑब्जेक्ट को सामान्य आकृति बनाए रखने के लिए [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) का उपयोग करें। उसकी [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) मेथड `null` लौटाती है, परंतु आकृति स्लाइड के संग्रह में बनी रहती है। इसके विपरीत, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) आकृति को उस संग्रह से हटा देती है।

नीचे दिया गया उदाहरण `template.pptx` को आवश्यक स्रोत मानता है जिसमें कम से कम एक स्लाइड और पहले स्लाइड पर एक गैर‑खाली टेक्स्ट प्लेसहोल्डर है। लेआउट या मास्टर से विरासत स्वरूपित प्लेसहोल्डर का उपयोग करके संबंध हटाने के प्रभाव को देखें। उदाहरण यह जाँचता है कि वही आकृति बनी रहती है, फिर उसी सामान्य आकृति पर मेथड को पुनः कॉल करता है, और परिणाम सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति हटाने से विरासत रूप‑रेखा सेटिंग्स स्वचालित रूप से संरक्षित नहीं रहतीं। नीचे का उदाहरण जानबूझकर उन सेटिंग्स को जैसे का तैसा छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। पूरी तरह विरासत में मिली स्थितियों और आकार वाले एक आकृति को कॉल के बाद शून्य निर्देशांक और आयाम मिल सकते हैं और वह अदृश्य हो सकता है, हालांकि वह संग्रह में बनी रहती है।
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // एक सामान्य आकृति पर इस मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

एक संगत प्लेसहोल्डर के लिए सभी तीन जाँचें `true` प्रिंट करती हैं। टेक्स्ट बना रहता है, परंतु विरासत स्थितियाँ, आकार, घूर्णन, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ़्रेम मार्जिन, ऊर्ध्वाधर एंकरिंग, फ़िल, और रेखा सेटिंग्स प्लेसहोल्डर संबंध हटने पर बदल सकती हैं। उदाहरण के तौर पर, विरासत शीर्षक स्वरूपण सामान्य टेक्स्ट स्वरूपण में गिर सकता है। लेआउट के बारे में अधिक जानकारी के लिए [Slide Layout](/slides/hi/php-java/slide-layout/) देखें।

इच्छित रूप‑रेखा संरक्षित करने के लिए, कॉल से पहले हल की गई स्थिति, आकार और घूर्णन को कैप्चर करें, और आवश्यक प्रभावी स्वरूपण मानों को अलग‑अलग वेरिएबल में कॉपी करें। इन मानों को [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), और [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) के माध्यम से प्राप्त करें। केवल प्रभावी‑फ़ॉर्मेट वस्तुओं को रख कर भरोसा न रखें, क्योंकि उनका टेक्स्ट‑फ़ॉर्मेटिंग मान संबंध हटने के बाद बदल सकता है। बाद में कैप्चर किए गए मानों को सामान्य आकृति पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट परिवार, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, फ़िल और रेखा शामिल हैं।

विरासत आकृति ज्यामिति को भी स्पष्ट रूप से [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) के द्वारा असाइन किया जा सकता है। वर्गाकार टेक्स्ट प्लेसहोल्डर के लिए, इसका अर्थ है [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) असाइन करना; केवल फ़िल और रेखा को पुनर्स्थापित करना दृश्य वर्ग को पुनः स्थापित नहीं करेगा। अतिरिक्त प्रभाव या जटिल स्वरूपण वाले टेम्प्लेट को भी इन सेटिंग्स को संभालना आवश्यक होगा।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। उसके [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) मेथड से पहले [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) की जाँच करें।

यह उदाहरण पहले स्लाइड पर पहले शीर्षक प्लेसहोल्डर को अपडेट करता है और परिणाम सहेजता है:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यह पैटर्न चित्र, चार्ट, तालिका या मीडिया प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ऑब्जेक्ट मानने से बचाता है। यह प्लेसहोल्डर को उद्देश्य के आधार पर पहचानता है न कि कमजोर आकृति इंडेक्स पर निर्भर रहने से।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट एक खाली प्लेसहोल्डर में डिज़ाइन‑टाइम निर्देश होता है, जैसे *Click to add title*। इसे सामान्य स्लाइड की आकृति संग्रह से पहुँचने के बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट को [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) से प्राप्त करें और [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर इटरेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट बदलता है:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए निर्देशित है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर दे तो प्रॉम्प्ट प्रदर्शित नहीं रहता। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइडों के मौजूदा टेक्स्ट पर कोई प्रभाव नहीं पड़ता।

## **चित्र प्लेसहोल्डर अपडेट करें**

दो स्थितियों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) द्वारा प्रतिनिधित्व किया गया है, तो छवि को [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) और [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) के द्वारा बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो प्लेसहोल्डर के निर्देशांक पर [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) से एक चित्र फ़्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों स्थितियों को समर्थन देता है और प्रस्तुति को सहेजता है:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ़्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) में सेट्टर नहीं है। यह आरक्षित स्थिति रखता है परंतु अब प्लेसहोल्डर‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर को तैयार और भरें, फिर Aspose.Slides से उत्पन्न [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिए देखें [Manage Picture Frames](/slides/hi/php-java/picture-frame/)। ये ऑपरेशन्स चित्र फ़्रेम या चित्र फ़िल से संबंधित हैं, न कि प्लेसहोल्डर मेटाडेटा से।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

भरे हुए चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रन‑टाइम वर्ग दोनों के आधार पर ऐसे चार्ट को खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सामान्य कंटेंट प्लेसहोल्डर अक्सर [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों (चार्ट, तालिका, डायग्राम, चित्र, मीडिया) के लिए लॉन्चर की तरह काम करता है। एक बार भरा जाने के बाद, वास्तविक आकृति वर्ग की जाँच करें कि इसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), या [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides खाली [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) प्लेसहोल्डर को केवल [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) बदलकर [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) में नहीं बदलता; प्रकार क्लास के माध्यम से नहीं बदला जा सकता। खाली चार्ट या कंटेंट क्षेत्र को प्रोग्रामेटिक रूप से भरने के लिए, प्लेसहोल्डर के निर्देशांक पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर हटाएँ। नीचे दिया गया उदाहरण चार्ट के लिए यही करता है:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को कवर करता है परंतु लेआउट प्लेसहोल्डर से विरासत नहीं लेता। जब आपको इसकी श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलना हो, तो समर्पित [chart management articles](/slides/hi/php-java/powerpoint-charts/) देखें।

## **पूरा उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्न अंत‑से‑अंत उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकृति प्रकार जाँचता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जानबूझकर आकृति इंडेक्स मानने या सभी प्लेसहोल्डर को समान वर्ग मानने से बचता है।

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**एक बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित आकृति है जो लेआउट या मास्टर में स्थित होती है, जिससे अन्य प्लेसहोल्डर विरासत लेता है। इसे प्राप्त करने के लिए [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) का उपयोग करें। एक सामान्य स्थानीय आकृति `null` लौटाती है क्योंकि वह प्लेसहोल्डर पदानुक्रम में भाग नहीं लेती।

**क्या मैं सभी स्लाइड शीर्षकों को लेआउट प्लेसहोल्डर संपादित करके बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत स्वरूपण या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, परंतु मौजूदा शीर्षक सामग्री सामान्य स्लाइड में संग्रहीत होती है। प्रस्तुति में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों पर इटरेट करके प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करना होगा।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फ़ूटर प्लेसहोल्डर कैसे प्रबंधित करूँ?**

सही स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्तर पर हेडर और फ़ूटर मैनेजरों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/php-java/presentation-header-and-footer/).