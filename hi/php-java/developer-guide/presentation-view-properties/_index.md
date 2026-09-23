---
title: PHP में प्रस्तुति दृश्य गुण पुनः प्राप्त करें और अद्यतन करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/php-java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के दृश्य गुणों की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के फ़ॉर्मेट को अनुकूलित किया जा सके — लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **Introduction**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति संबंधी गुण। यह जानकारी एप्लिकेशन को उसके दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, जिससे जब फिर से खोला जाए तो दृश्य उसी स्थिति में रहता है जैसा कि प्रस्तुति अंतिम बार सहेजी गई थी।

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है। 

[NormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties) क्लासेज तथा उनके उत्तराधिकारी, [SplitterBarStateType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType) एनीम जोड़े गए हैं।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

मेथड्स [getShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) यह निर्धारित करते हैं कि क्या एप्लिकेशन को normal view मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।

मेथड्स [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) यह निर्धारित करते हैं कि जब साइड क्षेत्र पर्याप्त छोटा हो तो लंबवत स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी [getPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) और [setPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) यह निर्धारित करती है कि उपयोगकर्ता मानक मानक three content regions वाले सामान्य दृश्य की बजाय पूर्ण-खिड़की एकल-समग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

मेथड्स [getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) यह निर्दिष्ट करते हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखेगा। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Maximized) और [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored)।

मेथड्स [getRestoredLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) और [getRestoredTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार निर्दिष्ट करते हैं, जब [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) पर क्रमशः लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब [getRestoredTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) का चाइल्ड हो, ऊँचाई जब [getRestoredLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) का चाइल्ड हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न्यूनतम या अधिकतम नहीं) हो। 

मेथड [getDimensionSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) स्लाइड क्षेत्र के आकार को निर्दिष्ट करता है (चौड़ाई जब restoredTop का चाइल्ड हो, ऊँचाई जब restoredLeft का चाइल्ड हो)।

मेथड [getAutoAdjust](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) यह निर्धारित करता है कि साइड सामग्री क्षेत्र का आकार विंडो को री-साइज़ करने पर नई आकार के लिए समायोजित होना चाहिए या नहीं।

नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के लिए [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) गुणों तक कैसे पहुँच सकते हैं।

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि जब प्रस्तुति खोली जाए, ज़ूम पहले से सेट हो। यह किसी प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) को प्रोग्रामेटिकली सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) कैसे सेट करें।

{{% /alert %}} 

दृश्य गुण सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।
   नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।

```php
  $presentation = new Presentation();
  try {
    # प्रस्तुति के दृश्य गुण सेट करना
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // स्लाइड दृश्य के लिए प्रतिशत में ज़ूम मान
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // नोट्स दृश्य के लिए प्रतिशत में ज़ूम मान

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation::getViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getViewProperties) का उपयोग करके प्रस्तुति-व्यापी दृश्य सेटिंग्स तक पहुँचें। [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#getGridSpacing) और [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#setGridSpacing) मेथड्स अंतर्निहित एडिटिंग ग्रिड की अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, व्यक्तिगत स्लाइड पर नहीं। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक सकारात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई इंच अंतराल सेट करता है, और परिणाम सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ग्रिड [drawing guides](/slides/hi/php-java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। ड्रॉइंग गाइड्स को जोड़ना, ले जाना या साफ़ करना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और ड्रॉइंग गाइड दोनों ही संपादन सहायक हैं। इन्हें PDF, इमेज, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को संग्रहीत करने से यह गारंटी नहीं मिलती कि एडिटर ग्रिड दिखाएगा: उसकी दृश्यता व्यूअर या एडिटर की पसंद पर भी निर्भर करती है।

## **प्रस्तुति खोलते समय टिप्पणियाँ दिखाएँ या छुपाएँ**

[Presentation::getViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) का उपयोग करके प्रस्तुति-व्यापी दृश्य सेटिंग्स तक पहुँचें। [ViewProperties::getShowComments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getshowcomments/) और [ViewProperties::setShowComments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/setshowcomments/) का उपयोग करके यह पढ़ें या बदलें कि प्रस्तुति PowerPoint या किसी अन्य संगत एडिटर में खुलते समय टिप्पणियाँ दिखाई जानी चाहिए या नहीं।

यह सेटिंग केवल संग्रहीत दृश्य प्राथमिकता को नियंत्रित करती है। यह टिप्पणियों को जोड़ती, हटाती, संपादित या हल नहीं करती। टिप्पणियों को छुपाने से उनकी सामग्री, लेखक, स्थितियाँ, उत्तर और स्थिति बरकरार रहती है। टिप्पणियों को स्वयं बदलने वाले कार्यों के लिए [Presentation Comments](/slides/hi/php-java/presentation-comments/) देखें।

निम्नलिखित उदाहरण के लिए एक मौजूदा `comments.pptx` की आवश्यकता है जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणियों को छुपाने का अनुरोध करता है, और किसी भी टिप्पणी को हटाए बिना नया PPTX सहेजता है। यह प्रारंभिक संपादन दृश्य को टिप्पणी दृश्यता के साथ कॉन्फ़िगर करने के लिए [ViewProperties::setLastView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/setlastview/) को [ViewType::SlideView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewtype/#SlideView) के साथ भी उपयोग करता है।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, इमेज, नोट्स या हैंडआउट एक्सपोर्ट में शामिल हैं या नहीं। संबंधित एक्सपोर्ट-विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं प्रस्तुति फिर से खोलता हूँ तो ग्रिड क्यों नहीं दिख रहा है?**

फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडिटर के ग्रिड दृश्यता सेटिंग्स को जांचें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शनों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), सेक्शन के अनुसार नहीं, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब वह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियों को पहले से परिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुणों को रखती है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियां उसी तरह खुलें?**

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।