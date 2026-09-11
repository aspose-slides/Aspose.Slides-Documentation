---
title: Python में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/python-java/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- समीकरण LaTeX में निर्यात करें
- PowerPoint से LaTeX में
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों से गणितीय समीकरण सीधे LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुति से गणितीय समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स (किसी विशिष्ट प्रस्तुति से) पर मौजूद गणितीय समीकरणों को निकालकर उन्हें किसी अन्य कार्यक्रम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="info" title="Note" %}} 
आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब पर और कई अनुप्रयोगों में उपयोग किए जाने वाले गणितीय सामग्री के लिए एक लोकप्रिय मानक है।
{{% /alert %}}

## **गणित समीकरणों को LaTeX में निर्यात करें**

Aspose.Slides एक PowerPoint गणितीय समीकरण को सीधे LaTeX में परिवर्तित कर सकता है; एक मध्यवर्ती MathML फ़ाइल या बाहरी कनवर्टर की आवश्यकता नहीं होती। एक गणितीय समीकरण टेक्स्ट फ्रेम में एक [MathPortion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathportion/) के रूप में संग्रहीत होता है। [MathPortion.getMathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathportion/#getMathParagraph) का उपयोग करके आप एक [MathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/) प्राप्त कर सकते हैं, और फिर [MathParagraph.toLatex](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/#toLatex) को कॉल करें। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रोसेस कर सकते हैं।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#getAllTextBoxes) एक स्लाइड पर पाए गए सभी टेक्स्ट फ्रेम लौटाता है। MathPortion प्रकार की जाँच सामान्य टेक्स्ट और छवियों से वास्तविक संपादन योग्य समीकरणों को अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्प्लेट सभी समान कमांड, पैकेज या यूनिकोड अक्षर नहीं समर्थन करते। आपके अनुप्रयोग द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो लौटाई गई स्ट्रिंग में उसे प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को रिकॉर्ड करें।

## **MathML के रूप में गणित समीकरण सहेजें**

जबकि लोग कुछ समीकरण स्वरूपों जैसे LaTeX के लिए कोड आसानी से लिख सकते हैं, MathML को हाथ से लिखना कठिन है क्योंकि इसे अनुप्रयोगों द्वारा स्वचालित रूप से उत्पन्न करने के लिए डिज़ाइन किया गया है। प्रोग्राम आसानी से MathML को पढ़ और पार्स कर सकते हैं क्योंकि यह XML-आधारित है, इसलिए कई क्षेत्रों में MathML आमतौर पर आउटपुट और प्रिंटिंग स्वरूप के रूप में उपयोग किया जाता है।

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप MathML में या तो संपूर्ण गणित पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathblock/)) निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक मेथड प्रदान करते हैं।

**मैं कैसे पहचानूं कि स्लाइड पर मौजूद वस्तु सामान्य टेक्स्ट या छवि के बजाय गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathportion/) में रहता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/) होता है। बिना [MathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/) वाले छवियों और सामान्य टेक्स्ट भागों को निर्यात योग्य सूत्र नहीं माना जाता।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose Presentation MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जिसे अनुप्रयोगों और वेब में व्यापक रूप से उपयोग किया जाता है।

**टेबल, SmartArt, समूह आदि के भीतर सूत्रों का निर्यात समर्थित है क्या?**

हां, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mathparagraph/) वाले टेक्स्ट भाग होते हैं (अर्थात वास्तविक PowerPoint सूत्र), तो उन्हें निर्यात किया जाता है। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो उसे निर्यात नहीं किया जाता।

**MathML में निर्यात करने से मूल प्रस्तुति में परिवर्तन होता है क्या?**

नहीं। MathML लिखना सूत्र की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।