---
title: Kelola Header dan Footer Presentasi di .NET
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/net/presentation-header-and-footer/
keywords:
- kepala
- teks kepala
- kaki
- teks kaki
- atur header
- atur kaki
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk .NET memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui antarmuka manajer header/footer.

Placeholder yang tersedia bergantung pada ruang lingkup:

| Ruang Lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Regular slide | No | Yes | Yes | Yes |
| Notes master | Yes | Yes | Yes | Yes |
| Notes slide | Yes | Yes | Yes | Yes |
| Handout master | Yes | Yes | Yes | Yes |

Sebuah slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada manajer yang Anda gunakan. Antarmuka [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/islideheaderfootermanager/) mengontrol satu slide reguler. Antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/inotesslideheaderfootermanager/) mengontrol satu slide catatan. Manajer master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara antarmuka [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslideheaderfootermanager/) mengontrol master handout.

## **Atur Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer setiap slide, mengatur teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, sehingga Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`SetFooterText`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) dan [`SetDateTimeText`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) untuk mengatur teks, serta gunakan [`SetFooterVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), dan [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) untuk menampilkan placeholder yang bersangkutan.

Contoh end-to-end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama ke semua slide reguler:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Jika Anda hanya perlu memperbarui satu slide, akses slide tersebut langsung melalui koleksi [`Slides`](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) alih-alih mengiterasi seluruh koleksi.

## **Atur Header dan Footer pada Notes Master**

Notes master mendefinisikan format umum dan perilaku placeholder untuk halaman catatan. Gunakan antarmuka [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya notes master itu sendiri.

Contoh berikut mengatur header, footer, dan teks tanggal/waktu pada notes master serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Properti [`MasterNotesSlide`](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslidemanager/masternotesslide/) mengembalikan `null` ketika presentasi tidak berisi notes master.

## **Terapkan Pengaturan Notes Master ke Slide Catatan Anak**

Notes master dapat menerapkan pengaturan header dan footer ke dirinya sendiri dan ke semua slide catatan yang bergantung. Gunakan metode propagasi khusus pada [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Sebagai contoh, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) dan [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) memperbarui header notes master dan semua header anak. Metode yang setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Metode propagasi yang digunakan di atas meliputi [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), dan [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Atur Header dan Footer pada Slide Catatan Individu**

Slide catatan merupakan bagian dari slide reguler tertentu. Gunakan antarmuka [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/inotesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`AddNotesSlide`](https://reference.aspose.com/slides/id/net/aspose.slides/inotesslidemanager/addnotesslide/) mengembalikan slide catatan untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide presentasi pertama:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Jika Anda pertama-tama menyebarkan pengaturan dari notes master lalu mengubah slide catatan individu, pengaturan per-slide kemudian memungkinkan Anda menyesuaikan halaman catatan tersebut secara terpisah.

## **Atur Header dan Footer pada Handout Master**

Halaman handout menggunakan handout master untuk placeholder header, footer, tanggal/waktu, dan nomor halaman mereka. Tidak seperti halaman catatan, pengaturan handout dikelola melalui handout master bukan melalui slide handout individu.

Gunakan properti [`MasterHandoutSlide`](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) untuk mengakses handout master. Jika tidak ada, panggil [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) untuk membuat handout master default.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Pahami Ruang Lingkup dan Pewarisan**

Pilih manajer header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/islideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/ilayoutslideheaderfootermanager/) mengontrol slide layout dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasternotesslideheaderfootermanager/) mengontrol notes master dan dapat menyebarkan pengaturan ke semua slide catatan yang bergantung.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/inotesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/net/aspose.slides/imasterhandoutslideheaderfootermanager/) mengubah handout master dan mendukung keempat tipe placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus diterapkan di seluruh hierarki. Gunakan manajer slide individu atau notes-slide ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header ke slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan aktifkan bila diperlukan. Misalnya, [`IsFooterVisible`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) melaporkan apakah placeholder footer ada, dan [`SetFooterVisibility`](https://reference.aspose.com/slides/id/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Setel properti [`FirstSlideNumber`](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/firstslidenumber/) pada presentasi. Placeholder nomor slide kemudian menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.