---
title: Proteksi Presentasi dengan Kata Sandi di PHP
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/php-java/password-protected-presentation/
keywords:
- presentasi terlindungi kata sandi
- kata sandi pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi kata sandi presentasi
- periksa kata sandi presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- PHP
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, membuka, dan mendekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi kata sandi di PHP dengan Aspose.Slides."
---
## **Gambaran Umum**

Kata sandi pembuka mengenkripsi presentasi. Kata sandi yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Kata sandi pembuka berbeda dari kata sandi perlindungan penulisan. Perlindungan penulisan membatasi modifikasi namun tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola kata sandi untuk memodifikasi presentasi, lihat [Write-Protect Presentations](/slides/id/php-java/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh-contoh menggunakan kedua format tersebut ketika perilaku berbasis file dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Kata Sandi Pembuka**

Gunakan [ProtectionManager::encrypt](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#encrypt) untuk menetapkan kata sandi pembuka. Kemudian gunakan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk menyimpan presentasi yang telah dienkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Muat Presentasi yang Dienkripsi**

Setel [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword) ke kata sandi pembuka dan berikan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) saat memuat file. Proses pemuatan gagal ketika kata sandi pembuka diperlukan tetapi kata sandi yang diberikan tidak ada atau salah.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Bekerja dengan presentasi yang sudah didekripsi.
} finally {
    $presentation->dispose();
}
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan kata sandi pembukanya, panggil [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeEncryption), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa kata sandi.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Validasi Kata Sandi Pembuka Sebelum Memuat**

Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk memperoleh [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/) tanpa membuat instance presentasi secara lengkap. Periksa [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#isPasswordProtected) sebelum meminta atau memvalidasi kata sandi. Ketika perlindungan ada, validasi nilai yang diberikan dengan [PresentationInfo::checkPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Alur Kerja Jalur Berkas**

Contoh berikut memvalidasi kata sandi pembuka untuk file PPTX, mengirim nilai yang divalidasi ke [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword), dan kemudian memuat presentasi lengkap:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Alur Kerja Aliran**

Overload aliran dari [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) menyediakan alur kerja yang sama. Reset posisi aliran yang dapat dicari sebelum memuat presentasi lengkap dari aliran tersebut.

Contoh berikut menggunakan file PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Nilai Kembali checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#checkPassword) mengembalikan `true` hanya ketika presentasi memiliki kata sandi pembuka dan kata sandi yang diberikan benar. Ia mengembalikan `false` dalam masing‑mata kasus berikut:

- Kata sandi salah.
- Presentasi tidak memiliki kata sandi pembuka.
- Kata sandi yang diberikan `null` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Dienkripsi**

Setelah memuat presentasi dengan kata sandi yang benar, periksa [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isEncrypted) untuk memastikan bahwa presentasi sumber telah dienkripsi. Untuk mendeteksi perlindungan kata sandi pembuka sebelum memuat, gunakan [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#isPasswordProtected) seperti yang ditunjukkan di atas.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Security" %}}
Jangan mencatat kata sandi pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, simpan kata sandi dalam memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika segera memuat presentasi.
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
2. Pilih atau unggah presentasi.
3. Masukkan kata sandi untuk perlindungan tampilan.
4. Opsional, masukkan kata sandi terpisah untuk perlindungan edit.
5. Terapkan perlindungan dan unduh file yang dihasilkan.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/id/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/id/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara kata sandi pembuka dan kata sandi perlindungan penulisan?**

Kata sandi pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Kata sandi perlindungan penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi kata sandi pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan kata sandi pembuka hadir, dan validasi kata sandi sebelum membuat instance presentasi secara lengkap.

**Apakah alur kerja pemeriksaan kata sandi mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi kata sandi berbasis jalur berkas maupun aliran berperilaku sama untuk presentasi PPT dan PPTX.