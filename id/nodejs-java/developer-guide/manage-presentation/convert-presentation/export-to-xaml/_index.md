---
title: Ekspor Presentasi ke XAML dalam JavaScript
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/nodejs-java/export-to-xaml/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- PowerPoint ke XAML
- OpenDocument ke XAML
- presentasi ke XAML
- PPT ke XAML
- PPTX ke XAML
- ODP ke XAML
- simpan PPT sebagai XAML
- simpan PPTX sebagai XAML
- simpan ODP sebagai XAML
- ekspor PPT ke XAML
- ekspor PPTX ke XAML
- ekspor ODP ke XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam JavaScript menggunakan Aspose.Slides—solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas tumpukan XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk menggambarkan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML Dengan Opsi Default**

Contoh JavaScript berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Secara default, slide yang diekspor disimpan di subfolder `input` dari direktori kerja saat ini dari proses. Folder ini dibuat secara otomatis, dan gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Pada Aspose.Slides untuk Node.js via Java 26.8, mengekspor `input.pptx` menghasilkan jalur bersarang seperti `input/input/Slide_1.xaml`. Pertahankan jalur lengkap yang dihasilkan saat menangani output. Output default bersifat relatif terhadap direktori kerja saat ini, bukan selalu berada di samping file input.

## **Ekspor Presentasi ke XAML Dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) untuk mengontrol cara Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, implementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) dan berikan sebuah instance dari implementasi Anda ke metode [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) pada [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan `true`, seperti yang ditunjukkan dalam contoh JavaScript berikut:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Tangkap Semua Artefak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor ditambah gambar terpisah dan sumber daya pendukung. Tetapkan [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) kustom ke [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) untuk menerima artefak ini alih-alih menggunakan penyimpan file-system default. Mulai ekspor dengan overload [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) khusus XAML yang menerima opsi XAML.

Di Node.js, implementasikan antarmuka Java dengan `java.newProxy` dari paket `java` yang digunakan oleh Aspose.Slides. Pertahankan proxy tetap dapat diakses sampai ekspor selesai.

### **Memahami Siklus Hidup Callback**

Eksporder memanggil [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) secara terpisah untuk setiap artefak yang dihasilkan:
- `path` mengidentifikasi artefak dan dapat mencakup direktori relatif. Simpan informasi ini karena XAML mungkin merujuk sumber daya menggunakan jalur relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lainnya tidak boleh di-decode sebagai teks.
- Penyimpan bertanggung jawab untuk menyimpan atau mempertahankan data sebelum mengembalikan. Contoh-contoh menyalin setiap array byte Java ke dalam buffer Node.js yang dimiliki aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi mengembalikan dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak terpantau. Jika penyimpanan terjadi kemudian, laporkan keberhasilan keseluruhan hanya setelah langkah tersebut juga berhasil.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) juga berlaku untuk penyimpan kustom. Pengaturan default, `false`, mengecualikan dokumen XAML slide tersembunyi. Mengirim `true` menyertakan mereka serta sumber daya yang diperlukan untuk ekspornya. Jumlah sumber daya bergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `input.pptx`, mengumpulkan setiap artefak dalam peta JavaScript dari nama ke buffer, dan mencetak nama, tipe, serta jumlah byte. Ini mempertahankan nama yang diberikan persis. Nama duplikat menandai koleksi sebagai tidak valid alih-alih menimpa artefak secara diam-diam. Contoh memeriksa hal ini sebelum menggunakan hasil.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Dekode hanya XAML, dan hanya ketika inspeksi teks diperlukan.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Pemeriksaan ekstensi berguna untuk inspeksi; pertahankan semua artefak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan decoding UTF-8 hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemas Artefak yang Dikumpulkan dalam Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP menggunakan bridge Java. ZIP dirakit di memori sebelum disimpan ke disk. Nama arsip yang unik memisahkan pekerjaan ekspor yang bersamaan. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama yang tidak aman atau nama yang bertabrakan setelah normalisasi menolak seluruh paket sebelum ditulis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Penutupan menyelesaikan direktori ZIP sebelum arsip disimpan.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Contoh ini menggunakan [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) untuk menulis satu arsip lokal; eksportir itu sendiri tidak menulis file XAML atau gambar terpisah. Untuk penyimpanan jarak jauh, ganti tahap penulisan arsip dengan unggahan byte array yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artefak relatif penuh sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika penyimpanan gagal.

Untuk presentasi besar, penyimpan kustom dapat menyimpan setiap artefak langsung ke penyimpanan aplikasi untuk menghindari menyimpan salinan tambahan seluruh ekspor di memori aplikasi. Pertahankan setiap callback sinkron dari perspektif eksportir: kembalikan hanya setelah tujuan menerima byte, dan izinkan kegagalan mencapai pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur ketika tujuan memerlukannya, namun pertahankan direktori relatif. Jangan hanya menggunakan nama dasar kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama khusus tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen traversi, selesaikan tujuan ke jalur absolut, dan pastikan tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan keberadaan. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengalihkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi tabrakan setelah normalisasi pemisah dan sesuai dengan aturan sensitivitas huruf tujuan.
- Sebelum mempublikasikan, parsing setiap dokumen XAML sebagai XML dan periksa referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusi setiap URI relatif terhadap direktori artefak XAML yang berisi, normalisasi nama penyimpanan yang dihasilkan, dan konfirmasi bahwa kunci peta, entri ZIP, atau objek yang disimpan yang bersangkutan ada. Perlakukan URI eksternal dan ekspresi markup XAML secara terpisah dari nama file relatif.

Misalnya, jika `input/Slide_1.xaml` merujuk `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `input/images/image1.png`. Menyimpan hanya `image1.png` akan memutuskan hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar terresolusi dengan benar.

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Panggil [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) di [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — font ini digunakan sebagai font cadangan selama ekspor ketika font asli tidak ada. Ini tidak menjamin bahwa XAML yang dihasilkan merujuk font cadangan atau bahwa font tersebut tersedia di mesin target. Pastikan font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan di tumpukan XAML lain juga?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan tumpukan XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana saya dapat mencegahnya agar tidak diekspor secara default?**

Secara default, slide tersembunyi tidak termasuk. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) di [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — biarkan tidak aktif jika Anda tidak perlu mengekspornya.