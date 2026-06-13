---
title: स्लाइड
type: docs
weight: 10
url: /hi/java/examples/elements/slide/
keywords:
- कोड उदाहरण
- स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइडों को नियंत्रित करें: PPT, PPTX और ODP प्रस्तुतियों के लिए जावा का उपयोग करके बनाएं, क्लोन करें, क्रम बदलें, आकार बदलें, पृष्ठभूमि सेट करें, और ट्रांज़िशन लागू करें।"
---
यह लेख कई उदाहरण प्रदान करता है जो **Aspose.Slides for Java** का उपयोग करके स्लाइडों के साथ काम करने का तरीका दर्शाते हैं। आप `Presentation` वर्ग का उपयोग करके स्लाइडों को जोड़ना, एक्सेस करना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में संक्षिप्त व्याख्या के बाद जावा में कोड स्निपेट शामिल है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए, आपको पहले एक लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **नोट:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करती है। नीचे की छवि दर्शाती है कि PowerPoint में मास्टर स्लाइड और उनके संबंधित लेआउट कैसे व्यवस्थित होते हैं।

![Master and Layout Relationship](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुँचें**

आप स्लाइड्स को उनके इंडेक्स से एक्सेस कर सकते हैं, या किसी संदर्भ के आधार पर स्लाइड का इंडेक्स पा सकते हैं। यह विशिष्ट स्लाइडों को क्रमांकित करने या संशोधित करने के लिए उपयोगी है।

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // एक और खाली स्लाइड जोड़ें।
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // इंडेक्स द्वारा स्लाइड्स को एक्सेस करें।
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // संदर्भ से स्लाइड का इंडेक्स प्राप्त करें, फिर उसे इंडेक्स से एक्सेस करें।
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड को क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाता है। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड संग्रह के अंत में जुड़ जाती है।

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड्स का क्रम बदलें**

आप स्लाइड्स का क्रम बदल सकते हैं, एक को नए इंडेक्स पर स्थानांतरित करके। इस मामले में, हम एक क्लोन की गई स्लाइड को पहली स्थिति में ले जाते हैं।

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड हटाएँ**

स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `remove` कॉल करें। यह उदाहरण एक दूसरी स्लाइड जोड़ता है और फिर मूल स्लाइड को हटाता है, जिससे केवल नई स्लाइड बचती है।

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```