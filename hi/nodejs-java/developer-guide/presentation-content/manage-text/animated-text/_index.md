---
title: जावास्क्रिप्ट में PowerPoint टेक्स्ट एनिमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/nodejs-java/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशन में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान-से-समझने वाले, अनुकूलित कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में एनिमेटेड टेक्स्ट के साथ काम करने के बारे में बताता है, जिसमें व्यक्तिगत पैराग्राफ पर एनीमेशन इफ़ेक्ट लागू करना और टेक्स्ट फ्रेम में पैराग्राफ को पहले से सौंपे गए इफ़ेक्ट्स को पुनः प्राप्त करना शामिल है। यह प्रस्तुति में पैराग्राफ-स्तर के एनीमेशन को जोड़ने और मौजूदा पैराग्राफ एनीमेशन इफ़ेक्ट्स की जांच करने के लिए उपयोग किए जाने वाले API मेथड्स पर केंद्रित है।

## **पैराग्राफ में एनीमेशन इफ़ेक्ट्स जोड़ना**

हमने [**addEffect()**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Sequence) और [**Sequence**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Sequence) क्लासों में जोड़ा। यह मेथड आपको एकल पैराग्राफ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह सैंपल कोड दिखाता है कि एक पैराग्राफ में एनीमेशन इफ़ेक्ट कैसे जोड़ें:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // प्रभाव जोड़ने के लिए पैराग्राफ चुनें
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // चयनित पैराग्राफ में Fly एनीमेशन इफ़ेक्ट जोड़ें
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **पैराग्राफ में एनीमेशन इफ़ेक्ट्स प्राप्त करना**

आप यह जानने का निर्णय ले सकते हैं कि पैराग्राफ में कौन से एनीमेशन इफ़ेक्ट्स जोड़े गए हैं—उदाहरण के लिए, एक परिदृश्य में आप एक पैराग्राफ में एनीमेशन इफ़ेक्ट्स प्राप्त करना चाहते हैं क्योंकि आप उन इफ़ेक्ट्स को किसी अन्य पैराग्राफ या आकार पर लागू करने की योजना बना रहे हैं।

Aspose.Slides for Node.js via Java आपको टेक्स्ट फ्रेम (शेप) में मौजूद पैराग्राफ पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त करने की अनुमति देता है। यह सैंपल कोड दिखाता है कि पैराग्राफ में एनीमेशन इफ़ेक्ट्स कैसे प्राप्त करें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग होते हैं, और क्या इन्हें संयोजित किया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर वस्तु के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [transitions](/slides/hi/nodejs-java/slide-transition/) स्लाइड बदलने के तरीके को नियंत्रित करते हैं। वे स्वतंत्र हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन PDF या इमेजेज़ में निर्यात करते समय संरक्षित रहते हैं?**

नहीं। PDF और रास्टर इमेजेज़ स्थिर होते हैं, इसलिए आपको स्लाइड की एक ही स्थिति बिना गति के दिखाई देगी। आंदोलन को बनाए रखने के लिए, [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) या [HTML](/slides/hi/nodejs-java/export-to-html5/) निर्यात का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर वस्तुओं पर लागू इफ़ेक्ट्स स्लाइड्स द्वारा विरासत में मिले होते हैं, लेकिन उनका समय निर्धारण और स्लाइड-स्तर के एनीमेशन के साथ इंटरैक्शन स्लाइड पर अंतिम अनुक्रम पर निर्भर करता है।