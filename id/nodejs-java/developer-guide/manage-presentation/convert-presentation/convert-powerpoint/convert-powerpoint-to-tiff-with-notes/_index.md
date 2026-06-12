---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan Catatan dalam JavaScript
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke TIFF dengan catatan dalam JavaScript menggunakan Aspose.Slides untuk Node.js. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for Node.js via Java menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi dengan catatan pembicara tetapi juga menghasilkan thumbnail slide dalam tampilan Notes Slide. Proses konversi sederhana dan efisien, menggunakan metode `save` dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letaknya.

## **Mengonversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for Node.js via Java melibatkan langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
1. Konfigurasi opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/) untuk menentukan bagaimana catatan dan komentar harus ditampilkan.  
1. Simpan presentasi ke TIFF: Berikan opsi yang dikonfigurasi ke metode [save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![Slide presentasi dengan catatan pembicara](slide_with_notes.png)

Potongan kode di bawah ini memperlihatkan cara mengonversi presentasi ke gambar TIFF dalam tampilan Notes Slide menggunakan metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Tampilkan catatan di bawah slide.

    // Konfigurasikan opsi TIFF dengan penataan Catatan.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Simpan presentasi ke TIFF dengan catatan pembicara.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Hasil:

![Gambar TIFF dengan catatan pembicara](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Bisakah saya mengontrol posisi area catatan dalam TIFF yang dihasilkan?**

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) untuk memilih di antara opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau memungkinkan catatan mengalir ke halaman tambahan.

**Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa kehilangan kualitas yang terlihat?**

Pilih [efficient compression](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila memungkinkan gunakan [pixel format](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/setimagesize/) juga dapat membantu tanpa secara signifikan mengurangi keterbacaan.

**Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang hilang memicu [substitution](/slides/id/nodejs-java/font-selection-sequence/), yang dapat mengubah metrik teks dan tampilan. Untuk menghindarinya, [supply the required fonts](/slides/id/nodejs-java/custom-font/) atau tetapkan [fallback font](/slides/id/nodejs-java/fallback-font/) default sehingga jenis huruf yang dimaksud digunakan.