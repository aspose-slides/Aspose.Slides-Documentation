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
- keadaan bar
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Python via Java untuk menyesuaikan slide PPT, PPTX, dan ODP—atur tata letak, level zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slide itu sendiri, wilayah konten samping, dan wilayah konten bawah. Properti tampilan normal menggambarkan posisi wilayah-wilayah konten ini. Informasi ini memungkinkan aplikasi menyimpan status tampilan ke dalam file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNormalViewProperties) telah ditambahkan untuk memberikan akses ke properti tampilan normal dari sebuah presentasi.

Kelas [NormalViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/) dan enumerasi [SplitterBarStateType](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang NormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) menentukan apakah pemisah vertikal harus menempel ke keadaan diminimalkan ketika wilayah samping cukup kecil.

Metode [getPreferSingleView](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) dan [setPreferSingleView](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) menentukan apakah pengguna lebih suka melihat satu wilayah konten penuh-jendela dibandingkan tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih untuk menampilkan salah satu wilayah konten di seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) menentukan keadaan yang harus ditampilkan oleh batang pemisah horizontal atau vertikal. Batang pemisah horizontal memisahkan slide dari wilayah konten di bawah slide; batang pemisah vertikal memisahkan slide dari wilayah konten samping. Nilai yang mungkin adalah: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) dan [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop) menentukan ukuran wilayah slide samping atau atas pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), masing-masing.

## **Tentang Memulihkan NormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika menjadi anak dari [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop), tinggi ketika menjadi anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) pada tampilan normal, ketika wilayah memiliki ukuran pulih yang variabel (tidak diminimalkan maupun dimaksimalkan).

Metode [getDimensionSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) menentukan ukuran wilayah slide (lebar ketika menjadi anak dari [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop), tinggi ketika menjadi anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) menentukan apakah ukuran wilayah konten samping harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

Contoh di bawah ini menunjukkan cara mengakses [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNormalViewProperties) untuk sebuah presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Pulihkan properti tampilan presentasi.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Setel Nilai Zoom Default**

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Python via Java mendukung penetapan nilai zoom default sehingga sudah diterapkan ketika presentasi dibuka. Ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) dari sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getSlideViewProperties) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNotesViewProperties) dapat dikonfigurasi secara programatik. Dalam topik ini, kita akan melihat dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) dari [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) di Aspose.Slides.
{{% /alert %}}

Untuk menyetel properti tampilan, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Setel [View Properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) dari [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
3. Tuliskan presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Pada contoh di bawah, kami menyetel nilai zoom untuk tampilan slide dan tampilan catatan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Atur properti tampilan presentasi.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Persentase zoom untuk tampilan slide.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Persentase zoom untuk tampilan catatan.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Setel Jarak Grid**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) untuk mengakses pengaturan tampilan seluruh presentasi. Metode [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getGridSpacing) dan [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#setGridSpacing) membaca atau mengubah interval grid penyuntingan yang mendasarinya. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk slide individu. Jarak grid ditentukan dalam poin, di mana 72 poin sama dengan satu inci. Gunakan nilai positif, sebagaimana dipersyaratkan oleh dokumentasi API.

Contoh berikut membuka `demo.pptx` yang ada, mencetak jarak grid saat ini, menetapkan interval seperempat inci, dan menyimpan hasilnya.

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

Grid berbeda dari [drawing guides](/slides/id/python-java/drawing-guides/). Jarak grid mengontrol interval teratur, sementara drawing guides adalah garis penyejajaran horisontal atau vertikal yang diposisikan secara terpisah. Menambahkan, memindahkan, atau menghapus drawing guides tidak mengubah jarak grid.

Baik grid maupun drawing guides adalah bantuan penyuntingan. Mereka tidak dirender sebagai konten slide dalam PDF, gambar, SVG, atau tayangan slide. Menyimpan jarak grid tidak menjamin bahwa penyunting akan menampilkan grid: visibilitasnya juga bergantung pada preferensi penampil atau penyunting.

## **Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi**

Gunakan [Presentation.getViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) untuk mengakses pengaturan tampilan seluruh presentasi. Gunakan [ViewProperties.getShowComments](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getShowComments) dan [ViewProperties.setShowComments](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#setShowComments) untuk membaca atau mengubah preferensi yang disimpan mengenai apakah komentar harus ditampilkan ketika presentasi dibuka di PowerPoint atau penyunting kompatibel lainnya.

Pengaturan ini hanya mengontrol preferensi tampilan yang disimpan. Itu tidak menambah, menghapus, menyunting, atau menyelesaikan komentar. Menyembunyikan komentar mempertahankan konten, penulis, posisi, balasan, dan statusnya. Lihat [Presentation Comments](/slides/id/python-java/presentation-comments/) untuk operasi yang mengubah komentar itu sendiri.

Contoh berikut memerlukan `comments.pptx` yang ada berisi komentar. Ia mencetak pengaturan visibilitas saat ini, meminta komentar disembunyikan, dan menyimpan PPTX baru tanpa menghapus komentar apa pun. Ia juga menggunakan [ViewProperties.setLastView](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#setLastView) dengan [ViewType.SlideView](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewtype/#SlideView) untuk mengonfigurasi tampilan penyuntingan awal bersama visibilitas komentar.

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

Pengaturan ini tidak menentukan apakah komentar termasuk dalam ekspor PDF, HTML, gambar, catatan, atau handout. Konfigurasikan opsi khusus ekspor yang relevan secara terpisah.

## **FAQ**

**Mengapa grid tidak terlihat setelah saya membuka kembali presentasi?**

File menyimpan jarak grid, tetapi penyunting mengontrol apakah grid ditampilkan. Periksa pengaturan visibilitas grid pada penyunting.

**Apakah menghapus drawing guides mengubah jarak grid?**

Tidak. Drawing guides dan jarak grid adalah pengaturan yang independen. Menghapus guides tidak mengubah interval grid yang disimpan.

**Bisakah saya mengatur pengaturan tampilan yang berbeda untuk bagian-bagian berbeda dalam sebuah presentasi?**

[Pengaturan tampilan](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Apakah saya dapat mendefinisikan sebelumnya keadaan tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan bersifat bersama. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri hanya berisi satu set properti tampilan.

**Apakah saya dapat menyiapkan templat dengan View Properties yang telah ditentukan sehingga presentasi baru membuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam sebuah templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.