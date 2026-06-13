---
title: स्लाइड
type: docs
weight: 10
url: /hi/androidjava/examples/elements/slide/
keywords:
- कोड उदाहरण
- स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में स्लाइड्स को नियंत्रित करें: जावा का उपयोग करके PPT, PPTX और ODP प्रस्तुतियों के लिए बनाना, क्लोन करना, क्रम बदलना, आकार बदलना, पृष्ठभूमि सेट करना और ट्रांज़िशन लागू करना।"
---
यह लेख कई उदाहरण प्रदान करता है जो **Aspose.Slides for Android via Java** का उपयोग करके स्लाइड्स के साथ काम करने का तरीका दर्शाते हैं। आप `Presentation` क्लास का उपयोग करके स्लाइड्स को जोड़ना, एक्सेस करना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में एक संक्षिप्त विवरण होता है, उसके बाद जावा में कोड स्निपेट दिया गया है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए, पहले आपको एक लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

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

> 💡 **ध्यान दें:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से प्राप्त होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करती है। नीचे दी गई छवि दर्शाती है कि PowerPoint में मास्टर स्लाइड्स और उनके संबंधित लेआउट कैसे व्यवस्थित होते हैं।

![मास्टर और लेआउट संबंध](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुँचें**

आप स्लाइड्स को उनके इंडेक्स का उपयोग करके एक्सेस कर सकते हैं, या किसी संदर्भ के आधार पर स्लाइड का इंडेक्स खोज सकते हैं। यह विशिष्ट स्लाइड्स को क्रमबद्ध करने या संशोधित करने में उपयोगी होता है।

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // एक और खाली स्लाइड जोड़ें।
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // स्लाइड्स को इंडेक्स द्वारा एक्सेस करें।
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // किसी रेफ़रेंस से स्लाइड का इंडेक्स प्राप्त करें, फिर उसे इंडेक्स द्वारा एक्सेस करें।
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाए। क्लोन की गई स्लाइड स्वतः स्लाइड संग्रह के अंत में जोड़ दी जाती है।

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

आप किसी स्लाइड को नए इंडेक्स पर ले जाकर स्लाइड्स का क्रम बदल सकते हैं। इस उदाहरण में, हम क्लोन की गई स्लाइड को पहले स्थान पर ले जाते हैं।

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

स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `remove` को कॉल करें। इस उदाहरण में एक दूसरी स्लाइड जोड़ी जाती है और फिर मूल स्लाइड को हटाया जाता है, जिससे केवल नई स्लाइड बचती है।

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