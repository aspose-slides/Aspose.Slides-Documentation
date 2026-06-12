---
title: Menyimpan Presentasi di Java
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
- menyegarkan thumbnail
- menyimpan progres
- Java
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di Java menggunakan Aspose.Slides—mengekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Ringkasan**

[Open Presentations in Java](/slides/id/java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) berisi konten sebuah presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi presentasi yang sudah ada, Anda akan ingin menyimpannya setelah selesai. Dengan Aspose.Slides for Java, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Menyimpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `save` kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

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

## **Menyimpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberikan output stream ke metode `save` kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). Presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

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

## **Menyimpan Presentasi dengan Tipe Tampilan yang Telah Ditetapkan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewproperties/#setLastView-int-) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxoptions/) dan atur properti conformance saat menyimpan. Jika Anda mengatur [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), file output disimpan dalam format Strict Office Open XML.

Contoh berikut membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Menyimpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi setiap file menjadi 4 GB (2^32 byte), ukuran terkompresi setiap file, serta total ukuran arsip, dan juga membatasi jumlah file menjadi 65 535 (2^16‑1). Ekstensi format ZIP64 mengangkat batasan ini menjadi 2^64.

Metode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batasan di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut mendemonstrasikan cara menyimpan presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

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
Ketika Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/java/com.aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxexception/) dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Menyimpan Presentasi tanpa Menyegarkan Gambar Miniatur**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) mengontrol pembuatan gambar miniatur ketika menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, gambar miniatur disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, gambar miniatur saat ini dipertahankan. Jika presentasi tidak memiliki gambar miniatur, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan gambar miniaturnya.

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

## **Menyimpan Pembaruan Progres dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) digunakan melalui metode `setProgressCallback` yang disediakan oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) dengan `setProgressCallback` untuk menerima pembaruan progres penyimpanan dalam bentuk persentase.

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
Aspose telah mengembangkan aplikasi [PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda membagi sebuah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "penyimpanan cepat" (incremental save) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap kali menyimpan file target dibuat secara penuh; penyimpanan cepat secara incremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) **tidak thread‑safe** (/slides/id/java/multithreading/); simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/java/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video via jalur relatif) tidak disalin secara otomatis—pastikan jalur yang direferensikan tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar [/slides/id/java/presentation-properties/] didukung dan akan ditulis ke file saat disimpan.