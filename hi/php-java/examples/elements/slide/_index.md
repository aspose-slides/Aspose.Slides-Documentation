---
title: स्लाइड
type: docs
weight: 10
url: /hi/php-java/examples/elements/slide/
keywords:
- स्लाइड
- स्लाइड जोड़ें
- स्लाइड एक्सेस करें
- स्लाइड इंडेक्स
- स्लाइड क्लोन करें
- स्लाइड्स का क्रम बदलें
- स्लाइड हटाएँ
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड्स का प्रबंधन: निर्माण, क्लोन, क्रम बदलना, छिपाना, पृष्ठभूमि और आकार सेट करना, ट्रांज़िशन लागू करना, और PowerPoint तथा OpenDocument के लिए निर्यात करना।"
---
यह लेख उदाहरणों की एक श्रृंखला प्रदान करता है जो दिखाते हैं कि **Aspose.Slides for PHP via Java** का उपयोग करके स्लाइड्स के साथ कैसे काम किया जाए। आप `Presentation` क्लास का उपयोग करके स्लाइड्स को जोड़ना, एक्सेस करना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में एक संक्षिप्त व्याख्या और PHP में कोड स्निपेट शामिल है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए, आपको पहले लेआउट चुनना आवश्यक है। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // प्रत्येक स्लाइड एक लेआउट पर आधारित होती है, जो स्वयं एक मास्टर स्लाइड पर आधारित होता है।
        // नया स्लाइड बनाने के लिए ब्लैंक लेआउट का उपयोग करें।
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // चयनित लेआउट का उपयोग करके एक नया खाली स्लाइड जोड़ें।
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **सूचना:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करता है। नीचे की छवि दर्शाती है कि PowerPoint में मास्टर स्लाइड्स और उनके संबंधित लेआउट्स कैसे व्यवस्थित होते हैं।

![मास्टर और लेआउट संबंध](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुंचें**

आप स्लाइड्स को उनके इंडेक्स से एक्सेस कर सकते हैं।

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // इंडेक्स द्वारा एक स्लाइड तक पहुँचें।
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्लाइड क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाए। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड संग्रह के अंत में जोड़ दी जाती है।

```php
function cloneSlide() {
    // डिफॉल्ट रूप से, प्रस्तुति में एक खाली स्लाइड शामिल है।
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // पहली स्लाइड को क्लोन करें; यह प्रस्तुति के अंत में जोड़ी जाएगी।
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // क्लोन की गई स्लाइड का इंडेक्स 1 है (प्रस्तुति में दूसरी स्लाइड)।
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्लाइड्स का क्रम बदलें**

आप स्लाइड्स के क्रम को बदल सकते हैं, एक स्लाइड को नए इंडेक्स पर ले जाकर। इस मामले में, हम एक स्लाइड को पहली स्थिति में ले जाते हैं।

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // स्लाइड को पहले स्थान पर ले जाएँ (बाकी नीचे शिफ्ट हो जाएंगे)।
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **स्लाइड हटाएँ**

स्लाइड को हटाने के लिए, बस उसका संदर्भ दें और `remove` को कॉल करें। यह उदाहरण इंडेक्स और संदर्भ द्वारा स्लाइड्स को हटाता है।

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // इंडेक्स द्वारा एक स्लाइड हटाएँ।
        $presentation->getSlides()->removeAt(0);

        // रेफ़रेंस द्वारा एक स्लाइड हटाएँ।
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```