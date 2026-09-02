---
title: Menambahkan Tanda Tangan Digital ke Presentasi di .NET
linktitle: Tanda Tangan Digital
type: docs
weight: 10
url: /id/net/digital-signature-in-powerpoint/
keywords:
- tanda tangan digital
- sertifikat digital
- otoritas sertifikat
- sertifikat PFX
- PKCS#12
- memvalidasi tanda tangan
- PowerPoint
- PPTX
- keamanan presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menandatangani presentasi PPTX yang ada dengan sertifikat PFX dan menggunakan Aspose.Slides untuk .NET untuk memvalidasi atau menghapus tanda tangan digital."
---
## **Gambaran Umum**

Tanda tangan digital membantu penerima menentukan siapa yang menandatangani presentasi dan apakah konten yang ditandatangani telah berubah. Tiga konsep keamanan terkait penting di sini:

- **Sertifikat digital** adalah kredensial elektronik yang mengaitkan identitas dengan kunci publik. Otoritas sertifikat (CA) tepercaya dapat mengeluarkan sertifikat, atau organisasi dapat menggunakan sertifikat yang ditandatangani sendiri untuk alur kerja internal.
- **Tanda tangan digital** dibuat dari konten presentasi dan kunci pribadi pemegang sertifikat. Kunci publik sertifikat kemudian dapat digunakan untuk memverifikasi tanda tangan. Tanda tangan memberikan bukti asal dan integritas; tidak mengenkripsi presentasi.
- **Proteksi kata sandi** mengontrol apakah pengguna dapat membuka atau mengubah sebuah presentasi. Ini terpisah dari penandatanganan digital dan dijelaskan di [Password-Protected Presentations](/net/password-protected-presentation/).

PowerPoint menyediakan perintah **Add a Digital Signature** di bawah **File > Info > Protect Presentation**.

![Menu PowerPoint Protect Presentation dengan Add a Digital Signature disorot](add-digital-signature-in-powerpoint.png)

Setelah presentasi yang ditandatangani dibuka, PowerPoint dapat menampilkan notifikasi status tanda tangan.

![Notifikasi PowerPoint yang menyatakan bahwa presentasi berisi tanda tangan yang valid](digital-signature-status-in-powerpoint.png)

Aspose.Slides mengekspos tanda tangan melalui [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/digitalsignatures/), sebuah [IDigitalSignatureCollection](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignaturecollection/) yang elemennya mengimplementasikan [IDigitalSignature](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignature/). Sebuah presentasi dapat berisi beberapa tanda tangan.

## **Memahami Sertifikat PFX dan Kata Sandi**

File PFX, juga dikenal sebagai file PKCS#12 dan biasanya memiliki ekstensi `.pfx` atau `.p12`, dapat berisi sertifikat X.509, kunci privatnya, dan rantai sertifikat. Kunci privat memungkinkan pemegangnya membuat tanda tangan. Sertifikat tanpa kunci privat yang dapat diakses tidak dapat digunakan untuk menandatangani sebuah presentasi.

Kata sandi PFX melindungi paket sertifikat dan kunci privat. Itu **bukan** kata sandi untuk membuka atau mengedit presentasi. Jangan menyimpan file PFX atau kata sandinya ke kontrol sumber. Dalam produksi, batasi akses ke file sertifikat dan dapatkan kata sandinya dari penyimpanan rahasia atau sumber konfigurasi terlindungi lainnya. Contoh di bawah ini menggunakan variabel lingkungan hanya untuk menghindari menanamkan kata sandi dalam kode.

## **Menambahkan Tanda Tangan Digital ke Presentasi**

Untuk menandatangani alur kerja presentasi yang nyata, muat file PPTX yang ada, buat sebuah [DigitalSignature](https://reference.aspose.com/slides/id/net/aspose.slides/digitalsignature/) dari sertifikat PFX dan kata sandinya, tambahkan tanda tangan ke koleksi presentasi, dan simpan ke file PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Menyimpan hasil dengan nama baru mempertahankan file sumber yang belum ditandatangani. Nilai [DigitalSignature.Comments](https://reference.aspose.com/slides/id/net/aspose.slides/digitalsignature/comments/) menjelaskan tujuan tanda tangan; itu bukan kontrol keamanan.

## **Memvalidasi Tanda Tangan Digital**

Saat Anda memuat file PPTX yang ditandatangani, periksa setiap item dalam [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/digitalsignatures/). Properti [IDigitalSignature.IsValid](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignature/isvalid/) menunjukkan apakah tanda tangan yang tersemat valid untuk konten presentasi saat ini.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Hasil tidak valid biasanya berarti konten presentasi yang ditandatangani atau data tanda tangan berubah setelah penandatanganan, atau file rusak. Menghapus semua tanda tangan menghasilkan presentasi yang tidak ditandatangani, jadi memeriksa hanya validitas item tidak cukup: alur kerja yang sensitif terhadap keamanan harus juga memverifikasi bahwa jumlah tanda tangan yang diharapkan dan identitas penandatangan yang diharapkan ada.

Hasil validitas ini tidak boleh diperlakukan sebagai keputusan kepercayaan sertifikat yang lengkap. Tergantung pada kebijakan keamanan Anda, aplikasi Anda mungkin juga perlu membangun dan memvalidasi rantai sertifikat X.509, memeriksa tanggal berlaku sertifikat dan status pencabutan, mengonfirmasi subjek atau sidik jari yang diharapkan, memverifikasi penggunaan kunci, dan mengevaluasi timestamp yang tepercaya. Nilai [IDigitalSignature.SignTime](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignature/signtime/) sendiri bukan bukti dari otoritas timestamp yang tepercaya.

## **Menghapus Tanda Tangan Digital**

Menghapus tanda tangan mengubah status keamanan presentasi. Contoh berikut memuat file PPTX yang ditandatangani, menghapus semua tanda tangan dengan [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignaturecollection/clear/), dan menyimpan salinan yang tidak ditandatangani.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Untuk menghapus hanya satu tanda tangan, panggil [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides/idigitalsignaturecollection/removeat/) dengan indeks berbasis nol. Simpan ke file baru kecuali menimpa file asli yang ditandatangani merupakan bagian eksplisit dari alur kerja Anda.

## **Pertimbangan Pengeditan dan Format**

- Tanda tangan tidak membuat sebuah presentasi menjadi hanya-baca. Pengguna dan aplikasi masih dapat mengedit file, tetapi perubahan pada konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid.
- Selesaikan semua pengeditan yang dimaksud sebelum menandatangani. Jika sebuah presentasi harus diubah, simpan presentasi yang direvisi dan tanda tangani revisi tersebut kembali.
- Simpan output akhir dalam format PPTX. Mengonversi presentasi yang ditandatangani ke format lain tidak mentransfer tanda tangan PPTX asli sebagai tanda tangan yang valid untuk file yang dikonversi.
- Perlakukan kunci privat sertifikat sebagai data sensitif. Siapa pun yang memperoleh kunci privat dan kata sandinya dapat membuat tanda tangan yang tampak berasal dari pemegang sertifikat tersebut.
- Simpan sumber yang tidak ditandatangani atau salinan terkendali lainnya ketika kebijakan retensi dokumen Anda memerlukannya.

## **FAQ**

**Apakah tanda tangan digital mengenkripsi presentasi?**

Tidak. Tanda tangan digital memberikan bukti tentang asal dan integritas, tetapi konten presentasi tetap dapat dibaca kecuali enkripsi terpisah diterapkan. Gunakan [password protection](/net/password-protected-presentation/) ketika akses ke konten harus dibatasi.

**Apakah kata sandi PFX sama dengan kata sandi presentasi?**

Tidak. Kata sandi PFX membuka kunci privat yang disimpan dalam paket sertifikat. Itu tidak mengontrol siapa yang dapat membuka atau mengedit file PPTX.

**Bisakah saya menggunakan sertifikat yang ditandatangani sendiri?**

Secara teknis, sertifikat yang ditandatangani sendiri dapat digunakan bila mencakup kunci privat yang dapat diakses. Namun penerima tidak akan secara otomatis mempercayainya, kecuali sertifikat tersebut secara eksplisit ditambahkan ke lingkungan tepercaya mereka. Alur kerja publik atau lintas organisasi umumnya menggunakan sertifikat yang diterbitkan oleh CA tepercaya.

**Apa yang membuat sebuah tanda tangan tidak valid?**

Mengubah konten presentasi yang ditandatangani atau data tanda tangan setelah penandatanganan dapat membuat tanda tangan tidak valid. Kerusakan file juga dapat menyebabkan validasi gagal. Jika semua tanda tangan dihapus, presentasi menjadi tidak ditandatangani, bukan file yang berisi tanda tangan tidak valid.

**Apakah tanda tangan yang valid berarti saya harus mempercayai penandatangan?**

Tidak dengan sendirinya. Integritas tanda tangan dan kepercayaan pada penandatangan adalah keputusan terpisah. Kebijakan validasi produksi juga harus memeriksa rantai sertifikat, periode berlaku, status pencabutan, identitas yang diharapkan, penggunaan kunci, dan persyaratan timestamp tepercaya apa pun.

**Apa yang terjadi ketika sertifikat kedaluwarsa?**

Kedaluwarsa sertifikat tidak mengubah byte presentasi, tetapi memengaruhi evaluasi kepercayaan sertifikat. Apakah sebuah tanda tangan masih dapat diterima tergantung pada kebijakan Anda dan apakah timestamp tepercaya yang valid membuktikan bahwa penandatanganan terjadi saat sertifikat masih berlaku. Jangan mengandalkan waktu penandatanganan yang ditampilkan saja sebagai timestamp tepercaya.

**Apakah presentasi yang ditandatangani masih dapat diedit?**

Ya. Penandatanganan tidak mengunci file. Mengedit konten yang ditandatangani biasanya membuat tanda tangan yang ada menjadi tidak valid, jadi selesaikan presentasi terlebih dahulu dan tanda tangani revisi akhir.

**Apakah sebuah presentasi dapat berisi lebih dari satu tanda tangan?**

Ya. Tambahkan setiap tanda tangan ke [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/digitalsignatures/) sebelum menyimpan. Selama validasi, periksa setiap tanda tangan dan konfirmasi bahwa semua penandatangan yang diperlukan hadir.

**Format presentasi apa yang mendukung operasi ini?**

Aspose.Slides mendukung operasi tanda tangan digital yang dijelaskan di sini hanya untuk PPTX. Format presentasi PPT dan OpenDocument tidak didukung oleh alur kerja API ini.

**Apakah saya dapat menghapus tanda tangan tanpa memengaruhi slide?**

Ya. Anda dapat menghapus satu tanda tangan atau membersihkan seluruh koleksi lalu menyimpan presentasi. Konten slide tetap tersedia, tetapi file yang disimpan tidak lagi membawa bukti tanda tangan yang dihapus.