---
title: Ambil dan Perbarui Properti Tampilan Presentasi dengan Python
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

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti yang berkaitan dengan penempatan wilayah konten yang berbeda. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke dalam file, sehingga ketika dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Properti [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/normal_view_properties/) telah ditambahkan untuk menyediakan akses ke properti tampilan normal presentasi.  

[NormalViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/normalviewproperties/), kelas [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/normalviewrestoredproperties/) dan turunannya, enum [SplitterBarStateType](https://reference.aspose.com/slides/id/python-net/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang INormalViewProperties**

Mewakili properti tampilan normal.

Properti **ShowOutlineIcons** menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Properti **SnapVerticalSplitter** menentukan apakah pemisah vertikal harus menempel ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Properti **PreferSingleView** menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh‑jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten di seluruh jendela.

Properti **VerticalBarState** dan **HorizontalBarState** menentukan keadaan yang harus ditampilkan oleh bilah pemisah horizontal atau vertikal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide, bilah pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** dan **SplitterBarStateType.Restored.**

Properti **RestoredLeft** dan **RestoredTop** menentukan ukuran wilayah slide atas atau samping pada tampilan normal, ketika nilai **SplitterBarStateType.Restored** diterapkan untuk **VerticalBarState** dan **HorizontalBarState** secara sesuai.

## **Tentang Memulihkan INormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak RestoredTop, tinggi ketika menjadi anak RestoredLeft) pada tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diminimalkan maupun dimaksimalkan).  

Properti **DimensionSize** menentukan ukuran wilayah slide (lebar ketika menjadi anak restoredTop, tinggi ketika menjadi anak restoredLeft).  

Properti **AutoAdjust** menentukan apakah ukuran wilayah konten samping harus menyesuaikan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.  

Contoh di bawah ini menunjukkan cara Anda dapat mengakses properti **ViewProperties.NormalViewProperties** untuk sebuah presentasi.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Pulihkan properti tampilan presentasi
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Nilai Zoom Default**

Aspose.Slides untuk Python melalui .NET kini mendukung pengaturan nilai zoom default untuk presentasi sehingga ketika presentasi dibuka, zoom sudah diatur. Hal ini dapat dilakukan dengan mengatur [view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) sebuah presentasi. Properti Tampilan Slide serta [notes_view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/notes_view_properties/) dapat diatur secara programatis. Pada topik ini, kami akan melihat contoh cara mengatur Properti Tampilan Presentasi di Aspose.Slides.

Untuk mengatur properti tampilan, ikuti langkah‑langkah di bawah ini:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/)
1. Atur [view properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/) presentasi
1. Tulis presentasi sebagai file PPTX

Dalam contoh di bawah ini, kami telah mengatur nilai zoom untuk tampilan slide serta tampilan catatan.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Mengatur properti tampilan presentasi
    presentation.view_properties.slide_view_properties.scale = 100 # Nilai zoom dalam persentase untuk tampilan slide
    presentation.view_properties.notes_view_properties.scale = 100 # Nilai zoom dalam persentase untuk tampilan catatan 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Jarak Grid**

Gunakan [Presentation.view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) untuk mengakses pengaturan tampilan seluruh presentasi. Properti [ViewProperties.grid_spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/grid_spacing/) membaca atau mengubah interval grid penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak grid ditentukan dalam poin, dimana 72 poin sama dengan satu inci. Gunakan nilai positif, sesuai dengan dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak grid saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Grid berbeda dari [drawing guides](/slides/id/python-net/drawing-guides/). Jarak grid mengontrol interval reguler, sementara drawing guides adalah garis penyelarasan horizontal atau vertikal yang diposisikan secara individual. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides merupakan bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin bahwa editor akan menampilkan grid: visibilitasnya juga tergantung pada preferensi penampil atau editor.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation.view_properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) untuk mengakses pengaturan tampilan seluruh presentasi. Baca atau ubah [ViewProperties.show_comments](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/show_comments/) untuk menyimpan preferensi apakah komentar harus ditampilkan ketika presentasi dibuka di PowerPoint atau editor kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Ini tidak menambah, menghapus, menyunting, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan konten, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/python-net/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan `comments.pptx` yang ada dan berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga mengatur [ViewProperties.last_view](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/last_view/) ke [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewtype/) untuk mengkonfigurasi tampilan penyuntingan awal bersamaan dengan visibilitas komentar.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Pengaturan ini tidak menentukan apakah komentar disertakan dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi khusus ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**  
File menyimpan jarak grid, tetapi editor yang mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada editor.

**Apakah menghapus drawing guides mengubah jarak grid?**  
Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian‑bagian berbeda dari sebuah presentasi?**  
[View settings](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/slide_view_properties/)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Bisakah saya mendefinisikan sebelumnya status tampilan yang berbeda untuk pengguna yang berbeda?**  
Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Bisakah saya menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru terbuka dengan cara yang sama?**  
Ya. Karena [view properties](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/view_properties/) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.