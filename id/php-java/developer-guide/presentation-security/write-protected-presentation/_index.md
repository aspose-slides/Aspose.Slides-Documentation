---
title: Proteksi Penulisan Presentasi di PHP
linktitle: Proteksi Penulisan
type: docs
weight: 25
url: /id/php-java/write-protected-presentation/
keywords:
- proteksi penulisan
- proteksi penulisan PowerPoint
- kata sandi untuk memodifikasi
- batasi pengeditan presentasi
- hapus proteksi penulisan
- validasi kata sandi modifikasi
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Mengatur, mendeteksi, memvalidasi, dan menghapus kata sandi proteksi penulisan pada presentasi PowerPoint PPT dan PPTX menggunakan Aspose.Slides untuk PHP."
---
## **Pendahuluan**

Kata sandi perlindungan tulis membatasi modifikasi sebuah presentasi tetapi tidak mengenkripsi isinya. Pengguna dapat memuat dan melihat presentasi yang dilindungi tulis tanpa kata sandi. Tergantung pada aplikasi, mereka mungkin juga dapat mengedit konten dan menyimpannya dengan nama berbeda, jadi perlindungan tulis tidak boleh dianggap sebagai mekanisme kerahasiaan.

Kata sandi pembuka memiliki tujuan yang berbeda: ia mengenkripsi presentasi dan diperlukan untuk memuat isinya. Untuk mengenkripsi presentasi atau memvalidasi kata sandi pembuka, lihat [Password-Protect Presentations](/slides/id/php-java/password-protected-presentation/).

Alur kerja dalam artikel ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan file PPTX; ketika menyimpan ke PPT, gunakan ekstensi `.ppt` dan format penyimpanan PPT yang sesuai.

## **Atur Perlindungan Tulis pada Presentasi**

Gunakan [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#setWriteProtection) untuk menetapkan kata sandi yang diperlukan untuk memodifikasi presentasi. Menyimpan presentasi akan mempertahankan pengaturan perlindungan tersebut.

Contoh berikut menetapkan perlindungan tulis pada presentasi PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Muat Presentasi yang Dilindungi Tulis**

Karena perlindungan tulis tidak mengenkripsi konten presentasi, tidak diperlukan kata sandi untuk memuat presentasi. Kata sandi hanya relevan saat memvalidasi otorisasi untuk mengubah presentasi yang dilindungi.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Jangan berikan kata sandi perlindungan tulis ke [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword). Metode tersebut menerima kata sandi pembuka untuk konten yang dienkripsi. Jika sebuah presentasi memiliki kedua jenis perlindungan, berikan kata sandi pembuka untuk memuatnya dan tangani kata sandi perlindungan tulis secara terpisah.

## **Hapus Perlindungan Tulis dari Presentasi**

Gunakan [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeWriteProtection) untuk menghapus pembatasan modifikasi, lalu simpan presentasi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Periksa Apakah Presentasi Dilindungi Tulis**

Untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang lengkap, panggil [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) dan periksa [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#isWriteProtected). Metode ini menggunakan [NullableBool](https://reference.aspose.com/slides/id/php-java/aspose.slides/nullablebool/) dan mengembalikan `NullableBool::True` ketika perlindungan tulis terdeteksi.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

Overload stream dari [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/#getPresentationInfo) memberikan informasi yang sama untuk presentasi yang disediakan sebagai stream.

## **Validasi Kata Sandi Perlindungan Tulis**

Gunakan [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#checkWriteProtection) untuk memvalidasi kata sandi modifikasi tanpa memuat presentasi secara lengkap. Periksa [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#isWriteProtected) terlebih dahulu sehingga aplikasi hanya meminta atau memvalidasi kata sandi ketika perlindungan tulis ada.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#checkWriteProtection) memvalidasi hanya kata sandi perlindungan tulis. Ia tidak memvalidasi kata sandi pembuka atau menentukan apakah konten terenkripsi dapat dimuat. Sebaliknya, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#checkPassword) memvalidasi hanya kata sandi pembuka. Jika sebuah presentasi lengkap sudah dimuat, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#checkWriteProtection) menyediakan pemeriksaan perlindungan tulis yang setara melalui manajer perlindungannya.

Dalam aplikasi produksi, jangan mencatat kata sandi atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak perlu, dan simpan kata sandi dalam memori hanya selama diperlukan.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/id/php-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/id/php-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/id/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Apakah perlindungan tulis mengenkripsi sebuah presentasi?**

Tidak. Ia membatasi modifikasi tetapi membiarkan konten presentasi tersedia untuk dimuat dan dilihat.

**Apakah kata sandi perlindungan tulis diperlukan untuk membuka sebuah presentasi?**

Tidak. Hanya kata sandi pembuka yang diperlukan untuk memuat konten presentasi yang terenkripsi.

**Apakah sebuah presentasi dapat memiliki kata sandi pembuka dan kata sandi perlindungan tulis sekaligus?**

Ya. Berikan kata sandi pembuka melalui opsi muat untuk membuka presentasi yang terenkripsi, dan validasi kata sandi perlindungan tulis secara terpisah ketika otorisasi modifikasi diperlukan.