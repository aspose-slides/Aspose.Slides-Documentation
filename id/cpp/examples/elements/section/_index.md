---
title: Bagian
type: docs
weight: 90
url: /id/cpp/examples/elements/section/
keywords:
- contoh kode
- bagian
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola bagian slide di Aspose.Slides untuk C++: buat, ganti nama, urutkan ulang, dan kelompokkan slide dengan contoh C++ untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for C++**.

## **Menambahkan Bagian**

Buat bagian yang dimulai pada slide tertentu.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tentukan slide yang menandai awal bagian.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Mengakses Bagian**

Baca informasi bagian dari sebuah presentasi.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Akses bagian berdasarkan indeks.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Menghapus Bagian**

Hapus bagian yang sebelumnya ditambahkan.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Hapus bagian pertama.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Mengganti Nama Bagian**

Ubah nama bagian yang ada.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```