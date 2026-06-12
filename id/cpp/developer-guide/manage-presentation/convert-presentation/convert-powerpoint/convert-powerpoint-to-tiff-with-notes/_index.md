---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan Catatan di C++
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk C++. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for C++ menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi beserta catatan pembicara, tetapi juga menghasilkan thumbnail slide dalam tampilan Notes Slide. Proses konversi sederhana dan efisien, menggunakan metode `Save` dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letaknya.

## **Mengonversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for C++ melibatkan langkah‑langkah berikut:

1. Membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
2. Mengonfigurasi opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/) untuk menentukan cara menampilkan catatan dan komentar.  
3. Menyimpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasi ke metode [Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![The presentation slide with speaker notes](slide_with_notes.png)

Cuplikan kode di bawah ini menunjukkan cara mengonversi presentasi menjadi gambar TIFF dalam tampilan Notes Slide menggunakan metode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// Instansiasikan kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Tampilkan catatan di bawah slide.

// Konfigurasikan opsi TIFF dengan penataan Catatan.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Simpan presentasi ke TIFF dengan catatan pembicara.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Hasilnya:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengontrol posisi area catatan dalam TIFF yang dihasilkan?**

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) untuk memilih antara opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau memungkinkan catatan meluas ke halaman tambahan.

**Bagaimana saya dapat mengurangi ukuran file TIFF dengan catatan tanpa kehilangan kualitas yang terlihat?**

Pilih [efficient compression](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila memungkinkan, gunakan [pixel format](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_imagesize/) juga dapat membantu tanpa mengurangi keterbacaan secara signifikan.

**Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang hilang memicu [substitution](/slides/id/cpp/font-selection-sequence/), yang dapat mengubah metrik teks dan penampilan. Untuk menghindari hal ini, [supply the required fonts](/slides/id/cpp/custom-font/) atau tetapkan [fallback font](/slides/id/cpp/fallback-font/) default sehingga jenis huruf yang dimaksud digunakan.