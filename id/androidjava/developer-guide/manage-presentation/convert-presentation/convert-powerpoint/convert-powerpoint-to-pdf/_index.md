---
title: Konversi PPT dan PPTX ke PDF di Android [Fitur Lanjutan Termasuk]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/androidjava/convert-powerpoint-to-pdf/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- konversi PPT ke PDF
- PPTX ke PDF
- konversi PPTX ke PDF
- simpan PowerPoint sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari di Java menggunakan Aspose.Slides untuk Android, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) menjadi format PDF di Android menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) menyediakan metode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Android via Java menyisipkan informasi API dan nomor versi ke dalam dokumen keluaran. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat memerintahkan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen keluaran.
{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint ke PDF menggunakan opsi default. Dalam kasus ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF menggunakan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat sebuah presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose menawarkan [**Konverter PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratis secara online yang menunjukkan proses konversi presentasi ke PDF. Anda dapat menjalankan tes dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti pada kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus berjalan.

### **Konversi PowerPoint ke PDF dengan Opsi Khusus**

Dengan opsi konversi khusus, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, menetapkan tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan banyak lagi.

Contoh berikut mengekspor presentasi ke PDF 1.5 dengan kualitas JPEG 90, resolusi gambar 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Memilih Kompresi Gambar Secara Otomatis**

Ketika sebuah presentasi berisi banyak foto atau tangkapan layar, mengurangi ukuran PDF yang diekspor dapat mempermudah pengiriman email atau pengunduhan. Panggil [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) dengan `true` untuk secara otomatis memilih algoritma kompresi yang paling sesuai untuk setiap gambar selama ekspor PDF.

Contoh berikut memuat presentasi yang ada, mengaktifkan pemilihan kompresi gambar otomatis, dan menyimpannya sebagai dokumen PDF. Semua pengaturan ekspor PDF lainnya tetap menggunakan nilai default.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Opsi ini memilih algoritma kompresi untuk setiap gambar. Menurunkan nilai yang diberikan ke [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) justru mengurangi kualitas gambar JPEG, sementara menurunkan nilai yang diberikan ke [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) memungkinkan gambar di‑downsample ke resolusi lebih rendah, yang dapat mengurangi detail. Mengaktifkan pemilihan kompresi otomatis tidak secara otomatis menurunkan salah satu pengaturan ini.

Memilih algoritma kompresi gambar memerlukan tambahan waktu pemrosesan dan memori. Pengurangan ukuran bergantung pada gambar dalam presentasi dan pengaturan ekspor; pengurangan tetap tidak dijamin untuk setiap presentasi.

### **Mempertahankan File OLE yang Disematkan sebagai Lampiran PDF**

Jika sebuah presentasi berisi buku kerja Excel yang disematkan, Anda mungkin ingin penerima PDF dapat mengakses data buku kerja tersebut sekaligus melihat slide. Panggil [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) dengan `true` untuk mempertahankan file OLE yang disematkan sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `false`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file yang disematkan tidak disertakan sebagai lampiran. Menetapkan opsi ke `true` juga menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file yang disematkan secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi buku kerja Excel yang disematkan dan mengekspornya ke PDF dengan buku kerja terlampir.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor dalam penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Lampiran** penampil dan temukan buku kerja yang disematkan.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil memperbolehkan. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file yang disematkan, PDF/A-2 hanya memperbolehkan lampiran PDF/A, dan PDF/A-3 memperbolehkan tipe file lain, termasuk buku kerja Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak memperlihatkan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) dari kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Mendeteksi Substitusi Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) pada kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan hanya dicetak ketika font yang tidak tersedia disubstitusi selama ekspor.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Substitusi Font](/slides/id/androidjava/font-substitution/).
{{% /alert %}} 

### **Menangani Font Tanpa Gaya Tebal Khusus**

Sebuah presentasi dapat menerapkan format tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks masih dapat muncul tebal melalui bold sintetis, yang secara artifisial menebalkan glif reguler. Ketika teks tersebut tampak terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba panggil [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) dengan `true`. Opsi ini merender teks yang terkena sebagai bitmap selama ekspor PDF dan dapat meningkatkan penampilannya untuk beberapa font. Nilai defaultnya adalah `false`.

Presentasi contoh berisi dua kotak teks: satu dengan teks biasa dan satu dengan format tebal yang diterapkan pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Pratinjau berikut menunjukkan output dengan opsi dinonaktifkan dan output dengan opsi diaktifkan. Pada contoh ini, teks tebal memiliki goresan lebih tebal ketika opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`false`, default) | Opsi diaktifkan (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dalam contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: teks tersebut tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya tampak lebih lembut pada pembesaran 800 %. Teks biasa tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap berupa teks.

Opsi ini merasterisasi teks yang diformat tebal ketika fontnya tidak memiliki gaya tebal khusus. [Substitusi Font](/slides/id/androidjava/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini dimulai dari satu, dan presentasi input harus berisi setidaknya tiga slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskalakan konten slide agar sesuai dan mengekspor slide tunggal ke PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Hapus slide kosong yang dibuat secara otomatis pada presentasi baru.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Contoh berikut mengekspor sebuah presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide tersebut. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini menunjukkan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Operasi konversi PDF lainnya ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—juga didukung.
{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar tunggal. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk keseluruhan gambar.

## **FAQ**

**Dapatkah saya mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengulangi file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan untuk melindungi PDF yang dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Panggil [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) dengan `true` dalam kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) dan [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) dalam kelas [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi [berbagai standar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), termasuk PDF/A1a, PDF/A1b, dan PDF/UA, sehingga dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Android via Java](/slides/id/androidjava/)
- [Referensi API Aspose.Slides untuk Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/conversion)