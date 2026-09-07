---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan Catatan di Python
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke TIFF
- presentasi ke TIFF
- slide ke TIFF
- PPT ke TIFF
- PPTX ke TIFF
- simpan PPT sebagai TIFF
- simpan PPTX sebagai TIFF
- ekspor PPT ke TIFF
- ekspor PPTX ke TIFF
- PowerPoint dengan catatan
- presentasi dengan catatan
- slide dengan catatan
- PPT dengan catatan
- PPTX dengan catatan
- TIFF dengan catatan
- Python
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk Python via Java. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for Python via Java menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) beserta catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Gunakan metode [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) pada kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) untuk mengekspor slide dan catatan pembicara ke satu file TIFF multipage.

## **Mengonversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for Python via Java melibatkan langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.
1. Konfigurasikan opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/) untuk menentukan cara menampilkan catatan dan komentar.
1. Simpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasikan ke metode [save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![Slide presentasi dengan catatan pembicara](slide_with_notes.png)

Potongan kode di bawah ini menunjukkan cara mengonversi presentasi ke gambar TIFF dalam tampilan Slide Catatan menggunakan metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Tampilkan catatan pembicara lengkap di bawah setiap slide.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Atur resolusi TIFF dan tata letak catatan.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Simpan presentasi ke TIFF dengan catatan pembicara.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Hasilnya:

![Gambar TIFF dengan catatan pembicara](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengontrol posisi area catatan pada TIFF yang dihasilkan?**

Ya. Konfigurasikan [setNotesPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) dengan [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/#BottomTruncated) untuk menampung catatan pada satu halaman, yang mungkin memotongnya, atau [NotesPositions.BottomFull](https://reference.aspose.com/slides/id/python-java/aspose.slides/notespositions/#BottomFull) untuk menampilkan semua catatan menggunakan halaman tambahan bila diperlukan. Untuk mengekspor slide tanpa catatan, lewati konfigurasi tata letak catatan seperti yang ditunjukkan pada [Convert PowerPoint to TIFF](/slides/id/python-java/convert-powerpoint-to-tiff/).

**Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa mengurangi kualitas gambar?**

Gunakan kompresi [LZW compression](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffcompressiontypes/#LZW) yang lossless melalui [setCompressionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/#setCompressionType). Mengurangi resolusi atau kedalaman warna dapat lebih menurunkan ukuran file, tetapi dapat memengaruhi kualitas gambar dan keterbacaan catatan. Lihat [TIFF export settings](/slides/id/python-java/convert-powerpoint-to-tiff/) untuk opsi lainnya.

**Apakah font pada catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang tidak ada memicu [font substitution](/slides/id/python-java/font-selection-sequence/), yang dapat mengubah metrik dan tampilan teks. [Supply the required fonts](/slides/id/python-java/custom-font/) untuk mempertahankan jenis huruf yang dimaksud.