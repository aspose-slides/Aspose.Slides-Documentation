---
title: Sesuaikan Tabel Data Grafik dalam Presentasi di Android
linktitle: Tabel Data
type: docs
url: /id/androidjava/chart-data-table/
keywords:
- data grafik
- tabel data
- properti font
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan tabel data grafik dalam Java untuk PPT dan PPTX dengan Aspose.Slides untuk Android guna meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan tabel data grafik di Aspose.Slides. Ini menunjukkan cara menampilkan tabel data untuk sebuah grafik dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini mendemonstrasikan memuat presentasi, menambahkan grafik, mengaktifkan tabel data grafik, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

## **Atur Properti Font untuk Tabel Data Grafik**
Aspose.Slides for Android via Java menyediakan dukungan untuk mengubah warna kategori dalam warna seri. 

1. Buat objek kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Tambahkan grafik pada slide.
1. atur tabel grafik.
1. Atur tinggi font.
1. Simpan presentasi yang telah dimodifikasi.

 Contoh sampel diberikan di bawah ini. 

```java
// Membuat presentasi kosong
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di samping nilai dalam tabel data grafik?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender grafik sebagai bagian dari slide, sehingga [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/id/androidjava/convert-powerpoint-to-html/)/[image](/slides/id/androidjava/convert-powerpoint-to-png/) yang diekspor menyertakan grafik beserta tabel data.

**Apakah tabel data didukung untuk grafik yang berasal dari file templat?**

Ya. Untuk grafik apa pun yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [is shown](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#hasDataTable--) menggunakan properti grafik.

**Bagaimana cara cepat menemukan grafik mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti setiap grafik yang menunjukkan apakah tabel data [is shown](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#hasDataTable--) dan iterasi melalui slide untuk mengidentifikasi grafik yang diaktifkan.