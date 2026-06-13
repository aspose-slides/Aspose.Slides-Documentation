---
title: स्लाइड
type: docs
weight: 10
url: /hi/net/examples/elements/slide/
keywords:
- स्लाइड
- स्लाइड जोड़ें
- स्लाइड तक पहुँचें
- स्लाइड अनुक्रमणिका
- स्लाइड क्लोन करें
- स्लाइड्स का क्रम बदलें
- स्लाइड हटाएँ
- कोड उदाहरण
- पावरपॉइंट
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड्स को नियंत्रित करें: PPT, PPTX और ODP प्रस्तुतियों के लिए C# के साथ स्लाइड बनाना, क्लोन करना, क्रम बदलना, आकार बदलना, पृष्ठभूमि सेट करना और ट्रांज़िशन लागू करना।"
---
यह लेख कई उदाहरण प्रदान करता है जो **Aspose.Slides for .NET** का उपयोग करके स्लाइड्स के साथ काम करने का प्रदर्शन करते हैं। आप `Presentation` क्लास का उपयोग करके स्लाइड्स को जोड़ना, एक्सेस करना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में एक संक्षिप्त विवरण और उसके बाद C# में कोड स्निपेट शामिल है।

## **एक स्लाइड जोड़ें**

एक नई स्लाइड जोड़ने के लिए, आपको पहले एक लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // प्रत्येक स्लाइड एक लेआउट पर आधारित होती है, जो स्वयं एक मास्टर स्लाइड पर आधारित होता है।
    // नई स्लाइड बनाने के लिए Blank लेआउट का उपयोग करें।
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // चयनित लेआउट का उपयोग करके नई खाली स्लाइड जोड़ें।
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Note:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करता है। नीचे की छवि दर्शाती है कि PowerPoint में मास्टर स्लाइड्स और उनके संबंधित लेआउट कैसे व्यवस्थित हैं।

![मास्टर और लेआउट संबंध](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुँच**

आप स्लाइड्स को उनके इंडेक्स का उपयोग करके एक्सेस कर सकते हैं, या किसी संदर्भ के आधार पर स्लाइड का इंडेक्स पा सकते हैं। यह विशिष्ट स्लाइड्स के माध्यम से पुनरावृत्ति या उन्हें संशोधित करने में उपयोगी है।

```csharp
static void AccessSlide()
{
    // डिफ़ॉल्ट रूप से, एक प्रस्तुति एक खाली स्लाइड के साथ बनाई जाती है।
    using var presentation = new Presentation();

    // एक और खाली स्लाइड जोड़ें।
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // स्लाइड्स को इंडेक्स द्वारा एक्सेस करें।
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // किसी रेफ़रेंस से स्लाइड इंडेक्स प्राप्त करें, फिर इसे इंडेक्स द्वारा एक्सेस करें।
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **एक स्लाइड क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाए। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड संग्रह के अंत में जोड़ी जाती है।

```csharp
static void CloneSlide()
{
    // डिफ़ॉल्ट रूप से, प्रस्तुति में एक खाली स्लाइड होती है।
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // पहली स्लाइड को क्लोन करें; यह प्रस्तुति के अंत में जोड़ी जाएगी।
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // क्लोन की गई स्लाइड का इंडेक्स 1 है (प्रस्तुति में दूसरी स्लाइड)।
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **स्लाइड्स का क्रम बदलें**

आप एक स्लाइड को नए इंडेक्स पर ले जाकर स्लाइड्स का क्रम बदल सकते हैं। इस मामले में, हम क्लोन की गई स्लाइड को पहले स्थान पर ले जाते हैं।

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // पहले स्लाइड की एक क्लोन जोड़ें (डिफ़ॉल्ट रूप से बनाई गई)।
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // क्लोन की हुई स्लाइड को पहले स्थान पर ले जाएँ (बाकी नीचे की ओर शिफ्ट हो जाते हैं)।
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **एक स्लाइड हटाएँ**

एक स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `Remove` को कॉल करें। यह उदाहरण एक दूसरी स्लाइड जोड़ता है और फिर मूल स्लाइड को हटाता है, जिससे केवल नई स्लाइड बची रहती है।

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // डिफ़ॉल्ट पहली स्लाइड के अतिरिक्त एक नई खाली स्लाइड जोड़ें।
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // पहली स्लाइड हटाएँ; केवल नई जोड़ी गई स्लाइड बची रहेगी।
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```