---
title: Diagram
type: docs
weight: 60
url: /id/net/examples/elements/chart/
keywords:
- diagram
- tambahkan diagram
- akses diagram
- hapus diagram
- perbarui diagram
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasi diagram dengan Aspose.Slides untuk .NET: buat, format, kaitkan data, dan ekspor diagram dalam PPT, PPTX, dan ODP dengan contoh C#."
---
Contoh untuk menambahkan, mengakses, menghapus, dan memperbarui berbagai jenis diagram dengan **Aspose.Slides for .NET**. Potongan kode di bawah ini memperlihatkan operasi dasar diagram.

## **Tambahkan Diagram**

Metode ini menambahkan diagram area sederhana ke slide pertama.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tambahkan diagram area sederhana ke slide pertama.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Akses Diagram**

Setelah membuat diagram, Anda dapat mengambilnya melalui koleksi shape.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Akses diagram pertama pada slide.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Hapus Diagram**

Kode berikut menghapus diagram dari sebuah slide.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Hapus diagram.
    slide.Shapes.Remove(chart);
}
```

## **Perbarui Data Diagram**

Anda dapat mengubah properti diagram seperti judul.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Ubah judul diagram.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```