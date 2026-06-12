---
title: Slide
type: docs
weight: 10
url: /id/net/examples/elements/slide/
keywords:
- slide
- tambah slide
- akses slide
- indeks slide
- gandakan slide
- ubah urutan slide
- hapus slide
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kontrol slide dalam Aspose.Slides untuk .NET: buat, gandakan, ubah urutan, ubah ukuran, atur latar belakang, dan terapkan transisi dengan C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for .NET**. Anda akan belajar cara menambah, mengakses, menggandakan, mengubah urutan, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti oleh cuplikan kode dalam C#.

## **Tambah Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Dalam contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Setiap slide didasarkan pada tata letak, yang juga didasarkan pada slide master.
    // Gunakan tata letak Blank untuk membuat slide baru.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Tambahkan slide kosong baru menggunakan tata letak yang dipilih.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Catatan:** Setiap tata letak slide diturunkan dari slide master, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah ini menggambarkan bagaimana slide master dan tata letaknya yang terkait diatur dalam PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Akses Slide berdasarkan Indeks**

Anda dapat mengakses slide menggunakan indeksnya, atau menemukan indeks slide berdasarkan referensi. Ini berguna untuk iterasi atau memodifikasi slide tertentu.

```csharp
static void AccessSlide()
{
    // Secara default, presentasi dibuat dengan satu slide kosong.
    using var presentation = new Presentation();

    // Tambahkan slide kosong lain.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Akses slide berdasarkan indeks.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Dapatkan indeks slide dari referensi, lalu akses dengan indeks.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Gandakan Slide**

Contoh ini menunjukkan cara menggandakan slide yang ada. Slide yang digandakan secara otomatis ditambahkan ke akhir koleksi slide.

```csharp
static void CloneSlide()
{
    // Secara default, presentasi berisi satu slide kosong.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Gandakan slide pertama; slide tersebut akan ditambahkan di akhir presentasi.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Indeks slide yang digandakan adalah 1 (slide kedua dalam presentasi).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Ubah Urutan Slide**

Anda dapat mengubah urutan slide dengan memindahkan satu ke indeks baru. Dalam kasus ini, kami memindahkan slide yang digandakan ke posisi pertama.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Tambahkan klon slide pertama (dibuat secara default).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Pindahkan slide yang diklon ke posisi pertama (yang lain bergeser ke bawah).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Hapus Slide**

Untuk menghapus slide, cukup referensikan dan panggil `Remove`. Contoh ini menambahkan slide kedua lalu menghapus slide yang asli, sehingga hanya slide baru yang tersisa.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Tambahkan slide kosong baru selain slide pertama default.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Hapus slide pertama; hanya slide yang baru ditambahkan yang akan tetap ada.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```