---
title: जावा में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात
type: docs
weight: 30
url: /hi/java/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात करें—स्वरूपण को संरक्षित रखें और संगतता को बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स पर मौजूद गणितीय समीकरणों (किसी विशिष्ट प्रस्तुति से) को निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है। 

{{% alert color="primary" %}} 
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में देखी जाने वाली गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय स्वरूप या मानक है। 
{{% /alert %}}

## **गणितीय समीकरणों को MathML के रूप में सहेजें**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण स्वरूपों के लिए कोड आसानी से लिखते हैं, वे MathML के लिए कोड लिखने में कठिनाई महसूस करते हैं क्योंकि इसे स्वचालित रूप से एप्लिकेशनों द्वारा उत्पन्न किया जाना है। प्रोग्राम्स MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग स्वरूप के रूप में सामान्यतः उपयोग किया जाता है। 

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

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप MathML में या तो पूरा गणित पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathblock/)) निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने की एक विधि प्रदान करते हैं।

**मैं कैसे पहचान सकता हूँ कि स्लाइड पर कोई वस्तु सामान्य पाठ या चित्र की बजाय गणितीय सूत्र है?**

एक सूत्र [MathPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) होता है। जो चित्र और सामान्य पाठ भागों में [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) नहीं होता, वे निर्यात योग्य सूत्र नहीं होते।

**प्रस्तुति में MathML कहाँ से आता है—क्या यह PowerPoint-विशिष्ट है या कोई मानक?**

निर्यात मानक MathML (XML) को लक्ष्य बनाता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**क्या तालिकाओं, SmartArt, समूहों आदि के भीतर सूत्रों का निर्यात समर्थित है?**

हां, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mathparagraph/) वाले पाठ भाग होते हैं (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात होते हैं। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**क्या MathML में निर्यात करने से मूल प्रस्तुति में परिवर्तन होता है?**

नहीं। MathML लिखना सूत्र की सामग्री का क्रमबद्धीकरण है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।