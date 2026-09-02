---
title: PHP में प्रस्तुति प्लेसहोल्डर का प्रबंधन
linktitle: प्लेसहोल्डर का प्रबंधन
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
description: "Aspose.Slides for PHP via Java के साथ टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर्स का निरीक्षण और संपादन कैसे करें और प्लेसहोल्डर विरासत को समझें।"
---
## **अवलोकन**

एक placeholder वह shape है जो प्रस्तुति टेम्प्लेट में किसी विशेष प्रकार की सामग्री के लिए स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, मुख्य भाग, चित्र, चार्ट, और सामान्य‑उद्देश्य सामग्री placeholders शामिल हैं। सामान्य shape के विपरीत, एक placeholder अपनी स्थिति, आकार, फ़ॉर्मेटिंग, और अन्य सेटिंग्स को एक लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides placeholder जानकारी को [Shape::getPlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getplaceholder/) मेथड के माध्यम से उजागर करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/) वस्तु या सामान्य shape के लिए `null` लौटाता है। placeholder किस प्रकार की सामग्री रखने के लिए अभिप्रेत है, यह निर्धारित करने के लिए [Placeholder::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/gettype/) का उपयोग करें।

shape क्लास का महत्व placeholder प्रकार जानने के बाद भी बना रहता है:

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट placeholder आमतौर पर एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) द्वारा दर्शाया जाता है।
- एक भरे हुए चित्र placeholder को एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरे हुए चार्ट placeholder को एक [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है।
- एक कंटेंट placeholder कई प्रकार की सामग्री रख सकता है। प्रत्येक placeholder को [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) मानने के बजाय दोनों [Placeholder::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/gettype/) और रन‑टाइम shape क्लास की जाँच करें।

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/gettype/) placeholder की भूमिका को वर्णित करता है; यह shape की रन‑टाइम क्लास की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल, या मीडिया‑विशिष्ट सदस्य तक पहुँचने से पहले हमेशा प्रकार जाँच करें।
{{% /alert %}}

## **Placeholder विरासत को समझें**

Placeholders एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: प्रयोज्य शैलियों को परिभाषित करता है और कुछ मामलों में मास्टर‑स्तर के placeholders भी देता है।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइडों द्वारा उपयोग की जाने वाली व्यवस्था को परिभाषित करता है और मास्टर से विरासत ले सकता है।
3. एक सामान्य स्लाइड उस स्लाइड के placeholders को रखती है और अपने लेआउट से विरासत ले सकती है।

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जाएँ। एक स्लाइड placeholder सामान्यतः अपना लेआउट placeholder लौटाता है; एक लेआउट placeholder अपना मास्टर placeholder लौटा सकता है। जब shape के पास कोई बेस placeholder नहीं होता तो मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर placeholders की सूची देता है और उनके बेस placeholders की रिपोर्ट करता है:

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

एक सामान्य स्लाइड पर placeholder को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइडों पर प्रभाव पड़ता है जो अभी भी उस सेटिंग को विरासत में लेती हैं। एक स्थानीय सामान्य shape का कोई बेस placeholder नहीं होता और केवल उसी निर्देशांक को धारण करने के कारण विरासत शुरू नहीं करता।

## **Placeholder में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, मुख्य भाग, और टेक्स्ट placeholders सामान्यतः टेक्स्ट समर्थन देते हैं। उनका [getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/gettextframe/) मेथड उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) होने की जाँच करें।

यह उदाहरण पहले स्लाइड पर पहले शीर्षक placeholder को अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल, या मीडिया placeholders को [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) वस्तुओं के रूप में मानने से बचता है। यह placeholder को उसके उद्देश्य से पहचानता है न कि नाजुक shape इंडेक्स पर निर्भर होकर।

## **लेआउट पर Prompt टेक्स्ट सेट करें**

Prompt टेक्स्ट वह डिज़ाइन‑टाइम निर्देश है जो एक खाली placeholder में दिखाया जाता है, जैसे *Click to add title*। इसे सामान्य स्लाइड की shape संग्रह के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट placeholder पर सेट करें। लेआउट तक पहुँचने के लिए [Slide::getLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getLayoutSlide) का प्रयोग करें और [BaseSlide::getShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर इटरेट करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक prompts को बदलता है:

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

Prompt टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली placeholders के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर देता है, तो prompt नहीं दिखता। Prompt बदलने से लेआउट का उपयोग करने वाली स्लाइडों पर मौजूदा टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र Placeholder को अपडेट करें**

दुर्घटनाएँ दो प्रकार की हैं:

- यदि चित्र placeholder पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) द्वारा दर्शाया गया है, तो छवि को [PictureFillFormat::getPicture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/getpicture/) और [SlidesPicture::setImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidespicture/setimage/) द्वारा बदलें।
- यदि वह अभी भी एक खाली placeholder है, तो [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) का उपयोग करके placeholder के निर्देशांक पर एक picture frame जोड़ें और खाली placeholder को हटा दें।

अगला उदाहरण दोनों मामलों को संभालता है और प्रस्तुति को सहेजता है:

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

एक खाली placeholder के लिए बनाया गया प्रतिस्थापन एक स्थानीय picture frame है, न कि एक नया placeholder, क्योंकि [Shape::getPlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getplaceholder/) कोई setter प्रदान नहीं करता। यह आरक्षित स्थान को बरकरार रखता है लेकिन अब placeholder‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि placeholder संबंध को बनाए रखना आवश्यक हो, तो पहले PowerPoint में placeholder तैयार और भरें, फिर Aspose.Slides के साथ परिणामी [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के बारे में देखें [Manage Picture Frames](/slides/hi/php-java/picture-frame/)। ये ऑपरेशन चित्र फ्रेम या चित्र फ़िल के अंतर्गत आते हैं, न कि placeholder मेटा‑डेटा के।

## **चार्ट और कंटेंट Placeholder के साथ काम करें**

एक भरा हुआ चार्ट placeholder एक [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है। यह उदाहरण placeholder प्रकार और रन‑टाइम क्लास दोनों से ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल सहेजता है:

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

एक सामान्य कंटेंट placeholder आम तौर पर [PlaceholderType::Object](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/) रखता है। PowerPoint में यह कई कंटेंट प्रकारों के लॉन्चर के रूप में कार्य करता है, जिसमें चार्ट, टेबल, डायग्राम, चित्र और मीडिया शामिल हैं। एक बार वह भरा जाने के बाद, वास्तविक shape क्लास की जाँच करके पता लगाएँ कि इसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType::Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/), या [PlaceholderType::Diagram](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholdertype/) को उजागर कर सकते हैं।

Aspose.Slides खाली [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) placeholder को केवल [Placeholder::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/placeholder/gettype/) को बदलकर [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) में नहीं बदलता; प्रकार को क्लास के माध्यम से बदला नहीं जा सकता। खाली चार्ट या कंटेंट क्षेत्र को प्रोग्रामेटिक रूप से भरने के लिए आवश्यक वस्तु को placeholder के निर्देशांक पर जोड़ें और फिर खाली placeholder को हटाएँ। निम्न उदाहरण इसे चार्ट के लिए करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह placeholder के क्षेत्र को घेरता है लेकिन लेआउट placeholder से विरासत नहीं लेता। जब आपको इसकी श्रेणियाँ, श्रृंखलाएँ या वर्कबुक डेटा बदलने की आवश्यकता हो तो समर्पित [chart management articles](/slides/hi/php-java/powerpoint-charts/) देखें।

## **पूर्ण उदाहरण: टेक्स्ट या चित्र सामग्री अपडेट करें**

निम्न अंतिम‑से‑अंत उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र placeholder खोजता है, placeholder और shape प्रकारों की जाँच करता है, उपयुक्त सामग्री को अपडेट करता है, और आउटपुट सहेजता है। यह उदाहरण जानबूझकर shape इंडेक्स मानता नहीं है और न ही सभी placeholders को एक ही क्लास मानता है।

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

**एक बेस placeholder क्या है?**

एक बेस placeholder वह संबंधित shape है जो लेआउट या मास्टर पर स्थित है, जिससे दूसरा placeholder विरासत लेता है। इसे प्राप्त करने के लिए [Shape::getBasePlaceholder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getbaseplaceholder/) का उपयोग करें। एक सामान्य स्थानीय shape `null` लौटाता है क्योंकि वह placeholder पदानुक्रम का हिस्सा नहीं होता।

**क्या मैं लेआउट placeholder को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या prompt टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइडों पर संग्रहीत होती है। सभी स्लाइडों में वास्तविक शीर्षक टेक्स्ट बदलने के लिए स्लाइडों को इटरेट करें और प्रत्येक शीर्षक placeholder को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर placeholders को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप में हेडर और फुटर मैनेजर्स का उपयोग करें। पूर्ण उदाहरणों के लिये देखें [Manage Presentation Header and Footer](/slides/hi/php-java/presentation-header-and-footer/).