---
title: Konversi Presentasi PowerPoint ke TIFF dengan Catatan dalam PHP
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk PHP via Java. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for PHP via Java menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi dengan catatan pembicara, tetapi juga menghasilkan thumbnail slide dalam tampilan Notes Slide. Proses konversi sederhana dan efisien, memanfaatkan metode `save` dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letaknya.

## **Konversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for PHP via Java melibatkan langkah-langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.
1. Konfigurasikan opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/) untuk menentukan bagaimana catatan dan komentar ditampilkan.
1. Simpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasi ke metode [save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![Slide presentasi dengan catatan pembicara](slide_with_notes.png)

Potongan kode di bawah ini memperlihatkan cara mengonversi presentasi menjadi gambar TIFF dalam tampilan Notes Slide menggunakan metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```php
// Instansiasikan kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Tampilkan catatan di bawah slide.

    // Konfigurasikan opsi TIFF dengan tata letak Catatan.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Simpan presentasi ke TIFF dengan catatan pembicara.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Gambar TIFF dengan catatan pembicara](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengontrol posisi area catatan di TIFF yang dihasilkan?**

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) untuk memilih di antara opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing-masing menyembunyikan catatan, menyesuaikannya ke dalam satu halaman, atau memungkinkan catatan mengalir ke halaman tambahan.

**Bagaimana saya dapat mengurangi ukuran file TIFF dengan catatan tanpa kehilangan kualitas yang terlihat?**

Pilih [efficient compression](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/setcompressiontype/) (mis., `LZW` atau `RLE`), atur DPI yang wajar, dan, jika dapat diterima, gunakan [pixel format](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/setpixelformat/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/setimagesize/) juga dapat membantu tanpa secara signifikan mengurangi keterbacaan.

**Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang hilang memicu [substitution](/slides/id/php-java/font-selection-sequence/), yang dapat mengubah metrik teks dan tampilan. Untuk menghindarinya, [supply the required fonts](/slides/id/php-java/custom-font/) atau atur [fallback font](/slides/id/php-java/fallback-font/) default sehingga jenis huruf yang dimaksud digunakan.