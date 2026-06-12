---
title: Tautan Hiper
type: docs
weight: 130
url: /id/net/examples/elements/hyperlink/
keywords:
- tautan hiper
- tambahkan tautan hiper
- akses tautan hiper
- hapus tautan hiper
- perbarui tautan hiper
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tambahkan dan kelola tautan hiper di Aspose.Slides untuk .NET: tautkan teks, bentuk, dan gambar, atur target serta aksi untuk PPT, PPTX, dan ODP dengan contoh C#."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for .NET**.

## **Tambah Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang mengarah ke situs web eksternal.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Akses Hyperlink**

Baca informasi hyperlink dari bagian teks sebuah bentuk.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Hapus Hyperlink**

Hapus hyperlink dari teks sebuah bentuk.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Perbarui Hyperlink**

Ubah target hyperlink yang ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah mengandung hyperlink, yang meniru cara PowerPoint memperbarui hyperlink secara aman.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Mengubah hyperlink dalam teks yang ada sebaiknya dilakukan melalui
    // HyperlinkManager daripada mengatur properti secara langsung.
    // Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```