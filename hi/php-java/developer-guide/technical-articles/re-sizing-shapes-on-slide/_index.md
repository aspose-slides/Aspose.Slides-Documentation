---
title: "प्रेजेंटेशन स्लाइड्स में PHP के द्वारा आकार बदलें"
type: docs
weight: 130
url: /hi/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/आकार-पर-स्लाइड-पर-बदलें/
  - /hi/php-java/re-sizing-shapes-on-slide/
keywords:
  - आकार बदलें
  - आकार बदलें
  - पॉवरपॉइंट
  - ओपनडॉक्यूमेंट
  - प्रस्तुति
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आकार आसानी से बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **सारांश**

जब आप प्रस्तुति की स्लाइड आकार बदलते हैं, तो आपको उसके आकार को नई आयामों के अनुसार फिट करने के लिए उसके आकारों (shapes) का आकार बदलना और पुनः स्थित करना पड़ सकता है। यह लेख दिखाता है कि आकारों को मैन्युअल रूप से कैसे स्केल करें और स्लाइड, मास्टर और लेआउट में तालिकाओं को कैसे संभालें।

## **आकारों को पुनः आकार दें**

प्रत्येक आकार की सापेक्ष स्थिति और आकार को संरक्षित रखने केलिए, उसकी क्षैतिज समन्वय और चौड़ाई को नई स्लाइड की चौड़ाई तथा मूल चौड़ाई के अनुपात से गुणा करें। उसकी लंबवत समन्वय और ऊँचाई पर संबंधित ऊँचाई अनुपात लागू करें।

पहला उदाहरण एक प्रस्तुति लोड करता है जिसके स्लाइड में कोई तालिका नहीं होती, स्लाइड आकार को A4 में बदलता है, और परिणाम सहेजता है। यह [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) को [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) के साथ उपयोग करता है ताकि बाद का लूप स्केलिंग को नियंत्रित करे। अनुपात इकाईरहित होते हैं; आकार की स्थितियों और आयामों को पॉइंट में मापा जाता है। अलग‑अलग चौड़ाई और ऊँचाई अनुपात आकारों को विकृत कर सकते हैं, और आकार के आयाम बदलने से उसके फ़ॉन्ट आकार नहीं बदलते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
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
तालिकाओं को अलग से संभालना आवश्यक है: तालिका की कुल चौड़ाई और ऊँचाई को निर्धारित करने के बजाय, उसके कॉलम चौड़ाई और पंक्ति ऊँचाई को स्केल करें। यदि सेल सामग्री को अधिक स्थान चाहिए तो पंक्ति ऊँचाई अनुरोधित आकार से बड़ी रह सकती है।
{{% /alert %}}

दूसरा उदाहरण तालिकाओं का समर्थन करता है और आकारों को मास्टर और लेआउट सहित व्यक्तिगत स्लाइड पर प्रक्रिया करता है, फिर पुनः आकार वाली प्रस्तुति सहेजता है। इसका सहायक प्रत्येक [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) को कॉलम चौड़ाई को [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) से स्केल करके और न्यूनतम पंक्ति ऊँचाई को [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) से संभालता है। फिर यह तालिका की स्थिति को स्केल करता है बिना उसके कुल आयामों को अलग से स्केल किए।

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
                // तालिका के आयाम कॉलम चौड़ाई और पंक्ति ऊँचाइयों द्वारा नियंत्रित होते हैं।
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
    // स्वतंत्र क्षैतिज और लंबवत स्केल कारकों की गणना करें।
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // मास्टर और लेआउट में परिभाषित आकारों के साथ-साथ व्यक्तिगत स्लाइड पर भी आकार को पुनः आकार दें।
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

## **प्रश्नोत्तर**

**स्लाइड को पुनः आकार देने के बाद आकार क्यों विकृत या कटे हुए दिखते हैं?**

यदि आप स्लाइड आकार बदलते हैं बिना आकारों को स्केल किए, तो वे अपनी मूल स्थितियों और आयामों को बनाए रखते हैं और स्लाइड से बाहर निकल सकते हैं। चौड़ाई और ऊँचाई को अलग‑अलग अनुपात से स्केल करने से भी आकार विकृत हो सकते हैं।

**क्या प्रदान किया गया कोड सभी आकार प्रकारों के लिए कार्य करता है?**

पहला उदाहरण आकार की सीमाओं को सीधे बदलता है और तालिकाविहीन स्लाइड के लिए अभिप्रेत है। दूसरा उदाहरण तालिकाओं को अलग से संभालता है। परिणामस्वरूप लेआउट, विशेषकर पाठ और तालिकाओं की जाँच करें, क्योंकि ये उदाहरण फ़ॉन्ट आकार नहीं स्केल करते और तालिका सामग्री पंक्ति ऊँचाई को सीमित कर सकती है।

**स्लाइड को पुनः आकार देते समय तालिकाओं का आकार कैसे बदलूँ?**

कॉलम चौड़ाई को चौड़ाई अनुपात से और न्यूनतम पंक्ति ऊँचाई को ऊँचाई अनुपात से स्केल करें, फिर तालिका की स्थिति को स्केल करें, जैसा कि दूसरे उदाहरण में दिखाया गया है।

**क्या यह पुनः आकार देना मास्टर स्लाइड और लेआउट स्लाइड के लिए कार्य करेगा?**

हाँ। दूसरा उदाहरण [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) और प्रत्येक मास्टर की [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) के माध्यम से इटररेट करता है और उनके आकारों पर समान पुनः आकार तर्क लागू करता है।

**क्या मैं पुनः आकार के साथ स्लाइड की अभिविन्यास (पोर्ट्रेट/लैंडस्केप) भी बदल सकता हूँ?**

हां। स्लाइड आकार बदलने के बाद और लक्ष्य आयाम पढ़ने से पहले [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) को कॉल करें, ताकि स्केल कारक अंतिम अभिविन्यास को दर्शाएँ।

**क्या स्लाइड आकार को सेट करने की कोई सीमा है?**

आप कस्टम स्लाइड आयाम को [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) से निर्दिष्ट कर सकते हैं। समर्थित आयाम प्रस्तुति फ़ॉर्मेट और फ़ाइल खोलने वाले अनुप्रयोग पर भी निर्भर करते हैं।

**मैं स्थिर अनुपात वाले आकारों को विकृत होने से कैसे रोकूँ?**

चौड़ाई और ऊँचाई के लिए समान स्केल कारक उपयोग करें। मूल लेआउट को नई स्लाइड आयामों में फिट करने के लिए, दोनों आयामों और स्थितियों के लिए चौड़ाई और ऊँचाई अनुपात में से छोटा चुनें। यह अनुपात को बनाए रखता है लेकिन एक किनारे पर अप्रयुक्त स्थान छोड़ सकता है।