---
title: Ubah Ukuran dan Orientasi Halaman Catatan di Python
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/python-net/notes-size/
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
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk Python via .NET, ubah orientasi, verifikasi ukuran yang disimpan, dan ekspor catatan atau handout ke PDF dan gambar."
---
## **Ikhtisar**

Gunakan [Presentation.notes_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/notes_size/) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [NotesSize](https://reference.aspose.com/slides/id/python-net/aspose.slides/notessize/) yang properti [size](https://reference.aspose.com/slides/id/python-net/aspose.slides/notessize/size/)‑nya dapat ditulisi. Walaupun objek pengaturan itu sendiri bersifat read‑only, Anda dapat menetapkan dimensi baru pada properti size‑nya.

Lebar dan tinggi ditentukan dalam **point**, dengan 72 point per inci. Misalnya, 900 × 600 point setara dengan 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/notes_size/) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.slide_size](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slide_size/) | Mengontrol dimensi slide presentasi reguler melalui [SlideSize](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide reguler. Lihat [Slide Size](/slides/id/python-net/slide-size/) untuk mengubah ukuran slide reguler.

Contoh di bawah menggunakan file `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi yang setidaknya memiliki satu slide dengan catatan pembicara. Setiap contoh dapat dijalankan secara terpisah.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi lalu bandingkan untuk menentukan orientasi: halaman yang lebih lebar adalah lanskap, yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman persegi. Contoh ini mencetak dimensi aktual dalam point, tanpa mengasumsikan ukuran kertas standar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Berpindah ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk yang berasal dari ukuran kertas kustom. Kondisi di bawah mencegah halaman yang sudah lanskap berubah kembali menjadi potret dan membiarkan halaman persegi tidak berubah.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.width > size.height`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi secara bersamaan, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/) untuk menulis presentasi. Contoh ini menetapkan halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan mengizinkan toleransi 0,01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Hasil yang diharapkan adalah `900 x 600 points` dan `Size preserved: True`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan di memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut sendiri: konfigurasi opsi ekspor juga diperlukan. Ekspor slide reguler tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/) ke [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/) dan [RenderingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/).

Mode [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notespositions/) mempertahankan catatan pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Point menggambarkan geometri halaman; piksel menggambarkan keluaran raster, yang dimensinya juga tergantung pada skala rendering.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Untuk ekspor PDF dengan catatan panjang, [BOTTOM_FULL](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notespositions/) memungkinkan penambahan halaman sesuai kebutuhan. Jangan gunakan mode itu dengan pemanggilan gambar satu‑slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak menjamin semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/python-net/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/handoutlayoutingoptions/) untuk menampilkan beberapa miniatur slide pada satu halaman. Contoh berikut menetapkan halaman 900 × 600 point dan menggunakan [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.get_images](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/) dengan tata letak handout, bukan metode gambar slide individu. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individu tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/python-net/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Pertahankan perbedaan antara ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak:

- **Penampil presentasi:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letaknya sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensi lagi; konversi format aplikasi tersebut mungkin menormalkannya.
- **Format ekspor:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang dikonfigurasi. Gambar raster menggunakan dimensi piksel integer dan skala rendering, sehingga nilai point pecahan dapat dibulatkan pada output gambar. Mengekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Driver printer:** Pemilihan kertas, rotasi otomatis, dan pengaturan fit‑to‑page dapat mengubah output fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan hanya untuk satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individual dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran yang berbeda?**

Pertama, buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pilihan kertas printer.