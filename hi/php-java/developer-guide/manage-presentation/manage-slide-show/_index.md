---
title: PHP में स्लाइड शो प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/php-java/manage-slide-show/
keywords:
- शो प्रकार
- वक्ता द्वारा प्रस्तुत
- व्यक्तिगत द्वारा ब्राउज़ किया गया
- कियोस्क पर ब्राउज़ किया गया
- शो विकल्प
- लगातार लूप
- बिना व्याख्या के शो
- बिना एनीमेशन के शो
- पेन रंग
- स्लाइड दिखाएँ
- कस्टम शो
- स्लाइड आगे बढ़ाएँ
- हाथ से
- टाइमिंग्स का उपयोग
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में स्लाइड शो को कैसे प्रबंधित करें सीखें। PPT, PPTX और ODP फ़ॉर्मेट्स में स्लाइड ट्रांज़िशन, टाइमिंग्स और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों को तैयार करने और देने के लिए एक प्रमुख उपकरण है। इस अनुभाग की सबसे महत्वपूर्ण विशेषताओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट स्थितियों और दर्शकों के अनुसार अनुकूलित करने की अनुमति देता है, जिससे लचीलापन और सुविधा मिलती है। इस सुविधा के साथ, आप शो प्रकार चुन सकते हैं (जैसे स्पीकर द्वारा प्रस्तुत, व्यक्तिगत द्वारा ब्राउज़ किया गया, या कियोस्क पर ब्राउज़ किया गया), लूपिंग को सक्षम या अक्षम कर सकते हैं, प्रदर्शित करने के लिए विशिष्ट स्लाइड चुन सकते हैं, और टाइमिंग्स का उपयोग कर सकते हैं। तैयारी का यह चरण आपकी प्रस्तुति को अधिक प्रभावी और पेशेवर बनाने के लिए महत्वपूर्ण है।

`getSlideShowSettings` एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की विधि है जो [SlideShowSettings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowsettings/) प्रकार का ऑब्जेक्ट लौटाती है, जिससे आप PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स को प्रबंधित कर सकते हैं। इस लेख में, हम इस विधि का उपयोग करके स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कैसे कॉन्फ़िगर और नियंत्रित करें, इस पर चर्चा करेंगे। 

## **प्रदर्शन प्रकार चुनें**

`SlideShowSettings->setSlideShowType` स्लाइड शो का प्रकार परिभाषित करता है, जो निम्नलिखित क्लासों में से एक का उदाहरण हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/php-java/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/php-java/aspose.slides/browsedatkiosk/). इस विधि का उपयोग करके आप विभिन्न उपयोग परिदृश्यों के लिए प्रस्तुति को अनुकूलित कर सकते हैं, जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियाँ।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" सेट करता है, बिना स्क्रॉलबार दिखाए।

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **प्रदर्शन विकल्प सक्षम करें**

`SlideShowSettings->setLoop` निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से रोकने तक लूप में दोहराया जाना चाहिए या नहीं। यह निरंतर चलने वाली स्वचालित प्रस्तुतियों के लिए उपयोगी है। `SlideShowSettings->setShowNarration` निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ की व्याख्याएँ चलनी चाहिए या नहीं। यह ऑडियो मार्गदर्शन वाली स्वचालित प्रस्तुतियों के लिए उपयोगी है। `SlideShowSettings->setShowAnimation` निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़ी गई एनिमेशन चलनी चाहिए या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने में सहायक है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप में चलाता है।

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **प्रदर्शित करने के लिए स्लाइड्स चुनें**

`SlideShowSettings->setSlides` विधि आपको प्रस्तुति के दौरान दिखाने के लिए स्लाइड्स की एक रेंज चुनने की अनुमति देती है। यह तब उपयोगी है जब आपको पूरी प्रस्तुति के बजाय केवल कुछ भाग दिखाने की आवश्यकता हो। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को `2` से `9` तक सेट करता है।

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **स्लाइड्स को अग्रिम रूप से उपयोग करें**

`SlideShowSettings->setUseTimings` विधि आपको प्रत्येक स्लाइड के पूर्वनिर्धारित टाइमिंग्स के उपयोग को सक्षम या अक्षम करने की अनुमति देती है। यह पूर्वनिर्धारित प्रदर्शित अवधि के साथ स्वचालित रूप से स्लाइड्स दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग्स के उपयोग को अक्षम करता है।

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **मीडिया नियंत्रण दिखाएँ**

`SlideShowSettings->setShowMediaControls` विधि निर्धारित करती है कि मल्टीमीडिया सामग्री (जैसे वीडियो या ऑडियो) चलाते समय स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, स्टॉप) प्रदर्शित किए जाएँ या नहीं। यह तब उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रण को प्रदर्शित करने के लिए सक्षम करता है।

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति को इस तरह सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हां। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खोलने पर सीधे स्लाइड शो मोड में लॉन्च होते हैं। Aspose.Slides में, निर्यात के दौरान उपयुक्त सहेजने का फ़ॉर्मेट चुनें [during export](/slides/hi/php-java/save-presentation/)।

**क्या मैं फ़ाइल से स्लाइड हटाए बिना व्यक्तिगत स्लाइड्स को शो से बाहर रख सकता हूँ?**

हां। किसी स्लाइड को [hidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/sethidden/) के रूप में चिह्नित करें। छिपी स्लाइड्स प्रस्तुति में बनी रहती हैं लेकिन स्लाइड शो के दौरान नहीं दिखतीं।

**क्या Aspose.Slides स्लाइड शो चला सकता है या स्क्रीन पर लाइव प्रस्तुति को नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुतियों के फ़ाइलों को संपादित, विश्लेषण और परिवर्तित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।