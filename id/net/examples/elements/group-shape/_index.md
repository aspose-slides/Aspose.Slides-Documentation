---
title: Bentuk Grup
type: docs
weight: 170
url: /id/net/examples/elements/group-shape/
keywords:
- grup
- menambahkan bentuk grup
- mengakses bentuk grup
- menghapus bentuk grup
- membongkar bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola bentuk yang dikelompokkan di Aspose.Slides untuk .NET: buat, susun berlapis, rata, urutkan kembali, dan gaya bentuk grup dengan contoh C# dalam presentasi PPT, PPTX, dan ODP."
---
Contoh pembuatan grup bentuk, mengaksesnya, membongkar grup, dan menghapus menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Bentuk Grup**

Buat grup yang berisi dua bentuk dasar.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Mengakses Bentuk Grup**

Ambil bentuk grup pertama dari slide.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Menghapus Bentuk Grup**

Hapus bentuk grup dari slide.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Membongkar Bentuk**

Pindahkan bentuk keluar dari kontainer grup.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Pindahkan bentuk keluar dari grup.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```