---
title: Konversi Presentasi PowerPoint ke Markdown di Android
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/androidjava/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- Android
- Java
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown di Android lewat Java serta mengontrol lokasi penyimpanan dan referensi gambar bitmap, metafile, dan SVG yang diekspor."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java dapat mengonversi presentasi PPT dan PPTX menjadi Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol cara konten slide dirender, dan memutuskan di mana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan merujuknya.

Secara default, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, atur jenis ekspor dengan metode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) ke nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` mempertahankan item yang dikelompokkan bersama agar hubungan visualnya terjaga. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga callback penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Konversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), kemudian panggil metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Pilih Varian Markdown**

Metode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Ekspor Gambar dengan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) menyediakan dua metode untuk mengkonfigurasi gambar yang disimpan secara lokal:

- [setBasePath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Perilaku ini juga berfungsi sebagai cadangan ketika handler penyimpanan gambar khusus mengembalikan `false`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan metode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) untuk mendaftarkan callback bagi sumber daya bitmap dan metafile non‑SVG yang dihasilkan selama ekspor Markdown. Callback `MarkdownImageSavingHandler` menerima objek [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) , nilai [ImageFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/) , dan tautan Markdown yang dihasilkan sebagai parameter `String[]` berukuran satu. Simpan atau unggah gambar dengan format yang diberikan, dan gantikan `link[0]` dengan referensi yang harus muncul dalam output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Daftarkan callback dengan metode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` menerima objek [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/) dan parameter `String[] link` berukuran satu. SVG tidak memiliki argumen `ImageFormat`; tulis atau unggah data XML‑nya melalui metode [ISvgImage.getSvgData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/) . Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat dirasterisasi atau digabungkan dengan konten lain; sumber daya non‑SVG yang dihasilkan kemudian diserahkan ke callback penyimpanan gambar. Daftarkan kedua callback ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Nilai kembali handler menentukan siapa yang memproses gambar:

- Kembalikan `true` setelah handler menyimpan, mengunggah, mengubah, atau memproses gambar dengan cara lain dan menetapkan nilai sah ke `link[0]`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal default.
- Kembalikan `false` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya sesuai nilai yang ditetapkan oleh [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Penting" %}}
Handler yang mengembalikan `true` bertanggung jawab atas gambar. Jika mengembalikan `true` tanpa menetapkan tautan yang sah dan tidak kosong, ekspor akan gagal dengan `InvalidOperationException`.
{{% /alert %}}

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut memperlakukan `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap handler mengekstrak nama file yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan menggantikan referensi lokal yang dihasilkan dengan URL CDN publik. Contoh itu sendiri tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau file‑filenya dipublikasikan ke CDN. Untuk penyimpanan objek, ganti penulisan sistem file dengan operasi unggah SDK penyimpanan dan tetapkan `link[0]` hanya setelah unggahan berhasil.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Handler bitmap sengaja mengembalikan `false` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` menggunakan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Misalnya, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handler menggunakan jalur sistem operasi hanya saat menulis file; tautan yang ditulis ke Markdown menggunakan garis miring maju dan nama file yang di‑escape URL. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori spesifik platform.

## **FAQ**

**Apakah satu handler dapat memproses gambar raster dan gambar SVG?**

Tidak. Gunakan [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) untuk sumber daya bitmap dan metafile yang dihasilkan dan [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama menyediakan objek [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) dan nilai [ImageFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/) ; yang kedua menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/) yang data SVG‑nya dapat dibaca dengan [ISvgImage.getSvgData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isvgimage/). SVG sumber yang dirasterisasi selama ekspor diproses oleh callback penyimpanan gambar sebagai gantinya.

**Apa yang terjadi ketika handler penyimpanan gambar mengembalikan `false`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal defaultnya. Lokasi gambar dan referensi yang dihasilkan dikontrol oleh nilai yang ditetapkan dengan [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markdownsaveoptions/).

**Dapatkah sebuah handler menyediakan URL tanpa menyimpan gambar secara lokal?**

Ya. Handler dapat mengunggah gambar ke penyimpanan objek atau mengirimnya ke layanan lain, menetapkan URL yang dihasilkan ke `link[0]`, dan mengembalikan `true`. Handler harus menyelesaikan pemrosesan sendiri; mengembalikan `true` mencegah penyimpanan lokal default.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari sebuah handler?**

Pengecualian ini terjadi ketika handler mengembalikan `true` tetapi tidak menyediakan tautan yang valid. Tetapkan jalur relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `true`.

**Pemisa jalur mana yang harus digunakan oleh tautan gambar?**

Gunakan garis miring maju dalam tautan Markdown dan URL. Gunakan `Path.resolve` hanya untuk jalur sistem file, lalu buat atau normalisasi referensi Markdown secara terpisah.

**Apakah tautan hiper tetap dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/androidjava/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [transitions](/slides/id/androidjava/slide-transition/) slide dan [animations](/slides/id/androidjava/powerpoint-animation/) tidak dikonversi.

**Dapatkah presentasi dikonversi ke Markdown secara paralel?**

Anda dapat memproses berkas presentasi yang berbeda secara paralel, tetapi jangan berbagi instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang sama antar thread. Ikuti panduan [multithreading guidelines](/slides/id/androidjava/multithreading/) dan gunakan instance terpisah untuk setiap berkas.