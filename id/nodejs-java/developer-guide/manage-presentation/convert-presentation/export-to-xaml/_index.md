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
description: "Konversi slide PowerPoint dan OpenDocument ke XAML dalam JavaScript menggunakan Aspose.Slides—solusi cepat tanpa Office yang mempertahankan tata letak Anda tetap utuh."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan memperlihatkan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font fallback, kompatibilitas tumpukan XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk mendeskripsikan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh JavaScript berikut menunjukkan cara mengekspor sebuah presentasi ke XAML dengan pengaturan default:

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

Secara default, slide yang diekspor disimpan dalam subfolder `input` dari direktori kerja saat ini proses. Folder tersebut dibuat secara otomatis, dan semua gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Pada Aspose.Slides untuk Node.js via Java 26.8, mengekspor `input.pptx` menghasilkan jalur bersarang seperti `input/input/Slide_1.xaml`. Pertahankan jalur lengkap yang dihasilkan saat menangani output. Output default bersifat relatif terhadap direktori kerja saat ini, bukan selalu berdampingan dengan file input.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloptions/) untuk mengendalikan bagaimana Aspose.Slides mengekspor sebuah presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, implementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) dan kirimkan instance implementasi Anda ke metode [setOutputSaver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) dari [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) dengan `true`, seperti yang ditunjukkan dalam contoh JavaScript berikut:

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

Ekspor XAML dapat menghasilkan dokumen XAML untuk setiap slide yang diekspor plus gambar terpisah dan sumber daya pendukung. Tetapkan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) kustom ke [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) untuk menerima artefak ini alih‑alih menggunakan penyimpan sistem berkas default. Mulai ekspor dengan overload [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) khusus XAML yang menerima opsi XAML.

Di Node.js, implementasikan antarmuka Java dengan `java.newProxy` dari paket `java` yang digunakan oleh Aspose.Slides. Pertahankan proxy dapat dijangkau hingga ekspor selesai.

### **Pahami Siklus Hidup Callback**

- `path` mengidentifikasi artefak dan dapat mencakup direktori relatif. Simpan informasi ini karena XAML mungkin merujuk sumber daya menggunakan jalur relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lainnya tidak boleh diuraikan sebagai teks.
- Penyimpan bertanggung jawab untuk menyimpan atau mempersistenkan data sebelum mengembalikan. Contoh menyalin setiap array byte Java ke dalam buffer Node.js milik aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi mengembalikan dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak terpantau. Jika persistensi terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah itu juga berhasil.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) juga berlaku untuk penyimpan kustom. Pengaturan default, `false`, mengecualikan dokumen XAML slide tersembunyi. Menetapkan `true` menyertakan dokumen tersebut serta semua sumber daya yang diperlukan untuk ekspornya. Jumlah sumber daya bergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `input.pptx`, mengumpulkan setiap artefak dalam peta JavaScript dari nama ke buffer, dan mencetak nama, tipe, serta jumlah byte. Ia mempertahankan nama yang diberikan persis. Nama duplikat menandai kumpulan sebagai tidak valid alih‑alih menimpa artefak secara diam‑diam. Contoh memeriksa hal ini sebelum menggunakan hasil.

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

Pemeriksaan ekstensi berguna untuk inspeksi; pertahankan semua artefak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan dekoding UTF‑8 hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemas Artefak yang Dikumpulkan ke dalam Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP menggunakan jembatan Java. ZIP dirakit di memori sebelum disimpan ke disk. Nama arsip yang unik memisahkan pekerjaan ekspor yang bersamaan. Entri ZIP menggunakan garis miring maju dan mempertahankan direktori relatif. Nama yang tidak aman atau yang bentrok setelah normalisasi menolak seluruh paket sebelum ditulis.

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Menutup menyelesaikan direktori ZIP sebelum arsip disimpan.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Contoh ini menggunakan [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) untuk menulis satu arsip lokal; penyedia ekspor sendiri tidak menulis file XAML atau gambar yang terpisah. Untuk penyimpanan remote, ganti tahap penulisan arsip dengan unggahan array byte yang dikumpulkan. Gunakan pengenal pekerjaan ekspor ditambah nama artefak relatif penuh sebagai kunci blob, atau simpan pengenal pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial bila persistensi gagal.

Untuk presentasi besar, penyimpan kustom dapat mempersistensikan tiap artefak langsung ke penyimpanan aplikasi untuk menghindari menyalin seluruh ekspor ke memori aplikasi. Pertahankan setiap callback sinkron dari perspektif penyedia ekspor: kembali hanya setelah tujuan menerima byte, dan izinkan kegagalan sampai ke pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur ketika tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan hanya menggunakan nama dasar kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama khusus tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen traversing, selesaikan tujuan menjadi jalur absolut, dan verifikasi bahwa jalur tersebut tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan containment. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengarahkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi benturan setelah normalisasi pemisah dan sesuai aturan sensitivitas huruf besar/kecil tujuan.
- Sebelum mempublikasikan, parsing setiap dokumen XAML sebagai XML dan inspeksi referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusi setiap URI relatif terhadap direktori artefak XAML yang bersangkutan, normalisasi nama penyimpanan yang dihasilkan, dan pastikan kunci peta, entri ZIP, atau objek yang disimpan yang bersesuaian ada. Perlakukan URI eksternal dan ekspresi markup XAML terpisah dari nama file relatif.

Sebagai contoh, bila `input/Slide_1.xaml` merujuk ke `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `input/images/image1.png`. Menyimpan hanya `image1.png` akan memutuskan hubungan tersebut. Untuk penyimpanan objek, pertahankan susunan yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar ter‑resolve dengan benar.

## **FAQ**

**Bagaimana saya dapat memastikan font yang konsisten jika font asli tidak tersedia di mesin?**

Panggil [setDefaultRegularFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) pada [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/) — font ini digunakan sebagai font fallback selama ekspor ketika font asli tidak ada. Hal ini tidak menjamin bahwa XAML yang dihasilkan akan merujuk ke font fallback atau bahwa font tersebut tersedia di mesin target. Pastikan font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya dimaksudkan untuk WPF, atau dapat digunakan pada tumpukan XAML lain juga?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan tumpukan XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegahnya agar tidak diekspor secara default?**

Secara default, slide tersembunyi tidak termasuk. Anda dapat mengendalikan perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) pada [XamlOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/xamloptions/) — biarkan tetap dinonaktifkan jika Anda tidak perlu mengekspornya.