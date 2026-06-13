---
title: प्रस्तुतियों से पाइथन में गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/python-net/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात सक्षम करें—फ़ॉर्मेटिंग को सुरक्षित रखें और संगतता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको विशिष्ट स्लाइड्स से समीकरण निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में पुन: उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}}
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में गणितीय सामग्री को प्रदर्शित करने के लिए व्यापक रूप से प्रयुक्त मानक है।
{{% /alert %}}

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

हालाँकि मनुष्य आसानी से LaTeX लिख सकते हैं, लेकिन MathML आमतौर पर अनुप्रयोगों द्वारा स्वचालित रूप से उत्पन्न किया जाता है। क्योंकि MathML XML-आधारित है, कार्यक्रम इसे विश्वसनीय रूप से पढ़ और पार्स कर सकते हैं, इसलिए यह कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में व्यापक रूप से उपयोग किया जाता है।

निम्नलिखित नमूना कोड दर्शाता है कि प्रस्तुतिकरण से एक गणितीय समीकरण को MathML में कैसे निर्यात किया जाता है:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या व्यक्तिगत फ़ॉर्मूला ब्लॉक?**  
आप पूरे गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक विधि प्रदान करते हैं।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई ऑब्जेक्ट सामान्य टेक्स्ट या छवि के बजाय गणितीय फ़ॉर्मूला है?**  
एक फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/) में स्थित होता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) होता है। उन छवियों और सामान्य टेक्स्ट भागों में जो [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) नहीं रखते, फ़ॉर्मूला निर्यात योग्य नहीं होते।

**प्रस्तुति में MathML किससे आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर फ़ॉर्मूला निर्यात का समर्थन किया जाता है?**  
हां, यदि उन ऑब्जेक्ट्स में [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) के साथ टेक्स्ट भाग होते हैं (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात किए जाते हैं। यदि फ़ॉर्मूला एक छवि के रूप में एम्बेड किया गया है, तो नहीं।

**क्या MathML में निर्यात मूल प्रस्तुति को संशोधित करता है?**  
नहीं। MathML लिखना फ़ॉर्मूला की सामग्री का क्रमबद्धीकरण है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।