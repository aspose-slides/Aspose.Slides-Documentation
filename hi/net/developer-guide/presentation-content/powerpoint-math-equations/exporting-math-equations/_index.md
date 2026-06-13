---
title: .NET में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात
type: docs
weight: 30
url: /hi/net/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात करें—फ़ॉर्मेटिंग को संरक्षित रखें और अनुकूलता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for .NET आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स पर (एक विशिष्ट प्रस्तुति से) गणितीय समीकरण निकालने और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है। 

{{% alert color="primary" %}} 
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब पर और कई अनुप्रयोगों में देखी जाने वाली गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय स्वरूप या मानक है। 
{{% /alert %}}

## **MathML के रूप में गणितीय समीकरणों को सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों के लिए कोड आसानी से लिखते हैं, वे MathML के लिए कोड लिखने में संघर्ष करते हैं क्योंकि यह बाद वाला ऐप्स द्वारा स्वचालित रूप से उत्पन्न किए जाने के लिए बनाया गया है। प्रोग्राम्स MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में आमतौर पर उपयोग किया जाता है। 

यह नमूना कोड दिखाता है कि प्रस्तुति से एक गणितीय समीकरण को MathML में कैसे निर्यात किया जाए:
```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**MathML में ठीक‑ठीक क्या निर्यात होता है — एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप या तो पूरी गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/)) या एक व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की विधि प्रदान करते हैं।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई ऑब्जेक्ट सामान्य टेक्स्ट या छवि के बजाय गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) में स्थित होता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/) होता है। बिना [MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/) के छवियां और सामान्य टेक्स्ट हिस्से निर्यात योग्य सूत्र नहीं होते हैं।

**प्रस्तुति में MathML कहां से आता है — क्या यह PowerPoint‑विशिष्ट है या मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**टेबल, SmartArt, समूह आदि के भीतर सूत्रों का निर्यात समर्थित है क्या?**

हां, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/) वाले टेक्स्ट भाग होते हैं (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात होते हैं। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**MathML में निर्यात करने से मूल प्रस्तुति में परिवर्तन होता है क्या?**

नहीं। MathML लिखना सूत्र की सामग्री का क्रमबद्ध निरूपण है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।