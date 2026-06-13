---
title: जावा में पावरपॉइंट टेक्स्ट को एनीमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/java/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान‑से‑समझने वाले, अनुकूलित Java कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में एनीमेटेड टेक्स्ट के साथ काम करने के तरीके को समझाता है, जहाँ आप व्यक्तिगत पैराग्राफ़ पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं और टेक्स्ट फ़्रेम में पैराग्राफ़ को पहले से सौंपे गए इफ़ेक्ट्स को प्राप्त कर सकते हैं। यह प्रस्तुति में पैराग्राफ‑स्तर के एनीमेशन जोड़ने और मौजूदा पैराग्राफ एनीमेशन इफ़ेक्ट्स का निरीक्षण करने वाले API मेथड्स पर केंद्रित है।

## **पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ना**

हमने [**addEffect()**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Sequence) और [**ISequence**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISequence) क्लासेज़ में जोड़ा है। यह मेथड आपको एकल पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह नमूना कोड दिखाता है कि एकल पैराग्राफ़ में एनीमेशन इफ़ेक्ट कैसे जोड़ें:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // इफ़ेक्ट जोड़ने के लिए पैराग्राफ चुनें
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // चयनित पैराग्राफ में Fly एनीमेशन इफ़ेक्ट जोड़ें
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करना**

आप यह पता लगाना चाह सकते हैं कि किसी पैराग्राफ़ में कौन से एनीमेशन इफ़ेक्ट जोड़े गये हैं—उदाहरण के लिए, एक स्थिति में आप किसी पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करना चाहते हैं क्योंकि आप इन्हें दूसरे पैराग्राफ़ या शेप पर लागू करने की योजना बना रहे हैं।

Aspose.Slides for Java आपको टेक्स्ट फ़्रेम (शेप) में मौजूद सभी पैराग्राफ़ पर लागू किए गए एनीमेशन इफ़ेक्ट प्राप्त करने देता है। यह नमूना कोड दिखाता है कि पैराग्राफ़ में एनीमेशन इफ़ेक्ट कैसे प्राप्त करें:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **प्रश्नोत्तर**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग होते हैं, और क्या इन्हें मिलाया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर वस्तु के व्यवहार को समय के साथ नियंत्रित करते हैं, जबकि [transitions](/slides/hi/java/slide-transition/) स्लाइड के बदलने के तरीके को नियंत्रित करते हैं। वे स्वतंत्र होते हैं और एक साथ उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**PDF या इमेज में एक्सपोर्ट करने पर टेक्स्ट एनीमेशन सुरक्षित रहते हैं क्या?**

नहीं। PDF और रास्टर इमेज स्थिर होते हैं, इसलिए आप स्लाइड की एक ही स्थिति बिना गति के देखेंगे। गति को बनाए रखने के लिए, [video](/slides/hi/java/convert-powerpoint-to-video/) या [HTML](/slides/hi/java/export-to-html5/) एक्सपोर्ट का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू किए गए इफ़ेक्ट स्लाइड्स द्वारा विरासत में प्राप्त होते हैं, लेकिन उनका timing और स्लाइड‑स्तर के एनीमेशन के साथ अन्तःक्रिया स्लाइड पर अंतिम क्रम पर निर्भर करती है।