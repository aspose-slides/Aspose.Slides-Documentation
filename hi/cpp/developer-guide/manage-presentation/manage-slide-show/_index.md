---
title: C++ में स्लाइड शो प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/cpp/manage-slide-show/
keywords:
- शो प्रकार
- स्पीकर द्वारा प्रस्तुत
- व्यक्ति द्वारा ब्राउज़ किया गया
- कियोस्क पर ब्राउज़ किया गया
- शो विकल्प
- लगातार लूप
- वर्णन के बिना शो
- एनीमेशन के बिना शो
- पेन रंग
- स्लाइड दिखाएँ
- कस्टम शो
- स्लाइड आगे बढ़ाएँ
- मैन्युअली
- टाइमिंग का उपयोग
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड शो को कैसे प्रबंधित करें, सीखें। PPT, PPTX और ODP फ़ॉर्मैट्स में स्लाइड ट्रांज़िशन, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों को तैयार करने और देने के लिये एक प्रमुख टूल हैं। इस खंड की सबसे महत्वपूर्ण सुविधाओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट परिस्थितियों और दर्शकों के अनुसार अनुकूलित करने की अनुमति देता है, जिससे लचीलापन और सुविधा सुनिश्चित होती है। इस फीचर के साथ, आप शो प्रकार चुन सकते हैं (जैसे, स्पीकर द्वारा प्रस्तुत, व्यक्तिगत द्वारा ब्राउज़ किया गया, या कियोस्क में ब्राउज़ किया गया), लूपिंग को सक्षम या अक्षम कर सकते हैं, प्रदर्शित करने के लिये विशिष्ट स्लाइड चुन सकते हैं, और टाइमिंग का उपयोग कर सकते हैं। इस तैयारी का कदम आपकी प्रस्तुति को अधिक प्रभावी और पेशेवर बनाने में महत्वपूर्ण है।

`get_SlideShowSettings` एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की मेथड है जो [SlideShowSettings](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slideshowsettings/) प्रकार का ऑब्जेक्ट लौटाती है, जिससे आप PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स को प्रबंधित कर सकते हैं। इस लेख में, हम इस मेथड का उपयोग करके स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कॉन्फ़िगर और नियंत्रित करना सीखेंगे। 

## **Show Type चुनें**

`SlideShowSettings.set_SlideShowType` स्लाइड शो का प्रकार परिभाषित करता है, जो निम्नलिखित क्लासों में से किसी एक का इंस्टेंस हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/cpp/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/cpp/aspose.slides/browsedatkiosk/). इस मेथड का उपयोग करके आप विभिन्न उपयोग परिदृश्यों, जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियों, के लिये प्रस्तुति को अनुकूलित कर सकते हैं।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो टाइप को "Browsed by an individual" पर सेट करता है, बिना स्क्रॉलबार दिखाए।

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Show Options सक्षम करें**

`SlideShowSettings.set_Loop` निर्धारित करता है कि स्लाइड शो मैन्युअल रूप से रुकाए जाने तक लूप में दोहराया जाए या नहीं। यह निरंतर चलने वाली स्वचालित प्रस्तुतियों के लिये उपयोगी है। `SlideShowSettings.set_ShowNarration` निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ीय वर्णन चलाए जाएँ या नहीं। यह दर्शकों के लिये आवाज़ी मार्गदर्शन वाली स्वचालित प्रस्तुतियों में उपयोगी है। `SlideShowSettings.set_ShowAnimation` निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़े गए एनिमेशन चलाए जाएँ या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने में सहायक है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **दिखाने के लिये स्लाइड चुनें**

`SlideShowSettings.set_Slides` मेथड आपको प्रस्तुति के दौरान प्रदर्शित होने वाली स्लाइडों की रेंज चुनने की अनुमति देता है। यह तब उपयोगी है जब आपको पूरी प्रस्तुति की बजाय केवल उसका कुछ हिस्सा दिखाना हो। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को `2` से `9` तक सेट करता है।

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड्स को अग्रे बढ़ाएँ**

`SlideShowSettings.set_UseTimings` मेथड आपको प्रत्येक स्लाइड के लिए पूर्व निर्धारित टाइमिंग के उपयोग को सक्षम या अक्षम करने की अनुमति देता है। यह पूर्वनिर्धारित प्रदर्शित अवधि के साथ स्वचालित रूप से स्लाइड्स दिखाने के लिये उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग के उपयोग को अक्षम करता है।

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Media Controls दिखाएँ**

`SlideShowSettings.set_ShowMediaControls` मेथड निर्धारित करता है कि मल्टीमीडिया सामग्री (जैसे वीडियो या ऑडियो) चलाए जाने पर स्लाइड शो के दौरान मीडिया कंट्रोल्स (जैसे play, pause, stop) दिखाए जाएँ या नहीं। यह तब उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया कंट्रोल्स को प्रदर्शित करने के लिये सक्षम करता है।

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**क्या मैं प्रस्तुति को इस प्रकार सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हाँ। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खुले पर सीधे स्लाइड शो मोड में लॉन्च होते हैं। Aspose.Slides में, निर्यात के दौरान उचित सहेजने वाले फ़ॉर्मेट का चयन करें [/slides/hi/cpp/save-presentation/](/slides/hi/cpp/save-presentation/)।

**क्या मैं व्यक्तिगत स्लाइड्स को शो से बाहर रख सकता हूँ बिना उन्हें फ़ाइल से हटाए?**

हाँ। स्लाइड को [hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/set_hidden/) के रूप में चिह्नित करें। छिपी हुई स्लाइड्स प्रस्तुति में बनी रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीँ।

**क्या Aspose.Slides स्लाइड शो चला सकता है या स्क्रीन पर लाइव प्रस्तुति नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषण और रूपांतरित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।