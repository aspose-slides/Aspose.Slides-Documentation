---
title: Sesuaikan Diagram Donat dalam Presentasi Menggunakan Java
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/java/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk Java, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya adalah pada metode `setDoughnutHoleSize` dan memperlihatkan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario terkait diagram donat, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meledak, serta mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
{{% alert color="primary" %}} 

Aspose.Slides for Java kini mendukung penentuan ukuran lubang pada diagram donat. Pada topik ini, kita akan melihat contoh cara menentukan ukuran lubang pada diagram donat.

{{% /alert %}} 

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

1. Buat objek [Presentasi](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Tambahkan diagram donat pada slide.
1. Tentukan ukuran lubang pada diagram donat.
1. Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah menetapkan ukuran lubang pada diagram donat.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Simpan presentasi ke disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat membuat donat bertingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi sebuah cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat “meledak” (irisan terpisah) didukung?**

Ya. Ada tipe diagram Donat Meledak [chart type](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan secara individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah sebuah bentuk; Anda dapat merendernya menjadi [gambar raster](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) atau mengekspor diagram ke [gambar SVG](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).