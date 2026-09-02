---
title: Java में प्रस्तुतियों से गणित समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/java/exporting-math-equations/
keywords:
- गणित समीकरण निर्यात करें
- समीकरणों को LaTeX में निर्यात करें
- PowerPoint को LaTeX में
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों से गणित समीकरणों को सीधे LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों से गणित समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स पर गणितीय समीकरणों को (किसी विशिष्ट प्रस्तुति से) निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है। 

{{% alert color="primary" %}} 
आप सीधे LaTeX या MathML में समीकरण निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग किया जाने वाला गणितीय सामग्री का एक लोकप्रिय मानक है। 
{{% /alert %}}

## **LaTeX में गणित समीकरण निर्यात करें**

Aspose.Slides PowerPoint गणित समीकरण को सीधे LaTeX में बदल सकता है; एक मध्यस्थ MathML फ़ाइल या बाहरी कन्वर्टर की आवश्यकता नहीं है। एक गणित समीकरण को टेक्स्ट फ़्रेम में एक [IMathPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imathportion/) के रूप में संग्रहीत किया जाता है। एक [IMathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imathparagraph/) प्राप्त करने के लिए [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imathportion/#getMathParagraph--) का उपयोग करें, और फिर [IMathParagraph.toLatex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imathparagraph/#toLatex--) को बुलाएँ। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रक्रिया कर सकते हैं।

निम्न उदाहरण प्रत्येक स्लाइड पर हर टेक्स्ट फ़्रेम की जाँच करता है, सभी गणित भागों को खोजता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) एक स्लाइड पर मिलने वाले सभी टेक्स्ट फ़्रेम लौटाता है। [IMathPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imathportion/) प्रकार जांच सामान्य टेक्स्ट और छवियों से वास्तविक संपादन योग्य समीकरणों को अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्प्लेट सभी समान कमांड, पैकेज या यूनिकोड वर्णों को समर्थित नहीं करते। अपने अनुप्रयोग द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो लौटाई गई स्ट्रिंग में इसे किसी प्रोजेक्ट‑विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या दर्ज करें।

## **MathML के रूप में गणित समीकरण सहेजें**

मानव LaTeX जैसे कुछ समीकरण फ़ॉर्मेट के कोड को आसानी से लिख सकते हैं, लेकिन MathML के कोड को लिखने में कठिनाई होती है क्योंकि इसे स्वचालित रूप से एप्लिकेशन द्वारा उत्पन्न किया जाना चाहिए। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में आमतौर पर उपयोग किया जाता है। 

यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति से गणित समीकरण को MathML में निर्यात किया जाए:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**  
आप पूरे गणित पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML लिखने के लिए एक मेथड प्रदान करते हैं।

**मैं कैसे पहचानूं कि स्लाइड पर कोई ऑब्जेक्ट सामान्य टेक्स्ट या छवि के बजाय गणित सूत्र है?**  
एक सूत्र एक [MathPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) होता है। जिन छवियों और सामान्य टेक्स्ट भागों में [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) नहीं होता, उन्हें निर्यात योग्य सूत्र नहीं माना जाता।

**प्रस्तुति में MathML कहाँ से आता है—क्या यह PowerPoint‑विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML का उपयोग करता है—मानक का वह उपसमुच्चय जो प्रस्तुति के लिए तैयार किया गया है और विभिन्न अनुप्रयोगों व वेब में व्यापक रूप से उपयोग किया जाता है।

**टेबल, SmartArt, समूह आदि में मौजूद सूत्रों का निर्यात समर्थित है क्या?**  
हाँ, यदि उन ऑब्जेक्ट्स में वह टेक्स्ट भाग है जिसमें एक [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) है (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात किए जाते हैं। यदि सूत्र छवि के रूप में एम्बेड किया गया है, तो यह निर्यात योग्य नहीं है।

**MathML में निर्यात करने से मूल प्रस्तुति में कोई बदलाव होता है क्या?**  
नहीं। MathML लिखना सूत्र की सामग्री का एक सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।