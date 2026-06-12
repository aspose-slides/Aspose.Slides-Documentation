---
title: Kelola Slide Show dalam Python
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/python-net/manage-slide-show/
keywords:
- tipe pertunjukan
- dipresentasikan oleh pembicara
- ditelusuri oleh individu
- ditelusuri di kios
- opsi pertunjukan
- putar terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan khusus
- lanjutkan slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola slide show di Aspose.Slides untuk Python melalui .NET. Kendalikan transisi slide, timing, dan lainnya pada format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** merupakan alat penting untuk menyiapkan dan menyajikan presentasi profesional. Salah satu fitur paling penting di bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kemudahan. Dengan fitur ini, Anda dapat memilih jenis pertunjukan (misalnya, dipresentasikan oleh pembicara, ditelusuri oleh individu, atau ditelusuri di kios), mengaktifkan atau menonaktifkan looping, memilih slide tertentu untuk ditampilkan, dan menggunakan timing. Langkah persiapan ini krusial untuk membuat presentasi Anda lebih efektif dan profesional.

`slide_show_settings` adalah properti dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) bertipe [SlideShowSettings](https://reference.aspose.com/slides/id/python-net/aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Dalam artikel ini, kita akan mengeksplorasi cara menggunakan properti ini untuk mengonfigurasi dan mengontrol berbagai aspek pengaturan slide show. 

## **Pilih Jenis Pertunjukan**

`SlideShowSettings.slide_show_type` menentukan tipe slide show, yang dapat berupa instance dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/python-net/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/python-net/aspose.slides/browsedatkiosk/). Menggunakan properti ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kios otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur jenis pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings.loop` menentukan apakah slide show harus diulang secara loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. `SlideShowSettings.show_narration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. `SlideShowSettings.show_animation` menentukan apakah animasi yang ditambahkan pada objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan loop pada slide show.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Pilih Slide yang Akan Ditampilkan**

Properti `SlideShowSettings.slides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi daripada semua slide. Contoh kode di bawah ini membuat presentasi baru dan mengatur rentang slide yang ditampilkan dari slide `2` hingga `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gunakan Timing Slide**

Properti `SlideShowSettings.use_timings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan timing yang telah ditentukan untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditetapkan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tampilkan Kontrol Media**

Properti `SlideShowSettings.show_media_controls` menentukan apakah kontrol media (seperti mainkan, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberikan kontrol kepada presenter atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/python-net/save-presentation/).

**Apakah saya dapat mengecualikan slide tertentu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/hidden/). Slide yang disembunyikan tetap ada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.