---
title: Header Footer
type: docs
weight: 220
url: /id/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- header footer
- tambahkan header footer
- perbarui header footer
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides for .NET: tambahkan tanggal, nomor slide, dan teks khusus di PPT, PPTX, dan ODP dengan contoh C#."
---
Artikel ini menjelaskan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for .NET**.

## **Tambahkan Footer**

Tambahkan teks ke area footer sebuah slide dan buat agar terlihat.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada sebuah slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```