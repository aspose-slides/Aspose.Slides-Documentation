---
title: Android पर प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/androidjava/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सुगम निर्यात करें—फ़ॉर्मेटिंग को संरक्षित रखें और संगतता बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides for Android via Java आपको प्रस्तुतियों से गणितीय समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स पर गणितीय समीकरण निकालने (किसी विशिष्ट प्रस्तुति से) और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 
आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में देखी जाने वाली गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय फ़ॉर्मेट या मानक है। 
{{% /alert %}}

## **प्रस्तुति से गणितीय समीकरण निर्यात करना**

जबकि मनुष्य LaTeX जैसे कुछ समीकरण फ़ॉर्मेट के कोड को आसानी से लिख सकते हैं, वे MathML के कोड को लिखने में कठिनाई महसूस करते हैं क्योंकि इसे ऐप्स द्वारा स्वचालित रूप से उत्पन्न किया जाना होता है। कार्यक्रम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में आम तौर पर उपयोग किया जाता है।

यह नमूना कोड दिखाता है कि कैसे प्रस्तुति से गणितीय समीकरण को MathML में निर्यात किया जाता है:
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

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत फ़ॉर्मूला ब्लॉक?**  
आप पूरे गणित पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने का एक मेथड प्रदान करते हैं।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई वस्तु सामान्य टेक्स्ट या इमेज के बजाय गणितीय फ़ॉर्मूला है?**  
एक फ़ॉर्मूला [MathPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathportion/) में मौजूद होता है और इसका एक [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) होता है। इमेज और सामान्य टेक्स्ट हिस्से जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) नहीं होता, निर्यात योग्य फ़ॉर्मूले नहीं होते।

**प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**  
निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रेजेंटेशन MathML—मानक का प्रेजेंटेशन उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**टेबल, SmartArt, समूह आदि के भीतर फ़ॉर्मूले निर्यात करना समर्थित है क्या?**  
हाँ, यदि उन वस्तुओं में [MathParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mathparagraph/) वाले टेक्स्ट हिस्से होते हैं (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात होते हैं। यदि फ़ॉर्मूला इमेज के रूप में एम्बेड किया गया है, तो वह निर्यात नहीं होता।

**क्या MathML में निर्यात करने से मूल प्रस्तुति बदलती है?**  
नहीं। MathML लिखना फ़ॉर्मूले की सामग्री का सीरियलाइज़ेशन है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।