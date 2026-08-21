---
title: PHP में प्रस्तुतियों में ड्राइंग गाइड्स का प्रबंधन
linktitle: ड्राइंग गाइड्स
type: docs
weight: 85
url: /hi/php-java/drawing-guides/
keywords:
- ड्राइंग गाइड
- क्षैतिज गाइड
- ऊर्ध्वाधर गाइड
- संरेखण गाइड
- स्लाइड दृश्य
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और ऊर्ध्वाधर ड्राइंग गाइड्स को जोड़ें, पहुंचें और साफ़ करें।"
---
## **Overview**

ड्राइंग गाइड्स समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति को संपादित करते समय आकृतियों को लगातार संरेखित करने में मदद करती हैं। ये विशेष रूप से उपयोगी होती हैं जब कोई एप्लिकेशन ऐसी प्रस्तुति बनाता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लिकेशन समान संरेखण सहायता सहेज सकता है जिसे लेखक सामग्री जोड़ते या हटाते समय अनुसरण करें।

ड्राइंग गाइड्स संपादन सहायता हैं, स्लाइड सामग्री नहीं। ये स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देतीं। Aspose.Slides for PHP via Java इन्हें [DrawingGuidesCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/) क्लास के माध्यम से प्रकट करता है। एक गाइड [DrawingGuide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguide/) द्वारा प्रतिनिधित्व किया जाता है और इसमें अभिविन्यास, स्थिति और रंग होता है।

स्थिति संबंधित स्लाइड या मास्टर के शीर्ष-बाएँ कोने से पॉइंट्स में मापी जाती है। एक लंबवत गाइड क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड लंबवत निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई के बीच।

## **Add Guides to the Slide View**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/orientation/) मान और पॉइंट्स में स्थिति के साथ [DrawingGuidesCollection::add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/#add) को कॉल करें।

निम्नलिखित उदाहरण स्लाइड केंद्र के दाएँ ओर एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Access Drawing Guides**

[DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/#getCount) और [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/#get_Item) विधियाँ मौजूदा गाइड्स तक पहुँच प्रदान करती हैं। [DrawingGuide::getOrientation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguide/#getPosition) और [DrawingGuide::getColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguide/#getColor) विधियाँ मान लौटाती हैं जिन्हें संबंधित सेट्टर विधियों के माध्यम से बदला भी जा सकता है।

निम्नलिखित उदाहरण ऊपर बनाई गई प्रस्तुति से स्लाइड‑व्यू गाइड्स को पढ़ता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Add Guides to Master and Layout Slides**

एक स्लाइड मास्टर और उसकी प्रत्येक लेआउट स्लाइड के अपने ड्राइंग‑गाइड संग्रह हो सकते हैं। मास्टर स्लाइड के लिए [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/#getDrawingGuides) और लेआउट स्लाइड के लिए [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getDrawingGuides) का उपयोग करें।

निम्नलिखित उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Add Guides to Notes and Handout Masters**

नोट्स मास्टर और हैंडआउट मास्टर भी ड्राइंग गाइड्स का समर्थन करते हैं। उनके संग्रह तक पहुँचने के लिए [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masternotesslide/#getDrawingGuides) और [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) का उपयोग करें। यदि प्रस्तुति में इन मास्टरों में से कोई नहीं है, तो उचित मैनेजर को [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) या [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) के साथ प्राप्त करें, फिर `setDefaultMasterNotesSlide` या `setDefaultMasterHandoutSlide` द्वारा डिफ़ॉल्ट मास्टर बनाएँ।

निम्नलिखित उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clear Drawing Guides**

किसी विशिष्ट संग्रह से सभी गाइड्स हटाने के लिए [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/#clear) को कॉल करें। एक संग्रह को साफ़ करने से दूसरे स्कोप में संग्रहीत गाइड्स प्रभावित नहीं होते।

निम्नलिखित उदाहरण स्लाइड‑व्यू गाइड्स तथा स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर पर सभी गाइड्स को बिना लापता मास्टर बनाए हटाता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ड्राइंग गाइड्स स्लाइड शो या एक्सपोर्ट किए गए चित्रों में दिखते हैं क्या?**

नहीं। ड्राइंग गाइड्स संपादन के लिए संरेखण सहायता हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं होते।

**क्या ड्राइंग गाइड को सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**

सामान्य‑स्लाइड संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर के लिए अलग-अलग गाइड संग्रह उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन से यूनिट उपयोग किए जाते हैं?**

स्थिति पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से और क्षैतिज स्थितियों को शीर्ष किनारे से मापा जाता है।

**क्या ड्राइंग गाइड्स को साफ़ करने से आकार हटते हैं या स्लाइड सामग्री बदलती है?**

नहीं। [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/drawingguidescollection/#clear) विधि केवल चयनित संग्रह में गाइड्स को हटाती है। आकार और अन्य स्लाइड सामग्री अपरिवर्तित रहती है।