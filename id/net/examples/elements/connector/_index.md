---
title: Konektor
type: docs
weight: 190
url: /id/net/examples/elements/connector/
keywords:
- konektor
- menambahkan konektor
- mengakses konektor
- menghapus konektor
- menyambungkan kembali bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan, mengarahkan, dan memberi gaya konektor antara bentuk menggunakan Aspose.Slides untuk .NET, dengan contoh C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menghubungkan bentuk dengan konektor dan mengubah targetnya menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Konektor**

Masukkan bentuk konektor di antara dua titik pada slide.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Mengakses Konektor**

Ambil bentuk konektor pertama yang ditambahkan ke slide.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Menghapus Konektor**

Hapus konektor dari slide.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Menyambungkan Kembali Bentuk**

Lampirkan konektor ke dua bentuk dengan menetapkan target mulai dan akhir.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```