---
title: PHP में स्लाइड लेआउट लागू करें या बदलें
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
- अप्रयुक्त लेआउट
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और वर्टिकल टेक्स्ट
- वर्टिकल शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में स्लाइड लेआउट लागू करें, बनाएँ और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता नियंत्रित करें."
---
## **Overview**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिका जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स में एक सुसंगत संरचना बनती है जबकि प्रत्येक स्लाइड को अपना स्वयं का सामग्री रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल हैं।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल है।
- **Blank**: कोई सामग्री प्लेसहोल्डर नहीं होता और जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाएगा तो यह उपयोगी होता है।

## **Understand Layout Inheritance**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. A [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
2. A [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) मास्टर से संबंधित होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है।
3. A [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करती है।

एक सामान्य स्लाइड अपना थीम और स्वरूपण अपने लेआउट से विरासत में लेती है, और लेआउट अपने मास्टर से विरासत में लेता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज सामग्री सामान्य स्लाइड की ही होती है।

स्लाइड्स बनाने से पहले लेआउट में आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में किसी अतिरिक्त प्लेसहोल्डर को जोड़ने से मौजूदा सामान्य स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिले स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकते हैं। उपयोग में हो रहे लेआउट को संपादित करने से पहले उसकी निर्भर स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अनउपयोगी लेआउट हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/php-java/slide-master/)।

एक स्लाइड या साझा लेआउट पर विरासत में मिले लोगो या सजावटी मास्टर आकारों को छिपाने के लिए देखें [Control the Visibility of Master Graphics](/slides/hi/php-java/slide-master/). उदाहरण दो स्लाइड्स की तुलना करता है जो एक ही मास्टर का उपयोग करती हैं।

## **Select and Apply a Slide Layout**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट के नाम उपयोग‑संशोधित होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम‑आधारित चयन कम भरोसेमंद है जब तक आप स्रोत टेम्पलेट को नियंत्रित नहीं करते।

निम्न उदाहरण पहले मास्टर पर **Title and Content** लेआउट को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर फ़ॉलबैक करता है। दूसरा null जांच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट ही हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#setLayoutSlide) मेथड के माध्यम से लागू किया जाता है।

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

लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का संबंध बदल सकता है, इसलिए काफी भिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **Add a Layout Slide**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछले उदाहरण ने मौजूदा लेआउट को चुना; उसने नया नहीं बनाया। एक लेआउट बनाने के लिए, लक्ष्य मास्टर के लेआउट संग्रह पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterlayoutslidecollection/#add) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक नया **Title and Content** लेआउट जोड़ता है, फिर उसके आधार पर एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होना चाहिए।

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

केवल तब ही लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक और पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो नया बनाने के बजाय उसे चुनें और पुनः उपयोग करें।

## **Add Placeholders to a Layout Slide**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/) लौटाता है जिससे लेआउट में प्लेसहोल्डर आकार जोड़ सकते हैं।

| PowerPoint प्लेसहोल्डर | `LayoutPlaceholderManager` मेथड |
| ------------------------ | -------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्न उदाहरण सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम को जान‑बूझकर इस प्रकार रखा गया है: प्लेसहोल्डर सामान्य स्लाइड बनाने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिले स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर्स की ज्यामिति बदलने से निर्भर स्लाइड्स पर प्रभाव पड़ सकता है। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में पीछे से नहीं भरा जाता। लेआउट परिवर्तन को प्रस्तुति की प्रतिलिपि पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **Remove Unused Layout Slides**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड का उपयोग उन लेआउट्स को हटाने के लिए करें जहाँ कोई सामान्य स्लाइड संदर्भ नहीं रखती। यह मेथड अभी भी उपयोग में रहने वाले लेआउट्स को अपरिवर्तित छोड़ देता है।

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

किसी विशिष्ट लेआउट को हटाने के लिए पहले उसकी [hasDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getDependingSlides) मेथड का उपयोग करें। निर्भर स्लाइड्स को पुनः असाइन करने के बाद ही [LayoutSlide.remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#remove) को कॉल करें। उपयोग में रहे लेआउट को हटाने की कोशिश करने से एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **Control Footer Visibility on a Layout Slide**

लेआउट में अपना स्वयं का फ़ूटर, स्लाइड‑नंबर और तिथि‑समय प्लेसहोल्डर होते हैं। इन प्लेसहोल्डर्स को किसी एक लेआउट के लिए नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) मेथड का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर कंटेंट लेआउट्स को फ़ूटर दिखाना हो लेकिन टाइटल लेआउट्स को नहीं।

निम्न उदाहरण सुरक्षित रूप से एक लेआउट चुनता है और उसके फ़ूटर तत्वों को दृश्यमान बनाता है:

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

## **Control Footer Visibility on a Master and Its Child Layouts**

मास्टर पदानुक्रम में समान फ़ूटर सेटिंग्स लागू करने के लिए [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/#getHeaderFooterManager) मेथड का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslideheaderfootermanager/) की प्रोपेगेशन मेथड्स मास्टर, उसकी निर्भर लेआउट स्लाइड्स और सामान्य स्लाइड्स पर काम करती हैं; वे केवल एक सामान्य स्लाइड को लक्ष्य नहीं बनातीं।

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

**क्या है एक Master Slide और Layout Slide के बीच का अंतर?**

मास्टर स्लाइड प्रस्तुति का थीम और साझा स्वरूपण परिभाषित करती है। लेआउट स्लाइड एक मास्टर से संबंधित होती है और प्लेसहोल्डर्स की एक पुन: प्रयोज्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक Layout Slide को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हाँ। लक्ष्य संग्रह में एक प्रतिलिपि जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/globallayoutslidecollection/#addClone) मेथड का उपयोग करें। प्रस्तुतियों के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**यदि मैं एक लेआउट को संशोधित करता हूँ जो पहले से उपयोग में है तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं जब तक कि उन्होंने स्थानीय रूप से प्रभावित स्वरूपण या वस्तुओं को ओवरराइड नहीं किया हो। प्लेसहोल्डर की ज्यामिति और विरासत में मिला स्टाइलिंग कई स्लाइड्स पर एक साथ बदल सकता है। संपादन से पहले प्रभावित स्लाइड्स की पहचान करने के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करें।

**यदि मैं एक लेआउट को हटाता हूँ जो अभी भी उपयोग में है तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) फेंकेगा। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अप्रयुक्त लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) का प्रयोग करें।