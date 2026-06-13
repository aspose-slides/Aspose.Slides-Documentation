---
title: स्मार्टआर्ट
type: docs
weight: 140
url: /hi/cpp/examples/elements/smart-art/
keywords:
- कोड उदाहरण
- स्मार्टआर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में SmartArt के साथ काम करें: C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों के लिए आरेख बनाएं, संपादित करें, रूपांतरित करें और शैली दें।"
---
यह लेख बताता है कि **Aspose.Slides for C++** का उपयोग करके SmartArt ग्राफ़िक्स को कैसे जोड़ें, उन तक कैसे पहुँचें, उन्हें कैसे हटाएँ, और लेआउट कैसे बदलें।

## **SmartArt जोड़ें**

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt तक पहुँचें**

स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें।

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **SmartArt हटाएँ**

स्लाइड से एक SmartArt आकार हटाएँ।

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **SmartArt लेआउट बदलें**

मौजूदा SmartArt ग्राफ़िक के लेआउट प्रकार को अपडेट करें।

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```