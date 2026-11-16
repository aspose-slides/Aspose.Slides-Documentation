---
title: PHP में प्रेज़ेंटेशन व्यू प्रॉपर्टीज़ प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/php-java/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- नॉर्मल व्यू
- रूपरेखा सामग्री
- रूपरेखा आइकन्स
- स्नैप वर्टिकल स्प्लिटर
- सिंगल व्यू
- बार स्टेट
- डाइमेंशन साइज
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रेज़ेंटेशन्स में नॉर्मल व्यू लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड स्पेसिंग, और टिप्पणी दृश्यता को कॉन्फ़िगर करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड एक साइड पेन (थंबनेल या रूपरेखा) और नीचे नोट्स पेन के बीच दिखाई देती है। Aspose.Slides for PHP via Java प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) के माध्यम से उजागर करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड स्पेसिंग और टिप्पणी दृश्यता शामिल हैं।

## **NormalViewProperties के बारे में**

[getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) का उपयोग करके आप [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/) क्लास तक पहुँच सकते हैं। [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) नियंत्रित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में आइकन दिखें या नहीं। [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) उपयोगकर्ता द्वारा साइड पेन को संकुचित करने पर पेन को उसके न्यूनतम स्थिति में स्नैप करने देता है। [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) पूर्ण विंडो में एक पेन दिखाने की पसंद दर्शाता है।

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) साइड पेन और स्लाइड के बीच विभाजन नियंत्रित करता है। [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) नोट्स पेन के ऊपर विभाजन नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) का मान स्वीकार करते हैं जो `Minimized`, `Maximized`, या `Restored` हो सकता है।

## **NormalViewProperties को पुनर्स्थापित करने के बारे में**

जब किसी विभाजन को पुनर्स्थापित किया जाता है, तो [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) साइड पेन का सहेचा आकार प्रदान करता है और [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) ऊपर के स्लाइड क्षेत्र का सहेचा आकार प्रदान करता है। दोनों [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/) को प्रस्तुत करते हैं। उसकी [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) मेथड 0 से 100 तक का प्रतिशत स्वीकार करती है, और [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) नियंत्रित करता है कि विंडो के आकार बदलने पर संपादक आकार को स्वचालित रूप से समायोजित करे या नहीं।

यह उदाहरण मौज़ूद प्रेजेंटेशन को अपडेट करता है। यह क्षैतिज विभाजन को पुनर्स्थापित करता है, [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) द्वारा लौटाए गए आकार को 80% पर सेट करता है और स्वचालित समायोजन को सक्रिय करता है, तथा लंबवत विभाजन को अधिकतम करता है। यह [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) को भी कॉल करता है ताकि रूपरेखा दृश्य में आइकन प्रदर्शित हों।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) और [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) संपादक के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहित करते हैं। इन सेटिंग्स का स्लाइड आयाम, स्लाइड‑शो प्लेबैक, या इमेज एक्सपोर्ट रिज़ॉल्यूशन पर कोई प्रभाव नहीं पड़ता।

यह उदाहरण मौज़ूद प्रेजेंटेशन को खोलता है और स्लाइड को संपादन विंडो में फिट करने के लिए [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) को कॉल करता है। नोट्स पेज के लिए यह स्वचालित स्केलिंग को अक्षम करता है और एक निर्धारित 80% ज़ूम सेट करने हेतु [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) को कॉल करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) की `setGridSpacing` मेथड प्रेजेंटेशन भर में संपादन ग्रिड रेखाओं के बीच की दूरी निर्धारित करती है। यह पॉइंट्स में एक सकारात्मक मान लेती है, जहाँ 1 इंच में 72 पॉइंट्स होते हैं। यह उदाहरण मौज़ूद प्रेजेंटेशन में वर्तमान स्पेसिंग को प्रिंट करता है और अंतराल को 18 पॉइंट्स सेट करके एक चौथाई इंच ग्रिड सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ग्रिड एक निश्चित अंतराल पर दोहराता है। [ड्राइंग गाइड्स](/slides/hi/php-java/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिन्हित करते हैं। दोनों संपादन सहायक हैं और केवल उन संपादकों में दिखते हैं जो इन्हें प्रदर्शित करते हैं। स्लाइड शो और PDF, इमेज या SVG में निर्यात इनके बिना होते हैं।

## **प्रेजेंटेशन खोलते समय टिप्पणी दिखाएँ या छिपाएँ**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) वह प्राथमिकता संग्रहीत करता है जिसे संगत संपादक प्रेजेंटेशन खोलते समय उपयोग करते हैं। टिप्पणियों वाले मौज़ूद प्रेजेंटेशन के लिए यह उदाहरण वर्तमान सेटिंग को प्रिंट करता है और टिप्पणी छिपी हुई प्रतिलिपि को सहेजता है। यह [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) को [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) के साथ भी कॉल करता है ताकि प्रतिलिपि स्लाइड दृश्य में खुले।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

टिप्पणियों को छिपाने से उनका पाठ, लेखक, स्थितियाँ, जवाब और स्थिति संरक्षित रहती है। टिप्पणियों को स्वयं बदलने के लिए देखें [प्रेजेंटेशन टिप्पणियाँ](/slides/hi/php-java/presentation-comments/)। निर्यात सेटिंग्स यह नियंत्रित करती हैं कि टिप्पणी PDF, HTML, इमेज, नोट्स या हैंडआउट्स में दिखाई दे।

## **अक्सर पूछे जाने वाले सवाल**

**जब मैं प्रेजेंटेशन को पुनः खोलता हूँ तो ग्रिड क्यों छिपा रहता है?**  
प्रेजेंटेशन ग्रिड अंतराल को संग्रहीत करता है। ग्रिड देखने के लिए संपादक में ग्रिड दृश्यता को सक्षम करें।

**क्या ड्राइंग गाइड्स को साफ करने से ग्रिड स्पेसिंग बदलती है?**  
नहीं। गाइड जोड़ना, स्थान बदलना या साफ करना ग्रिड अंतराल को अपरिवर्तित रखता है।

**क्या प्रेजेंटेशन के विभिन्न भागों के लिए अलग-अलग दृश्य सेटिंग्स हो सकती हैं?**  
नहीं। [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) पूरे प्रेजेंटेशन पर लागू होता है।

**क्या मैं अलग-अलग उपयोगकर्ताओं के लिए अलग-अलग दृश्य सेटिंग्स सहेज सकता हूँ?**  
फ़ाइल सभी उपयोगकर्ताओं के लिए एक सेट दृश्य गुण संग्रहीत करती है। कोई संपादक उपयोगकर्ता की स्थानीय प्राथमिकता भी लागू कर सकता है।

**क्या मैं टेम्प्लेट में दृश्य सेटिंग्स सहेज सकता हूँ?**  
हां। टेम्प्लेट से बनाई गई प्रेजेंटेशन उसकी सहेजी गई दृश्य सेटिंग्स को विरासत में लेती है।