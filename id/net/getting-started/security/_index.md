---
title: Keamanan
type: docs
weight: 160
url: /id/net/security/
keywords:
- keamanan
- ketergantungan
- komponen pihak ketiga
- NuGet
- pemindaian kerentanan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau bagaimana Aspose.Slides for .NET memproses presentasi, paket NuGet apa yang menjadi dependensinya untuk setiap kerangka target, dan komponen pihak ketiga mana yang disertakannya."
---
## **Keamanan di Aspose.Slides**

Aspose menerapkan praktik terbaik saat mengembangkan produknya.

* Aspose.Slides for .NET digunakan untuk memanipulasi presentasi dan mengonversinya ke format lain. Ia tidak menjalankan skrip dalam presentasi. Aspose.Slides mengurai struktur presentasi dan memungkinkan kode pengguna akhir memanipulasi model objek dengan cara yang nyaman.
* Aspose.Slides berfungsi sebagai pustaka yang mengurai dan menafsirkan dokumen tanpa mengeksekusi kode jarak jauh. Semua produk Aspose berjalan di mesin Anda. Mereka tidak mengirim data apa pun ke Aspose. Satu‑satunya pengecualian adalah [metered license](https://purchase.aspose.com/faqs/licensing/metered): jika Anda menggunakannya, hanya informasi penggunaan API Anda yang diproses.
* Komponen Aspose berjalan dalam konteks pengguna yang sama dengan aplikasi biasa. Oleh karena itu, komponen Aspose tidak menimbulkan risiko bagi sumber daya sistem yang penting. Lebih lanjut, ketika sebuah komponen Aspose membuka dokumen, makro tidak dijalankan secara otomatis.
* Risiko yang melekat pada atau terkait dengan paket Microsoft Office tidak berlaku untuk komponen Aspose, sehingga produk Aspose sangat aman.

## **Ketergantungan NuGet**

Aspose.Slides for .NET bergantung pada paket yang dipublikasikan Microsoft di NuGet. Ketergantungan berbeda menurut paket dan kerangka target:

| Paket | Kerangka target | Ketergantungan |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Bagian **Dependencies** pada halaman [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) dan [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) di NuGet mencantumkan versi minimum setiap ketergantungan untuk setiap rilis.

Saat Anda menambahkan Aspose.Slides ke proyek, NuGet juga memulihkan ketergantungan paket‑paket ini. Untuk menampilkan setiap paket yang dipulihkan proyek Anda, termasuk ketergantungan transitif, jalankan perintah berikut di folder proyek:

```bash
dotnet list package --include-transitive
```

Untuk memeriksa kumpulan paket yang sama terhadap kerentanan yang diketahui, jalankan:

```bash
dotnet list package --vulnerable --include-transitive
```

Untuk cara lain mengaudit paket NuGet, lihat [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Komponen Pihak Ketiga**

Aspose.Slides menyertakan kode dari komponen open‑source pihak ketiga. Mereka merupakan bagian dari produk, bukan paket NuGet terpisah, sehingga alat yang hanya membaca ketergantungan NuGet tidak menampilkannya. Kedua paket berisi file *thirdpartylicenses.Aspose.Slides.for.NET.pdf* yang mencantumkan komponen dan lisensinya:

| Komponen | Lisensi yang tercantum dalam pemberitahuan |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Sistem apa yang digunakan untuk memantau kerentanan dalam kode Aspose?**

Kami menjalankan analisis kode statis untuk setiap rilis Aspose.Slides. Kami dapat menyediakan laporan keamanan yang membuktikan kode Aspose.Slides memenuhi OWASP Top 10.

**Apakah Aspose.Slides menggunakan paket eksternal?**

Ya. Ia bergantung pada paket NuGet Microsoft yang tercantum dalam [Ketergantungan NuGet](#ketergantungan-nuget), dan menyertakan komponen pihak ketiga yang tercantum dalam [Komponen Pihak Ketiga](#komponen-pihak-ketiga). Sertakan keduanya dalam tinjauan keamanan Anda, dan gunakan `dotnet list package --vulnerable --include-transitive` untuk memeriksa paket NuGet yang dipulihkan proyek Anda.