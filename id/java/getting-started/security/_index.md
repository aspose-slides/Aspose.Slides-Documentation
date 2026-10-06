---
title: Keamanan
type: docs
weight: 160
url: /id/java/security/
keywords:
- keamanan
- dependensi
- komponen pihak ketiga
- Maven
- tanda tangan JAR
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau bagaimana Aspose.Slides for Java memproses presentasi, apa yang ditambahkannya ke dependensi proyek Anda, cara memverifikasi berkas JAR, dan komponen pihak ketiga apa yang disertakannya."
---
## **Pendahuluan**

Artikel ini mengumpulkan informasi yang biasanya diperlukan untuk tinjauan keamanan sebuah aplikasi yang menggunakan Aspose.Slides for Java: bagaimana perpustakaan memproses presentasi, apa yang ditambahkan ke dependensi proyek Anda, cara memeriksa bahwa berkas JAR berasal dari Aspose, dan komponen pihak ketiga apa yang terdapat dalam berkas JAR.

## **Keamanan di Aspose.Slides**

Aspose menerapkan praktik terbaik saat mengembangkan produknya.

* Aspose.Slides for Java digunakan untuk membuat, memodifikasi, dan mengonversi presentasi. Ia tidak menjalankan skrip dalam presentasi. Aspose.Slides mengurai struktur presentasi dan memungkinkan kode Anda bekerja dengan model objek.
* Aspose.Slides berfungsi sebagai perpustakaan yang mengurai dan menafsirkan dokumen tanpa mengeksekusi kode jarak jauh. Semua produk Aspose berjalan di mesin Anda. Mereka tidak mengirim data apa pun ke Aspose. Satu-satunya pengecualian adalah [lisensi bermeter](/slides/id/java/metered-licensing/): jika Anda menggunakannya, hanya informasi penggunaan API Anda yang diproses.
* Komponen Aspose berjalan dalam konteks pengguna yang sama dengan aplikasi biasa. Oleh karena itu, komponen Aspose tidak menimbulkan risiko bagi sumber daya sistem yang penting. Lebih lanjut, ketika sebuah komponen Aspose membuka dokumen, makro tidak dijalankan secara otomatis.

## **Dependensi Maven**

Artefak Maven Aspose.Slides for Java, `com.aspose:aspose-slides`, tidak mendeklarasikan dependensi apa pun: berkas POM‑nya hanya berisi koordinat artefak itu sendiri. Ketika Anda menambahkannya ke sebuah proyek, Maven menambahkan satu berkas JAR ini dan tidak ada yang lain. Untuk menampilkan setiap artefak yang diselesaikan proyek Anda, termasuk dependensi transitif, jalankan perintah berikut di folder proyek:

```bash
mvn dependency:tree
```

Pada proyek dari [Instalasi](/slides/id/java/installation/), output menampilkan Aspose.Slides sebagai satu‑satunya dependensi:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verifikasi Berkas JAR**

Aspose menandatangani berkas JAR. Untuk memeriksa tanda tangan, jalankan alat `jarsigner` dari JDK di folder yang berisi berkas JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Perintah akan mencetak `jar verified.` ketika tanda tangan valid dan tidak ada entri yang berubah sejak berkas ditandatangani. Pesan ini tidak menyebutkan penandatangan. Untuk memastikan bahwa Aspose yang menandatangani berkas, tambahkan opsi `-verbose` dan `-certs` dan periksa bahwa sertifikat penandatangan diterbitkan untuk `CN=ASPOSE PTY LTD`. Ketika Maven mengunduh berkas JAR, ia juga memeriksa checksum SHA‑1 yang dipublikasikan repositori di samping berkas.

## **Komponen Pihak Ketiga**

Aspose.Slides for Java mencakup kode dan data dari komponen pihak ketiga. Mereka merupakan bagian dari berkas JAR, bukan artefak Maven terpisah, sehingga `mvn dependency:tree` dan alat lain yang membaca dependensi Maven tidak menampilkannya. Berkas JAR berisi pemberitahuan *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, yang mencantumkan komponen dan lisensi mereka:

| Komponen | Lisensi yang tercantum dalam pemberitahuan |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | Lisensi gaya MIT |
| Mono | Lisensi MIT; beberapa bagian di bawah lisensi lain yang tercantum dalam pemberitahuan |
| RSWOP.ICM color profile | Syarat lisensi Microsoft |
| sRGB_v4_ICC_preference.icc color profile | Izin ICC untuk menggunakan, menyalin, dan mendistribusikan berkas tidak berubah |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Untuk mengekstrak pemberitahuan dari berkas JAR, jalankan alat `jar` dari JDK di folder yang berisi berkas JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Apakah Aspose.Slides for Java menggunakan paket eksternal?**

Tidak ada dependensi Maven, seperti yang ditunjukkan pada [Dependensi Maven](#maven-dependencies), tetapi ia menyertakan komponen pihak ketiga yang tercantum dalam [Komponen Pihak Ketiga](#third-party-components). Sertakan baik berkas JAR maupun komponen ini dalam tinjauan keamanan Anda.

**Apakah Aspose.Slides for Java memerlukan akses jaringan?**

Tidak. Pembuatan, penyimpanan, dan render presentasi dapat dilakukan pada sistem tanpa koneksi jaringan apa pun. Satu‑satunya fitur yang mengirim data ke Aspose adalah [lisensi bermeter](/slides/id/java/metered-licensing/), yang melaporkan penggunaan API.

**Apakah Aspose.Slides for Java berisi kode native?**

Tidak. Berkas JAR hanya berisi kelas dan sumber daya Java, sehingga tidak menambahkan perpustakaan native ke aplikasi Anda. Pada Linux, dukungan font runtime Java memerlukan perpustakaan fontconfig serta font dari sistem operasi; lihat [Persyaratan Sistem](/slides/id/java/system-requirements/#linux).