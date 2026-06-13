---
title: जावास्क्रिप्ट में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/nodejs-java/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js का उपयोग करके PowerPoint से MathML में गणितीय समीकरणों का सहज निर्यात सक्षम करें—फ़ॉर्मेटिंग को बनाए रखें और संगतता को बढ़ाएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों से गणित समीकरण निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको स्लाइड्स पर गणितीय समीकरण निकालने (किसी विशिष्ट प्रस्तुति से) और उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है। 

{{% alert color="primary" %}} 

आप समीकरणों को MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में देखे जाने वाले गणितीय समीकरणों और समान सामग्री के लिए एक लोकप्रिय फ़ॉर्मेट या मानक है। 

{{% /alert %}}

## **MathML के रूप में गणित समीकरण सहेजें**

जबकि मनुष्य कुछ समीकरण फ़ॉर्मेट जैसे LaTeX के कोड को आसानी से लिखते हैं, वे MathML के कोड को लिखने में कठिनाई महसूस करते हैं क्योंकि यह अंततः एप्लिकेशनों द्वारा स्वचालित रूप से उत्पन्न किया जाता है। प्रोग्राम MathML को आसानी से पढ़ते और पार्स करते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML को कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में आमतौर पर उपयोग किया जाता है। 

यह नमूना कोड दर्शाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात किया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**MathML में ठीक क्या निर्यात किया जाता है—एक पैराग्राफ या एक व्यक्तिगत सूत्र ब्लॉक?**

आप पूरी गणितीय पैराग्राफ([MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक([MathBlock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार MathML में लिखने के लिए एक विधि प्रदान करते हैं।

**मैं कैसे पहचानूँ कि स्लाइड पर कोई वस्तु सामान्य पाठ या छवि के बजाय गणितीय सूत्र है?**

एक सूत्र एक[MathPortion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/) में स्थित होता है और इसका एक[MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) होता है। जिन छवियों और सामान्य पाठ भागों में[MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) नहीं होता, वे निर्यात योग्य सूत्र नहीं होते।

**एक प्रस्तुति में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या एक मानक?**

निर्यात मानक MathML (XML) को लक्षित करता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जो अनुप्रयोगों और वेब में व्यापक रूप से उपयोग होता है।

**टेबल, SmartArt, समूह आदि के भीतर सूत्रों का निर्यात समर्थित है क्या?**

हाँ, यदि उन वस्तुओं में[MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) वाला पाठ भाग है (अर्थात वास्तविक PowerPoint सूत्र), तो वे निर्यात होते हैं। यदि कोई सूत्र छवि के रूप में एम्बेड किया गया है, तो वह नहीं निर्यात होता।

**क्या MathML में निर्यात करने से मूल प्रस्तुति संशोधित होती है?**

नहीं। MathML लिखना सूत्र की सामग्री का क्रमबद्धण है; यह प्रस्तुति फ़ाइल को संशोधित नहीं करता।