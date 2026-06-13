---
title: جدول
type: docs
weight: 120
url: /fa/net/examples/elements/table/
keywords:
- جدول
- افزودن جدول
- دسترسی به جدول
- حذف جدول
- ادغام سلول‌ها
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با جدول‌ها در Aspose.Slides برای .NET: ایجاد، قالب‌بندی، ادغام سلول‌ها، اعمال سبک‌ها، وارد کردن داده‌ها و خروجی‌گیری با مثال‌های C# برای PPT، PPTX و ODP."
---
نمونه‌هایی برای افزودن جدول‌ها، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for .NET**.

## **Add a Table**

یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **Access a Table**

شکل جدول اول موجود در اسلاید را بازیابی کنید.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // دسترسی به اولین جدول در اسلاید.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Remove a Table**

یک جدول را از اسلاید حذف کنید.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **Merge Table Cells**

سلول‌های مجاور یک جدول را به یک سلول واحد ادغام کنید.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```