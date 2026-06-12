---
title: Konversi Slide Presentasi menjadi Gambar dalam JavaScript
linktitle: Slide ke Gambar
type: docs
weight: 35
url: /id/nodejs-java/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi slide dari PPT, PPTX, dan ODP menjadi gambar dalam JavaScript menggunakan Aspose.Slides untuk Node.js via Java — rendering cepat dengan kualitas tinggi dan contoh kode yang jelas."
---
## **Pendahuluan**

Aspose.Slides untuk Node.js via Java memungkinkan Anda dengan mudah mengonversi slide presentasi PowerPoint dan OpenDocument ke berbagai format gambar, termasuk BMP, PNG, JPG (JPEG), GIF, dan lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Tentukan pengaturan konversi yang diinginkan dan pilih slide yang ingin Anda ekspor dengan menggunakan:
    - Kelas [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/), atau
    - Kelas [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/).
2. Hasilkan gambar slide dengan memanggil metode [getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage).

Di Aspose.Slides untuk Node.js via Java, sebuah [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) adalah kelas yang memungkinkan Anda bekerja dengan gambar yang didefinisikan oleh data piksel. Anda dapat menggunakan kelas ini untuk menyimpan gambar dalam berbagai format (BMP, JPG, PNG, dll.).

## **Konversi Slide ke Bitmap dan Simpan Gambar dalam PNG**

Anda dapat mengonversi slide ke objek bitmap dan menggunakannya langsung dalam aplikasi Anda. Atau, Anda dapat mengonversi slide ke bitmap lalu menyimpan gambar dalam format JPEG atau format lain yang diinginkan.

Kode JavaScript berikut memperlihatkan cara mengonversi slide pertama dari presentasi menjadi objek bitmap dan kemudian menyimpan gambar dalam format PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konversi slide pertama dalam presentasi menjadi bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Simpan gambar dalam format PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konversi Slide ke Gambar dengan Ukuran Kustom**

Anda mungkin perlu mendapatkan gambar dengan ukuran tertentu. Dengan menggunakan overload dari [getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage), Anda dapat mengonversi slide menjadi gambar dengan dimensi spesifik (lebar dan tinggi).

Kode contoh berikut memperlihatkan cara melakukannya:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konversi slide pertama dalam presentasi menjadi bitmap dengan ukuran yang ditentukan.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Simpan gambar dalam format JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konversi Slide dengan Catatan dan Komentar menjadi Gambar**

Beberapa slide mungkin berisi catatan dan komentar.

Aspose.Slides menyediakan dua kelas—[TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/) dan [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/)—yang memungkinkan Anda mengontrol rendering slide presentasi menjadi gambar. Kedua kelas menyertakan metode `setSlidesLayoutOptions`, yang memungkinkan Anda mengonfigurasi rendering catatan dan komentar pada slide saat mengonversinya menjadi gambar.

Dengan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/), Anda dapat menentukan posisi yang diinginkan untuk catatan dan komentar dalam gambar yang dihasilkan.

Kode JavaScript berikut memperlihatkan cara mengonversi slide dengan catatan dan komentar:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Atur posisi catatan.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Atur posisi komentar.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Atur lebar area komentar.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Atur warna area komentar.

    // Buat opsi rendering.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konversi slide pertama presentasi menjadi gambar.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Simpan gambar dalam format GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Dalam proses konversi slide ke gambar apa pun, metode [setNotesPosition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) tidak dapat menerapkan `BottomFull` (untuk menentukan posisi catatan) karena teks catatan mungkin terlalu besar, sehingga tidak dapat muat dalam ukuran gambar yang ditentukan.

{{% /alert %}} 

## **Konversi Slide ke Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/) menyediakan kontrol yang lebih besar atas gambar TIFF yang dihasilkan dengan memungkinkan Anda menentukan parameter seperti ukuran, resolusi, palet warna, dan lainnya.

Kode JavaScript berikut memperlihatkan proses konversi di mana opsi TIFF digunakan untuk menghasilkan gambar hitam-putih dengan resolusi 300 DPI dan ukuran 2160 × 2800:

```js
// Muat file presentasi.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Dapatkan slide pertama dari presentasi.
    let slide = presentation.getSlides().get_Item(0);

    // Konfigurasikan pengaturan gambar TIFF output.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Atur ukuran gambar.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Atur format piksel (hitam putih).
    tiffOptions.setDpiX(300);                                                          // Atur resolusi horizontal.
    tiffOptions.setDpiY(300);                                                          // Atur resolusi vertikal.

    // Konversi slide menjadi gambar dengan opsi yang ditentukan.
    let image = slide.getImage(tiffOptions);
    try {
        // Simpan gambar dalam format TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Dukungan TIFF tidak dijamin pada versi sebelum JDK 9.

{{% /alert %}} 

## **Konversi Semua Slide menjadi Gambar**

Aspose.Slides memungkinkan Anda mengonversi semua slide dalam sebuah presentasi menjadi gambar, secara efektif mengubah seluruh presentasi menjadi serangkaian gambar.

Kode contoh berikut memperlihatkan cara mengonversi semua slide dalam sebuah presentasi menjadi gambar menggunakan JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Render presentasi menjadi gambar slide per slide.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Kendalikan slide tersembunyi (jangan render slide tersembunyi).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Konversi slide menjadi gambar.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Simpan gambar dalam format JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak, metode `getImage` hanya menyimpan gambar statis dari slide, tanpa animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya, slide tersembunyi dapat diproses seperti slide biasa. Pastikan saja mereka termasuk dalam loop pemrosesan.

**Apakah gambar dapat disimpan dengan bayangan dan efek?**

Ya, Aspose.Slides mendukung rendering bayangan, transparansi, dan efek grafis lainnya saat menyimpan slide sebagai gambar.