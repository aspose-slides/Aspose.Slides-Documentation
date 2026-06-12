---
title: Kelola Pertunjukan Slide di .NET
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/net/manage-slide-show/
keywords:
- jenis pertunjukan
- dipresentasikan oleh pembicara
- dilihat oleh individu
- dilihat di kiosk
- opsi pertunjukan
- ulangi terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan khusus
- maju slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola pertunjukan slide di Aspose.Slides untuk .NET. Kontrol transisi slide, timing, dan lainnya di seluruh format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** merupakan alat penting untuk menyiapkan dan menyampaikan presentasi profesional. Salah satu fitur paling penting dalam bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kemudahan. Dengan fitur ini, Anda dapat memilih jenis pertunjukan (mis., dipresentasikan oleh pembicara, dilihat oleh individu, atau dilihat di kios), mengaktifkan atau menonaktifkan pengulangan, memilih slide tertentu untuk ditampilkan, dan menggunakan timing. Langkah persiapan ini penting untuk membuat presentasi Anda lebih efektif dan profesional.

`SlideShowSettings` adalah properti dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) class, berjenis [SlideShowSettings](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slideshowsettings/) , yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Dalam artikel ini, kami akan menjelajahi cara menggunakan properti ini untuk mengonfigurasi dan mengontrol berbagai aspek pengaturan slide show. 

## **Pilih Jenis Pertunjukan**

`SlideShowSettings.SlideShowType` menentukan jenis slide show, yang dapat berupa instansi dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/net/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/net/aspose.slides/browsedatkiosk/). Menggunakan properti ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur jenis pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings.Loop` menentukan apakah slide show harus diulang dalam loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. `SlideShowSettings.ShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. `SlideShowSettings.ShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual penuh pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Pilih Slide yang Ditampilkan**

Properti `SlideShowSettings.Slides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan mengatur rentang slide yang akan ditampilkan dari slide `2` hingga `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Gunakan Pewaktu Slide**

Properti `SlideShowSettings.UseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan timing preset untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditentukan sebelumnya. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Tampilkan Kontrol Media**

Properti `SlideShowSettings.ShowMediaControls` menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (mis., video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kendali atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan penampilan kontrol media.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file dengan format PPSX atau PPSM; format ini langsung membuka slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/net/save-presentation/).

**Apakah saya dapat mengecualikan slide individu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [Hidden](https://reference.aspose.com/slides/id/net/aspose.slides/slide/hidden/). Slide yang disembunyikan tetap berada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.