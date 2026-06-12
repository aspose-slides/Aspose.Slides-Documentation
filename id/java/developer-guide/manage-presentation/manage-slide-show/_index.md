---
title: Kelola Slide Show di Java
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/java/manage-slide-show/
keywords:
- jenis pertunjukan
- dipresentasikan oleh pembicara
- dijelajahi oleh individu
- dijelajahi di kiosk
- opsi pertunjukan
- loop terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- pertunjukan slide
- pertunjukan khusus
- maju slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengelola slide show di Aspose.Slides untuk Java. Kendalikan transisi slide, timing, dan lainnya di format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** merupakan alat penting untuk menyiapkan dan menyampaikan presentasi profesional. Salah satu fitur terpenting dalam bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kenyamanan. Dengan fitur ini, Anda dapat memilih jenis pertunjukan (misalnya, disajikan oleh pembicara, dijelajahi oleh individu, atau dijelajahi di kiosk), mengaktifkan atau menonaktifkan looping, memilih slide tertentu untuk ditampilkan, dan menggunakan timing. Langkah persiapan ini krusial untuk membuat presentasi Anda lebih efektif dan profesional.

`getSlideShowSettings` adalah metode dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) yang mengembalikan objek bertipe [SlideShowSettings](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Pada artikel ini, kami akan menjelaskan cara menggunakan metode ini untuk mengonfigurasi dan mengendalikan berbagai aspek pengaturan slide show. 

## **Pilih Jenis Pertunjukan**

`SlideShowSettings.setSlideShowType` menentukan jenis slide show, yang dapat berupa instance dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/java/com.aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/java/com.aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan menetapkan jenis pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings.setLoop` menentukan apakah slide show harus diulang secara berulang sampai dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. `SlideShowSettings.setShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara untuk audiens. `SlideShowSettings.setShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk menampilkan efek visual lengkap dari presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pilih Slide yang Akan Ditampilkan**

Metode `SlideShowSettings.setSlides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan menetapkan rentang slide yang akan ditampilkan dari slide `2` hingga `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gunakan Slide Otomatis**

Metode `SlideShowSettings.setUseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan timing yang telah ditentukan untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditetapkan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Tampilkan Kontrol Media**

Metode `SlideShowSettings.setShowMediaControls` menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [selama ekspor](/slides/id/java/save-presentation/).

**Apakah saya dapat mengecualikan slide tertentu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#setHidden-boolean-). Slide tersembunyi tetap ada dalam presentasi namun tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengendalikan presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.