---
title: Persyaratan Sistem
type: docs
weight: 80
url: /id/java/system-requirements/
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
- Java
- Aspose.Slides
description: "Temukan persyaratan sistem Aspose.Slides untuk Java. Pastikan dukungan PowerPoint dan OpenDocument yang mulus di Windows, Linux, dan macOS."
---
## **Gambaran Umum**
Aspose.Slides untuk Java tidak memerlukan Microsoft PowerPoint terinstal, karena Aspose.Slides sendiri adalah mesin pembuatan, konversi, tata letak halaman, dan rendering dokumen Microsoft PowerPoint.

## **Sistem Operasi yang Didukung**
Aspose.Slides untuk Java mendukung semua sistem operasi 32-bit atau 64-bit yang menjalankan runtime Java, termasuk namun tidak terbatas pada:

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS dan lainnya)

### **Mac**
- Mac OS X

## **Versi Java yang Didukung**
Aspose.Slides untuk Java mendukung J2SE 6.0 (Java 1.6) dan yang lebih tinggi.

## **Tanya Jawab**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/java/create-presentation/), memodifikasi, [mengonversi](/slides/id/java/convert-presentation/), dan [merender](/slides/id/java/convert-powerpoint-to-png/) presentasi.

**Font apa yang dibutuhkan untuk rendering yang tepat?**

Secara praktik, font yang digunakan dalam presentasi atau [pengganti](/slides/id/java/font-substitution/) yang tepat harus tersedia. Untuk memastikan rendering yang konsisten di Linux/macOS, disarankan menginstal paket font umum.

**Mengapa font khusus dirender sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri tabel nama yang tidak konsisten atau rusak, stack pencocokan font Linux (FreeType/fontconfig) dapat memilih catatan yang tidak valid, menyebabkan font tidak dapat diselesaikan. Menggunakan versi font dengan catatan tabel nama yang sudah diperbaiki atau menginstal pengganti yang konsisten menyelesaikan masalah.