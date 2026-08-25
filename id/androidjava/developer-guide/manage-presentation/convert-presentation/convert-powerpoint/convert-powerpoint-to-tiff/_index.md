---
title: Mengonversi Presentasi PowerPoint ke TIFF di Android
titlelink: PowerPoint ke TIFF
type: docs
weight: 90
url: /id/androidjava/convert-powerpoint-to-tiff/
keywords:
- konversi PowerPoint
- konversi OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "Pelajari cara mudah mengonversi presentasi PowerPoint (PPT, PPTX) menjadi gambar TIFF berkualitas tinggi menggunakan Aspose.Slides untuk Android, dengan contoh kode Java."
---
## **Introduction**

TIFF (**Tagged Image File Format**) adalah format gambar raster lossless yang banyak digunakan, dikenal karena kualitas luar biasa dan preservasi detail grafis. Desainer, fotografer, dan penerbit desktop sering memilih TIFF untuk mempertahankan lapisan, akurasi warna, dan pengaturan asli pada gambar mereka.

Dengan Aspose.Slides, Anda dapat dengan mudah mengonversi slide PowerPoint (PPT, PPTX) dan slide OpenDocument (ODP) langsung menjadi gambar TIFF berkualitas tinggi, memastikan presentasi Anda mempertahankan fidelitas visual maksimum. 

## **Convert a Presentation to TIFF**

Menggunakan metode [save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), Anda dapat dengan cepat mengonversi seluruh presentasi PowerPoint ke TIFF. Gambar TIFF yang dihasilkan sesuai dengan ukuran slide default.

Kode berikut menunjukkan cara mengonversi presentasi PowerPoint ke TIFF:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang merepresentasikan file presentasi (PPT, PPTX, ODP, dll).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Simpan presentasi sebagai TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convert a Presentation to Black-and-White TIFF**

Metode [setBwConversionMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) pada kelas [TiffOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/) memungkinkan Anda menentukan algoritma yang digunakan saat mengonversi slide atau gambar berwarna menjadi TIFF hitam-putih. Perhatikan bahwa pengaturan ini hanya berlaku ketika metode [setCompressionType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) disetel ke `CCITT4` atau `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) adalah pengaturan tingkat ekspor yang memilih algoritma konversi piksel untuk seluruh gambar TIFF. Untuk menentukan bagaimana bentuk individu harus ditampilkan ketika mode tampilan hitam-putih aktif, gunakan [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Lihat [Control Black-and-White Rendering for Shapes](/slides/id/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) untuk contoh.
{{% /alert %}}

Misalkan kita memiliki file "sample.pptx" dengan slide berikut:

![A presentation slide](slide_black_and_white.png)

Kode berikut menunjukkan cara mengonversi slide berwarna menjadi TIFF hitam-putih:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

Jika Anda memerlukan gambar TIFF dengan dimensi tertentu, Anda dapat mengatur nilai yang diinginkan menggunakan metode yang tersedia di [TiffOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/). Misalnya, metode [setImageSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) memungkinkan Anda menentukan ukuran gambar yang dihasilkan.

Kode berikut menunjukkan cara mengonversi presentasi PowerPoint ke gambar TIFF dengan ukuran khusus:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Membuat instance kelas Presentation yang merepresentasikan file presentasi (PPT, PPTX, ODP, dll).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Atur jenis kompresi.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Jenis kompresi:
        Default - Menentukan skema kompresi default (LZW).
        None - Menentukan tidak ada kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Kedalaman tergantung pada jenis kompresi dan tidak dapat diatur secara manual.

    // Atur DPI gambar.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Atur ukuran gambar.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Simpan presentasi sebagai TIFF dengan ukuran yang ditentukan.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

Dengan menggunakan metode [setPixelFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) dari kelas [TiffOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/tiffoptions/), Anda dapat menentukan format piksel yang diinginkan untuk gambar TIFF yang dihasilkan.

Kode berikut menunjukkan cara mengonversi presentasi PowerPoint ke gambar TIFF dengan format piksel khusus:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang merepresentasikan file presentasi (PPT, PPTX, ODP, dll).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat berisi nilai-nilai berikut (seperti yang tercantum dalam dokumentasi):
        Format1bppIndexed - 1 bit per piksel, terindeks.
        Format4bppIndexed - 4 bit per piksel, terindeks.
        Format8bppIndexed - 8 bit per piksel, terindeks.
        Format24bppRgb    - 24 bit per piksel, RGB.
        Format32bppArgb   - 32 bit per piksel, ARGB.
    */
    
    // Simpan presentasi sebagai TIFF dengan format piksel yang ditentukan.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Lihat [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online) dari Aspose.
{{% /alert %}}

## **FAQ**

**Can I convert an individual slide instead of entire PowerPoint presentation to TIFF?**

Ya. Aspose.Slides memungkinkan Anda mengonversi slide individual dari presentasi PowerPoint dan OpenDocument menjadi gambar TIFF secara terpisah.

**Is there any limit to the number of slides when converting a presentation to TIFF?**

Tidak, Aspose.Slides tidak memberlakukan batasan pada jumlah slide. Anda dapat mengonversi presentasi berukuran apa pun ke format TIFF.

**Are PowerPoint animations and transition effects preserved when converting slides to TIFF?**

Tidak, TIFF adalah format gambar statis. Oleh karena itu, animasi dan efek transisi tidak dipertahankan; hanya snapshot statis dari slide yang diekspor.