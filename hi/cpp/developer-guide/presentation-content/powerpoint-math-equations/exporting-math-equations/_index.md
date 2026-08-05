---
title: प्रस्तुतियों से गणितीय समीकरण निर्यात करें C++ में
linktitle: निर्यात समीकरण
type: docs
weight: 30
url: /hi/cpp/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात खोलें — स्वरूपण को बनाए रखें और संगतता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for C++ आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइडों (किसी विशिष्ट प्रस्तुति से) पर गणितीय समीकरण निकालने और उन्हें किसी अन्य कार्यक्रम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में देखी जाने वाली गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय स्वरूप या मानक है। 
{{% /alert %}}

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों के लिए कोड आसानी से लिख सकते हैं, वे MathML के लिए कोड लिखने में कठिनाई महसूस करते हैं क्योंकि यह बाद वाला ऐप्स द्वारा स्वचालित रूप से जनरेट किया जाना चाहता है। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में सामान्यतः उपयोग किया जाता है। 

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

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत फ़ॉर्मूला ब्लॉक?**  
आप या तो पूरे गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की विधि प्रदान करते हैं।  

**मैं कैसे पहचान सकता हूँ कि स्लाइड पर कोई वस्तु गणितीय फ़ॉर्मूला है या सामान्य पाठ या छवि?**  
फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathportion/) में स्थित होता है और उसमें एक [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) होता है। उन छवियों और सामान्य पाठ भागों जिनके पास [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) नहीं है, निर्यात योग्य फ़ॉर्मूले नहीं होते।  

**प्रस्तुति में MathML कहां से आता है—क्या यह केवल PowerPoint-विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।  

**क्या टेबल, SmartArt, समूह आदि के भीतर फ़ॉर्मूले निर्यात करना समर्थित है?**  
हां, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) वाले पाठ भाग होते हैं (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात किए जाते हैं। यदि कोई फ़ॉर्मूला छवि के रूप में एम्बेड किया गया है, तो वह नहीं।  

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**  
नहीं। MathML लिखना फ़ॉर्मूले की सामग्री का क्रमबद्धन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।