---
title: Sesuaikan Diagram Donat dalam Presentasi di Android
linktitle: Diagram Donat
type: docs
weight: 30
url: /id/androidjava/doughnut-chart/
keywords:
- diagram donat
- celah tengah
- ukuran lubang
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk Android via Java, mendukung format PowerPoint untuk presentasi dinamis."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada metode `setDoughnutHoleSize` dan mendemonstrasikan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario diagram donat terkait, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang di‑pecah, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
{{% alert color="primary" %}} 

Aspose.Slides untuk Android via Java kini mendukung penentuan ukuran lubang pada diagram donat. Pada topik ini, kita akan melihat contoh cara menentukan ukuran lubang pada diagram donat.

{{% /alert %}} 

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

1. Buat objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
2. Tambahkan diagram donat pada slide.
3. Tentukan ukuran lubang pada diagram donat.
4. Tuliskan presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur ukuran lubang pada diagram donat.

```java
// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Tuliskan presentasi ke disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat membuat donat multi‑tingkat dengan beberapa cincin?**

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

**Apakah donat "exploded" (irisan terpisah) didukung?**

Ya. Terdapat tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individual.

**Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?**

Diagram adalah bentuk; Anda dapat merendernya menjadi [gambar raster](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) atau mengekspor diagram ke [gambar SVG](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).