---
title: Ubah Ukuran dan Orientasi Halaman Catatan dalam Java
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/java/notes-size/
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
- Java
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk Java, ubah orientasi, verifikasi ukuran yang disimpan, serta ekspor catatan atau handout ke PDF dan gambar."
---
## **Ringkasan**

Gunakan [Presentation.getNotesSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getNotesSize--) untuk mengakses pengaturan halaman catatan presentasi. Ini mengembalikan objek [INotesSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotessize/) yang metode [setSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-)‑nya mengatur dimensi halaman. Meskipun objek pengaturan itu sendiri tidak dapat diganti, Anda dapat menetapkan dimensi baru melalui metode ini.

Lebar dan tinggi ditentukan dalam **point**, dengan 72 point per inci. Misalnya, 900 × 600 point adalah 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getNotesSize--) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSlideSize--) | Mengontrol dimensi slide presentasi biasa melalui [ISlideSize](https://reference.aspose.com/slides/id/java/com.aspose.slides/islidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide biasa. Lihat [Slide Size](/slides/id/java/slide-size/) untuk mengubah ukuran slide biasa.

Contoh di bawah menggunakan `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi dengan setidaknya satu slide yang berisi catatan pembicara. Setiap contoh dapat dijalankan secara independen.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi lalu bandingkan untuk menentukan orientasi: halaman yang lebih lebar adalah lanskap, yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman berbentuk persegi. Contoh ini mencetak dimensi sebenarnya dalam point, tanpa mengasumsikan ukuran kertas standar.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Ubah ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah lanskap menjadi kembali ke potret dan membiarkan halaman persegi tidak berubah.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.getWidth() > size.getHeight()`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi sekaligus, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis presentasi. Contoh ini menetapkan halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan memperbolehkan toleransi 0,01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Hasil yang diharapkan adalah `900.0 x 600.0 points` dan `Size preserved: true`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan di memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut sendiri: konfigurasikan opsi ekspor juga. Ekspor slide biasa tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/notescommentslayoutingoptions/) ke [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) dan [RenderingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/java/com.aspose.slides/notespositions/) menjaga catatan pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Point menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga tergantung pada skala rendering.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/java/com.aspose.slides/notespositions/) memungkinkan halaman tambahan bila diperlukan. Jangan gunakan mode itu dengan panggilan gambar satu‑slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek master catatan yang ada; mengubah dimensi halaman saja tidak boleh dianggap sebagai jaminan bahwa semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/java/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut menetapkan halaman 900 × 600 point dan menggunakan [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/id/java/com.aspose.slides/handouttype/) untuk mengatur hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.getImages](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) dengan tata letak handout, bukan metode gambar slide individual. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara panggilan gambar slide individual tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/java/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Jaga ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak tetap terpisah:

- **Penampil presentasi:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letaknya sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensi lagi; konversi format aplikasi tersebut mungkin menormalkannya.
- **Format ekspor:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang telah dikonfigurasi. Gambar raster menggunakan dimensi piksel integer dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Mengekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Driver printer:** Pemilihan kertas, rotasi otomatis, dan pengaturan fit‑to‑page dapat mengubah output fisik tanpa mengubah dimensi yang disimpan di presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan hanya untuk satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individu dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang disimpan atau dicetak memiliki ukuran berbeda?**

Pertama buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pilihan kertas printer.