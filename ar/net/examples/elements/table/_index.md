---
title: جدول
type: docs
weight: 120
url: /ar/net/examples/elements/table/
keywords:
- جدول
- إضافة جدول
- الوصول إلى جدول
- إزالة جدول
- دمج خلايا
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "التعامل مع الجداول في Aspose.Slides for .NET: إنشاء، تنسيق، دمج الخلايا، تطبيق الأنماط، استيراد البيانات، وتصدير مع أمثلة C# للـ PPT و PPTX و ODP."
---
أمثلة لإضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for .NET**.

## **إضافة جدول**

إنشاء جدول بسيط يتكون من صفين وعمودين.

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

## **الوصول إلى جدول**

استرجاع الشكل الجدولي الأول على الشريحة.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // الوصول إلى أول جدول على الشريحة.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **إزالة جدول**

حذف جدول من الشريحة.

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

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول إلى خلية واحدة.

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