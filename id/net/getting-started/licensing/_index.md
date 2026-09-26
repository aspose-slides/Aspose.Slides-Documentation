---
title: Lisensi
type: docs
weight: 80
url: /id/net/licensing/
keywords:
- lisensi
- lisensi sementara
- atur lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk .NET. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan dan memotong teks yang dibaca kode Anda dari presentasi.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya yang disematkan dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**
{{% alert color="info" title="Note" %}}
Anda dapat mengunduh versi evaluasi **Aspose.Slides for .NET** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.NET/). Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi produk. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi akan menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/id/net/). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk pembaruan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi atau bahkan versi evaluasi mendapatkan dukungan teknis gratis dan tanpa batas.
{{% /alert %}} 

**Batasan versi evaluasi**

* Versi evaluasi (tanpa lisensi yang ditentukan) menyediakan fungsionalitas produk secara penuh, tetapi menambahkan kotak teks watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan.
* Teks yang dibaca kode Anda dari sebuah presentasi dipotong hingga beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}
Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [Cara mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Lisensi di Aspose.Slides**
* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang memiliki lisensi, tanggal kedaluwarsa langganan, dan sebagainya.
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh mengubah file tersebut. Bahkan penambahan baris kosong secara tidak sengaja ke isi file akan membuatnya tidak valid.
* Aspose.Slides for .NET biasanya mencoba menemukan lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi entry assembly (exe Anda)
  * Sumber daya yang disematkan dalam assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides).
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda harus menetapkan lisensi sebelum menggunakan Aspose.Slides. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

{{% alert color="info" title="Note" %}}
Anda mungkin ingin melihat [Metered Licensing](/slides/id/net/metered-licensing/).
{{% /alert %}} 

## **Menerapkan Lisensi**
Lisensi dapat dimuat dari **file**, **stream**, atau **sumber daya yang disematkan**. 

{{% alert color="info" title="Note" %}}
Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/net/aspose.slides/license) untuk operasi lisensi.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **File**
Metode paling mudah untuk menetapkan lisensi mengharuskan Anda menempatkan file lisensi di folder yang sama dengan DLL komponen (termasuk dalam Aspose.Slides) dan hanya menentukan nama file tanpa jalurnya.

Kode C# berikut menunjukkan cara menetapkan file lisensi:

``` csharp
// Membuat instance kelas License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Mengatur jalur file lisensi
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
Jika Anda menempatkan file lisensi di direktori yang berbeda, saat memanggil metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1), nama file lisensi di akhir jalur yang ditentukan harus sama dengan nama file lisensi Anda.

Misalnya, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan jalur ke file (yang berakhir dengan *Aspose.Slides.lic.xml*) ke metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1).
{{% /alert %}}

### **Stream**
Anda dapat memuat lisensi dari sebuah stream. Kode C# berikut menunjukkan cara menerapkan lisensi dari stream:

``` csharp
// Membuat instance kelas License
Aspose.Slides.License license = new Aspose.Slides.License();

// Membuka file lisensi sebagai stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Mengatur lisensi melalui stream
license.SetLicense(licenseStream);
```

### **Embedded Resource**
Anda dapat mengemas lisensi bersama aplikasi Anda (untuk menghindari kehilangan) dengan menambahkan lisensi sebagai sumber daya yang disematkan ke salah satu assembly yang memanggil DLL komponen (termasuk dalam Aspose.Slides). 

Berikut cara menambahkan file lisensi sebagai sumber daya yang disematkan:

1. Di Visual Studio, tambahkan file lisensi (.lic) ke proyek dengan cara: Pilih **File** > **Add Existing Item** > **Add**. 
2. Pilih file tersebut di **Solution Explorer**.
3. Pada jendela **Properties**, atur **Build Action** menjadi **Embedded Resource**.
4. Untuk mengakses lisensi yang disematkan dalam assembly, tambahkan file lisensi sebagai sumber daya yang disematkan ke proyek, lalu berikan nama file lisensi ke metode `SetLicense`. 


Kelas `License` secara otomatis menemukan file lisensi di sumber daya yang disematkan. Anda tidak perlu memanggil metode `GetExecutingAssembly` dan `GetManifestResourceStream` dari kelas `System.Reflection.Assembly` pada Microsoft .NET Framework.

Kode C# berikut menunjukkan cara menetapkan lisensi sebagai sumber daya yang disematkan:

``` csharp
// Membuat instance kelas License
Aspose.Slides.License license = new Aspose.Slides.License();

// Menyerahkan nama file lisensi yang disematkan dalam assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah diatur dengan benar, Anda dapat memvalidasinya. Kode C# berikut menunjukkan cara memvalidasi lisensi:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Keamanan Thread**

{{% alert color="warning" title="Warning" %}}
Metode [license.SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/) tidak aman untuk thread. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitiva sinkronisasi (seperti lock) untuk menghindari masalah. 
{{% /alert %}}

## **FAQ**

### Bisakah saya menerapkan lisensi dalam lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui.