---
title: Menginstal Aspose.Slides untuk JasperReports
type: docs
weight: 40
url: /id/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Pilih jar Aspose.Slides untuk JasperReports yang sesuai dengan versi JasperReports Anda, dan tambahkan ke JasperReports, proyek Maven, atau JasperReports Server."
---
## **Pilih jar untuk versi JasperReports Anda**

Aspose.Slides for JasperReports didistribusikan sebagai file ZIP pada [halaman unduhan](https://releases.aspose.com/slides/id/jasperreport/). Folder *lib*-nya memiliki satu subfolder untuk tiap rentang versi JasperReports. Ambil jar dari subfolder yang mencakup versi JasperReports yang Anda gunakan:

| Versi JasperReports | Subfolder *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Tidak ada subfolder untuk JasperReports 6.17.0 atau lebih baru, termasuk JasperReports 7. Subfolder *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* tidak berisi jar, hanya catatan bahwa dukungan untuk versi tersebut berakhir di Aspose.Slides for JasperReports 17.6.

Setiap subfolder berisi dua jar; *xx.x* dalam nama mereka adalah versi produk:

- *aspose.slides.jasperreports.library-xx.x.jar* berisi eksportir untuk JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` dan `ASHtmlExporter`) serta kelas `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* berisi aksi ekspor untuk JasperReports Server. Jar ini dibangun dari library jar, sehingga server selalu membutuhkan kedua jar dari subfolder yang sama.

## **Tambahkan jar library ke JasperReports atau aplikasi Anda**

Salin *aspose.slides.jasperreports.library-xx.x.jar* dari subfolder yang sesuai ke folder *lib* JasperReports atau ke classpath aplikasi Anda. Aplikasi Anda kemudian dapat membuat eksportir dalam kode.

{{% alert color="info" title="Note" %}}
Pada Linux, JasperReports memerlukan fontconfig dan setidaknya satu font terpasang untuk mengisi laporan. Tanpa font, proses pengisian gagal dengan kesalahan "Error initializing graphic environment".
{{% /alert %}}

## **Tambahkan jar library ke proyek Maven**

Jar tersedia dalam file ZIP, bukan dari repositori Maven. Untuk menggunakannya dalam build Maven, instal ke repositori Maven lokal Anda. Untuk versi 26.6, jalankan perintah berikut di folder yang berisi jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Kemudian tambahkan ke dependensi dalam *pom.xml*, bersama dengan versi JasperReports yang dicakup oleh subfolder jar:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

ID grup dan artefak adalah yang Anda pilih dalam perintah instalasi; mereka hanya perlu cocok. Proyek lengkap yang menggunakan JasperReports 6.16.0 ada di [Ekspor pertama Anda](/slides/id/jasperreports/#your-first-export).

## **Tambahkan jar ke JasperReports Server**

Salin kedua jar dari subfolder yang sesuai ke folder *WEB-INF/lib* aplikasi web JasperReports Server, kemudian daftarkan eksportir seperti dijelaskan di [Integrasi dengan JasperServer](/slides/id/jasperreports/integration-with-jasperserver/).