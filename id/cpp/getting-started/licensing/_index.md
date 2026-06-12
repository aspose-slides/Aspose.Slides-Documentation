---
title: Lisensi
type: docs
weight: 120
url: /id/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk C++. Pastikan akses yang tidak terputus ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi saat presentasi dibuka atau disimpan dan membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya yang disematkan dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="primary" %}} 
Anda dapat mengunduh versi evaluasi **Aspose.Slides for C++** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.CPP/). Versi evaluasi menawarkan fungsionalitas yang sama dengan produk berlisensi. Bahkan, paket evaluasi identik dengan paket yang dibeli—hanya menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami menyarankan meninjau jenis langganan yang tersedia. Jika Anda memiliki pertanyaan, silakan menghubungi tim penjualan Aspose.

Setiap lisensi Aspose mencakup langganan satu tahun untuk pembaruan gratis, termasuk versi baru dan perbaikan bug yang dirilis selama periode tersebut. Baik Anda menggunakan versi berlisensi maupun versi evaluasi, Anda mendapatkan dukungan teknis gratis dan tidak terbatas.
{{% /alert %}} 

**Batasan Versi Evaluasi**

* Meskipun versi evaluasi Aspose.Slides (ketika tidak ada lisensi yang diterapkan) menyediakan fungsionalitas lengkap produk, ia menyisipkan watermark evaluasi di bagian atas dokumen selama operasi buka dan simpan.
* Ekstraksi teks terbatas pada satu slide saat menggunakan versi evaluasi.

{{% alert color="primary" %}} 
Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Untuk informasi lebih lanjut, lihat halaman [Cara Mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menerapkannya dengan menambahkan beberapa baris kode.
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan lainnya.
* File lisensi ditandatangani secara digital, sehingga tidak boleh diubah. Bahkan perubahan tidak sengaja—seperti menambahkan baris baru—akan membuat file tidak valid.
* Aspose.Slides for C++ biasanya mencari file lisensi di lokasi berikut:
  * Jalur yang secara eksplisit ditentukan dalam kode Anda
  * Folder yang berisi DLL komponen (disertakan dalam Aspose.Slides)
  * Folder yang berisi assembly yang memanggil DLL komponen
* Untuk menghindari batasan versi evaluasi, Anda harus mengatur lisensi sebelum menggunakan Aspose.Slides. Lisensi hanya perlu diatur satu kali per aplikasi atau proses.

## **Terapkan Lisensi**

Lisensi dapat dimuat dari **file**, **stream**, atau **sumber daya yang disematkan**.

{{% alert color="primary" %}}
Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.license/) untuk operasi lisensi.
{{% /alert %}} 

{{% alert color="warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **File**

Cara termudah untuk mengatur lisensi adalah menempatkan file lisensi di folder yang sama dengan DLL komponen (disertakan dalam Aspose.Slides) dan hanya menyebutkan nama file, tanpa jalur.

Kode C++ berikut menunjukkan cara mengatur file lisensi:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 
Jika Anda menempatkan file lisensi di direktori yang berbeda, maka saat memanggil metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/), nama file pada akhir jalur eksplisit yang diberikan harus persis cocok dengan nama file lisensi Anda.

Sebagai contoh, jika Anda mengganti nama file lisensi menjadi *Aspose.Slides.lic.xml*, Anda harus memberikan jalur lengkap yang berakhir dengan *Aspose.Slides.lic.xml* ke metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) dalam kode Anda.
{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari sebuah stream. Kode C++ berikut menunjukkan cara menerapkan lisensi dari stream:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah diatur dengan benar, Anda dapat memvalidasinya. Kode C++ berikut menunjukkan cara memvalidasi lisensi:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Keamanan Thread**

{{% alert title="Note" color="warning" %}} 
Metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) **tidak aman untuk thread**. Jika Anda perlu memanggil metode ini dari beberapa thread secara bersamaan, disarankan menggunakan primitif sinkronisasi (seperti lock) untuk mencegah potensi masalah.
{{% /alert %}}

## **FAQ**

**Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui lisensi.