---
title: Nhóm Hình
type: docs
weight: 170
url: /vi/cpp/examples/elements/group-shape/
keywords:
- ví dụ mã
- nhóm hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các hình dạng được nhóm trong Aspose.Slides for C++: tạo, lồng, căn chỉnh, sắp xếp lại và tạo kiểu cho nhóm hình với các ví dụ C++ trong các bản trình chiếu PPT, PPTX và ODP."
---
Các ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bằng **Aspose.Slides for C++**.

## **Thêm một Nhóm Hình**

Tạo một nhóm chứa hai hình dạng cơ bản.

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

## **Truy cập một Nhóm Hình**

Lấy nhóm hình đầu tiên từ một slide.

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

## **Xóa một Nhóm Hình**

Xóa một nhóm hình khỏi slide.

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

## **Tách Nhóm Hình**

Di chuyển các hình ra khỏi container nhóm.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Di chuyển hình ra khỏi nhóm.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```