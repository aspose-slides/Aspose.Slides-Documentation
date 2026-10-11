---
title: Ubah Ukuran dan Orientasi Halaman Catatan di JavaScript
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/nodejs-java/notes-size/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk Node.js via Java, ubah orientasi, verifikasi ukuran yang disimpan, dan ekspor catatan atau handout ke PDF dan gambar."
---
## **Ikhtisar**

Gunakan [Presentation.getNotesSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getnotessize/) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [NotesSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notessize/) yang memiliki metode [setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notessize/setsize/) untuk mengatur dimensi halaman. Meskipun objek pengaturan tidak dapat diganti, Anda dapat menetapkan dimensi baru melalui metode ini.

Lebar dan tinggi ditentukan dalam **points**, dengan 72 points per inch. Misalnya, 900 × 600 points adalah 12,5 × 8⅓ inches. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individual.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getnotessize/) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslidesize/) | Mengontrol dimensi slide presentasi biasa melalui [SlideSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide biasa. Lihat [Slide Size](/slides/id/nodejs-java/slide-size/) untuk mengubah ukuran slide biasa.

Contoh di bawah ini menggunakan file `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi dengan setidaknya satu slide yang berisi catatan speaker. Setiap contoh dapat dijalankan secara independen.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi lalu bandingkan untuk menentukan orientasinya: halaman yang lebih lebar adalah lanskap, halaman yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman persegi. Contoh ini mencetak dimensi sebenarnya dalam points, tanpa mengasumsikan ukuran kertas standar.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah dalam mode lanskap berpindah kembali ke potret dan membiarkan halaman persegi tetap tidak berubah.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.getWidth() > size.getHeight()`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi sekaligus, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/save/) untuk menulis presentasi. Contoh ini mengatur halaman lanskap 900 × 600 points, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan memperbolehkan toleransi 0,01 point untuk nilai floating-point; ini bukan jaminan presisi untuk setiap format file.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Hasil yang diharapkan adalah `900 x 600 points` dan `Size preserved: true`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut secara otomatis: konfigurasikan juga opsi ekspor. Ekspor slide reguler tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ke [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage) dan [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notespositions/) menjaga catatan tetap pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 points. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Points menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga tergantung pada skala rendering.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notespositions/) memungkinkan halaman tambahan sesuai kebutuhan. Jangan gunakan mode tersebut dengan panggilan gambar satu slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes-master yang ada; mengubah dimensi halaman saja tidak dapat dijadikan jaminan bahwa semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/nodejs-java/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut mengatur halaman 900 × 600 points dan menggunakan [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.getImages](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getimages/) dengan tata letak handout, bukan metode gambar slide individual. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara panggilan gambar slide individual tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/nodejs-java/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Pertahankan perbedaan antara ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak:

- **Penampil presentasi:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letaknya sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensinya kembali; konversi format aplikasi tersebut mungkin menormalkannya.
- **Format ekspor:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang dikonfigurasi. Gambar raster menggunakan dimensi piksel bulat dan skala rendering, sehingga nilai points pecahan dapat dibulatkan dalam output gambar. Mengekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Driver printer:** Pemilihan kertas, rotasi otomatis, dan pengaturan ukuran ke halaman dapat mengubah output fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan untuk hanya satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individual dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran yang berbeda?**

Pertama buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika dimensi tersebut berubah, periksa apakah penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pemilihan kertas printer.