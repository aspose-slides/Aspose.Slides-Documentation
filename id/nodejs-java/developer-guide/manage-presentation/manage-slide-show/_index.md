---
title: Kelola Slide Show dalam JavaScript
linktitle: Tayangan Slide
type: docs
weight: 90
url: /id/nodejs-java/manage-slide-show/
keywords:
- tipe tayangan
- ditampilkan oleh pembicara
- ditelusuri oleh individu
- ditelusuri di kiosk
- opsi tayangan
- putar berulang terus-menerus
- tayangan tanpa narasi
- tayangan tanpa animasi
- warna pena
- tampilkan slide
- tayangan khusus
- maju ke slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola slide show dalam JavaScript dengan Aspose.Slides untuk Node.js. Kontrol transisi slide, timing, dan lainnya di format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** adalah alat penting untuk menyiapkan dan menyajikan presentasi profesional. Salah satu fitur paling penting di bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kenyamanan. Dengan fitur ini, Anda dapat memilih jenis tayangan (misalnya, disajikan oleh pembicara, dilihat oleh individu, atau dilihat di kiosk), mengaktifkan atau menonaktifkan pengulangan, memilih slide tertentu untuk ditampilkan, dan menggunakan pengaturan waktu. Langkah persiapan ini penting untuk membuat presentasi Anda lebih efektif dan profesional.

`getSlideShowSettings` adalah metode dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang mengembalikan objek bertipe [SlideShowSettings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Dalam artikel ini, kita akan menelusuri cara menggunakan metode ini untuk mengkonfigurasi dan mengontrol berbagai aspek pengaturan slide show.

## **Pilih Tipe Tayangan**

`SlideShowSettings.setSlideShowType` menentukan tipe slide show, yang dapat berupa instance dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur tipe tayangan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Aktifkan Opsi Tayangan**

`SlideShowSettings.setLoop` menentukan apakah slide show harus berulang dalam loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. `SlideShowSettings.setShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. `SlideShowSettings.setShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Pilih Slide untuk Ditampilkan**

Metode `SlideShowSettings.setSlides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan mengatur rentang slide yang ditampilkan dari slide `2` hingga `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gunakan Pengaturan Waktu Slide**

Metode `SlideShowSettings.setUseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan waktu preset untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditentukan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Tampilkan Kontrol Media**

Metode `SlideShowSettings.setShowMediaControls` menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/nodejs-java/save-presentation/).

**Apakah saya dapat mengecualikan slide tertentu dari tayangan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/sethidden/). Slide tersembunyi tetap berada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.