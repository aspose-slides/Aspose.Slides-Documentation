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
description: "Temukan cara membuat dan menyesuaikan diagram donat di Aspose.Slides untuk Java, yang mendukung format PowerPoint untuk presentasi dinamis."
---
## **Ikhtisar**

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang pusatnya, dan menyimpan presentasi. Artikel ini berfokus pada metode `setDoughnutHoleSize` dan mendemonstrasikan langkah‑langkah dasar yang diperlukan untuk menyesuaikan tipe diagram ini dalam kode.

Artikel ini juga menyertakan FAQ singkat yang mencakup skenario terkait diagram donat, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meledak, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
{{% alert color="info" %}} 

Aspose.Slides untuk Java kini mendukung penentuan ukuran lubang pada diagram donat. Pada topik ini, kita akan melihat contoh cara menentukan ukuran lubang pada diagram donat.

{{% /alert %}} 

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

1. Buat objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Tambahkan diagram donat pada slide.
1. Tentukan ukuran lubang pada diagram donat.
1. Tulis presentasi ke disk.

Pada contoh di bawah ini, kami telah menentukan ukuran lubang pada diagram donat.

```java
import com.aspose.slides.*;

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

### Bisakah saya membuat donat multi‑tingkat dengan beberapa cincin?

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

### Apakah donat "meledak" (irisan terpisah) didukung?

Ya. Ada tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individual.

### Bagaimana saya dapat memperoleh gambar diagram donat (PNG/SVG) untuk laporan?

Diagram adalah sebuah shape; Anda dapat merendernya menjadi [raster image](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) atau mengekspor diagram ke [SVG image](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).