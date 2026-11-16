---
title: Mengambil dan Memperbarui Properti Tampilan Presentasi di Python via Java
linktitle: Properti Tampilan
type: docs
weight: 80
url: /id/python-java/presentation-view-properties/
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
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk Python via Java untuk mengonfigurasi tata letak tampilan normal, zoom slide dan catatan, jarak grid, serta visibilitas komentar dalam presentasi PowerPoint."
---
## **Pendahuluan**

Dalam tampilan normal PowerPoint, slide muncul di antara panel samping untuk thumbnail atau outline dan panel catatan di bawah. Aspose.Slides untuk Python via Java mengekspos preferensi penyuntingan yang disimpan dalam presentasi melalui [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Preferensi ini mencakup tata letak panel, tingkat zoom, jarak grid, dan visibilitas komentar.

## **Tentang NormalViewProperties**

Gunakan [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) untuk mengakses kelas [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) mengontrol apakah ikon muncul di sebelah judul slide dalam outline. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) memungkinkan panel samping menempel ke keadaan diperkecil ketika pengguna memperkecilnya. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) menunjukkan preferensi untuk menampilkan satu panel dalam jendela penuh.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) mengontrol pemisah antara panel samping dan slide. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) mengontrol pemisah di atas panel catatan. Kedua metode menerima nilai [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) berupa `Minimized`, `Maximized`, atau `Restored`.

## **Tentang Mengembalikan NormalViewProperties**

Ketika sebuah pemisah dikembalikan, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) menyediakan ukuran yang disimpan untuk panel samping dan [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) menyediakan ukuran yang disimpan untuk area slide bagian atas. Kedua metode mengembalikan instance dari [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Metode [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) menerima persentase dari 0 hingga 100, dan [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) mengontrol apakah editor menyesuaikan ukuran ketika jendela diubah ukurannya.

Contoh ini memperbarui presentasi yang ada. Ia mengembalikan pemisah horizontal, mengatur ukuran yang dikembalikan oleh [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) menjadi 80% dengan penyesuaian otomatis diaktifkan, dan memaksimalkan pemisah vertikal. Ia juga memanggil [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) untuk menampilkan ikon dalam tampilan outline.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Nilai Zoom Default**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) dan [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) menyimpan pengaturan zoom independen untuk editor. Pengaturan ini tidak memengaruhi dimensi slide, pemutaran slide-show, atau resolusi ekspor gambar.

Contoh ini membuka presentasi yang ada dan memanggil [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) untuk menyesuaikan slide dengan jendela penyuntingan. Untuk halaman catatan, ia menonaktifkan penskalaan otomatis dan memanggil [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) untuk menetapkan zoom tetap 80%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Jarak Grid**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) menetapkan jarak antara garis grid penyuntingan di seluruh presentasi. Nilai yang diberikan harus positif dalam satuan poin, dengan 72 poin per inci. Contoh ini mencetak jarak grid saat ini dalam presentasi yang ada dan menyimpan grid seperempat inci dengan mengatur interval menjadi 18 poin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Grid diulang pada interval tetap. [Drawing guides](/slides/id/python-java/drawing-guides/) menandai posisi horizontal atau vertikal individual. Kedua alat ini merupakan bantuan penyuntingan dan hanya muncul di editor yang menampilkannya. Slide show dan ekspor ke PDF, gambar, atau SVG mengabaikannya.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) menyimpan preferensi yang digunakan editor kompatibel saat membuka presentasi. Untuk presentasi yang ada dengan komentar, contoh ini mencetak pengaturan saat ini dan menyimpan salinan dengan komentar disembunyikan. Ia juga memanggil [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) dengan [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) sehingga salinan tersebut terbuka dalam tampilan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Menyembunyikan komentar mempertahankan teks, penulis, posisi, balasan, dan statusnya. Untuk mengubah komentar itu sendiri, lihat [Presentation Comments](/slides/id/python-java/presentation-comments/). Pengaturan ekspor mengontrol apakah komentar muncul dalam PDF, HTML, gambar, catatan, atau handout.

## **FAQ**

**Mengapa grid tersembunyi saat saya membuka kembali presentasi?**

Presentasi menyimpan interval grid. Untuk melihat grid, aktifkan visibilitas grid di editor.

**Apakah menghapus panduan gambar mengubah jarak grid?**

Tidak. Menambahkan, memindahkan, atau menghapus panduan tidak mengubah interval grid.

**Apakah bagian berbeda dari presentasi dapat memiliki pengaturan tampilan yang berbeda?**

Tidak. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) berlaku untuk seluruh presentasi.

**Bisakah saya menyimpan pengaturan tampilan yang berbeda untuk pengguna yang berbeda?**

File menyimpan satu set properti tampilan untuk semua orang. Editor dapat juga menerapkan preferensi lokal pengguna.

**Bisakah saya menyimpan pengaturan tampilan dalam templat?**

Ya. Presentasi yang dibuat dari templat mewarisi pengaturan tampilan yang disimpan dalam templat.