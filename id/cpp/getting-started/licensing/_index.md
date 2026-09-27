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
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk C++. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan dan memotong teks yang dibaca kode Anda dari presentasi.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan pustaka. Lisensi dapat dimuat dari file atau stream dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="info" title="Note" %}}

Anda dapat mengunduh versi evaluasi **Aspose.Slides for C++** dari [halaman unduhan NuGet-nya](https://www.nuget.org/packages/Aspose.Slides.Cpp/) atau, sebagai paket ZIP, dari [halaman unduhan](https://releases.aspose.com/slides/id/cpp/). Versi evaluasi menawarkan fungsionalitas yang sama dengan produk berlisensi. Faktanya, paket evaluasi identik dengan yang dibeli—hanya menjadi berlisensi setelah Anda menambahkan beberapa baris kode untuk menerapkan lisensi.

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/id/cpp/). Kami menyarankan meninjau jenis-jenis langganan yang tersedia. Jika Anda memiliki pertanyaan, silakan menghubungi tim penjualan Aspose.

Setiap lisensi Aspose mencakup langganan satu tahun untuk peningkatan gratis, termasuk versi baru dan perbaikan bug yang dirilis selama periode tersebut. Baik Anda menggunakan versi berlisensi maupun versi evaluasi, Anda memperoleh dukungan teknis gratis dan tak terbatas.

{{% /alert %}} 

**Batasan Versi Evaluasi**

* Versi evaluasi (tanpa lisensi yang ditentukan) menyediakan fungsionalitas produk penuh, tetapi menambahkan kotak teks watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan.
* Teks yang dibaca kode Anda dari sebuah presentasi dipotong pada beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Untuk informasi lebih lanjut, lihat halaman [Cara Mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menerapkannya dengan menambahkan beberapa baris kode.
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang memiliki lisensi, tanggal kedaluwarsa langganan, dan lainnya.
* File lisensi ditandatangani secara digital, sehingga tidak boleh diubah. Bahkan perubahan tidak sengaja—seperti menambahkan jeda baris—akan membuat file tidak valid.
* Ketika Anda memberikan nama file tanpa folder, Aspose.Slides for C++ mencari file lisensi hanya di direktori kerja saat ini. Ia tidak mencari di folder eksekutabel Anda atau perpustakaan Aspose.Slides, jadi berikan jalur lengkap bila file lisensi disimpan di tempat lain.
* Untuk menghindari batasan versi evaluasi, Anda harus mengatur lisensi sebelum menggunakan Aspose.Slides. Lisensi hanya perlu diatur satu kali per aplikasi atau proses.

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**

Cara termudah untuk mengatur lisensi adalah menempatkan file lisensi di direktori kerja program Anda dan hanya menyebutkan nama file, tanpa jalur. Jika tidak, sebutkan jalur lengkap ke file.

Kode C++ berikut menerapkan file lisensi *Aspose.Slides.lic* dari direktori kerja program:

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

Jika lisensi valid, [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) mengembalikan kontrol dan program berakhir tanpa output; mulai saat itu, Aspose.Slides berfungsi tanpa batasan evaluasi. Jika file tidak berada di direktori kerja, metode ini melempar [FileNotFoundException](https://reference.aspose.com/slides/id/cpp/system.io/filenotfoundexception/) dengan pesan *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Contoh tidak menangani pengecualian, sehingga program berhenti.

{{% alert color="warning" title="Warning" %}}

Jika Anda menempatkan file lisensi di direktori lain, maka saat memanggil metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/), nama file di akhir jalur eksplisit yang diberikan harus persis sama dengan nama file lisensi Anda.

Sebagai contoh, jika Anda mengganti nama file lisensi menjadi *Aspose.Slides.lic.xml*, Anda harus memberikan jalur lengkap yang diakhiri dengan *Aspose.Slides.lic.xml* ke metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) dalam kode Anda.

{{% /alert %}}

### **Stream**

Muat lisensi dari stream ketika program Anda tidak menyimpan lisensi sebagai file yang dapat dinamai, misalnya ketika lisensi dibaca dari basis data. [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) menerima setiap [Stream](https://reference.aspose.com/slides/id/cpp/system.io/stream/) yang berisi lisensi. Untuk memperpendek contoh, kode C++ berikut membuka *Aspose.Slides.lic* di direktori kerja dengan [File::OpenRead](https://reference.aspose.com/slides/id/cpp/system.io/file/openread/) dan menerapkan lisensi dari stream tersebut:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Lisensi yang valid memberikan hasil yang sama seperti pada contoh file. Jika file tidak ada, [File::OpenRead](https://reference.aspose.com/slides/id/cpp/system.io/file/openread/) melempar [FileNotFoundException](https://reference.aspose.com/slides/id/cpp/system.io/filenotfoundexception/) sebelum lisensi diterapkan, dan program berhenti.

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah diatur dengan benar, panggil [License::IsLicensed](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/islicensed/). Metode ini mengembalikan `true` hanya setelah lisensi yang sah diterapkan, dan `false` sebelum itu. Kode C++ berikut menerapkan file lisensi dari direktori kerja dan kemudian memeriksanya:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Dengan lisensi yang valid, program mencetak *License is good!*. Jika file tidak ada atau bukan file lisensi, [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) melempar pengecualian sebelum pemeriksaan, dan program berhenti tanpa mencetak apa pun. Jika file adalah lisensi yang tanda tangannya tidak cocok, misalnya karena telah diedit, SetLicense mengembalikan tanpa error tetapi `IsLicensed` mengembalikan `false`, sehingga tidak ada yang dicetak dan Aspose.Slides tetap dalam mode evaluasi.

## **Keamanan Thread**

{{% alert color="warning" title="Warning" %}}

Metode [License::SetLicense](https://reference.aspose.com/slides/id/cpp/aspose.slides/license/setlicense/) **tidak aman untuk thread**. Jika Anda perlu memanggil metode ini dari beberapa thread secara bersamaan, disarankan menggunakan primitif sinkronisasi (seperti lock) untuk mencegah potensi masalah.

{{% /alert %}}

## **FAQ**

### Bisakah saya menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal akhir langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui langganan.