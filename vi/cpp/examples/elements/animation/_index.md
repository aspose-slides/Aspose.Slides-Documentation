---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/cpp/examples/elements/animation/
keywords:
- ví dụ mã
- hoạt ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá các ví dụ hoạt ảnh của Aspose.Slides for C++: thêm, sắp xếp và tùy chỉnh các hiệu ứng và chuyển đổi bằng C++ cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách tạo các hoạt ảnh đơn giản và quản lý chuỗi của chúng bằng **Aspose.Slides for C++**.

## **Thêm một Hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng xuất hiện dần khi được kích hoạt bằng cú nhấp chuột.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Hiệu ứng mờ.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Truy cập một Hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Truy cập hiệu ứng hoạt ảnh đầu tiên.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Xóa một Hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi chuỗi.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Xóa hiệu ứng.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Sắp xếp Hoạt ảnh**

Thêm nhiều hiệu ứng và hiển thị thứ tự thực hiện của các hoạt ảnh.

```cpp
static void SequenceAnimations()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

    auto sequence = slide->get_Timeline()->get_MainSequence();
    sequence->AddEffect(shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    sequence->AddEffect(shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```