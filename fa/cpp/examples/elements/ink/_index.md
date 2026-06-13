---
title: جوهر
type: docs
weight: 180
url: /fa/cpp/examples/elements/ink/
keywords:
- مثال کد
- جوهر
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "کار با جوهر در Aspose.Slides برای C++: رسم، وارد کردن و ویرایش خطوط، تنظیم رنگ و عرض، و صادرات به PPT، PPTX و ODP با استفاده از مثال‌های C++."
---
این مقاله مثال‌هایی از دسترسی به اشکال جوهر موجود و حذف آن‌ها با استفاده از **Aspose.Slides for C++** ارائه می‌دهد.

> ❗ **تذکر:** اشکال جوهر نمایانگر ورودی کاربر از دستگاه‌های تخصصی هستند. Aspose.Slides نمی‌تواند خطوط جوهر جدید را به صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و اصلاح کنید.

## **دسترسی به جوهر**

برچسب‌ها را از اولین شکل جوهر در یک اسلاید بخوانید.

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
            // در صورت نیاز از tagName استفاده کنید.
        }
    }

    presentation->Dispose();
}
```

## **حذف جوهر**

اگر موجود باشد، یک شکل جوهر را از اسلاید حذف کنید.

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