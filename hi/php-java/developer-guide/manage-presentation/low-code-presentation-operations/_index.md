---
title: PHP में लो-कोड प्रेजेंटेशन ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/php-java/low-code-presentation-operations/
keywords:
- लो-कोड प्रेजेंटेशन API
- प्रेजेंटेशन कनवर्ट करें
- प्रेजेंटेशन मर्ज करें
- स्लाइड्स पर इटरिट करें
- शेप्स पर इटरिट करें
- टेक्स्ट पर इटरिट करें
- शेप्स एकत्र करें
- प्रेजेंटेशन कंप्रेस करें
- अनुपयोगी मास्टर स्लाइड्स हटाएँ
- अनुपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स कंप्रेस करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides लो-कोड API का उपयोग करके प्रेजेंटेशन्स को कनवर्ट और मर्ज करें, कंटेंट के माध्यम से इटरिट करें, शेप्स एकत्र करें, और प्रेजेंटेशन का आकार घटाएँ।"
---
## **अवलोकन**

[aspose.slides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) नेमस्पेस सामान्य प्रेजेंटेशन ऑपरेशन्स के लिए स्थैतिक हेल्पर क्लासेज प्रदान करता है। ये हेल्पर्स अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लो को केंद्रित मेथड्स में लपेटते हैं, जिससे आप फाइलों को कनवर्ट या मर्ज कर सकते हैं, प्रेजेंटेशन एलिमेंट्स को प्रोसेस कर सकते हैं, शेप्स एकत्र कर सकते हैं, और कम कोड के साथ अनावश्यक कंटेंट को हटा सकते हैं।

Low-code हेल्पर्स तब सबसे उपयोगी होते हैं जब ऑपरेशन पूरी फ़ाइल या प्रेजेंटेशन पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, एक्सपोर्ट सेटिंग्स, या प्रेजेंटेशन एलिमेंट्स के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए, तो पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) का उपयोग करें।

निम्नलिखित तालिका उपलब्ध हेल्पर्स का सारांश देती है:

| हेल्पर | किसके लिए उपयोग करें |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/) | एक प्रेजेंटेशन को सीधे फ़ाइल-से-फ़ाइल कॉल के साथ दूसरे फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूरी प्रेजेंटेशन फ़ाइलों को मिलाना। |
| [ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) | हर स्लाइड, शेप, पैराग्राफ, या टेक्स्ट पोर्शन के लिए कॉलबैक चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/) | पूरे प्रेजेंटेशन से शेप्स को पुनः प्रक्रिया या विश्लेषण के लिए प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) | अनुपयोगी मास्टर्स और लेआउट्स को हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रेजेंटेशन को रूपांतरित करें**

जब आउटपुट फ़ाइल एक्सटेंशन निर्यात फ़ॉर्मेट चुनने के लिए पर्याप्त हो, तब [Convert::autoByExtension](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/#autoByExtension) का उपयोग करें। यह मेथड स्रोत प्रेजेंटेशन को खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिए समर्पित मेथड्स भी प्रदान करती है। जब आपको निर्यात से पहले प्रेजेंटेशन की जांच या संशोधन करना हो या ऐसी निर्यात विकल्प कॉन्फ़िगर करना हो जो चयनित हेल्पर द्वारा उजागर नहीं किया गया है, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। फ़ॉर्मेट‑विशिष्ट वर्कफ़्लो और विकल्पों के लिए [Convert Presentation](/slides/hi/php-java/convert-presentation/) देखें।

## **प्रेजेंटेशन को मर्ज करें**

एक कॉल में पूरी प्रेजेंटेशन फ़ाइलों को मिलाने के लिए [Merger::process](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/#process) का उपयोग करें। इनपुट प्रेजेंटेशन को एक ही फ़ाइल फ़ॉर्मेट होना चाहिए।

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

यह हेल्पर तब उपयुक्त है जब सभी स्लाइड्स को व्यक्तिगत रूप से चुनने या पुनःमैपिंग किए बिना एक परिणाम में जोड़ना हो। जब आपको चयनित स्लाइड्स को मर्ज करना हो, गंतव्य मास्टर या लेआउट लागू करना हो, सेक्शन्स को स्पष्ट रूप से संरक्षित करना हो, या विभिन्न स्लाइड आकारों को समायोजित करना हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। इन परिस्थितियों के लिए [Merge Presentations](/slides/hi/php-java/merge-presentation/) देखें।

## **प्रेजेंटेशन तत्वों पर इटरेट करें**

[ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) क्लास प्रत्येक अनुरोधित प्रेजेंटेशन तत्व प्रकार के लिए एक कॉलबैक को कॉल करती है। यह नेस्टेड कलेक्शन लूप से बचती है और प्रेजेंटेशन‑व्यापी निरीक्षण या फ़ॉर्मेटिंग बदलावों के लिए सुविधाजनक है।

निम्नलिखित उदाहरण [ForEach_::slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#paragraph), और [ForEach_::portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#portion) का उपयोग करके संबंधित तत्वों का निरीक्षण करता है:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

डिफ़ॉल्ट रूप से, प्रेजेंटेशन‑व्यापी शेप और टेक्स्ट ट्रैवर्सल में सामान्य, मास्टर और लेआउट स्लाइड्स शामिल होते हैं। `includeNotes` पैरामीटर वाले ओवरलोड्स नोट्स स्लाइड्स को भी प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, जल्दी निकास, कॉलबैक कॉल से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे कलेक्शन लूप का उपयोग करें।

## **शेप्स एकत्र करें**

[Collect::shapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/#shapes) का उपयोग तब करें जब आपको प्रत्येक शेप के लिए कॉलबैक की बजाय प्रेजेंटेशन में सभी शेप्स का संग्रह चाहिए। यह तब उपयोगी होता है जब वही सेट कई बार फ़िल्टर, गिना या प्रोसेस किया जाएगा।

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

जब प्रत्येक शेप को तुरंत संभाला जा सकता है और आपको संग्रहित परिणाम को रख कर रखने की आवश्यकता नहीं है, तो इसके बजाय [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape) का उपयोग करें।

## **प्रेजेंटेशन कंटेंट को कंप्रेस करें**

[Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास अनउपयोगी संरचनात्मक तत्वों को हटाकर और एम्बेडेड फ़ॉन्ट डेटा को कम करके कंटेंट को कंप्रेस कर सकती है:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) वह लेआउट स्लाइड्स हटाता है जिनका कोई सामान्य स्लाइड संदर्भ नहीं रखती।
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedMasterSlides) वह मास्टर स्लाइड्स हटाता है जो अब उपयोग में नहीं हैं।
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#compressEmbeddedFonts) एम्बेडेड फ़ॉन्ट्स से अप्रयुक्त कैरेक्टर्स को हटाता है।

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अप्रयुक्त लेआउट्स को अप्रयुक्त मास्टर्स से पहले हटाएँ ताकि लेआउट सफ़ाई के बाद ग़ैर‑संदर्भित होने वाला मास्टर भी हटाया जा सके। यदि आपको बाद में मूल मास्टर्स, लेआउट्स, या पूरा एम्बेडेड फ़ॉन्ट डेटा चाहिए, तो अनुकूलित प्रेजेंटेशन को नई फ़ाइल में सहेजें। अधिक विवरण के लिए देखें [Slide Master](/slides/hi/php-java/slide-master/) और [Embedded Font](/slides/hi/php-java/embedded-font/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मुझे पूर्ण ऑब्जेक्ट मॉडल की बजाय लो‑कोड API का उपयोग करना चाहिए?**

जब एक मानक ऑपरेशन पूरी फ़ाइल या प्रेजेंटेशन पर लागू हो और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो‑कोड हेल्पर्स का उपयोग करें। जब आपको विशिष्ट स्लाइड्स चुननी हों, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती स्थिति की जांच करनी हो, या ऐसा व्यवहार कॉन्फ़िगर करना हो जो हेल्पर उजागर नहीं करता, तब पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट्स में प्रेजेंटेशन को मिलाने में सक्षम है?**

नहीं। [Merger::process](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/#process) को इनपुट प्रेजेंटेशन को एक ही फ़ॉर्मेट में होना आवश्यक है। पहले इनपुट फ़ाइलों को सामान्य फ़ॉर्मेट में परिवर्तित करें, उदाहरण के लिए [Convert::autoByExtension](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/#autoByExtension) का उपयोग करके, और फिर परिवर्तित फ़ाइलों को मर्ज करें।

**क्या ForEach_ मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach_::slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#slide) सामान्य प्रेजेंटेशन स्लाइड्स पर इटरिट करता है। प्रेजेंटेशन‑व्यापी [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#paragraph) और [ForEach_::portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#portion) ऑपरेशन्स डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिए `includeNotes` को `true` पर सेट करके उनके ओवरलोड्स का उपयोग करें।

**ForEach_::shape और Collect::shapes में क्या अंतर है?**

[ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape) का उपयोग प्रत्येक शेप को तुरंत कॉलबैक के माध्यम से प्रोसेस करने के लिए करें। जब आपको ऐसा इटेरेबल परिणाम चाहिए जिसे बरकरार रखा जा सके, फ़िल्टर किया जा सके, गिना जा सके, या कई बार ट्रैवर्स किया जा सके, तब [Collect::shapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/#shapes) का उपयोग करें।

**क्या Compress हमेशा प्रेजेंटेशन फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रेजेंटेशन में अनउपयोगी लेआउट्स, अनउपयोगी मास्टर्स या अनउपयोगी कैरेक्टर्स वाले एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि इनमें से कोई भी नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) ऑपरेशन्स फ़ाइल आकार कम नहीं कर सकते।

**क्या ForEach_ या Compress द्वारा किए गए बदलाव स्वतः सहेजे जाते हैं?**

नहीं। ये हेल्पर्स स्मृति में लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट पर काम करते हैं। [ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) कॉलबैक में तत्वों को बदलने या [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) चलाने के बाद, परिणाम को लिखने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन को रूपांतरित करें](/slides/hi/php-java/convert-presentation/)
- [प्रेजेंटेशन को मर्ज करें](/slides/hi/php-java/merge-presentation/)
- [स्लाइड मास्टर](/slides/hi/php-java/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधित करें](/slides/hi/php-java/manage-textbox/)
- [एंबेडेड फ़ॉन्ट](/slides/hi/php-java/embedded-font/)