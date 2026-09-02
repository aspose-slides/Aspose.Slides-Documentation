---
title: Menyimpan Presentasi di Android
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/androidjava/save-presentation/
keywords:
- menyimpan PowerPoint
- menyimpan OpenDocument
- menyimpan presentasi
- menyimpan slide
- menyimpan PPT
- menyimpan PPTX
- menyimpan ODP
- presentasi ke file
- presentasi ke stream
- tipe tampilan yang ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- kemajuan penyimpanan
- Android
- Java
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Java menggunakan Aspose.Slides untuk Android—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Ikhtisar**

[Buka Presentasi di Android](/slides/id/androidjava/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) berisi konten sebuah presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda akan ingin menyimpannya setelah selesai. Dengan Aspose.Slides untuk Android, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Simpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan sebuah presentasi dengan Aspose.Slides.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang merepresentasikan file presentasi.
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

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke berbagai jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke stream file.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Membuat instance kelas Presentation yang merepresentasikan file presentasi.
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

## **Simpan Presentasi dengan Jenis Tampilan yang Ditetapkan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewtype/).

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

Aspose.Slides memungkinkan Anda menyimpan sebuah presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/) dan atur properti conformance‑nya saat menyimpan. Jika Anda menetapkan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Membuat instance kelas Presentation yang merepresentasikan file presentasi.
Presentation presentation = new Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

File Office Open XML adalah arsip ZIP yang memberlakukan batas 4 GB (2^32 byte) pada ukuran tidak terkompresi dari setiap file, ukuran terkompresi, dan total ukuran arsip, serta membatasi arsip hingga 65 535 (2^16‑1) file. Ekstensi format ZIP64 meningkatkan batas ini menjadi 2^64.

Metode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batas di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

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
Ketika Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxexception/) akan dilemparkan jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Ketika bekerja dengan presentasi besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu pemrosesan. Bergantung pada kebutuhan Anda, Anda mungkin lebih memilih pemrosesan yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan metode [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan sebuah presentasi dalam format Office Open XML.

Tingkat kompresi berikut tersedia:

- [**None**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#None): Tidak ada kompresi yang diterapkan. File disimpan apa adanya.
- [**Level1**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level1): Kompresi tercepat dengan rasio kompresi terendah.
- [**Level2**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level2): Kompresi lebih cepat dengan rasio kompresi sedikit lebih baik dibanding **Level1**.
- [**Level3**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level3): Menyediakan kompresi lebih baik daripada **Level2** dengan dampak sedang pada waktu pemrosesan.
- [**Level4**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level4): Menyediakan kompresi lebih baik daripada **Level3**.
- [**Level5**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level5): Menyediakan kompresi yang lebih baik daripada **Level4** dengan waktu pemrosesan tambahan.
- [**Level6**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level6): Kompresi standar yang menawarkan keseimbangan yang baik antara kecepatan pemrosesan dan ukuran file. Ini adalah *tingkat kompresi default*.
- [**Level7**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level7): Menyediakan kompresi lebih baik daripada **Level6** dengan pemrosesan lebih lambat.
- [**Level8**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level8): Menyediakan kompresi lebih baik daripada **Level7**.
- [**Level9**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compressionlevel/#Level9): Kompresi maksimum. Menghasilkan ukuran file terkecil dengan biaya waktu pemrosesan terpanjang.

Contoh berikut menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX *tanpa kompresi*:

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

Contoh ini menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan *kompresi maksimum*:

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

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) mengontrol pembuatan thumbnail saat menyimpan sebuah presentasi ke PPTX:

- Jika disetel ke `true`, thumbnail akan disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika disetel ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dihasilkan.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnail‑nya.

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

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprogresscallback/) digunakan melalui metode `setProgressCallback` yang disediakan oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprogresscallback/) dengan `setProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Gunakan nilai persentase kemajuan di sini.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan sebuah [aplikasi PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API‑nya sendiri. Aplikasi ini memungkinkan Anda memisahkan sebuah presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap kali menyimpan, file target lengkap dibuat; "fast save" inkremental tidak didukung.

**Apakah aman untuk thread menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) [tidak aman untuk thread](/slides/id/androidjava/multithreading/); simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlinks](/slides/id/androidjava/manage-hyperlinks/) tetap dipertahankan. File yang ditautkan secara eksternal (misalnya video via jalur relatif) tidak disalin secara otomatis—pastikan jalur referensi tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. [Properti dokumen](/slides/id/androidjava/presentation-properties/) standar didukung dan akan ditulis ke file saat disimpan.