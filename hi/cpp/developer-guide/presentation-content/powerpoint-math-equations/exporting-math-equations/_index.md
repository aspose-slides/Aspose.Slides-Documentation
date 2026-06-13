---
title: प्रस्तुतीकरण से С++ में गणितीय समीकरणों का निर्यात
linktitle: समीकरण निर्यात
type: docs
weight: 30
url: /hi/cpp/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- MathML
- LaTeX
- PowerPoint
- प्रस्तुतीकरण
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात करें — फॉर्मेटिंग को बनाए रखें और संगतता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for C++ आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको किसी विशिष्ट प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरणों को निकालकर किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करना पड़ सकता है।

{{% alert color="primary" %}} 

आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में देखे जाने वाले गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय प्रारूप या मानक है। 

{{% /alert %}}

## **Math समीकरणों को MathML के रूप में सहेजें**

मानव आसानी से कुछ समीकरण प्रारूपों जैसे LaTeX के लिए कोड लिखते हैं, लेकिन MathML का कोड लिखने में कठिनाई महसूस करते हैं क्योंकि यह बाद वाला स्वचालित रूप से एप्लिकेशन द्वारा उत्पन्न किया जाना चाहिए। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग प्रारूप के रूप में आमतौर पर उपयोग किया जाता है। 

यह नमूना कोड दिखाता है कि कैसे प्रस्तुति से एक गणितीय समीकरण को MathML में निर्यात किया जाए:

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

**वास्तव में MathML में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत फ़ॉर्मूला ब्लॉक?**

आप पूरी गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की विधि प्रदान करते हैं।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या इमेज के बजाय एक गणितीय फ़ॉर्मूला है?**

फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathportion/) में रहता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) होता है। जिन इमेजों और सामान्य टेक्स्ट हिस्सों में [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) नहीं होता, वे निर्यात योग्य फ़ॉर्मूला नहीं होते।

**प्रस्तुति में MathML कहाँ से आता है—क्या यह PowerPoint‑विशिष्ट है या कोई मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML का उपयोग करता है—मानक का प्रस्तुति उपसमुच्चय—जो विभिन्न अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।

**टेबल, SmartArt, समूह आदि के भीतर फ़ॉर्मूले निर्यात करने का समर्थन है क्या?**

हाँ, यदि उन वस्तुओं में ऐसे टेक्स्ट हिस्से हैं जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.mathtext/mathparagraph/) शामिल है (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात होते हैं। यदि फ़ॉर्मूला एक इमेज के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**MathML में निर्यात करने से मूल प्रस्तुति में परिवर्तन होता है क्या?**

नहीं। MathML लिखना फ़ॉर्मूले की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल में कोई परिवर्तन नहीं करता।