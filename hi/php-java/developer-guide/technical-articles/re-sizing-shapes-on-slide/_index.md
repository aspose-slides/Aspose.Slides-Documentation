---
title: PHP में प्रस्तुति स्लाइड्स पर आकृतियों का आकार बदलें
type: docs
weight: 130
url: /hi/php-java/resizing-shapes-on-slide/
aliases:
  - /hi/php-java/re-sizing-shapes-on-slide/
keywords:
- आकृति आकार बदलें
- आकृति आकार बदलना
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आकृतियों को आसानी से आकार बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **सारांश**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको नई परिमाणों के अनुसार उसकी आकृतियों का आकार बदलना और उनका स्थान पुन: निर्धारित करना भी आवश्यक हो सकता है। यह लेख दिखाता है कि आकृतियों को मैन्युअल रूप से कैसे स्केल किया जाए और स्लाइड्स, मास्टर्स और लेआउट्स पर टेबल्स को कैसे संभाला जाए।

## **आकृतियों का आकार बदलें**

प्रत्येक आकृति की सापेक्ष स्थिति और आकार को बनाए रखने के लिए, उसके क्षैतिज समन्वयों और चौड़ाई को नई स्लाइड की चौड़ाई तथा मूल चौड़ाई के अनुपात से गुणा करें। समान ऊँचाई अनुपात को उसके ऊर्ध्वाधर समन्वयों और ऊँचाई पर लागू करें।

पहला उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसकी स्लाइड्स में कोई टेबल नहीं होती, स्लाइड आकार को A4 पर बदलता है, और परिणाम को सेव करता है। यह [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) को [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है ताकि आगे की लूप स्केलिंग को नियंत्रित करे। अनुपात बिना इकाई के होते हैं; आकृति की स्थितियाँ और आयाम पॉइंट्स में मापे जाते हैं। विभिन्न चौड़ाई और ऊँचाई अनुपात आकृतियों को विकृत कर सकते हैं, और आकृति के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
टेबल्स को अलग तरह से संभालना चाहिए: कुल तालिका की चौड़ाई और ऊँचाई निर्धारित करने के बजाय उनके कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ स्केल करें। यदि कोशिका की सामग्री को अधिक जगह की आवश्यकता हो तो पंक्ति की ऊँचाई अनुरोधित से बड़ी बनी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण टेबल्स को समर्थित करता है और आकार बदली प्रस्तुति को सेव करने से पहले मास्टर और लेआउट्स के साथ व्यक्तिगत स्लाइड्स पर आकृतियों को प्रोसेस करता है। इसका सहायक प्रत्येक [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) को कॉलम की चौड़ाइयों को [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) और न्यूनतम पंक्ति ऊँचाइयों को [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) से स्केल करके संभालता है। फिर यह कुल आयामों को अलग से स्केल किए बिना टेबल की स्थिति को स्केल करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // टेबल आयाम कॉलम चौड़ाइयों और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और ऊर्ध्वाधर स्केल कारकों की गणना करें।
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // मास्टर और लेआउट पर परिभाषित आकृतियों व व्यक्तिगत स्लाइड्स का आकार बदलें।
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड का आकार बदलने के बाद आकृतियाँ विकृत या कट क्यों जाती हैं?**  
यदि आप स्लाइड आकार बदले बिना आकृतियों को स्केल नहीं करते हैं, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखती हैं और स्लाइड से बाहर निकल सकती हैं। चौड़ाई और ऊँचाई को विभिन्न अनुपात से स्केल करने से भी आकृतियों में विकृति आ सकती है।

**क्या प्रदान किया गया कोड सभी आकृति प्रकारों के लिए काम करता है?**  
पहला उदाहरण आकृति की सीमा को सीधे बदलता है और टेबल रहित स्लाइड्स के लिए है। दूसरा उदाहरण टेबल्स को अलग से संभालता है। परिणामी लेआउट, विशेषकर टेक्स्ट और टेबल्स, की जांच करें, क्योंकि इन उदाहरणों में फ़ॉन्ट आकार स्केल नहीं होते और टेबल की सामग्री पंक्ति की ऊँचाई को सीमित कर सकती है।

**स्लाइड का आकार बदलते समय टेबल्स का आकार कैसे बदलें?**  
कॉलम की चौड़ाइयों को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाइयों को ऊँचाई अनुपात से स्केल करें, फिर टेबल की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह आकार बदलना मास्टर स्लाइड्स और लेआउट स्लाइड्स के लिए काम करेगा?**  
हाँ। दूसरा उदाहरण [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) के माध्यम से इटरेट करता है और प्रत्येक मास्टर की [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) को प्रोसेस करके उनकी आकृतियों पर समान आकार बदलने की लॉजिक लागू करता है।

**क्या स्लाइड का अभिविन्यास (पोर्ट्रेट/लैंडस्केप) आकार बदलते समय बदला जा सकता है?**  
हाँ। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) को कॉल करें, ताकि स्केल फैक्टर अंतिम अभिविन्यास को दर्शाते हों।

**क्या मैं सेट कर सकने वाले स्लाइड आकार की कोई सीमा है?**  
आप कस्टम स्लाइड परिमाण [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) के साथ निर्दिष्ट कर सकते हैं। समर्थित परिमाण प्रस्तुति प्रारूप और फ़ाइल खोलने वाले एप्लिकेशन पर भी निर्भर करते हैं।

**स्थिर अनुपात वाली आकृतियों को विकृत होने से कैसे बचाएँ?**  
चौड़ाई और ऊँचाई के लिए समान स्केल फैक्टर उपयोग करें। मूल लेआउट को नई स्लाइड परिमाणों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा मान उपयोग करें। यह अनुपात को बनाए रखता है लेकिन किसी किनारे पर अप्रयुक्त जगह बच सकती है।