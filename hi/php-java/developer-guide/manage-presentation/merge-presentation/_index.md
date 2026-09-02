---
title: PHP में प्रस्तुतियों को कुशलता से मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/php-java/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- PHP
- Aspose.Slides
description: "PHP में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, और संरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करने के तरीके सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java प्रस्तुतियों को एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) से दूसरी में स्लाइड क्लोन करके मिलाता है। मुख्य ऑपरेशन है [SlideCollection::addClone()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/), जो स्रोत स्लाइड की फ़ॉर्मेटिंग को संरक्षित कर सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति में मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्ज वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन किए गए स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक समग्र वर्कफ़्लो में मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणियां, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइलों और मल्टीथ्रेडिंग मुद्दों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपने स्वरूप का बहुत हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोन ओवरलोड का चयन करते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड लक्ष्य प्रस्तुति में कैसे एकीकृत होगी।

इनमें से किसी एक तरीके से [SlideCollection::addClone()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मेटिंग संरक्षित रखें। आवश्यक होने पर स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है जिससे वही स्रोत मास्टर उपयोग करने वाली दोहरायी स्लाइड्स बार‑बार क्लोन नहीं होते।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट टाइप या नाम द्वारा मिलते‑जुलते लेआउट की खोज करता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) से जोड़ें।

`addClone` ओवरलोड में पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबद्ध होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से प्रत्येक स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखने चाहिए।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और लक्ष्य अलग‑अलग डिज़ाइन उपयोग करते हैं। यह अपेक्षित है क्योंकि स्रोत फ़ॉर्मेटिंग जानबूझकर संरक्षित की गई है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको प्रत्येक स्लाइड क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण स्रोत प्रस्तुति से केवल चयनित स्लाइड इंडेक्स को आयात करता है।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से प्राप्त स्लाइड इंडेक्स को क्लोन करने से पहले सत्यापित करें।

## **लक्ष्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को लक्ष्य प्रस्तुति के मौजूदा मास्टर के साथ मिलाना हो, तो [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) ओवरलोड का उपयोग करें।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides निर्दिष्ट मास्टर के तहत उपयुक्त लेआउट का चयन स्रोत लेआउट के टाइप या नाम से मिलान करके करता है। यदि कोई उपयुक्त लेआउट मौजूद नहीं है और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है जिससे स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) फेंका जाता है।

यदि आप चाहते हैं कि मर्ज विफल हो बजाय लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक जानते हैं कि आयातित स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) ओवरलोड का उपयोग करें।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

लक्ष्य लेआउट लागू करने से केवल विरासत में मिली लेआउट संबंध बदलती है; स्रोत स्लाइड सामग्री को फिर से डिज़ाइन नहीं किया जाता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचना अलग है, तो परिणाम की जांच करें यह पुष्टि करने के लिए कि विरासत में मिली फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उचित हैं।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी अन्य स्लाइड आकार वाली प्रस्तुति में स्लाइड को क्लोन करने से उसकी सामग्री स्वतः नए कैनवास के अनुसार पुनः डिज़ाइन नहीं होती। परिणामस्वरूप आकार बदलने, शिफ्ट होने या स्लाइड के दृश्यमान क्षेत्र से बाहर रहने की संभावना रहती है।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize::setSize()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/setsize/) मेथड सामग्री को स्केल करता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिये स्केल करता है।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदलता है। यदि आपको आगे के ऑपरेशनों के लिये मूल स्रोत प्रस्तुति अपरिवर्तित चाहिए, तो मर्ज के लिये अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बुनियादी स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएँ या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(Slide, Section)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) के साथ क्लोन करें।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिये, [Presentation::getSections](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation/#getSections) को इनेमेरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [Section::getSlidesListOfSection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Section/#getSlidesListOfSection) से प्राप्त करें, लक्ष्य में सेक्शन फिर से बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके संबंधित लक्ष्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑इनेमेरेशन उदाहरण के लिये [Manage Slide Sections](/slides/hi/php-java/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन भी शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अंत उदाहरण पहले प्रस्तुति को लक्ष्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तब खुला रखता है जब वह कॉपी किया जा रहा हो, और अंतिम फ़ाइल को केवल एक बार सहेजता है।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित करने हेतु एक उपयोगी बेसलाइन है। यदि आपका आउटपुट एकल लक्ष्य थीम का उपयोग करना चाहिए, तो साधारण `addClone($slide)` को पहले दिखाए गए उपयुक्त लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग स्वचालित रूप से आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को पुनः‑क्लोनिंग से बचने के लिये एक आंतरिक रजिस्ट्री में रखता है। मैन्युअली क्लोन किए गए मास्टर इस रजिस्ट्री द्वारा ट्रैक नहीं होते, इसलिए जब तक आपको मास्टर संरचना पर स्पष्ट नियंत्रण न चाहिए, तब तक पूर्व‑क्लोनिंग से बचें।

एक ही नाम वाले दो मास्टर या लेआउट को दृश्य रूप से समान न मानें। यदि कोई कॉरपोरेट टेम्प्लेट अंतिम लुक को नियंत्रित करता है, तो स्पष्ट रूप से लक्ष्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और टिप्पणियां**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides [presentation notes](/slides/hi/php-java/presentation-notes/) और [presentation comments](/slides/hi/php-java/presentation-comments/) के लिये भी समर्पित API प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। रिव्यू वर्कफ़्लो में विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड कमेंट्स की भी पुष्टि करें।

### **छवियां, ऑडियो, वीडियो, OLE ऑब्जेक्ट और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तर के संसाधनों जैसे छवियां, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्य आकृतियों को कॉपी करने के बजाय स्लाइड को स्वयं क्लोन करें ताकि Aspose.Slides उसके संसाधनों के संबंध को बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अभी भी अपने बाहरी लक्ष्य पर निर्भर रहेगा; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। क्लोन की गई प्रस्तुति को खोलने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ और URL की जाँच करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन इसका अर्थ यह नहीं कि असंबंधित स्रोत प्रस्तुतियों से समान बाइनरी रिसोर्स हमेशा डिडुप्लिकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज किए गए पैकेज की जाँच करें और परिणाम को मापें, न कि केवल इम्प्लिसिट डिडुप्लिकेशन पर भरोसा करें।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को सभी मशीनों में एकसमान रहना है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि आवश्यक सभी फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध होंगे। आप [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) से एम्बेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/php-java/embedded-font/) में बताई गई तरह स्पष्ट रूप से एम्बेडिंग प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि स्रोत फ़ाइलों में प्रयुक्त फ़ॉन्ट को एम्बेड करने की अनुमति है या नहीं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियाँ**

पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions::setPassword()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/setpassword/) के माध्यम से प्रदान करें।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें।
} finally {
    $source->dispose();
}
```

एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से लक्ष्य प्रस्तुति में वही सुरक्षा लागू नहीं करता। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन छवियों, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियां पर्याप्त मेमोरी उपभोग कर सकती हैं। [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) BLOB हैंडलिंग और अस्थायी‑फ़ाइल उपयोग के लिये नियंत्रण प्रदान करता है। PHP via Java बड़े‑फ़ाइल उदाहरण के लिये देखें [Open Presentations](/slides/hi/php-java/open-presentation/#open-large-presentations)।

बड़ी फ़ाइलों के लिये, संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को उसके मर्ज होने के तुरंत बाद डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड में लोड, मॉडिफ़ाई, सहेज या क्लोन न करें। ये ऑपरेशन PHP via Java में मल्टीथ्रेडेड उपयोग के लिये समर्थित नहीं हैं। यदि आपको समानांतर मर्ज जॉब्स चाहिए, तो उन्हें अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस में चलाएँ, प्रत्येक प्रोसेस अपने स्वयं के प्रस्तुति इंस्टेंस का उपयोग करे, और [Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन](/slides/hi/php-java/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे बनाए रखूँ?**

[SlideCollection::addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) को बिना लक्ष्य मास्टर या लेआउट के उपयोग करें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर देगा।

**आयातित स्लाइड्स को लक्ष्य थीम में कैसे लाऊँ?**

ऐसा ओवरलोड उपयोग करें जो लक्ष्य मास्टर को स्वीकार करता हो। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने का प्रयास करेगा।

**कब मुझे लक्ष्य मास्टर के बजाय विशिष्ट लक्ष्य लेआउट इस्तेमाल करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट टाइप या नाम के आधार पर उस मास्टर के उपलब्ध लेआउट में से चुनें, तो मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री को लक्ष्य आयामों के लिये स्वचालित रूप से पुनः‑डिज़ाइन नहीं किया जाता। पूर्व‑आकार‑बदलाव के लिये [SlideSize::setSize()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। क्योंकि प्रस्तुति फ़ॉर्मेटों में फीचर सेट पूरी तरह समान नहीं होते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल कंटेंट की जाँच करें। देखें [Supported File Formats](/slides/hi/php-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वतः संरक्षित होते हैं?**

सिर्फ स्लाइड्स को क्लोन करने वाले बुनियादी लूप में नहीं। लक्ष्य में आवश्यक सेक्शन बनाएं और सेक्शन ओवरलोड वाले [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) का उपयोग करें जब सेक्शन संरचना को संरक्षित करना हो।

**क्या स्पीकर नोट्स और टिप्पणियां संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। यदि आपके वर्कफ़्लो में नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भरता है, तो मर्ज के बाद परिणाम की पुष्टि करें क्योंकि ये परिस्थितियां प्रस्तुति‑स्तर की संरचनाओं तथा स्लाइड‑स्तर की सामग्री दोनों को शामिल करती हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक क्या होते हैं?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के रिसोर्स संबंधों के हिस्से के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइल या URL को मर्ज के बाद भी उपलब्ध होना चाहिए।

**क्या हर स्रोत से एम्बेडेड फ़ॉन्ट मर्ज्ड प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देती। लक्ष्य प्रस्तुति में एम्बेडेड फ़ॉन्ट की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions::setPassword()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/setpassword/) के साथ उसे खोलें, फिर सामान्य रूप से उसकी स्लाइड्स क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बहुत बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी पर भारी पड़ें तो BLOB प्रबंधन उपयोग करें, बहुत बड़ी फ़ाइलों के लिये फ़ाइल‑पाथ लोडिंग पसंद करें, स्रोत प्रस्तुतियों को मर्ज होने के तुरंत बाद डिस्पोज़ करें, और अंतिम परिणाम केवल आवश्यक होने पर सहेजें।

**क्या कई थ्रेड में स्लाइड्स को मर्ज किया जा सकता है?**

PHP via Java में प्रस्तुतियों को लोड, सहेज या क्लोन करने के लिए मल्टीथ्रेडिंग समर्थित नहीं है। समानांतर कार्य के लिये अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस चलाएँ और प्रत्येक प्रोसेस में अपनी प्रस्तुति इंस्टेंस रखें, और [Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन](/slides/hi/php-java/multithreading/) का पालन करें।