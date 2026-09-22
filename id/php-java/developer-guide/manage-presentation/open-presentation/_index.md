---
title: Membuka Presentasi di PHP
linktitle: Membuka Presentasi
type: docs
weight: 20
url: /id/php-java/open-presentation/
keywords:
- membuka PowerPoint
- membuka presentasi
- membuka PPTX
- membuka PPT
- membuka ODP
- memuat presentasi
- memuat PPTX
- memuat PPT
- memuat ODP
- presentasi dilindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- PHP
- Aspose.Slides
description: "Pelajari cara membuka presentasi PowerPoint dan OpenDocument di PHP, menyediakan kata sandi pembuka, mengontrol pemuatan sumber daya, dan mengurangi penggunaan memori dengan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/id/php-java/) dapat memuat presentasi PowerPoint dan OpenDocument dari file dan aliran. Setelah sebuah presentasi dimuat, Anda dapat memeriksa strukturnya, menyunting slide, mengelola sumber daya, dan menyimpannya dalam format asli atau format lain yang didukung.

Perilaku pemuatan dapat disesuaikan melalui kelas [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/). Misalnya, Anda dapat menyediakan kata sandi pembuka, menyimpan objek biner besar di luar memori heap Java, mengendalikan sumber daya eksternal, atau mengabaikan data biner yang tertanam.

## **Buka Presentasi**

Setelah memuat file atau aliran, Anda dapat [menentukan format presentasi asli](/slides/id/php-java/detect-presentation-source-format/) untuk memilih cara aplikasi Anda memprosesnya.

Untuk membuka presentasi yang ada, berikan jalur file ke konstruktor [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Buang (dispose) presentasi setelah digunakan agar pegangan file, data sementara, dan sumber daya lainnya segera dibebaskan.

Contoh PHP berikut menunjukkan cara membuka presentasi dan mendapatkan jumlah slide-nya:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Buka Presentasi yang Dilindungi Kata Sandi**

Kata sandi pembuka mengenkripsi konten presentasi. Untuk memuat seluruh presentasi, berikan kata sandi yang benar ke [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword) dan sediakan opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Pemuatan gagal bila kata sandi tidak ada atau salah.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Untuk deteksi kata sandi, validasi, dan alur kerja enkripsi, lihat [Password-Protect Presentations](/slides/id/php-java/password-protected-presentation/). Jika sebuah presentasi terenkripsi memang disimpan dengan properti dokumen publik, properti tersebut dapat dibaca tanpa kata sandi; lihat [Manage Presentation Properties](/slides/id/php-java/presentation-properties/).

## **Buka Presentasi Besar**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) mengembalikan opsi yang mengontrol bagaimana Aspose.Slides menangani objek biner besar seperti gambar, audio, dan video. Anda dapat menjaga file sumber tetap terkunci, mengizinkan file sementara, dan membatasi jumlah data BLOB yang dipertahankan dalam memori.

Kode PHP berikut menunjukkan pemuatan presentasi besar (misalnya, 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Dengan [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), file sumber tetap terkunci sampai instance presentasi dibuang. Jangan memindahkan, menimpa, atau menghapus file sumber sementara instance tersebut masih hidup.

Aspose.Slides mungkin menyalin isi aliran input saat memuatnya. Untuk presentasi besar, jalur file biasanya lebih efisien dibanding aliran. Lihat [Manage BLOBs](/slides/id/php-java/manage-blob/) untuk opsi penyimpanan dan manajemen memori tambahan.
{{% /alert %}}

## **Kontrol Sumber Daya Eksternal**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) menerima implementasi dari antarmuka Java [IResourceLoadingCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iresourceloadingcallback/) melalui PHP/Java Bridge. Callback dapat menyediakan data pengganti, mengarahkan ulang sumber daya, menggunakan pemuat default, atau melewati sumber daya. Ini berguna ketika presentasi berisi gambar eksternal yang harus diselesaikan sesuai dengan aturan keamanan atau penyimpanan khusus aplikasi.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Muat Presentasi Tanpa Objek Biner Tertanam**

Sebuah presentasi dapat berisi data biner tertanam yang tidak diperlukan atau tidak ingin disimpan oleh aplikasi. Contohnya:

- Proyek VBA, tersedia melalui [Presentation::getVbaProject](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getVbaProject);
- Data OLE tertanam, tersedia melalui [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/id/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Data kontrol ActiveX, tersedia melalui [Control::getActiveXControlBinary](https://reference.aspose.com/slides/id/php-java/aspose.slides/control/#getActiveXControlBinary).

Atur [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) ke `true` untuk menghapus data biner ini saat memuat. Simpan presentasi yang dimuat untuk mempertahankan hasil yang telah dibersihkan.

Opsi ini mengurangi paparan terhadap muatan tertanam yang tidak diinginkan, namun bukan sistem deteksi malware atau sanitasi konten yang lengkap.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Aspose.Slides melempar pengecualian parsing atau format saat memuat. Tangani kegagalan tersebut secara terpisah dari kesalahan kata sandi yang salah agar aplikasi dapat melaporkan penyebabnya dengan akurat.

**Apa yang terjadi jika font yang dibutuhkan tidak ada?**

Presentasi masih dapat dimuat, tetapi rendering dan ekspor mungkin mengganti font. Anda dapat [mengonfigurasi substitusi font](/slides/id/php-java/font-substitution/) atau [menyediakan font khusus](/slides/id/php-java/custom-font/) untuk membuat keluaran lebih dapat diprediksi.

**Apakah memuat presentasi juga memuat media yang tertanam?**

Audio dan video yang tertanam menjadi tersedia melalui model objek presentasi. Sumber daya eksternal diselesaikan sesuai dengan perilaku pemuatan sumber daya yang dikonfigurasi dan mungkin tidak tersedia jika lokasinya tidak dapat diakses.