---
title: Gambaran Produk
type: docs
weight: 10
url: /id/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Selamat datang di Aspose.Slides for JasperReports!**

Aspose.Slides for JasperReports adalah sebuah pustaka yang dirancang khusus dan dikembangkan untuk pengembang yang perlu mengekspor laporan dari JasperReports ke format Microsoft PowerPoint Presentation (PPT) dan Microsoft PowerPoint Show (PPS) dengan mudah dalam aplikasi Java mereka. Semua fitur laporan dikonversi dengan tingkat presisi tertinggi ke presentasi Microsoft PowerPoint. Aspose.Slides for JasperReports mencakup dukungan untuk JasperReports 5+.

## **Deskripsi Produk**
JasperReports dan JasperServer tidak memiliki kemampuan bawaan untuk mengekspor laporan sebagai presentasi Microsoft PowerPoint, tetapi Aspose.Slides for JasperReports memberi Anda akses ke dua format ekspor tambahan: 

- PPT – Presentasi PowerPoint via Aspose.Slides
- PPS – Show PowerPoint via Aspose.Slides
- PPTX – Presentasi PowerPoint via Aspose.Slides
- PPSX – Show PowerPoint via Aspose.Slides

Aspose.Slides for JasperReports secara internal menggunakan pustaka Java 100% murni kami, Aspose.Slides for Java dan Aspose.Metafiles for Java, pustaka kelas dunia untuk pemrosesan presentasi sisi server dan metafile.

Aspose.Slides for JasperReports memungkinkan untuk mengekspor laporan apa pun dalam format PPT atau PPS.

### **Contoh Output**
Kelas ASPptExporter memperluas kelas ASAbstractExporter sehingga dapat digunakan dengan cara yang sama seperti semua pengekspor standar lainnya. Contoh singkat ini menampilkan kode tipikal dan tangkapan layar dari sebuah laporan yang dilihat di MS PowerPoint. Contoh terperinci dapat ditemukan dalam laporan demo yang disediakan. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Presentasi yang dihasilkan dengan demo JasperReports xmldatasource** 

![Presentasi yang dihasilkan dengan JasperReports](product-overview_2.png)