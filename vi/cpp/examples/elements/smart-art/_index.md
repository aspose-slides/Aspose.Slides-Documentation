---
title: SmartArt
type: docs
weight: 140
url: /vi/cpp/examples/elements/smart-art/
keywords:
- ví dụ mã
- SmartArt
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Làm việc với SmartArt trong Aspose.Slides cho C++: tạo, chỉnh sửa, chuyển đổi và thiết kế các sơ đồ bằng C++ cho các bài thuyết trình PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng cách sử dụng **Aspose.Slides for C++**.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng một trong các bố cục có sẵn.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

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

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

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

## **Thay đổi bố cục SmartArt**

Cập nhật loại bố cục của một đồ họa SmartArt hiện có.

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