---
title: Android पर प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/androidjava/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- LaTeX में समीकरण निर्यात करें
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों से गणितीय समीकरण को सीधे LaTeX या MathML में Aspose.Slides for Android via Java के साथ निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Android via Java आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की सुविधा देता है। उदाहरण के तौर पर, आपको स्लाइड्स (एक विशिष्ट प्रस्तुति से) पर मौजूद गणितीय समीकरण निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 
आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग होने वाला एक लोकप्रिय मानक है।
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides सीधे PowerPoint गणितीय समीकरण को LaTeX में बदल सकता है; इसके लिए मध्यस्थ MathML फ़ाइल या बाहरी रूपान्तरणकर्ता की आवश्यकता नहीं होती। गणितीय समीकरण एक टेक्स्ट फ्रेम में एक [IMathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/) के रूप में संग्रहीत होता है। एक [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) का उपयोग करके आप एक [IMathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathparagraph/) प्राप्त कर सकते हैं, और फिर [IMathParagraph.toLatex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य अनुप्रयोग को भेज सकते हैं, या आगे प्रक्रिया कर सकते हैं।

नीचे दिया गया उदाहरण प्रत्येक स्लाइड पर सभी टेक्स्ट फ्रेम की जाँच करता है, सभी गणितीय हिस्सों को खोजता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) एक स्लाइड पर पाए जाने वाले सभी टेक्स्ट फ्रेम लौटाता है। [IMathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/) प्रकार की जाँच साधारण टेक्स्ट और छवियों से वास्तविक संपादन योग्य समीकरणों को अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्प्लेट सभी समान कमांड, पैकेज या Unicode अक्षरों का समर्थन नहीं करते। अपने अनुप्रयोग द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि कोई चिन्ह या Office Math तत्व उस वातावरण में उपयुक्त रूप में उपलब्ध नहीं है, तो लौटाई गई स्ट्रिंग में उसे प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या दर्ज करें।

## **Save Math Equations as MathML**

मानव आसानी से LaTeX जैसी कुछ समीकरण फ़ॉर्मेट की कोड लिख सकते हैं, लेकिन MathML की कोड लिखने में उन्हें कठिनाई होती है क्योंकि इसे आमतौर पर ऐप्स द्वारा स्वचालित रूप से उत्पन्न किया जाता है। प्रोग्राम्स MathML को आसानी से पढ़ और पार्स कर सकते हैं क्योंकि उसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में व्यापक रूप से उपयोग किया जाता है।

यह नमूना कोड दिखाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात किया जाए:

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

## **FAQ**

**MathML में वास्तव में क्या निर्यात होता है—एक पैराग्राफ या व्यक्तिगत फ़ॉर्मूला ब्लॉक?**

आप पूरे गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार के पास MathML में लिखने की विधि उपलब्ध है।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई वस्तु गणितीय फ़ॉर्मूला है या सामान्य टेक्स्ट/छवि?**

फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) होता है। जिन छवियों और सामान्य टेक्स्ट हिस्सों में [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) नहीं होता, वे निर्यात योग्य फ़ॉर्मूले नहीं होते।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या कोई मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो विभिन्न अनुप्रयोगों और वेब में व्यापक रूप से प्रयुक्त होता है।

**टेबल, SmartArt, समूह आदि के अंदर फ़ॉर्मूले निर्यात करना समर्थित है?**

हाँ, यदि उन वस्तुओं में ऐसे टेक्स्ट हिस्से हैं जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) है (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात किए जाते हैं। यदि फ़ॉर्मूला छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होगा।

**MathML में निर्यात करने से मूल प्रस्तुति में कोई परिवर्तन होता है?**

नहीं। MathML लिखना फ़ॉर्मूले की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।