---
title: Tablo
type: docs
weight: 120
url: /tr/net/examples/elements/table/
keywords:
- tablo
- tablo ekle
- tabloya eriş
- tablo kaldır
- hücreleri birleştir
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te tablolarla çalışın: oluştur, biçimlendir, hücreleri birleştir, stiller uygula, veri içe aktar ve PPT, PPTX ve ODP için C# örnekleriyle dışa aktar."
---
Aspose.Slides for .NET kullanarak tablo ekleme, tabloya erişme, tablo silme ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

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

## **Tabloya Eriş**

Slayttaki ilk tablo şekline erişin.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Slayttaki ilk tabloya eriş.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Tabloyu Kaldır**

Bir slayttan tabloyu silin.

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

## **Tablo Hücrelerini Birleştir**

Bir tablonun yan yana hücrelerini tek bir hücreye birleştirin.

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