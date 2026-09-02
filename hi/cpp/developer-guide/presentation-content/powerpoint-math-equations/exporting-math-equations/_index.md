---
title: प्रस्तुतियों से C++ में गणितीय समीकरण निर्यात
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/cpp/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- समीकरणों को LaTeX में निर्यात
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे Aspose.Slides for C++ के साथ LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for C++ आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की सुविधा देता है। उदाहरण के रूप में, आपको विशिष्ट प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरण निकालने और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 

आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग किए जाने वाला एक लोकप्रिय मानक है।

{{% /alert %}}

## **LaTeX में गणितीय समीकरण निर्यात करें**

Aspose.Slides सीधे PowerPoint गणितीय समीकरण को LaTeX में बदल सकता है; एक मध्यवर्ती MathML फ़ाइल और बाहरी कनवर्टर की आवश्यकता नहीं है। एक गणितीय समीकरण को टेक्स्ट फ़्रेम में एक [IMathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/) के रूप में संग्रहित किया जाता है। एक [IMathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/) प्राप्त करने के लिए [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) का उपयोग करें, और फिर [IMathParagraph::ToLatex](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) को कॉल करें। यह विधि एक स्ट्रिंग लौटाती है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य एप्लीकेशन को भेज सकते हैं, या आगे प्रोसेस कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड पर सभी टेक्स्ट फ़्रेम की जांच करता है, सभी गणितीय हिस्सों को ढूँढता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextboxes/) स्लाइड पर पाए गए सभी टेक्स्ट फ़्रेम लौटाता है। [IMathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/imathportion/) प्रकार की जाँच सामान्य टेक्स्ट और छवियों से वास्तविक संपादन योग्य समीकरणों को अलग करती है।

LaTeX इंजन और डॉक्यूमेंट टेम्पलेट सभी एक ही कमांड, पैकेज या यूनिकोड कैरेक्टर को समर्थन नहीं देते हैं। लौटाई गई स्ट्रिंग को अपने एप्लिकेशन द्वारा प्रयुक्त LaTeX इंजन के साथ परीक्षण करें। यदि किसी चिन्ह या Office Math तत्व का उस पर्यावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो उसे लौटाई गई स्ट्रिंग में प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को रिकॉर्ड करें।

## **MathML के रूप में गणितीय समीकरण सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों का कोड आसानी से लिख सकते हैं, वे MathML का कोड लिखने में कठिनाई महसूस करते हैं क्योंकि यह अंततः ऐप्स द्वारा स्वचालित रूप से उत्पन्न किया जाता है। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में सामान्यतः उपयोग किया जाता है।

यह नमूना कोड दर्शाता है कि कैसे एक प्रस्तुति से गणितीय समीकरण को MathML में निर्यात किया जाए:

``` cpp
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

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या व्यक्तिगत फॉर्मूला ब्लॉक?**

आप MathML में पूरी गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathblock/)) दोनों निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की एक विधि प्रदान करते हैं।

**मैं कैसे पता करूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या छवि के बजाय गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathportion/) में स्थित होता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) होता है। बिना [MathParagraph] वाले चित्र और सामान्य टेक्स्ट हिस्से निर्यात योग्य सूत्र नहीं होते हैं।

**प्रस्तुति में MathML कहाँ से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से प्रयुक्त होता है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर सूत्रों का निर्यात समर्थित है?**

हाँ, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) वाले टेक्स्ट हिस्से हों (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात होते हैं। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**

नहीं। MathML लिखना सूत्र की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को बदलता नहीं है।