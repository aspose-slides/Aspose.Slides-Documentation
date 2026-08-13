---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan Catatan di Android
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk Android via Java. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for Android via Java menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi lengkap dengan catatan pembicara, tetapi juga menghasilkan thumbnail slide dalam tampilan Catatan Slide. Proses konversi sederhana dan efisien, memanfaatkan metode `save` dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sekaligus mempertahankan catatan dan tata letaknya.

## **Mengonversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for Android via Java melibatkan langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
2. Atur opsi tata letak keluaran: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/notescommentslayoutingoptions/) untuk menentukan bagaimana catatan dan komentar ditampilkan.  
3. Simpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasi ke metode [save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![Slide presentasi dengan catatan pembicara](slide_with_notes.png)

Potongan kode di bawah ini menunjukkan cara mengonversi presentasi ke gambar TIFF dalam tampilan Catatan Slide menggunakan metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Tampilkan catatan di bawah slide.

    // Mengonfigurasi opsi TIFF dengan tata letak Catatan.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Simpan presentasi ke TIFF dengan catatan pembicara.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Gambar TIFF dengan catatan pembicara](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Dapatkah saya mengontrol posisi area catatan dalam TIFF yang dihasilkan?

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk memilih opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau membiarkannya melanjutkan ke halaman tambahan.

### Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa mengurangi kualitas yang terlihat?

Pilih [efficient compression](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila dapat diterima, gunakan [pixel format](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) juga dapat membantu tanpa mengganggu keterbacaan secara signifikan.

### Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?

Ya. Font yang hilang memicu [substitution](/slides/id/androidjava/font-selection-sequence/), yang dapat mengubah metrik teks dan tampilannya. Untuk menghindarinya, [supply the required fonts](/slides/id/androidjava/custom-font/) atau tetapkan [fallback font](/slides/id/androidjava/fallback-font/) default sehingga tipe huruf yang dimaksud tetap digunakan.