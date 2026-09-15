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
- keadaan bilah
- ukuran dimensi
- penyesuaian otomatis
- zoom default
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan properti tampilan Aspose.Slides untuk Python via Java untuk menyesuaikan slide PPT, PPTX, dan ODP—atur tata letak, tingkat zoom, dan pengaturan tampilan."
---
## **Pendahuluan**

Tampilan normal terdiri dari tiga wilayah konten: slidennya sendiri, wilayah konten sisi, dan wilayah konten bawah. Properti tampilan normal menggambarkan posisi wilayah-wilayah konten ini. Informasi ini memungkinkan aplikasi menyimpan keadaan tampilan ke file, sehingga saat dibuka kembali tampilan berada dalam keadaan yang sama seperti saat presentasi terakhir disimpan.

Metode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNormalViewProperties) telah ditambahkan untuk menyediakan akses ke properti tampilan normal sebuah presentasi.

Kelas [NormalViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/) dan [NormalViewRestoredProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/) serta enumerasi [SplitterBarStateType](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/) telah ditambahkan.

## **Tentang NormalViewProperties**

Mewakili properti tampilan normal.

Metode [getShowOutlineIcons](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) dan [setShowOutlineIcons](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) menentukan apakah aplikasi harus menampilkan ikon saat menampilkan konten outline di salah satu wilayah konten mode tampilan normal.

Metode [getSnapVerticalSplitter](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) dan [setSnapVerticalSplitter](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) menentukan apakah pemisah vertikal harus menempel pada keadaan diminimalkan ketika wilayah sisi cukup kecil.

Metode [getPreferSingleView](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) dan [setPreferSingleView](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) menentukan apakah pengguna lebih suka melihat wilayah konten tunggal seluruh jendela daripada tampilan normal standar dengan tiga wilayah konten. Jika diaktifkan, aplikasi dapat memilih menampilkan salah satu wilayah konten pada seluruh jendela.

Metode [getVerticalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) menentukan keadaan yang harus ditampilkan oleh bilah pemisah horizontal atau vertikal. Bilah pemisah horizontal memisahkan slide dari wilayah konten di bawah slide; bilah pemisah vertikal memisahkan slide dari wilayah konten sisi. Nilai yang mungkin: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Maximized) dan [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metode [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) dan [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop) menentukan ukuran wilayah slide atas atau sisi pada tampilan normal, ketika nilai [SplitterBarStateType.Restored](https://reference.aspose.com/slides/id/python-java/aspose.slides/splitterbarstatetype/#Restored) diterapkan pada [getVerticalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) dan [getHorizontalBarState](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), masing‑masing.

## **Tentang Mengembalikan NormalViewProperties**

Menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) pada tampilan normal, ketika wilayah tersebut memiliki ukuran dipulihkan yang variabel (tidak diminimalkan maupun dimaksimalkan).

Metode [getDimensionSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) menentukan ukuran wilayah slide (lebar ketika anak dari [getRestoredTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredTop), tinggi ketika anak dari [getRestoredLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metode [getAutoAdjust](https://reference.aspose.com/slides/id/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) menentukan apakah ukuran wilayah konten sisi harus menyesuaikan dengan ukuran baru saat mengubah ukuran jendela yang berisi tampilan dalam aplikasi.

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

## **Mengatur Nilai Zoom Default**

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Python via Java mendukung pengaturan nilai zoom default sehingga sudah diterapkan saat presentasi dibuka. Hal ini dapat dilakukan dengan mengatur [ViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) sebuah presentasi. [getSlideViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getSlideViewProperties) serta [getNotesViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNotesViewProperties) dapat dikonfigurasi secara programatik. Pada topik ini, kami akan melihat dengan contoh cara mengatur [View Properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) dari [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) di [Aspose.Slides](/slides/id/).
{{% /alert %}}

Untuk mengatur properti tampilan, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Atur [View Properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) dari [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tulis presentasi sebagai file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Pada contoh di bawah, kami mengatur nilai zoom untuk tampilan slide dan tampilan catatan.

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

## **FAQ**

**Apakah saya dapat mengatur pengaturan tampilan yang berbeda untuk bagian berbeda dalam sebuah presentasi?**

[View settings](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) didefinisikan pada tingkat presentasi ([Normal View](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), bukan per bagian, sehingga satu set parameter berlaku untuk seluruh dokumen saat dibuka.

**Apakah saya dapat mendefinisikan sebelumnya status tampilan yang berbeda untuk pengguna yang berbeda?**

Tidak. Pengaturan disimpan dalam file dan dibagikan. Aplikasi penampil dapat menghormati preferensi pengguna, tetapi file itu sendiri berisi satu set properti tampilan.

**Apakah saya dapat menyiapkan templat dengan View Properties yang sudah ditentukan sehingga presentasi baru membuka dengan cara yang sama?**

Ya. Karena [view properties](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getViewProperties) disimpan pada tingkat presentasi, Anda dapat menyematkannya dalam templat dan membuat dokumen baru darinya dengan konfigurasi tampilan awal yang sama.