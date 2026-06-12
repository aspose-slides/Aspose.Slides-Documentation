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

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi saat presentasi dibuka atau disimpan dan membatasi ekstraksi teks menjadi satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya tertanam dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**
{{% alert color="primary" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for NET** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.NET/). Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi produk. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk pembaruan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi atau bahkan versi evaluasi mendapatkan dukungan teknis gratis dan tak terbatas.
{{% /alert %}} 

**Batasan Versi Evaluasi**

* Meskipun versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas penuh produk, ia menyisipkan watermark evaluasi di bagian atas dokumen pada operasi buka dan simpan. 
* Anda dibatasi satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [Cara mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Lisensi di Aspose.Slides**
* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh mengubah file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.
* Aspose.Slides for .NET biasanya mencoba menemukan lisensi di lokasi-lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi entry assembly (exe Anda)
  * Sumber daya tertanam dalam assembly yang memanggil dll komponen (termasuk dalam Aspose.Slides).
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu mengatur lisensi sebelum menggunakan Aspose.Slides. Anda hanya perlu mengatur lisensi satu kali per aplikasi atau proses.

{{% alert color="primary" %}} 

Anda mungkin ingin melihat [Metered Licensing](https://docs.aspose.com/slides/id/net/metered-licensing/).
{{% /alert %}} 


## **Menerapkan Lisensi**
Lisensi dapat dimuat dari **file**, **stream**, atau **sumber daya tertanam**. 

{{% alert color="primary" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/net/aspose.slides/license) untuk operasi lisensi.
{{% /alert %}} 

{{% alert color="warning" %}} 

Lisensi baru hanya dapat mengaktifkan Aspose.Slides pada versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **File**
Metode paling mudah untuk mengatur lisensi mengharuskan Anda menempatkan file lisensi di folder yang sama dengan DLL komponen (termasuk dalam Aspose.Slides) dan hanya menyebutkan nama file tanpa jalurnya.

Kode C# berikut menunjukkan cara mengatur file lisensi:

``` csharp
// Membuat instance kelas License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Menetapkan jalur file lisensi
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Jika Anda menempatkan file lisensi di direktori lain, ketika Anda memanggil metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1), nama file lisensi pada akhir jalur eksplisit yang ditentukan harus sama dengan file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan jalur ke file (yang diakhiri dengan *Aspose.Slides.lic.xml*) ke metode [SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/#setlicense_1).
{{% /alert %}}

### **Stream**
Anda dapat memuat lisensi dari stream. Kode C# berikut menunjukkan cara menerapkan lisensi dari stream:

``` csharp
// Membuat instance kelas License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Menetapkan lisensi melalui stream
license.SetLicense(myStream);
```

### **Embedded Resource**
Anda dapat mengemas lisensi bersama aplikasi Anda (untuk menghindari kehilangan) dengan menambahkan lisensi sebagai sumber daya tertanam dalam salah satu assembly yang memanggil DLL komponen (termasuk dalam Aspose.Slides). 

Berikut cara menambahkan file lisensi sebagai sumber daya tertanam:

1. Di Visual Studio, tambahkan file lisensi (.lic) ke proyek dengan cara: Buka **File** > **Add Existing Item** > **Add**. 
2. Pilih file di **Solution Explorer**.
3. Pada jendela **Properties**, atur **Build Action** menjadi **Embedded Resource**.
4. Untuk mengakses lisensi yang tertanam dalam assembly, tambahkan file lisensi sebagai sumber daya tertanam ke proyek, lalu berikan nama file lisensi ke metode `SetLicense`. 

Kelas `License` secara otomatis menemukan file lisensi di sumber daya tertanam. Anda tidak perlu memanggil metode `GetExecutingAssembly` dan `GetManifestResourceStream` dari kelas `System.Reflection.Assembly` di Microsoft .NET Framework.

Kode C# berikut menunjukkan cara mengatur lisensi sebagai sumber daya tertanam:

``` csharp
// Membuat instance kelas License
Aspose.Slides.License license = new Aspose.Slides.License();

// Menyampaikan nama file lisensi yang tertanam dalam assembly
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

{{% alert title="Note" color="warning" %}} 

Metode [license.SetLicense](https://reference.aspose.com/slides/id/net/aspose.slides/license/setlicense/) tidak thread-safe. Jika metode ini harus dipanggil secara simultan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti lock) untuk menghindari masalah. 
{{% /alert %}}

## **FAQ**

**Apakah saya dapat menerapkan lisensi di lingkungan sepenuhnya offline (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui.