---
title: Lisensi
type: docs
weight: 80
url: /id/net/licensing/
keywords:
- lisensi
- lisensi sementara
- menetapkan lisensi
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

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi memberikan fungsi yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi saat presentasi dibuka atau disimpan dan membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan bagaimana menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya tertanam dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="info" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for NET** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.NET/). Versi evaluasi menyediakan fungsi yang sama dengan versi berlisensi produk ini. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi cukup menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika ada pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi atau bahkan versi evaluasi mendapatkan dukungan teknis gratis dan tak terbatas.

{{% /alert %}} 

**Batasan versi evaluasi**

* Meskipun versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas penuh produk, ia menyisipkan watermark evaluasi di bagian atas dokumen saat operasi buka dan simpan. 
* Anda dibatasi pada satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="info" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [Cara Mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.

{{% /alert %}}

## **Lisensi di Aspose.Slides**
* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.
* Aspose.Slides for .NET biasanya mencoba menemukan lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi assembly entri (exe Anda)
  * Sumber daya tertanam dalam assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides).
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan Aspose.Slides. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

{{% alert color="info" %}} 

Anda mungkin ingin melihat [Metered Licensing](https://docs.aspose.com/slides/id/net/metered-licensing/).

{{% /alert %}} 


## **Menerapkan Lisensi**
Lisensi dapat dimuat dari **file**, **stream**, atau **sumber daya tertanam**. 

{{% alert color="info" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/net/aspose.slides/license) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" %}} 

Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**
Metode paling mudah untuk menetapkan lisensi mengharuskan Anda menempatkan file lisensi di folder yang sama dengan DLL komponen (termasuk dalam Aspose.Slides) dan hanya menyebutkan nama file tanpa jalurnya.

Kode C# berikut menunjukkan cara menetapkan file lisensi:

``` csharp
// Membuat instance kelas License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Menetapkan jalur file lisensi
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Jika Anda menempatkan file lisensi di direktori yang berbeda, ketika memanggil metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1), nama file lisensi di akhir jalur eksplisit yang diberikan harus sama dengan file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.lic.xml*. Kemudian, dalam kode Anda, harus memberikan jalur ke file (yang berakhiran *Aspose.Slides.lic.xml*) ke metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Stream**
Anda dapat memuat lisensi dari stream. Kode C# berikut menunjukkan cara menerapkan lisensi dari stream:

``` csharp
// Membuat instance kelas License
Aspose.Slides.License license = new Aspose.Slides.License();

// Membuka file lisensi sebagai stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Menetapkan lisensi melalui stream
license.SetLicense(licenseStream);
```

### **Embedded Resource**
Anda dapat memaketkan lisensi bersama aplikasi Anda (untuk menghindari kehilangan) dengan menambahkan lisensi sebagai sumber daya tertanam ke salah satu assembly yang memanggil DLL komponen (termasuk dalam Aspose.Slides). 

Berikut cara menambahkan file lisensi sebagai sumber daya tertanam:

1. Di Visual Studio, tambahkan file lisensi (.lic) ke proyek dengan cara: Pilih **File** > **Add Existing Item** > **Add**. 
2. Pilih file di **Solution Explorer**.
3. Di jendela **Properties**, atur **Build Action** menjadi **Embedded Resource**.
4. Untuk mengakses lisensi yang tertanam dalam assembly, tambahkan file lisensi sebagai sumber daya tertanam ke proyek, lalu berikan nama file lisensi ke metode `SetLicense`. 

Kelas `License` secara otomatis menemukan file lisensi di sumber daya tertanam. Anda tidak perlu memanggil metode `GetExecutingAssembly` dan `GetManifestResourceStream` dari kelas `System.Reflection.Assembly` di Microsoft .NET Framework.

Kode C# berikut menunjukkan cara menetapkan lisensi sebagai sumber daya tertanam:

``` csharp
// Membuat instance kelas License
Aspose.Slides.License license = new Aspose.Slides.License();

// Menyampaikan nama file lisensi yang tertanam dalam assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah ditetapkan dengan benar, Anda dapat memvalidasinya. Kode C# berikut menunjukkan cara memvalidasi lisensi:

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

{{% alert title="Note" color="warning" %}} 

Metode [license.SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/) tidak thread-safe. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti lock) untuk menghindari masalah. 

{{% /alert %}}

## **FAQ**

### Apakah saya dapat menerapkan lisensi dalam lingkungan offline sepenuhnya (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak memerlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak berhak menggunakan rilis baru tanpa memperbarui lisensi.