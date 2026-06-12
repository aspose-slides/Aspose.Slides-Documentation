---
title: Amankan Presentasi dengan Sandi di Android
linktitle: Proteksi Sandi
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
- atur sandi
- tambahkan sandi
- enkripsi PowerPoint
- enkripsi presentasi
- dekripsi PowerPoint
- dekripsi presentasi
- proteksi tulis
- keamanan PowerPoint
- keamanan presentasi
- hapus sandi
- hapus proteksi
- hapus enkripsi
- nonaktifkan sandi
- nonaktifkan proteksi
- hapus proteksi tulis
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Dengan mudah mengunci dan membuka kunci presentasi PowerPoint serta OpenDocument yang dilindungi sandi menggunakan Aspose.Slides untuk Android melalui Java. Amankan presentasi Anda."
---
## **Pendahuluan**

Ketika Anda melindungi presentasi dengan sandi, itu berarti Anda menetapkan sandi yang memberlakukan beberapa pembatasan pada presentasi. Untuk menghapus pembatasan tersebut, sandi harus dimasukkan. Presentasi yang dilindungi sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan sandi untuk memberlakukan pembatasan ini pada presentasi:

- **Modifikasi**

  Jika Anda ingin hanya pengguna tertentu yang dapat memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang memodifikasi, mengubah, atau menyalin elemen dalam presentasi Anda (kecuali mereka memasukkan sandi).

  Namun, dalam kasus ini, bahkan tanpa sandi, pengguna tetap dapat mengakses dokumen Anda dan membukanya. Dalam mode baca‑saja ini, pengguna dapat melihat isi atau elemen—tautan hiper, animasi, efek, dan lainnya—di dalam presentasi, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

  Jika Anda ingin hanya pengguna tertentu yang dapat membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda (kecuali mereka memasukkan sandi).

  Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda: ketika orang tidak dapat membuka presentasi, mereka tidak dapat melakukan perubahan apa pun pada presentasi tersebut.  

  **Catatan** bahwa ketika Anda melindungi presentasi dengan sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Proteksi Sandi untuk Presentasi di Aspose.Slides**
**Format yang Didukung**

Aspose.Slides mendukung proteksi sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT – Microsoft PowerPoint Presentation  
- ODP – OpenDocument Presentation  
- OTP – OpenDocument Presentation Template  

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan proteksi sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi sebuah presentasi  
- Menetapkan proteksi tulis pada sebuah presentasi  

**Operasi Lain**

Aspose.Slides memungkinkan Anda melakukan tugas lain yang melibatkan proteksi sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi  
- Menghapus enkripsi; menonaktifkan proteksi sandi  
- Menghapus proteksi tulis dari sebuah presentasi  
- Mendapatkan properti sebuah presentasi yang terenkripsi  
- Memeriksa apakah sebuah presentasi terenkripsi  
- Memeriksa apakah sebuah presentasi dilindungi sandi.

## **Enkripsi Presentasi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus menyediakan sandi tersebut.

Untuk mengenkripsi atau melindungi presentasi dengan sandi, Anda harus menggunakan metode `encrypt` (dari [IProtectionManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager)) untuk menetapkan sandi pada presentasi. Anda melewatkan sandi ke metode `encrypt` dan menggunakan metode `save` untuk menyimpan presentasi yang kini terenkripsi.

Contoh kode berikut memperlihatkan cara mengenkripsi sebuah presentasi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Setel Proteksi Tulis pada Presentasi**

Anda dapat menambahkan tanda “Jangan ubah” pada sebuah presentasi. Dengan cara ini, Anda memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.

**Catatan** bahwa proses proteksi tulis tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memang ingin—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus membuat presentasi dengan nama yang berbeda.

Untuk menetapkan proteksi tulis, Anda harus menggunakan metode [setWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Contoh kode berikut memperlihatkan cara menetapkan proteksi tulis pada sebuah presentasi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Muat Presentasi yang Dienkripsi**

Aspose.Slides memungkinkan Anda memuat file terenkripsi dengan memasukkan sandinya. Untuk mendekripsi sebuah presentasi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) tanpa parameter. Selanjutnya Anda harus memasukkan sandi yang benar untuk memuat presentasi tersebut.

Contoh kode berikut memperlihatkan cara mendekripsi sebuah presentasi:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // bekerja dengan presentasi yang didekripsi
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Hapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau proteksi sandi pada sebuah presentasi. Dengan cara ini, pengguna dapat mengakses atau memodifikasi presentasi tanpa pembatasan.

Untuk menghapus enkripsi atau proteksi sandi, Anda harus memanggil metode [removeEncryption](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Contoh kode berikut memperlihatkan cara menghapus enkripsi dari sebuah presentasi:

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

## **Hapus Proteksi Tulis dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus proteksi tulis yang digunakan pada file presentasi. Dengan cara ini, pengguna dapat memodifikasi sesuka hati—tanpa peringatan saat melakukan tugas tersebut.

Anda dapat menghapus proteksi tulis dari sebuah presentasi dengan menggunakan metode [removeWriteProtection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--). Contoh kode berikut memperlihatkan cara menghapus proteksi tulis dari sebuah presentasi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Dapatkan Properti Presentasi yang Dienkripsi**

Biasanya, pengguna kesulitan untuk mendapatkan properti dokumen dari presentasi yang dienkripsi atau dilindungi sandi. Aspose.Slides, bagaimanapun, menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan sandi sambil tetap memberikan cara bagi pengguna untuk mengakses properti presentasi tersebut.

**Catatan** bahwa ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi secara default juga dilindungi sandi. Namun jika Anda perlu membuat properti presentasi dapat diakses (bahkan setelah presentasi dienkripsi), Aspose.Slides memungkinkan Anda melakukan hal tersebut.

Jika Anda ingin pengguna tetap dapat mengakses properti sebuah presentasi yang Anda enkripsi, Anda dapat mengatur properti [encryptDocumentProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) menjadi `true`. Contoh kode berikut memperlihatkan cara mengenkripsi sebuah presentasi sambil menyediakan cara bagi pengguna untuk mengakses properti dokumennya:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Periksa Apakah Presentasi Dilindungi Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa dan memastikan bahwa presentasi tersebut belum dilindungi dengan sandi. Dengan cara ini, Anda dapat menghindari kesalahan dan masalah serupa yang muncul ketika presentasi yang dilindungi sandi dimuat tanpa sandinya.

Kode Java berikut memperlihatkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi sandi (tanpa memuat presentasi itu sendiri):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Periksa Apakah Presentasi Dienkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dienkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan properti [isEncrypted](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), yang mengembalikan `true` jika presentasi dienkripsi atau `false` jika tidak dienkripsi.

Contoh kode berikut memperlihatkan cara memeriksa apakah sebuah presentasi dienkripsi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan properti [isWriteProtected](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Contoh kode berikut memperlihatkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validasi atau Konfirmasi Bahwa Sandi Tertentu Telah Digunakan**

Anda mungkin ingin memeriksa dan memastikan bahwa sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi sebuah sandi.

Contoh kode berikut memperlihatkan cara memvalidasi sebuah sandi:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // periksa apakah "pass" cocok dengan
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan sandi yang ditentukan. Jika tidak, mengembalikan `false`.

{{% alert color="primary" title="Lihat juga" %}} 
- [Digital Signature in PowerPoint](/slides/id/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Sebuah pengecualian akan dilempar jika sandi yang salah digunakan, memberi peringatan bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak pada performa saat bekerja dengan presentasi yang dilindungi sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit overhead selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak performa ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi Anda.