---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di C++
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/cpp/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pembagi vertikal
- tampilan tunggal
- keadaan bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk C++ untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pengantar**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang terkait dengan penempatan wilayah konten yang berbeda. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi.  

Antarmuka [INormalViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/inormalviewrestoredproperties/) dan keturunannya, serta enumerasi [SplitterBarStateType](https://reference.aspose.com/slides/id/cpp/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon bila menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pemisah vertikal harus menempel pada keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih menyukai tampilan satu wilayah konten penuh jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditampilkan oleh bilah pemisah vertikal atau horizontal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan pada **VerticalBarState** dan **HorizontalBarState** secara berurutan.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft) pada tampilan normal, ketika wilayah memiliki ukuran dipulihkan yang dapat berubah (tidak diminimalkan maupun dimaksimalkan).  

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft).  

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah ini menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Pulihkan properti tampilan presentasi
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Mengatur Nilai Zoom Default**

Aspose.Slides untuk C++ kini mendukung pengaturan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) sebuah presentasi. Properti Tampilan Slide serta [get_NotesViewProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_notesviewproperties/) dapat diatur secara programatik. Pada topik ini, kita akan melihat dengan contoh cara mengatur Properti Tampilan Presentasi di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/)
2. Atur [Properties](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/) Tampilan Presentasi
3. Simpan presentasi sebagai file PPTX

Pada contoh di bawah, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Mengatur properti tampilan presentasi
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Nilai zoom dalam persen untuk tampilan slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Nilai zoom dalam persen untuk tampilan catatan 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengatur pengaturan tampilan yang berbeda untuk bagian yang berbeda dari sebuah presentasi?**

[Pengaturan tampilan](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/id/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen ketika dibuka.

**Apakah saya dapat mendefinisikan keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat berbagi. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Apakah saya dapat menyiapkan templat dengan Properti Tampilan yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**

Ya. Karena [properti tampilan](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_viewproperties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.