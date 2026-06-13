---
title: स्लाइड
type: docs
weight: 10
url: /hi/cpp/examples/elements/slide/
keywords:
- कोड उदाहरण
- स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड्स को नियंत्रित करें: C++ के साथ PPT, PPTX और ODP प्रस्तुतियों के लिए बनाएं, क्लोन करें, क्रम बदलें, आकार बदलें, बैकग्राउंड सेट करें और ट्रांज़िशन लागू करें।"
---
यह लेख एक श्रृंखला के उदाहरण प्रदान करता है जो **Aspose.Slides for C++** का उपयोग करके स्लाइड्स के साथ काम करने का प्रदर्शन करते हैं। आप `Presentation` क्लास का उपयोग करके स्लाइड जोड़ना, पहुंचना, क्लोन करना, क्रम बदलना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में एक संक्षिप्त व्याख्या और उसके बाद C++ में कोड स्निपेट शामिल है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए आपको पहले एक लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करके प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **नोट:** प्रत्येक स्लाइड लेआउट एक मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करता है। नीचे की छवि दर्शाती है कि PowerPoint में मास्टर स्लाइड्स और उनके संबंधित लेआउट कैसे व्यवस्थित होते हैं।

![मास्टर और लेआउट संबंध](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुंचें**

आप स्लाइड्स को उनके इंडेक्स से पहुंच सकते हैं, या किसी संदर्भ के आधार पर स्लाइड का इंडेक्स खोज सकते हैं। यह विशेष स्लाइड्स को दोहराने या संशोधित करने के लिए उपयोगी है।

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // एक और खाली स्लाइड जोड़ें।
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // इंडेक्स द्वारा स्लाइड्स तक पहुंचें।
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // किसी संदर्भ से स्लाइड इंडेक्स प्राप्त करें, फिर इसे इंडेक्स द्वारा पहुंचें।
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **स्लाइड क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को क्लोन कैसे किया जाता है। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड कलेक्शन के अंत में जोड़ दी जाती है।

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **स्लाइड्स का क्रम बदलें**

आप स्लाइड के क्रम को बदल सकते हैं, एक स्लाइड को नए इंडेक्स पर ले जाकर। इस मामले में, हम क्लोन की गई स्लाइड को पहले स्थान पर ले जाते हैं।

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **स्लाइड हटाएँ**

स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `Remove` को कॉल करें। यह उदाहरण एक दूसरी स्लाइड जोड़ता है और फिर मूल स्लाइड को हटाता है, जिससे केवल नई स्लाइड बचती है।

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```