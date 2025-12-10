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
description: "إنشاء وتنسيق الجداول في C# باستخدام Aspose.Slides: إدراج البيانات، دمج الخلايا، تنسيق الحدود، محاذاة المحتوى، والاستيراد/التصدير لـ PPT و PPTX و ODP."
---

أمثلة لإضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for .NET**.

## **إضافة جدول**

إنشاء جدول بسيط مكوّن من صفين وعمودين.
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


## **الوصول إلى جدول**

استرجاع الشكل الأول للجدول في الشريحة.
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // الوصول إلى الجدول الأول في الشريحة
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## **إزالة جدول**

حذف جدول من شريحة.
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


## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في الجدول لتصبح خلية واحدة.
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
