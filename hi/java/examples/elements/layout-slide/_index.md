---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/java/examples/elements/layout-slide/
keywords:
- कोड उदाहरण
- लेआउट स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में मास्टर लेआउट स्लाइड्स: स्लाइड लेआउट, प्लेसहोल्डर्स और मास्टर्स को चुनें, लागू करें और अनुकूलित करें, PPT, PPTX और ODP प्रस्तुतियों के लिए जावा उदाहरणों के साथ।"
---
यह लेख Aspose.Slides for Java में **Layout Slides** के साथ काम करने का तरीका दर्शाता है। एक लेआउट स्लाइड सामान्य स्लाइड्स के द्वारा विरासत में प्राप्त डिज़ाइन और फॉर्मेटिंग को परिभाषित करती है। आप लेआउट स्लाइड्स को जोड़, एक्सेस, क्लोन और हटाया जा सकता है, साथ ही अनुपयोगी स्लाइड्स को साफ़ करके प्रस्तुति का आकार घटा सकते हैं।

## **लेआउट स्लाइड जोड़ें**

आप पुन: उपयोग योग्य फ़ॉर्मेटिंग को परिभाषित करने के लिए एक कस्टम लेआउट स्लाइड बना सकते हैं। उदाहरण के लिए, आप ऐसा टेक्स्ट बॉक्स जोड़ सकते हैं जो इस लेआउट का उपयोग करने वाली सभी स्लाइड्स पर दिखाई देगा।

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // एक खाली लेआउट प्रकार और एक कस्टम नाम के साथ लेआउट स्लाइड बनाएं।
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // लेआउट स्लाइड में एक टेक्स्ट बॉक्स जोड़ें।
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // इस लेआउट का उपयोग करके दो स्लाइड्स जोड़ें; दोनों लेआउट से टेक्स्ट को विरासत में प्राप्त करेंगे।
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **नोट 1:** लेआउट स्लाइड्स व्यक्तिगत स्लाइड्स के लिए टेम्प्लेट के रूप में कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित कर सकते हैं और उन्हें कई स्लाइड्स में पुनः उपयोग कर सकते हैं।

> 💡 **नोट 2:** जब आप लेआउट स्लाइड में शैप्स या टेक्स्ट जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइड्स स्वचालित रूप से यह साझा सामग्री प्रदर्शित करेंगे।  
> नीचे का स्क्रीनशॉट दो स्लाइड्स को दिखाता है, प्रत्येक समान लेआउट स्लाइड से एक टेक्स्ट बॉक्स को विरासत में प्राप्त करता है।

![लेआउट सामग्री विरासत में लेने वाली स्लाइड्स](layout-slide-result.png)

## **लेआउट स्लाइड तक पहुंचें**

लेआउट स्लाइड्स को इंडेक्स या लेआउट प्रकार (उदा., `Blank`, `Title`, `SectionHeader`, आदि) के द्वारा एक्सेस किया जा सकता है।

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // इंडेक्स द्वारा लेआउट स्लाइड तक पहुंचें।
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // प्रकार द्वारा लेआउट स्लाइड तक पहुंचें।
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **लेआउट स्लाइड हटाएं**

यदि किसी विशेष लेआउट स्लाइड की अब आवश्यकता नहीं है, तो आप इसे हटा सकते हैं।

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और उसे हटाएँ।
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **अनुपयोगी लेआउट स्लाइड्स हटाएं**

प्रस्तुति का आकार घटाने के लिए, आप उन लेआउट स्लाइड्स को हटाना चाह सकते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की गई हैं।

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // स्वचालित रूप से उन सभी लेआउट स्लाइड्स को हटा देता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **लेआउट स्लाइड क्लोन करें**

आप `addClone` मेथड का उपयोग करके लेआउट स्लाइड को डुप्लिकेट कर सकते हैं।

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें।
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // लेआउट स्लाइड को लेआउट स्लाइड संग्रह के अंत में क्लोन करें।
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **सारांश:** लेआउट स्लाइड्स स्लाइड्स के बीच निरंतर फ़ॉर्मेटिंग प्रबंधन के लिए शक्तिशाली उपकरण हैं। Aspose.Slides लेआउट स्लाइड्स को बनाने, प्रबंधित करने और अनुकूलित करने पर पूर्ण नियंत्रण प्रदान करता है।