---
title: "Amankan Presentasi dengan Kata Sandi di JavaScript"
linktitle: "Perlindungan Kata Sandi"
type: docs
weight: 20
url: /id/nodejs-java/password-protected-presentation/
keywords:
- "Kunci PowerPoint"
- "Kunci presentasi"
- "Buka kunci PowerPoint"
- "Buka kunci presentasi"
- "Lindungi PowerPoint"
- "Lindungi presentasi"
- "Tetapkan kata sandi"
- "Tambahkan kata sandi"
- "Enkripsi PowerPoint"
- "Enkripsi presentasi"
- "Dekripsi PowerPoint"
- "Dekripsi presentasi"
- "Perlindungan penulisan"
- "Keamanan PowerPoint"
- "Keamanan presentasi"
- "Hapus kata sandi"
- "Hapus perlindungan"
- "Hapus enkripsi"
- "Nonaktifkan kata sandi"
- "Nonaktifkan perlindungan"
- "Hapus perlindungan penulisan"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk Node.js via Java. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, berarti Anda menetapkan kata sandi yang memberlakukan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan pembatasan berikut pada sebuah presentasi:

- **Modifikasi**

  Jika Anda hanya menginginkan pengguna tertentu untuk memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang memodifikasi, mengubah, atau menyalin hal‑hal dalam presentasi Anda (kecuali mereka memberikan kata sandi).

  Namun, dalam kasus ini, meskipun tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode hanya‑baca, pengguna dapat melihat isi atau elemen—tautan hiper, animasi, efek, dan lain‑lain—di dalam presentasi, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda hanya menginginkan pengguna tertentu untuk membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memberikan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: ketika orang tidak dapat membuka sebuah presentasi, mereka tidak dapat memodifikasi atau membuat perubahan pada presentasi tersebut.  
  
  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, berkas presentasi menjadi terenkripsi.

## **Cara Melindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik **Drop or upload your files**.

3. Pilih berkas yang ingin Anda lindungi dengan kata sandi di komputer Anda. 

4. Masukkan kata sandi pilihan Anda untuk perlindungan edit; Masukkan kata sandi pilihan Anda untuk perlindungan tampilan. 

5. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan akhir, centang kotak **Mark as final**.

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

## **Mengenkripsi Presentasi**

Anda dapat mengenkripsi presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi terkunci, pengguna harus memberikan kata sandi. 

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [ProtectionManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager)) untuk menetapkan kata sandi pada presentasi. Anda melewatkan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

Kode contoh ini menunjukkan cara mengenkripsi presentasi:

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

## **Menetapkan Perlindungan Penulisan pada Presentasi**

Anda dapat menambahkan tanda “Do not modify” pada presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak mengizinkan mereka mengubah presentasi.  

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda. 

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Kode contoh ini menunjukkan cara menetapkan perlindungan penulisan pada presentasi:

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

## **Mendekripsi Presentasi; Membuka Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat berkas terenkripsi dengan melewatkan kata sandinya. Untuk mendekripsi presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) tanpa parameter. Kemudian Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.

Kode contoh ini menunjukkan cara mendekripsi presentasi: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // bekerja dengan presentasi yang didekripsi
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Menghapus Enkripsi; Menonaktifkan Perlindungan Kata Sandi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan. 

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Kode contoh ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

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

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang diterapkan pada berkas presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—tanpa peringatan saat melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari sebuah presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Kode contoh ini menunjukkan cara menghapus perlindungan penulisan dari sebuah presentasi:

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

## **Mendapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menyediakan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sambil tetap memberi kemampuan kepada pengguna untuk mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen tetap dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukannya.

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi terenkripsi, lewati `false` ke `setEncryptDocumentProperties` pada [ProtectionManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/protectionmanager/). Kode contoh ini menunjukkan cara mengenkripsi presentasi sekaligus tetap memberikan akses ke properti dokumennya:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata presentasi terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/) dan lewati `true` ke `setOnlyLoadDocumentProperties`. Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses secara publik.

Contoh kode berikut membaca properti dokumen bawaan dan kustom melalui `getDocumentProperties` pada [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Baca properti dokumen bawaan.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Baca properti dokumen kustom.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, melewatkan `true` ke `LoadOptions.setOnlyLoadDocumentProperties` menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat presentasi lengkap termasuk slide dan konten lainnya, berikan kata sandi yang benar melalui `LoadOptions.setPassword` pada [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/).

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi Sebelum Memuatnya**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode JavaScript ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Memeriksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan hal ini, Anda dapat menggunakan properti [isEncrypted](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

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

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan hal ini, Anda dapat menggunakan properti [isWriteProtected](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

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

## **Memvalidasi atau Mengonfirmasi bahwa Kata Sandi Tertentu Telah Digunakan untuk Melindungi Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi. 

Kode contoh ini menunjukkan cara memvalidasi kata sandi:

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

{{% alert color="primary" title="Lihat juga" %}} 
- [Digital Signature in PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Pengecualian akan dilempar jika kata sandi yang salah digunakan, memberi peringatan bahwa akses ke presentasi ditolak. Hal ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit overhead selama operasi pembukaan dan penyimpanan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi Anda.