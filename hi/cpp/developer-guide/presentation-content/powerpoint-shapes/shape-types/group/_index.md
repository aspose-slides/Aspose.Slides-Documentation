---
title: C++ में समूह प्रस्तुति आकार
linktitle: शेप ग्रुप
type: docs
weight: 40
url: /hi/cpp/group/
keywords:
- ग्रुप आकार
- आकार समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint डेक में शैप्स को समूहित और अलग करने के लिए सीखें — तेज़, चरण-दर-चरण मार्गदर्शिका मुफ्त C++ कोड के साथ।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides में समूह आकार (group shapes) के साथ कैसे काम किया जाए। यह दिखाता है कि एक स्लाइड में समूह आकार कैसे जोड़ा जाए, उसके अंदर आकार (shapes) कैसे रखे जाएँ, और अद्यतन प्रस्तुति को कैसे सहेजा जाए। यह यह भी दर्शाता है कि समूह के अंदर संग्रहीत आकारों तक कैसे पहुंचा जाए और उनके `AlternativeText` मानों को पढ़ा जाए। साथ ही, यह लेख नेस्टेड समूह, z‑order, और लॉकिंग विकल्प जैसी संबंधित समूह‑आकार क्षमताओं का संक्षिप्त परिचय देता है।

## **समूह आकार जोड़ें**
Aspose.Slides स्लाइडों पर समूह आकारों के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रस्तुतियाँ बनाने में मदद करती है। Aspose.Slides for C++ समूह आकार जोड़ने या उन तक पहुँचने का समर्थन करता है। जोड़े गए समूह आकार में आकार जोड़कर इसे भरना या समूह आकार की किसी भी संपत्ति तक पहुँच प्राप्त करना संभव है। Aspose.Slides for C++ का उपयोग करके किसी स्लाइड में समूह आकार जोड़ने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक समूह आकार जोड़ें।
1. जोड़े गए समूह आकार में आकार जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में एक समूह आकार जोड़ता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **AltText संपत्ति तक पहुँचें**
यह विषय समूह आकार जोड़ने और स्लाइडों पर समूह आकारों की AltText संपत्ति तक पहुँचने के लिए कोड उदाहरणों सहित सरल चरणों को दिखाता है। Aspose.Slides for C++ का उपयोग करके स्लाइड में समूह आकार की AltText तक पहुँचने के चरण इस प्रकार हैं:

1. `Presentation` क्लास का एक उदाहरण बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
1. उसके Index का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइडों के shape संग्रह तक पहुँचें।
1. समूह आकार तक पहुँचें।
1. AltText संपत्ति तक पहुँचें।

नीचे दिया गया उदाहरण समूह आकार के वैकल्पिक पाठ (alternative text) तक पहुँचता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या नेस्टेड ग्रुपिंग (एक समूह के भीतर दूसरा समूह) समर्थित है?**

हाँ। [GroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/groupshape/) में एक [get_ParentGroup](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_parentgroup/) मेथड है, जो सीधे पदानुक्रम समर्थन दर्शाता है (एक समूह दूसरे समूह का बच्चा हो सकता है)।

**मैं स्लाइड पर अन्य वस्तुओं की तुलना में समूह के z‑order को कैसे नियंत्रित करूँ?**

[GroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/groupshape/) की [Z-Order position](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/get_zorderposition/) का उपयोग करके उसकी प्रदर्शनी स्टैक में स्थिति को जांचें।

**क्या मैं समूह को चलने/संपादित करने/समूह‑विच्छेद (ungrouping) से रोक सकता हूँ?**

हाँ। समूह की लॉक सेक्शन [get_GroupShapeLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/groupshape/get_groupshapelock/) के द्वारा उजागर की गई है, जिससे आप ऑब्जेक्ट पर संचालन को प्रतिबंधित कर सकते हैं।