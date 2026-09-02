---
title: Amankan Presentasi dengan Kata Sandi di Android
linktitle: Perlindungan Kata Sandi
type: docs
weight: 20
url: /id/androidjava/password-protected-presentation/
keywords:
- kunci PowerPoint
- kunci presentasi
- buka kunci PowerPoint
- buka kunci presentasi
- lindungi PowerPoint
- lindungi presentasi
- atur kata sandi
- tambahkan kata sandi
- enkripsi PowerPoint
- enkripsi presentasi
- dekripsi PowerPoint
- dekripsi presentasi
- perlindungan penulisan
- keamanan PowerPoint
- keamanan presentasi
- hapus kata sandi
- hapus perlindungan
- hapus enkripsi
- nonaktifkan kata sandi
- nonaktifkan perlindungan
- hapus perlindungan penulisan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kunci dan buka kunci presentasi PowerPoint dan OpenDocument yang dilindungi kata sandi dengan mudah menggunakan Aspose.Slides untuk Android via Java. Amankan presentasi Anda."
---
## **Pengantar**

Ketika Anda melindungi presentasi dengan kata sandi, itu berarti Anda menetapkan kata sandi yang memberlakukan batasan tertentu pada presentasi. Untuk menghapus batasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan batasan ini pada sebuah presentasi:

- **Modifikasi**

  Jika Anda hanya menginginkan pengguna tertentu untuk memodifikasi presentasi Anda, Anda dapat menetapkan batasan modifikasi. Batasan ini mencegah orang mengubah, memodifikasi, atau menyalin hal‑hal dalam presentasi Anda (kecuali mereka memasukkan kata sandi). 

  Namun, dalam kasus ini, bahkan tanpa kata sandi, pengguna dapat mengakses dokumen Anda dan membukanya. Dalam mode hanya‑baca ini, pengguna dapat melihat isi atau hal‑hal—tautan hiper, animasi, efek, dan lainnya—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi. 

- **Membuka**

  Jika Anda hanya menginginkan pengguna tertentu untuk membuka presentasi Anda, Anda dapat menetapkan batasan pembukaan. Batasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memasukkan kata sandi).

  Secara teknis, batasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: Ketika orang tidak dapat membuka sebuah presentasi, mereka tidak dapat mengubah atau membuat perubahan pada presentasi tersebut. 
  
  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut: 

- PPTX dan PPT – Presentasi Microsoft PowerPoint 
- ODP – Presentasi OpenDocument 
- OTP – Template Presentasi OpenDocument 

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi sebuah presentasi
- Menetapkan perlindungan penulisan pada sebuah presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi
- Menghapus perlindungan penulisan dari sebuah presentasi
- Mendapatkan properti sebuah presentasi yang terenkripsi
- Memeriksa apakah sebuah presentasi terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi kata sandi.

## **Enkripsi Presentasi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus menyediakan kata sandi. 

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [IProtectionManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager)) untuk menetapkan kata sandi pada presentasi. Anda meneruskan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

This sample code shows you how to encrypt a presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menetapkan Perlindungan Penulisan pada Presentasi**

Anda dapat menambahkan tanda “Jangan dimodifikasi” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.  

**Catatan** bahwa proses perlindungan penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda. 

Untuk menetapkan perlindungan penulisan, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Contoh kode ini menunjukkan cara menetapkan perlindungan penulisan pada sebuah presentasi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Muat Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat file yang terenkripsi dengan memberikan kata sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) tanpa parameter. Selanjutnya Anda harus memasukkan kata sandi yang benar untuk memuat presentasi.

Contoh kode ini menunjukkan cara mendekripsi sebuah presentasi: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // bekerja dengan presentasi yang didekripsi
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menghapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa batasan. 

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Contoh kode ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menghapus Perlindungan Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan penulisan yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan tidak akan ada peringatan saat mereka melakukan tugas tersebut.

Anda dapat menghapus perlindungan penulisan dari sebuah presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Contoh kode ini menunjukkan cara menghapus perlindungan penulisan dari sebuah presentasi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mendapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari sebuah presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sekaligus mempertahankan kemampuan pengguna untuk mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen tetap dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukan hal itu.

Jika Anda ingin pengguna tetap memiliki kemampuan mengakses properti sebuah presentasi yang terenkripsi, berikan `false` ke [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) . Contoh kode ini menunjukkan cara mengenkripsi presentasi sambil tetap memberikan pengguna akses ke properti dokumennya:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata sebuah presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/) dan berikan `true` ke [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses secara publik.

Contoh kode berikut membaca properti dokumen bawaan dan khusus melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Baca properti dokumen bawaan.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Baca properti dokumen khusus.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, memberikan `true` ke `loadOptions.setOnlyLoadDocumentProperties` akan menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat seluruh presentasi, termasuk slide dan konten lainnya, berikan kata sandi yang benar melalui [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tersebut tidak dilindungi kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode Java ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Memeriksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan ini, Anda dapat menggunakan properti [isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak terenkripsi.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Memeriksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan ini, Anda dapat menggunakan properti [isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Contoh kode ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validasi atau Konfirmasi Bahwa Kata Sandi Tertentu Telah Digunakan**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi. 

Contoh kode ini menunjukkan cara memvalidasi kata sandi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // periksa apakah "pass" cocok dengan
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Ini mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan. Jika tidak, mengembalikan `false`. 

{{% alert color="primary" title="Lihat juga" %}} 
- [Digital Signature in PowerPoint](/slides/id/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Pengecualian akan dilemparkan jika kata sandi yang salah digunakan, memberi peringatan bahwa akses ke presentasi ditolak. Hal ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit beban selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak memengaruhi secara signifikan waktu pemrosesan keseluruhan tugas presentasi Anda.