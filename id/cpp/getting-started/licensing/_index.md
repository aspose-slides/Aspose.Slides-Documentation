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
- berkas lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Menerapkan, mengelola, dan memecahkan masalah lisensi di Aspose.Slides untuk C++. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi ketika presentasi dibuka atau disimpan dan membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari berkas, aliran, atau sumber daya tersemat dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="info" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for C++** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.CPP/). Versi evaluasi menawarkan fungsionalitas yang sama dengan produk berlisensi. Faktanya, paket evaluasi identik dengan yang dibeli—hanya menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami menyarankan meninjau jenis langganan yang tersedia. Jika Anda memiliki pertanyaan, silakan hubungi tim penjualan Aspose.

Setiap lisensi Aspose mencakup langganan satu tahun untuk peningkatan gratis, termasuk versi baru dan perbaikan bug yang dirilis selama periode tersebut. Baik Anda menggunakan versi berlisensi maupun evaluasi, Anda menerima dukungan teknis gratis dan tak terbatas.

{{% /alert %}} 

**Batasan Versi Evaluasi**

* Meskipun versi evaluasi Aspose.Slides (ketika tidak ada lisensi yang diterapkan) menyediakan fungsionalitas penuh produk, ia menyisipkan watermark evaluasi di bagian atas dokumen saat operasi buka dan simpan.
* Ekstraksi teks dibatasi hingga satu slide ketika menggunakan versi evaluasi.

{{% alert color="info" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Untuk informasi lebih lanjut, lihat halaman [Cara Mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menerapkannya dengan menambahkan beberapa baris kode.
* Lisensi adalah berkas XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan lain-lain.
* Berkas lisensi ditandatangani secara digital, sehingga tidak boleh diubah. Bahkan perubahan tidak sengaja—seperti menambahkan baris baru—akan membuat berkas tidak valid.
* Aspose.Slides for C++ biasanya mencari berkas lisensi di lokasi berikut:
  * Jalur yang secara eksplisit ditentukan dalam kode Anda
  * Folder yang berisi DLL komponen (termasuk dalam Aspose.Slides)
  * Folder yang berisi assembly yang memanggil DLL komponen
* Untuk menghindari batasan versi evaluasi, Anda harus menetapkan lisensi sebelum menggunakan Aspose.Slides. Lisensi hanya perlu disetel sekali per aplikasi atau proses.

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **berkas**, **aliran**, atau **sumber daya tersemat**.

{{% alert color="info" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.license/) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" %}}

Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **Berkas**

Cara termudah untuk menetapkan lisensi adalah dengan menempatkan berkas lisensi di folder yang sama dengan DLL komponen (termasuk dalam Aspose.Slides) dan menyebutkan hanya nama berkas, tanpa jalur.

Berikut kode C++ yang menunjukkan cara menetapkan berkas lisensi:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Jika Anda menempatkan berkas lisensi di direktori lain, maka saat memanggil metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/), nama berkas di akhir jalur eksplisit yang ditentukan harus persis cocok dengan nama berkas lisensi Anda.

Sebagai contoh, jika Anda mengganti nama berkas lisensi menjadi *Aspose.Slides.lic.xml*, Anda harus memberikan jalur lengkap yang berakhir dengan *Aspose.Slides.lic.xml* ke metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) dalam kode Anda.

{{% /alert %}}

### **Aliran**

Anda dapat memuat lisensi dari aliran. Berikut kode C++ yang menunjukkan cara menerapkan lisensi dari aliran:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah disetel dengan benar, Anda dapat memvalidasinya. Berikut kode C++ yang menunjukkan cara memvalidasi lisensi:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Keamanan Thread**

{{% alert title="Catatan" color="warning" %}} 

Metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) **tidak aman untuk thread**. Jika Anda perlu memanggil metode ini dari beberapa thread secara bersamaan, disarankan menggunakan primitif sinkronisasi (seperti kunci) untuk mencegah potensi masalah.

{{% /alert %}}

## **FAQ**

### Apakah saya dapat menerapkan lisensi dalam lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan berkas lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan berhenti berfungsi?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhir langganan Anda; Anda hanya tidak berhak menggunakan rilis baru tanpa memperbarui lisensi.