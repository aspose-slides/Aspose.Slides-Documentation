---
title: Simpan Presentasi di Android
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/androidjava/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke aliran
- tipe tampilan yang ditentukan
- Format Office Open XML yang Ketat
- mode Zip64
- menyegarkan gambar mini
- progres penyimpanan
- Android
- Java
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau aliran di Android dengan Aspose.Slides, serta atur output PPTX dan pelaporan progres."
---
## **Gambaran Umum**

Setelah Anda membuat presentasi atau [membuka presentasi yang ada](/slides/id/androidjava/open-presentation/), gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis hasilnya. Aspose.Slides untuk Android via Java dapat menyimpan presentasi ke file atau aliran dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Tambahkan atau ubah konten presentasi di sini.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Aslinya**

Untuk contoh deteksi file dan aliran, perilaku presentasi yang baru dibuat, dan perbedaan antara format sumber dan output, lihat [Determine the Original Presentation Format](/slides/id/androidjava/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format masukan mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dari metode [IPresentation.getSourceFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Serahkan nilai [SourceFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/) yang sesuai, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis presentasi yang dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori masukan, memperbarui judulnya, dan menyimpannya ke direktori keluaran dalam format yang sama dengan saat dimuat:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang bersesuaian. Ia hanya memetakan format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Menyerahkan nilai [SourceFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/sourceformat/) yang tidak didukung atau tidak valid menghasilkan [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

File PPT, PPS, dan POT lama menggunakan wadah biner yang sama. Ketika presentasi semacam itu dimuat dari aliran tanpa ekstensi file, file PPS atau POT dapat teridentifikasi sebagai PPT. Jika diperlukan mempertahankan subtipe lama ini, simpan nama file asli atau metadata format secara terpisah dan gunakan saat memilih nama file dan format keluaran.

## **Simpan Presentasi ke Aliran**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan aliran yang dapat ditulis dan nilai [SaveFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan dalam basis data, atau diproses dalam memori.

Contoh berikut menyimpan presentasi baru ke aliran file:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dengan Tipe Tampilan yang Ditentukan**

Anda dapat menentukan tampilan di mana PowerPoint secara awal membuka presentasi yang disimpan. Gunakan metode [ViewProperties.setLastView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) dengan nilai [ViewType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengonfigurasi tampilan Slide Master sebagai tampilan awal:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML yang Ketat**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/) dan gunakan metode [setConformance](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) dengan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Kemudian serahkan opsi tersebut ke metode [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi setiap entri, ukuran total arsip, dan jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#IfNecessary) menggunakan ZIP64 hanya ketika presentasi melampaui batas ZIP standar. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never) menonaktifkan ekstensi ZIP64.
- [Always](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Always) selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi keluaran:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Jika [Zip64Mode.Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never) digunakan dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan menggunakan metode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Kelas [CompressionLevel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/) menyediakan nilai-nilai berikut:

- [None](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#None) menyimpan data tanpa kompresi.
- [Level1](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level1) memberikan kompresi tercepat dan output terkompresi terbesar.
- [Level2](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level2) hingga [Level5](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level5) secara bertahap lebih mengutamakan output yang lebih kecil daripada kecepatan penyimpanan.
- [Level6](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level6) menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah level default.
- [Level7](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level7) dan [Level8](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level8) lebih mengutamakan output yang lebih kecil daripada kecepatan penyimpanan.
- [Level9](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level9) memberikan kompresi terkuat dan membutuhkan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi tanpa Menyegarkan Gambar Mini**

Ketika presentasi disimpan sebagai PPTX, metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) mengontrol gambar mini dokumen:

- `true` menghasilkan kembali gambar mini selama operasi penyimpanan. Ini adalah nilai default.
- `false` mempertahankan gambar mini yang ada. Jika presentasi tidak memiliki gambar mini, Aspose.Slides tidak akan membuatnya.

Contoh berikut menyimpan presentasi tanpa menyegarkan gambar mini-nya:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran gambar mini dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Pembaruan Progres Penyimpanan dalam Persentase**

Untuk memantau operasi penyimpanan, implementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprogresscallback/) dan serahkan implementasinya ke metode [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides kemudian memanggil metode [IProgressCallback.reporting](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide terpilih dari sebuah presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan inkremental atau “fast save”?**

Tidak. Setiap operasi penyimpanan menulis file output lengkap bukan hanya memperbarui bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

Tidak. Instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) [tidak thread‑safe](/slides/id/androidjava/multithreading/). Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang terhubung secara eksternal ketika saya menyimpan sebuah presentasi?**

[Hyperlinks](/slides/id/androidjava/manage-hyperlinks/) tetap berada dalam presentasi. Aspose.Slides tidak menyalin file yang terhubung secara eksternal, sehingga presentasi yang disimpan masih harus dapat mengakses lokasi mereka.

**Dapatkah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

Ya. Atur [document properties](/slides/id/androidjava/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menuliskannya ke file output.