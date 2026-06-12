---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Python
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/python-net/presentation-view-properties/
keywords:
- properti tampilan
- tampilan normal
- konten outline
- ikon outline
- snap pemisah vertikal
- tampilan tunggal
- status bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Python via .NET untuk menyesuaikan format slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Normal view terdiri dari tiga region konten: slide itu sendiri, region konten sisi, dan region konten bawah. Properti yang berkaitan dengan penempatan berbagai region konten. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam status yang sama seperti ketika presentasi terakhir disimpan.

Properti [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/normal_view_properties/) telah ditambahkan untuk memberikan akses ke properti tampilan normal presentasi.  

[NormalViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/normalviewrestoredproperties/) classes and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/id/python-net/aspose.slides/splitterbarstatetype/) enum have been added.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu region konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah splitter vertikal harus beralih ke keadaan diminimalkan ketika region sisi cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu region konten penuh-jendela dibandingkan tampilan normal standar dengan tiga region konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu region konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditampilkan oleh bar splitter vertikal atau horizontal. Bar splitter horizontal memisahkan slide dari region konten di bawah slide, bar splitter vertikal memisahkan slide dari region konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** dan **SplitterBarStateType.Restored**.

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran region slide atas atau samping tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan untuk **VerticalBarState** dan **HorizontalBarState** secara berurutan.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran region slide (lebar ketika anak dari RestoredTop, tinggi ketika anak dari RestoredLeft) tampilan normal, ketika region berada dalam ukuran dipulihkan yang variabel (tidak diminimalkan maupun dimaksimalkan).  

Properti **DimensionSize** menentukan ukuran region slide (lebar ketika anak dari restoredTop, tinggi ketika anak dari restoredLeft).  

Properti **AutoAdjust** menentukan apakah ukuran region konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh di bawah ini menunjukkan cara mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Pulihkan properti tampilan presentasi
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Nilai Zoom Default**

Aspose.Slides for Python via .NET kini mendukung penetapan nilai zoom default untuk presentasi sehingga saat presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) suatu presentasi. Properti Tampilan Slide serta [notes_view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/notes_view_properties/) dapat diatur secara programatis. Dalam topik ini, kami akan menunjukkan dengan contoh cara mengatur Properti Tampilan Presentasi di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Set [view properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/) presentasi.
1. Tulis presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Mengatur properti tampilan presentasi
    presentation.view_properties.slide_view_properties.scale = 100 # Nilai zoom dalam persen untuk tampilan slide
    presentation.view_properties.notes_view_properties.scale = 100 # Nilai zoom dalam persen untuk tampilan catatan 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set different view settings for different sections of a presentation?**

[View settings](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) didefinisikan pada level presentasi ([Normal View](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/slide_view_properties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Can I predefine different view states for different users?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Can I prepare a template with predefined View Properties so new presentations open the same way?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) disimpan pada level presentasi, Anda dapat menyematkannya dalam template dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.