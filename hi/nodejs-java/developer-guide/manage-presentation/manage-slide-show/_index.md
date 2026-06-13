---
title: "जावास्क्रिप्ट में स्लाइड शो प्रबंधित करें"
linktitle: "स्लाइड शो"
type: docs
weight: 90
url: /hi/nodejs-java/manage-slide-show/
keywords:
- "शो प्रकार"
- "प्रस्तुतकर्ता द्वारा प्रस्तुत"
- "व्यक्तिगत द्वारा ब्राउज़ किया गया"
- "कियोस्क पर ब्राउज़ किया गया"
- "शो विकल्प"
- "लगातार लूप"
- "बिना नैरेशन के शो"
- "बिना एनीमेशन के शो"
- "पेन का रंग"
- "स्लाइड दिखाएँ"
- "अनुकूलित शो"
- "स्लाइड आगे बढ़ाएँ"
- "मैन्युअल रूप से"
- "टाइमिंग का उपयोग"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides के साथ जावास्क्रिप्ट में स्लाइड शो प्रबंधित करें। PPT, PPTX और ODP फ़ॉर्मेट्स में स्लाइड संक्रमण, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों को तैयार करने और देने के लिए एक प्रमुख उपकरण हैं। इस अनुभाग की सबसे महत्वपूर्ण विशेषताओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट परिस्थितियों और दर्शकों के अनुसार अनुकूलित करने की अनुमति देता है, जिससे लचीलापन और सुविधा प्राप्त होती है। इस सुविधा के साथ, आप शो प्रकार चुन सकते हैं (जैसे, प्रस्तुतकर्ता द्वारा प्रस्तुत, व्यक्तिगत द्वारा ब्राउज़ किया गया, या कियोस्क पर ब्राउज़ किया गया), लूपिंग को सक्षम या अक्षम कर सकते हैं, प्रदर्शित करने के लिए विशिष्ट स्लाइड चुन सकते हैं, और टाइमिंग का उपयोग कर सकते हैं। तैयारी में यह कदम आपकी प्रस्तुति को अधिक प्रभावी और पेशेवर बनाने के लिए महत्वपूर्ण है।

`getSlideShowSettings` एक विधि है जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की है और यह [SlideShowSettings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowsettings/) प्रकार का ऑब्जेक्ट लौटाती है, जो आपको PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स को प्रबंधित करने की सुविधा देता है। इस लेख में, हम इस विधि का उपयोग करके स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कॉन्फ़िगर और नियंत्रित करने का तरीका देखेंगे। 

## **शो प्रकार चुनें**

`SlideShowSettings.setSlideShowType` स्लाइड शो का प्रकार परिभाषित करता है, जिसका उदाहरण निम्नलिखित कक्षाओं में से हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/browsedatkiosk/)। इस विधि का उपयोग करके आप प्रस्तुति को विभिन्न उपयोग परिदृश्यों, जैसे स्वचालित कियोस्क या मैनुअल प्रस्तुतियों, के लिए अनुकूलित कर सकते हैं।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" पर सेट करता है बिना स्क्रॉलबार दिखाए।

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **शो विकल्प सक्षम करें**

`SlideShowSettings.setLoop` यह निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से रोके जाने तक लूप में दोहराया जाना चाहिए या नहीं। यह निरंतर चलने वाली स्वचालित प्रस्तुतियों के लिए उपयोगी है। `SlideShowSettings.setShowNarration` यह निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ी व्याख्यान चलाया जाना चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिनमें दर्शकों के लिए आवाज़ी मार्गदर्शन शामिल है। `SlideShowSettings.setShowAnimation` यह निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़े गए एनीमेशन्स चलाए जाने चाहिए या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने में मदद करता है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **दिखाने के लिए स्लाइड चुनें**

`SlideShowSettings.setSlides` मेथड आपको प्रस्तुति के दौरान दिखाने के लिए स्लाइड की एक रेंज चुनने की अनुमति देता है। यह तब उपयोगी है जब आपको पूरी प्रस्तुति की बजाय केवल कुछ ही स्लाइड दिखानी हों। निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को स्लाइड `2` से `9` तक सेट करता है।

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **अग्रिम स्लाइड्स का उपयोग करें**

`SlideShowSettings.setUseTimings` मेथड आपको प्रत्येक स्लाइड के लिए पूर्वनिर्धारित टाइमिंग्स के उपयोग को सक्षम या अक्षम करने की अनुमति देता है। यह पूर्वनिर्धारित डिस्प्ले अवधि के साथ स्वचालित रूप से स्लाइड दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग्स के उपयोग को अक्षम करता है।

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **मीडिया नियंत्रण दिखाएँ**

`SlideShowSettings.setShowMediaControls` मेथड निर्धारित करता है कि मल्टीमीडिया सामग्री (जैसे वीडियो या ऑडियो) चलाते समय स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) दिखाए जाने चाहिए या नहीं। यह उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रण को प्रदर्शित करने के लिए सक्षम करता है।

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति को इस प्रकार सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हां। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फॉर्मेट PowerPoint में खोलते ही सीधे स्लाइड शॉ में लॉन्च होते हैं। Aspose.Slides में, निर्यात के दौरान अनुरूप सहेजने का फॉर्मेट चुनें [during export](/slides/hi/nodejs-java/save-presentation/)।

**क्या मैं फ़ाइल से स्लाइड हटाए बिना व्यक्तिगत स्लाइड्स को शो से बाहर रख सकता हूँ?**

हां। एक स्लाइड को [hidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/sethidden/) के रूप में चिह्नित करें। छिपी हुई स्लाइड्स प्रस्तुति में रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**क्या Aspose.Slides स्लाइड शो चलाने या स्क्रीन पर लाइव प्रस्तुति को नियंत्रित करने में सक्षम है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषण और रूपांतरित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।