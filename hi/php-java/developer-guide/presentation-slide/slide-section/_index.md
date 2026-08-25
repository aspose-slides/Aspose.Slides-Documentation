---
title: PHP के साथ प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/php-java/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- सेक्शन स्लाइड्स प्राप्त करें
- सेक्शन स्लाइड्स प्रोसेस करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ स्लाइड सेक्शन प्रबंधित करें: PPTX प्रस्तुतियों में सेक्शन स्लाइड्स को बनाएं, नाम बदलें, पुनःक्रमित करें, प्राप्त करें और प्रोसेस करें।"
---
## **परिचय**

सेक्शन लगातार स्लाइड्स को बिना स्लाइड सामग्री बदले नामित समूहों में व्यवस्थित करते हैं। Aspose.Slides for PHP via Java के साथ, आप सेक्शन को बनाना, पुनर्व्यवस्थित करना, नाम बदलना, निरीक्षण करना और हटाना [Presentation::getSections](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSections) मेथड के माध्यम से कर सकते हैं।

सेक्शन विशेष रूप से उपयोगी होते हैं जब:

- एक बड़ी प्रस्तुति को तार्किक विषयों या अध्यायों में विभाजित करने की आवश्यकता हो;
- स्लाइड्स के विभिन्न समूह विभिन्न सहयोगियों को सौंपे गए हों;
- स्लाइड्स को समूहों के रूप में प्रोसेस, स्थानांतरित या मर्ज करने की आवश्यकता हो।

संक्षिप्त सेक्शन नाम चुनें जो समूहित स्लाइड्स के उद्देश्य को वर्णित करें। क्योंकि सेक्शन प्रस्तुति संरचना का हिस्सा होते हैं, सदस्यता निर्धारित करने के लिए सेक्शन API का उपयोग करें, न कि स्लाइड स्थितियों से निकालें।

## **सेक्शन बनाना और प्रबंधन**

एक सेक्शन बनाते समय उसका नाम और प्रारम्भिक स्लाइड निर्दिष्ट करने के लिए [SectionCollection::addSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#addSection) का उपयोग करें। Aspose.Slides वर्तमान प्रस्तुति की सेक्शन संरचना से निर्धारित करता है कि कौन सी स्लाइड्स उस सेक्शन की हैं।

एक ही [SectionCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/) आपको भी अनुमति देता है:
- सेक्शन को उसकी स्लाइड्स के साथ [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) का उपयोग करके स्थानांतरित करें;
- केवल सेक्शन परिभाषा को [SectionCollection::removeSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#removeSection) से हटाएँ, जिससे उसकी स्लाइड्स बनी रहती हैं;
- सेक्शन और उसकी स्लाइड्स को [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides) से हटाएँ;
- अंत में एक खाली सेक्शन जोड़ने के लिए [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#appendEmptySection) का उपयोग करें।

निम्न उदाहरण दो सेक्शन बनाता है, उनमें से एक को स्थानांतरित करता है, उसे उसकी स्लाइड्स के साथ हटाता है, और एक खाली सेक्शन जोड़ता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

इन ऑपरेशनों के बाद, प्रस्तुति में `Introduction` सेक्शन उसकी स्लाइड्स के साथ और एक खाली `Appendix` सेक्शन रहता है। `Results` सेक्शन और उसकी स्लाइड्स हटा दी गई हैं।

## **सेक्शन का नाम बदलना**

सेक्शन का नाम बदलने के लिए, उसकी [Section::setName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#setName) मेथड को कॉल करें। सेक्शन की स्लाइड्स और स्थिति अपरिवर्तित रहती है।

निम्न उदाहरण एक सेक्शन बनाता है और उसका नाम बदलता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **सेक्शन से स्लाइड्स प्राप्त करना**

[Presentation::getSections](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSections) मेथड एक [SectionCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/) लौटाता है जिसे आप इंडेक्स द्वारा प्रोसेस कर सकते हैं। प्रत्येक [Section](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/) के लिए, वर्तमान में उसमें मौजूद स्लाइड्स प्राप्त करने हेतु [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSlidesListOfSection) को कॉल करें। यह मेथड एक [SectionSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionSlideCollection/) लौटाता है, जो गिनती और इंडेक्स्ड एक्सेस प्रदान करता है।

निम्न उदाहरण दो भरे हुए सेक्शन और एक खाली सेक्शन बनाता है, फिर प्रत्येक सेक्शन का [name](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getStartedFromSlide), स्लाइड गिनती और स्लाइड नंबर प्रिंट करता है। यह इंडेक्स्ड एक्सेस के लिए [SectionCollection::get_Item](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionCollection/#get_Item) और [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SectionSlideCollection/#get_Item) का उपयोग करता है। खाली सेक्शन के लिए, लौटाई गई कलेक्शन का आकार शून्य होता है और `get_Item` को कॉल नहीं किया जाता।

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

सेक्शन सदस्यता प्रस्तुति की सेक्शन संरचना द्वारा निर्धारित होती है। सेक्शन की सीमा को [Section::getStartedFromSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getStartedFromSlide), स्लाइड इंडेक्स और अगली सेक्शन की प्रारम्भिक स्लाइड से मैन्युअली गणना न करें।

संरचनात्मक संपादन एक सेक्शन के लिए लौटाई गई स्लाइड्स और उनके स्लाइड नंबर दोनों को बदल सकते हैं। इसमें स्लाइड्स का पुनःक्रमण, स्लाइड को सेक्शन में क्लोन करना, सेक्शन को उसकी स्लाइड्स के साथ स्थानांतरित करना, स्लाइड्स हटाना, और सेक्शन हटाना शामिल है। अगला उदाहरण प्रत्येक ऐसे परिवर्तन के बाद [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSlidesListOfSection) को कॉल करता है, बजाय इसके कि सेक्शन की पूर्व सीमा के बारे में धारणाएँ बनाए रखें।

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

जब भी स्लाइड्स या सेक्शन को पुनःक्रमित, क्लोन, स्थानांतरित या हटाया जाए, तो [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSlidesListOfSection) को पुनः कॉल करें। इससे बाद की प्रोसेसिंग वर्तमान प्रस्तुति संरचना के अनुरूप रहती है।

PPT (PowerPoint 97–2003) फॉर्मेट सेक्शन मेटाडाटा को संरक्षित नहीं करता। इस वर्कफ़्लो का उपयोग ऐसे फॉर्मेट के साथ करें जो सेक्शन का समर्थन करता हो, जैसे PPTX; PPT में बदलने से बाद में इटरेशन के लिए आवश्यक सेक्शन संरचना हट जाती है।

## **FAQ**

**क्या PPT (PowerPoint 97–2003) फॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फॉर्मेट सेक्शन मेटाडाटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूह खो जाता है।

**क्या पूरे सेक्शन को “छिपाया” जा सकता है?**

नहीं। एक सेक्शन का कोई दृश्यता स्थिति नहीं होती। उसके सामग्री को छिपाने के लिए, सेक्शन की प्रत्येक स्लाइड पर [Slide::setHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Slide/#setHidden) को कॉल करें।

**मैं उस सेक्शन को कैसे खोज सकता हूँ जिसमें कोई स्लाइड शामिल है?**

[Presentation::getSections](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSections) द्वारा लौटाई गई कलेक्शन के माध्यम से लूप चलाएँ, प्रत्येक सेक्शन के लिए [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSlidesListOfSection) को कॉल करें, और लौटाई गई स्लाइड्स को लक्ष्य स्लाइड से तुलना करें। गैर-खाली सेक्शन के लिए, [Section::getStartedFromSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getStartedFromSlide) उसकी पहली स्लाइड लौटाता है; खाली सेक्शन के लिए, यह `null` लौटाता है।