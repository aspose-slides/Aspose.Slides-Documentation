---
title: Amankan Presentasi dengan Kata Sandi di PHP
linktitle: Perlindungan Kata Sandi
type: docs
weight: 20
url: /id/php-java/password-protected-presentation/
keywords:
- Kunci PowerPoint
- Kunci presentasi
- Buka kunci PowerPoint
- Buka kunci presentasi
- Lindungi PowerPoint
- Lindungi presentasi
- Atur kata sandi
- Tambahkan kata sandi
- Enkripsi PowerPoint
- Enkripsi presentasi
- Dekripsi PowerPoint
- Dekripsi presentasi
- Perlindungan penulisan
- Keamanan PowerPoint
- Keamanan presentasi
- Hapus kata sandi
- Hapus perlindungan
- Hapus enkripsi
- Nonaktifkan kata sandi
- Nonaktifkan perlindungan
- Hapus perlindungan penulisan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk PHP. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, itu berarti Anda mengatur kata sandi yang memberlakukan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat mengatur kata sandi untuk memberlakukan pembatasan ini pada presentasi:

- **Modifikasi**

  Jika Anda ingin hanya pengguna tertentu yang dapat memodifikasi presentasi Anda, Anda dapat mengatur pembatasan modifikasi. Pembatasan ini mencegah orang memodifikasi, mengubah, atau menyalin isi presentasi Anda (kecuali mereka memasukkan kata sandi).

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode hanya-baca, pengguna dapat melihat isi atau hal‑hal—hyperlink, animasi, efek, dan lain‑lain—di dalam presentasi, tetapi tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda ingin hanya pengguna tertentu yang dapat membuka presentasi Anda, Anda dapat mengatur pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memasukkan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: ketika orang tidak dapat membuka presentasi, mereka tidak dapat membuat perubahan apa pun.

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman **[Aspose.Slides Lock](https://products.aspose.app/slides/id/lock)** kami.  

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Seret atau unggah file Anda**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda.

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan.

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.

6. Klik **PROTECT NOW.**

7. Klik **DOWNLOAD NOW.**

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**Operasi yang didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi presentasi
- Menetapkan perlindungan penulisan pada presentasi

**Operasi lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi presentasi; membuka presentasi terenkripsi
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi
- Menghapus perlindungan penulisan dari presentasi
- Mendapatkan properti presentasi terenkripsi
- Memeriksa apakah presentasi terenkripsi
- Memeriksa apakah presentasi dilindungi kata sandi.

## **Enkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan mengatur kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memasukkan kata sandi.

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode **encrypt** (dari [ProtectionManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/)) untuk mengatur kata sandi pada presentasi. Anda mengirimkan kata sandi ke metode **encrypt** dan menggunakan metode **save** untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode berikut menunjukkan cara mengenkripsi presentasi:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Tetapkan Perlindungan Penulisan pada Presentasi**

Anda dapat menambahkan tanda “Do not modify” pada presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak ingin mereka mengubah presentasi.

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#setWriteProtection). Contoh kode berikut menunjukkan cara menetapkan perlindungan penulisan pada presentasi:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Muat Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat file terenkripsi dengan memasukkan kata sandinya. Untuk mendekripsi presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeEncryption) tanpa parameter. Selanjutnya Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.

Contoh kode berikut menunjukkan cara mendekripsi presentasi:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # bekerja dengan presentasi yang didekripsi
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Hapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan.

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeEncryption). Contoh kode berikut menunjukkan cara menghapus enkripsi dari presentasi:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Hapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang diterapkan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—tanpa peringatan saat melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Contoh kode berikut menunjukkan cara menghapus perlindungan penulisan dari presentasi:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Dapatkan Properti Presentasi Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menyediakan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memberi pengguna kemampuan mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen tetap dapat diakses meskipun setelah enkripsi, Aspose.Slides memungkinkan Anda melakukan hal tersebut.

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi terenkripsi, kirimkan `false` ke [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Contoh kode berikut menunjukkan cara mengenkripsi presentasi sambil tetap memberi pengguna akses ke properti dokumennya:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Muat Hanya Properti Dokumen dari Presentasi Terenkripsi**

Untuk memeriksa metadata presentasi terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/) dan kirimkan `true` ke [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses publik.

Contoh kode berikut membaca properti dokumen bawaan dan khusus melalui [Presentation::getDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Baca properti dokumen bawaan.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Baca properti dokumen khusus.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Alur kerja ini berfungsi hanya ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen dienkripsi, mengirimkan `true` ke [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) akan menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat seluruh presentasi, termasuk slide dan kontennya, berikan kata sandi yang benar melalui [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword).

## **Periksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode PHP berikut menunjukkan cara memeriksa apakah presentasi dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Periksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan ini, Anda dapat menggunakan metode [isEncrypted](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isEncrypted) yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Contoh kode berikut menunjukkan cara memeriksa apakah presentasi terenkripsi:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan ini, Anda dapat menggunakan metode [isWriteProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isWriteProtected) yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Contoh kode berikut menunjukkan cara memeriksa apakah presentasi dilindungi penulisan:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Validasi atau Konfirmasi Bahwa Kata Sandi Tertentu Telah Digunakan**

Anda mungkin ingin memeriksa dan mengonfirmasi bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi.

Contoh kode berikut menunjukkan cara memvalidasi kata sandi:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # periksa apakah "pass" cocok dengan
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Itu mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, mengembalikan `false`.

{{% alert color="primary" title="Lihat juga" %}} 
- [Digital Signature in PowerPoint](/slides/id/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka presentasi?**

Sebuah pengecualian dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menimbulkan sedikit overhead selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi.