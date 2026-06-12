---
title: Konversi Presentasi PowerPoint ke TIFF dengan Catatan di Python
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/python-net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint dengan catatan
- presentasi dengan catatan
- slide dengan catatan
- PPT dengan catatan
- PPTX dengan catatan
- TIFF dengan catatan
- Python
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk Python via .NET. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) beserta catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi dengan catatan pembicara, tetapi juga menghasilkan thumbnail slide dalam tampilan Notes Slide. Proses konversi sederhana dan efisien, memanfaatkan metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letaknya.

## **Konversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for Python via .NET melibatkan langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
1. Atur opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/) untuk menentukan cara menampilkan catatan dan komentar.  
1. Simpan presentasi ke TIFF: Serahkan opsi yang telah diatur ke metode [save](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![The presentation slide with speaker notes](slide_with_notes.png)

Cuplikan kode di bawah ini memperlihatkan cara mengonversi presentasi menjadi gambar TIFF dalam tampilan Notes Slide menggunakan properti [slides_layout_options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/slides_layout_options/).

```py
# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Menampilkan catatan di bawah slide.
    
    # Mengatur opsi TIFF dengan tata letak Catatan.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Menyimpan presentasi ke TIFF dengan catatan pembicara.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Hasilnya:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Tanya Jawab**

**Apakah saya dapat mengontrol posisi area catatan dalam TIFF yang dihasilkan?**

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) untuk memilih antara opsi seperti `NONE`, `BOTTOM_TRUNCATED`, atau `BOTTOM_FULL`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau membiarkan catatan meluas ke halaman tambahan.

**Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa mengorbankan kualitas yang terlihat?**

Pilih [efficient compression](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/compression_type/) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila memungkinkan, gunakan [pixel format](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/pixel_format/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/image_size/) juga dapat membantu tanpa secara signifikan memengaruhi keterbacaan.

**Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang hilang memicu [substitution](/slides/id/python-net/font-selection-sequence/), yang dapat mengubah metrik teks dan tampilan. Untuk menghindarinya, [supply the required fonts](/slides/id/python-net/custom-font/) atau tetapkan [fallback font](/slides/id/python-net/fallback-font/) default agar jenis huruf yang diinginkan digunakan.