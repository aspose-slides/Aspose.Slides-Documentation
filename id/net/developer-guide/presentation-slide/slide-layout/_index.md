---
title: Menerapkan atau Mengubah Tata Letak Slide di .NET
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/net/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- C#
- .NET
- Aspose.Slides
description: "Menerapkan, membuat, dan memodifikasi tata letak slide di Aspose.Slides untuk .NET, menambahkan placeholder, menghapus tata letak yang tidak terpakai, dan mengontrol visibilitas footer."
---
## **Ikhtisar**

Tata letak slide mendefinisikan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberi slide struktur yang konsisten sekaligus memungkinkan setiap slide memiliki kontennya masing‑ma​sil.

Tata letak yang paling umum meliputi:

- **Slide Judul**: Memuat placeholder judul dan subjudul.
- **Judul dan Konten**: Memuat placeholder judul dan placeholder konten serbaguna.
- **Kosong**: Tidak memuat placeholder konten dan berguna bila setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkat yang saling terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) menentukan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/) berada dalam sebuah master dan mendefinisikan susunan placeholder tertentu.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah slide normal mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan secara langsung pada slide normal akan menimpa nilai yang diwarisi pada tingkat tersebut. Ketika sebuah slide normal dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik slide normal.

Tambahkan placeholder yang diperlukan ke sebuah tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambah bentuk placeholder yang bersesuaian pada slide normal yang sudah ada.

Hubungan ini menghasilkan dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah dipakai, periksa slide‑slide yang tergantung dan tinjau hasil presentasi.
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang tingkatan teratas hierarki ini, lihat [Slide Master](/slides/id/net/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika tata letak tersebut tidak tersedia, secara sengaja akan beralih ke **Kosong**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui properti [ISlide.LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan korespondensi antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksalah output ketika beralih antar tata letak yang secara substansial berbeda.

## **Tambahkan Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya hanya memilih tata letak yang sudah ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/masterlayoutslidecollection/add/) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Judul dan Konten** baru bernama `Report Title and Content`, kemudian menambahkan slide normal yang didasarkan padanya. Nama tata letak harus unik dalam koleksi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Tambahkan tata letak hanya bila templat memang membutuhkan struktur yang dapat digunakan kembali. Jika tata letak yang sesuai sudah ada, pilih dan gunakan kembali daripada membuat duplikat.

## **Tambahkan Placeholder ke Tata Letak Slide**

Properti [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/placeholdermanager/) menyediakan [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| Placeholder PowerPoint               | Metode `ILayoutPlaceholderManager` |
| ------------------------------------ | ----------------------------------- |
| ![Content](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png)  | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)              | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                  | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                  | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Contoh berikut memverifikasi bahwa tata letak **Kosong** ada, menambahkan empat placeholder padanya, lalu membuat slide normal yang menggunakan tata letak yang telah dimodifikasi. Urutannya sengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang bersesuaian pada slide tersebut.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder tata letak yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak otomatis di‑backfill ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Digunakan**

Gunakan metode [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus tata letak yang tidak dirujuk oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih dipakai tetap utuh.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Untuk menghapus satu tata letak tertentu, pertama gunakan properti [HasDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/hasdependingslides/) atau metode [GetDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/getdependingslides/). Alihkan semua slide yang bergantung sebelum memanggil [ILayoutSlide.Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/remove/). Mencoba menghapus tata letak yang masih dipakai akan menghasilkan [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/).

## **Atur Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki placeholder footer, nomor slide, dan tanggal‑waktu sendiri. Gunakan properti [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/headerfootermanager/) untuk mengontrol placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak dengan aman dan membuat elemen footernya terlihat:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Atur Visibilitas Footer pada Master dan Tata Letak Turunannya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan properti [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/headerfootermanager/). Metode propagasi pada [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslideheaderfootermanager/) bekerja pada master serta tata letak dan slide normal yang bergantung; mereka tidak menargetkan satu slide normal saja.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Master slide menentukan tema presentasi dan pemformatan bersama. Layout slide merupakan bagian dari master dan menentukan satu susunan placeholder yang dapat digunakan kembali. Slide normal menggunakan tata letak tersebut dan menyimpan konten khusus slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/globallayoutslidecollection/addclone/). Saat menyalin antar presentasi, periksa juga font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Jika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa pemformatan atau objek secara lokal. Geometri placeholder dan styling yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [GetDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/getdependingslides/) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus hanya layout yang tidak direferensikan.