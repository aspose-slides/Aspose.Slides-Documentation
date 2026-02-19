---
title: مجموعة الشكل
type: docs
weight: 170
url: /ar/cpp/examples/elements/group-shape/
keywords:
- مثال شفرة
- مجموعة شكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة الأشكال المجمعة في Aspose.Slides for C++: إنشاء، تضمين، محاذاة، إعادة ترتيب، وتنسيق مجموعات الأشكال باستخدام أمثلة C++ في عروض PPT و PPTX و ODP."
---
أمثلة لإنشاء مجموعات من الأشكال، والوصول إليها، وإلغاء تجميعها، وإزالتها باستخدام **Aspose.Slides for C++**.

## **إضافة شكل مجموعة**

إنشاء مجموعة تحتوي على شكلين أساسيين.

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

## **الوصول إلى شكل مجموعة**

استرجاع شكل المجموعة الأول من الشريحة.

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

## **إزالة شكل مجموعة**

حذف شكل مجموعة من الشريحة.

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

## **إلغاء تجميع الأشكال**

نقل الأشكال خارج حاوية المجموعة.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // نقل الشكل خارج المجموعة.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```