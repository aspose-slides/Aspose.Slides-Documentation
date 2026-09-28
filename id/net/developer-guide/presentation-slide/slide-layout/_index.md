---
title: Terapkan atau Ubah Tata Letak Slide di .NET
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
- tata letak yang tidak digunakan
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
description: "Terapkan, buat, dan modifikasi tata letak slide di Aspose.Slides untuk .NET, tambahkan placeholder, hapus tata letak yang tidak digunakan, dan kontrol visibilitas footer."
---
## **Ikhtisar**

Sebuah tata letak slide mendefinisikan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sambil memungkinkan setiap slide berisi kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga level terkait:

1. A [master slide](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. A [layout slide](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/) termasuk dalam master dan mendefinisikan susunan khusus placeholder.
1. A [normal slide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari layout‑nya, dan layout mewarisi dari master‑nya. Nilai yang ditetapkan langsung pada normal slide menggantikan nilai yang diwariskan pada level itu. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari layout yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut milik normal slide.

Tambahkan placeholder yang diperlukan ke layout sebelum membuat slide darinya. Menambahkan placeholder lain ke layout kemudian tidak otomatis menambahkan bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwariskan atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide‑slide yang bergantung dan tinjau presentasi yang dihasilkan.
- Tata letak yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide yang bergantung ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak digunakan.

Untuk informasi lebih lanjut tentang level atas hirarki ini, lihat [Slide Master](/slides/id/net/slide-master/).

Untuk menyembunyikan logo yang diwariskan atau bentuk master dekoratif pada satu slide atau melalui tata letak bersama, lihat [Control the Visibility of Master Graphics](/slides/id/net/slide-master/). Contoh membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika tata letak itu tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui properti [ISlide.LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/islide/layoutslide/).

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

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwariskan, dan korespondensi antara placeholder yang ada dan tata letak baru dapat berubah, sehingga periksa hasilnya ketika beralih antara tata letak yang sangat berbeda.

## **Tambahkan Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/id/net/aspose.slides/masterlayoutslidecollection/add/) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Title and Content** baru bernama `Report Title and Content`, lalu menambahkan slide normal yang berdasar padanya. Nama tata letak harus unik dalam koleksi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Tambahkan tata letak hanya ketika templat memang memerlukan struktur dapat digunakan ulang lainnya. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali alih-alih membuat duplikat.

## **Tambahkan Placeholder ke Tata Letak Slide**

Properti [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/placeholdermanager/) menyediakan sebuah [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke tata letak.

| Placeholder PowerPoint | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Konten](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Konten (Vertikal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Teks](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Teks (Vertikal)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Gambar](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabel](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Gambar Online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Contoh berikut memverifikasi bahwa tata letak **Blank** ada, menambahkan empat placeholder padanya, lalu membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutan ini disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

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

Hasil:

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwariskan atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Digunakan**

Gunakan metode [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus tata letak yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih dipakai tetap utuh.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Untuk menghapus satu tata letak tertentu, pertama gunakan properti [HasDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/hasdependingslides/) atau metode [GetDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/getdependingslides/). Alihkan slide yang bergantung sebelum memanggil [ILayoutSlide.Remove](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/remove/). Mencoba menghapus tata letak yang masih dipakai akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu sendiri. Gunakan properti [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/headerfootermanager/) untuk mengontrol placeholder tersebut pada satu tata letak. Hal ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak secara aman dan membuat elemen footernya terlihat:

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

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan properti [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslide/headerfootermanager/). Metode propagasi dari [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta tata letak dan slide normal yang bergantung; mereka tidak menargetkan satu slide normal saja.

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

**Apa Perbedaan Antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema presentasi dan pemformatan bersama. Layout slide termasuk dalam master dan mendefinisikan satu susunan placeholder yang dapat digunakan ulang. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [AddClone](https://reference.aspose.com/slides/id/net/aspose.slides/globallayoutslidecollection/addclone/). Saat menyalin antar presentasi, verifikasi juga font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Ketika Saya Mengubah Tata Letak yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan tata letak kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwariskan dapat berubah pada banyak slide sekaligus. Gunakan [GetDependingSlides](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslide/getdependingslides/) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) untuk menghapus hanya tata letak yang tidak direferensikan.