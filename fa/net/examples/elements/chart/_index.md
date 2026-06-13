---
title: نمودار
type: docs
weight: 60
url: /fa/net/examples/elements/chart/
keywords:
  - نمودار
  - افزودن نمودار
  - دسترسی به نمودار
  - حذف نمودار
  - به‌روزرسانی نمودار
  - مثال کد
  - PowerPoint
  - OpenDocument
  - ارائه
  - .NET
  - C#
  - Aspose.Slides
description: "نمودارها را با Aspose.Slides for .NET به‌کار ببندید: ایجاد، قالب‌بندی، اتصال داده‌ها و صادرات نمودارها در فرمت‌های PPT، PPTX و ODP با مثال‌های C#."
---
نمونه‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودار با **Aspose.Slides for .NET**. قطعه کدهای زیر عملیات پایه‌ای نمودار را نشان می‌دهند.

## **افزودن نمودار**

این روش یک نمودار ناحیه ساده را به اولین اسلاید اضافه می‌کند.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // یک نمودار ناحیه ساده به اسلاید اول اضافه می‌کند.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **دسترسی به نمودار**

پس از ایجاد یک نمودار، می‌توانید آن را از طریق مجموعهٔ شکل‌ها بازیابی کنید.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // دسترسی به اولین نمودار در اسلاید.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **حذف نمودار**

کد زیر یک نمودار را از یک اسلاید حذف می‌کند.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // حذف نمودار.
    slide.Shapes.Remove(chart);
}
```

## **به‌روزرسانی داده‌های نمودار**

می‌توانید ویژگی‌های نمودار را مانند عنوان تغییر دهید.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // تغییر عنوان نمودار.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```