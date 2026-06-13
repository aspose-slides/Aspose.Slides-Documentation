---
title: एन्ड्रॉइड पर स्लाइड शो प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/androidjava/manage-slide-show/
keywords:
- शो प्रकार
- प्रस्तुतकर्ता द्वारा प्रस्तुत
- व्यक्तिगत द्वारा ब्राउज़ किया गया
- कियोस्क पर ब्राउज़ किया गया
- शो विकल्प
- निरन्तर लूप
- बिना कथन के शो
- बिना एनीमेशन के शो
- पेन रंग
- स्लाइड्स दिखाएँ
- कस्टम शो
- स्लाइड्स आगे बढ़ाएँ
- मैन्युअली
- टाइमिंग का उपयोग करके
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Android में Java के माध्यम से स्लाइड शो को कैसे प्रबंधित करें, जानें। PPT, PPTX और ODP फ़ॉर्मैट्स में स्लाइड ट्रांज़िशन, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों को तैयार करने और देने के लिए एक प्रमुख उपकरण हैं। इस अनुभाग में सबसे महत्वपूर्ण विशेषताओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट परिस्थितियों और दर्शकों के अनुसार तैयार करने की अनुमति देती है, जिससे लचीलापन और सुविधा सुनिश्चित होती है। इस सुविधा के साथ, आप शो प्रकार चुन सकते हैं (उदा., प्रस्तुतकर्ता द्वारा प्रस्तुत, किसी व्यक्ति द्वारा ब्राउज़ किया गया, या कियोस्क पर ब्राउज़ किया गया), लूपिंग को सक्षम या अक्षम कर सकते हैं, प्रदर्शित करने के लिए विशिष्ट स्लाइड्स चुन सकते हैं, और टाइमिंग का उपयोग कर सकते हैं। तैयारी का यह चरण आपकी प्रस्तुति को अधिक प्रभावी और पेशेवर बनाने के लिए महत्वपूर्ण है।

`getSlideShowSettings` एक मेथड है [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का, जो [SlideShowSettings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowsettings/) प्रकार का ऑब्जेक्ट लौटाता है, जो आपको PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स को प्रबंधित करने की अनुमति देता है। इस लेख में, हम देखेंगे कि इस मेथड का उपयोग स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कॉन्फ़िगर और नियंत्रित करने के लिए कैसे किया जाता है। 

## **शो प्रकार चुनें**

`SlideShowSettings.setSlideShowType` स्लाइड शो का प्रकार निर्धारित करता है, जो निम्नलिखित क्लासों का उदाहरण हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/browsedatkiosk/). इस मेथड का उपयोग करके आप विभिन्न उपयोग परिदृश्यों, जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियों के लिए प्रस्तुति को अनुकूलित कर सकते हैं।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" सेट करता है बिना स्क्रॉलबार दर्शाए।

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **शो विकल्प सक्षम करें**

`SlideShowSettings.setLoop` निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से बंद न करने तक लूप में दोहराना चाहिए या नहीं। यह स्वचालित प्रस्तुतियों के लिए उपयोगी है जिन्हें निरंतर चलना आवश्यक है। `SlideShowSettings.setShowNarration` निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ी कथा चलानी चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिनमें दर्शकों के लिए आवाज़ मार्गदर्शन शामिल है। `SlideShowSettings.setShowAnimation` निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़े गए एनीमेशन चलाने चाहिए या नहीं। यह प्रस्तुति के पूरे दृश्य प्रभाव को प्रदान करने में उपयोगी है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **प्रस्तुत करने के लिए स्लाइड्स चुनें**

`SlideShowSettings.setSlides` मेथड आपको प्रस्तुति के दौरान प्रदर्शित करने के लिए स्लाइड्स की एक रेंज चुनने की अनुमति देता है। यह उपयोगी है जब आपको पूरी प्रस्तुति के बजाय केवल उसका कुछ भाग दिखाना हो। निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को `2` से `9` तक प्रदर्शित करने के लिए सेट करता है।

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **स्लाइड्स को अग्रिम रूप से उपयोग करें**

`SlideShowSettings.setUseTimings` मेथड आपको प्रत्येक स्लाइड के लिए पूर्वनिर्धारित टाइमिंग्स के उपयोग को सक्षम या अक्षम करने की अनुमति देता है। यह पूर्वनिर्धारित प्रदर्शन अवधि के साथ स्वचालित रूप से स्लाइड्स दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग के उपयोग को अक्षम कर देता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **मीडिया नियंत्रण दिखाएँ**

`SlideShowSettings.setShowMediaControls` मेथड निर्धारित करता है कि मल्टीमीडिया सामग्री (उदा., वीडियो या ऑडियो) चलाते समय स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) प्रदर्शित किए जाने चाहिए या नहीं। यह तब उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तोता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रणों को प्रदर्शित करने के लिए सक्षम करता है।

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति को इस तरह सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हाँ। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खोलने पर सीधे स्लाइड शो में लॉन्च होते हैं। Aspose.Slides में, संबंधित सहेजने का फ़ॉर्मेट चुनें [during export](/slides/hi/androidjava/save-presentation/)।

**क्या मैं फ़ाइल से हटाए बिना व्यक्तिगत स्लाइड्स को शो से बाहर कर सकता हूँ?**

हाँ। एक स्लाइड को [hidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slide/#setHidden-boolean-) के रूप में चिह्नित करें। छुपी हुई स्लाइड्स प्रस्तुति में बनी रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**क्या Aspose.Slides स्क्रीन पर स्लाइड शो चला सकता है या लाइव प्रस्तुति को नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलें संपादित, विश्लेषण और परिवर्तित करता है; वास्तविक playback एक व्यूअर एप्लिकेशन जैसे PowerPoint द्वारा संभाला जाता है।