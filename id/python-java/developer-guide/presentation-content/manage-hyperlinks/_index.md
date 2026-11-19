---
title: Kelola Hyperlink Presentasi dalam Python via Java
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/python-java/manage-hyperlinks/
keywords:
- tambahkan URL
- tambahkan hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Tambahkan, format, perbarui, dan hapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via Java, menggunakan contoh Python."
---
## **Pendahuluan**

Sebuah hyperlink menghubungkan konten presentasi ke situs web atau lokasi di dalam presentasi. Di PowerPoint, hyperlink biasanya berfungsi untuk dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides for Python via Java memungkinkan Anda menambahkan tautan ini, mengontrol tampilan dan suaranya, memperbarui properti, dan menghapusnya. Contoh di bawah ini menunjukkan cara bekerja dengan hyperlink pada elemen individu dan cara mengakses hyperlink pada tingkat presentasi, slide, atau kerangka teks.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor PowerPoint online gratis Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Tambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen tempat Anda menetapkan hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sedangkan bentuk atau bingkai menautkan objek slide.

Untuk presentasi yang berisi hyperlink relatif, lihat [Kelola Base Hyperlink](/slides/id/python-java/presentation-properties/#manage-the-hyperlink-base) untuk membaca, mengubah, atau membersihkan basis tingkat dokumen.

### **Tambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, lewatkan sebuah [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) ke metode [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) pada bagian teks, seperti ditunjukkan di bawah. Hanya bagian teks itu yang menjadi dapat diklik.

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

### **Tambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Panggil [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) pada persegi panjang untuk membuat seluruh area dapat diklik. Gunakan [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) untuk menampilkan petunjuk tentang tujuan ketika pengguna mengarahkan kursor ke persegi panjang. Kedua metode juga berlaku untuk bingkai gambar, audio, dan video.

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

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

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

## **Format Hyperlink**

Anda dapat mengubah warna teks yang ditautkan, memutar atau menghentikan suara ketika pembaca mengaktifkan tautan, dan mengatur tooltip yang muncul saat mengarahkan kursor.

### **Warna**

Metode [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) pada [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau pemformatan bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) dan atur warna isi bagian. Fitur ini diperkenalkan di PowerPoint 2019; versi lama tidak menerapkan pengaturan ini.

Dalam contoh ini, [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) membuat tautan pertama menggunakan isi merah pada bagian teks. Tautan kedua mempertahankan warna hyperlink presentasi.

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

Sebuah hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sudah diputar. Gunakan metode berikut untuk mengkonfigurasi perilaku ini:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) menentukan audio yang terkait dengan hyperlink.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Tombol pada slide pertama menggunakan [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) untuk memutar audio dari `sampleaudio.wav` ketika pembaca mengklik untuk melanjutkan. Pada slide kedua, tombol terpisah menggunakan [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) untuk menghentikan pemutaran dan menjaga pembaca tetap pada slide tersebut.

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

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) dan [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

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

Anda dapat memanggil metode [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) berikut setelah menetapkan hyperlink ke teks atau bentuk:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) mengatur teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) menentukan bingkai target dalam satu set bingkai HTML induk, bila berlaku.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) mengontrol apakah mengaktifkan tautan menambahkan tujuannya ke daftar hyperlink yang telah dilihat.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) mengontrol apakah hyperlink disorot saat diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua jenis aktivasi dari slide pertama. Untuk menghapus hanya satu jenis, panggil hanya [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) atau [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); menghapus aksi klik tidak menghapus pasangan mouse‑over-nya.

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

Untuk penghapusan tanpa syarat, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) menghapus kedua jenis aktivasi dalam lingkup yang dipilih dalam satu panggilan. Untuk pembersihan selektif dan cakupan master, tata letak, serta catatan, lihat [Laporan, Sanitasi, dan Verifikasi Hyperlink](#report-sanitize-and-verify-hyperlinks).

### **Bersihkan Hyperlink Sebelum Mengganti Teks SmartArt**

Saat Anda mengganti paragraf dalam node SmartArt yang ada, membersihkan bagian teksnya dapat meninggalkan hyperlink lama yang masih aktif. Dapatkan paragraf melalui [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame). Sebelum membersihkan bagiannya, panggil [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) pada kerangka teks bentuk node yang menampilkan paragraf, kemudian panggil [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) pada objek yang dikembalikan. Ini menghapus semua hyperlink dalam kerangka tersebut, termasuk tautan di paragraf lain.

Contoh mengasumsikan bahwa bentuk ketiga pada slide pertama `SmartArtHyperlink.pptx` adalah grafik SmartArt. Ia mengganti paragraf pertama node keempat. Dalam presentasi ini, bentuk pertama node menampilkan paragraf tersebut.

Setelah menambahkan kedua bagian, contoh membaca pemformatan efektif mereka dengan [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective). Pada pemformatan itu, `getHyperlinkClick` mengembalikan hyperlink baru untuk bagian pertama dan `None` untuk bagian kedua.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # None
finally:
    presentation.dispose()
```

## **Bangun Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasikan aksi interaktif serta tautan webnya. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) mengembalikan kontainer hyperlink, seperti objek [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) dan [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), bukan daftar datar string URL. Periksa baik [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) maupun [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) pada setiap kontainer. Mereka independen: kontainer yang sama dapat mengekspos kedua aksi, sehingga laporan lengkap memerlukan hingga dua baris per kontainer.

Memindai hanya hyperlink tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Kueri lingkup yang tepat sebagai gantinya, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksinya nanti.

### **Kueri Lingkup Presentasi, Slide, dan Kerangka Teks**

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) tersedia melalui [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries), dan [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Setiap lingkup mendukung kueri yang sama:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) mengembalikan kontainer dengan aksi klik.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) mengembalikan kontainer dengan aksi mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh ini menetapkan aksi klik dan mouse‑over pada sebuah bentuk dan teksnya, serta aksi makro pada tombol terpisah. Ia membandingkan jumlah kontainer yang dikembalikan oleh [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) dengan hitungan untuk setiap jenis aktivasi. Kueri kerangka teks menghitung hanya tautan dalam teks. Aksi bentuk yang membungkus muncul dalam kueri slide dan presentasi.

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

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga kontainer klik, dua kontainer mouse‑over, dan tiga kontainer dengan salah satu aksi. Kueri kerangka teks melaporkan satu kontainer di masing‑masing kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) untuk menafsirkan suatu aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) mencakup lebih dari navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan macro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka file atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Mulai atau hentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi tidak dikenal yang memerlukan tinjauan. |

Baca tujuan eksternal dari [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) dan tujuan internal spesifik dari [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Simpan nilai yang dikembalikan oleh [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) bila berbeda dari URL yang dinormalisasi, dan sertakan tooltip yang dikembalikan oleh [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh ini membuka presentasi dari contoh sebelumnya dan menulis satu rekam JSON per aksi. Ia menggunakan [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) untuk mengumpulkan kontainer pada slide biasa, master, tata letak, dan catatan, termasuk master catatan dan handout bila ada. Ia menggunakan kesetaraan referensi untuk menghitung setiap kontainer sekali, menerapkan kebijakan yang dijelaskan di bawah, dan membuka kembali presentasi yang disimpan untuk memeriksa kedua aksi klik dan mouse‑over.

Laporan mencatat indeks slide berbasis satu dan [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) bila tersedia. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) menyediakan slide pemilik untuk kontainer yang didukung. Master, tata letak, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi oleh lingkupnya. Kontainer bentuk dan kontainer pemformatan bagian teks diberi label terpisah; tipe kontainer lain mempertahankan nama tipe runtime mereka. Setiap kontainer mendapat ID lokal laporan sehingga dua aksinya dapat dikaitkan. Laporan menyimpan tipe aksi sebagai konstanta integer yang didefinisikan oleh enumerasi Java.

Kebijakan aplikasi yang sengaja restriktif ini hanya memperbolehkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak macro, program, aksi file, aksi slideshow lain, aksi tidak dikenal, dan skema URL lain. Penolakan ini adalah keputusan kebijakan, bukan putusan keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar izinkan host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalisasi diperiksa. Contoh mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk perbaikan, [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) kontainer mendukung [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), dan [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landas HTTPS tetap; klik dan aksi mouse‑over yang dilarang lain dihapus secara independen. Atur `replace_external_clicks` ke `False` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penerapan.

Bendera ekspor laporan menggunakan kebijakan tinjauan PDF konservatif: beri bendera pada aksi mouse‑over dan apa pun selain tautan eksternal atau loncatan slide spesifik sebagai kemungkinan tidak didukung. Itu hanyalah petunjuk tinjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak dibendera akan bertahan pada ekspor. Ekspor [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/python-java/convert-powerpoint-to-html/) yang didukung dapat mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Raster [gambar](/slides/id/python-java/convert-powerpoint-to-png/) dan [video](/slides/id/python-java/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri bendera pada setiap aksi saat mengaudit output tersebut.

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

Dengan masukan yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse‑over file dan klik macro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi terlarang. Masukan yang berisi URL klik eksternal terlarang juga menjalankan cabang penggantian. Kontainer dengan klik yang diizinkan dan mouse‑over terlarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), yang menghapus kedua jenis aktivasi di seluruh lingkup yang dipilih tanpa mempedulikan kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; ia tidak menghapus proyek VBA yang disematkan, objek OLE, atau konten aktif lain, dan tidak memvalidasi file PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana cara menautkan ke sebuah bagian atau slide pertamanya?**

Bagian di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan slide individual. Untuk membuat navigasi ke sebuah bagian, tautkan ke slide pertama dalam bagian tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan pada elemen ini tersedia selama pertunjukan slide pada slide yang menggunakan master atau tata letak yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung mungkin mempertahankan hyperlink; raster gambar dan video tidak dapat. Lihat pertimbangan ekspor dalam [Laporan, Sanitasi, dan Verifikasi Hyperlink](#report-sanitize-and-verify-hyperlinks).