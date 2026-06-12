---
title: Slide
type: docs
weight: 10
url: /id/cpp/examples/elements/slide/
keywords:
- contoh kode
- slide
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kontrol slide dalam Aspose.Slides untuk C++: buat, gandakan, ubah urutan, ubah ukuran, atur latar belakang, dan terapkan transisi dengan C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for C++**. Anda akan belajar cara menambah, mengakses, menggandakan, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini menyertakan penjelasan singkat diikuti oleh cuplikan kode dalam C++.

## **Add a Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Pada contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Catatan:** Setiap tata letak slide berasal dari master slide, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah menggambarkan bagaimana master slide dan tata letaknya yang terkait diatur dalam PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

Anda dapat mengakses slide menggunakan indeksnya, atau menemukan indeks slide berdasarkan referensi. Ini berguna untuk mengiterasi atau memodifikasi slide tertentu.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Tambah slide kosong lainnya.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Akses slide berdasarkan indeks.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Dapatkan indeks slide dari referensi, lalu akses berdasarkan indeks.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clone a Slide**

Contoh ini menunjukkan cara menggandakan slide yang ada. Slide yang digandakan secara otomatis ditambahkan ke akhir koleksi slide.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reorder Slides**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Pada kasus ini, kami memindahkan slide yang digandakan ke posisi pertama.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Remove a Slide**

Untuk menghapus slide, cukup referensikan dan panggil `Remove`. Contoh ini menambahkan slide kedua lalu menghapus slide asli, sehingga hanya slide baru yang tersisa.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```