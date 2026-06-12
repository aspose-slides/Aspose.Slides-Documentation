---
title: Lisensi
type: docs
weight: 90
url: /id/java/licensing/
keywords:
- "lisensi"
- "lisensi sementara"
- "atur lisensi"
- "gunakan lisensi"
- "validasi lisensi"
- "file lisensi"
- "versi evaluasi"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Java. Pastikan akses tanpa gangguan ke fitur lengkap dengan panduan lisensi langkah demi langkah kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsi yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi saat presentasi dibuka atau disimpan dan membatasi ekstraksi teks ke satu slide.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, stream, atau sumber daya tersemat dengan menggunakan kelas `License`. Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="primary" %}} 

Anda dapat mengunduh versi evaluasi **Aspose.Slides for Java** dari[halaman unduhan](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi produk ini. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi secara sederhana menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).

Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/buy). Kami menyarankan Anda meninjau berbagai tipe langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.

Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi (atau bahkan versi evaluasi) mendapatkan dukungan teknis gratis dan tanpa batas.

{{% /alert %}} 

**Batasan versi evaluasi**

* Meskipun versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsi produk secara penuh, ia menambahkan watermark evaluasi di bagian atas dokumen saat operasi membuka atau menyimpan. 
* Anda dibatasi hanya satu slide saat mengekstrak teks dari slide presentasi.

{{% alert color="primary" %}} 

Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman[How to get a Temporary License](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.

{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, sehingga Anda tidak boleh memodifikasi file tersebut. Bahkan penambahan baris kosong secara tidak sengaja pada isi file akan membuatnya tidak sah.
* Aspose.Slides untuk Java biasanya memeriksa lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi Aspose.Slides.jar
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menyetel lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menyetel lisensi sekali per aplikasi atau proses.

{{% alert color="primary" %}} 

Mungkin Anda ingin melihat[Metered Licensing](/slides/id/java/metered-licensing/).

{{% /alert %}} 


## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="primary" %}}

Aspose.Slides menyediakan kelas[License](https://reference.aspose.com/slides/id/java/com.aspose.slides/License) untuk operasi lisensi.

{{% /alert %}} 

{{% alert color="warning" %}}

Lisensi baru dapat mengaktifkan Aspose.Slides hanya dengan versi 21.4 atau lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.

{{% /alert %}}

### **File**

Metode termudah untuk menyetel lisensi mengharuskan Anda menempatkan file lisensi di folder yang berisi Aspose.Slides.jar atau jar aplikasi Anda.

Kode Java berikut menunjukkan cara menyetel file lisensi:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan jalur file lisensi
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Jika Anda menempatkan file lisensi di direktori yang berbeda, ketika Anda memanggil metode[SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.lang.String-) , nama file lisensi pada akhir jalur eksplisit yang ditentukan harus sama dengan file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi*Aspose.Slides.Java.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberikan path ke file (berakhir dengan*Aspose.Slides.Java.lic.xml*) ke metode[SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.lang.String-).

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

Jika Anda menggunakan Aspose.Slides untuk PHP melalui Java, Anda dapat menyetel lisensi melalui jembatan PHP/Java. Jembatan ini memungkinkan Anda menggunakan kelas Java dalam sintaks PHP. Untuk informasi lebih lanjut, lihat[License in PHP](/slides/id/php-java/licensing/).

## **Validasi Lisensi**

Untuk memeriksa apakah lisensi telah disetel dengan benar, Anda dapat memvalidasinya. Kode Java berikut menunjukkan cara memvalidasi lisensi:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Keamanan Thread**

{{% alert title="Note" color="warning" %}} 

Metode[SetLicense](https://reference.aspose.com/slides/id/java/com.aspose.slides/License#setLicense-java.io.InputStream-) tidak aman untuk thread. Jika metode ini harus dipanggil secara simultan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti lock) untuk menghindari masalah. 

{{% /alert %}}

## **FAQ**

**Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?**

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

**Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan akan berhenti berfungsi?**

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan dapat menggunakan rilis yang lebih baru tanpa memperbarui.