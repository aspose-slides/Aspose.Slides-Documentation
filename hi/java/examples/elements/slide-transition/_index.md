---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/java/examples/elements/slide-transition/
keywords:
- कोड उदाहरण
- स्लाइड ट्रांज़िशन
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड ट्रांज़िशन को मास्टर करें: प्रभावों और अवधि को जोड़ें, अनुकूलित करें, और क्रमबद्ध करें, PPT, PPTX, और ODP प्रस्तुतियों के लिए Java उदाहरणों के साथ।"
---
यह लेख स्लाइड ट्रांज़िशन इफ़ेक्ट्स और टाइमिंग को **Aspose.Slides for Java** के साथ लागू करने को दर्शाता है।

## **स्लाइड ट्रांज़िशन जोड़ें**

पहली स्लाइड पर फ़ेड ट्रांज़िशन इफ़ेक्ट लागू करें।

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // फ़ेड ट्रांज़िशन लागू करें।
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन तक पहुँचें**

स्लाइड को वर्तमान में असाइन किए गए ट्रांज़िशन प्रकार को पढ़ें।

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // ट्रांज़िशन प्रकार तक पहुँचें।
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन हटाएँ**

टाइप को `None` सेट करके किसी भी ट्रांज़िशन इफ़ेक्ट को साफ़ करें।

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // none सेट करके ट्रांज़िशन को हटाएँ।
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **ट्रांज़िशन अवधि सेट करें**

स्वचालित रूप से आगे बढ़ने से पहले स्लाइड कितने समय तक प्रदर्शित की जाएगी, यह निर्दिष्ट करें।

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // मिलीसेकंड में।
    } finally {
        presentation.dispose();
    }
}
```