---
title: Tabel
type: docs
weight: 120
url: /id/net/examples/elements/table/
keywords:
- tabel
- tambah tabel
- mengakses tabel
- menghapus tabel
- menggabungkan sel
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan tabel di Aspose.Slides untuk .NET: membuat, memformat, menggabungkan sel, menerapkan gaya, mengimpor data, dan mengekspor dengan contoh C# untuk PPT, PPTX, dan ODP."
---
Contoh menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for .NET**.

## **Tambah Tabel**

Buat tabel sederhana dengan dua baris dan dua kolom.

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

## **Akses Tabel**

Ambil bentuk tabel pertama pada slide.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Akses tabel pertama pada slide.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Hapus Tabel**

Hapus tabel dari slide.

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

## **Gabungkan Sel Tabel**

Gabungkan sel yang berdekatan pada tabel menjadi satu sel.

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