---
title: اتصال‌گر
type: docs
weight: 190
url: /fa/cpp/examples/elements/connector/
keywords:
- مثال کد
- اتصال‌گر
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "نحوه افزودن، مسیریابی و استایل‌دادن به اتصالات بین اشکال با استفاده از Aspose.Slides برای C++ را با مثال‌هایی برای ارائه‌های PPT، PPTX و ODP بیاموزید."
---
این مقاله نشان می‌دهد چگونه اشکال را با اتصال‌گرها وصل کنید و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for C++** تغییر دهید.

## **افزودن یک اتصال‌گر**

یک شکل اتصال‌گر بین دو نقطه در اسلاید وارد کنید.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **دسترسی به یک اتصال‌گر**

اولین شکل اتصال‌گر اضافه شده به اسلاید را بازیابی کنید.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // دسترسی به اولین اتصال‌گر در اسلاید.
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

## **حذف یک اتصال‌گر**

یک اتصال‌گر را از اسلاید حذف کنید.

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

## **اتصال مجدد اشکال**

یک اتصال‌گر را به دو شکل با اختصاص هدف‌های شروع و پایان متصل کنید.

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