---
title: .NET में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/net/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- LaTeX में समीकरण निर्यात करें
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for .NET आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइडों पर (किसी विशिष्ट प्रस्तुति से) गणितीय समीकरणों को निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="info" %}} 
आप सीधे समीकरणों को LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग होने वाले गणितीय सामग्री के लिए एक लोकप्रिय मानक है।
{{% /alert %}}

## **गणितीय समीकरणों को LaTeX में निर्यात करें**

Aspose.Slides PowerPoint के गणितीय समीकरण को सीधे LaTeX में बदल सकता है; एक मध्यवर्ती MathML फ़ाइल या बाहरी कन्‍वर्टर की आवश्यकता नहीं होती। एक गणितीय समीकरण टेक्स्ट फ्रेम में एक [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) के रूप में संग्रहीत होता है। [MathPortion.MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/mathparagraph/) का उपयोग करके आप एक [IMathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathparagraph/) प्राप्त कर सकते हैं, और फिर [IMathParagraph.ToLatex](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। यह विधि एक स्ट्रिंग लौटाती है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रोसेस कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड के सभी टेक्स्ट फ्रेम की जाँच करता है, सभी गणितीय हिस्सों को खोजता है, और प्रत्येक समीकरण को अलग `.tex` फ़ाइल में लिखता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextboxes/) स्लाइड पर पाए गए सभी टेक्स्ट फ्रेम लौटाता है। [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) प्रकार की जाँच वास्तविक संपादन योग्य समीकरणों को सामान्य टेक्स्ट और छवियों से अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्पलेट सभी समान कमांड, पैकेज या यूनिकोड अक्षरों को समर्थन नहीं देते। लौटाई गई स्ट्रिंग को अपने अनुप्रयोग द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो उसे लौटाई गई स्ट्रिंग में प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को रिकॉर्ड करें।

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों के लिए कोड आसानी से लिख सकते हैं, वे MathML के कोड लिखने में कठिनाई महसूस करते हैं क्योंकि इसे स्वचालित रूप से एप्लिकेशन द्वारा उत्पन्न किया जाना चाहिए। प्रोग्राम MathML को आसानी से पढ़ और पार्स कर सकते हैं क्योंकि उसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में सामान्यतः उपयोग किया जाता है।

यह नमूना कोड आपको दिखाता है कि प्रस्तुति से एक गणितीय समीकरण को MathML में कैसे निर्यात करें:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में वास्तव में क्या निर्यात होता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**  
आप एक संपूर्ण गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/)) या एक व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक मेथड प्रदान करते हैं।

**स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या छवि के बजाय गणितीय सूत्र है, यह कैसे पता करें?**  
एक सूत्र एक [MathPortion](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides.mathtext/mathparagraph/) होता है। जिन छवियों और सामान्य टेक्स्ट हिस्सों में [MathParagraph] नहीं होता, वे निर्यात योग्य सूत्र नहीं होते।

**प्रस्तुति में MathML कहाँ से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।

**टेबल, SmartArt, समूह आदि के भीतर सूत्रों का निर्यात समर्थित है क्या?**  
हां, यदि उन वस्तुओं में [MathParagraph] (अर्थात वास्तविक PowerPoint सूत्र) वाले टेक्स्ट हिस्से हैं, तो उन्हें निर्यात किया जाता है। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं किया जाता।

**क्या MathML में निर्यात करना मूल प्रस्तुति को संशोधित करता है?**  
नहीं। MathML लिखना सूत्र की सामग्री का क्रमबद्धकरण है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।