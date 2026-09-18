---
title: JavaScript में एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/nodejs-java/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएँ
- एनीमेशन प्रबंधित करें
- एनीमेशन नियंत्रित करें
- एनीमेशन प्रभाव
- PowerPoint एनीमेशन
- एनीमेशन टाइमलाइन
- इंटरैक्टिव एनीमेशन
- कस्टम एनीमेशन
- आकार एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड आकार
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड चित्र
- एनिमेटेड तालिका
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint एनीमेशन को संभालने के लिए Node.js के लिए Aspose.Slides via Java का उपयोग करें। यह अवलोकन प्रमुख सुविधाओं को उजागर करता है और आपके प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना होता है, इसलिए निर्माण के दौरान उनकी दृश्य उपस्थिति और इंटरैक्टिव व्यवहार हमेशा ध्यान में रखे जाते हैं।

**PowerPoint animation** प्रस्तुति को दर्शकों के लिए आकर्षक और संलग्न बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Node.js via Java PowerPoint प्रस्तुतियों में एनीमेशन जोड़ने के लिए व्यापक विकल्प प्रदान करता है:

- आकार, चार्ट, तालिकाएँ, OLE ऑब्जेक्ट और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन प्रभाव लागू करें।
- एक ही आकार पर कई PowerPoint एनीमेशन प्रभावों का उपयोग करें।
- एनीमेशन प्रभावों को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Node.js via Java में विभिन्न एनीमेशन प्रभाव आकारों पर लागू किए जा सकते हैं। चूंकि स्लाइड पर प्रत्येक तत्व, जिसमें पाठ, चित्र, OLE ऑब्जेक्ट और तालिकाएँ शामिल हैं, को आकार माना जाता है, इसलिए एनीमेशन प्रभाव स्लाइड के किसी भी तत्व पर लागू किए जा सकते हैं।

## **एनीमेशन प्रभाव**
Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें बाउंस, PathFootball और ज़ूम जैसे बुनियादी प्रभाव और OLEObjectShow और OLEObjectOpen जैसे विशिष्ट प्रभाव शामिल हैं। आप पूर्ण सूची [EffectType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttype/) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन प्रभावों को निम्नलिखित व्यवहारों के साथ संयोजन में उपयोग किया जा सकता है:
- [रंग प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ColorEffect)
- [कमांड प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommandEffect)
- [फ़िल्टर प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FilterEffect)
- [मूवमेंट प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MotionEffect)
- [प्रॉपर्टी प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PropertyEffect)
- [रोटेशन प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/RotationEffect)
- [स्केल प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ScaleEffect)
- [सेट प्रभाव](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SetEffect)

## **कस्टम एनीमेशन**
पूरे JavaScript उदाहरणों के लिए जो व्यवहार और संपादन योग्य मोशन पाथ बनाते, निरीक्षण करते और संशोधित करते हैं, देखें [कस्टम एनीमेशन](/slides/hi/nodejs-java/custom-animation/)।

Aspose.Slides में आप अपने स्वयं के **कस्टम एनीमेशन** बना सकते हैं। यह कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाकर प्राप्त किया जा सकता है।

[Behavior](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behavior/) PowerPoint एनीमेशन प्रभाव का निर्माण ब्लॉक है। प्रभाव को अनुकूलित करने के लिए व्यवहारों को मिलाएँ, या पूर्वनिर्धारित प्रभाव को विस्तारित करने के लिए एक व्यवहार जोड़ें। पुनरावृत्ति को अलग-अलग पुनरावृत्ति व्यवहार के बजाय टाइमिंग सेटिंग्स के माध्यम से कॉन्फ़िगर किया जाता है।

[Animation Point](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/point/) वह बिंदु है जहाँ एक व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**
[Sequence](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/) विभिन्न आकारों को लक्षित करने वाले एनीमेशन प्रभावों का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/animationtimeline/) एक विशिष्ट स्लाइड में उपयोग किए जाने वाले क्रमों का सेट है। यह PowerPoint 2002 में प्रस्तुत किया गया एनीमेशन इंजन है। PowerPoint के पहले संस्करणों में प्रस्तुतियों में एनीमेशन प्रभाव जोड़ना चुनौतीपूर्ण था और केवल विभिन्न वर्कअराउंड के माध्यम से संभव था। टाइमलाइन PowerPoint एनीमेशन के लिए एक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करती है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरेक्टिव एनीमेशन**
[Trigger](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttriggertype/) आपको उपयोगकर्ता क्रियाओं को परिभाषित करने की अनुमति देता है, जैसे बटन क्लिक, जो किसी विशिष्ट एनीमेशन को प्रारंभ करता है।

## **आकार एनीमेशन**
Aspose.Slides आपको आकारों पर एनीमेशन लागू करने की सुविधा देता है, जिसमें पाठ, आयत, रेखाएँ, फ्रेम, OLE ऑब्जेक्ट और अधिक शामिल हो सकते हैं।

{{% alert color="info" title="Note" %}}
अधिक पढ़ें [**आकार एनीमेशन के बारे में**](/slides/hi/nodejs-java/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट**
एनिमेटेड चार्ट बनाने के लिए, आपको आकारों के समान कक्षाओं का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर लागू किए जा सकते हैं। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="info" title="Note" %}}
अधिक पढ़ें [**एनिमेटेड चार्ट के बारे में**](/slides/hi/nodejs-java/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**
टेक्स्ट को एनीमेट करने के अलावा, आप पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="info" title="Note" %}}
अधिक पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/nodejs-java/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PDF में निर्यात करते समय एनीमेशन संरक्षित रहेंगे?**

नहीं। PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और [स्लाइड ट्रांज़िशन](/slides/hi/nodejs-java/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/nodejs-java/export-to-html5/), [एनिमेटेड GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/), या [वीडियो](/slides/hi/nodejs-java/convert-powerpoint-to-video/) में निर्यात करें।

**क्या मैं एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट एवं फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हाँ। आप [प्रस्तुति को फ्रेम के रूप में रेंडर](/slides/hi/nodejs-java/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (उदाहरण के लिए, ffmpeg द्वारा), FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन बरकरार रहेंगे?**

PPT, PPTX, और ODP को [पढ़ने](/slides/hi/nodejs-java/open-presentation/) और [लिखने](/slides/hi/nodejs-java/save-presentation/) के लिए समर्थन है, लेकिन यह एनीमेशन संरक्षण की गारंटी नहीं देता। ODP में रूपांतरण करते समय कस्टम एनीमेशन डेटा खो सकता है। उदाहरणों और फ़ॉर्मेट संगतता की जाँच के मार्गदर्शन के लिए [कस्टम एनीमेशन](/slides/hi/nodejs-java/custom-animation/) देखें।