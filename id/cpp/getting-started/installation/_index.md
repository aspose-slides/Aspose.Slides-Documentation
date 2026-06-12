---
title: Instalasi
type: docs
weight: 70
url: /id/cpp/installation/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara cepat menginstal Aspose.Slides untuk C++. Panduan langkah demi langkah, persyaratan sistem, dan contoh kode — mulai bekerja dengan presentasi PowerPoint hari ini!"
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menginstal Aspose.Slides pada Windows. Artikel ini berfokus pada instalasi berbasis NuGet dan menunjukkan cara menambahkan pustaka ke proyek Visual Studio baik melalui NuGet Package Manager maupun Package Manager Console di Windows. Artikel ini juga menjelaskan cara memperbarui paket dan menginstal build prerelease bila diperlukan.

## **Windows**
NuGet menyediakan cara termudah untuk mengunduh dan menginstal API Aspose untuk C++ pada PC. 

### **Opsi Satu: Instal atau Perbarui Aspose.Slides untuk C++ dari NuGet Package Manager**

1. Buka Microsoft Visual Studio. 
2. Buat aplikasi konsol sederhana. Atau Anda dapat membuka proyek pilihan Anda. 
3. Arahkan ke **Tools** > **NuGet package manager**.
4. Di bawah **Browse**, ketik *Aspose.Slides.Cpp* ke dalam kolom teks. 

![todo:image_alt_text](installation_1.png)

3. Klik versi **Aspose.Slides.Cpp** yang Anda butuhkan, lalu klik **Install**. 
   * Jika Anda ingin memperbarui Aspose.Slides—yang berarti Anda sudah menginstalnya—klik **Update** sebagai gantinya. 

API yang dipilih akan diunduh dan direferensikan dalam proyek Anda.

### **Opsi 2: Instal atau Perbarui Aspose.Slides Melalui Package Manager Console**

Untuk merujuk pada [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) menggunakan konsol Package Manager, lakukan hal berikut:

1. Buka solution/proyek Anda di Visual Studio.

1. Arahkan ke **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   Package Manager Console terbuka. 

![todo:image_alt_text](installation_2.png)

4. Ketik perintah berikut: `Install-Package Aspose.Slides.Cpp` 
> Jika Anda ingin menginstal versi x86, gunakan paket Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Tekan tombol Enter.

   Rilis penuh terbaru akan diinstal ke dalam aplikasi Anda. 

   * Sebagai alternatif, Anda dapat menambahkan akhiran `-prerelease` pada perintah untuk menentukan agar rilis terbaru (termasuk hotfix) juga diinstal.

![todo:image_alt_text](installation_3.png)

Setelah unduhan selesai, Anda akan melihat beberapa pesan konfirmasi.  

![todo:image_alt_text](installation_4.png)

Jika Anda tidak familiar dengan [Aspose EULA](https://about.aspose.com/legal/eula), Anda mungkin ingin membaca lisensi yang dirujuk pada URL tersebut.

Di Package Manager Console, Anda dapat menjalankan perintah `Update-Package Aspose.Slides.Cpp` untuk memeriksa pembaruan paket Aspose.Slides. Pembaruan (jika ada) akan diinstal secara otomatis. Anda juga dapat menggunakan akhiran `-prerelease` untuk memperbarui rilis terbaru.

### **Menggunakan Folder Include dan lib**
1. [Download](https://downloads.aspose.com/slides/id/cpp) versi terbaru Aspose.Slides untuk C++. 
1. Ekstrak folder ke lingkungan produksi. 
1. Untuk menggunakan Aspose.Slides untuk C++, referensikan folder Include dan lib dalam proyek Anda.

## **FAQ**

**Apakah ada versi gratis atau batasan trial?**

Ya, secara default, Aspose.Slides berjalan dalam mode evaluasi, yang menambahkan watermark dan mungkin memiliki batasan lain. Untuk menghapus pembatasan, Anda perlu menerapkan [lisensi](/slides/id/cpp/licensing/) yang valid.