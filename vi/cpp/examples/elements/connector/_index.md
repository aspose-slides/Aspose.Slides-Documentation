---
title: Kết nối
type: docs
weight: 190
url: /vi/cpp/examples/elements/connector/
keywords:
- ví dụ mã
- Kết nối
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm, định hướng và định dạng các connector giữa các shape bằng Aspose.Slides for C++, với các ví dụ cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng các connector và thay đổi mục tiêu của chúng bằng **Aspose.Slides for C++**.

## **Thêm một Connector**

Chèn một hình connector giữa hai điểm trên slide.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Truy cập một Connector**

Lấy hình connector đầu tiên được thêm vào slide.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Truy cập connector đầu tiên trên slide.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Xóa một Connector**

Xóa một connector khỏi slide.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Kết nối lại các Shape**

Gắn một connector vào hai shape bằng cách gán mục tiêu bắt đầu và kết thúc.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```