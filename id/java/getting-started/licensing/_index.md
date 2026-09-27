---
title: Lisensi
type: docs
weight: 90
url: /id/java/licensing/
keywords:
- lisensi
- lisensi sementara
- tetapkan lisensi
- gunakan lisensi
- validasi lisensi
- file lisensi
- versi evaluasi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Java. Pastikan akses tanpa gangguan ke semua fitur dengan panduan langkah demi langkah tentang lisensi kami."
---
## **Ikhtisar**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsi yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan dan memotong teks yang dibaca kode Anda melalui API.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan pustaka. Lisensi dapat dimuat dari file, stream, atau sumber daya yang disematkan dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="info" title="Note" %}}

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Java** dari [halaman unduhan](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Versi evaluasi menyediakan fungsi yang sama dengan versi berlisensi produk. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi akan menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/java/). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi (atau bahkan versi evaluasi) mendapatkan dukungan teknis gratis dan tidak terbatas.

{{% /alert %}} 

**Batasan versi evaluasi**

* Versi evaluasi (tanpa lisensi yang ditentukan) menyediakan fungsionalitas penuh produk, tetapi menambahkan kotak teks watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan.
* Teks yang dibaca kode Anda melalui API, termasuk teks yang baru saja diatur, dipotong ke beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [How to get a Temporary License](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.

{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya.
* File lisensi ditandatangani secara digital, jadi Anda tidak boleh memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak valid.
* Aspose.Slides for Java biasanya mencari lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi Aspose.Slides.jar
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

{{% alert color="info" title="Note" %}}

Anda mungkin ingin melihat [Metered Licensing](/slides/id/java/metered-licensing/).

{{% /alert %}} 

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**

Metode termudah untuk menetapkan lisensi memerlukan Anda menempatkan file lisensi di folder yang berisi Aspose.Slides.jar atau jar aplikasi Anda.

Kode Java berikut menunjukkan cara menetapkan file lisensi:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan jalur file lisensi
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Jika Anda menempatkan file lisensi di direktori yang berbeda, saat memanggil metode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) , nama file lisensi di akhir jalur yang ditentukan harus sama dengan nama file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.Java.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan jalur ke file (yang berakhir dengan *Aspose.Slides.Java.lic.xml*) ke metode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari stream. Kode Java berikut menunjukkan cara menerapkan lisensi dari stream:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan lisensi melalui stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Jika Anda menggunakan Aspose.Slides untuk PHP melalui Java, Anda dapat menetapkan lisensi melalui jembatan PHP/Java. Jembatan ini memungkinkan Anda menggunakan kelas Java dalam sintaks PHP. Untuk informasi lebih lanjut, lihat [License in PHP](/slides/id/php-java/licensing/).

## **Memvalidasi Lisensi**

Untuk memeriksa apakah lisensi telah ditetapkan dengan benar, Anda dapat memvalidasinya. Kode Java berikut menunjukkan cara memvalidasi lisensi:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Keamanan Thread**

{{% alert color="warning" title="Warning" %}}

Metode [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) tidak thread-safe. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti lock) untuk menghindari masalah.

{{% /alert %}}

## **FAQ**

### Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah pustaka akan berhenti berfungsi?

Tidak. Lisensi bersifat perpetual: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal akhir langganan Anda; Anda hanya tidak akan dapat menggunakan rilis terbaru tanpa memperbarui.