---
title: Chuyển đổi slide
type: docs
weight: 110
url: /vi/cpp/examples/elements/slide-transition/
keywords:
- ví dụ mã
- chuyển đổi slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Thành thạo chuyển đổi slide trong Aspose.Slides for C++: thêm, tùy chỉnh và sắp xếp các hiệu ứng và thời lượng với các ví dụ C++ cho bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển đổi slide và thời gian với **Aspose.Slides for C++**.

## **Thêm chuyển đổi slide**

Áp dụng hiệu ứng chuyển đổi mờ cho slide đầu tiên.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Áp dụng chuyển đổi mờ.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Truy cập chuyển đổi slide**

Đọc loại chuyển đổi hiện được gán cho một slide.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Truy cập loại chuyển đổi.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Xóa chuyển đổi slide**

Xóa mọi hiệu ứng chuyển đổi bằng cách đặt loại thành `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Xóa chuyển đổi bằng cách đặt không.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Đặt thời lượng chuyển đổi**

Chỉ định thời gian slide được hiển thị trước khi tự động chuyển sang slide tiếp theo.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // Bằng mili giây.

    presentation->Dispose();
}
```