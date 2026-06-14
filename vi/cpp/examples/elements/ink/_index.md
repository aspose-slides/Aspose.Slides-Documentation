---
title: Mực
type: docs
weight: 180
url: /vi/cpp/examples/elements/ink/
keywords:
- ví dụ mã
- mực
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Làm việc với Mực trong Aspose.Slides cho C++: vẽ, nhập và chỉnh sửa các nét mực, điều chỉnh màu và độ rộng, và xuất ra PPT, PPTX, và ODP bằng các ví dụ C++."
---
Bài viết này cung cấp các ví dụ về việc truy cập các hình mực hiện có và xóa chúng bằng **Aspose.Slides for C++**.

> ❗ **Note:** Các hình mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới một cách lập trình, nhưng bạn có thể đọc và chỉnh sửa các nét mực hiện có.

## **Truy cập mực**

Đọc các thẻ từ hình mực đầu tiên trên một slide.

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
            // Sử dụng tagName khi cần.
        }
    }

    presentation->Dispose();
}
```

## **Xóa mực**

Xóa một hình mực khỏi slide nếu nó tồn tại.

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