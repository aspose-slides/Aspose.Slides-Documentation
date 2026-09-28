---
title: Persyaratan Sistem
type: docs
weight: 60
url: /id/net/system-requirements/
keywords:
- persyaratan sistem
- platform yang didukung
- kerangka kerja target
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Periksa apa yang diperlukan Aspose.Slides untuk .NET sebelum Anda menginstalnya: kerangka kerja yang menjadi target setiap paket NuGet, sistem operasi dan prosesor yang didukung, serta pustaka dan font yang dibutuhkan Linux."
---
## **Pendahuluan**

Aspose.Slides for .NET adalah pustaka mandiri: tidak memerlukan Microsoft PowerPoint atau Microsoft Office. Ia dipublikasikan sebagai dua paket NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) dan [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Kedua paket menyediakan namespace dan kelas Aspose.Slides yang sama; perbedaannya terletak pada kerangka kerja yang ditargetkan dan cara mereka menggambar slide, yang menentukan di mana mereka dijalankan dan apa yang mereka butuhkan.

Artikel ini mencantumkan versi .NET dan platform yang didukung masing‑masing paket serta pustaka sistem dan font yang diperlukan Linux, dan diakhiri dengan program singkat yang memeriksa pengaturan Anda. Untuk menambahkan paket ke proyek, lihat [Installation](/slides/id/net/installation/).

## **Versi .NET yang Didukung**

Setiap paket berisi satu build Aspose.Slides per target framework, dan NuGet memilih build yang cocok dengan target framework proyek Anda.

| Paket | Kerangka target dalam paket | Proyek Anda dapat menargetkan |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 atau lebih baru; .NET 6 atau lebih baru, termasuk .NET 8, .NET 9, dan .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 atau lebih baru, termasuk .NET 8, .NET 9, dan .NET 10 |

Build `netstandard2.0` memungkinkan perpustakaan kelas .NET Standard 2.0 merujuk Aspose.Slides.NET. Aplikasi yang menggunakan perpustakaan tersebut menjalankan build yang cocok dengan target framework aplikasi itu sendiri: misalnya aplikasi .NET 8 akan menjalankan build `net6.0`.

## **Sistem Operasi dan Prosesor yang Didukung**

**Aspose.Slides.NET** hanya berisi kode terkelola yang bersifat processor‑independent (AnyCPU), sehingga berjalan pada arsitektur prosesor runtime .NET yang memuatnya. Ia menggambar slide melalui pustaka Microsoft System.Drawing.Common, yang Microsoft dukung [hanya di Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Di Linux, Aspose.Slides.NET karenanya memerlukan pustaka `libgdiplus` dan sebuah switch startup, seperti dijelaskan di [Linux](#linux). Ia berjalan pada distribusi Linux yang menyediakan `libgdiplus`, seperti Debian, Ubuntu, dan Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** menggambar slide dengan mesin grafisnya sendiri. Mesin tersebut adalah pustaka native yang disertakan paket dalam satu build per platform, sehingga paket hanya berjalan pada platform berikut:

| Sistem operasi | Prosesor | Catatan |
|---|---|---|
| Windows | x86, x64 | Windows pada ARM64 tidak didukung. |
| Linux | x64, ARM64 | Membutuhkan glibc 2.23 atau lebih baru pada x64 dan glibc 2.39 atau lebih baru pada ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) | |

Aspose.Slides.NET6.CrossPlatform tidak berjalan pada Alpine Linux atau distribusi lain yang dibangun di atas musl alih‑alih glibc, atau pada distribusi dengan glibc lebih lama, seperti CentOS 7. Gunakan Aspose.Slides.NET pada sistem‑sistem tersebut.

Pada Windows, pustaka native Aspose.Slides.NET6.CrossPlatform menggunakan runtime Microsoft Visual C++ (*MSVCP140.dll* dan *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* pada x64). Jika file‑file ini tidak ada pada mesin target, instal [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Kedua paket memerlukan pustaka sistem tambahan pada Linux. Tanpa itu, contoh pertama di [Create Presentations](/slides/id/net/create-presentation/) akan gagal dengan pengecualian alih‑alih menyimpan berkas. Perintah di bawah ini untuk Debian dan Ubuntu; pada distribusi‑distribusi tersebut, tiap pustaka juga memasang font DejaVu (`fonts-dejavu-core`), sehingga teks ditampilkan tanpa paket font tambahan.

### **Aspose.Slides.NET6.CrossPlatform**

Pustaka Linux paket memerlukan pustaka `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Tanpa itu, pembuatan sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) gagal dengan `TypeInitializationException` yang berisi `DllNotFoundException` yang melaporkan bahwa `libfontconfig.so.1` tidak dapat dibuka.

Gambar dasar minimal mungkin juga tidak menyertakan `fontconfig`. Misalnya, gambar dasar AWS Lambda untuk .NET 8 tidak mengandung `fontconfig` maupun font apa pun. Pada gambar kontainer yang dibangun di atasnya, jalankan `dnf install -y fontconfig`, yang juga memasang font Noto Sans.

### **Aspose.Slides.NET**

Paket memerlukan dua hal pada Linux:

1. Pustaka `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Switch `System.Drawing.EnableUnixSupport`, diaktifkan di awal aplikasi Anda sebelum pemanggilan Aspose.Slides mana pun. Pada *Program.cs* dengan pernyataan top‑level, letakkan setelah direktif `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Tanpa `libgdiplus`, penyimpanan presentasi gagal dengan `TypeInitializationException` yang berisi `DllNotFoundException` yang melaporkan bahwa `libgdiplus` tidak dapat dimuat. Tanpa switch, pengecualian dalamnya adalah `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Switch hanya berfungsi dengan System.Drawing.Common 6, versi yang menjadi dependensi Aspose.Slides.NET. Microsoft menghapusnya pada System.Drawing.Common 7. Jika proyek Anda merujuk System.Drawing.Common 7 atau lebih baru, secara langsung atau melalui paket lain, Aspose.Slides.NET akan gagal di Linux dengan `PlatformNotSupportedException` meski `libgdiplus` sudah terinstal dan switch diaktifkan. Dalam kasus ini, gunakan Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Pada Alpine Linux, gunakan Aspose.Slides.NET dengan switch yang dijelaskan di atas. Gambar Alpine biasanya tidak berisi font, dan `libgdiplus` saja tidak memasang font apa pun, sehingga instal `libgdiplus` bersamaan dengan setidaknya satu paket font. Tanpa font, penyimpanan presentasi gagal dengan error berikut:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Opsi 1: Font DejaVu**

Opsi yang disarankan adalah paket `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Pada rilis Alpine terkini, `ttf-dejavu` memasang paket `font-dejavu`, yang juga memasang `fontconfig` dan alat‑alat font yang dibutuhkannya.

**Opsi 2: Font inti Microsoft**

Jika presentasi Anda menggunakan font Microsoft seperti Arial, Times New Roman, Courier New, atau Verdana, instal font inti Microsoft sebagai gantinya. Langkah `update-ms-fonts` mengunduh font saat gambar dibangun, sehingga proses build memerlukan akses internet:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Dukungan Globalisasi**

Kedua paket memerlukan dukungan globalisasi .NET, yang disediakan .NET di Linux melalui pustaka ICU. Dalam [mode globalization‑invariant](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), pembuatan sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) gagal dengan `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Beberapa gambar kontainer mengaktifkan mode ini. Misalnya, gambar runtime .NET untuk Alpine Linux (`runtime-deps`, `runtime`, dan `aspnet`) menetapkan `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` dan tidak menyertakan ICU. Pada gambar yang dibangun di atasnya, instal ICU dan matikan mode tersebut:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Pastikan juga file proyek Anda tidak mengatur properti `InvariantGlobalization` ke `true`.

## **Periksa Pengaturan Anda**

Untuk memeriksa bahwa paket dan persyaratannya sudah ada, jalankan program yang menyimpan presentasi dan merender slide ke gambar. Penyimpanan dan rendering menggunakan pustaka grafis serta font, yang merupakan apa yang disediakan oleh persyaratan Linux di atas.

Buat aplikasi konsol dan tambahkan paket sebagaimana dijelaskan di [Installation](/slides/id/net/installation/), ganti isi *Program.cs* dengan kode di bawah, lalu jalankan `dotnet run`. Jika Anda menggunakan Aspose.Slides.NET di Linux, tambahkan pernyataan switch `System.Drawing.EnableUnixSupport` yang ditunjukkan di [Linux](#linux) setelah direktif `using`. Program ini menggunakan pernyataan top‑level dan deklarasi `using`, yang memerlukan C# 9 atau lebih baru. Proyek yang menargetkan .NET 6 atau lebih baru secara default menggunakan versi C# yang lebih baru; pada proyek yang menargetkan .NET Framework, tambahkan `<LangVersion>latest</LangVersion>` ke `PropertyGroup` dalam file proyek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Program menambahkan persegi panjang dengan teks ke slide pertama dan menyimpan presentasi sebagai *hello.pptx* dengan metode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Selanjutnya program merender slide dengan [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) dan menyimpan hasilnya sebagai *hello.png* dengan [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) dalam format [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). Faktor skala 1 menghasilkan satu piksel per point, sehingga slide default 720 × 540 point menjadi gambar 720 × 540 piksel, dengan teks terlihat di dalam persegi panjang. Tanpa lisensi, kedua berkas tersebut juga menampilkan watermark evaluasi; lihat [Licensing](/slides/id/net/licensing/). Jika ada persyaratan yang hilang, program akan berhenti dengan salah satu pengecualian yang dijelaskan di [Linux](#linux).

## **Alat Pengembangan**

Anda dapat membangun aplikasi yang menggunakan Aspose.Slides dengan alat apa pun yang mendukung target framework proyek Anda: .NET SDK dan antarmuka baris perintah `dotnet` pada Windows, Linux, dan macOS, atau Visual Studio pada Windows. [Installation](/slides/id/net/installation/) menjelaskan keduanya.

## **FAQ**

**Apakah saya memerlukan Microsoft PowerPoint terinstal untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan. Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/net/create-presentation/), mengubah, [mengonversi](/slides/id/net/convert-presentation/), dan [merender](/slides/id/net/convert-powerpoint-to-png/) presentasi.

**Paket mana yang seharusnya saya gunakan?**

Gunakan Aspose.Slides.NET pada Windows dan Aspose.Slides.NET6.CrossPlatform pada Linux dan macOS. Pada Alpine Linux, pada sistem Linux yang glibc‑nya lebih lama dari versi yang tercantum di atas, dan pada proyek yang menargetkan .NET Framework, gunakan Aspose.Slides.NET. Tambahkan hanya satu dari dua paket ke proyek.

**Font apa yang dibutuhkan untuk rendering yang tepat?**

Font yang digunakan dalam presentasi, atau pengganti yang cocok, harus tersedia di sistem operasi. Pada Linux dan macOS, instal paket font yang dibutuhkan presentasi Anda agar rendering konsisten. Pada Alpine Linux, instal setidaknya satu paket font selain `libgdiplus`, seperti dijelaskan di [Alpine Linux](#alpine-linux).

**Mengapa font khusus tampil sebagai fallback atau teks yang hilang di Linux?**

Jika berkas font memiliki entri tabel nama yang tidak konsisten atau rusak, tumpukan pencocokan font Linux (FreeType/fontconfig) dapat memilih catatan yang tidak valid, sehingga font tidak dapat di‑resolve. Menggunakan versi font dengan tabel nama yang sudah diperbaiki atau memasang pengganti yang konsisten menyelesaikan masalah.