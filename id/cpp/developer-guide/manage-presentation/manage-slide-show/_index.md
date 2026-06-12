---
title: Kelola Slide Show di C++
linktitle: Slide Show
type: docs
weight: 90
url: /id/cpp/manage-slide-show/
keywords:
- jenis pertunjukan
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
- menggunakan penjadwalan waktu
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola slide show di Aspose.Slides untuk C++. Kendalikan transisi slide, penjadwalan waktu, dan lebih banyak lagi pada format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Di Microsoft PowerPoint, pengaturan **Slide Show** merupakan alat penting untuk menyiapkan dan menyajikan presentasi profesional. Salah satu fitur terpenting di bagian ini adalah **Set Up Show**, yang memungkinkan Anda menyesuaikan presentasi dengan kondisi dan audiens tertentu, memastikan fleksibilitas dan kenyamanan. Dengan fitur ini, Anda dapat memilih jenis pertunjukan (misalnya, dipresentasikan oleh pembicara, dijelajahi oleh individu, atau dijelajahi di kios), mengaktifkan atau menonaktifkan pengulangan, memilih slide tertentu untuk ditampilkan, dan menggunakan penjadwalan waktu. Langkah persiapan ini penting untuk membuat presentasi Anda lebih efektif dan profesional.

`get_SlideShowSettings` adalah metode dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang mengembalikan objek tipe [SlideShowSettings](https://reference.aspose.com/slides/id/cpp/aspose.slides/slideshowsettings/), yang memungkinkan Anda mengelola pengaturan slide show dalam presentasi PowerPoint. Dalam artikel ini, kami akan mengeksplorasi cara menggunakan metode ini untuk mengonfigurasi dan mengontrol berbagai aspek pengaturan slide show. 

## **Pilih Jenis Pertunjukan**

`SlideShowSettings.set_SlideShowType` menentukan jenis slide show, yang dapat berupa instansi dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/cpp/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/cpp/aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kios otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur jenis pertunjukan ke "Browsed by an individual" tanpa menampilkan scrollbar.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aktifkan Opsi Pertunjukan**

`SlideShowSettings.set_Loop` menentukan apakah slide show harus diulang secara loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus‑menerus. `SlideShowSettings.set_ShowNarration` menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara untuk audiens. `SlideShowSettings.set_ShowAnimation` menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual penuh pada presentasi.

Contoh kode berikut membuat presentasi baru dan mengulangi slide show.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pilih Slide yang Ditampilkan**

Metode `SlideShowSettings.set_Slides` memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi baru dan mengatur rentang slide yang ditampilkan dari slide `2` hingga `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gunakan Waktu Slide**

Metode `SlideShowSettings.set_UseTimings` memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan waktu yang telah ditentukan sebelumnya untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditetapkan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan waktu.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tampilkan Kontrol Media**

Metode `SlideShowSettings.set_ShowMediaControls` menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga terbuka langsung dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam mode slide show saat dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [saat mengekspor](/slides/id/cpp/save-presentation/).

**Apakah saya dapat mengecualikan slide individu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/set_hidden/). Slide yang disembunyikan tetap ada dalam presentasi tetapi tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.