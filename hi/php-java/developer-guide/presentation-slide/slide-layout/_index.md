---
title: "PHP में स्लाइड लेआउट लागू करें या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/php-java/slide-layout/
keywords:
- स्लाइड लेआउट
- कंटेंट लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- उपयोग न किया गया लेआउट
- फुटर दृश्यता
- टाइटल स्लाइड
- टाइटल और कंटेंट
- सेक्शन हेडर
- दो कंटेंट
- तुलना
- टाइटल केवल
- खाली लेआउट
- कैप्शन वाला कंटेंट
- कैप्शन वाली तस्वीर
- टाइटल और वर्टिकल टेक्स्ट
- वर्टिकल टाइटल और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP (Java के माध्यम से) में स्लाइड लेआउट लागू करें, बनाएँ और संशोधित करें, प्लेसहोल्डर जोड़ें, उपयोग न किए गए लेआउट हटाएँ, और फुटर दृश्यता नियंत्रित करें।"
---
## **समीक्षा**

एक स्लाइड लेआउट प्लेसहोल्डर जैसे शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं की स्थितियों और स्वरूपण को निर्धारित करता है। लेआउट लागू करने से स्लाइड्स में एक समान संरचना बनती है जबकि प्रत्येक स्लाइड अपना स्वयं का सामग्री रख सकता है।

सबसे सामान्य लेआउट शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल करता है।
- **Title and Content**: शीर्षक प्लेसहोल्डर और एक सामान्य प्रयोजन कंटेंट प्लेसहोल्डर शामिल करता है।
- **Blank**: कोई कंटेंट प्लेसहोल्डर नहीं होता और जब प्रत्येक आकार को हस्तचालित रूप से स्थित किया जाएगा तब यह उपयोगी है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि, और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [layout slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) मास्टर का भाग होता है और प्लेसहोल्डरों की विशिष्ट व्यवस्था को परिभाषित करता है।
1. एक [normal slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिए दर्ज किया गया कंटेंट संग्रहीत करता है।

एक normal slide अपना थीम और स्वरूपण अपने लेआउट से विरासत में प्राप्त करता है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। normal slide पर सीधे सेट किया गया मान उस स्तर पर विरासत मान को ओवरराइड करता है। जब एक normal slide बनाई जाती है, तो उसके प्लेसहोल्डर शैलियों को चयनित लेआउट से उत्पन्न किया जाता है, जबकि उन प्लेसहोल्डरों में दर्ज किया गया कंटेंट normal slide का हिस्सा होता है।

लेआउट से स्लाइड्स बनाने से पहले आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में दूसरा प्लेसहोल्डर जोड़ने से मौजूदा normal स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर शैलियां नहीं जुड़ती हैं।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति बदलने से उन सभी स्लाइड्स को अपडेट किया जा सकता है जो उस पर निर्भर हैं। उपयोग में पहले से मौजूद लेआउट को संपादित करने से पहले, उसकी निर्भर स्लाइड्स की जांच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जो अभी भी किसी स्लाइड द्वारा उपयोग में है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट में पुनः असाइन करें, या केवल अनउपयोगित लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए, देखें [Slide Master](/slides/hi/php-java/slide-master/)।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता द्वारा संपादित किए जा सकते हैं और स्थानीयकृत हो सकते हैं, इसलिए स्रोत टेम्पलेट को नियंत्रित न करने पर नाम-आधारित चयन कम भरोसेमंद होता है।

निम्न उदाहरण पहले मास्टर पर **Title and Content** की खोज करता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर वापस जाता है। दूसरा null जांच आवश्यक है क्योंकि एक प्रस्तुति में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट फिर पहले normal स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#setLayoutSlide) मेथड द्वारा लागू किया जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

स्लाइड का लेआउट बदलने से स्लाइड पर सीधे जोड़े गए सामान्य आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर स्थितियां, विरासत स्वरूपण, और मौजूदा प्लेसहोल्डर और नए लेआउट के बीच का संबंध बदल सकता है, इसलिए विभिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जांच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग-अलग संचालन हैं। पिछला उदाहरण मौजूदा लेआउट को चुनता है; यह नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर के लेआउट संग्रह पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterlayoutslidecollection/#add) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक normal स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होने चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

टेम्पलेट को वास्तविक रूप से एक और पुन: प्रयोज्य संरचना की आवश्यकता होने पर ही लेआउट जोड़ें। यदि उपयुक्त लेआउट पहले से मौजूद है, तो नया बनाकर डुप्लिकेट बनाने की बजाय उसे चुनें और पुन: उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/) प्रदान करता है जिससे लेआउट में प्लेसहोल्डर शैलियां जोड़ी जा सकती हैं।

| PowerPoint प्लेसहोल्डर | `LayoutPlaceholderManager` मेथड |
| ----------------------- | -------------------------------- |
| ![सामग्री](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![पाठ](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![पाठ (ऊर्ध्वाधर)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![चित्र](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![चार्ट](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![तालिका](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![मीडिया](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ऑनलाइन छवि](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्न उदाहरण जाँचता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर इस संशोधित लेआउट का उपयोग करने वाली एक normal स्लाइड बनाता है। क्रम जानबूझकर रखा गया है: प्लेसहोल्डर को normal स्लाइड बनाने से पहले जोड़ा जाता है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर शैलियां उत्पन्न कर सके।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="चेतावनी" %}}
विरासत स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नए जोड़े गए लेआउट प्लेसहोल्डर मौजूदा normal स्लाइड्स में बैकफ़िल नहीं होते। लेआउट बदलावों को प्रस्तुति की एक प्रति पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जांच करें।
{{% /alert %}}

## **बिना उपयोग के लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड का उपयोग करके उन लेआउट्स को हटाएँ जिनका कोई normal स्लाइड संदर्भ नहीं देता। यह मेथड उन लेआउट्स को बिना छुए रखता है जो अभी भी उपयोग में हैं।

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

एक विशिष्ट लेआउट हटाने के लिए, पहले उसकी [hasDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getDependingSlides) मेथड का उपयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#remove) को कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में लेआउट हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर, और तिथि‑समय प्लेसहोल्डर होता है। उन प्लेसहोल्डरों को एक लेआउट के लिए नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) मेथड का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन शीर्षक लेआउट्स को नहीं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **मास्टर और उसकी संतान लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए, [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/#getHeaderFooterManager) मेथड का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslideheaderfootermanager/) के प्रसारण मेथड्स मास्टर और उसकी निर्भर लेआउट स्लाइड्स तथा normal स्लाइड्स पर कार्य करते हैं; वे केवल एक normal स्लाइड को लक्षित नहीं करते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

एक master स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। एक layout स्लाइड master का भाग होती है और प्लेसहोल्डरों की एक पुन: प्रयोज्य व्यवस्था को परिभाषित करती है। normal स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां। लक्ष्य संग्रह में एक कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/globallayoutslidecollection/#addClone) मेथड का उपयोग करें। प्रस्तुतियों के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं एक लेआउट को संशोधित करता हूँ जो पहले से प्रयोग में है तो क्या होता है?**

निर्भर स्लाइड्स लेआउट बदलावों को विरासत में लेती हैं जब तक कि वे स्थानीय रूप से प्रभावित स्वरूपण या वस्तुओं को ओवरराइड न करें। प्लेसहोल्डर ज्यामिति और विरासत शैली कई स्लाइड्स पर एक साथ बदल सकती है। लेआउट संपादित करने से पहले प्रभावित स्लाइड्स की पहचान करने हेतु [getDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करें।

**यदि मैं एक लेआउट को हटाता हूँ जो अभी भी उपयोग में है तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनउपयोगित लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें।