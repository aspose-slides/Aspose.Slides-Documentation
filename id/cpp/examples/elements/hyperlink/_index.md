---
title: Hyperlink
type: docs
weight: 130
url: /id/cpp/examples/elements/hyperlink/
keywords:
- contoh kode
- hyperlink
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Menambahkan dan mengelola hyperlink di Aspose.Slides untuk C++: menautkan teks, bentuk, dan gambar, mengatur target serta aksi untuk PPT, PPTX, dan ODP dengan contoh C++."
---
Artikel ini menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for C++**.

## **Menambahkan Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang menunjuk ke situs web eksternal.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Mengakses Hyperlink**

Baca informasi hyperlink dari bagian teks bentuk.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Menghapus Hyperlink**

Hapus hyperlink dari teks bentuk.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Memperbarui Hyperlink**

Ubah target hyperlink yang ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah berisi hyperlink, yang meniru cara PowerPoint memperbarui hyperlink secara aman.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Mengubah hyperlink di dalam teks yang ada sebaiknya dilakukan melalui
    // HyperlinkManager daripada mengatur properti secara langsung.
    // Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```