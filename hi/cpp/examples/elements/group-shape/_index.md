---
title: समूह आकृति
type: docs
weight: 170
url: /hi/cpp/examples/elements/group-shape/
keywords:
- कोड उदाहरण
- समूह आकृति
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में समूहित आकारों को प्रबंधित करें: C++ उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों में समूह आकार बनाएं, नेस्ट करें, संरेखित करें, क्रम बदलें और शैली लागू करें।"
---
**Aspose.Slides for C++** का उपयोग करके आकारों के समूह बनाने, उन्हें एक्सेस करने, अनग्रुप करने और हटाने के उदाहरण।

## **समूह आकृति जोड़ें**

दो बुनियादी आकारों को शामिल करने वाला एक समूह बनाएँ।

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **समूह आकृति तक पहुँचें**

स्लाइड से पहली समूह आकृति प्राप्त करें।

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **समूह आकृति हटाएँ**

स्लाइड से समूह आकृति हटाएँ।

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **आकारों को अनग्रुप करें**

आकारों को समूह कंटेनर से बाहर निकालें।

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // समूह से आकार को बाहर ले जाएँ.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```