---
title: جدول
type: docs
weight: 120
url: /ar/net/examples/elements/table/
keywords:
- مثال جدول
- إضافة جدول
- الوصول إلى جدول
- إزالة جدول
- دمج خلايا
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتنسيق الجداول في C# باستخدام Aspose.Slides: إدخال البيانات، دمج الخلايا، تنسيق الحدود، محاذاة المحتوى، والاستيراد/التصدير لملفات PPT و PPTX و ODP."
---

أمثلة لإضافة الجداول، الوصول إليها، إزالتها، ودمج الخلايا باستخدام **Aspose.Slides for .NET**.

## Add a Table
إضافة جدول

Create a simple table with two rows and two columns.
إنشاء جدول بسيط يتكون من صفين وعمودين.
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## Access a Table
الوصول إلى جدول

Retrieve the first table shape on the slide.
استرجاع أول شكل جدول في الشريحة.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // الوصول إلى أول جدول في الشريحة
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## Remove a Table
إزالة جدول

Delete a table from a slide.
حذف جدول من الشريحة.
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## Merge Table Cells
دمج خلايا الجدول

Merge adjacent cells of a table into a single cell.
دمج الخلايا المتجاورة في جدول إلى خلية واحدة.
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
