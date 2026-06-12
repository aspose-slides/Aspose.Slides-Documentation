---
title: Tinta
type: docs
weight: 180
url: /id/net/examples/elements/ink/
keywords:
- tinta
- mengakses tinta
- menghapus tinta
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan Tinta di Aspose.Slides untuk .NET: gambar, impor, dan edit goresan, atur warna dan lebar, serta ekspor ke PPT, PPTX, dan ODP menggunakan contoh C#."
---
Artikel ini memberikan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for .NET**.

> ❗ **Catatan:** Bentuk tinta mewakili input pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatik, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.

## **Akses Tinta**

Baca tag dari bentuk tinta pertama pada slide.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Gunakan tagName sesuai kebutuhan.
        }
    }
}
```

## **Hapus Tinta**

Hapus bentuk tinta dari slide jika ada.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```