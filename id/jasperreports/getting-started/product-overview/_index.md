---
title: Gambaran Produk
type: docs
weight: 10
url: /id/jasperreports/product-overview/
description: "Pelajari apa yang dilakukan Aspose.Slides for JasperReports, versi JasperReports dan format output apa yang didukungnya, serta untuk apa dua jar tersebut."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Deskripsi Produk**

Aspose.Slides for JasperReports mengekspor laporan dari JasperReports ke presentasi PowerPoint, dalam aplikasi Java dan di JasperReports Server, tanpa Microsoft PowerPoint. Produk ini mendukung JasperReports 3.7.2 hingga 6.16.0, dengan jar terpisah untuk setiap rentang versi — lihat [Installing Aspose.Slides for JasperReports](/slides/id/jasperreports/installing-aspose-slides-for-jasperreports/).

Ini mengekspor laporan yang telah diisi ke empat format, satu slide atau halaman per halaman laporan:

- PPT – presentasi PowerPoint 97–2003
- PPTX – presentasi PowerPoint (Office Open XML)
- PDF
- HTML

Produk ini memiliki dua bagian:

- Jar perpustakaan menambahkan exporternya `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter`, dan `ASHtmlExporter` ke JasperReports Library.
- Jar server menyediakan aksi ekspor untuk keempat format yang sama, yang Anda daftarkan di JasperReports Server — lihat [Integration with JasperServer](/slides/id/jasperreports/integration-with-jasperserver/).

### **Contoh Output**

Exporter memperluas kelas exporter milik JasperReports sendiri dan digunakan dengan cara yang sama: berikan laporan yang telah diisi dan file output kepada mereka, lalu panggil `exportReport`. Untuk program lengkap yang mengisi laporan dan mengekspornya ke PPTX, lihat [Your first export](/slides/id/jasperreports/#your-first-export); untuk semua empat format, lihat [PPT, PPTX, PDF and HTML Export](/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/).

![Laporan yang diekspor ke presentasi tanpa lisensi, dengan watermark evaluasi di tengah slide](product-overview_2.png)