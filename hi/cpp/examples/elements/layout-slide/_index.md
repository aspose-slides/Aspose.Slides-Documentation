---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/cpp/examples/elements/layout-slide/
keywords:
- कोड उदाहरण
- लेआउट स्लाइड
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में लेआउट स्लाइड्स को मास्टर करें: स्लाइड लेआउट, प्लेसहोल्डर, और मास्टर को चुनें, लागू करें और अनुकूलित करें, साथ ही PPT, PPTX, और ODP प्रस्तुतियों के लिए C++ उदाहरणों के साथ।"
---
यह लेख Aspose.Slides for C++ में **Layout Slides** के साथ काम करने का तरीका दर्शाता है। एक लेआउट स्लाइड सामान्य स्लाइडों द्वारा विरासत में मिलने वाले डिज़ाइन और स्वरूपण को परिभाषित करती है। आप लेआउट स्लाइड को जोड़ सकते हैं, एक्सेस कर सकते हैं, क्लोन कर सकते हैं, और हटा सकते हैं, साथ ही अनउपयोगी स्लाइडों को साफ करके प्रस्तुति का आकार कम कर सकते हैं।

## **लेआउट स्लाइड जोड़ें**

आप एक कस्टम लेआउट स्लाइड बना सकते हैं ताकि पुन: उपयोग योग्य स्वरूपण परिभाषित किया जा सके। उदाहरण के लिए, आप इस लेआउट का उपयोग करने वाले सभी स्लाइडों में दिखाई देने वाला एक टेक्स्ट बॉक्स जोड़ सकते हैं।

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // एक खाली लेआउट प्रकार और कस्टम नाम के साथ लेआउट स्लाइड बनाएं।
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // लेआउट स्लाइड में एक टेक्स्ट बॉक्स जोड़ें।
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // इस लेआउट का उपयोग करके दो स्लाइडें जोड़ें; दोनों लेआउट से टेक्स्ट विरासत में पाएँगी।
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **नोट 1:** लेआउट स्लाइड व्यक्तिगत स्लाइडों के लिए टेम्पलेट के रूप में कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित कर सकते हैं और उन्हें कई स्लाइडों में पुनः उपयोग कर सकते हैं।  
> 💡 **नोट 2:** जब आप लेआउट स्लाइड में आकार या टेक्स्ट जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइडें यह साझा सामग्री स्वचालित रूप से प्रदर्शित करेंगी।  
> नीचे का स्क्रीनशॉट दो स्लाइडें दिखाता है, जिनमें प्रत्येक ने एक ही लेआउट स्लाइड से टेक्स्ट बॉक्स को विरासत में प्राप्त किया है।

![लेआउट सामग्री विरासत में लेने वाली स्लाइड्स](layout-slide-result.png)

## **लेआउट स्लाइड तक पहुँचें**

लेआउट स्लाइड को इंडेक्स या लेआउट प्रकार (जैसे `Blank`, `Title`, `SectionHeader` आदि) द्वारा एक्सेस किया जा सकता है।

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // इंडेक्स द्वारा लेआउट स्लाइड तक पहुँचें।
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // प्रकार द्वारा लेआउट स्लाइड तक पहुँचें।
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **लेआउट स्लाइड हटाएँ**

यदि कोई लेआउट स्लाइड अब आवश्यक नहीं है, तो आप इसे हटा सकते हैं।

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और हटाएँ।
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

प्रस्तुति का आकार घटाने के लिए, आप उन लेआउट स्लाइड्स को हटाना चाहेंगे जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की जाती हैं।

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // स्वचालित रूप से उन सभी लेआउट स्लाइड्स को हटाता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **लेआउट स्लाइड क्लोन करें**

आप `AddClone` विधि का उपयोग करके एक लेआउट स्लाइड को दोहराव (डुप्लिकेट) कर सकते हैं।

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें।
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // लेआउट स्लाइड को लेआउट स्लाइड संग्रह के अंत में क्लोन करें।
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **सारांश:** लेआउट स्लाइड स्लाइडों में सुसंगत स्वरूपण को प्रबंधित करने के लिए शक्तिशाली उपकरण हैं। Aspose.Slides लेआउट स्लाइड बनाने, प्रबंधित करने और अनुकूलित करने पर पूर्ण नियंत्रण प्रदान करता है।