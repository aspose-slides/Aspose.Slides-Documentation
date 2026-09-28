---
title: Persyaratan Tingkat Kepercayaan
type: docs
weight: 190
url: /id/net/declaration/
keywords:
- tingkat kepercayaan
- izin Kepercayaan Penuh
- kepercayaan parsial
- Medium Trust
- keamanan akses kode
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Level kepercayaan keamanan akses kode yang dibutuhkan Aspose.Slides untuk .NET: kepercayaan penuh pada .NET Framework, dan tidak ada pengaturan kepercayaan pada .NET 6 dan versi lebih baru."
---
## **Gambaran Umum**

Level kepercayaan Code Access Security (CAS) hanya ada di .NET Framework. Artikel ini menjelaskan apa artinya bagi Aspose.Slides untuk .NET: perpustakaan memerlukan kepercayaan penuh pada .NET Framework, dan pada .NET 6 dan yang lebih baru tidak ada level kepercayaan yang dapat dikonfigurasi.

## **.NET Framework**

Aspose.Slides memerlukan kepercayaan penuh pada .NET Framework. Ia tidak berjalan di bawah kepercayaan parsial, seperti aplikasi ASP.NET yang dikonfigurasi untuk Medium Trust (`<trust level="Medium" />`): pembuatan objek [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) gagal dengan `SecurityException`.

Microsoft tidak lagi memperlakukan ASP.NET partial trust sebagai cara untuk mengisolasi aplikasi satu sama lain, dan menyarankan menjalankan aplikasi dalam kumpulan aplikasi terpisah. Lihat [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Code Access Security tidak tersedia pada .NET 6 dan yang lebih baru, sehingga tidak ada level kepercayaan yang dapat diberikan. Aspose.Slides berjalan dengan izin akun yang menjalankan aplikasi Anda. Untuk membatasi apa yang dapat diakses oleh sebuah aplikasi, Microsoft menyarankan batasan sistem operasi, seperti akun pengguna, kontainer, atau mesin virtual. Lihat [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Apakah saya dapat menggunakan Aspose.Slides dengan penyedia hosting yang menjalankan aplikasi ASP.NET dalam Medium Trust?**

Tidak dalam Medium Trust. Pada .NET Framework, aplikasi yang menggunakan Aspose.Slides harus berjalan dengan kepercayaan penuh.