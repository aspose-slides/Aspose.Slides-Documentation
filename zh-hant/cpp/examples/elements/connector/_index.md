---
title: 連接線
type: docs
weight: 190
url: /zh-hant/cpp/examples/elements/connector/
keywords:
- 程式碼範例
- 連接線
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for C++ 在形狀之間新增、路由與樣式化連接線，並提供 PPT、PPTX 與 ODP 簡報的範例。"
---
本文示範如何使用 **Aspose.Slides for C++** 連接形狀與連接線，並變更其目標。

## **新增連接線**

在投影片的兩個點之間插入連接線形狀。

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **存取連接線**

取得已新增至投影片的第一個連接線形狀。

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // 存取投影片上的第一個連接線。
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

## **移除連接線**

從投影片中刪除連接線。

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

## **重新連接形狀**

透過指派起始與結束目標，將連接線連接至兩個形狀。

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