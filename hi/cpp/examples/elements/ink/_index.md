---
title: इंक
type: docs
weight: 180
url: /hi/cpp/examples/elements/ink/
keywords:
- कोड उदाहरण
- इंक
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में इंक के साथ काम करें: स्ट्रोक बनाएं, आयात करें, और संपादित करें, रंग और चौड़ाई को समायोजित करें, और C++ उदाहरणों का उपयोग करके PPT, PPTX और ODP में निर्यात करें।"
---
यह लेख मौजूदा इंक आकृतियों तक पहुँचने और उन्हें हटाने के उदाहरण प्रदान करता है, **Aspose.Slides for C++** का उपयोग करके।

> ❗ **ध्यान दें:** इंक आकृतियाँ विशेष उपकरणों से उपयोगकर्ता इनपुट का प्रतिनिधित्व करती हैं। Aspose.Slides प्रोग्रामेटिक रूप से नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।

## **इंक तक पहुँचें**

स्लाइड पर पहली इंक आकृति से टैग पढ़ें।

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // आवश्यकतानुसार tagName का उपयोग करें।
        }
    }

    presentation->Dispose();
}
```

## **इंक हटाएँ**

यदि कोई इंक आकृति मौजूद है तो उसे स्लाइड से हटाएँ।

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```