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
description: "Terapkan, kelola, dan selesaikan masalah lisensi di Aspose.Slides untuk Android via Java. Pastikan akses tak terputus ke semua fitur dengan panduan lisensi kami."
---
## **Gambaran Umum**

Aspose.Slides dapat digunakan dalam mode evaluasi atau dengan lisensi yang valid. Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi, tetapi menambahkan watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan dan memotong teks yang dibaca kode Anda dari presentasi.

Artikel ini menjelaskan cara kerja lisensi di Aspose.Slides dan cara menerapkan lisensi sebelum menggunakan perpustakaan. Lisensi dapat dimuat dari file, aliran, atau sumber daya tertanam dengan menggunakan kelas [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). Artikel ini juga menunjukkan cara memvalidasi apakah lisensi telah diterapkan dengan benar.

## **Evaluasi Aspose.Slides**

{{% alert color="info" title="Note" %}}
Anda dapat mengunduh versi evaluasi **Aspose.Slides for Android via Java** dari [halaman unduhan](https://releases.aspose.com/slides/androidjava/). Versi evaluasi menyediakan fungsionalitas yang sama dengan versi berlisensi produk. Paket evaluasi sama dengan paket yang dibeli. Versi evaluasi cukup menjadi berlisensi setelah Anda menambahkan beberapa baris kode (untuk menerapkan lisensi).
Setelah Anda puas dengan evaluasi **Aspose.Slides**, Anda dapat [membeli lisensi](https://purchase.aspose.com/pricing/slides/android-java/). Kami menyarankan Anda meninjau berbagai jenis langganan. Jika Anda memiliki pertanyaan, hubungi tim penjualan Aspose.
Setiap lisensi Aspose dilengkapi dengan langganan satu tahun untuk peningkatan gratis ke versi baru atau perbaikan yang dirilis selama periode langganan. Pengguna dengan produk berlisensi (atau bahkan versi evaluasi) mendapatkan dukungan teknis gratis dan tanpa batas.
{{% /alert %}}

**Batasan versi evaluasi**

* Versi evaluasi (tanpa lisensi yang ditentukan) menyediakan fungsionalitas produk penuh, tetapi menambahkan kotak teks watermark evaluasi pada setiap slide dari setiap presentasi yang disimpan.
* Teks yang dibaca kode Anda dari sebuah presentasi dipotong ke beberapa karakter pertama, diikuti dengan pemberitahuan tentang batasan evaluasi. Teks yang ditulis kode Anda disimpan secara lengkap.

{{% alert color="info" title="Note" %}}
Untuk menguji Aspose.Slides tanpa batasan, Anda dapat meminta **Lisensi Sementara 30 Hari**. Lihat halaman [How to get a Temporary License](https://purchase.aspose.com/temporary-license) untuk informasi lebih lanjut.
{{% /alert %}}

## **Lisensi di Aspose.Slides**

* Versi evaluasi menjadi berlisensi setelah Anda membeli lisensi dan menambahkan beberapa baris kode (untuk menerapkan lisensi).
* Lisensi adalah file XML teks biasa yang berisi detail seperti nama produk, jumlah pengembang yang dilisensikan, tanggal kedaluwarsa langganan, dan sebagainya. 
* File lisensi ditandatangani secara digital, sehingga Anda tidak boleh memodifikasinya. Bahkan penambahan baris kosong secara tidak sengaja ke isi file akan membuatnya tidak valid.
* Aspose.Slides for Android via Java biasanya mencari lisensi di lokasi berikut:
  * Jalur eksplisit
  * Folder yang berisi Aspose.Slides.jar
* Untuk menghindari batasan yang terkait dengan versi evaluasi, Anda perlu menetapkan lisensi sebelum menggunakan **Aspose.Slides**. Anda hanya perlu menetapkan lisensi sekali per aplikasi atau proses.

## **Menerapkan Lisensi**

Lisensi dapat dimuat dari **file** atau **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides menyediakan kelas [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) untuk operasi lisensi.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Lisensi baru hanya dapat mengaktifkan Aspose.Slides dengan versi 21.4 atau yang lebih baru. Versi sebelumnya menggunakan sistem lisensi yang berbeda dan tidak akan mengenali lisensi ini.
{{% /alert %}}

### **File**

Metode termudah untuk menetapkan lisensi adalah dengan menempatkan file lisensi di folder yang berisi Aspose.Slides.jar atau jar aplikasi Anda.

{{% alert color="info" title="Note" %}}
Di Android, perpustakaan dan aplikasi Anda dikemas ke dalam APK, sehingga tidak ada folder yang berisi file JAR perpustakaan, dan jalur relatif seperti *Aspose.Slides.Android.via.Java.lic* tidak mengarah ke file di aplikasi Anda. Tambahkan file lisensi ke aset aplikasi Anda dan muat dari aliran, seperti yang ditunjukkan di [Stream from App Assets](#stream-from-app-assets).
{{% /alert %}}

Kode Java ini memperlihatkan cara menetapkan file lisensi:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan jalur file lisensi
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Jika Anda menempatkan file lisensi di direktori berbeda, saat memanggil metode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) , nama file lisensi di akhir jalur yang ditentukan harus sama dengan nama file lisensi Anda.

Sebagai contoh, Anda dapat mengubah nama file lisensi menjadi *Aspose.Slides.Android.via.Java.lic.xml*. Kemudian, dalam kode Anda, Anda harus memberi jalur ke file (yang berakhir dengan *Aspose.Slides.Android.via.Java.lic.xml*) ke metode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Stream**

Anda dapat memuat lisensi dari aliran. Kode Java ini memperlihatkan cara menerapkan lisensi dari aliran:

``` java
// Membuat instance kelas License
com.aspose.slides.License license = new com.aspose.slides.License();

// Menetapkan lisensi melalui aliran
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream from App Assets**

Di aplikasi Android, letakkan file lisensi di folder *assets* modul aplikasi, *app/src/main/assets*, sehingga file tersebut menjadi bagian dari APK. Buka file dengan metode [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) dan berikan aliran ke metode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). Kode dijalankan di dalam sebuah `Activity`, misalnya di metode `onCreate`, sebelum aplikasi menggunakan Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Nama file yang diberikan ke metode [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) bersifat relatif terhadap folder *assets*. Jika file tidak ada di sana, kode akan mencatat kesalahan, dan Aspose.Slides tetap berada dalam mode evaluasi. Untuk memeriksa apakah lisensi telah diterapkan, lihat [Validating a License](#validating-a-license).

## **Validating a License**

Untuk memeriksa apakah lisensi telah ditetapkan dengan benar, Anda dapat memvalidasinya. Kode Java ini memperlihatkan cara memvalidasi lisensi:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Keamanan Thread**

{{% alert color="warning" title="Warning" %}}
Metode [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) tidak aman untuk thread. Jika metode ini harus dipanggil secara bersamaan dari banyak thread, Anda mungkin ingin menggunakan primitif sinkronisasi (seperti kunci) untuk menghindari masalah.
{{% /alert %}}

## **FAQ**

### Apakah saya dapat menerapkan lisensi di lingkungan yang sepenuhnya offline (tanpa akses internet)?

Ya. Validasi lisensi dilakukan secara lokal menggunakan file lisensi; tidak diperlukan koneksi internet.

### Apa yang terjadi setelah langganan satu tahun berakhir? Apakah perpustakaan berhenti berfungsi?

Tidak. Lisensi bersifat permanen: Anda dapat terus menggunakan versi yang dirilis sebelum tanggal berakhirnya langganan Anda; Anda hanya tidak akan memenuhi syarat untuk menggunakan rilis yang lebih baru tanpa memperbarui.