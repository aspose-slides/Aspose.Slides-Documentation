---
title: "Amankan Presentasi dengan Kata Sandi di JavaScript"
linktitle: "Perlindungan Kata Sandi"
type: docs
weight: 20
url: /id/nodejs-java/password-protected-presentation/
keywords:
- "kunci PowerPoint"
- "kunci presentasi"
- "buka kunci PowerPoint"
- "buka kunci presentasi"
- "lindungi PowerPoint"
- "lindungi presentasi"
- "atur kata sandi"
- "tambahkan kata sandi"
- "enkripsi PowerPoint"
- "enkripsi presentasi"
- "dekripsi PowerPoint"
- "dekripsi presentasi"
- "perlindungan tulis"
- "keamanan PowerPoint"
- "keamanan presentasi"
- "hapus kata sandi"
- "hapus perlindungan"
- "hapus enkripsi"
- "nonaktifkan kata sandi"
- "nonaktifkan perlindungan"
- "hapus perlindungan tulis"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Dengan mudah kunci dan buka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk Node.js lewat Java. Amankan presentasi Anda."
---
## **Pendahuluan**

Ketika Anda melindungi presentasi dengan kata sandi, itu berarti Anda menetapkan kata sandi yang memberlakukan batasan tertentu pada presentasi. Untuk menghapus batasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi yang terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan batasan ini pada sebuah presentasi:

- **Modifikasi**

  Jika Anda hanya ingin pengguna tertentu dapat memodifikasi presentasi Anda, Anda dapat menetapkan batasan modifikasi. Batasan ini mencegah orang memodifikasi, mengubah, atau menyalin elemen dalam presentasi Anda (kecuali mereka memasukkan kata sandi).

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna masih dapat mengakses dokumen Anda dan membukanya. Dalam mode baca-saja, pengguna dapat melihat konten atau elemen—tautan hiper, animasi, efek, dan lainnya—di dalam presentasi, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda hanya ingin pengguna tertentu dapat membuka presentasi Anda, Anda dapat menetapkan batasan pembukaan. Batasan ini mencegah orang bahkan melihat konten presentasi Anda (kecuali mereka memasukkan kata sandi).

  Secara teknis, batasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka presentasi, mereka tidak dapat melakukan perubahan apapun.

  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih file yang ingin Anda lindungi dengan kata sandi pada komputer Anda. 

4. Masukkan kata sandi yang Anda inginkan untuk perlindungan edit; Masukkan kata sandi yang Anda inginkan untuk perlindungan tampilan. 

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

- Mengenkripsi sebuah presentasi
- Menetapkan perlindungan tulis pada sebuah presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi
- Menghapus perlindungan tulis dari sebuah presentasi
- Mendapatkan properti sebuah presentasi yang terenkripsi
- Memeriksa apakah sebuah presentasi terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi kata sandi.

## **Mengenkripsi Sebuah Presentasi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memberikan kata sandi.

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager)) untuk menetapkan kata sandi pada presentasi. Anda melewatkan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode ini menunjukkan cara mengenkripsi sebuah presentasi:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Menetapkan Perlindungan Tulis pada Sebuah Presentasi**

Anda dapat menambahkan tanda “Jangan ubah” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.

**Catatan** bahwa proses perlindungan tulis tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.

Untuk menetapkan perlindungan tulis, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) . Contoh kode ini menunjukkan cara menetapkan perlindungan tulis pada sebuah presentasi:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mendekripsi Sebuah Presentasi; Membuka Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat file terenkripsi dengan memasukkan kata sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) tanpa parameter. Selanjutnya Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.

Contoh kode ini menunjukkan cara mendekripsi sebuah presentasi:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // bekerja dengan presentasi yang telah didekripsi
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Menghapus Enkripsi; Menonaktifkan Perlindungan Kata Sandi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa batasan.

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) . Contoh kode ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Menghapus Perlindungan Tulis dari Sebuah Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan tulis yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan tidak ada peringatan saat mereka melakukan tugas tersebut.

Anda dapat menghapus perlindungan tulis dari sebuah presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Contoh kode ini menunjukkan cara menghapus perlindungan tulis dari sebuah presentasi:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Mendapatkan Properti Sebuah Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mendapatkan properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Aspose.Slides, bagaimanapun, menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memberi pengguna cara untuk mengakses properti presentasi tersebut.

**Catatan** bahwa ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi kata sandi secara default. Tetapi jika Anda perlu membuat properti presentasi dapat diakses (bahkan setelah presentasi dienkripsi), Aspose.Slides memungkinkan Anda melakukan hal itu.

Jika Anda ingin pengguna tetap dapat mengakses properti sebuah presentasi yang Anda enkripsi, Anda dapat menetapkan properti [encryptDocumentProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) menjadi `true`. Contoh kode ini menunjukkan cara mengenkripsi sebuah presentasi sambil menyediakan cara bagi pengguna mengakses properti dokumennya:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Memeriksa Apakah Sebuah Presentasi Dilindungi Kata Sandi Sebelum Memuatnya**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi kata sandi. Dengan cara ini, Anda menghindari kesalahan dan masalah serupa yang muncul saat presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode JavaScript ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Memeriksa Apakah Sebuah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan properti [isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Memeriksa Apakah Sebuah Presentasi Dilindungi Tulis**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi tulis. Untuk melakukan tugas ini, Anda dapat menggunakan properti [isWriteProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , yang mengembalikan `true` jika presentasi dilindungi tulis atau `false` jika tidak.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi tulis:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Memvalidasi atau Mengonfirmasi bahwa Kata Sandi Tertentu Telah Digunakan untuk Melindungi Sebuah Presentasi**

Anda mungkin ingin memeriksa dan mengonfirmasi bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi sebuah kata sandi.

Contoh kode ini menunjukkan cara memvalidasi sebuah kata sandi:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // periksa apakah "pass" cocok dengan
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `false`.

{{% alert color="primary" title="See also" %}} 
- [Tanda Tangan Digital di PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Sebuah pengecualian dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi isi presentasi.

**Apakah ada dampak performa saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit overhead selama operasi pembukaan dan penyimpanan. Dalam kebanyakan kasus, dampak performa ini minimal dan tidak memengaruhi secara signifikan waktu pemrosesan keseluruhan tugas presentasi Anda.