---
title: Kelola Tautan Hiperteks Presentasi dalam Python via Java
linktitle: Kelola Tautan Hiperteks
type: docs
weight: 20
url: /id/python-java/manage-hyperlinks/
keywords:
- tambahkan URL
- menambahkan tautan hiperteks
- membuat tautan hiperteks
- memformat tautan hiperteks
- menghapus tautan hiperteks
- memperbarui tautan hiperteks
- tautan hiperteks teks
- tautan hiperteks slide
- tautan hiperteks bentuk
- tautan hiperteks gambar
- tautan hiperteks video
- tautan hiperteks dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Menambahkan, memformat, memperbarui, dan menghapus tautan hiperteks dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via Java, menggunakan contoh Python."
---
## **Pendahuluan**

Tautan hiperteks menghubungkan konten presentasi ke situs web atau ke lokasi di dalam presentasi. Di PowerPoint, tautan hiperteks biasanya melayani dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for Python via Java memungkinkan Anda menambahkan tautan ini, mengontrol penampilan dan suaranya, memperbarui propertinya, serta menghapusnya. Contoh di bawah menunjukkan cara bekerja dengan tautan hiperteks pada elemen individu dan cara mengakses tautan hiperteks pada tingkat presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor PowerPoint online gratis Aspose](https://products.aspose.app/slides/id/editor).
{{% /alert %}} 

## **Menambahkan Tautan URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen tempat Anda menetapkan tautan hiperteks menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sementara bentuk atau bingkai menautkan objek slide.

### **Menambahkan Tautan URL ke Teks**

Untuk menautkan teks ke situs web, berikan sebuah [Hyperlink](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/) ke metode [setHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#setHyperlinkClick) milik bagian teks, seperti yang ditunjukkan di bawah. Hanya bagian teks tersebut yang menjadi dapat diklik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menambahkan Tautan URL ke Bentuk dan Bingkai Media**

Agar bentuk atau bingkai dapat diklik, panggil metode [setHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setHyperlinkClick) miliknya. Tautan hiperteks menjadi milik objek itu sendiri, bukan bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan tautan hiperteks ke bingkai dan panggil [setTooltip](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setTooltip) jika diperlukan.

Contoh berikut membuat sebuah persegi panjang dapat diklik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gunakan Tautan Hiperteks untuk Membuat Daftar Isi**

Tautan hiperteks internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [setInternalHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Format Tautan Hiperteks**

### **Warna**

Metode [setColorSource](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setColorSource) dari [Hyperlink](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/) menentukan apakah tautan hiperteks menggunakan warna tautan presentasi atau pemformatan bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkcolorsource/) dan atur warna isi bagian tersebut. Fitur ini diperkenalkan pada PowerPoint 2019; versi yang lebih lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua tautan teks ke slide yang sama. Yang pertama menggunakan isi teks merah, sementara yang kedua mempertahankan warna tautan hiperteks default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Suara**

Suatu tautan hiperteks dapat memutar suara saat diaktifkan atau menghentikan suara yang sedang diputar. Gunakan metode berikut untuk mengonfigurasi perilaku ini:

- [Hyperlink.setSound](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setSound) menentukan audio yang terkait dengan tautan hiperteks.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) mengontrol apakah mengaktifkan tautan hiperteks menghentikan suara sebelumnya.

#### **Tambahkan Suara pada Tautan Hiperteks**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan sebuah tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide tersebut menghentikan suara sebelumnya saat diklik, tanpa melakukan aksi navigasi.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Ekstrak Suara dari Tautan Hiperteks**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio tautan hiperteks pada bentuk pertama ke dalam memori melalui [getSound](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getSound) dan [getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Pengaturan Tooltip dan Interaksi**

Anda dapat memanggil metode [Hyperlink](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/) berikut setelah menetapkan tautan hiperteks ke teks atau bentuk:

- [setTooltip](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setTooltip) mengatur teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [setTargetFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setTargetFrame) menentukan bingkai target di dalam frameset HTML induk, bila berlaku.
- [setHistory](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setHistory) mengontrol apakah mengaktifkan tautan menambahkan tujuannya ke daftar tautan hiperteks yang telah dilihat.
- [setHighlightClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#setHighlightClick) mengontrol apakah tautan hiperteks disorot saat diklik.

## **Hapus Tautan Hiperteks dari Presentasi**

Gunakan [getAnyHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) untuk mengumpulkan kontainer tautan hiperteks, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua jenis aktivasi dari slide pertama. Untuk menghapus hanya satu jenis, panggil hanya [removeHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) atau [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); menghapus aksi klik tidak menghapus pasangan mouse-overnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Untuk penghapusan tanpa syarat, [removeAllHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) menghapus kedua jenis aktivasi dalam ruang lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan cakupan master, tata letak, serta catatan, lihat [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bangun Inventaris Tautan Hiperteks yang Lengkap**

Sebelum mendistribusikan sebuah presentasi, inventarisasi aksi interaktifnya serta tautan webnya. [getAnyHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) mengembalikan kontainer tautan hiperteks, seperti objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) dan [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/), bukan daftar datar string URL. Periksa baik [getHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getHyperlinkClick) maupun [getHyperlinkMouseOver](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getHyperlinkMouseOver) pada setiap kontainer. Mereka bersifat independen: kontainer yang sama dapat menampilkan kedua aksi, sehingga laporan lengkap membutuhkan hingga dua baris per kontainer.

Memindai hanya tautan hiperteks tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Sebaliknya, query ruang lingkup yang tepat, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksinya nanti.

### **Query Ruang Lingkup Presentasi, Slide, dan Bingkai Teks**

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/) tersedia melalui [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getHyperlinkQueries), dan [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getHyperlinkQueries). Setiap ruang lingkup mendukung kueri yang sama:

- [getHyperlinkClicks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) mengembalikan kontainer dengan aksi klik.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) mengembalikan kontainer dengan aksi mouse-over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse-over file, navigasi slide internal, tautan mouse-over teks, dan aksi makro. Contoh ini tidak mengeksekusi aksi apa pun. Ketiga kueri yang sama berfungsi pada setiap ruang lingkup; hitungan menggambarkan kontainer, bukan total aksi. Ruang lingkup bingkai teks mengecualikan tautan milik bentuk yang mengelilinginya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk contoh ini, kueri presentasi dan slide masing-masing melaporkan tiga kontainer klik, dua kontainer mouse-over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer pada setiap kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [Hyperlink.getActionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getActionType) untuk menafsirkan sebuah aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkactiontype/) mencakup lebih dari navigasi web:

| Nilai | Arti untuk audit |
| --- | --- |
| `Hyperlink` | Tautan hiperteks eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan makro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka file atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi tidak dikenal yang memerlukan peninjauan. |

Baca tujuan eksternal dari [getExternalUrl](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getExternalUrl) dan tujuan internal spesifik dari [getTargetSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getTargetSlide). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Simpan nilai yang dikembalikan oleh [getExternalUrlOriginal](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) ketika berbeda dari URL yang dinormalisasi, dan sertakan tooltip yang dikembalikan oleh [getTooltip](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlink/#getTooltip) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Tautan Hiperteks**

Contoh Python berikut membaca presentasi yang ada (gunakan file yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kedua jenis aktivasi lagi. Contoh ini mengumpulkan kontainer sebelum mengubahnya dan menggunakan kesetaraan referensi untuk menghindari pemrosesan kontainer yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventaris seluruh paket, juga secara eksplisit mengkueri master, tata letak, catatan, serta master catatan dan handout bila ada.

Kebijakan aplikasi yang sengaja dibatasi ini hanya mengizinkan URL HTTPS absolut dan target slide internal yang valid. Kebijakan ini menolak makro, program, aksi file, aksi slideshow lainnya, aksi tidak dikenal, dan skema URL lainnya. Penolakan ini merupakan keputusan kebijakan, bukan keputusan keselamatan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar putih host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalisasi diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk remediasi, [getHyperlinkManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getHyperlinkManager) pada kontainer mendukung [setExternalHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), dan [removeHyperlinkMouseOver](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman arahan HTTPS tetap; klik yang dilarang lainnya dan aksi mouse-over yang dilarang dihapus secara independen. Atur `replace_external_clicks` ke `False` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penyebaran.

Bendera ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: menandai aksi mouse-over dan apa pun selain tautan eksternal atau loncatan slide spesifik sebagai berpotensi tidak didukung. Ini merupakan petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak ditandai akan bertahan setelah ekspor. Ekspor [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/python-java/convert-powerpoint-to-html/) yang didukung dapat mempertahankan tautan hiperteks, tergantung pada aksi, opsi ekspor, dan penampil. [Gambar](/slides/id/python-java/convert-powerpoint-to-png/) raster dan [video](/slides/id/python-java/convert-powerpoint-to-video/) tidak dapat mempertahankan tautan hiperteks interaktif; tandai setiap aksi saat melakukan audit untuk output tersebut.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse-over file dan klik makro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi dilarang. Input yang berisi URL klik eksternal yang dilarang juga menguji cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse-over yang dilarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [removeAllHyperlinks](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), yang menghapus kedua jenis aktivasi di seluruh ruang lingkup yang dipilih tanpa mempedulikan kebijakan. Verifikasi di sini hanya memeriksa aksi tautan hiperteks; tidak menghapus proyek VBA yang disematkan, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi file PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana saya dapat menautkan ke bagian atau slide pertamanya?**

Bagian dalam PowerPoint mengelompokkan slide, namun tautan hiperteks internal menargetkan satu slide individu. Untuk membuat navigasi ke sebuah bagian, tautkan ke slide pertama dalam bagian tersebut.

**Apakah saya dapat menempelkan tautan hiperteks pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung tautan hiperteks. Tautan pada elemen-elemen ini tersedia selama pertunjukan slide pada slide yang menggunakan master atau tata letak yang bersangkutan.

**Apakah tautan hiperteks akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung dapat mempertahankan tautan hiperteks; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor dalam [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).