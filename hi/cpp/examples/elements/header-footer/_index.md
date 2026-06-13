---
title: हेडर फ़ूटर
type: docs
weight: 220
url: /hi/cpp/examples/elements/header-footer/
keywords:
- कोड उदाहरण
- हेडर
- फ़ूटर
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ स्लाइड हेडर और फ़ूटर नियंत्रित करें: PPT, PPTX और ODP में तिथियाँ, स्लाइड नंबर और कस्टम टेक्स्ट जोड़ें, C++ उदाहरणों के साथ।"
---
यह लेख **Aspose.Slides for C++** का उपयोग करके फ़ुटर जोड़ने और दिनांक व समय प्लेसहोल्डर को अपडेट करने का प्रदर्शन करता है।

## **फ़ुटर जोड़ें**

स्लाइड के फ़ुटर क्षेत्र में टेक्स्ट जोड़ें और इसे दृश्यमान बनाएं।

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **दिनांक और समय अपडेट करें**

स्लाइड पर दिनांक और समय प्लेसहोल्डर को संशोधित करें।

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```