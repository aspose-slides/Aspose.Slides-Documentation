---
title: "Pengaturan Demo"
type: docs
weight: 70
url: /id/jasperreports/demos-setup/
description: "Siapkan proyek demo dari unduhan Aspose.Slides for JasperReports, ubah kelas exporter yang mereka gunakan, dan bangun mereka dengan Ant."
---
## **Apa itu demo**

Folder *samples* dari unduhan Aspose.Slides for JasperReports memiliki delapan proyek demo: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* dan *xmldatasource*. Mereka adalah demo JasperReports standar, yang diubah untuk menambahkan target build `ppt` yang mengekspor laporan yang terisi ke PPT. Unduhan tidak berisi presentasi yang diekspor; Anda membuatnya dengan membangun sebuah demo.

## **Ubah kelas exporter sebelum Anda membangun**

Sebagai paket standar, kode Java demo menggunakan `com.aspose.slides.jasperreports.JRPptExporter`, sebuah kelas yang tidak terdapat dalam jar saat ini, sehingga demo tidak dapat dikompilasi. Di kelas aplikasi demo (misalnya, *ShapesApp.java* dalam demo *shapes*), gantilah `JRPptExporter` dengan `ASPptExporter`, exporter PPT di paket yang sama. Demo *fonts* mengimpor seluruh paket, jadi hanya nama kelas dalam kode yang berubah.

Demo juga menggunakan kelas JasperReports yang dihapus pada versi JasperReports berikutnya, seperti `JExcelApiExporter` dan `JRExporterParameter.FONT_MAP`. Dengan perubahan di atas, demo dapat dikompilasi sebagai berikut:

| Versi JasperReports | Demo yang dapat dikompilasi |
| :- | :- |
| 5.5.1 | semua delapan |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* dan *xmldatasource* |
| 6.16.0 | *charts* |

## **Membangun demo**

*build.xml* tiap demo mengharapkan tata letak folder proyek JasperReports: ia mengompilasi terhadap *../../../build/classes* dan jar di *../../../lib*, relatif terhadap folder demo.

1. Salin folder demo ke *demo/samples* dalam folder proyek JasperReports Anda.
2. Salin *aspose.slides.jasperreports.library-xx.x.jar* dari subfolder *lib* unduhan yang cocok dengan versi JasperReports Anda ke folder *lib* proyek JasperReports. Lihat [Installing Aspose.Slides for JasperReports](/slides/id/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Tempatkan jar versi JasperReports Anda dan jar yang menjadi dependensinya di folder *lib* yang sama. Selain file demo, *build.xml* hanya menambahkan *build/classes* dan jar di bawah *lib* ke classpath, dan *build/classes* berisi kelas JasperReports hanya setelah Anda mengompilasi JasperReports dari sumber.
4. Demo *charts*, *subreport* dan *text* membaca basis data contoh HSQLDB JasperReports (`jdbc:hsqldb:hsql://localhost`), jadi mulailah servernya terlebih dahulu, seperti dijelaskan dalam *samples/Readme.txt* unduhan. Demo lainnya tidak memerlukan basis data.
5. Di folder demo, kompilasikan aplikasi, kompilasikan desain laporan, isi laporan, dan ekspor ke PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Target `ppt` menulis presentasi di samping laporan yang terisi, dengan nama yang sama dengan laporan (misalnya, *LandscapeReport.ppt*).

Dua demo memerlukan lebih dari langkah-langkah di atas:

- Demo *images* memuat satu gambar dari `http://jasperreports.sourceforge.net/jasperreports.png` saat mengekspor. Alamat itu kini mengalihkan ke HTTPS, sehingga langkah `ppt` tidak menghasilkan presentasi hingga Anda mengubah alamat menjadi `https://` dalam *ImagesReport.jrxml*. Dengan JasperReports 6.4.0, mengekspor gambar tersebut gagal bahkan melalui HTTPS.
- Laporan *xmldatasource* menggunakan font Arial. Pada sistem tanpa Arial, `ant fill` mencetak bahwa font "tidak tersedia untuk JVM" dan tidak menghasilkan laporan terisi, sehingga `ant ppt` tidak memiliki apa pun untuk diekspor. Build tetap melaporkan keberhasilan, jadi periksa output setiap langkah.