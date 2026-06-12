---
title: Lisensi
type: docs
weight: 90
url: /id/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Android via Java. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi kami."
---
## **Overview**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi saat presentasi dibuka atau disimpan serta membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan bagaimana menerapkan lisensi sebelum menggunakan pustaka. Lisensi dapat dimuat dari file, stream, atau sumber daya yang disematkan dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluate Aspose.Slides**

{{% alert color="primary" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Android via Java** dari [download page](https://releases.aspose.com/slides/id/androidjava/). Versi evaluasi menyediakan fungsi yang sama dengan versi berlisensi dari produk ini. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi secara sederhana menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [purchase a license](https://purchase.aspose.com/buy). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi (atau bahkan versi evaluasi) mendapatkan dukungan teknis gratis dan tak terbatas.

{{% /alert %}} 

**Evaluation version limitations**

* Meskipun versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsionalitas produk secara penuh, ia menyisipkan watermark evaluasi di bagian atas dokumen saat operasi buka dan simpan. 
* Anda dibatasi hanya satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **30-Day Temporary License**. Lihat halaman [How to get a Temporary License](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, sehingga Anda tidak boleh memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.
* Aspose.Slides for Android via Java biasanya mencari lisensi di lokasi berikut:
  * Path eksplisit
  * Folder yang berisi Aspose.Slides.jar
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

## **Applying a License**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="primary" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/license/) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" %}}

Lisensi baru hanya dapat mengaktifkan Aspose.Slides pada versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**

Metode paling mudah untuk mengatur lisensi mengharuskan Anda menempatkan file lisensi di folder yang berisi Aspose.Slides.jar atau jar aplikasi Anda.

Kode Java berikut menunjukkan cara mengatur file lisensi:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan jalur file lisensi
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Jika Anda menempatkan file lisensi di direktori yang berbeda, saat memanggil metode [SetLicense](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), nama file lisensi di akhir path eksplisit yang ditentukan harus sama dengan file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.Android.via.Java.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan path ke file (yang diakhiri dengan *Aspose.Slides.Android.via.Java.lic.xml*) ke metode [SetLicense](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari stream. Kode Java berikut menunjukkan cara menerapkan lisensi dari stream:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan lisensi melalui stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validating a License**

Untuk memeriksa apakah lisensi telah diatur dengan benar, Anda dapat memvalidasinya. Kode Java berikut menunjukkan cara memvalidasi lisensi:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

Metode [SetLicense](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) tidak aman untuk thread. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti lock) untuk menghindari masalah. 

{{% /alert %}}

## **FAQ**

**Can I apply the license in a completely offline environment (no internet access)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

**What happens after the one-year subscription expires? Will the library stop working?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal akhir langganan Anda; Anda hanya tidak dapat menggunakan rilis yang lebih baru tanpa memperbarui.