---
title: Amankan Presentasi dengan Kata Sandi di .NET
linktitle: Proteksi Kata Sandi
type: docs
weight: 20
url: /id/net/password-protected-presentation/
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
- proteksi penulisan
- keamanan PowerPoint
- keamanan presentasi
- hapus kata sandi
- hapus proteksi
- hapus enkripsi
- nonaktifkan kata sandi
- nonaktifkan proteksi
- hapus proteksi penulisan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint serta OpenDocument yang dilindungi kata sandi menggunakan Aspose.Slides untuk .NET. Amankan presentasi Anda."
---
## **Pengantar**

Saat Anda melindungi presentasi dengan kata sandi, itu berarti Anda menetapkan kata sandi yang memberlakukan batasan tertentu pada presentasi. Untuk menghapus batasan ini, kata sandi harus dimasukkan. Presentasi yang dilindungi kata sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan kata sandi untuk memberlakukan batasan ini pada sebuah presentasi:

- **Modifikasi**

Jika Anda hanya ingin pengguna tertentu dapat memodifikasi presentasi Anda, Anda dapat menetapkan batasan modifikasi. Batasan ini mencegah orang memodifikasi, mengubah, atau menyalin elemen dalam presentasi Anda kecuali mereka memberikan kata sandi.  

Namun, bahkan tanpa kata sandi, pengguna tetap dapat mengakses dan membuka dokumen Anda. Dalam mode hanya-baca ini, pengguna dapat melihat konten—termasuk tautan hiperteks, animasi, efek, dan elemen lainnya—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

Jika Anda hanya ingin pengguna tertentu dapat membuka presentasi Anda, Anda dapat menetapkan batasan pembukaan. Batasan ini mencegah orang bahkan melihat isi presentasi Anda kecuali mereka memberikan kata sandi.  

Secara teknis, batasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda—jika orang tidak dapat membuka sebuah presentasi, mereka tidak dapat memodifikasi atau membuat perubahan pada presentasi tersebut.

**Catatan:** Saat Anda melindungi presentasi dengan kata sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Proteksi Kata Sandi di Aspose.Slides**

**Format yang Didukung**

Aspose.Slides mendukung proteksi kata sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT – Presentasi Microsoft PowerPoint
- ODP – Presentasi OpenDocument
- OTP – Templat Presentasi OpenDocument

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan proteksi kata sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi sebuah presentasi
- Menetapkan proteksi penulisan pada sebuah presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas tambahan yang melibatkan proteksi kata sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan proteksi kata sandi
- Menghapus proteksi penulisan dari sebuah presentasi
- Mengambil properti sebuah presentasi yang terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi kata sandi sebelum memuatnya
- Memeriksa apakah sebuah presentasi terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi kata sandi

## **Lindungi Presentasi dengan Kata Sandi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan kata sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memberikan kata sandi.

Untuk mengenkripsi (atau melindungi kata sandi) sebuah presentasi, gunakan metode `Encrypt` dari [ProtectionManager](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager) untuk menetapkan kata sandi. Kirimkan kata sandi ke metode `Encrypt`, kemudian gunakan metode `Save` untuk menyimpan presentasi yang kini terenkripsi.

Kode contoh ini menunjukkan cara mengenkripsi sebuah presentasi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Tetapkan Proteksi Penulisan pada Presentasi**

Anda dapat menambahkan tanda dengan tulisan "Do not modify" pada sebuah presentasi. Ini memberi tahu pengguna bahwa Anda tidak menginginkan mereka mengubah presentasi.

**Catatan:** Proses proteksi penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memilih—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus menyimpannya dengan nama yang berbeda.

Untuk menetapkan proteksi penulisan, gunakan metode `SetWriteProtection`. Kode contoh ini menunjukkan cara menetapkan proteksi penulisan pada sebuah presentasi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Muat Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat presentasi yang terenkripsi dengan memberikan kata sandi yang tepat. Kode contoh ini menunjukkan cara memuat presentasi yang terenkripsi:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Bekerja dengan presentasi yang didekripsi.
}
```

## **Hapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau proteksi kata sandi dari sebuah presentasi, sehingga pengguna dapat mengakses atau memodifikasinya tanpa batasan.

Untuk menghapus enkripsi atau proteksi kata sandi, panggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/methods/removeencryption). Kode contoh ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Hapus Proteksi Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus proteksi penulisan dari file presentasi. Dengan cara ini, pengguna dapat memodifikasinya sesuka hati—dan mereka tidak akan menerima peringatan apa pun saat melakukan tugas tersebut.

Anda dapat menghapus proteksi penulisan dengan menggunakan metode [RemoveWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/methods/removewriteprotection). Kode contoh ini menunjukkan cara menghapus proteksi penulisan dari sebuah presentasi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Dapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi kata sandi. Namun, Aspose.Slides menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan kata sandi sekaligus tetap memberikan kemampuan bagi pengguna untuk mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi kata sandi. Jika Anda perlu membuat properti dokumen dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukannya.

Jika Anda ingin pengguna tetap dapat mengakses properti presentasi yang terenkripsi, setel properti `EncryptDocumentProperties` dari [IProtectionManager](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/) ke `false`. Kode contoh ini menunjukkan cara mengenkripsi presentasi sambil tetap memberikan akses pengguna ke properti dokumennya:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata sebuah presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) dan setel [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ke `true`. Dalam mode ini, Aspose.Slides mengabaikan kata sandi dan hanya memuat properti dokumen yang dapat diakses secara publik.

Contoh kode berikut membaca properti dokumen bawaan dan kustom melalui [IPresentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Baca properti dokumen bawaan.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Baca properti dokumen kustom.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, menyetel `OnlyLoadDocumentProperties` ke `true` menyebabkan pengecualian karena kata sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat seluruh presentasi, termasuk slide dan konten lainnya, berikan nilai `Password` yang tepat dalam [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/).

## **Periksa Apakah Presentasi Dilindungi Kata Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa apakah presentasi tersebut tidak dilindungi kata sandi. Hal ini membantu menghindari kesalahan dan masalah serupa yang terjadi ketika presentasi yang dilindungi kata sandi dimuat tanpa kata sandi yang tepat.

Kode C# ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi kata sandi tanpa benar-benar memuatnya:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Periksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan tugas ini, Anda dapat menggunakan properti [IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/properties/isencrypted), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan tugas ini, Anda dapat menggunakan properti [IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/properties/iswriteprotected), yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifikasi Penggunaan Kata Sandi Presentasi**

Anda mungkin ingin memeriksa dan mengonfirmasi bahwa kata sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi kata sandi.

Kode contoh ini menunjukkan cara memvalidasi kata sandi:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Periksa apakah kata sandi cocok.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Metode ini mengembalikan `true` jika presentasi telah dienkripsi dengan kata sandi yang ditentukan; sebaliknya, mengembalikan `false`.

{{% alert color="info" title="Lihat juga" %}} 
- [Tanda Tangan Digital di PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 
1. Klik **Drop atau unggah file Anda**. 
1. Pilih file yang ingin Anda lindungi dengan kata sandi di komputer Anda. 
1. Masukkan kata sandi pilihan Anda untuk perlindungan edit dan kata sandi pilihan Anda untuk perlindungan tampilan.
1. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.
1. Klik **PROTECT NOW.** 
1. Klik **DOWNLOAD NOW.**

![Lindungi kata sandi presentasi PowerPoint](slides-lock.png)

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika kata sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Pengecualian akan dilemparkan jika kata sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada dampak kinerja saat bekerja dengan presentasi yang dilindungi kata sandi?**

Proses enkripsi dan dekripsi dapat menambah sedikit beban selama operasi membuka dan menyimpan. Dalam sebagian besar kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi waktu pemrosesan keseluruhan tugas presentasi Anda.