---
title: PHP में प्रभावी रूप से प्रस्तुतियों को मर्ज करें
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
description: "PHP में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड कंटेंट का आकार बदलकर, सेक्शन को संरक्षित करके, और सुरक्षित या बड़े फाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java एक प्रेजेंटेशन से दूसरी में स्लाइड क्लोन करके प्रस्तुतियों को मिलाता है। मुख्य ऑपरेशन [SlideCollection::addClone()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) है, जो स्रोत स्लाइड की फ़ॉर्मैटिंग को बनाए रख सकता है या क्लोन की गई स्लाइड को गंतव्य प्रेजेंटेशन में किसी मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मैटिंग को बरकरार रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रेजेंटेशन से एक मास्टर लागू करें;
- गंतव्य प्रेजेंटेशन से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्य बनाएं;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रेजेंटेशन्स को एक अंत‑से‑अंत वर्कफ़्लो में मर्ज करें;
- मास्टर्स, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फाइलें और मल्टीथ्रेडिंग संबंधी मामलों को संभालें।

## **स्लाइड क्लोनिंग कैसे मास्टर्स और लेआउट्स को प्रभावित करती है**

एक स्लाइड अपना अधिकांश रूप लेआउट और मास्टर से प्राप्त करती है। इसलिए, आप जिस क्लोनिंग ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गंतव्य प्रेजेंटेशन में कैसे एकीकृत होगी।

इनमें से किसी एक तरीके से [SlideCollection::addClone()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मैटिंग बनाए रखें। आवश्यक होने पर, स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रेजेंटेशन में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स को ट्रैक करता है ताकि वही स्रोत मास्टर प्रयोग करने वाली पुनरावृत्त स्लाइड्स बार‑बार क्लोन न हों।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को किसी विशिष्ट गंतव्य [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम से मिलते‑जुलते लेआउट की तलाश करता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे किसी विशिष्ट गंतव्य [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) से जोड़ें।

`addClone` ओवरलोड में पास किया गया मास्टर या लेआउट **गंतव्य** प्रेजेंटेशन से होना चाहिए, स्रोत प्रेजेंटेशन से नहीं।

## **पूरे प्रेजेंटेशन को मर्ज करें और स्रोत फ़ॉर्मैटिंग बनाए रखें**

सबसे सरल मर्ज स्रोत प्रेजेंटेशन की हर स्लाइड को गंतव्य प्रेजेंटेशन में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखना हो।

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

परिणामी प्रेजेंटेशन में कई मास्टर्स हो सकते हैं जब स्रोत और गंतव्य विभिन्न डिज़ाइनों का उपयोग करते हैं। यह अपेक्षित है क्योंकि स्रोत फ़ॉर्मैटिंग इरादतन संरक्षित की गई है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड क्लोन करने की जरूरत नहीं है। निम्नलिखित उदाहरण स्रोत प्रेजेंटेशन से केवल चयनित स्लाइड इंडेक्स को आयात करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले स्लाइड इंडेक्स को क्लोन करने से पहले सत्यापित करें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को गंतव्य प्रेजेंटेशन में पहले से मौजूद किसी मास्टर का अनुसरण करना हो, तो [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) फेंका जाता है।

`false` का उपयोग तब करें जब आप मर्ज को विफल चाहते हैं बजाय गंतव्य मास्टर में अतिरिक्त लेआउट जोड़ने के।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक जानते हैं कि आयातित स्लाइड्स को कौन से गंतव्य लेआउट का उपयोग करना चाहिए, तो [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) ओवरलोड का उपयोग करें।

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

गंतव्य लेआउट को लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनःडिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट की प्लेसहोल्डर संरचना अलग है, तो परिणाम का निरीक्षण करें ताकि विरासत में मिला फ़ॉर्मैटिंग और प्लेसहोल्डर व्यवहार उचित हो।

## **विभिन्न स्लाइड आकारों वाले प्रेजेंटेशन्स को मर्ज करें**

विभिन्न स्लाइड आयामों वाले प्रेजेंटेशन्स को मर्ज किया जा सकता है, लेकिन किसी प्रेजेंटेशन में दूसरे स्लाइड आकार के साथ स्लाइड को क्लोन करने से उसकी सामग्री नए कैनवास के लिए स्वतः पुनःडिज़ाइन नहीं होती। परिणामस्वरूप शैलियां शिफ्ट, स्केल या स्लाइड के दृश्य क्षेत्र के बाहर हो सकती हैं।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रेजेंटेशन का आकार बदलें। [SlideSize::setSize()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/setsize/) मेथड मौजूदा सामग्री को स्केल करता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

आकार बदलने से स्रोत प्रेजेंटेशन ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको अन्य ऑपरेशनों के लिए मूल स्रोत प्रेजेंटेशन अपरिवर्तित चाहिए, तो मर्ज के लिये एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रेजेंटेशन सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोन लूप स्रोत प्रेजेंटेशन की सेक्शन पदानुक्रम को पुनःसर्जित नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो गंतव्य प्रेजेंटेशन में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(Slide, Section)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) से क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट गंतव्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिये, गंतव्य में वही सेक्शन पुनः बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित गंतव्य सेक्शन से मैप करें।

## **कई प्रेजेंटेशन्स को सुरक्षित रूप से मर्ज करें**

निम्नलिखित अंत‑से‑अंत उदाहरण पहले प्रेजेंटेशन को गंतव्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्य करता है, प्रत्येक स्रोत को केवल तब तक खुला रखता है जब वह कॉपी हो रहा हो, और अंत में अंतिम फाइल को सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मैटिंग को संरक्षित करने के लिये एक उपयोगी बेंचमार्क है। यदि आपका आउटपुट एकल गंतव्य थीम का उपयोग करना चाहिए, तो सरल `addClone($slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर्स, लेआउट्स और फ़ॉर्मैटिंग फिडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रेजेंटेशन में ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स के लिये एक आंतरिक रजिस्ट्री रखता है ताकि समान मास्टर की बार‑बार क्लोनिंग से बचा जा सके। मैन्युअली क्लोन किए गए मास्टर्स इस रजिस्ट्री में नहीं आते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते तब तक पूर्व‑क्लोनिंग से बचें।

दोनों मास्टर्स या लेआउट्स के समान नाम होने का अर्थ यह नहीं कि वे दृश्य रूप से समान हों। यदि कोई कॉर्पोरेट टेम्पलेट अंतिम दिखावट को नियंत्रित करता है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और कमेंट्स**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी हो जाती हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/php-java/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/php-java/presentation-comments/) के लिये समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मैटिंग महत्वपूर्ण है, तो मर्ज किए गए प्रेजेंटेशन की जांच करें क्योंकि नोट़्स मास्टर्स प्रेजेंटेशन‑स्तरीय ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। रिव्यू वर्कफ़्लोज़ के लिये, विभिन्न लेखकों या टेम्पलेट्स से फ़ाइलें मिलाने के बाद कमेंट लेखकों और थ्रेडेड कमेंट्स की भी पुष्टि करें।

### **इमेजेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और एक्सटर्नल लिंक**

स्लाइड्स प्रेजेंटेशन‑स्तर के रिसोर्सेज जैसे इमेजेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा का संदर्भ दे सकती हैं। स्लाइड को स्वयं क्लोन करें न कि केवल उसके दृश्य शैलियों को कॉपी करें ताकि Aspose.Slides उसके रिसोर्सेज़ के साथ संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज़ को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अभी भी बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। मर्ज किए गए प्रेजेंटेशन को खोलने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ्स और URLs का परीक्षण करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर्स को ट्रैक करता है, लेकिन यह सार्वभौमिक गारंटी नहीं है कि असंबंधित स्रोत प्रेजेंटेशन्स के समान बाइनरी रिसोर्सेज हमेशा ड्यूप्लीकेट हटाए जाएँ। यदि आउटपुट फाइल आकार महत्वपूर्ण है, तो मर्ज पैकेज की जाँच करें और परिणाम मापें बजाय आंतरिक डीडुप्लिकेशन पर भरोसा करने के।

### **एम्बेडेड फ़ॉन्ट्स और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रेजेंटेशन स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को मशीनों के बीच सुसंगत रहना चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट्स गंतव्य वातावरण में उपलब्ध हों। आप [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) से एम्बेडेड फ़ॉन्ट्स की जाँच कर सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/php-java/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट्स को एम्बेड करने की अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑प्रोटेक्टेड प्रेजेंटेशन्स**

पासवर्ड‑प्रोटेक्टेड स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions::setPassword()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/setpassword/) के माध्यम से प्रदान करें।

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // डिक्रिप्टेड प्रेजेंटेशन के साथ काम करें।
} finally {
    $source->dispose();
}
```

एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से गंतव्य प्रेजेंटेशन पर वही सुरक्षा लागू नहीं करता। आवश्यकता पड़ने पर आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रेजेंटेशन्स और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेजेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रेजेंटेशन्स काफी मेमोरी खा सकती हैं। [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के लिये नियंत्रण प्रदान करता है। बड़े‑फ़ाइल उदाहरण के लिये PHP via Java में देखें [Open Presentations](https://docs.aspose.com/slides/hi/php-java/open-presentation/#open-large-presentations)।

बड़ी फ़ाइलों के लिये, यदि संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रेजेंटेशन को मर्ज हो जाने के बाद तुरंत डिस्पोज़ करें, और वर्कफ़्लो में आवश्यक न होने पर मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें।

### **थ्रेड सुरक्षा**

[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंसेज़ को कई थ्रेड्स में लोड, संशोधित, सहेज या क्लोन न करें। ये ऑपरेशन्स PHP via Java में मल्टीथ्रेडेड उपयोग के लिये समर्थित नहीं हैं। यदि आपको समानांतर मर्ज जॉब्स चलाने हैं, तो उन्हें अलग‑अलग सिंगल‑थ्रेडेड प्रोसेसेस में चलाएँ, प्रत्येक प्रोसेस अपने स्वयं के प्रेज़ेंटेशन इंस्टेंस का उपयोग करे, और [Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन](https://docs.aspose.com/slides/hi/php-java/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रेजेंटेशन की मूल डिज़ाइन कैसे बरकरार रखूँ?**

`addClone(sourceSlide)` को बिना गंतव्य मास्टर या लेआउट के प्रदान किए उपयोग करें। जब आयातित स्लाइड को स्रोत मास्टर की आवश्यकता होगी, तो Aspose.Slides उसे स्वचालित रूप से क्लोन कर देगा।

**आयातित स्लाइड्स को गंतव्य थीम का उपयोग कैसे करवाएँ?**

एक ऐसा ओवरलोड उपयोग करें जो गंतव्य मास्टर स्वीकार करता है। गंतव्य प्रेजेंटेशन से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस स्थिति में गंतव्य मास्टर के बजाय विशिष्ट गंतव्य लेआउट का उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट्स में से चयन करे, तो मास्टर चुनें।

**क्या विभिन्न स्लाइड आकारों वाले प्रेजेंटेशन्स को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री गंतव्य आयामों के लिये स्वतः पुनःडिज़ाइन नहीं होती। पूर्व‑रूपांतरित आकार की आवश्यकता होने पर [SlideSize::setSize()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रेजेंटेशन्स को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रेजेंटेशन को लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि फ़ॉर्मेट्स में फीचर सेट समान नहीं होते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की पुष्टि करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/php-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

नहीं, यदि आप केवल स्लाइड्स को क्लोन करने वाला बेसिक लूप उपयोग करते हैं। सेक्शन संरचना को संरक्षित करने के लिये, गंतव्य में आवश्यक सेक्शन पुनः बनाएं और सेक्शन ओवरलोड वाले [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/addclone/) का प्रयोग करें।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित होते हैं?**

वे क्लोन किए गए स्लाइड के साथ कॉपी हो जाते हैं। यदि आपके वर्कफ़्लो को नोट‑मास्टर स्टाइलिंग, कमेंट लेखकों या थ्रेडेड रिव्यू डेटा की आवश्यकता है, तो मर्ज परिणाम की पुष्टि करें क्योंकि ये परिदृश्य प्रेजेंटेशन‑स्तरीय संरचनाओं के साथ स्लाइड‑स्तरीय सामग्री को भी शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और हाइपरलिंक्स का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के रिसोर्स रिलेशनशिप्स के हिस्से के रूप में ले जाया जाता है। एक्सटर्नल लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइलें या URLs मर्ज के बाद भी उपलब्ध रहनी चाहिए।

**क्या सभी स्रोतों के एम्बेडेड फ़ॉन्ट्स मर्ज किए गए प्रेजेंटेशन में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग अकेले फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देता। गंतव्य के एम्बेडेड फ़ॉन्ट्स की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या एक्सटर्नल फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑प्रोटेक्टेड फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions::setPassword()](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/setpassword/) के साथ इसे खोलें, फिर उसकी स्लाइड्स को सामान्य रूप से क्लोन करें। आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

**बड़ी प्रेजेंटेशन्स को कैसे संभालूँ?**

बड़े बाइनरी ऑब्जेक्ट्स के कारण मेमोरी उपयोग होने पर BLOB मैनेजमेंट का उपयोग करें, बहुत बड़ी फ़ाइलों के लिये फ़ाइल‑पाथ लोडिंग प्राथमिकता दें, स्रोत प्रेजेंटेशन्स को तुरंत डिस्पोज़ करें, और अंतिम परिणाम को केवल आवश्यकता पड़ने पर ही सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

PHP via Java में प्रेज़ेंटेशन्स को लोड, सहेज या क्लोन करना मल्टीथ्रेडेड उपयोग के लिये सपोर्टेड नहीं है। समानांतर कार्यों के लिये अलग‑अलग सिंगल‑थ्रेडेड प्रोसेसेस चलाएँ और प्रत्येक प्रोसेस में अपने स्वयं के प्रेज़ेंटेशन इंस्टेंस रखें, और Aspose.Slides की मल्टीथ्रेडिंग गाइडलाइन का पालन करें।