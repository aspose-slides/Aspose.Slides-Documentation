---
title: Persyaratan Sistem
type: docs
weight: 60
url: /id/net/system-requirements/
keywords:
- persyaratan sistem
- sistem operasi
- instalasi
- dependensi
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan persyaratan sistem Aspose.Slides untuk .NET. Pastikan dukungan PowerPoint dan OpenDocument yang mulus di Windows, Linux, dan macOS."
---
## **Pendahuluan**

Aspose.Slides for .NET tidak memerlukan Microsoft PowerPoint terpasang karena Aspose.Slides adalah mesin independen untuk pembuatan, konversi, tata letak halaman, dan rendering dokumen Microsoft PowerPoint.

## **Sistem Operasi yang Didukung**

Aspose.Slides for .NET mendukung semua sistem operasi 32-bit atau 64-bit yang memiliki .NET atau kerangka kerja Mono terpasang termasuk (tetapi tidak terbatas pada):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, dan lain-lain)

### **Mac**

- Mac OS X

## **Framework yang Didukung**

Aspose.Slides for .NET mendukung kerangka kerja .NET dan Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Framework Mono**

- Dukungan MONO di platform MAC dan Linux

## **Lingkungan Pengembangan**

Aspose.Slides for .NET dapat digunakan untuk mengembangkan aplikasi di lingkungan pengembangan apa pun yang menargetkan platform .NET, tetapi lingkungan berikut secara eksplisit didukung:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Build Utama Aspose.Slides**

Saat ini, ada dua build utama Aspose.Slides — Aspose.Slides.NET dan Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Ini adalah versi utama produk. Ia menggunakan mesin grafis .NET standar.
- Pada platform non-Windows, Anda mungkin perlu menginstal pustaka `libgdiplus` dan dependensinya.
- Sebelum versi Aspose.Slides 25.3, untuk platform non-Windows, diperlukan menggunakan DLL .NET Standard 2.0 dari paket ZIP Aspose.Slides.
- Mulai dari versi Aspose.Slides 25.3, paket NuGet dapat langsung digunakan bahkan pada sistem non-Windows.
- Saat dijalankan pada sistem non-Windows, aplikasi Anda harus menyertakan baris berikut pada startup:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Mulai dari versi 25.3, Anda dapat menggunakan paket ini pada platform yang mendukung .NET, seperti Linux aarch64 (ARM64).**

#### **Paket Tambahan untuk Linux Alpine**

Saat menjalankan Aspose.Slides for .NET dalam kontainer Alpine Linux, menginstal `libgdiplus` saja mungkin tidak cukup. Kontainer Alpine biasanya tidak menyertakan font secara default. Jika tidak ada font yang tersedia, operasi rendering atau konversi dapat gagal dengan error serupa dengan:

```text
System.ArgumentException: Font '?' cannot be found
```
Untuk menggunakan Aspose.Slides di Alpine, instal `libgdiplus` bersama setidaknya satu paket font.

**Opsi 1: Font DejaVu**

Opsi yang direkomendasikan adalah menginstal paket ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Paket `ttf-dejavu` secara otomatis menginstal dependensi terkait font yang diperlukan, seperti `fontconfig`, `encodings`, `mkfontscale`, dan `mkfontdir`. Tidak ada paket font tambahan yang diperlukan untuk sebagian besar kasus penggunaan.

**Opsi 2: Font Inti Microsoft**

Jika presentasi Anda menggunakan font khusus Microsoft, seperti Arial, Times New Roman, Courier New, atau Verdana, instal Microsoft Core Fonts sebagai gantinya:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Gunakan opsi ini hanya ketika presentasi yang diproses memerlukan font Microsoft. Untuk kebanyakan skenario, menginstal `ttf-dejavu` lebih sederhana dan lebih dapat diandalkan.

**Persyaratan tambahan untuk globalisasi**

Untuk mengaktifkan dukungan globalisasi yang tepat pada Alpine, instal paket `icu-libs` dan nonaktifkan mode invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Ini adalah versi Aspose.Slides yang menggunakan mesin grafis lintas platform khusus yang dikembangkan oleh tim Aspose.Slides.  
Pada platform non-Windows, pustaka `fontconfig` mungkin diperlukan.

**Platform yang Didukung**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Platform yang Tidak Didukung**
- *Windows 11 ARM* (ARM64) — *Saat ini tidak dipertimbangkan*

{{%  alert  title="Notes"  color="primary"  %}}  
Untuk Linux x64, diperlukan GLIBC 2.23+; untuk Linux ARM64, diperlukan GLIBC 2.39+. Sistem seperti CentOS 7 (GLIBC 2.14) tidak didukung. Jika Anda perlu menjalankan Aspose.Slides pada CentOS 7 atau sistem tidak kompatibel lainnya (misalnya, Alpine), silakan gunakan paket standar: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Tanya Jawab**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/net/create-presentation/), memodifikasi, [mengonversi](/slides/id/net/convert-presentation/), dan [merender](/slides/id/net/convert-powerpoint-to-png/) presentasi.

**Font apa yang dibutuhkan untuk rendering yang tepat?**

Font yang digunakan dalam presentasi, atau pengganti yang cocok, harus tersedia di sistem operasi. Pada Linux dan macOS, instal paket font umum untuk memastikan rendering yang konsisten.

Untuk kontainer Alpine Linux, instal setidaknya satu paket font selain `libgdiplus`. Pengaturan minimal yang direkomendasikan adalah `libgdiplus` dengan `ttf-dejavu`. Jika font Microsoft seperti Arial, Times New Roman, Courier New, atau Verdana diperlukan, gunakan `msttcorefonts-installer` bersama `fontconfig`.

**Mengapa font khusus dirender sebagai fallback atau teks yang hilang di Linux?**

Jika berkas font memiliki entri tabel nama yang tidak konsisten atau rusak, stack pencocokan font Linux (FreeType/fontconfig) dapat memilih rekaman yang tidak valid, menyebabkan font tidak terpecahkan. Menggunakan versi font dengan tabel nama yang diperbaiki atau menginstal pengganti yang konsisten menyelesaikan masalah.