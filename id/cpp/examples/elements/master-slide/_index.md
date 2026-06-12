---
title: Slide Master
type: docs
weight: 30
url: /id/cpp/examples/elements/master-slide/
keywords:
- contoh kode
- slide master
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Jelajahi contoh master slide Aspose.Slides for C++: buat, edit, dan atur gaya master, placeholder, serta tema dalam PPT, PPTX, dan ODP dengan kode C++ yang jelas."
---
Master slide membentuk tingkat teratas dalam hierarki pewarisan slide di PowerPoint. **Master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slide** mewarisi dari master slide, dan **normal slide** mewarisi dari layout slide.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slide menggunakan Aspose.Slides for C++.

## **Menambahkan Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan mengkloning yang default. Kemudian menambahkan spanduk nama perusahaan ke semua slide melalui pewarisan layout.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Klon master slide default.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Tambahkan spanduk dengan nama perusahaan di bagian atas master slide.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Tetapkan master slide baru ke layout slide.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Tetapkan layout slide ke slide pertama dalam presentasi.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Catatan 1:** Master slide menyediakan cara untuk menerapkan merek konsisten atau elemen desain bersama di semua slide. Setiap perubahan yang dibuat pada master akan secara otomatis tercermin pada layout dan normal slide yang bergantung.

> 💡 **Catatan 2:** Setiap bentuk atau pemformatan yang ditambahkan ke master slide diwariskan oleh layout slide dan, pada gilirannya, semua normal slide yang menggunakan layout tersebut.
> Gambar di bawah menggambarkan bagaimana kotak teks yang ditambahkan pada master slide secara otomatis ditampilkan pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Mengakses Master Slide**

Anda dapat mengakses master slide menggunakan koleksi master presentasi. Berikut cara mengambil dan bekerja dengannya:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Ubah jenis latar belakang.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Menghapus Master Slide**

Master slide dapat dihapus baik berdasarkan indeks maupun referensi.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Hapus master slide berdasarkan indeks.
    presentation->get_Masters()->RemoveAt(0);

    // Hapus master slide berdasarkan referensi.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Menghapus Master Slide yang Tidak Digunakan**

Beberapa presentasi berisi master slide yang tidak digunakan. Menghapus slide ini dapat membantu mengurangi ukuran file.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Hapus semua master slide yang tidak digunakan (bahkan yang ditandai sebagai Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```