---
title: PHP में स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/php-java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- अनुपयोगी लेआउट
- फ़ुटर दृश्यमानता
- टाइटल स्लाइड
- टाइटल और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल टाइटल
- ब्लैंक लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- टाइटल और ऊर्ध्वाधर टेक्स्ट
- ऊर्ध्वाधर टाइटल और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides में स्लाइड लेआउट को प्रबंधित और अनुकूलित करें। कोड उदाहरणों के साथ लेआउट प्रकार, प्लेसहोल्डर नियंत्रण और फ़ुटर दृश्यमानता का अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के लिए प्लेसहोल्डर बॉक्स और फॉर्मेटिंग की व्यवस्था को परिभाषित करता है। यह निर्धारित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ दिखाई देते हैं। स्लाइड लेआउट आपको तेज़ और सुसंगत प्रस्तुति बनाने में मदद करते हैं—चाहे आप कुछ सरल बना रहे हों या अधिक जटिल। PowerPoint में सबसे सामान्य स्लाइड लेआउट में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल करता है: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – शीर्ष पर एक छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट, चार्ट, चित्र आदि) के लिए बड़ा प्लेसहोल्डर।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, जिससे आप स्लाइड को शुरू से डिज़ाइन कर सकते हैं।

स्लाइड लेआउट स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुति के लिए लेआउट शैलियों को परिभाषित करने वाला शीर्ष‑स्तरीय स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड्स तक पहुँच और उन्हें संशोधित कर सकते हैं—उनके प्रकार, नाम या अद्वितीय ID से। वैकल्पिक रूप से, आप प्रस्तुति के भीतर किसी विशिष्ट लेआउट स्लाइड को सीधे संपादित कर सकते हैं।

Aspose.Slides for PHP में स्लाइड लेआउट के साथ काम करने के लिए आप उपयोग कर सकते हैं:

- वह मेथड्स जैसे [getLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getLayoutSlides) और [getMasters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasters) जो [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास के तहत उपलब्ध हैं
- प्रकार जैसे [LayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/), और [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड्स के साथ काम करने के बारे में अधिक जानने के लिए, [Slide Master](/slides/hi/php-java/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रस्तुति में स्लाइड लेआउट जोड़ें**

अपनी स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए आपको नई लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for PHP आपको यह जांचने की सुविधा देता है कि कोई विशेष लेआउट पहले से मौजूद है या नहीं, आवश्यकता होने पर नया लेआउट जोड़ें, और उसे उपयोग करके उस लेआउट के आधार पर स्लाइड सम्मिलित करें।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterlayoutslidecollection/) तक पहुँच प्राप्त करें।
1. जाँचें कि वांछित लेआउट स्लाइड संग्रह में पहले से मौजूद है या नहीं। यदि नहीं, तो आवश्यक लेआउट स्लाइड जोड़ें।
1. नई लेआउट स्लाइड के आधार पर एक खाली स्लाइड जोड़ें।
1. प्रस्तुति को सहेजें।

नीचे PHP कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड लेआउट कैसे जोड़ें:

```php
// PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
$presentation = new Presentation("Sample.pptx");
try {
    // लेआउट स्लाइड प्रकारों के माध्यम से जाएँ ताकि एक लेआउट स्लाइड चुन सकें।
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // ऐसी स्थिति जहाँ प्रस्तुति में सभी लेआउट प्रकार शामिल नहीं होते।
        // प्रस्तुति फ़ाइल में केवल ब्लैंक और कस्टम लेआउट प्रकार होते हैं।
        // हालाँकि, कस्टम प्रकार वाली लेआउट स्लाइड्स की पहचान योग्य नाम हो सकते हैं,
        // जैसे "Title", "Title and Content" आदि, जिन्हें लेआउट स्लाइड चयन के लिए उपयोग किया जा सकता है।
        // आप प्लेसहोल्डर आकार प्रकारों के एक सेट पर भी निर्भर कर सकते हैं।
        // उदाहरण के लिये, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // जोड़े गए लेआउट स्लाइड का उपयोग करके एक खाली स्लाइड जोड़ें।
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // प्रस्तुति को डिस्क पर सहेजें।
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अनुपयोगी लेआउट स्लाइड हटाएँ**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास में उपलब्ध [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड आपको अनावश्यक और अप्रयुक्त लेआउट स्लाइड्स को हटाने की सुविधा देता है।

नीचे PHP कोड दिखाता है कि PowerPoint प्रस्तुति से लेआउट स्लाइड कैसे हटाएँ:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

Aspose.Slides [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड प्रदान करता है, जिससे आप लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ सकते हैं।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिए मेथड्स शामिल करता है:

| PowerPoint प्लेसहोल्डर | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/) विधि |
| ----------------------- | ------------------------------------------------------------------- |
| ![सामग्री](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![टेक्स्ट](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![टेक्स्ट (ऊर्ध्वाधर)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![चित्र](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![चार्ट](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![टेबल](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![मीडिया](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![ऑनलाइन चित्र](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

नीचे PHP कोड दिखाता है कि Blank लेआउट स्लाइड में नए प्लेसहोल्डर आकार कैसे जोड़ें:

```php
$presentation = new Presentation();
try {
    // Blank लेआउट स्लाइड प्राप्त करें।
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // लेआउट स्लाइड के प्लेसहोल्डर मैनेजर को प्राप्त करें।
    $placeholderManager = $layout->getPlaceholderManager();

    // Blank लेआउट स्लाइड में विभिन्न प्लेसहोल्डर जोड़ें।
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Blank लेआउट के साथ एक नई स्लाइड जोड़ें।
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

## **लेआउट स्लाइड के लिए फुटर दृश्यमानता सेट करें**

PowerPoint प्रस्तुतियों में तिथि, स्लाइड नंबर और कस्टम टेक्स्ट जैसी फुटर तत्वों को स्लाइड लेआउट के आधार पर दिखाया या छुपाया जा सकता है। Aspose.Slides for PHP आपको इन फुटर प्लेसहोल्डर की दृश्यमानता को नियंत्रित करने की सुविधा देता है। यह उपयोगी है जब आप कुछ लेआउट में फुटर दिखाना चाहते हैं जबकि अन्य को साफ़ रखना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स के आधार पर एक लेआउट स्लाइड रेफ़रेंस प्राप्त करें।
1. स्लाइड फुटर प्लेसहोल्डर को दृश्यमान के रूप में सेट करें।
1. स्लाइड नंबर प्लेसहोल्डर को दृश्यमान के रूप में सेट करें।
1. तिथि‑समय प्लेसहोल्डर को दृश्यमान के रूप में सेट करें।
1. प्रस्तुति को सहेजें।

नीचे PHP कोड दिखाता है कि स्लाइड फुटर की दृश्यमानता कैसे सेट करें और संबंधित कार्य करें:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **स्लाइड के लिए चाइल्ड फुटर दृश्यमानता सेट करें**

PowerPoint प्रस्तुतियों में तिथि, स्लाइड नंबर और कस्टम टेक्स्ट जैसे फुटर तत्वों को मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है ताकि सभी लेआउट स्लाइड्स में एकरूपता बनी रहे। Aspose.Slides for PHP आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यमानता और सामग्री सेट करने, और इन्हें सभी चाइल्ड लेआउट स्लाइड्स पर प्रसारित करने की सुविधा देता है। यह आपके प्रस्तुति में समान फुटर जानकारी सुनिश्चित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. उसके इंडेक्स के आधार पर मास्टर स्लाइड का रेफ़रेंस प्राप्त करें।
1. मास्टर और सभी चाइल्ड फुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड तिथि‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रस्तुति को सहेजें।

नीचे PHP कोड इस ऑपरेशन को दर्शाता है:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड समग्र थीम और डिफ़ॉल्ट फॉर्मेटिंग को परिभाषित करता है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिए प्लेसहोल्डर की विशिष्ट व्यवस्थाएँ निर्धारित करता है।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां, आप किसी प्रस्तुति की लेआउट स्लाइड संग्रह से (जिस तक आप [getLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getLayoutSlides) मेथड से पहुंच सकते हैं) लेआउट स्लाइड को क्लोन करके `addClone` मेथड का उपयोग कर दूसरी प्रस्तुति में सम्मिलित कर सकते हैं।

**यदि मैं किसी लेआउट स्लाइड को हटाता हूँ जो अभी भी किसी स्लाइड द्वारा उपयोग में है तो क्या होता है?**

यदि आप ऐसी लेआउट स्लाइड को हटाने का प्रयास करते हैं जो कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) फेंकेगा। इसे रोकने के लिए, आप [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग कर सकते हैं, जो केवल अनउपयोगी लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है।