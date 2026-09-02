---
title: जावास्क्रिप्ट में प्रस्तुतियों से गणितीय समीकरण निर्यात करें
linktitle: समीकरण निर्यात करें
type: docs
weight: 30
url: /hi/nodejs-java/exporting-math-equations/
keywords:
- गणितीय समीकरण निर्यात करें
- LaTeX में समीकरण निर्यात करें
- PowerPoint से LaTeX
- MathML
- LaTeX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों से गणितीय समीकरणों को सीधे LaTeX या MathML में Aspose.Slides के साथ Node.js के लिये Java के माध्यम से निर्यात करें।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों से गणितीय समीकरणों को निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको किसी विशिष्ट प्रस्तुति से स्लाइड्स पर मौजूद गणितीय समीकरणों को निकालकर उन्हें किसी अन्य प्रोग्राम या प्लेटफ़ॉर्म में उपयोग करने की आवश्यकता हो सकती है।

{{% alert color="primary" %}} 
आप सीधे समीकरणों को LaTeX या MathML में निर्यात कर सकते हैं, जो वेब और कई अनुप्रयोगों में प्रयुक्त गणितीय सामग्री के लिए एक लोकप्रिय मानक है।
{{% /alert %}}

## **LaTeX में गणितीय समीकरण निर्यात करना**

Aspose.Slides PowerPoint गणितीय समीकरण को सीधे LaTeX में परिवर्तित कर सकता है; इसके लिए मध्यवर्ती MathML फ़ाइल या बाहरी कनवर्टर की आवश्यकता नहीं होती। एक गणितीय समीकरण को टेक्स्ट फ्रेम में एक [MathPortion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/) के रूप में संग्रहीत किया जाता है। एक [MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) प्राप्त करने के लिए [MathPortion.getMathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) का उपयोग करें, और फिर [MathParagraph.toLatex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/#toLatex--) को कॉल करें। यह मेथड एक स्ट्रिंग लौटाता है जिसे आप सहेज सकते हैं, प्रदर्शित कर सकते हैं, किसी अन्य एप्लिकेशन को भेज सकते हैं, या आगे प्रोसेस कर सकते हैं।

निम्नलिखित उदाहरण प्रत्येक स्लाइड के सभी टेक्स्ट फ्रेम को जांचता है, सभी गणितीय हिस्सों को खोजता है, और प्रत्येक समीकरण को अलग-अलग `.tex` फ़ाइल में लिखता है:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) स्लाइड पर पाए गए सभी टेक्स्ट फ्रेम लौटाता है। [MathPortion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/) प्रकार की जाँच सामान्य टेक्स्ट और चित्रों से वास्तविक संपादन योग्य समीकरणों को अलग करती है।

LaTeX इंजन और दस्तावेज़ टेम्पलेट सभी कमांड, पैकेज या Unicode अक्षरों को समान रूप से समर्थन नहीं देते। अपने एप्लिकेशन द्वारा प्रयुक्त LaTeX इंजन के साथ लौटाई गई स्ट्रिंग का परीक्षण करें। यदि कोई प्रतीक या Office Math तत्व उस वातावरण में उपयुक्त प्रतिनिधित्व नहीं रखता, तो लौटाई गई स्ट्रिंग में इसे प्रोजेक्ट-विशिष्ट कमांड से बदलें या समीकरण को छोड़कर समस्या को रिकॉर्ड करें।

## **MathML के रूप में गणितीय समीकरण सहेजना**

जबकि लोग LaTeX जैसे कुछ समीकरण फ़ॉर्मेट का कोड आसानी से लिख सकते हैं, वे MathML का कोड लिखने में कठिनाई महसूस करते हैं क्योंकि इसका उद्देश्य एप्लिकेशन द्वारा स्वचालित रूप से उत्पन्न किया जाना है। प्रोग्राम MathML को आसानी से पढ़ और पार्स कर लेते हैं क्योंकि इसका कोड XML में होता है, इसलिए MathML कई क्षेत्रों में आउटपुट और प्रिंटिंग फ़ॉर्मेट के रूप में व्यापक रूप से उपयोग किया जाता है।

यह नमूना कोड दिखाता है कि प्रस्तुति से गणितीय समीकरण को MathML में कैसे निर्यात किया जा सकता है:

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

## **FAQ**

**MathML में वास्तव में क्या निर्यात किया जाता है—एक पैराग्राफ या व्यक्तिगत फ़ॉर्मूला ब्लॉक?**

आप पूरे गणितीय पैराग्राफ ([MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/)) या व्यक्तिगत ब्लॉक ([MathBlock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathblock/)) को MathML में निर्यात कर सकते हैं। दोनों प्रकार में MathML लिखने के लिए एक मेथड उपलब्ध है।

**मैं कैसे पहचानूं कि स्लाइड पर कोई ऑब्जेक्ट गणितीय फ़ॉर्मूला है या सामान्य टेक्स्ट/इमेज?**

एक फ़ॉर्मूला एक [MathPortion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathportion/) में रहता है और उसका एक [MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) होता है। बिना [MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides.mathparagraph/) वाले इमेज और सामान्य टेक्स्ट हिस्से निर्यात योग्य फ़ॉर्मूला नहीं होते।

**प्रेजेंटेशन में MathML कहां से आता है—क्या यह PowerPoint-विशिष्ट है या मानक?**

निर्यात मानक MathML (XML) को लक्ष्य बनाता है। Aspose प्रस्तुति MathML—मानक का प्रस्तुति उपसमुच्चय—का उपयोग करता है, जिसे विभिन्न एप्लिकेशनों और वेब में व्यापक रूप से अपनाया गया है।

**टेबल, SmartArt, समूह आदि के अंदर फ़ॉर्मूला निर्यात का समर्थन है क्या?**

हाँ, यदि उन ऑब्जेक्ट्स में ऐसे टेक्स्ट हिस्से हैं जिनमें [MathParagraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/mathparagraph/) मौजूद है (अर्थात वास्तविक PowerPoint फ़ॉर्मूले), तो वे निर्यात किए जाते हैं। यदि फ़ॉर्मूला इमेज के रूप में एम्बेड है, तो वह निर्यात योग्य नहीं है।

**MathML में निर्यात करने से मूल प्रस्तुति में कोई परिवर्तन होता है क्या?**

नहीं। MathML लिखना फ़ॉर्मूला की सामग्री का सीरियलाइज़ेशन है; इससे प्रस्तुति फ़ाइल में कोई परिवर्तन नहीं होता।