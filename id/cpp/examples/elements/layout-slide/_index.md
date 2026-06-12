---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/cpp/examples/elements/layout-slide/
keywords:
- contoh kode
- slide tata letak
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi slide tata letak di Aspose.Slides untuk C++: pilih, terapkan, dan sesuaikan tata letak slide, placeholder, dan master dengan contoh C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** di Aspose.Slides untuk C++. Sebuah layout slide mendefinisikan desain dan pemformatan yang diwariskan oleh slide normal. Anda dapat menambahkan, mengakses, menggandakan, dan menghapus layout slide, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Tambah Layout Slide**

Anda dapat membuat layout slide kustom untuk mendefinisikan pemformatan yang dapat digunakan kembali. Sebagai contoh, Anda mungkin menambahkan kotak teks yang muncul pada semua slide yang menggunakan layout ini.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Buat slide tata letak dengan jenis tata letak kosong dan nama khusus.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Tambahkan kotak teks ke slide tata letak.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Tambahkan dua slide menggunakan tata letak ini; keduanya akan mewarisi teks dari tata letak.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Catatan 1:** Layout slides berfungsi sebagai templat untuk slide individu. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Saat Anda menambahkan bentuk atau teks ke layout slide, semua slide yang berbasis pada layout tersebut akan menampilkan konten bersama ini secara otomatis.  
> Tangkap layar di bawah menunjukkan dua slide, masing-masing mewarisi kotak teks dari layout slide yang sama.

![Slide yang Mewarisi Konten Layout](layout-slide-result.png)

## **Akses Layout Slide**

Layout slides dapat diakses berdasarkan indeks atau berdasarkan tipe layout (misalnya, `Blank`, `Title`, `SectionHeader`, dll.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Akses slide tata letak berdasarkan indeks.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Akses slide tata letak berdasarkan tipe.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Hapus Layout Slide**

Anda dapat menghapus layout slide tertentu jika tidak lagi diperlukan.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Dapatkan slide tata letak berdasarkan tipe dan hapus.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Hapus Layout Slide yang Tidak Digunakan**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus layout slide yang tidak digunakan oleh slide normal mana pun.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Secara otomatis menghapus semua slide tata letak yang tidak direferensikan oleh slide manapun.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Duplikat Layout Slide**

Anda dapat menggandakan layout slide menggunakan metode `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Dapatkan slide tata letak yang ada berdasarkan tipe.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Gandakan slide tata letak ke akhir koleksi slide tata letak.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Ringkasan:** Layout slides adalah alat yang kuat untuk mengelola pemformatan konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan optimalisasi layout slide.