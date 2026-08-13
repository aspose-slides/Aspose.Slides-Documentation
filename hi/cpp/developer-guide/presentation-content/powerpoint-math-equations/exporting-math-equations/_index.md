---
title: C++ में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/cpp/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- समीकरणों को LaTeX में निर्यात करें
- PowerPoint को LaTeX में
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे LaTeX या MathML में Aspose.Slides for C++ के साथ निर्यात करें।"
---
## **परिचय**

Aspose.Slides for C++ आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको किसी विशेष प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरणों को निकालना और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करना पड़ सकता है। 

{{% alert color="info" %}} 
आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग किया जाने वाला गणितीय सामग्री का एक लोकप्रिय मानक है। 
{{% /alert %}}

## **LaTeX में गणितीय समीकरण निर्यात करें**

Aspose.Slides एक PowerPoint गणितीय समीकरण को सीधे LaTeX में परिवर्तित कर सकता है; मध्यवर्ती MathML फ़ाइल और बाहरी परिवर्तक की आवश्यकता नहीं होती। एक गणितीय समीकरण को टेक्स्ट फ़्रेम में एक [IMathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/) के रूप में संग्रहित किया जाता है। एक [IMathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/) प्राप्त करने के लिए [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) का उपयोग करें, और फिर [IMathParagraph::ToLatex](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। यह विधि एक स्ट्रिंग लौटाती है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रक्रिया कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड पर सभी टेक्स्ट फ़्रेम का परीक्षण करता है, सभी गणितीय भागों को खोजता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextboxes/) एक स्लाइड पर पाए गए सभी टेक्स्ट फ़्रेम को लौटाता है। [IMathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/) प्रकार जांच वास्तविक संपादन योग्य समीकरणों को सामान्य टेक्स्ट और चित्रों से अलग करती है।

सभी LaTeX इंजन और दस्तावेज़ टेम्पलेट एक ही कमांड, पैकेज या Unicode अक्षरों का समर्थन नहीं करते। अपने अनुप्रयोग द्वारा उपयोग किए गए LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो उसे लौटाई गई स्ट्रिंग में प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा हेतु समस्या को दर्ज करें।

## **MathML के रूप में गणितीय समीकरण सहेजें**

जबकि मनुष्य कुछ समीकरण स्वरूपों जैसे LaTeX के लिए कोड आसानी से लिख सकते हैं, वे MathML के कोड को लिखने में कठिनाई महसूस करते हैं क्योंकि यह बाद वाला कोड एप्लिकेशनों द्वारा स्वतः उत्पन्न किया जाना है। प्रोग्राम MathML को आसानी से पढ़ और पार्स कर सकते हैं क्योंकि इसका कोड XML में होता है, इसलिए कई क्षेत्रों में MathML अक्सर आउटपुट और प्रिंटिंग स्वरूप के रूप में उपयोग किया जाता है। 

यह नमूना कोड आपको दिखाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात करें:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत फ़ॉर्मूला ब्लॉक?**  
आप MathML में निर्यात करने के लिए या तो पूरी गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathblock/)) निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की एक विधि प्रदान करते हैं।

**मैं कैसे पहचान सकता हूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या छवि के बजाय गणितीय फ़ॉर्मूला है?**  
एक फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathportion/) में स्थित होता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) होता है। बिना [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) वाले चित्र और सामान्य टेक्स्ट भाग निर्यात योग्य फ़ॉर्मूला नहीं होते।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या कोई मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose Presentation MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो कई अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर के फ़ॉर्मूले निर्यात समर्थित हैं?**  
हाँ, यदि उन वस्तुओं में [MathParagraph] वाले टेक्स्ट भाग शामिल हैं (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात किए जाते हैं। यदि कोई फ़ॉर्मूला चित्र के रूप में एम्बेड किया गया है, तो वह नहीं निर्यात होगा।

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**  
नहीं। MathML लिखना फ़ॉर्मूला की सामग्री का एक क्रमबद्धन है; यह मूल प्रस्तुति फ़ाइल को नहीं बदलता।