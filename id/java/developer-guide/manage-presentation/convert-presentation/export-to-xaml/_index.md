---
title: Export Presentasi ke XAML dalam Java
linktitle: Presentasi ke XAML
type: docs
weight: 30
url: /id/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Mengonversi slide PowerPoint dan OpenDocument ke XAML di Java menggunakan Aspose.Slides—solusi cepat tanpa Office yang menjaga tata letak Anda tetap utuh."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengekspor presentasi PowerPoint ke XAML menggunakan Aspose.Slides. Artikel ini mencakup pengantar singkat tentang XAML, menunjukkan cara menyimpan presentasi ke XAML dengan pengaturan default, dan mendemonstrasikan cara menyesuaikan ekspor melalui [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/), termasuk mengekspor slide tersembunyi. Artikel ini juga menjawab beberapa pertanyaan umum terkait font cadangan, kompatibilitas stack XAML, dan perilaku ekspor slide tersembunyi.

## **Tentang XAML**

XAML adalah bahasa markup berbasis XML yang digunakan untuk mendeskripsikan antarmuka pengguna dalam kerangka kerja seperti WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), dan Xamarin.Forms.

Anda dapat bekerja dengan file XAML di desainer visual atau menulis dan mengedit markup secara langsung.

## **Ekspor Presentasi ke XAML dengan Opsi Default**

Contoh Java berikut menunjukkan cara mengekspor presentasi ke XAML dengan pengaturan default:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Secara default, slide yang diekspor disimpan di subfolder `pres` dari direktori kerja saat ini proses, yang diresolusikan dari jalur kosong dengan [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). Folder tersebut dibuat secara otomatis, dan gambar yang diperlukan juga disimpan di sana.

Nama folder output diambil dari nama file sumber tanpa ekstensi. Untuk `pres.pptx`, file output dinamai `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, dan seterusnya. Bahkan jika Anda memberikan jalur absolut ke presentasi masukan, folder output dibuat relatif terhadap direktori kerja saat ini, bukan di samping file masukan.

## **Ekspor Presentasi ke XAML dengan Opsi Kustom**

Gunakan antarmuka [IXamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloptions/) untuk mengontrol cara Aspose.Slides mengekspor presentasi ke XAML.

Untuk menyimpan output ke lokasi kustom, implementasikan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) dan berikan instance implementasi Anda ke metode [setOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) dari [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/).

Untuk menyertakan slide tersembunyi dalam output XAML, panggil [setExportHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dengan `true`, seperti pada contoh Java berikut:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Tangkap Semua Artefak XAML yang Dihasilkan**

Ekspor XAML dapat menghasilkan sebuah dokumen XAML untuk setiap slide yang diekspor serta gambar terpisah dan sumber daya pendukung. Tetapkan [IXamlOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/) kustom ke [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) untuk menerima artefak-artefak ini alih‑alih menggunakan penyimpan default berbasis sistem berkas. Mulai ekspor dengan overload [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) yang khusus untuk XAML dan menerima opsi XAML.

### **Pahami Siklus Hidup Callback**

Ekspor memanggil [IXamlOutputSaver.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) secara terpisah untuk setiap artefak yang dihasilkan:

- `path` mengidentifikasi artefak dan dapat mencakup direktori relatif. Simpan informasi ini karena XAML mungkin merujuk sumber daya menggunakan jalur relatif.
- `data` berisi byte artefak. Gambar dan sumber daya biner lain tidak boleh didekode sebagai teks.
- Penyimpan bertanggung jawab menyimpan atau mempertahankan data sebelum mengembalikan. Contoh menyalin setiap array byte ke memori milik aplikasi.
- Anggap ekspor berhasil hanya ketika operasi penyimpanan presentasi selesai dan setiap callback telah selesai dengan sukses. Jangan menelan kesalahan penyimpanan atau memulai penulisan latar belakang yang tidak dipantau. Jika persistensi terjadi setelahnya, laporkan keberhasilan keseluruhan hanya setelah langkah itu juga berhasil.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) juga berlaku pada penyimpan kustom. Pengaturan default, `false`, mengecualikan dokumen XAML slide tersembunyi. Menetapkan `true` menyertakan mereka serta semua sumber daya yang diperlukan untuk ekspor mereka. Jumlah sumber daya tergantung pada presentasi; jangan mengasumsikan satu callback per slide atau urutan callback yang tetap.

### **Ekspor ke Memori dan Periksa Artefak**

Contoh lengkap ini memuat `pres.pptx`, mengumpulkan setiap artefak dalam sebuah [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), dan mencetak nama, tipe, serta jumlah byte-nya. Nama yang disediakan dipertahankan persis. Nama duplikat menandai koleksi tidak valid alih‑alih menimpa artefak secara diam‑diam. Contoh memeriksa hal ini sebelum menggunakan hasilnya.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Hanya dekode XAML, dan hanya ketika inspeksi teks diperlukan.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Pemeriksaan ekstensi berguna untuk inspeksi; pertahankan semua artefak, termasuk tipe sumber daya yang tidak dikenal. Biarkan byte tetap tidak berubah saat menyimpan atau mentransmisikannya. Gunakan konstruktor [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) dengan UTF-8 hanya untuk XAML yang memerlukan pemrosesan teks.

### **Kemas Artefak yang Dikumpulkan dalam Arsip ZIP**

Contoh independen ini mengumpulkan ekspor, memvalidasi namanya, dan menulis byte asli ke dalam arsip ZIP. Nama arsip yang unik memisahkan pekerjaan ekspor yang bersamaan. Entri ZIP menggunakan slash maju dan mempertahankan direktori relatif. Nama yang tidak aman atau yang berbenturan setelah normalisasi menolak seluruh paket sebelum ditulis.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Direktori ZIP telah diselesaikan dengan menutup sebelum melaporkan keberhasilan.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Contoh menggunakan [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) untuk menulis satu arsip lokal; eksportir sendiri tidak menulis file XAML atau gambar secara terpisah. Untuk penyimpanan jarak jauh, gantikan tahap penulisan arsip dengan unggahan array byte yang dikumpulkan. Gunakan pengidentifikasi pekerjaan ekspor ditambah nama artefak relatif lengkap sebagai kunci blob, atau simpan pengidentifikasi pekerjaan, nama relatif, dan data biner dalam baris basis data. Publikasikan pekerjaan hanya setelah semua unggahan selesai atau transaksi basis data dikomit. Bersihkan output parsial jika persistensi gagal.

Untuk presentasi besar, penyimpan kustom dapat menyimpan setiap artefak langsung ke penyimpanan aplikasi untuk menghindari menahan salinan tambahan seluruh ekspor di memori aplikasi. Pertahankan setiap callback sinkron dari perspektif eksportir: kembali hanya setelah tujuan menerima byte, dan izinkan kegagalan menjangkau pemanggil.

### **Pertahankan Nama Sumber Daya dan Verifikasi Referensi**

- Normalisasi pemisah jalur bila tujuan memerlukannya, tetapi pertahankan direktori relatif. Jangan hanya memakai [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) kecuali setiap nama yang dihasilkan diketahui unik dan referensi sumber daya tetap valid.
- Terapkan validasi nama spesifik tujuan. Saat menulis file terpisah, tolak jalur berakar dan segmen traversing, resolusikan tujuan dengan [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), dan pastikan tetap berada di bawah direktori ekspor yang dimaksud, termasuk pemisah direktori dalam pemeriksaan containment. Gunakan direktori yang dikontrol aplikasi tanpa tautan simbolik yang dapat mengalihkan penulisan.
- Gunakan penyimpan dan namespace penyimpanan terpisah untuk setiap pekerjaan ekspor. Deteksi benturan setelah normalisasi pemisah dan sesuai aturan sensitivitas huruf besar/kecil tujuan.
- Sebelum dipublikasikan, parse setiap dokumen XAML sebagai XML dan inspeksi referensi sumber daya berbasis file, seperti atribut `Source` atau `ImageSource` pada gambar. Resolusikan setiap URI relatif terhadap direktori artefak XAML yang memuatnya, normalisasi nama penyimpanan yang dihasilkan, dan konfirmasi bahwa kunci peta, entri ZIP, atau objek yang disimpan yang bersesuaian ada. Tangani URI eksternal dan ekspresi markup XAML secara terpisah dari nama file relatif.

Sebagai contoh, jika `pres/Slide_1.xaml` merujuk ke `images/image1.png`, sumber daya yang disimpan harus tersedia sebagai `pres/images/image1.png`. Menyimpan hanya `image1.png` akan memutus hubungan tersebut. Untuk penyimpanan objek, pertahankan tata letak yang sama di bawah prefiks pekerjaan dan buat URL sumber daya tersebut dapat diakses oleh konsumen XAML. Buka kembali ZIP yang selesai untuk memverifikasi nama entri dan byte sumber daya, serta muat slide representatif di lingkungan XAML target untuk memastikan gambar ter‑resolve dengan benar.

## **FAQ**

**Bagaimana saya dapat memastikan font yang dapat diprediksi jika font asli tidak tersedia di mesin?**

Panggil [setDefaultRegularFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) di [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/) — font ini digunakan sebagai font cadangan selama ekspor ketika yang asli tidak ada. Hal ini tidak menjamin bahwa XAML yang dihasilkan merujuk ke font cadangan atau bahwa font tersebut tersedia di mesin target. Pastikan bahwa font yang dirujuk oleh XAML tersedia di lingkungan tempat XAML ditampilkan.

**Apakah XAML yang diekspor hanya ditujukan untuk WPF, atau dapat digunakan di stack XAML lainnya juga?**

Aspose.Slides mengekspor XAML WPF melalui API publiknya. Kompatibilitas dengan stack XAML lain, seperti UWP dan Xamarin.Forms, tidak dijamin. Uji markup yang dihasilkan di lingkungan target Anda.

**Apakah slide tersembunyi didukung, dan bagaimana cara mencegah mereka diekspor secara default?**

Secara default, slide tersembunyi tidak disertakan. Anda dapat mengontrol perilaku ini melalui [setExportHiddenSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) di [XamlOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/xamloptions/) — biarkan opsi ini dinonaktifkan jika Anda tidak perlu mengekspornya.