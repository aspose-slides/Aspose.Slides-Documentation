---
title: موصل
type: docs
weight: 190
url: /ar/cpp/examples/elements/connector/
keywords:
- مثال على الكود
- موصل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وتوجيه وتنسيق الموصلات بين الأشكال باستخدام Aspose.Slides for C++، مع أمثلة لعروض PPT، PPTX، و ODP."
---
توضح هذه المقالة كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for C++**.

## **إضافة موصل**

أدرج شكل موصل بين نقطتين على الشريحة.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **الوصول إلى موصل**

استرجع أول شكل موصل تمت إضافته إلى الشريحة.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // الوصول إلى أول موصل على الشريحة.
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

## **إزالة موصل**

احذف موصلًا من الشريحة.

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

## **إعادة ربط الأشكال**

قم بإرفاق موصل إلى شكلين عن طريق تعيين أهداف البداية والنهاية.

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