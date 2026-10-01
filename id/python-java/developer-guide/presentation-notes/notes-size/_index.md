---
title: Ubah Ukuran dan Orientasi Halaman Catatan di Python via Java
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/python-java/notes-size/
keywords:
- ukuran halaman catatan
- orientasi catatan
- catatan lanskap
- catatan potret
- ukuran handout
- PowerPoint
- presentasi
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk Python via Java, ubah orientasi, verifikasi ukuran yang disimpan, serta ekspor catatan atau handout ke PDF dan gambar."
---
## **Gambaran Umum**

Gunakan [Presentation.getNotesSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getNotesSize) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [NotesSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/notessize/) yang memiliki metode [setSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/notessize/#setSize) untuk mengatur dimensi halaman. Meskipun objek pengaturan tersebut tidak dapat diganti, Anda dapat menetapkan dimensi baru melalui metode ini.

Lebar dan tinggi ditentukan dalam **points**, dengan 72 points per inci. Sebagai contoh, 900 × 600 points adalah 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individual.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getNotesSize) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlideSize) | Mengontrol dimensi slide presentasi biasa melalui [SlideSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lainnya. Mengubah orientasi halaman catatan juga tidak memutar slide biasa. Lihat [Slide Size](/slides/id/python-java/slide-size/) untuk mengubah ukuran slide biasa.

Contoh di bawah ini menggunakan file `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi yang memiliki setidaknya satu slide dengan catatan pembicara. Setiap contoh dapat dijalankan secara terpisah.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi lalu bandingkan untuk menentukan orientasi: halaman yang lebih lebar adalah lanskap, yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman persegi. Contoh ini mencetak dimensi aktual dalam points, tanpa mengasumsikan ukuran kertas standar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah lanskap diubah kembali menjadi potret dan membiarkan halaman persegi tidak berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.getWidth() > size.getHeight()`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi sekaligus, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) untuk menulis presentasi. Contoh ini mengatur halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan mengizinkan toleransi 0.01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Hasil yang diharapkan adalah `900.0 x 600.0 points` dan `Size preserved: True`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut sendiri: konfigurasi opsi ekspor juga diperlukan. Ekspor slide biasa tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Terapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/) ke [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dan [RenderingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/) menjaga catatan pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Points menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga tergantung pada skala rendering.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/) memungkinkan halaman tambahan sesuai kebutuhan. Jangan gunakan mode itu dengan pemanggilan gambar satu slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak boleh dianggap sebagai jaminan semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/python-java/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/handoutlayoutingoptions/) untuk banyak thumbnail slide pada satu halaman. Contoh berikut mengatur halaman 900 × 600 point dan menggunakan [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/id/python-java/aspose.slides/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan tata letak handout, bukan metode gambar slide individual. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individual tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/python-java/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Jaga agar ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak tetap terpisah:

- **Presentation viewers:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letak mereka sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensi lagi; konversi format aplikasi tersebut dapat menormalkannya.
- **Export formats:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang dikonfigurasi. Gambar raster menggunakan dimensi piksel bulat dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Mengekspor slide biasa tidak menerapkan ukuran halaman catatan.
- **Printer drivers:** Pemilihan kertas, rotasi otomatis, dan pengaturan fit‑to‑page dapat mengubah hasil fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan hanya untuk satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individual dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide biasa memiliki dimensi yang independen. Gunakan pengaturan ukuran slide biasa ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran yang berbeda?**

Pertama, buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah penyimpanan atau konversi file oleh aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pemilihan kertas printer.