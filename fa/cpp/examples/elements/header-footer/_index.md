---
title: سرصفحه پاورقی
type: docs
weight: 220
url: /fa/cpp/examples/elements/header-footer/
keywords:
- نمونه کد
- سرصفحه
- پاورقی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "سرصفحه‌ها و پاورقی‌های اسلایدها را با Aspose.Slides for C++ کنترل کنید: تاریخ‌ها، شماره اسلایدها و متن‌های سفارشی را در فرمت‌های PPT, PPTX و ODP با مثال‌های C++ اضافه کنید."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کنید و نگهدارنده‌های تاریخ و زمان را به‌روزرسانی کنید با استفاده از **Aspose.Slides for C++**.

## **افزودن پاورقی**

متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **به‌روزرسانی تاریخ و زمان**

نگهدارندهٔ تاریخ و زمان را در یک اسلاید اصلاح کنید.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```