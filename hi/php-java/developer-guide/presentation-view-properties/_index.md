---
title: "PHP में प्रस्तुति व्यू गुण प्राप्त करना और अपडेट करना"
linktitle: "व्यू गुण"
type: docs
weight: 80
url: /hi/php-java/presentation-view-properties/
keywords:
- "व्यू गुण"
- "सामान्य दृश्य"
- "रूपरेखा सामग्री"
- "रूपरेखा आइकॉन"
- "वर्टिकल स्प्लिटर स्नैप"
- "एकल दृश्य"
- "बार स्थिति"
- "आयाम आकार"
- "ऑटो समायोजन"
- "डिफ़ॉल्ट ज़ूम"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java व्यू गुणों को खोजें ताकि PPT, PPTX, और ODP स्लाइड्स के फ़ॉर्मेट को कस्टमाइज़ किया जा सके — लेआउट, ज़ूम लेवल, और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड कंटेंट रीजन, और एक बॉटम कंटेंट रीजन। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को उसका दृश्य स्थिति फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य वही स्थिति में हो जैसा प्रस्तुति को अंतिम बार सहेजा गया था।

विधि[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties) वर्ग और उनके वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType) एनम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

मेथड्स[getShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) और[setShowOutlineIcons](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) यह निर्धारित करते हैं कि सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

मेथड्स[getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) और[setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) यह निर्दिष्ट करते हैं कि साइड रीजन पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी[getPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) और[setPreferSingleView](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) यह निर्धारित करता है कि उपयोगकर्ता पूर्ण-खिड़की एकल‑सामग्री रीजन को मानक तीन‑सामग्री क्षेत्रों वाले सामान्य दृश्य की तुलना में देखना पसंद करता है या नहीं। यदि सक्षम किया जाता है, तो एप्लिकेशन पूरे विंडो में एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

मेथड्स[getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और[getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) यह निर्धारित करते हैं कि क्षैतिज या वर्टिकल स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे की सामग्री रीजन से अलग करता है, वर्टिकल स्प्लिटर बार स्लाइड को साइड कंटेंट रीजन से अलग करता है। संभव मान हैं: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Maximized) और[SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored)।

मेथड्स[getRestoredLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) और[getRestoredTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) यह निर्दिष्ट करते हैं कि सामान्य दृश्य में शीर्ष या साइड स्लाइड रीजन का आकार क्या होगा, जब[getVerticalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) और[getHorizontalBarState](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) के लिए[SplitterBarStateType::Restored](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SplitterBarStateType/#Restored) मान लागू किया गया हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब रीजन परिवर्तनशील पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) में हो, तो सामान्य दृश्य में स्लाइड रीजन (चाइल्ड होने पर चौड़ाई/getRestoredTop और ऊँचाई/getRestoredLeft) का आकार निर्दिष्ट करता है।

मेथड[getDimensionSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) स्लाइड रीजन का आकार (पुनर्स्थापित टॉप के चाइल्ड होने पर चौड़ाई, पुनर्स्थापित लेफ्ट के चाइल्ड होने पर ऊँचाई) निर्दिष्ट करता है।

मेथड[getAutoAdjust](https://reference.aspose.com/slides/hi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) यह निर्दिष्ट करता है कि जब एप्लिकेशन में दृश्य वाली विंडो का आकार बदलता है तो साइड कंटेंट रीजन का आकार नए आकार के अनुसार स्वयं समायोजित हो।

निम्न उदाहरण दिखाता है कि आप प्रस्तुति के लिए[ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) गुणों तक कैसे पहुँच सकते हैं।

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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, ताकि प्रस्तुति खोलते समय ज़ूम पहले से ही सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है।[getSlideViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) तथा[ getNotesViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) को प्रोग्रामmatically सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि कैसे[View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) को[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) के लिए[Aspose.Slides](/slides/hi/) में सेट किया जाए।

{{% /alert %}} 

दृश्य गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) वर्ग का इंस्टांस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) के[View Properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ViewProperties) को सेट करें।
1. प्रस्तुति को एक[PPTX ](https://docs.fileformat.com/presentation/pptx/)file के रूप में लिखें। नीचे दिए गए उदाहरण में हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```php
  $presentation = new Presentation();
  try {
    # प्रस्तुति के व्यू गुण सेट करना
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति के विभिन्न हिस्सों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर निर्धारित किए जाते हैं ([Normal View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), न कि प्रति सेक्शन, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ के लिए लागू होता है जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियों को पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी के साथ साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं को मान दे सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुणों को रखती है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियों का खुलना वही हो?**

हाँ। क्योंकि[view properties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एंबेड कर सकते हैं और उसी प्रारम्भिक दृश्य कॉन्फ़िगरेशन के साथ नया दस्तावेज़ बना सकते हैं।