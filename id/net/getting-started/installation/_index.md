---
title: Instalasi
type: docs
weight: 70
url: /id/net/installation/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- Instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menginstal Aspose.Slides untuk .NET dengan cepat. Panduan langkah demi langkah, persyaratan sistem, dan contoh kode — mulailah bekerja dengan presentasi PowerPoint hari ini!"
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menginstal Aspose.Slides untuk .NET di Windows dan macOS. Fokusnya pada instalasi berbasis NuGet dan menunjukkan cara menambahkan pustaka ke proyek Visual Studio baik melalui NuGet Package Manager maupun Package Manager Console di Windows. Artikel ini juga menjelaskan cara memperbarui paket dan menginstal build prerelease bila diperlukan.

## **Windows**
NuGet menyediakan cara termudah untuk mengunduh dan menginstal API Aspose untuk .NET di PC. 

### **Metode 1: Install atau Perbarui Aspose.Slides dari NuGet Package Manager**

1. Buka Microsoft Visual Studio. 
2. Buat aplikasi console sederhana atau buka proyek yang sudah ada. 
3. Pilih **Tools** > **NuGet package manager**.
4. Di bawah **Browse**, cari *Aspose Slides* pada bidang teks. 
{{% image img="installation_1.png" alt="Instalasi Aspose.Slides dari NuGet Package Manager - 1" %}}
5. Klik **Aspose.Slides.NET** lalu klik **Install**. 
   * Jika Anda ingin memperbarui Aspose.Slides—dengan asumsi Anda sudah menginstalnya—klik **Update** sebagai gantinya. 

API yang dipilih akan diunduh dan direferensikan dalam proyek Anda.

### **Metode 2: Install atau Perbarui Aspose.Slides melalui Package Manager Console**

Inilah cara Anda merujuk [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) melalui package manager console:

1. Buka Microsoft Visual Studio. 
2. Buat aplikasi console sederhana atau buka proyek yang sudah ada. 
3. Pilih **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Jalankan perintah berikut: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Rilis penuh terbaru akan diinstal dalam aplikasi Anda. 

* Alternatifnya, Anda dapat menambahkan akhiran `-prerelease` pada perintah untuk memastikan rilis terbaru (termasuk hotfix) juga diinstal.

Petunjuk **Installing Aspose.Slides.NET** muncul di bagian bawah jendela. 
![todo:image_alt_text](installation_4.png)

Setelah unduhan selesai, Anda akan melihat beberapa pesan konfirmasi. 

Jika Anda tidak familiar dengan [Aspose EULA](https://about.aspose.com/legal/eula), Anda mungkin ingin membaca lisensi yang tercantum pada URL tersebut. 
![todo:image_alt_text](installation_5.png)

Dalam aplikasi Anda, Anda akan melihat bahwa Aspose.Slides telah berhasil ditambahkan dan direferensikan. 
![todo:image_alt_text](installation_6.png)

Di Package Manager Console, Anda dapat menjalankan perintah `Update-Package Aspose.Slides.NET` untuk memeriksa pembaruan paket Aspose.Slides. Pembaruan (jika ada) akan diinstal secara otomatis. Anda juga dapat menggunakan akhiran `-prerelease` untuk memperbarui ke rilis terbaru.

#### **Pertimbangan Saat Menjalankan di Lingkungan Server Bersama**
Kami sangat menyarankan Anda menjalankan semua komponen Aspose .NET dengan set izin **Full Trust** karena komponen Aspose terkadang perlu mengakses pengaturan registri dan file yang berada di luar direktori virtual—misalnya, ketika komponen Aspose harus membaca font. 

Selain itu, komponen Aspose.NET berbasis pada kelas sistem inti .NET—dan beberapa kelas tersebut juga memerlukan izin Full Trust untuk operasi tertentu. 

Penyedia Layanan Internet yang menyewakan banyak aplikasi untuk perusahaan berbeda biasanya menerapkan tingkat keamanan Medium Trust. Pada .NET 2.0, tingkat keamanan tersebut dapat menyebabkan pembatasan yang memengaruhi operasi Aspose.Slides:

- **RegistryPermission** tidak tersedia. Ini berarti Anda tidak dapat mengakses registri, yang diperlukan untuk memenumerasi font yang terpasang saat merender dokumen.
- **FileIOPermission** dibatasi. Ini berarti Anda hanya dapat mengakses file dalam hierarki direktori virtual aplikasi Anda. Hal ini juga berpotensi menyebabkan font tidak dapat dibaca selama operasi ekspor. 

Dengan alasan di atas, kami sangat menyarankan Anda menjalankan Aspose.Slides dengan izin **Full Trust**. Jika Anda menggunakan **Medium trust**, Anda mungkin mengalami inkonsistensi—beberapa fitur pustaka (misalnya rendering) mungkin tidak berfungsi saat melakukan tugas tertentu. 

## **macOS**

NuGet menyediakan cara termudah untuk mengunduh dan menginstal Aspose.Slides untuk .NET di mac.

**Instal Prasyarat**

Namespace `System.Drawing` beroperasi secara berbeda di macOS, sehingga Anda harus menginstal mono-libgdiplus. 

> Pada .NET 5 dan versi sebelumnya, paket NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) berfungsi di Windows, Linux, dan macOS. Namun, ada beberapa perbedaan platform. Pada Linux dan macOS, fungsionalitas GDI+ diimplementasikan oleh pustaka [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). Pustaka ini tidak diinstal secara default pada sebagian besar distribusi Linux dan tidak mendukung semua fungsionalitas GDI+ pada Windows dan macOS. Ada pula platform yang sama sekali tidak menyediakan libgdiplus. Untuk menggunakan tipe dari paket System.Drawing.Common pada Linux dan macOS, Anda harus menginstal libgdiplus secara terpisah. Untuk informasi lebih lanjut, lihat [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) atau [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

Untuk menginstal mono-libgdiplus secara terpisah pada mac Anda, lihat [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) dari dokumentasi .NET. 

### **Instal Aspose.Slides**

1. Buka Visual Studio. 
2. Buat aplikasi console sederhana atau buka proyek yang sudah ada.
3. Pilih **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Ketik *Aspose.Slides* pada bidang teks. 
5. Klik **Aspose.Slides for .NET** lalu klik **Add Package**. 
6. Tambahkan potongan kode sederhana.
   * Anda dapat menyalin kode pada [this page](/slides/id/net/create-presentation/).
7. Jalankan aplikasi.
8. Buka *folder/bin/Debug/presentation_file_name* proyek Anda.

## **FAQ**

**Apakah ada versi gratis atau batasan percobaan?**

Ya, secara default, Aspose.Slides berjalan dalam mode evaluasi, yang menambahkan watermark dan mungkin memiliki batasan lain. Untuk menghapus pembatasan, Anda perlu menerapkan [license](/slides/id/net/licensing/).