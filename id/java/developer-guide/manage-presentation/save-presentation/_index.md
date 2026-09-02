---
title: Simpan Presentasi di Java
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/java/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang telah ditentukan
- Format Strict Office Open XML
- mode Zip64
- memperbarui thumbnail
- progres penyimpanan
- Java
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Java menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Buka Presentasi di Java](/slides/id/java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) berisi konten presentasi. Apakah Anda membuat presentasi dari awal atau memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides for Java, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Simpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```java
import com.aspose.slides.*;

// Instansiasi kelas Presentation yang mewakili sebuah file presentasi.
Presentation presentation = new Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke sebuah file.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberikan output stream ke metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Presentasi dapat ditulis ke berbagai tipe stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instansiasi kelas Presentation yang mewakili sebuah file presentasi.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Simpan presentasi ke stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dengan Tipe Tampilan yang Telah Ditentukan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/#setLastView-int-) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda menetapkan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), file output disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instansiasi kelas Presentation yang mewakili sebuah file presentasi.
Presentation presentation = new Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

File Office Open XML adalah arsip ZIP yang memberlakukan batas 4 GB (2^32 byte) pada ukuran tidak terkompresi setiap file, ukuran terkompresi setiap file, dan total ukuran arsip, serta membatasi arsip hingga 65.535 (2^16‑1) file. Ekstensi format ZIP64 meningkatkan batas ini menjadi 2^64.

Metode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batas di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Saat Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxexception/) dilemparkan jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Saat bekerja dengan presentasi besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu pemrosesan. Berdasarkan kebutuhan Anda, mungkin Anda lebih mengutamakan pemrosesan yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan metode [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan presentasi dalam format Office Open XML.

Tingkat kompresi berikut tersedia:

- [**None**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#None): Tidak ada kompresi yang diterapkan. File disimpan sebagaimana adanya.
- [**Level1**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level1): Kompresi tercepat dengan rasio kompresi terendah.
- [**Level2**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level2): Kompresi lebih cepat dengan rasio kompresi sedikit lebih baik dibanding **Level1**.
- [**Level3**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level3): Memberikan kompresi lebih baik dibanding **Level2** dengan dampak sedang pada waktu pemrosesan.
- [**Level4**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level4): Memberikan kompresi lebih baik dibanding **Level3**.
- [**Level5**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level5): Memperbaiki kompresi dibanding **Level4** dengan tambahan waktu pemrosesan.
- [**Level6**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level6): Kompresi standar yang menawarkan keseimbangan baik antara kecepatan pemrosesan dan ukuran file. Ini merupakan *tingkat kompresi default*.
- [**Level7**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level7): Memberikan kompresi lebih baik dibanding **Level6** dengan proses yang lebih lambat.
- [**Level8**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level8): Memberikan kompresi lebih baik dibanding **Level7**.
- [**Level9**](https://reference.aspose.com/slides/id/java/com.aspose.slides/compressionlevel/#Level9): Kompresi maksimum. Menghasilkan ukuran file terkecil dengan biaya waktu pemrosesan terpanjang.

Contoh berikut menunjukkan cara menyimpan presentasi sebagai file PPTX *tanpa kompresi*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Contoh ini menunjukkan cara menyimpan presentasi sebagai file PPTX dengan *kompresi maksimum*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi tanpa Memperbarui Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika disetel ke `true`, thumbnail diperbarui selama penyimpanan. Ini adalah nilai default.
- Jika disetel ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak akan dibuat thumbnail.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnailnya.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan presentasi dalam format PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) digunakan melalui metode `setProgressCallback` yang disediakan oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) dengan `setProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Gunakan nilai persentase progres di sini.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan aplikasi [PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda membagi presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan selalu membuat file target lengkap setiap kali; "fast save" inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) [tidak aman untuk thread](/slides/id/java/multithreading/); simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang terhubung secara eksternal saat menyimpan?**

[Hyperlinks](/slides/id/java/manage-hyperlinks/) dipertahankan. File yang terhubung secara eksternal (misalnya video melalui jalur relatif) tidak disalin secara otomatis—pastikan jalur yang direferensikan tetap dapat diakses.

**Dapatkah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. [Properti dokumen](/slides/id/java/presentation-properties/) standar didukung dan akan ditulis ke file saat disimpan.