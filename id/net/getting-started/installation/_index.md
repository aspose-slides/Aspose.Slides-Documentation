---
title: Instalasi
type: docs
weight: 70
url: /id/net/installation/
keywords:
- menginstal Aspose.Slides
- mengunduh Aspose.Slides
- menggunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Instal Aspose.Slides untuk .NET dari NuGet di Windows, Linux, dan macOS: pilih di antara dua paket, tambahkan satu dengan .NET CLI atau Visual Studio, dan instal prasyarat Linux."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan Aspose.Slides untuk .NET ke proyek di Windows, Linux, dan macOS. Aspose.Slides didistribusikan melalui NuGet. Anda dapat menambahkannya dengan .NET CLI pada sistem operasi apa pun, atau dengan NuGet Package Manager atau Package Manager Console di Visual Studio pada Windows. Artikel ini juga menjelaskan paket NuGet mana yang harus dipilih dan apa yang dibutuhkan Linux secara tambahan.

Sebelum instalasi, tinjau sistem operasi yang didukung, implementasi .NET, dan ketergantungan tambahan di [Persyaratan Sistem](/slides/id/net/system-requirements/).

## **Pilih Paket**

Aspose.Slides untuk .NET dipublikasikan sebagai dua paket NuGet. Kedua paket menyediakan namespace dan kelas Aspose.Slides yang sama, sehingga kode Anda tidak berubah ketika beralih di antara keduanya; hanya referensi paket dan persyaratan platform yang berbeda.

| Paket | Gunakan untuk | Persyaratan tambahan |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows, dan aplikasi .NET Framework | Pada Linux dan macOS: pustaka `libgdiplus`, dan saklar `System.Drawing.EnableUnixSupport` diaktifkan saat aplikasi dimulai |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 atau yang lebih baru pada Windows, Linux, dan macOS | Pada Linux: pustaka `fontconfig`, jika belum terpasang |

Jika Anda tidak yakin, gunakan Aspose.Slides.NET pada Windows dan Aspose.Slides.NET6.CrossPlatform pada Linux dan macOS. Pada Alpine Linux, dan pada sistem Linux yang glibc‑nya lebih tua dari 2.23 (x64) atau 2.39 (ARM64), gunakan Aspose.Slides.NET sebagai gantinya. [Persyaratan Sistem](/slides/id/net/system-requirements/) mencantumkan platform yang didukung masing‑masing paket.

## **Instal dengan .NET CLI**

Langkah‑langkah ini berfungsi pada Windows, Linux, dan macOS dengan .NET SDK 6 atau yang lebih baru. Buat aplikasi konsol:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Kemudian tambahkan paket untuk platform Anda. Tambahkan hanya satu dari dua paket ke proyek.

- Pada Windows: `dotnet add package Aspose.Slides.NET`
- Pada Linux dan macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (pada Linux, instal prasyaratnya terlebih dahulu; lihat [Linux](#linux))

Untuk memeriksa bahwa paket berfungsi, ganti isi *Program.cs* dengan contoh pertama di [Buat Presentasi](/slides/id/net/create-presentation/) dan jalankan `dotnet run`. Itu menyimpan *hello.pptx* di folder proyek.

## **Windows**

### **Metode 1: Instal atau Perbarui Aspose.Slides dari NuGet Package Manager**

1. Buka Microsoft Visual Studio.  
2. Buat aplikasi konsol atau buka proyek yang sudah ada.  
3. Di **Solution Explorer**, klik kanan pada proyek dan pilih **Manage NuGet Packages** (atau pergi ke **Project** > **Manage NuGet Packages**).  
4. Di bawah **Browse**, cari *Aspose.Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}  
5. Klik **Aspose.Slides.NET** lalu klik **Install**.  
   * Jika Anda sudah menginstal Aspose.Slides dan ingin memperbaruinya, klik **Update** sebagai gantinya.

Paket diunduh dan direferensikan dalam proyek Anda.

### **Metode 2: Instal atau Perbarui Aspose.Slides melalui Package Manager Console**

Berikut cara Anda merujuk paket [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) melalui Package Manager Console:

1. Buka Microsoft Visual Studio.  
2. Buat aplikasi konsol atau buka proyek yang sudah ada.  
3. Buka **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Opening the Package Manager Console](installation_2.png)  
4. Jalankan perintah ini: `Install-Package Aspose.Slides.NET`  
![Running the Install-Package command](installation_3.png)  
Rilis terbaru diinstal dalam proyek Anda.

Pesan **Installing Aspose.Slides.NET** muncul di bagian bawah jendela.  
![Installation progress in the Package Manager Console](installation_4.png)  

Setelah unduhan selesai, pesan konfirmasi muncul. Paket didistribusikan di bawah [Aspose EULA](https://about.aspose.com/legal/eula).  
![Installation confirmation messages](installation_5.png)  

Aspose.Slides kini ditambahkan ke proyek Anda dan direferensikan.  
![Aspose.Slides referenced in the project](installation_6.png)  

Untuk memperbarui paket, jalankan `Update-Package Aspose.Slides.NET` di Package Manager Console.

## **Linux**

Gunakan langkah‑langkah .NET CLI di atas. Pilih paket dan instal prasyaratnya dengan manajer paket distribusi Anda. Pada Debian dan Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: instal `fontconfig`.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
```

- **Aspose.Slides.NET**: instal `libgdiplus`, dan aktifkan dukungan Unix untuk System.Drawing sebelum aplikasi Anda menggunakan Aspose.Slides.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
```

Tambahkan pernyataan ini di awal aplikasi Anda, sebelum ada pemanggilan Aspose.Slides. Pada *Program.cs* dengan pernyataan tingkat atas, letakkan setelah direktif `using`:

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

Gunakan paket ini pada Alpine Linux, dan pada sistem yang glibc‑nya terlalu tua untuk Aspose.Slides.NET6.CrossPlatform.

Font yang digunakan dalam presentasi Anda, atau pengganti yang cocok, harus diinstal pada sistem agar teks dapat dirender dengan benar. [Persyaratan Sistem](/slides/id/net/system-requirements/) menjelaskan paket yang dibutuhkan Aspose.Slides.NET pada Alpine Linux, termasuk font.

## **macOS**

Gunakan langkah‑langkah .NET CLI di atas dengan paket **Aspose.Slides.NET6.CrossPlatform**, yang mendukung Mac Intel (x86_64) dan Apple silicon (ARM64):

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Apakah ada versi gratis atau batasan percobaan?**

Ya. Tanpa lisensi, Aspose.Slides berjalan dalam mode evaluasi: menambahkan watermark evaluasi pada setiap slide yang disimpan dan memotong teks yang dibaca dari presentasi. Untuk menghilangkan batasan ini, terapkan [lisensi](/slides/id/net/licensing/) yang valid.