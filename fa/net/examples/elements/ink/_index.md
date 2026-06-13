---
title: جوهر
type: docs
weight: 180
url: /fa/net/examples/elements/ink/
keywords:
- جوهر
- دسترسی به جوهر
- حذف جوهر
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با جوهر در Aspose.Slides برای .NET: رسم، وارد کردن و ویرایش خطوط، تنظیم رنگ و ضخامت، و صادر کردن به PPT، PPTX و ODP با استفاده از مثال‌های C#."
---
این مقاله نمونه‌هایی از دسترسی به اشکال جوهر موجود و حذف آن‌ها با استفاده از **Aspose.Slides for .NET** را ارائه می‌دهد.

> ❗ **توجه:** اشکال جوهر ورودی کاربر را از دستگاه‌های تخصصی نمایند. Aspose.Slides نمی‌تواند خطوط جوهر جدید را به‌صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و اصلاح کنید.

## **دسترسی به جوهر**

برچسب‌ها را از اولین شکل جوهر در یک اسلاید بخوانید.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // در صورت نیاز از tagName استفاده کنید.
        }
    }
}
```

## **حذف جوهر**

اگر یک شکل جوهر وجود داشته باشد، آن را از اسلاید حذف کنید.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```