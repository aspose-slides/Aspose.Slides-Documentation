---
title: Android पर प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/androidjava/exporting-math-equations/
keywords:
- "गणितीय समीकरण निर्यात करें"
- "समीकरणों को LaTeX में निर्यात करें"
- "PowerPoint को LaTeX में"
- MathML
- LaTeX
- PowerPoint
- "प्रस्तुति"
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे LaTeX या MathML में निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Android via Java आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको विशिष्ट प्रस्तुति से स्लाइड्स पर गणितीय समीकरण निकालने और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है (एक विशेष प्रस्तुति से)।

{{% alert color="info" %}} 
आप समीकरणों को सीधे LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में उपयोग किए जाने वाले गणितीय सामग्री के लिए एक लोकप्रिय मानक है।
{{% /alert %}}

## **गणितीय समीकरणों को LaTeX में निर्यात करें**

Aspose.Slides सीधे PowerPoint गणितीय समीकरण को LaTeX में परिवर्तित कर सकता है; मध्यस्थ MathML फ़ाइल और बाहरी रूपांतरणकर्ता की आवश्यकता नहीं है। एक गणितीय समीकरण को एक टेक्स्ट फ़्रेम में [IMathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/) के रूप में संग्रहीत किया जाता है। [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) का उपयोग करके आप एक [IMathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathparagraph/) प्राप्त कर सकते हैं, और फिर [IMathParagraph.toLatex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathparagraph/#toLatex--) को कॉल करें। यह विधि एक स्ट्रिंग लौटाती है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य एप्लिकेशन को भेज सकते हैं, या आगे प्रक्रिया कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड पर प्रत्येक टेक्स्ट फ़्रेम की जाँच करता है, सभी गणितीय हिस्सों को खोजता है, और प्रत्येक समीकरण को एक अलग `.tex` फ़ाइल में लिखता है:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) स्लाइड पर पाए गए सभी टेक्स्ट फ़्रेम लौटाता है। [IMathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imathportion/) प्रकार जाँच वास्तविक संपादन योग्य समीकरणों को सामान्य टेक्स्ट और छवियों से अलग करती है।

सभी LaTeX इंजन और दस्तावेज़ टेम्प्लेट एक ही कमांड, पैकेज या Unicode अक्षरों का समर्थन नहीं करते। आपके एप्लिकेशन द्वारा उपयोग किए जाने वाले LaTeX इंजन के साथ लौटाए गए स्ट्रिंग का परीक्षण करें। यदि किसी प्रतीक या Office Math तत्व का उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं है, तो लौटाए गए स्ट्रिंग में उसे प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़ दें और समीक्षा के लिए समस्या को रिकॉर्ड करें।

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों के कोड को आसानी से लिखते हैं, वे MathML का कोड लिखने में कठिनाई महसूस करते हैं क्योंकि इसे स्वचालित रूप से एप्लिकेशन द्वारा उत्पन्न किया जाना चाहिए। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि उसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में सामान्यतः उपयोग किया जाता है।

यह नमूना कोड आपको दिखाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात किया जाए:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**MathML में बिल्कुल क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप एक पूरे गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/)) या एक व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक विधि प्रदान करते हैं।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कोई वस्तु नियमित टेक्स्ट या छवि के बजाय गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathportion/) में स्थित होता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) होता है। बिना [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) वाले छवियाँ और सामान्य टेक्स्ट हिस्से निर्यात योग्य सूत्र नहीं हैं।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**

निर्यात मानक MathML (XML) को लक्ष्य करता है। Aspose Presentation MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो विभिन्न अनुप्रयोगों और वेब में व्यापक रूप से प्रयुक्त है।

**क्या टेबल, SmartArt, समूह आदि के अंदर के सूत्रों का निर्यात समर्थित है?**

हां, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) वाले टेक्स्ट हिस्से हैं (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात किए जाते हैं। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह नहीं।

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**

नहीं। MathML लिखना सूत्र की सामग्री का क्रमबद्धन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।