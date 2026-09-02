---
title: Amankan Presentasi dengan Sandi di .NET
linktitle: Proteksi Sandi
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
- atur sandi
- tambahkan sandi
- enkripsi PowerPoint
- enkripsi presentasi
- dekripsi PowerPoint
- dekripsi presentasi
- proteksi penulisan
- keamanan PowerPoint
- keamanan presentasi
- hapus sandi
- hapus proteksi
- hapus enkripsi
- nonaktifkan sandi
- nonaktifkan proteksi
- hapus proteksi penulisan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara dengan mudah mengunci dan membuka kunci presentasi PowerPoint dan OpenDocument yang dilindungi sandi dengan Aspose.Slides untuk .NET. Amankan presentasi Anda."
---
## **Pendahuluan**

Ketika Anda melindungi presentasi dengan sandi, itu berarti Anda menetapkan sandi yang memberlakukan pembatasan tertentu pada presentasi. Untuk menghapus pembatasan ini, sandi harus dimasukkan. Presentasi yang dilindungi sandi dianggap sebagai presentasi terkunci.

Biasanya, Anda dapat menetapkan sandi untuk memberlakukan pembatasan ini pada sebuah presentasi:

- **Modifikasi**

Jika Anda hanya ingin pengguna tertentu dapat memodifikasi presentasi Anda, Anda dapat menetapkan pembatasan modifikasi. Pembatasan ini mencegah orang memodifikasi, mengubah, atau menyalin elemen dalam presentasi Anda kecuali mereka memberikan sandi. 

Namun, bahkan tanpa sandi, pengguna masih dapat mengakses dan membuka dokumen Anda. Dalam mode hanya-baca ini, pengguna dapat melihat konten—termasuk tautan, animasi, efek, dan elemen lainnya—di dalam presentasi Anda, tetapi mereka tidak dapat menyalin item atau menyimpan presentasi.

- **Pembukaan**

Jika Anda hanya ingin pengguna tertentu dapat membuka presentasi Anda, Anda dapat menetapkan pembatasan pembukaan. Pembatasan ini mencegah orang bahkan melihat isi presentasi Anda kecuali mereka memberikan sandi.

Secara teknis, pembatasan pembukaan juga mencegah pengguna memodifikasi presentasi Anda—jika orang tidak dapat membuka presentasi, mereka tidak dapat memodifikasi atau membuat perubahan pada presentasi tersebut.

**Catatan:** Saat Anda melindungi presentasi dengan sandi untuk mencegah pembukaan, file presentasi menjadi terenkripsi.

## **Proteksi Sandi di Aspose.Slides**

**Format yang Didukung**

Aspose.Slides mendukung proteksi sandi, enkripsi, dan operasi serupa untuk presentasi dalam format berikut:

- PPTX dan PPT – Presentasi Microsoft PowerPoint
- ODP – Presentasi OpenDocument
- OTP – Templat Presentasi OpenDocument

**Operasi yang Didukung**

Aspose.Slides memungkinkan Anda menggunakan proteksi sandi pada presentasi untuk mencegah modifikasi dengan cara berikut:

- Mengenkripsi sebuah presentasi
- Menetapkan proteksi penulisan pada sebuah presentasi

**Operasi Lainnya**

Aspose.Slides memungkinkan Anda melakukan tugas tambahan yang melibatkan proteksi sandi dan enkripsi dengan cara berikut:

- Mendekripsi sebuah presentasi; membuka presentasi yang terenkripsi
- Menghapus enkripsi; menonaktifkan proteksi sandi
- Menghapus proteksi penulisan dari sebuah presentasi
- Mengambil properti sebuah presentasi yang terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi sandi sebelum memuatnya
- Memeriksa apakah sebuah presentasi terenkripsi
- Memeriksa apakah sebuah presentasi dilindungi sandi

## **Lindungi Presentasi dengan Sandi**

Anda dapat mengenkripsi sebuah presentasi dengan menetapkan sandi. Kemudian, untuk memodifikasi presentasi yang terkunci, pengguna harus memberikan sandi.

Untuk mengenkripsi (atau melindungi dengan sandi) sebuah presentasi, gunakan metode `Encrypt` dari [ProtectionManager](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager) untuk menetapkan sandi. Berikan sandi ke metode `Encrypt`, kemudian gunakan metode `Save` untuk menyimpan presentasi yang kini terenkripsi.

Kode contoh ini menunjukkan cara mengenkripsi sebuah presentasi:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Tetapkan Proteksi Penulisan pada Presentasi** 

Anda dapat menambahkan tanda yang menyatakan "Jangan ubah" pada sebuah presentasi. Ini memberi tahu pengguna bahwa Anda tidak ingin mereka mengubah presentasi.

**Catatan:** Proses proteksi penulisan tidak mengenkripsi presentasi. Oleh karena itu, pengguna—jika mereka memilih—dapat memodifikasi presentasi, tetapi untuk menyimpan perubahan, mereka harus menyimpannya dengan nama yang berbeda.

Untuk menetapkan proteksi penulisan, gunakan metode `SetWriteProtection`. Kode contoh ini menunjukkan cara menetapkan proteksi penulisan pada sebuah presentasi:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Muat Presentasi yang Terenkripsi**

Aspose.Slides memungkinkan Anda memuat sebuah presentasi yang terenkripsi dengan memberikan sandi yang benar. Kode contoh ini menunjukkan cara memuat presentasi yang terenkripsi:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Bekerja dengan presentasi yang telah didekripsi.
}
```

## **Hapus Enkripsi dari Presentasi**

Anda dapat menghapus enkripsi atau proteksi sandi dari sebuah presentasi, memungkinkan pengguna mengakses atau memodifikasinya tanpa pembatasan.

Untuk menghapus enkripsi atau proteksi sandi, panggil metode [RemoveEncryption](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/methods/removeencryption). Kode contoh ini menunjukkan cara menghapus enkripsi dari sebuah presentasi:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Hapus Proteksi Penulisan dari Presentasi**

Anda dapat menggunakan Aspose.Slides untuk menghapus proteksi penulisan dari file presentasi. Dengan cara ini, pengguna dapat memodifikasinya sesuka mereka—dan mereka tidak akan menerima peringatan apa pun saat melakukan tugas tersebut.

Anda dapat menghapus proteksi penulisan dengan menggunakan metode [RemoveWriteProtection](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/methods/removewriteprotection). Kode contoh ini menunjukkan cara menghapus proteksi penulisan dari sebuah presentasi:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Dapatkan Properti Presentasi yang Terenkripsi**

Biasanya, pengguna kesulitan mengambil properti dokumen dari presentasi yang terenkripsi atau dilindungi sandi. Namun, Aspose.Slides menawarkan mekanisme yang memungkinkan Anda melindungi presentasi dengan sandi sekaligus tetap memungkinkan pengguna mengakses propertinya.

**Catatan:** Secara default, ketika Aspose.Slides mengenkripsi sebuah presentasi, properti dokumen presentasi juga dilindungi sandi. Jika Anda perlu membuat properti dokumen tetap dapat diakses bahkan setelah enkripsi, Aspose.Slides memungkinkan Anda melakukannya.

Jika Anda ingin pengguna tetap dapat mengakses properti sebuah presentasi yang terenkripsi, atur properti `EncryptDocumentProperties` dari [IProtectionManager](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/) ke `false`. Kode contoh ini menunjukkan cara mengenkripsi sebuah presentasi sekaligus tetap memberikan pengguna akses ke properti dokumennya:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Muat Hanya Properti Dokumen dari Presentasi yang Terenkripsi**

Untuk memeriksa metadata sebuah presentasi yang terenkripsi tanpa memuat slide atau konten lainnya, buat objek [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) dan atur [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ke `true`. Dalam mode ini, Aspose.Slides mengabaikan sandi dan hanya memuat properti dokumen yang dapat diakses publik.

Contoh kode berikut membaca properti dokumen bawaan dan kustom melalui [IPresentation.DocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Alur kerja ini hanya berfungsi ketika properti dokumen dibiarkan tidak terenkripsi (publik) saat presentasi dienkripsi. Jika properti dokumen terenkripsi, mengatur `OnlyLoadDocumentProperties` ke `true` menyebabkan pengecualian karena sandi diabaikan dalam mode ini. Untuk mengakses properti dokumen yang terenkripsi atau memuat presentasi lengkap, termasuk slide dan konten lainnya, berikan nilai `Password` yang benar dalam [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/).

## **Periksa Apakah Presentasi Dilindungi Sandi**

Sebelum Anda memuat sebuah presentasi, Anda mungkin ingin memeriksa apakah presentasi tersebut belum dilindungi sandi. Ini membantu Anda menghindari kesalahan dan masalah serupa yang terjadi ketika presentasi yang dilindungi sandi dimuat tanpa sandi yang benar.

Kode C# ini menunjukkan cara memeriksa sebuah presentasi untuk melihat apakah ia dilindungi sandi tanpa benar-benar memuatnya:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Periksa Apakah Presentasi Terenkripsi**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi terenkripsi. Untuk melakukan ini, Anda dapat menggunakan properti [IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/properties/isencrypted), yang mengembalikan `true` jika presentasi terenkripsi atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi terenkripsi:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Periksa Apakah Presentasi Dilindungi Penulisan**

Aspose.Slides memungkinkan Anda memeriksa apakah sebuah presentasi dilindungi penulisan. Untuk melakukan ini, Anda dapat menggunakan properti [IsWriteProtected](https://reference.aspose.com/slides/id/net/aspose.slides/protectionmanager/properties/iswriteprotected), yang mengembalikan `true` jika presentasi dilindungi penulisan atau `false` jika tidak.

Kode contoh ini menunjukkan cara memeriksa apakah sebuah presentasi dilindungi penulisan:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifikasi Penggunaan Sandi pada Presentasi**

Anda mungkin ingin memeriksa dan memastikan bahwa sandi tertentu telah digunakan untuk melindungi dokumen presentasi. Aspose.Slides menyediakan cara bagi Anda untuk memvalidasi sandi.

Kode contoh ini menunjukkan cara memvalidasi sandi:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Periksa apakah sandi cocok.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Ia mengembalikan `true` jika presentasi telah dienkripsi dengan sandi yang ditentukan; jika tidak, ia mengembalikan `false`.

{{% alert color="primary" title="Lihat juga" %}} 
- [Tanda Tangan Digital di PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Lindungi Presentasi dengan Sandi Secara Online**

1. Buka halaman [**Aspose.Slides Lock**](https://products.aspose.app/slides/id/lock) kami. 
1. Klik **Tarik atau unggah file Anda**.
1. Pilih file yang ingin Anda lindungi dengan sandi di komputer Anda. 
1. Masukkan sandi pilihan Anda untuk proteksi penyuntingan dan sandi pilihan Anda untuk proteksi tampilan.
1. Jika Anda ingin pengguna melihat presentasi Anda sebagai salinan final, centang kotak **Mark as final**.
1. Klik **PROTECT NOW.** 
1. Klik **DOWNLOAD NOW.**

![Lindungi presentasi PowerPoint dengan sandi](slides-lock.png)

## **FAQ**

**Metode enkripsi apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung metode enkripsi modern, termasuk algoritma berbasis AES, yang memastikan tingkat keamanan data yang tinggi untuk presentasi Anda.

**Apa yang terjadi jika sandi yang salah dimasukkan saat mencoba membuka sebuah presentasi?**

Pengecualian akan dilemparkan jika sandi yang salah digunakan, memberi tahu Anda bahwa akses ke presentasi ditolak. Ini membantu mencegah akses tidak sah dan melindungi konten presentasi.

**Apakah ada implikasi kinerja saat bekerja dengan presentasi yang dilindungi sandi?**

Proses enkripsi dan dekripsi dapat menimbulkan sedikit beban tambahan selama operasi membuka dan menyimpan. Dalam kebanyakan kasus, dampak kinerja ini minimal dan tidak secara signifikan memengaruhi keseluruhan waktu pemrosesan tugas presentasi Anda.