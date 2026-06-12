---
title: Header Footer
type: docs
weight: 220
url: /id/net/examples/elements/header-footer/
keywords:
- header footer
- menambahkan header footer
- memperbarui header footer
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides untuk .NET: tambahkan tanggal, nomor slide, dan teks khusus dalam PPT, PPTX, dan ODP dengan contoh C#."
---
Artikel ini menunjukkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Footer**

Tambahkan teks ke area footer slide dan buat agar terlihat.

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

Ubah placeholder tanggal dan waktu pada slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```