---
title: C++ में एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएँ
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/cpp/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएँ
- एनीमेशन प्रबंधित करें
- एनीमेशन नियंत्रित करें
- एनीमेशन इफ़ेक्ट
- PowerPoint एनीमेशन
- एनीमेशन टाइमलाइन
- इंटरैक्टिव एनीमेशन
- कस्टम एनीमेशन
- शेप एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड शेप
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में उन्नत एनीमेशन इफ़ेक्ट्स को जोड़ना और नियंत्रित करना सीखें ताकि गतिशील PowerPoint और OpenDocument प्रस्तुतियां बना सकें।"
---
## **परिचय**

चूँकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना है, इसलिए उन्हें बनाते समय उनका दृश्य रूप एवं इंटरैक्टिव व्यवहार हमेशा ध्यान में रखा जाता है।

**PowerPoint animation** दर्शकों के लिए प्रस्तुतियों को आकर्षक और मनोहारी बनाने के लिए एक महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for C++ PowerPoint प्रस्तुतियों में एनीमेशन जोड़ने के लिए विभिन्न विकल्प प्रदान करता है:

- शेप्स, चार्ट्स, टेबल्स, OLE ऑब्जेक्ट्स और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट लागू करें।
- एक शेप पर कई PowerPoint एनीमेशन इफ़ेक्ट उपयोग करें।
- एनीमेशन इफ़ेक्ट को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for C++ में विभिन्न एनीमेशन इफ़ेक्ट शेप्स पर लागू किए जा सकते हैं। स्लाइड पर मौजूद प्रत्येक तत्व, जैसे टेक्स्ट, चित्र, OLE ऑब्जेक्ट, टेबल आदि, को शेप माना जाता है, इसलिए हम स्लाइड के प्रत्येक तत्व पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation) **namespace** PowerPoint एनीमेशन के साथ काम करने के लिए क्लासेज़ प्रदान करता है।

## **एनीमेशन इफ़ेक्ट्स**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बाउंस, PathFootball, ज़ूम इफ़ेक्ट जैसे बुनियादी एनीमेशन इफ़ेक्ट्स और OLEObjectShow, OLEObjectOpen जैसे विशिष्ट एनीमेशन इफ़ेक्ट्स शामिल हैं। आप एनीमेशन इफ़ेक्ट्स की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को मिलाकर उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.set_effect)

## **कस्टम एनीमेशन**

Aspose.Slides में आप अपनी खुद की **कस्टम एनीमेशन** बना सकते हैं। यह तब प्राप्त किया जा सकता है जब आप कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट की निर्माण इकाई है। सभी एनीमेशन इफ़ेक्ट वास्तव में व्यवहारों का एक सेट होते हैं जो एक रणनीति में सम्मिलित होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में मिलाकर अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप एक नए व्यवहार को मानक PowerPoint एनीमेशन इफ़ेक्ट में जोड़ते हैं - वह एक और कस्टम एनीमेशन बन जाएगा। उदाहरण के तौर पर, आप एनीमेशन में रिपीट व्यवहार जोड़ सकते हैं जिससे वह कुछ बार दोहराया जा सके।

[**Animation Point**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.point) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**

[**Sequence**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.sequence) एक विशिष्ट शेप पर लागू एनीमेशन इफ़ेक्ट्स का संग्रह है।

[**AnimationTimeLine**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.animation_time_line) एक विशिष्ट स्लाइड में उपयोग किए जाने वाले Sequences का सेट है। यह PowerPoint 2002 से प्रस्तुत किया गया एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में एनीमेशन इफ़ेक्ट जोड़ना चुनौतीपूर्ण था, जिसे केवल विभिन्न वर्कअराउंड के द्वारा संभव था। टाइमलाइन ने पुराने AnimationSettings क्लास को प्रतिस्थापित किया और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[**EffectTriggerType**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने की अनुमति देता है, जिससे कोई विशेष एनीमेशन शुरू हो सके। ट्रिगर्स केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**

Aspose.Slides आपको शेप्स पर एनीमेशन लागू करने की अनुमति देता है, जो वास्तव में टेक्स्ट, आयत, रेखा, फ्रेम, OLE ऑब्जेक्ट आदि हो सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**शेप एनीमेशन के बारे में**](/slides/hi/cpp/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**

एनिमेटेड चार्ट बनाने के लिए, आपको शेप्स की तरह ही सभी क्लासेज़ का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर ही उपयोग किया जा सकता है। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/cpp/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू किया जा सकता है।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेट्ड टेक्स्ट के बारे में**](/slides/hi/cpp/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या एनीमेशन को PDF में एक्सपोर्ट करने पर संरक्षित रखा जाएगा?

नहीं। PDF एक स्थिर प्रारूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/cpp/slide-transition/) नहीं चलते। यदि आपको मोशन चाहिए, तो इसके बजाय [HTML5](/slides/hi/cpp/export-to-html5/), [animated GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/cpp/convert-powerpoint-to-video/) में एक्सपोर्ट करें।

### क्या मैं एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट व फ्रेम आकार को नियंत्रित कर सकता हूँ?

हां। आप [render the presentation as frames](/slides/hi/cpp/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (उदाहरण के लिए, ffmpeg के माध्यम से), जिसमें FPS और रिज़ॉल्यूशन चुन सकते हैं। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांजिशन चलाए जाते हैं।

### क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन अपने स्वरूप में बना रहेगा?

PPT, PPTX, और ODP को [reading](/slides/hi/cpp/open-presentation/) और [writing](/slides/hi/cpp/save-presentation/) के लिए समर्थित किया गया है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट्स थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। वास्तविक नमूनों के साथ महत्वपूर्ण मामलों को सत्यापित करें।