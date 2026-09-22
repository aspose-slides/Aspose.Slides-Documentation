---
title: PHP में प्रस्तुति व्यू गुणों को प्राप्त करना और अपडेट करना
linktitle: व्यू गुण
type: docs
weight: 80
url: /hi/php-java/presentation-view-properties/
keywords:
- व्यू गुण
- सामान्य व्यू
- रूपरेखा सामग्री
- रूपरेखा आइकन
- स्नैप वर्टिकल स्प्लिटर
- सिंगल व्यू
- बार स्थिति
- डायमेंशन साइज
- ऑटो अडजस्ट
- डिफ़ॉल्ट ज़ूम
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के व्यू गुणों की खोज करें ताकि PPT, PPTX, और ODP स्लाइड्स के फॉर्मेट को अनुकूलित किया जा सके — लेआउट, ज़ूम स्तर, और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

Normal view में तीन सामग्री क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को अपने view state को फ़ाइल में सेव करने की अनुमति देती है, ताकि पुनः खोलने पर view वही स्थिति में रहे जैसा कि प्रस्तुति आखिरी बार सहेजी गई थी।

Method [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) को सामान्य view के गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties) क्लास और उनके descendants, [SplitterBarStateType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य view गुणों का प्रतिनिधित्व करता है।

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) यह निर्धारित करते हैं कि सामान्य view मोड के किसी भी सामग्री क्षेत्र में outline सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) यह निर्धारित करते हैं कि जब साइड क्षेत्र पर्याप्त रूप से छोटा हो तो vertical splitter को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

Property [getPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) और [setPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) यह निर्दिष्ट करता है कि उपयोगकर्ता सामान्य view के तीन सामग्री क्षेत्रों के बजाय पूर्ण-खिड़की सिंगल-कंटेंट क्षेत्र देखना चाहते हैं या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित करना चुन सकता है।

Methods [getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) यह निर्दिष्ट करते हैं कि horizontal या vertical splitter bar को किस अवस्था में दिखाया जाना चाहिए। एक horizontal splitter bar स्लाइड को नीचे की सामग्री region से अलग करता है, जबकि vertical splitter bar स्लाइड को साइड सामग्री region से अलग करता है। संभावित मान हैं: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Maximized) और [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored)।

Methods [getRestoredLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) और [getRestoredTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) यह निर्दिष्ट करते हैं जब [SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) के लिए लागू किया जाता है, तब सामान्य view की शीर्ष या साइड स्लाइड region का आकार किस प्रकार होना चाहिए।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

यह निर्धारित करता है कि सामान्य view की स्लाइड region (width जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredTop) की चाइल्ड हो, height जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) की चाइल्ड हो) का आकार क्या होना चाहिए, जब region का आकार परिवर्तनीय हो (न तो minimized और न ही maximized)।

Method [getDimensionSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) स्लाइड region का आकार (restoredTop की चाइल्ड होने पर width, restoredLeft की चाइल्ड होने पर height) निर्दिष्ट करता है।

Method [getAutoAdjust](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) यह निर्धारित करता है कि जब एप्लिकेशन में view वाली विंडो का आकार बदलता है तो साइड सामग्री region का आकार नई स्थिति के अनुसार समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के लिए [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) गुणों तक कैसे पहुंच सकते हैं।

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # प्रस्तुति के व्यू गुणों को पुनर्स्थापित करें
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

Aspose.Slides for PHP via Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करना समर्थित करता है ताकि प्रस्तुति खुलते ही ज़ूम पहले से सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) कैसे सेट करें।

{{% /alert %}} 

View properties सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का उदाहरण बनाएं।
1. उस [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को [PPTX ](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें। नीचे दिए गए उदाहरण में, हमने स्लाइड view और notes view दोनों के लिए ज़ूम मान सेट किया है।

```php
  $presentation = new Presentation();
  try {
    # प्रस्तुति के व्यू गुणों को सेट करना
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ग्रिड स्पेसिंग सेट करें**

पूरे प्रस्तुति‑वाइड view सेटिंग्स तक पहुंचने के लिए [Presentation::getViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getViewProperties) का उपयोग करें। [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#getGridSpacing) और [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/#setGridSpacing) मेथड अंतर्निहित संपादन ग्रिड का अंतराल पढ़ते या बदलते हैं। यह सेटिंग पूरे प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्धारित होती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक सकारात्मक मान उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच अंतराल सेट करता है, और परिणाम सहेजता है।

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

ग्रिड [drawing guides](/slides/hi/php-java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि drawing guides को व्यक्तिगत रूप से क्षैतिज या लंबवत संरेखण रेखाओं के रूप में स्थित किया जाता है। Drawing guides को जोड़ना, स्थानांतरित करना या हटाना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और drawing guides दोनों ही संपादन सहायता हैं। इन्हें PDF, इमेज, SVG या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को संग्रहीत करने से यह गारंटी नहीं मिलती कि कोई संपादक ग्रिड दिखाएगा: इसकी दृश्यता व्यूअर या संपादक की प्राथमिकताओं पर भी निर्भर करती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**ग्रिड पुनः खोलने के बाद दृश्यमान क्यों नहीं है?**

फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन संपादक तय करता है कि ग्रिड प्रदर्शित हो या नहीं। संपादक की ग्रिड दृश्यता सेटिंग्स जांचें।

**क्या drawing guides को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। Drawing guides और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड हटाने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग view सेटिंग्स कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), न कि प्रति सेक्शन, इसलिए एक ही सेट पैरामीटर पूरे दस्तावेज़ पर लागू होते हैं जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग view state पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट view properties रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुति समान तरीके से खुले?**

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नई दस्तावेज़ उसी प्रारंभिक view कॉन्फ़िगरेशन के साथ बना सकते हैं।