---
title: "C++ में PowerPoint टेक्स्ट को एनीमेट करें"
linktitle: "एनिमेटेड टेक्स्ट"
type: docs
weight: 60
url: /hi/cpp/animated-text/
keywords:
- "एनिमेटेड टेक्स्ट"
- "टेक्स्ट एनीमेशन"
- "एनिमेटेड पैराग्राफ"
- "पैराग्राफ एनीमेशन"
- "एनीमेशन इफ़ेक्ट"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान‑से‑अनुशरणीय और अनुकूलित C++ कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में एनीमेटेड टेक्स्ट के साथ काम करने के तरीके को समझाता है, जिसमें व्यक्तिगत पैराग्राफ़ पर एनिमेशन इफ़ेक्ट लागू किए जाते हैं और टेक्स्ट फ्रेम में पैराग्राफ़ को पहले से सौंपे गए इफ़ेक्ट प्राप्त किए जाते हैं। यह प्रस्तुति में पैराग्राफ‑स्तरीय एनिमेशन जोड़ने और मौजूदा पैराग्राफ एनिमेशन इफ़ेक्ट की जाँच के लिए उपयोग किए जाने वाले API मेथड्स पर केंद्रित है।

## **पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ें**

हमने [**AddEffect()**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.sequence) और [**ISequence**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.i_sequence) क्लासेज़ में जोड़ा है। यह मेथड आपको एकल पैराग्राफ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह सैंपल कोड आपको दिखाता है कि कैसे एक पैराग्राफ में एनीमेशन इफ़ेक्ट जोड़ा जाए:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// इफ़ेक्ट जोड़ने के लिए पैराग्राफ़ चुनें
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// चुने हुए पैराग्राफ़ में Fly एनीमेशन इफ़ेक्ट जोड़ें
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **पैराग्राफ़ के लिए एनीमेशन इफ़ेक्ट प्राप्त करें**

आप इस बात का पता लगाना चाह सकते हैं कि किसी पैराग्राफ़ में कौन से एनीमेशन इफ़ेक्ट जोड़े गए हैं, उदाहरण के लिए, एक स्थिति में आप पैराग्राफ़ में एनीमेशन इफ़ेक्ट प्राप्त करना चाहते हैं क्योंकि आप उन इफ़ेक्ट को दूसरे पैराग्राफ़ या शेप पर लागू करने की योजना बना रहे हैं।

Aspose.Slides for C++ आपको टेक्स्ट फ्रेम (शेप) में मौजूद पैराग्राफ़ पर लागू सभी एनीमेशन इफ़ेक्ट प्राप्त करने की सुविधा देता है। यह सैंपल कोड आपको दिखाता है कि कैसे एक पैराग्राफ़ में एनीमेशन इफ़ेक्ट प्राप्त किए जाएं:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग हैं, और क्या उन्हें मिलाया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर ऑब्जेक्ट के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [ट्रांज़िशन](/slides/hi/cpp/slide-transition/) स्लाइड के परिवर्तन को नियंत्रित करते हैं। वे स्वतंत्र होते हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन को PDF या इमेजेज़ में एक्सपोर्ट करने पर बनाए रखा जाता है?**

नहीं। PDF और रास्टर इमेजेज़ स्थिर होते हैं, इसलिए आप स्लाइड की एक ही स्थिति बिना गति के देखेंगे। गति बनाए रखने के लिए, [वीडियो](/slides/hi/cpp/convert-powerpoint-to-video/) या [HTML](/slides/hi/cpp/export-to-html5/) एक्सपोर्ट का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट्स और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू इफ़ेक्ट स्लाइड्स द्वारा विरासत में मिलते हैं, लेकिन उनका समय निर्धारण और स्लाइड-लेवल एनीमेशन के साथ इंटरैक्शन अंततः स्लाइड पर मौजूद अंतिम क्रम पर निर्भर करता है।