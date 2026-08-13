---
title: Lisensi
type: docs
weight: 90
url: /id/java/licensing/
keywords:
- lisensi
- lisensi sementara
- menetapkan lisensi
- menggunakan lisensi
- memvalidasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Menerapkan, mengelola, dan memecahkan masalah lisensi di Aspose.Slides untuk Java. Pastikan akses tanpa gangguan ke semua fitur dengan panduan lisensi langkah demi langkah kami."
---
## **Overview**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, namun menambahkan watermark evaluasi saat presentasi dibuka atau disimpan serta membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan bagaimana menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya tertanam dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluate Aspose.Slides**

{{% alert color="info" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Java** dari [halaman unduhan](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi produk. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi hanya menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami sarankan Anda meninjau berbagai jenis langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose disertai dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi (atau bahkan versi evaluasi) mendapatkan dukungan teknis gratis dan tidak terbatas.

{{% /alert %}} 

**Batasan versi evaluasi**

* Sementara versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan semua fungsionalitas produk, ia menyisipkan watermark evaluasi di bagian atas dokumen pada operasi buka dan simpan. 
* Anda dibatasi satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="info" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [Cara mendapatkan Lisensi Sementara](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* Sebuah versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh memodifikasi file tersebut. Bahkan penambahan baris baru tambahan secara tidak sengaja pada isi file akan membuatnya tidak valid.
* Aspose.Slides for Java biasanya mencari lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi Aspose.Slides.jar
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

{{% alert color="info" %}} 

Anda mungkin ingin melihat [Metered Licensing](/slides/id/java/metered-licensing/).

{{% /alert %}} 


## **Applying a License**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="info" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/id/java/com.aspose.slides/License) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" %}}

Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**

Metode paling mudah untuk menetapkan lisensi adalah dengan menempatkan file lisensi di folder yang berisi Aspose.Slides.jar atau jar aplikasi Anda.

Kode Java ini menunjukkan cara menetapkan file lisensi:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan jalur file lisensi
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Jika Anda menempatkan file lisensi di direktori yang berbeda, saat memanggil metode [SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.lang.String-) , nama file lisensi di akhir jalur eksplisit yang Anda tentukan harus sama dengan file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.Java.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan jalur ke file (yang diakhiri dengan *Aspose.Slides.Java.lic.xml*) ke metode [SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari stream. Kode Java ini menunjukkan cara menerapkan lisensi dari stream:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan lisensi melalui stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Jika Anda menggunakan Aspose.Slides for PHP melalui Java, Anda dapat menetapkan lisensi melalui jembatan PHP/Java. Jembatan ini memungkinkan Anda menggunakan kelas Java dalam sintaks PHP. Untuk informasi lebih lanjut, lihat [License in PHP](/slides/id/php-java/licensing/).

## **Validating a License**

Untuk memeriksa apakah lisensi telah ditetapkan dengan benar, Anda dapat memvalidasinya. Kode Java ini menunjukkan cara memvalidasi lisensi:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

Metode [SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.io.InputStream-) tidak thread-safe. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti kunci) untuk menghindari masalah. 

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### What happens after the one-year subscription expires? Will the library stop working?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal akhir langganan Anda; Anda hanya tidak akan memenuhi syarat untuk menggunakan rilis yang lebih baru tanpa memperbarui.