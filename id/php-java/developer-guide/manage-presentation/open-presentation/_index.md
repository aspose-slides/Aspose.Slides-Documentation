---
title: Membuka Presentasi di PHP
linktitle: Membuka Presentasi
type: docs
weight: 20
url: /id/php-java/open-presentation/
keywords:
- buka PowerPoint
- buka OpenDocument
- buka presentasi
- buka PPTX
- buka PPT
- buka ODP
- muat presentasi
- muat PPTX
- muat PPT
- muat ODP
- presentasi terlindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- PHP
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk PHP via Java — cepat, handal, lengkap fiturnya."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus slide yang ada, dan lain-lain.

## **Buka Presentasi**

Untuk membuka presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan berikan jalur file ke konstruktornya.

Contoh PHP berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slidenya:

```php
// Instansiasi kelas Presentation dan berikan jalur file ke konstruktornya.
$presentation = new Presentation("Sample.pptx");
try {
    // Cetak total jumlah slide dalam presentasi.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Ketika Anda perlu membuka presentasi yang dilindungi kata sandi, berikan kata sandi melalui metode [setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode PHP berikut menunjukkan operasi ini:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Lakukan operasi pada presentasi yang didekripsi.
} finally {
    $presentation->dispose();
}
```

## **Buka Presentasi Besar**

Aspose.Slides menyediakan opsi—khususnya metode [getBlobManagementOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) dalam kelas [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

Kode PHP berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama masa hidup
// instansi Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.

    // Lakukan perubahan pada presentasi.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci sampai objek presentasi dibuang.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Tidak masalah melakukan ini di sini. File sumber tidak lagi terkunci oleh objek presentasi.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi beberapa keterbatasan saat bekerja dengan aliran, Aspose.Slides dapat menyalin isi aliran tersebut. Memuat presentasi besar dari aliran menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi bukan aliran.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar resolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/php-java/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Mengontrol Sumber Daya Eksternal**

Aspose.Slides menyediakan antarmuka [IResourceLoadingCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iresourceloadingcallback/) yang memungkinkan Anda mengelola sumber daya eksternal. Kode PHP berikut menunjukkan cara menggunakan antarmuka `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Muat gambar pengganti.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Tetapkan URL pengganti.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Lewati semua gambar lain.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Muat Presentasi tanpa Objek Biner Tersemat**

Sebuah presentasi PowerPoint dapat berisi jenis objek biner tersemat berikut:

- Proyek VBA (dapat diakses melalui [Presentation.getVbaProject](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getVbaProject));
- Data tersemat objek OLE (dapat diakses melalui [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Data biner kontrol ActiveX (dapat diakses melalui [Control.getActiveXControlBinary](https://reference.aspose.com/slides/id/php-java/aspose.slides/control/#getActiveXControlBinary)).

Dengan menggunakan metode [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), Anda dapat memuat presentasi tanpa objek biner tersemat apapun.

Metode ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode PHP berikut menunjukkan cara memuat presentasi tanpa konten biner tersemat apa pun:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Lakukan operasi pada presentasi.
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**  
Anda akan mendapatkan pengecualian validasi parsing/format saat memuat. Kesalahan semacam itu sering menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang diperlukan tidak ada saat membuka?**  
File akan terbuka, tetapi kemudian [rendering/export](/slides/id/php-java/convert-presentation/) mungkin akan mengganti font. [Configure font substitutions](/slides/id/php-java/font-substitution/) atau [add the required fonts](/slides/id/php-java/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**  
Mereka akan tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; jika tidak, [rendering/export](/slides/id/php-java/convert-presentation/) mungkin akan mengabaikan media tersebut.