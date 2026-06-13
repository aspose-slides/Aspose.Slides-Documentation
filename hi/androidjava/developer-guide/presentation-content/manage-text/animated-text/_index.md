---
title: Android पर PowerPoint टेक्स्ट को एनीमेट करें
linktitle: एनिमेटेड टेक्स्ट
type: docs
weight: 60
url: /hi/androidjava/animated-text/
keywords:
- एनिमेटेड टेक्स्ट
- टेक्स्ट एनीमेशन
- एनिमेटेड पैराग्राफ
- पैराग्राफ एनीमेशन
- एनीमेशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में गतिशील एनिमेटेड टेक्स्ट बनाएं, आसान‑से‑अनुसरणीय, अनुकूलित Java कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides में एनीमेटेड टेक्स्ट के साथ कैसे काम किया जाए, व्यक्तिगत पैराग्राफ़ पर एनीमेशन इफ़ेक्ट लागू करके और टेक्स्ट फ़्रेम में पहले से असाइन किए गए पैराग्राफ़ पर इफ़ेक्ट पुनः प्राप्त करके। यह प्रस्तुति में पैराग्राफ‑स्तर के एनीमेशन जोड़ने और मौजूदा पैराग्राफ एनीमेशन इफ़ेक्ट्स की जांच करने के लिए उपयोग किए जाने वाले API मेथड्स पर केंद्रित है।

## **पराग्राफ में एनीमेशन इफ़ेक्ट जोड़ें**

हमने [**addEffect()**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) मेथड को [**Sequence**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Sequence) और [**ISequence**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISequence) क्लासेस में जोड़ दिया है। यह मेथड आपको एकल पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ने की अनुमति देता है। यह नमूना कोड दिखाता है कि कैसे एक पैराग्राफ़ में एनीमेशन इफ़ेक्ट जोड़ा जाए:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // इफ़ेक्ट जोड़ने के लिए पैराग्राफ़ चुनें
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // चयनित पैराग्राफ़ पर Fly एनीमेशन इफ़ेक्ट जोड़ें
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **पराग्राफ के एनीमेशन इफ़ेक्ट्स प्राप्त करें**

आप यह निर्धारित करना चाह सकते हैं कि किसी पैराग्राफ़ में कौन से एनीमेशन इफ़ेक्ट जोड़े गए हैं—उदाहरण के लिए, एक स्थिति में, आप किसी पैराग्राफ़ के एनीमेशन इफ़ेक्ट प्राप्त करना चाहते हैं क्योंकि आप उन इफ़ेक्ट्स को किसी अन्य पैराग्राफ़ या शेड में लागू करने की योजना बना रहे हैं।

Aspose.Slides for Android via Java आपको टेक्स्ट फ्रेम (शेप) में मौजूद पैराग्राफ़ पर लागू सभी एनीमेशन इफ़ेक्ट प्राप्त करने की अनुमति देता है। यह नमूना कोड दिखाता है कि कैसे पैराग्राफ़ में एनीमेशन इफ़ेक्ट प्राप्त किया जाए:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**टेक्स्ट एनीमेशन स्लाइड ट्रांज़िशन से कैसे अलग होते हैं, और क्या उन्हें मिलाया जा सकता है?**

टेक्स्ट एनीमेशन स्लाइड पर वस्तु के व्यवहार को समय के साथ नियंत्रित करता है, जबकि [ट्रांज़िशन](/slides/hi/androidjava/slide-transition/) स्लाइड के बदलने का तरीका नियंत्रित करता है। वे स्वतंत्र होते हैं और साथ में उपयोग किए जा सकते हैं; प्लेबैक क्रम एनीमेशन टाइमलाइन और ट्रांज़िशन सेटिंग्स द्वारा निर्धारित होता है।

**क्या टेक्स्ट एनीमेशन PDF या इमेज में एक्सपोर्ट करने पर संरक्षित रहते हैं?**

नहीं। PDF और रास्टर इमेज स्थिर होते हैं, इसलिए आप स्लाइड की एक ही स्थिति बिना गति के देखेंगे। गति बनाए रखने के लिए, [वीडियो](/slides/hi/androidjava/convert-powerpoint-to-video/) या [HTML](/slides/hi/androidjava/export-to-html5/) एक्सपोर्ट का उपयोग करें।

**क्या टेक्स्ट एनीमेशन लेआउट और स्लाइड मास्टर में काम करते हैं?**

लेआउट/मास्टर ऑब्जेक्ट्स पर लागू इफ़ेक्ट स्लाइड्स द्वारा विरासत में मिलते हैं, लेकिन उनका टाइमिंग और स्लाइड‑स्तर के एनीमेशन के साथ इंटरैक्शन स्लाइड पर अंतिम क्रम पर निर्भर करता है।