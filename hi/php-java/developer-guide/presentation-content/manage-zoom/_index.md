---
title: PHP में प्रस्तुति ज़ूम को प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/php-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन जोड़ें PowerPoint प्रस्तुतियों में."
---
## **परिचय**

PowerPoint ज़ूम आपको स्लाइड शो के दौरान विशिष्ट स्लाइडों और सेक्शन के बीच नेविगेट करने देते हैं। Aspose.Slides for PHP via Java के साथ, आप स्लाइड, सेक्शन, और सारांश ज़ूम बना सकते हैं और उनके प्रीव्यू, बॉर्डर, और ट्रांज़िशन को कस्टमाइज़ कर सकते हैं।

![PowerPoint ज़ूम ओवरव्यू](overview.png)

* पूरी प्रस्तुति को एक ही स्लाइड पर सारांशित करने के लिए, एक [सारांश ज़ूम](#summary-zoom) का उपयोग करें।
* केवल चयनित स्लाइडें दिखाने के लिए, एक [स्लाइड ज़ूम](#slide-zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [सेक्शन ज़ूम](#section-zoom) का उपयोग करें।

## **स्लाइड ज़ूम**

एक स्लाइड ज़ूम आपके प्रस्तुतीकरण को अधिक गतिशील बना सकता है, जिससे आप चुनिंदा क्रम में किसी भी स्लाइड पर स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रस्तुतीकरण की प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रस्तुतीकरणों के लिए उपयुक्त हैं जिनमें बहुत सारे सेक्शन नहीं होते, लेकिन आप उन्हें विभिन्न प्रस्तुतीकरण परिस्थितियों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको एकल ओवरव्यू स्लाइड से संबंधित जानकारी का पता लगाने की अनुमति देते हैं।

![स्लाइड ज़ूम के लिए स्लाइड चयन](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides द्वारा [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/) एनेमरेशन, [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) क्लास की मेथड्स प्रदान की जाती हैं।

### **ज़ूम फ्रेम बनाएं**

एक ओवरव्यू स्लाइड पर व्यक्तिगत स्लाइडों के लिंक रखने के लिए [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) का उपयोग करें। यह उदाहरण दो लक्ष्य स्लाइड बनाता है जिनके बैकग्राउंड और लेबल अलग-अलग हैं, फिर प्रत्येक का प्रीव्यू पहली स्लाइड पर जोड़ता है और प्रस्तुतीकरण को PPTX के रूप में सहेजता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्धारित किए जाते हैं।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**

टार्गेट स्लाइड के डिफ़ॉल्ट प्रीव्यू को बदलने के लिए [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) में एक कस्टम इमेज पास करें। यह उदाहरण एक लोकल इमेज की आवश्यकता रखता है, इसे [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) से लोड करता है, और इसे प्रस्तुतीकरण में [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage) का उपयोग करके जोड़ता है। परिणामस्वरूप फ्रेम वह इमेज दिखाता है जबकि अभी भी दूसरी स्लाइड से लिंक करता है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ज़ूम फ्रेम को फॉर्मेट करें**

यह उदाहरण दो स्लाइड ज़ूम फ्रेम को कस्टमाइज़ करता है। यह पहला फ्रेम स्थानीय इमेज के साथ [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) के माध्यम से असाइन करता है, और दूसरा फ्रेम पाँच पॉइंट, डैश-डॉट, गुलाबी बॉर्डर [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) से देता है। [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) को `false` पास करने से दूसरे फ्रेम की पृष्ठभूमि छिप जाती है। कस्टम प्रीव्यू के लिए एक लोकल इमेज आवश्यक है; दोनों फ्रेम सहेजे गए PPTX में अपने स्लाइड लक्ष्य को बनाए रखते हैं।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **सेक्शन ज़ूम**

एक सेक्शन ज़ूम आपके प्रस्तुतीकरण में किसी सेक्शन से लिंक करता है। इसका उपयोग आप किसी विषय को फिर से देखने या प्रस्तुतीकरण के विभिन्न भागों के बीच कनेक्शन दिखाने के लिए कर सकते हैं।

![सेक्शन ज़ूम के लिए सेक्शन चयन](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides द्वारा [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) क्लास की मेथड्स प्रदान की जाती हैं।

### **सेक्शन ज़ूम फ्रेम बनाएं**

[SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) से एक सेक्शन बनाएं, फिर लौटाए गए सेक्शन को [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) को पास करें। यह उदाहरण पहली स्लाइड पर एक सेक्शन ज़ूम रखता है और इसे एक रंगीन स्लाइड से शुरू होने वाले सेक्शन से लिंक करता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्धारित होते हैं, और प्रस्तुतीकरण PPTX के रूप में सहेजा जाता है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

[ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) की इमेज ओवरलोड आपको बिना डेस्टिनेशन सेक्शन बदले कस्टम प्रीव्यू दिखाने की अनुमति देती है। यह उदाहरण एक लोकल इमेज की आवश्यकता रखता है, जिसे [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) से लोड किया जाता है और [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage) के माध्यम से जोड़ा जाता है। सहेजी गई प्रस्तुति पहली स्लाइड पर एक सेक्शन ज़ूम रखती है जो नए बनाए गए सेक्शन से लिंक होती है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **सेक्शन ज़ूम के टार्गेट सेक्शन को बदलें**

मौजूदा सेक्शन ज़ूम को फिर से बनाने के बिना पुनर्निर्देशित करने के लिए [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) का उपयोग करें। समान प्रस्तुति की [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) कलेक्शन से एक भरा हुआ सेक्शन चुनें। एक खाली सेक्शन असाइन करने से मौजूदा टार्गेट अपरिवर्तित रहता है, इसलिए असाइन करने से पहले [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) को जाँचें। अधिक जानकारी के लिए देखें [स्लाइड सेक्शन प्रबंधित करें](/slides/hi/php-java/slide-section/)।

निम्न उदाहरण एक प्रस्तुति फ़ाइल लोड करता है, जिसमें कई भरे हुए सेक्शन, `Section navigation` नामक मौजूदा सेक्शन ज़ूम, और `Results` नामक अनूठा सेक्शन होना चाहिए। यह सभी स्लाइड्स में ज़ूम खोजता है और नाम से गंतव्य खोजता है, न कि ऐसे इंडेक्स से जो सेक्शन क्रम बदलने पर बदल सकता है। यदि नाम अद्वितीय नहीं हैं, तो गंतव्य पहचानने के लिए [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **सेक्शन ज़ूम फ्रेम को फॉर्मेट करें**

यह उदाहरण सेक्शन ज़ूम को 100 × 75 पॉइंट्स तक ले जाता और आकार बदलता है, स्थानीय इमेज को [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) से असाइन करता है, और 2.5 पॉइंट डैश-डॉट ब्राउन बॉर्डर लागू करता है। यह [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) को सक्षम करता है ताकि सेक्शन समाप्त होने पर मूल स्लाइड पर लौट सकें, [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) को अक्षम करता है, और [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड सेट करता है। कस्टम प्रीव्यू के लिए एक लोकल इमेज आवश्यक है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **सारांश ज़ूम**

सारांश ज़ूम प्रस्तुति के सेक्शन का ओवरव्यू प्रदान करता है। स्लाइड शो के दौरान, आप इसका उपयोग सेक्शन पर कूदने, आगे स्किप करने, या विषय को फिर से देखने के लिए कर सकते हैं बिना स्लाइड क्रम का पालन किए।

![सारांश ज़ूम के लिए सेक्शन चयन](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides द्वारा [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) क्लास की मेथड्स प्रदान की जाती हैं।

### **एक सारांश ज़ूम बनाएं**

[ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) का उपयोग करके प्रस्तुति के सेक्शन का एक ओवरव्यू बनाएं। यह उदाहरण चार सेक्शन बनाता है जिनके स्लाइड बैकग्राउंड अलग-अलग हैं और पहली स्लाइड में एक सारांश ज़ूम जोड़ता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्धारित होते हैं, और उत्पन्न ओवरव्यू को PPTX प्रस्तुति में सहेजा जाता है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

एक सारांश ज़ूम अपने [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) ऑब्जेक्ट्स को [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में संग्रहीत करता है। यह उदाहरण दो सेक्शन का ओवरव्यू बनाता है, फिर [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) से तीसरा सेक्शन जोड़ता है, और [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) से पहले सेक्शन की एंट्री हटाता है। एंट्री हटाने से प्रस्तुति का सेक्शन और उसकी स्लाइडें अपरिवर्तित रहती हैं।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **सारांश ज़ूम सेक्शन को फॉर्मेट करें**

यह उदाहरण [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में शून्य‑आधारित इंडेक्स `0` वाली पहली एंट्री को फॉर्मेट करता है। यह [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) के लिए एक लोकल इमेज की आवश्यकता रखता है, 1.5 पॉइंट डैश-डॉट काला बॉर्डर लागू करता है, और [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड सेट करता है। [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) को `false` पास करने से इस एंट्री के लिए स्वचालित रूप से सारांश स्लाइड पर लौटना निष्क्रिय हो जाता है।

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हाँ। लक्ष्य सामग्री दिखाने के बाद मूल स्लाइड पर लौटने के लिए [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) को `true` के साथ कॉल करें।

**क्या मैं ज़ूम ट्रांज़िशन की 'स्पीड' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ज़ूम ट्रांज़िशन की अवधि को सेकंड में नियंत्रित करने के लिए [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) का उपयोग करें।

**क्या प्रस्तुतीकरण में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ीकृत कोई सख्त API सीमा नहीं है। व्यावहारिक सीमाएँ कुल प्रस्तुतीकरण जटिलता और व्यूअर के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय पर विचार करना उचित है।