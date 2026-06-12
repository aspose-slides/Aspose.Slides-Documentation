---
title: Amankan Presentasi dengan Kata Sandi di PHP
linktitle: Perlindungan Kata Sandi
type: docs
weight: 20
url: /id/php-java/password-protected-presentation/
keywords:
- mengunci PowerPoint
- mengunci presentasi
- membuka kunci PowerPoint
- membuka kunci presentasi
- melindungi PowerPoint
- melindungi presentasi
- menetapkan kata sandi
- menambahkan kata sandi
- menenkripsi PowerPoint
- menenkripsi presentasi
- mendekripsi PowerPoint
- mendekripsi presentasi
- perlindungan penulisan
- keamanan PowerPoint
- keamanan presentasi
- menghapus kata sandi
- menghapus perlindungan
- menghapus enkripsi
- menonaktifkan kata sandi
- menonaktifkan perlindungan
- menghapus perlindungan penulisan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi dengan Aspose.Slides untuk PHP. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, berarti Anda menetapkan kata sandi yang menerapkan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat mengatur kata sandi untuk menerapkan pembatasan ini pada presentasi:

- **Modifikasi**

  Jika Anda hanya ingin pengguna tertentu dapat memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang memodifikasi, mengubah, atau menyalin isi presentasi Anda (kecuali mereka memberikan kata sandi).

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode baca saja, pengguna dapat melihat konten atau hal‑hal—tautan, animasi, efek, dan lainnya—di dalam presentasi, tetapi tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda hanya ingin pengguna tertentu dapat membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat konten presentasi Anda (kecuali mereka memberikan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka presentasi, mereka tidak dapat mengubah atau membuat perubahan pada presentasi tersebut.  

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda. 

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan. 

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.

6. Klik **PROTECT NOW.** 

7. Klik **DOWNLOAD NOW.**

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut: 

- PPTX dan PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi presentasi
- Menetapkan perlindungan penulisan pada presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi presentasi; membuka presentasi terenkripsi
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi
- Menghapus perlindungan penulisan dari presentasi
- Mendapatkan properti presentasi terenkripsi
- Memeriksa apakah presentasi terenkripsi
- Memeriksa apakah presentasi dilindungi kata sandi.

## **Enkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi terkunci, pengguna harus memberikan kata sandi. 

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/)) untuk menetapkan kata sandi pada presentasi. Anda mengirimkan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode ini menunjukkan cara mengenkripsi presentasi:

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

## **Menetapkan Perlindungan Penulisan pada Presentasi**

Anda dapat menambahkan tanda “Do not modify” pada presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka membuat perubahan pada presentasi.  

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda. 

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#setWriteProtection). Contoh kode ini menunjukkan cara menetapkan perlindungan penulisan pada presentasi:

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

## **Membuka Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda membuka file terenkripsi dengan memasukkan kata sandinya. Untuk mendekripsi presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeEncryption) tanpa parameter. Anda kemudian harus memasukkan kata sandi yang benar untuk membuka presentasi.

Contoh kode ini menunjukkan cara mendekripsi presentasi: 

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

## **Menghapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan. 

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeEncryption). Contoh kode ini menunjukkan cara menghapus enkripsi dari presentasi:

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

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesukanya—dan tidak akan menerima peringatan saat melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Contoh kode ini menunjukkan cara menghapus perlindungan penulisan dari presentasi:

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

## **Mendapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mendapatkan properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Aspose.Slides, bagaimanapun, menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memberi cara bagi pengguna mengakses properti presentasi tersebut.

**Catatan** bahwa ketika Aspose.Slides mengenkripsi presentasi, properti dokumen presentasi secara default juga dilindungi kata sandi. Tetapi jika Anda perlu membuat properti presentasi dapat diakses (bahkan setelah presentasi dienkripsi), Aspose.Slides memungkinkan Anda melakukannya.

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi yang Anda enkripsi, Anda dapat menggunakan metode [encryptDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) dengan nilai `true`. Contoh kode ini menunjukkan cara mengenkripsi presentasi sambil memberi cara bagi pengguna mengakses properti dokumennya:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda membuka presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dibuka tanpa kata sandinya.

Kode PHP ini menunjukkan cara memeriksa presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa membuka presentasi itu sendiri):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Memeriksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan metode [isEncrypted](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isEncrypted), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Contoh kode ini menunjukkan cara memeriksa apakah presentasi terenkripsi:

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

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan metode [isWriteProtected](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isWriteProtected), yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Contoh kode ini menunjukkan cara memeriksa apakah presentasi dilindungi penulisan:

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

## **Validasi atau Konfirmasi bahwa Kata Sandi Tertentu Telah Digunakan**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi. 

Contoh kode ini menunjukkan cara memvalidasi kata sandi:

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

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `false`. 

{{% alert color="primary" title="See also" %}} 
- [Tanda Tangan Digital di PowerPoint](/slides/id/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan ketika mencoba membuka presentasi?**

Sebuah pengecualian dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menimbulkan sedikit overhead selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi Anda.