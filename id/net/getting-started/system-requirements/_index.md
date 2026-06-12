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
description: "Temukan persyaratan sistem Aspose.Slides untuk .NET. Pastikan dukungan PowerPoint dan OpenDocument yang mulus pada Windows, Linux, dan macOS."
---
## **Pendahuluan**

Aspose.Slides for .NET tidak memerlukan Microsoft PowerPoint terpasang karena Aspose.Slides adalah mesin pembuatan, konversi, tata letak halaman, dan rendering dokumen Microsoft PowerPoint yang berdiri sendiri.

## **Sistem Operasi yang Didukung**

Aspose.Slides for .NET mendukung semua sistem operasi 32-bit atau 64-bit yang memiliki .NET atau kerangka kerja Mono terpasang, termasuk (tetapi tidak terbatas pada):

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

## **Kerangka Kerja yang Didukung**

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
- Dukungan COM Interop (COM, C++, VBScript)

### **Kerangka Kerja Mono**

- Dukungan MONO pada platform MAC dan Linux

## **Lingkungan Pengembangan**

Aspose.Slides for .NET dapat digunakan untuk mengembangkan aplikasi pada lingkungan pengembangan apa pun yang menargetkan platform .NET, namun lingkungan berikut secara eksplisit didukung:

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
- Mulai versi Aspose.Slides 25.3, paket NuGet dapat langsung digunakan bahkan pada sistem non-Windows.
- Saat berjalan pada sistem non-Windows, aplikasi Anda harus menyertakan baris berikut saat startup:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Mulai versi 25.3, Anda dapat menggunakan paket ini pada platform yang mendukung .NET, seperti Linux aarch64 (ARM64).**

#### **Paket Tambahan untuk Linux Alpine**

Saat menjalankan Aspose.Slides for .NET dalam kontainer Alpine Linux, menginstal `libgdiplus` saja mungkin tidak cukup. Kontainer Alpine biasanya tidak menyertakan font secara default. Jika tidak ada font, operasi rendering atau konversi dapat gagal dengan error serupa dengan:

```text
System.ArgumentException: Font '?' cannot be found
```
Untuk menggunakan Aspose.Slides pada Alpine, instal `libgdiplus` bersama setidaknya satu paket font.

**Opsi 1: Font DejaVu**

Opsi yang direkomendasikan adalah menginstal paket ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Paket `ttf-dejavu` secara otomatis menginstal dependensi terkait font yang diperlukan, seperti `fontconfig`, `encodings`, `mkfontscale`, dan `mkfontdir`. Tidak diperlukan paket font tambahan untuk kebanyakan kasus penggunaan.

**Opsi 2: Microsoft Core Fonts**

Jika presentasi Anda menggunakan font khusus Microsoft, seperti Arial, Times New Roman, Courier New, atau Verdana, instal Microsoft Core Fonts sebagai gantinya:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Gunakan opsi ini hanya ketika presentasi yang diproses memerlukan font Microsoft. Untuk kebanyakan skenario, menginstal `ttf-dejavu` lebih sederhana dan lebih andal.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Ini adalah versi Aspose.Slides yang menggunakan mesin grafis lintas platform khusus yang dikembangkan oleh tim Aspose.Slides.  
Pada platform non-Windows, pustaka `fontconfig` mungkin diperlukan.

**Platform yang Didukung**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Platform yang Tidak Didukung**
- *Windows 11 ARM* (ARM64) — *Tidak sedang dipertimbangkan*

{{%  alert  title="Catatan"  color="primary"  %}}  
Untuk Linux x64, GLIBC 2.23+ diperlukan; untuk Linux ARM64, GLIBC 2.39+ diperlukan. Sistem seperti CentOS 7 (GLIBC 2.14) tidak didukung. Jika Anda perlu menjalankan Aspose.Slides pada CentOS 7 atau sistem tidak kompatibel lainnya (misalnya Alpine), silakan gunakan paket standar: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/net/create-presentation/), memodifikasi, [mengonversi](/slides/id/net/convert-presentation/), dan [merender](/slides/id/net/convert-powerpoint-to-png/) presentasi.

**Font apa yang diperlukan untuk rendering yang tepat?**

Font yang digunakan dalam presentasi, atau pengganti yang sesuai, harus tersedia di sistem operasi. Pada Linux dan macOS, instal paket font umum untuk memastikan rendering yang konsisten.

Untuk kontainer Alpine Linux, instal setidaknya satu paket font selain `libgdiplus`. Pengaturan minimal yang direkomendasikan adalah `libgdiplus` dengan `ttf-dejavu`. Jika diperlukan font Microsoft seperti Arial, Times New Roman, Courier New, atau Verdana, gunakan `msttcorefonts-installer` bersama `fontconfig`.

**Mengapa font khusus tampil sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri nama-table yang tidak konsisten atau rusak, tumpukan pencocokan font Linux (FreeType/fontconfig) dapat memilih record yang tidak valid, menyebabkan font tidak terdeteksi. Menggunakan versi font dengan tabel nama yang telah diperbaiki atau menginstal pengganti yang konsisten menyelesaikan masalah.