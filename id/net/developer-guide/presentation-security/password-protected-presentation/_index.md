---
title: "Lindungi Presentasi dengan Kata Sandi di .NET"
linktitle: "Perlindungan Kata Sandi"
type: docs
weight: 20
url: /id/net/password-protected-presentation/
keywords:
- presentasi dilindungi kata sandi
- kata sandi pembuka
- enkripsi PowerPoint
- dekripsi PowerPoint
- validasi kata sandi presentasi
- periksa kata sandi presentasi
- buka presentasi terenkripsi
- hapus enkripsi
- PowerPoint
- PPT
- PPTX
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Enkripsi, deteksi, validasi, buka, dan dekripsi presentasi PowerPoint PPT dan PPTX yang dilindungi kata sandi dalam C# dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Kata sandi pembuka mengenkripsi presentasi. Kata sandi yang benar diperlukan untuk memuat dan melihat konten presentasi, sehingga perlindungan ini memberikan kerahasiaan.

Kata sandi pembuka berbeda dari kata sandi perlindungan penulisan. Perlindungan penulisan membatasi modifikasi tetapi tidak mengenkripsi konten atau mencegah presentasi dimuat. Untuk mengelola kata sandi yang digunakan untuk memodifikasi presentasi, lihat [Lindungi Presentasi dengan Proteksi Penulisan](/slides/id/net/write-protected-presentation/).

Alur kerja di bawah ini berlaku untuk presentasi PPT dan PPTX. Contoh menggunakan kedua format ketika perilaku berbasis berkas dan berbasis aliran penting.

## **Enkripsi Presentasi dengan Kata Sandi Pembuka**

Gunakan [IProtectionManager.Encrypt](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/encrypt/) untuk menetapkan kata sandi pembuka. Kemudian gunakan [IPresentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/) untuk menyimpan presentasi yang telah dienkripsi.

Contoh berikut mengenkripsi presentasi PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Biarkan Properti Dokumen Publik**

Secara default, Aspose.Slides menyertakan properti dokumen dalam enkripsi presentasi. Properti [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) mengendalikan perilaku ini secara terpisah dari enkripsi konten slide. Atur menjadi `false` sebelum memanggil [IProtectionManager.Encrypt](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/encrypt/) ketika sistem pengindeksan, klasifikasi, pencarian, atau manajemen dokumen harus membaca metadata tanpa kata sandi pembuka.

Contoh berikut membuat presentasi PPTX terenkripsi sambil membiarkan properti dokumen bawaan tetap publik:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Mengatur `EncryptDocumentProperties` ke `false` tidak membuat slide, master, tata letak, bentuk, media, atau konten presentasi lainnya menjadi publik. Itu hanya memengaruhi properti dokumen. Untuk membaca properti tersebut tanpa memuat konten terenkripsi, lihat [Kelola Properti Presentasi](/slides/id/net/presentation-properties/).

## **Muat Presentasi yang Terenkripsi**

Tetapkan [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/) ke kata sandi pembuka dan serahkan opsi tersebut ke [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) saat memuat berkas. Memuat akan gagal ketika kata sandi pembuka diperlukan tetapi kata sandi yang diberikan tidak ada atau salah.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Bekerja dengan presentasi yang didekripsi.
```

## **Hapus Enkripsi dari Presentasi**

Muat presentasi dengan kata sandi pembukanya, panggil [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/removeencryption/), dan simpan hasilnya. Presentasi yang disimpan kemudian dapat dimuat tanpa kata sandi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validasi Kata Sandi Pembuka Sebelum Memuat**

Gunakan [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memperoleh [IPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/) tanpa membuat instansi presentasi lengkap. Periksa [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/ispasswordprotected/) sebelum meminta atau memvalidasi kata sandi. Jika perlindungan ada, validasi nilai yang diberikan dengan [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Alur Kerja Jalur Berkas**

Contoh berikut memvalidasi kata sandi pembuka untuk berkas PPTX, meneruskan nilai yang tervalidasi ke [LoadOptions.Password](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/password/), dan kemudian memuat presentasi lengkap:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Alur Kerja Stream**

Beban berlebih stream dari [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationfactory/getpresentationinfo/) menyediakan alur kerja yang sama. Reset posisi stream yang dapat di‑seek sebelum memuat presentasi lengkap dari stream tersebut.

Contoh berikut menggunakan berkas PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Nilai Kembali CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationinfo/checkpassword/) mengembalikan `true` hanya ketika presentasi memiliki kata sandi pembuka dan kata sandi yang diberikan benar. Ia mengembalikan `false` dalam setiap kasus berikut:

- Kata sandi salah.
- Presentasi tidak memiliki kata sandi pembuka.
- Kata sandi yang diberikan `null` atau kosong.

Perilaku ini sama untuk presentasi PPT dan PPTX.

## **Periksa Apakah Presentasi yang Dimuat Terenkripsi**

Setelah memuat presentasi dengan kata sandi yang benar, periksa [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/id/net/aspose.slides/iprotectionmanager/isencrypted/) untuk memastikan bahwa sumber presentasi memang terenkripsi. Untuk mendeteksi perlindungan kata sandi pembuka sebelum memuat, gunakan `IPresentationInfo.IsPasswordProtected` seperti yang ditunjukkan di atas.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Rekomendasi Keamanan**

{{% alert color="warning" title="Keamanan" %}}
Jangan mencatat kata sandi pembuka atau menyertakannya dalam pesan diagnostik. Hindari upaya validasi berulang yang tidak diperlukan, simpan kata sandi di memori hanya selama diperlukan, dan gunakan kembali hasil validasi yang berhasil ketika langsung memuat presentasi.

Properti dokumen publik dapat mengungkapkan nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai khusus meskipun konten presentasi telah dienkripsi. Enkripsi metadata sensitif bersama dengan presentasi. Membiarkan properti publik harus menjadi keputusan eksplisit yang dibuat hanya ketika sistem harus mengindeks, mengklasifikasi, mencari, atau mengelola berkas tanpa kata sandi pembuka.
{{% /alert %}}

## **Lindungi Presentasi dengan Kata Sandi Secara Online**

1. Buka aplikasi [Aspose.Slides Lock](https://products.aspose.app/slides/id/lock).
1. Pilih atau unggah presentasi.
1. Masukkan kata sandi untuk perlindungan tampilan.
1. Secara opsional masukkan kata sandi terpisah untuk perlindungan penyuntingan.
1. Terapkan perlindungan dan unduh berkas hasilnya.

{{% alert color="info" title="Lihat juga" %}}
- [Lindungi Presentasi dengan Proteksi Penulisan](/slides/id/net/write-protected-presentation/)
- [Tanda Tangan Digital di PowerPoint](/slides/id/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Tanya Jawab**

**Apa perbedaan antara kata sandi pembuka dan kata sandi perlindungan penulisan?**

Kata sandi pembuka mengenkripsi presentasi dan diperlukan untuk memuat kontennya. Kata sandi perlindungan penulisan membatasi modifikasi tanpa mengenkripsi konten.

**Bisakah saya memvalidasi kata sandi pembuka tanpa memuat semua slide?**

Ya. Dapatkan informasi presentasi, periksa apakah perlindungan kata sandi pembuka ada, dan validasi kata sandi sebelum membuat instansi presentasi lengkap.

**Apakah aplikasi dapat membaca metadata tanpa kata sandi pembuka?**

Ya, tetapi hanya ketika presentasi dienkripsi dengan `EncryptDocumentProperties` disetel ke `false`. Aplikasi harus menggunakan mode pemuatan hanya properti dokumen yang dijelaskan di [Kelola Properti Presentasi](/slides/id/net/presentation-properties/).

**Apakah alur kerja pemeriksaan kata sandi mendukung PPT dan PPTX?**

Ya. Deteksi dan validasi kata sandi berbasis jalur berkas maupun stream berperilaku sama untuk presentasi PPT dan PPTX.