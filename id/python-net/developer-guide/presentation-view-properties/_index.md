---
title: "Ambil dan Perbarui Properti Tampilan Presentasi di Python"
linktitle: "Properti Tampilan"
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
- keadaan batang
- ukuran dimensi
- penyesuaian otomatis
- zoom bawaan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Gunakan Aspose.Slides for Python via .NET untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides for Python via .NET mengekspos preferensi penyuntingan yang disimpan pada presentasi melalui [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Ini termasuk tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang NormalViewProperties**

Gunakan [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) untuk mengakses objek [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) mengontrol apakah ikon muncul di samping judul slide dalam outline. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) memungkinkan panel samping menempel pada keadaan diminimalkan ketika pengguna memperkecilnya. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) menunjukkan preferensi untuk menampilkan satu panel dalam jendela penuh.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) mengontrol pemisah antara panel samping dan slide. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) mengontrol pemisah di atas panel catatan. Kedua‑nya menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) berupa `MINIMIZED`, `MAXIMIZED`, atau `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Editor konseptual memisahkan panel samping, area slide, dan area bawah dengan pemisah vertikal dan horizontal yang berlabel.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Dalam tampilan normal, pemisah vertikal mengontrol lebar panel samping. Pemisah horizontal mengontrol ruang di atas panel catatan.* 
<!-- visual-explanation:presentation-view-properties:end -->

## **Tentang Memulihkan NormalViewProperties**

Ketika sebuah pemisah dipulihkan, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) menyediakan ukuran yang disimpan untuk panel samping dan [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) menyediakan ukuran yang disimpan untuk area slide atas. Kedua‑nya mengekspos [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Properti [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/)‑nya menerima persentase dari 0 hingga 100, dan [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) mengontrol apakah editor menyesuaikan ukuran saat jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ia memulihkan pemisah horizontal, mengatur [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pemisah vertikal. Ia juga mengaktifkan [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) untuk tampilan outline.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Nilai Zoom Bawaan**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) dan [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) menyimpan pengaturan zoom yang terpisah untuk editor. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan mengaktifkan [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) agar slide menyesuaikan dengan jendela penyuntingan. Untuk halaman catatan, ia menonaktifkan skala otomatis dan mengatur [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) ke zoom tetap 80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Jarak Grid**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) mengatur jarak antara garis grid penyuntingan di seluruh presentasi. Nilai yang diberikan harus positif dalam satuan poin, dengan 72 poin per inci. Contoh ini mencetak jarak saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Grid diulang dengan interval tetap. [Panduan menggambar](/slides/id/python-net/drawing-guides/) menandai posisi horizontal atau vertikal individual. Kedua‑nya merupakan bantuan penyuntingan dan hanya muncul di editor yang menampilkannya. Slide show dan ekspor ke PDF, gambar, atau SVG tidak menyertakannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) menyimpan preferensi yang digunakan editor kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar tersembunyi. Ia juga mengatur [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) ke [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) sehingga salinan dibuka dalam tampilan slide.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Komentar Presentasi](/slides/id/python-net/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **Tanya Jawab**

**Mengapa grid tersembunyi ketika saya membuka kembali presentasi?**  
Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di editor.

**Apakah menghapus panduan menggambar mengubah jarak grid?**  
Tidak. Menambahkan, memindahkan, atau menghapus sebuah panduan tidak mengubah interval grid.

**Apakah bagian berbeda dalam sebuah presentasi dapat memiliki pengaturan tampilan yang berbeda?**  
Tidak. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) berlaku untuk seluruh presentasi.

**Dapatkah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**  
File menyimpan satu set properti tampilan untuk semua orang. Sebuah editor juga dapat menerapkan preferensi lokal pengguna.

**Dapatkah saya menyimpan pengaturan tampilan dalam sebuah templat?**  
Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpan.