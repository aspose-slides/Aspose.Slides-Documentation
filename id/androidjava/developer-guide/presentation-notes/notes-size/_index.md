---
title: Ubah Ukuran dan Orientasi Halaman Catatan di Android
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk Android via Java, ubah orientasi, verifikasi ukuran yang disimpan, dan ekspor catatan atau handout ke PDF dan gambar."
---
## **Ringkasan**

Gunakan [Presentation.getNotesSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getNotesSize--) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [INotesSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotessize/) yang memiliki metode [setSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) untuk menetapkan dimensi halaman. Meskipun objek pengaturan tidak dapat diganti, Anda dapat menetapkan dimensi baru melalui metode ini.

Lebar dan tinggi ditentukan dalam **point**, dengan 72 point per inci. Misalnya, 900 × 600 point adalah 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Mengontrol dimensi slide presentasi reguler melalui [ISlideSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide reguler. Lihat [Slide Size](/slides/id/androidjava/slide-size/) untuk mengubah ukuran slide reguler.

Contoh di bawah ini menggunakan `sample.pptx` yang ada. Untuk contoh ekspor, gunakan presentasi dengan setidaknya satu slide yang berisi catatan pembicara. Setiap contoh dapat dijalankan secara terpisah.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi dan bandingkan untuk menentukan orientasinya: halaman yang lebih lebar merupakan lanskap, halaman yang lebih tinggi merupakan potret, dan dimensi yang sama menggambarkan halaman berbentuk persegi. Contoh ini mencetak dimensi sebenarnya dalam point, tanpa mengasumsikan ukuran kertas standar.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah dalam mode lanskap beralih kembali ke potret dan membiarkan halaman persegi tetap tidak berubah.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `size.getWidth() > size.getHeight()`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Khusus**

Tetapkan kedua dimensi sekaligus, kemudian gunakan [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis presentasi. Contoh ini menetapkan halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan memperbolehkan toleransi 0,01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Hasil yang diharapkan adalah `900.0 x 600.0 points` dan `Size preserved: true`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut sendiri: atur juga opsi ekspor. Ekspor slide reguler tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ke [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) dan [RenderingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notespositions/) menjaga catatan pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Point menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga bergantung pada skala rendering.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notespositions/) memungkinkan halaman tambahan sesuai kebutuhan. Jangan gunakan mode itu pada pemanggilan gambar slide tunggal di atas, karena tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak boleh dianggap sebagai jaminan bahwa semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/androidjava/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut menetapkan halaman 900 × 600 point dan menggunakan [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.getImages](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) dengan tata letak handout, bukan metode gambar slide individu. Di Aspose.Slides, perenderan handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individu tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/androidjava/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Jaga agar ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas cetak tetap terpisah:

- **Presentation viewers:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letak sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensinya lagi; konversi format aplikasi tersebut mungkin menormalkannya.
- **Export formats:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang dikonfigurasi. Gambar raster menggunakan dimensi piksel bulat dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Ekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Printer drivers:** Pemilihan kertas, rotasi otomatis, dan pengaturan cocok‑ke‑halaman dapat mengubah output fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan untuk hanya satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individu dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran berbeda?**

Pertama buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pemilihan kertas printer.