---
title: Persyaratan Sistem
type: docs
weight: 80
url: /id/cpp/system-requirements/
keywords:
- persyaratan sistem
- sistem operasi
- instalasi
- ketergantungan
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Temukan persyaratan sistem Aspose.Slides untuk C++. Pastikan dukungan PowerPoint dan OpenDocument yang mulus di Windows, Linux, dan macOS."
---
## **Pendahuluan**

Aspose.Slides tidak memerlukan Microsoft PowerPoint terpasang karena Aspose.Slides adalah mesin mandiri untuk pembuatan, konversi, tata letak halaman, dan perenderan dokumen Microsoft PowerPoint.

## **Sistem Operasi yang Didukung**
Aspose.Slides untuk C++ adalah perpustakaan C++ asli. Aspose.Slides untuk C++ mendukung sistem operasi dan platform 64-bit serta 32-bit berikut:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 atau lebih baru.
- CentOS 8 atau lebih baru.
- Fedora 24 atau lebih baru.
- Dan Linux x86_64 lainnya dengan glibc 2.23 atau lebih baru.

### **macOS**
- macOS Monterey 12.1 atau lebih baru.

## **Lingkungan Pengembangan**
Anda dapat menggunakan Aspose.Slides untuk C++ saat mengembangkan aplikasi untuk Windows, Linux, atau macOS.

### **Windows**
- Microsoft Visual Studio 2017 atau lebih baru.
- CMake 3.18 atau lebih baru.

### **Linux**
- Clang 3.9 atau lebih baru.
- GCC 6.1 atau lebih baru.
- CMake 3.18 atau lebih baru.

### **macOS**
- Xcode 13.4 atau lebih baru.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan perenderan?**

Tidak, PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/cpp/create-presentation/), memodifikasi, [mengonversi](/slides/id/cpp/convert-presentation/), dan [merender](/slides/id/cpp/convert-powerpoint-to-png/) presentasi.

**Font apa yang dibutuhkan untuk perenderan yang tepat?**

Secara praktik, font yang digunakan dalam presentasi atau [pengganti](/slides/id/cpp/font-substitution/) yang sesuai harus tersedia. Untuk memastikan perenderan yang konsisten pada Linux/macOS, disarankan memasang paket font umum.

**Mengapa font khusus dirender sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri tabel nama yang tidak konsisten atau rusak, tumpukan pencocokan font Linux (FreeType/fontconfig) dapat memilih rekaman yang tidak sah, menyebabkan font tidak teridentifikasi. Menggunakan versi font dengan rekaman tabel nama yang telah diperbaiki atau memasang pengganti yang konsisten menyelesaikan masalah.