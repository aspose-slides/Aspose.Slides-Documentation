---
title: Header Footer
type: docs
weight: 220
url: /id/cpp/examples/elements/header-footer/
keywords:
- contoh kode
- header
- footer
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kontrol header dan footer slide dengan Aspose.Slides untuk C++: tambahkan tanggal, nomor slide, dan teks khusus dalam PPT, PPTX, dan ODP dengan contoh C++."
---
Artikel ini menunjukkan cara menambahkan footer dan memperbarui placeholder tanggal dan waktu menggunakan **Aspose.Slides for C++**.

## **Tambahkan Footer**

Tambahkan teks ke area footer pada slide dan buat itu terlihat.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada slide.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```