---
title: Mengelola Slide Show di PHP
linktitle: Slide Show
type: docs
weight: 90
url: /id/php-java/manage-slide-show/
keywords:
- tipe pertunjukan
- dipresentasikan oleh pembicara
- diputar oleh individu
- diputar di kiosk
- opsi pertunjukan
- loop terus menerus
- tampil tanpa narasi
- tampil tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan kustom
- maju slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola slide show di Aspose.Slides untuk PHP via Java. Kendalikan transisi slide, timing, dan lainnya pada format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** adalah alat penting untuk menyiapkan dan menyajikan presentasi profesional. Salah satu fitur paling penting dalam bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kenyamanan. Dengan fitur ini, Anda dapat memilih jenis pertunjukan (mis., dipresentasikan oleh pembicara, diputar oleh individu, atau diputar di kiosk), mengaktifkan atau menonaktifkan loop, memilih slide tertentu untuk ditampilkan, dan menggunakan timing. Langkah persiapan ini penting untuk membuat presentasi Anda lebih efektif dan profesional.

`getSlideShowSettings` adalah metode dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang mengembalikan objek tipe [SlideShowSettings](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Pada artikel ini, kami akan mengeksplorasi cara menggunakan metode ini untuk mengonfigurasi dan mengendalikan berbagai aspek pengaturan slide show. 

## **Pilih Tipe Pertunjukan**

`SlideShowSettings->setSlideShowType` menentukan jenis slide show, yang dapat berupa instansi dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/php-java/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/php-java/aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur tipe pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings->setLoop` menentukan apakah slide show harus berulang dalam loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang harus berjalan terus‑menerus. `SlideShowSettings->setShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. `SlideShowSettings->setShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Pilih Slide yang Ditampilkan**

`SlideShowSettings->setSlides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan mengatur rentang slide yang ditampilkan dari slide `2` hingga `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gunakan Slide Lanjutan**

`SlideShowSettings->setUseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan timing yang telah ditentukan untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditetapkan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Tampilkan Kontrol Media**

`SlideShowSettings->setShowMediaControls` menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (mis., video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung membuka slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/php-java/save-presentation/).

**Apakah saya dapat mengecualikan slide individu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/sethidden/). Slide yang disembunyikan tetap ada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengendalikan presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.