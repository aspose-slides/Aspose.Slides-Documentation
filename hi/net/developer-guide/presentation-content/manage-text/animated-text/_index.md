---
title: .NET में PowerPoint टेक्स्ट को एनीमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/net/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रेज़ेंटेशन में गतिशील एनीमेटेड टेक्स्ट बनाएँ, आसान‑से‑फ़ॉलो, अनुकूलित C# कोड उदाहरणों के साथ।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides में एनिमेटेड टेक्स्ट के साथ कैसे काम करें, व्यक्तिगत पैराग्राफ पर एनीमेशन इफ़ेक्ट्स लागू करके और टेक्स्ट फ़्रेम में पैराग्राफ को पहले से असाइन किए गए इफ़ेक्ट्स को पुनः प्राप्त करके। यह प्रस्तुति में पैराग्राफ‑स्तरीय एनीमेशन जोड़ने और मौजूदा पैराग्राफ एनीमेशन इफ़ेक्ट्स की जांच करने के लिये उपयोग किए जाने वाले API मेथड्स पर केंद्रित है।

## **पैराग्राफ़ में एनीमेशन इफ़ेक्ट्स जोड़ें**

हमने [**AddEffect()**](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/sequence/methods/addeffect/index) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/sequence) और [**ISequence**](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence) क्लासेज़ में जोड़ा है। यह मेथड आपको एक एकल पैराग्राफ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह सैंपल कोड दिखाता है कि एक पैराग्राफ में एनीमेशन इफ़ेक्ट कैसे जोड़ें:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // पैराग्राफ़ चुनें ताकि इफ़ेक्ट जोड़ा जा सके
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // चयनित पैराग्राफ़ में Fly एनीमेशन इफ़ेक्ट जोड़ें
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **पैराग्राफ़ के लिए एनीमेशन इफ़ेक्ट प्राप्त करें**

आप यह जानने का निर्णय ले सकते हैं कि किसी पैराग्राफ में कौन से एनीमेशन इफ़ेक्ट्स जोड़े गए हैं—उदाहरण के लिए, एक स्थिति में, आप एक पैराग्राफ में एनीमेशन इफ़ेक्ट्स प्राप्त करना चाहते हैं क्योंकि आप उन इफ़ेक्ट्स को किसी अन्य पैराग्राफ या शैप में लागू करने की योजना बना रहे हैं।

Aspose.Slides for .NET आपको टेक्स्ट फ़्रेम (शैप) में मौजूद पैराग्राफ़ पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त करने की अनुमति देता है। यह सैंपल कोड दर्शाता है कि एक पैराग्राफ में एनीमेशन इफ़ेक्ट्स कैसे प्राप्त करें:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**पाठ एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग होते हैं, और क्या उन्हें मिलाकर उपयोग किया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर समय के साथ ऑब्जेक्ट के व्यवहार को नियंत्रित करते हैं, जबकि [transitions](/slides/hi/net/slide-transition/) स्लाइड के परिवर्तन को नियंत्रित करते हैं। वे स्वतंत्र होते हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन PDF या इमेजेज़ में निर्यात करने पर बरकरार रहते हैं?**

नहीं। PDF और रास्टर इमेजेज़ स्थैतिक होती हैं, इसलिए आपको स्लाइड की एक ही अवस्था में मोशन के बिना दिखाई देगी। गति को बनाए रखने के लिए, [video](/slides/hi/net/convert-powerpoint-to-video/) या [HTML](/slides/hi/net/export-to-html5/) निर्यात का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू इफ़ेक्ट्स स्लाइड्स द्वारा विरासत में मिलते हैं, लेकिन उनके टाइमिंग और स्लाइड‑स्तरीय एनीमेशन के साथ इंटरैक्शन स्लाइड पर अंतिम क्रम पर निर्भर करता है।