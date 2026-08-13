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
- perlindungan tulis
- keamanan PowerPoint
- keamanan presentasi
- hapus kata sandi
- hapus perlindungan
- hapus enkripsi
- nonaktifkan kata sandi
- nonaktifkan perlindungan
- hapus perlindungan tulis
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Dengan mudah kunci dan buka kunci presentasi PowerPoint serta OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk Android via Java. Amankan presentasi Anda."
---
## **Pendahuluan**

Saat Anda melindungi presentasi dengan kata sandi, artinya Anda menetapkan kata sandi yang memberlakukan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan tersebut, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan pembatasan ini pada sebuah presentasi:

- **Modifikasi**

  Jika Anda ingin hanya pengguna tertentu yang dapat memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang mengubah, mengedit, atau menyalin hal‑hal dalam presentasi Anda (kecuali mereka memberikan kata sandi).

  Namun, dalam kasus ini, meskipun tanpa kata sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode hanya‑baca, pengguna dapat melihat isi atau elemen—tautan, animasi, efek, dan lain‑lain—di dalam presentasi, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda ingin hanya pengguna tertentu yang dapat membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memberikan kata sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: ketika orang tidak dapat membuka presentasi, mereka tidak dapat membuat perubahan apa pun pada presentasi tersebut.  
  
  **Catatan** bahwa ketika Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, berkas presentasi menjadi terenkripsi.

## **Perlindungan Kata Sandi untuk Presentasi di Aspose.Slides**
**Format yang didukung**

Aspose.Slides mendukung perlindungan kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Operasi yang didukung**

Aspose.Slides memungkinkan Anda menggunakan perlindungan kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi sebuah presentasi  
- Menetapkan perlindungan tulis pada sebuah presentasi  

**Operasi lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan perlindungan kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi  
- Menghapus enkripsi; menonaktifkan perlindungan kata sandi  
- Menghapus perlindungan tulis dari sebuah presentasi  
- Mendapatkan properti sebuah presentasi yang terenkripsi  
- Memeriksa apakah sebuah presentasi terenkripsi  
- Memeriksa apakah sebuah presentasi dilindungi kata sandi.

## **Mengenkripsi Presentasi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus menyediakan kata sandi.

Untuk mengenkripsi atau melindungi presentasi dengan kata sandi, Anda harus menggunakan metode encrypt (dari [IProtectionManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager)) untuk menetapkan kata sandi bagi presentasi. Anda meneruskan kata sandi ke metode encrypt dan menggunakan metode save untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode berikut menunjukkan cara mengenkripsi sebuah presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menetapkan Perlindungan Tulis pada Presentasi**

Anda dapat menambahkan tanda “Do not modify” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak ingin mereka melakukan perubahan pada presentasi.

**Catatan** bahwa proses perlindungan tulis tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.

Untuk menetapkan perlindungan tulis, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Contoh kode berikut menunjukkan cara menetapkan perlindungan tulis pada sebuah presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Memuat Presentasi yang terenkripsi**

Aspose.Slides memungkinkan Anda memuat presentasi yang terenkripsi dengan meneruskan kata sandi yang benar melalui [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/).

Contoh kode berikut menunjukkan cara membuka presentasi yang terenkripsi:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // bekerja dengan presentasi yang telah didekripsi
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menghapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau perlindungan kata sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan.

Untuk menghapus enkripsi atau perlindungan kata sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Contoh kode berikut menunjukkan cara menghapus enkripsi dari sebuah presentasi:

```java
import com.aspose.slides.*;

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

## **Menghapus Perlindungan Tulis dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus perlindungan tulis yang digunakan pada berkas presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—dan tidak akan ada peringatan saat mereka melakukan tugas tersebut.

Anda dapat menghapus perlindungan tulis dari sebuah presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Contoh kode berikut menunjukkan cara menghapus perlindungan tulis dari sebuah presentasi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Mendapatkan Properti Presentasi yang terenkripsi**

Biasanya, pengguna mengalami kesulitan untuk mengambil properti dokumen dari sebuah presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menyediakan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sekaligus tetap memberi kemampuan bagi pengguna untuk mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi tersebut juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukan hal tersebut.

Jika Anda ingin pengguna tetap dapat mengakses properti sebuah presentasi yang terenkripsi, kirimkan `false` ke [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Contoh kode berikut menunjukkan cara mengenkripsi sebuah presentasi sambil tetap memberi pengguna akses ke properti dokumennya:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Memuat Hanya Properti Dokumen dari Presentasi yang terenkripsi**

Untuk memeriksa metadata sebuah presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/) dan kirimkan `true` ke [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses secara publik.

Contoh kode berikut membaca properti dokumen bawaan dan kustom melalui [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Baca properti dokumen bawaan.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Baca properti dokumen kustom.
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

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, mengirimkan `true` ke `loadOptions.setOnlyLoadDocumentProperties` menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen terenkripsi atau memuat presentasi secara lengkap, termasuk slide dan konten lainnya, berikan kata sandi yang benar melalui [ILoadOptions.setPassword](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Memeriksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tersebut tidak dilindungi dengan kata sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika sebuah presentasi yang dilindungi kata sandi dimuat tanpa kata sandinya.

Kode Java berikut menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi (tanpa memuat presentasi itu sendiri):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Memeriksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan hal ini, Anda dapat menggunakan properti [isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak terenkripsi.

Contoh kode berikut menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Memeriksa Apakah Presentasi Dilindungi Tulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi tulisan. Untuk melakukan hal ini, Anda dapat menggunakan properti [isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) yang mengembalikan `true` jika presentasi dilindungi tulisan atau `false` jika tidak.

Contoh kode berikut menunjukkan cara memeriksa apakah sebuah presentasi dilindungi tulisan:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validasi atau Konfirmasi Bahwa Kata Sandi Tertentu Telah Digunakan**

Anda mungkin ingin memeriksa dan memastikan bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara untuk memvalidasi kata sandi.

Contoh kode berikut menunjukkan cara memvalidasi sebuah kata sandi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // periksa apakah "pass" cocok dengan
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Metode ini mengembalikan `true` jika presentasi telah dilindungi tulisan dengan kata sandi yang ditentukan. Jika tidak, ia mengembalikan `false`.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/id/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka presentasi?**

Sebuah pengecualian dilemparkan bila kata sandi yang salah digunakan, memberi peringatan bahwa akses ke presentasi ditolak. Hal ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit beban saat operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja tersebut minimal dan tidak secara signifikan mempengaruhi waktu pemrosesan tugas presentasi Anda.