---
title: Konversi PPT dan PPTX ke PDF dalam JavaScript [Fitur Lanjutan Termasuk]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari menggunakan Aspose.Slides untuk Node.js, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, ODP, dll.) ke format PDF dalam JavaScript menawarkan beberapa keuntungan, termasuk kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengendalikan kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) kemudian simpan presentasi sebagai PDF menggunakan metode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) menyediakan metode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Node.js via Java menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam bentuk "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.
{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Hyperlink
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint ke PDF menggunakan opsi default. Dalam kasus ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat sebuah presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose menawarkan [**PowerPoint ke PDF konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratis daring yang menunjukkan proses konversi presentasi ke PDF. Anda dapat menjalankan tes dengan konverter ini untuk implementasi langsung dari prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di dalam kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus berlangsung.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Menggunakan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas pilihan untuk gambar raster, menentukan bagaimana metafile harus diproses, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh berikut mengekspor sebuah presentasi ke PDF 1.5 dengan kualitas JPEG diatur ke 90, resolusi gambar diatur ke 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Pilih Kompresi Gambar Secara Otomatis**

Ketika sebuah presentasi berisi banyak foto atau tangkapan layar, mengurangi ukuran PDF yang diekspor dapat mempermudah mengirim email atau mengunduhnya. Panggil [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) dengan `true` untuk secara otomatis memilih algoritma kompresi paling tepat untuk setiap gambar selama ekspor PDF.

Contoh berikut memuat presentasi yang ada, mengaktifkan pemilihan kompresi gambar otomatis, dan menyimpannya sebagai dokumen PDF. Semua pengaturan ekspor PDF lainnya mempertahankan nilai defaultnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Opsi ini memilih algoritma kompresi untuk setiap gambar. Menurunkan nilai yang diberikan ke [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) justru mengurangi kualitas gambar JPEG, sementara menurunkan nilai yang diberikan ke [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) memungkinkan gambar diturunkan ke resolusi yang lebih rendah, yang dapat mengurangi detail. Mengaktifkan pemilihan kompresi otomatis tidak secara otomatis menurunkan salah satu dari pengaturan ini.

Memilih algoritma kompresi gambar memerlukan waktu pemrosesan dan memori tambahan. Pengurangan ukuran bergantung pada gambar dalam presentasi dan pengaturan ekspor; pengurangan tetap tidak dijamin untuk setiap presentasi.

### **Pertahankan File OLE Tersemat sebagai Lampiran PDF**

Jika sebuah presentasi berisi buku kerja Excel yang tersemat, Anda mungkin ingin penerima PDF mengakses data buku kerja tersebut serta melihat slide. Panggil [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) dengan `true` untuk mempertahankan file OLE tersemat sebagai lampiran dalam PDF yang dihasilkan.

Nilai defaultnya adalah `false`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file tersematnya tidak disertakan sebagai lampiran. Mengatur opsi ke `true` juga menyertakan data file. Pratinjau tetap merupakan representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tersemat secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi buku kerja Excel tersemat dan mengekspornya ke PDF dengan buku kerja terlampir.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Untuk memeriksa hasil:

1. Buka PDF yang diekspor menggunakan penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** pada penampil dan temukan buku kerja tersemat.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tersemat, PDF/A-2 hanya mengizinkan lampiran PDF/A, dan PDF/A-3 mengizinkan jenis file lain, termasuk buku kerja Excel. Ini adalah persyaratan standar, bukan pembatasan khusus pada Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak mendemonstrasikan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konversi PowerPoint ke PDF dengan Perlindungan Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika font yang tidak tersedia diganti selama ekspor.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Substitusi Font](/slides/id/nodejs-java/font-substitution/).
{{% /alert %}} 

### **Menangani Font Tanpa Tipe Huruf Tebal Khusus**

Presentasi dapat menerapkan pemformatan tebal pada teks meskipun fontnya tidak memiliki tipe huruf tebal khusus. Teks tersebut masih dapat terlihat tebal melalui bold sintetis, yang secara artifisial menebalkan glif reguler. Ketika teks tersebut terlihat terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba panggil [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) dengan `true`. Opsi ini merender teks yang terpengaruh sebagai bitmap selama ekspor PDF dan dapat memperbaiki penampilannya untuk font tertentu. Nilai defaultnya adalah `false`.

Presentasi contoh berisi dua kotak teks: satu dengan teks biasa dan satu dengan format tebal yang diterapkan pada font yang sama, yang tidak memiliki tipe huruf tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Pratinjau berikut menunjukkan output dengan opsi dimatikan dan dihidupkan. Dalam contoh ini, teks tebal memiliki goresan lebih berat ketika opsi dimatikan. Dengan opsi dihidupkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dimatikan (`false`, default) | Opsi dihidupkan (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dalam contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: teks tersebut tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya tampak lebih lembut pada zoom 800%. Teks biasa tetap dapat dicari. Dengan opsi dimatikan, kedua string tetap berupa teks.

Opsi ini merasterisasi teks yang diformat tebal ketika fontnya tidak memiliki tipe huruf tebal khusus. [Substitusi Font](/slides/id/nodejs-java/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini berbasis satu, dan presentasi input harus berisi setidaknya tiga slide.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskalakan konten slide agar sesuai dan mengekspor slide tunggal ke PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Hapus slide kosong yang dibuat saat presentasi baru dibuat.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Contoh berikut mengekspor presentasi ke PDF, menempatkan catatan pembicara masing-masing slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan ini: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini mendemonstrasikan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF ke JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—juga didukung.
{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafis kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Bisakah saya mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file-file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan untuk melindungi PDF yang dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Panggil [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) dengan `true` di kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengendalikan kualitas gambar dengan menggunakan metode seperti [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) dan [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) di kelas [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi [berbagai standar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Node.js via Java](/slides/id/nodejs-java/)
- [Referensi API Aspose.Slides untuk Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Konverter Daring Gratis Aspose](https://products.aspose.app/slides/conversion)