---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- سرصفحه و پاورقی
- افزودن سرصفحه و پاورقی
- به‌روزرسانی سرصفحه و پاورقی
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "سرصفحه‌ها و پاورقی‌های اسلاید را با Aspose.Slides برای .NET کنترل کنید: تاریخ‌ها، شماره اسلاید و متن سفارشی را در PPT، PPTX و ODP با مثال‌های C# اضافه کنید."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کرده و مکان‌گیرهای تاریخ و زمان را با استفاده از **Aspose.Slides for .NET** به‌روز کنید.

## **افزودن پاورقی**
متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **به‌روزرسانی تاریخ و زمان**
مکان‌گیر تاریخ و زمان را در یک اسلاید اصلاح کنید.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```