---
title: Bagian
type: docs
weight: 90
url: /id/net/examples/elements/section/
keywords:
- bagian
- bagian slide
- menambah bagian
- mengakses bagian
- menghapus bagian
- mengganti nama bagian
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola bagian slide di Aspose.Slides untuk .NET: buat, ganti nama, urutkan ulang, dan kelompokkan slide dengan contoh C# untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Bagian**

Buat sebuah bagian yang dimulai pada slide tertentu.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tentukan slide yang menandai awal bagian.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Mengakses Bagian**

Baca informasi bagian dari sebuah presentasi.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Akses bagian berdasarkan indeks.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Menghapus Bagian**

Hapus bagian yang sebelumnya ditambahkan.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Hapus bagian pertama.
    presentation.Sections.RemoveSection(section);
}
```

## **Mengganti Nama Bagian**

Ubah nama bagian yang ada.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```