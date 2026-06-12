---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/net/examples/elements/layout-slide/
keywords:
- slide tata letak
- tambah slide tata letak
- akses slide tata letak
- hapus slide tata letak
- slide tata letak tidak terpakai
- gandakan slide tata letak
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola slide tata letak utama di Aspose.Slides untuk .NET: pilih, terapkan, dan sesuaikan tata letak slide, placeholder, dan master dengan contoh C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** di Aspose.Slides untuk .NET. Slide tata letak mendefinisikan desain dan pemformatan yang diwarisi oleh slide biasa. Anda dapat menambah, mengakses, menggandakan, dan menghapus slide tata letak, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Tambah Slide Tata Letak**

Anda dapat membuat slide tata letak khusus untuk mendefinisikan pemformatan yang dapat digunakan kembali. Misalnya, Anda dapat menambahkan kotak teks yang muncul di semua slide yang menggunakan tata letak ini.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Membuat slide tata letak dengan tipe tata letak kosong dan nama khusus.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Menambahkan kotak teks ke slide tata letak.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Menambahkan dua slide menggunakan tata letak ini; keduanya akan mewarisi teks dari tata letak.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Catatan 1:** Slide tata letak berfungsi sebagai templat untuk slide individu. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Catatan 2:** Ketika Anda menambahkan bentuk atau teks ke slide tata letak, semua slide yang berbasis tata letak tersebut akan menampilkan konten bersama ini secara otomatis.
> Tangkapan layar di bawah menunjukkan dua slide, masing-masing mewarisi kotak teks dari slide tata letak yang sama.

![Slide yang Mewarisi Konten Tata Letak](layout-slide-result.png)

## **Akses Slide Tata Letak**

Slide tata letak dapat diakses berdasarkan indeks atau berdasarkan tipe tata letak (misalnya, `Blank`, `Title`, `SectionHeader`, dll.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Akses slide tata letak berdasarkan indeks.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Akses slide tata letak berdasarkan tipe.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Hapus Slide Tata Letak**

Anda dapat menghapus slide tata letak tertentu jika tidak lagi diperlukan.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Dapatkan slide tata letak berdasarkan tipe dan hapus.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Hapus Slide Tata Letak yang Tidak Digunakan**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus slide tata letak yang tidak digunakan oleh slide biasa manapun.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Secara otomatis menghapus semua slide tata letak yang tidak direferensikan oleh slide manapun.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Gandakan Slide Tata Letak**

Anda dapat menduplikat slide tata letak menggunakan metode `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Dapatkan slide tata letak yang ada berdasarkan tipe.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Gandakan slide tata letak ke akhir koleksi slide tata letak.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Ringkasan:** Slide tata letak adalah alat yang kuat untuk mengelola pemformatan konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan optimisasi slide tata letak.