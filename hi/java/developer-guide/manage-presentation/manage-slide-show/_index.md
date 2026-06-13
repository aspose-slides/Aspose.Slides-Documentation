---
title: Java में स्लाइड शो को प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/java/manage-slide-show/
keywords:
- शो प्रकार
- स्पीकर द्वारा प्रस्तुत
- व्यक्ति द्वारा ब्राउज़ किया गया
- कियोस्क पर ब्राउज़ किया गया
- शो विकल्प
- लगातार लूप
- बिना वर्णन के शो
- बिना एनीमेशन के शो
- पेन रंग
- स्लाइड दिखाएँ
- कस्टम शो
- स्लाइड्स आगे बढ़ाएँ
- मैन्युअली
- टाइमिंग का उपयोग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड शो को प्रबंधित करना सीखें। PPT, PPTX और ODP फ़ॉर्मेट्स में स्लाइड ट्रांज़िशन, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों की तैयारी और प्रस्तुति के लिए एक प्रमुख उपकरण हैं। इस अनुभाग की सबसे महत्वपूर्ण सुविधाओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट परिस्थितियों और दर्शकों के अनुसार अनुकूलित करने की अनुमति देता है, जिससे लचीलापन और सुविधा सुनिश्चित होती है। इस सुविधा के साथ, आप शो प्रकार (जैसे, स्पीकर द्वारा प्रस्तुत, व्यक्ति द्वारा ब्राउज़ किया गया, या कियोस्क में ब्राउज़ किया गया), लूपिंग को सक्षम या अक्षम कर सकते हैं, प्रदर्शित करने के लिए विशिष्ट स्लाइड चुन सकते हैं, और टाइमिंग का उपयोग कर सकते हैं। तैयारी के इस चरण से आपकी प्रस्तुति अधिक प्रभावी और पेशेवर बनती है।

`getSlideShowSettings` मेथड [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक मेथड है जो [SlideShowSettings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowsettings/) प्रकार का ऑब्जेक्ट लौटाता है, जिससे आप PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स को प्रबंधित कर सकते हैं। इस लेख में, हम इस मेथड का उपयोग करके स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कॉन्फ़िगर और नियंत्रित करने का तरीका देखेंगे। 

## **शो प्रकार चुनें**

`SlideShowSettings.setSlideShowType` स्लाइड शो के प्रकार को निर्धारित करता है, जो निम्नलिखित क्लासों में से किसी एक का इंस्टेंस हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/java/com.aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/java/com.aspose.slides/browsedatkiosk/). इस मेथड का उपयोग करके आप प्रस्तुति को विभिन्न उपयोग परिदृश्यों, जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियों के लिए अनुकूलित कर सकते हैं।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" सेट करता है बिना स्क्रॉलबार दिखाए।

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **शो विकल्प सक्षम करें**

`SlideShowSettings.setLoop` निर्धारित करता है कि स्लाइड शो तब तक लूप में दोहराया जाए जब तक मैन्युअल रूप से रोका न जाए। यह निरंतर चलने वाली स्वचालित प्रस्तुतियों के लिए उपयोगी है। `SlideShowSettings.setShowNarration` निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ के वर्णन चलाए जाएँ या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिनमें दर्शकों के लिए आवाज़ मार्गदर्शन शामिल है। `SlideShowSettings.setShowAnimation` निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़ी गई एनिमेशन चलाए जाएँ या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने के लिए उपयोगी है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **दिखाने हेतु स्लाइड चुनें**

`SlideShowSettings.setSlides` मेथड आपको प्रस्तुति के दौरान दिखाने के लिए स्लाइडों की एक रेंज चुनने की अनुमति देता है। यह तब उपयोगी होता है जब आपको सभी स्लाइडों की बजाय केवल कुछ भाग दिखाना हो। निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को `2` से `9` तक सेट करता है।

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स को स्वचालित रूप से आगे बढ़ाएँ**

`SlideShowSettings.setUseTimings` मेथड आपको प्रत्येक स्लाइड के लिए पूर्वनिर्धारित टाइमिंग के उपयोग को सक्षम या अक्षम करने की अनुमति देता है। यह पूर्व-परिभाषित डिस्प्ले अवधि के साथ स्लाइड्स को स्वचालित रूप से दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग के उपयोग को अक्षम करता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **मीडिया नियंत्रण दिखाएँ**

`SlideShowSettings.setShowMediaControls` मेथड निर्धारित करता है कि मल्टीमीडिया सामग्री (जैसे वीडियो या ऑडियो) चलाते समय स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) दिखाए जाएँ या नहीं। यह तब उपयोगी है जब आप प्रस्तुतकर्ता को प्रस्तुति के दौरान मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रण को दिखाने के लिए सक्षम करता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति को इस तरह सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हाँ। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खुलने पर सीधे स्लाइड शो मोड में लॉन्च होते हैं। Aspose.Slides में, निर्यात के दौरान उपयुक्त सहेजने के फ़ॉर्मेट का चयन करें [during export](/slides/hi/java/save-presentation/)।

**क्या मैं शो से व्यक्तिगत स्लाइड्स को फ़ाइल से हटाए बिना बाहर रख सकता हूँ?**

हाँ। किसी स्लाइड को [hidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slide/#setHidden-boolean-) के रूप में चिह्नित करें। छिपे हुए स्लाइड्स प्रस्तुति में रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**क्या Aspose.Slides स्लाइड शो चला सकता है या स्क्रीन पर लाइव प्रस्तुति को नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषण और परिवर्तित करता है; वास्तविक प्लेबैक एक व्यूअर एप्लिकेशन जैसे PowerPoint द्वारा संभाला जाता है।