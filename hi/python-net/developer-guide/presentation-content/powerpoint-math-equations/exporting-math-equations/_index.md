---
title: "पाइथन में प्रस्तुतियों से गणितीय समीकरण निर्यात"
linktitle: "समीकरण निर्यात"
type: docs
weight: 30
url: /hi/python-net/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- समीकरणों को LaTeX में निर्यात
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे Aspose.Slides for Python via .NET के साथ LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की सुविधा देता है। उदाहरण के तौर पर, आपको विशिष्ट स्लाइडों से समीकरण निकालने और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में पुन: उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}}
आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग किए जाने वाले गणितीय सामग्री के लिए एक लोकप्रिय मानक है।
{{% /alert %}}

## **गणितीय समीकरणों को LaTeX में निर्यात करें**

Aspose.Slides PowerPoint गणितीय समीकरण को सीधे LaTeX में बदल सकता है; मध्यवर्ती MathML फ़ाइल और बाहरी रूपांतरणकर्ता आवश्यक नहीं हैं। एक गणितीय समीकरण टेक्स्ट फ्रेम में एक [MathPortion](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/) के रूप में संग्रहीत होता है। [MathPortion.math_paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) का उपयोग करके आप एक [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) प्राप्त करते हैं, और फिर [MathParagraph.to_latex](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) को कॉल करते हैं। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रोसेस कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड पर सभी टेक्स्ट फ्रेम की जाँच करता है, सभी गणितीय भागों को खोजता है, और प्रत्येक समीकरण को अलग `.tex` फ़ाइल में लिखता है:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) एक स्लाइड पर मिलने वाले सभी टेक्स्ट फ्रेम लौटाता है। [MathPortion](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/) प्रकार की जाँच वास्तविक संपादन योग्य समीकरणों को सामान्य टेक्स्ट और चित्रों से अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्पलेट सभी समान कमांड, पैकेज या Unicode अक्षरों को समर्थन नहीं देते हैं। अपने अनुप्रयोग द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो लौटाई गई स्ट्रिंग में उसे प्रोजेक्ट-विशिष्ट कमांड से प्रतिस्थापित करें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को दर्ज करें।

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

भले ही मनुष्यों के लिए LaTeX लिखना आसान है, MathML आमतौर पर अनुप्रयोगों द्वारा स्वचालित रूप से उत्पन्न किया जाता है। क्योंकि MathML XML-आधारित है, प्रोग्राम इसे विश्वसनीय रूप से पढ़ और पार्स कर सकते हैं, इसलिए इसे कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में सामान्यतः उपयोग किया जाता है।

निम्नलिखित नमूना कोड दिखाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात किया जाए:

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

**MathML में वास्तव में क्या निर्यात होता है—एक पैराग्राफ या एक व्यक्तिगत फॉर्मूला ब्लॉक?**  
आप पूरी गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक मेथड प्रदान करते हैं।

**मैं कैसे पता करूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या चित्र के बजाय गणितीय फॉर्मूला है?**  
एक फॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathportion/) में स्थित होता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) होता है। जिन चित्रों और सामान्य टेक्स्ट भागों में [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) नहीं होता, वे निर्यात योग्य फॉर्मूले नहीं होते।

**प्रस्तुति में MathML कहाँ से आती है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose Presentation MathML—मानक की प्रस्तुति उपसमुच्चय—का उपयोग करता है, जिसे अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।

**क्या टेबल, SmartArt, समूह आदि में मौजूद फॉर्मूलों का निर्यात समर्थित है?**  
हां, यदि उन वस्तुओं में ऐसे टेक्स्ट भाग हैं जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides.mathtext/mathparagraph/) होता है (अर्थात वास्तविक PowerPoint फॉर्मूले), तो उन्हें निर्यात किया जाता है। यदि फॉर्मूला चित्र के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होगा।

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**  
नहीं। MathML लिखना फॉर्मूले की सामग्री का एक सीरियलाइजेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।