---
title: شکل گروهی
type: docs
weight: 170
url: /fa/cpp/examples/elements/group-shape/
keywords:
- مثال کد
- شکل گروهی
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "شکل‌های گروهی را در Aspose.Slides for C++ مدیریت کنید: ایجاد، تو در تو کردن، تراز کردن، ترتیب دوباره، و استایل دادن به شکل‌های گروهی با مثال‌های C++ در ارائه‌های PPT، PPTX و ODP."
---
مثال‌هایی برای ایجاد گروه‌های اشکال، دسترسی به آن‌ها، جداسازی گروه‌ها و حذف با استفاده از **Aspose.Slides for C++**.

## **افزودن یک شکل گروهی**

یک گروه شامل دو شکل پایه ایجاد کنید.

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

## **دسترسی به یک شکل گروهی**

اولین شکل گروهی را از یک اسلاید بازیابی کنید.

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

## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

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

## **جداسازی اشکال**

اشکال را از داخل یک محفظه گروهی بیرون ببرید.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // شکل را از گروه خارج کنید.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```