---
title: Konversi PPT dan PPTX ke PDF dalam JavaScript [Termasuk Fitur Lanjutan]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari menggunakan Aspose.Slides untuk Node.js, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Ikhtisar**

Mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, ODP, dll.) ke format PDF dalam JavaScript menawarkan beberapa keuntungan, termasuk kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen hasil.

## **Konversi PowerPoint ke PDF**

Dengan menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi sebuah presentasi ke PDF, kirimkan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode `save`. Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) menyediakan metode `save` yang biasanya digunakan untuk mengonversi sebuah presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides untuk Node.js via Java menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, ketika mengonversi sebuah presentasi ke PDF, Aspose.Slides mengisi field Application dengan "*Aspose.Slides*" dan field PDF Producer dengan nilai dalam bentuk "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat meminta Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat cocok dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Kepala dan kaki halaman
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint ke PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Kode ini menunjukkan cara mengonversi sebuah presentasi (PPT, PPTX, ODP, dll.) ke PDF:

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Simpan presentasi sebagai PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose menawarkan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) gratis secara daring yang menunjukkan proses konversi presentasi ke PDF. Anda dapat menjalankan tes dengan konverter ini untuk implementasi langsung dari prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti pada kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF hasil, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Konversi PowerPoint ke PDF dengan Opsi Khusus**

Dengan menggunakan opsi konversi khusus, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh kode di bawah ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi khusus.

```js
// Instansiasi kelas PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Setel kualitas untuk gambar JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Setel DPI untuk gambar.
pdfOptions.setSufficientResolution(300);

// Setel perilaku untuk metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Setel tingkat kompresi teks untuk konten tekstual.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definisikan mode kepatuhan PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Simpan presentasi sebagai dokumen PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan menyertakan slide tersembunyi:

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instansiasi kelas PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Tambah slide tersembunyi.
    pdfOptions.setShowHiddenSlides(true);

    // Simpan presentasi sebagai PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konversi PowerPoint ke PDF dengan Perlindungan Kata Sandi**

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions):

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instansiasi kelas PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Atur kata sandi PDF dan izin akses.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Simpan presentasi sebagai PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) pada kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions), memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Kode JavaScript ini menunjukkan cara mendeteksi substitusi font:

```js
// Atur callback peringatan pada opsi PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Simpan presentasi sebagai PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Font Substitution](/slides/id/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Konversi Slide Tertentu dalam PowerPoint ke PDF**

Kode JavaScript ini menunjukkan cara mengonversi hanya slide tertentu dari presentasi PowerPoint ke PDF:

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Setel array nomor slide.
    let slides = java.newArray("int", [1, 3]);

    // Simpan presentasi sebagai PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan ukuran slide yang ditentukan:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Buat presentasi baru dengan ukuran slide yang disesuaikan.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Setel ukuran slide khusus.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Klon slide pertama dari presentasi asli.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Simpan presentasi yang diubah ukurannya ke PDF dengan catatan.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```js
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Konfigurasikan opsi PDF dengan Tata Letak Catatan.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Simpan presentasi ke PDF dengan catatan.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode JavaScript ini menunjukkan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/nodejs-java/conversion/pdf-to-html/), [PDF ke JPG](https://products.aspose.com/slides/id/nodejs-java/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/nodejs-java/conversion/pdf-to-png/). Operasi konversi PDF lainnya ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/id/nodejs-java/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/nodejs-java/conversion/pdf-to-tiff/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafis kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**  
Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat melakukan iterasi pada file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan melindungi PDF yang dikonversi dengan kata sandi?**  
Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**  
Gunakan metode `setShowHiddenSlides` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**  
Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti `setJpegQuality` dan `setSufficientResolution` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PdfOptions) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**  
Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk Node.js via Java](/slides/id/nodejs-java/)
- [Referensi API Aspose.Slides untuk Node.js via Java](https://reference.aspose.com/slides/id/nodejs-java/)
- [Konverter Daring Gratis Aspose](https://products.aspose.app/slides/id/conversion)