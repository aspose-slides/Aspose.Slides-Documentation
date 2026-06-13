---
title: सेक्शन
type: docs
weight: 90
url: /hi/cpp/examples/elements/section/
keywords:
- कोड उदाहरण
- सेक्शन
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड सेक्शन प्रबंधित करें: C++ उदाहरणों के साथ PPT, PPTX, और ODP के लिए स्लाइड बनाएं, नाम बदलें, पुनर्व्यवस्थित करें और समूहित करें।"
---
प्रेज़ेंटेशन सेक्शन को प्रोग्रामेटिक रूप से जोड़ने, एक्सेस करने, हटाने और पुनः नाम देने के उदाहरण **Aspose.Slides for C++** का उपयोग करके।

## **सेक्शन जोड़ें**

एक विशिष्ट स्लाइड से शुरू होने वाला सेक्शन बनाएं।

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // सेक्शन की शुरुआत को चिह्नित करने वाली स्लाइड निर्दिष्ट करें।
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **सेक्शन तक पहुँचें**

प्रेज़ेंटेशन से सेक्शन जानकारी पढ़ें।

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // इंडेक्स द्वारा सेक्शन तक पहुँचें।
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **सेक्शन हटाएँ**

पहले जोड़ा गया सेक्शन हटाएँ।

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // पहला सेक्शन हटाएँ।
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **सेक्शन का नाम बदलें**

मौजूदा सेक्शन का नाम बदलें।

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```