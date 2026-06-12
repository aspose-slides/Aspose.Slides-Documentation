---
title: Kelola Slide Show di Android
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/androidjava/manage-slide-show/
keywords:
- tipe pertunjukan
- dipresentasikan oleh pembicara
- ditelusuri oleh individu
- ditelusuri di kiosk
- opsi pertunjukan
- loop terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan kustom
- lanjutkan slide
- secara manual
- menggunakan penjadwalan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mengelola slide show di Aspose.Slides untuk Android melalui Java. Kendalikan transisi slide, penjadwalan, dan lainnya di semua format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** merupakan alat penting untuk menyiapkan dan menyajikan presentasi profesional. Salah satu fitur paling penting di bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kenyamanan. Dengan fitur ini, Anda dapat memilih tipe pertunjukan (misalnya, dipresentasikan oleh pembicara, ditelusuri oleh individu, atau ditelusuri di kiosk), mengaktifkan atau menonaktifkan pengulangan, memilih slide tertentu untuk ditampilkan, dan menggunakan penjadwalan waktu. Langkah persiapan ini sangat penting untuk membuat presentasi Anda lebih efektif dan profesional.

`getSlideShowSettings` adalah metode dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang mengembalikan objek bertipe [SlideShowSettings](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Pada artikel ini, kita akan menjelajahi cara menggunakan metode ini untuk mengonfigurasi dan mengendalikan berbagai aspek pengaturan slide show. 

## **Pilih Tipe Pertunjukan**

`SlideShowSettings.setSlideShowType` mendefinisikan tipe slide show, yang dapat berupa instance dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur tipe pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings.setLoop` menentukan apakah slide show harus diulang dalam loop sampai dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. `SlideShowSettings.setShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. `SlideShowSettings.setShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pilih Slide yang Ditampilkan**

Metode `SlideShowSettings.setSlides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan menetapkan rentang slide yang ditampilkan dari slide `2` sampai `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gunakan Slide Lanjutan**

Metode `SlideShowSettings.setUseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan penjadwalan waktu yang telah ditetapkan untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditentukan sebelumnya. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan penjadwalan waktu.

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

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam slide show ketika dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/androidjava/save-presentation/).

**Apakah saya dapat mengecualikan slide tertentu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Slide tersembunyi tetap berada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.