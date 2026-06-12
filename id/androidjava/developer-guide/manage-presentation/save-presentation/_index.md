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
- presentasi ke stream
- tipe tampilan yang ditentukan sebelumnya
- Format Office Open XML Strict
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- Android
- Java
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Java menggunakan Aspose.Slides untuk Android—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Open Presentations on Android](/slides/id/androidjava/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) untuk membuka presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) berisi konten presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda ingin menyimpannya setelah selesai. Dengan Aspose.Slides untuk Android, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Simpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberikan output stream ke metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/). Presentasi dapat ditulis ke berbagai jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi.
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

## **Simpan Presentasi dengan Tipe Tampilan yang Ditetapkan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint ketika presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML Strict**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Office Open XML Strict. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/) dan atur properti conformance‑nya saat menyimpan. Jika Anda mengatur [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), file output disimpan dalam format Office Open XML Strict.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Office Open XML Strict.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Simpan presentasi dalam format Office Open XML Strict.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi setiap file menjadi 4 GB (2^32 byte), ukuran terkompresi setiap file, dan total ukuran arsip, serta membatasi jumlah file dalam arsip hingga 65.535 (2^16‑1) file. Ekstensi format ZIP64 meningkatkan batasan ini menjadi 2^64.

Metode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batasan di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```java
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
Saat Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxexception/) akan dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail akan disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnail‑nya.

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Gunakan nilai persentase kemajuan di sini.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan sebuah [aplikasi PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda memecah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**  
Tidak. Setiap kali menyimpan akan membuat file target penuh; "fast save" inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**  
Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) [tidak thread‑safe](/slides/id/androidjava/multithreading/); simpanlah dari satu thread.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**  
[Hyperlinks](/slides/id/androidjava/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan path relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**  
Ya. [Properti dokumen] standar (/slides/id/androidjava/presentation-properties/) didukung dan akan dituliskan ke file saat disimpan.