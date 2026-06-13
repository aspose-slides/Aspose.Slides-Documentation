---
title: PHP का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/php-java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्‍फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में स्लाइड ट्रांज़िशन को अनुकूलित करने के तरीके खोजें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन को प्रबंधित करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड पर ट्रांज़िशन प्रकार कैसे लागू करें, ट्रांज़िशन व्यवहार कैसे कॉन्फ़िगर करें जैसे कि क्लिक पर आगे बढ़ना या निर्धारित समय के बाद, स्वचालित अग्रसरता की जाँच और उसे अक्षम करना, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करना, और ट्रांज़िशन इफ़ेक्ट विकल्प सेट करना। उदाहरण दर्शाते हैं कि प्रस्तुति को कैसे लोड या बनाएं, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स को संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। लेख सामान्य प्रश्नों के उत्तर भी देता है जैसे ट्रांज़िशन गति, ट्रांज़िशन ध्वनियाँ, कई स्लाइड्स पर एक ही ट्रांज़िशन लागू करना, और किसी स्लाइड पर वर्तमान में सेट ट्रांज़िशन की जाँच करना।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक सरल स्लाइड ट्रांज़िशन प्रभाव बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. Aspose.Slides for PHP via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर TransitionType ए़नम के माध्यम से स्लाइड ट्रांज़िशन प्रकार लागू करें।
3. संशोधित प्रस्तुति फ़ाइल लिखें।

```php
  # स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास का इंस्टांस बनाएं
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # प्रस्तुति को डिस्क पर सहेजें
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**
ऊपर के अनुभाग में हमने केवल एक सरल ट्रांज़िशन इफ़ेक्ट स्लाइड पर लागू किया था। अब, इस सरल ट्रांज़िशन इफ़ेक्ट को और बेहतर और नियंत्रित बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. Aspose.Slides for PHP via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर ट्रांज़िशन प्रकार लागू करें।
3. आप ट्रांज़िशन को Advance On Click, किसी विशेष समय अवधि के बाद या दोनों पर सेट कर सकते हैं।
4. यदि स्लाइड ट्रांज़िशन को Advance On Click के लिए सक्षम किया गया है, तो ट्रांज़िशन केवल तब आगे बढ़ेगा जब कोई माउस पर क्लिक करेगा। इसके अतिरिक्त, यदि Advance After Time प्रॉपर्टी सेट है, तो ट्रांज़िशन निर्दिष्ट समय बीतने के बाद स्वचालित रूप से आगे बढ़ेगा।
5. संशोधित प्रस्तुति को एक प्रस्तुति फ़ाइल के रूप में लिखें।

```php
  # Presentation क्लास को इंस्टैंसिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 3 सेकंड का ट्रांज़िशन समय सेट करें
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 5 सेकंड का ट्रांज़िशन समय सेट करें
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # स्लाइड 3 पर जूम प्रकार का ट्रांज़िशन लागू करें
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 7 सेकंड का ट्रांज़िशन समय सेट करें
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # प्रस्तुति को डिस्क पर सहेजें
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph ट्रांज़िशन**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java अब [Morph Transition](https://reference.aspose.com/slides/hi/php-java/aspose.slides/morphtransition/) का समर्थन करता है। यह PowerPoint 2019 में प्रस्तुत नया morph ट्रांज़िशन दर्शाता है।

{{% /alert %}} 

Morph ट्रांज़िशन आपको एक स्लाइड से अगले स्लाइड तक सुगम गति से एनीमेट करने की अनुमति देता है। यह लेख इस अवधारणा और Morph ट्रांज़िशन के उपयोग को विस्तृत करता है। Morph ट्रांज़िशन को प्रभावी ढंग से उपयोग करने के लिए आपके पास दो स्लाइड्स हों जिनमें कम से कम एक ऑब्जेक्ट सामान्य हो। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरे स्लाइड पर ऑब्जेक्ट को अलग जगह ले जाना।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड की एक क्लोन को कुछ टेक्स्ट के साथ प्रस्तुति में जोड़ें और दूसरे स्लाइड पर [morph type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TransitionType) का ट्रांज़िशन सेट करें।

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph ट्रांज़िशन प्रकार**
नई [TransitionMorphType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/TransitionMorphType) ए़नम जोड़ी गयी है। यह Morph स्लाइड ट्रांज़िशन के विभिन्न प्रकारों का प्रतिनिधित्व करता है।

TransitionMorphType ए़नम में तीन सदस्य हैं:

- ByObject: Morph ट्रांज़िशन आकारों को अपरिभाज्य वस्तुओं के रूप में मानते हुए किया जाएगा।
- ByWord: Morph ट्रांज़िशन शब्दों द्वारा पाठ को स्थानांतरित करते हुए किया जाएगा जहाँ संभव हो।
- ByChar: Morph ट्रांज़िशन अक्षरों द्वारा पाठ को स्थानांतरित करते हुए किया जाएगा जहाँ संभव हो।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड पर morph ट्रांज़िशन सेट करें और morph प्रकार बदलें:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**
Aspose.Slides for PHP via Java काले से, बाएँ से, दाएँ से आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने का समर्थन करता है। ट्रांज़िशन इफ़ेक्ट सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन इफ़ेक्ट सेट करना।
- प्रस्तुति को [PPTX ](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

निम्नलिखित उदाहरण में, हमने ट्रांज़िशन इफ़ेक्ट सेट किए हैं।

```php
  # Presentation क्लास का एक इंस्टांस बनाएं
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # इफ़ेक्ट सेट करें
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # प्रस्तुति को डिस्क पर सहेजें
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**  
हाँ। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setspeed/) को [TransitionSpeed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/transitionspeed/) सेटिंग का उपयोग करके सेट करें (जैसे, slow/medium/fast)।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**  
हाँ। आप ट्रांज़िशन के लिए ध्वनि एम्बेड कर सकते हैं और ध्वनि मोड तथा लूपिंग जैसी सेटिंग्स के माध्यम से व्यवहार को नियंत्रित कर सकते हैं (जैसे, [setSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setsoundloop/), साथ ही [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) और [setSoundName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/setsoundname/) जैसी मेटाडेटा)।

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**  
प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड पर अलग से संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर एक ही प्रकार लागू करने से एकसमान परिणाम मिलता है।

**मैं कैसे जाँचूँ कि स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**  
स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getSlideShowTransition) का निरीक्षण करें और उसकी [transition type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideshowtransition/settype/) को पढ़ें; यह मान बताता है कि कौन सा इफ़ेक्ट लागू किया गया है।