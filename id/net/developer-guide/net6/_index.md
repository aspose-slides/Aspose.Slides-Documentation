---
title: Paket Lintas Platform untuk .NET 6 dan Versi Selanjutnya
linktitle: Paket Lintas Platform
type: docs
weight: 235
url: /id/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- lintas platform
- dukungan .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Pelajari kapan harus menggunakan paket Aspose.Slides.NET6.CrossPlatform: mengapa paket ini ada, platform yang didukung, dan apa yang dibutuhkannya di Linux sebagai pengganti libgdiplus."
---
## **Pendahuluan**

Aspose.Slides untuk .NET dipublikasikan sebagai dua paket NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) menghasilkan slide melalui pustaka System.Drawing.Common milik Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) menghasilkan slide dengan mesin grafis miliknya sendiri. Artikel ini menjelaskan mengapa paket kedua ada, di mana ia berjalan, apa yang dibutuhkannya di Linux, dan bagaimana ia berdampingan dengan System.Drawing.Common dalam satu proyek.

## **Mengapa Paket Terpisah**

Mulai dengan .NET 6, Microsoft mendukung System.Drawing.Common [hanya di Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Akibatnya, di Linux Aspose.Slides.NET memerlukan saklar `System.Drawing.EnableUnixSupport` selain pustaka `libgdiplus`, dan akan gagal jika proyek merujuk System.Drawing.Common 7 atau yang lebih baru. [System Requirements](/slides/id/net/system-requirements/) menjelaskan kondisi ini.

Aspose.Slides.NET6.CrossPlatform tidak menggunakan System.Drawing.Common atau `libgdiplus`. Mesin grafisnya adalah pustaka native yang disertakan paket dalam satu build per platform yang didukung. Kedua paket menyediakan namespace dan kelas Aspose.Slides yang sama, sehingga beralih dari satu ke yang lain hanya mengubah referensi paket, bukan kode Anda.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafik | System.Drawing.Common | Mesin grafis native yang disertakan dalam paket |
| Framework target | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Persyaratan Linux | `libgdiplus` dan saklar `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Supported | Not supported |

## **Platform yang Didukung**

Aspose.Slides.NET6.CrossPlatform bekerja dengan .NET 6 dan versi selanjutnya pada platform berikut:

- **Windows**: x86 dan x64. Pustaka native menggunakan runtime Microsoft Visual C++; lihat [System Requirements](/slides/id/net/system-requirements/).
- **Linux**: x64 dengan glibc 2.23 atau lebih baru, dan ARM64 dengan glibc 2.39 atau lebih baru.
- **macOS**: x64 (Intel) dan ARM64 (Apple silicon).

Tidak berjalan pada Windows ARM64, pada Alpine Linux atau distribusi lain yang dibangun di atas musl bukan glibc, atau pada distribusi dengan glibc yang lebih lama, seperti CentOS 7. Gunakan Aspose.Slides.NET pada sistem tersebut.

## **Instal di Linux**

Di Linux, paket memerlukan pustaka `fontconfig`, tetapi tidak memerlukan `libgdiplus`. Pada Debian dan Ubuntu, instal `fontconfig` lalu tambahkan paket ke proyek Anda:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Pada Debian dan Ubuntu, `libfontconfig1` juga menginstal font DejaVu, sehingga teks ditampilkan tanpa paket font tambahan. Tanpa `fontconfig`, membuat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) gagal dengan `TypeInitializationException` yang inner `DllNotFoundException` melaporkan bahwa `libfontconfig.so.1` tidak dapat dibuka. [System Requirements](/slides/id/net/system-requirements/) menyertakan program singkat yang memeriksa pengaturan.

## **Host Cloud dan Kontainer**

Karena tidak memerlukan `libgdiplus`, Aspose.Slides.NET6.CrossPlatform adalah paket yang harus digunakan pada host Linux dimana Anda tidak dapat menginstal `libgdiplus`. Paket ini tetap memerlukan `fontconfig` dan font, yang mungkin tidak ada pada gambar basis minimal. Misalnya, gambar basis AWS Lambda untuk .NET 8 tidak menyertakan keduanya. Pada gambar kontainer yang dibangun di atasnya, jalankan `dnf install -y fontconfig`, yang juga menginstal font Noto Sans.

Untuk panduan ke platform cloud tertentu, lihat [Aspose.Slides on Cloud Platforms](/slides/id/net/slides-on-cloud-platforms/).

## **Menggunakan System.Drawing.Common dalam Proyek yang Sama (CS0433)**

Proyek yang menggunakan Aspose.Slides.NET6.CrossPlatform dapat juga merujuk System.Drawing.Common, secara langsung atau melalui paket lain. Versi saat ini dari Aspose.Slides tidak mengekspos tipe publik dalam namespace `System`, sehingga dua pustaka tidak berbenturan, dan Anda dapat mengimpor namespace `Aspose.Slides` dan `System.Drawing` dalam file yang sama.

Jika kompiler melaporkan kesalahan CS0433 karena tipe seperti `Image` atau `Graphics` ada di both Aspose.Slides dan System.Drawing.Common, proyek Anda menggunakan versi Aspose.Slides yang lebih lama. Perbarui paket ke versi terbaru. Aspose.Slides mengembalikan gambar yang dirender sebagai objek [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), yang dijelaskan dalam [Modern API](/slides/id/net/modern-api/).

## **FAQ**

**Apakah saya perlu mengubah kode saya saat beralih dari Aspose.Slides.NET ke Aspose.Slides.NET6.CrossPlatform?**

Tidak. Kedua paket menyediakan namespace dan kelas Aspose.Slides yang sama, sehingga Anda hanya mengganti referensi paket. Aspose.Slides.NET6.CrossPlatform tidak memerlukan saklar `System.Drawing.EnableUnixSupport`. Tambahkan hanya satu dari dua paket ke proyek.

**Apakah saya dapat menggunakan Aspose.Slides.NET6.CrossPlatform dalam proyek .NET Framework?**

Tidak. Paket ini menargetkan hanya .NET 6 dan versi selanjutnya. Untuk .NET Framework 4.6.2 dan yang lebih baru, gunakan Aspose.Slides.NET.