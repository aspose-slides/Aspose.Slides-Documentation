---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/net/examples/elements/header-footer/
keywords:
- سرصفحه و پاورقی
- افزودن سرصفحه و پاورقی
- به‌روزرسانی سرصفحه و پاورقی
- مثال کد
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با Aspose.Slides برای .NET کنترل سرصفحه‌ها و پاورقی‌های اسلاید را انجام دهید: تاریخ‌ها، شماره اسلاید و متن سفارشی را در قالب‌های PPT، PPTX و ODP با مثال‌های C# اضافه کنید."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کنید و مکان‌نگهدارهای تاریخ و زمان را با استفاده از **Aspose.Slides for .NET** به‌روزرسانی کنید.

## **Add a Footer**
افزودن یک پاورقی

Add text to the footer area of a slide and make it visible.
متن را به ناحیهٔ پاورقی اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Update Date and Time**
به‌روزرسانی تاریخ و زمان

Modify the date and time placeholder on a slide.
مکان‌نگهدار تاریخ و زمان را در یک اسلاید اصلاح کنید.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```