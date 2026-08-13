---
title: Kustomisasi Diagram Donat dalam Presentasi di Android
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

Artikel ini menunjukkan cara bekerja dengan diagram donat di Aspose.Slides dengan menambahkan diagram ke slide, mengatur ukuran lubang tengahnya, dan menyimpan presentasi. Fokusnya pada metode `setDoughnutHoleSize` dan memperlihatkan langkah‑langkah dasar yang diperlukan untuk menyesuaikan jenis diagram ini dalam kode.

Selain itu, artikel ini menyertakan FAQ singkat yang mencakup skenario diagram donat terkait, seperti menggunakan beberapa seri untuk membuat beberapa cincin, bekerja dengan diagram donat yang meletus, dan mengekspor diagram sebagai gambar raster atau SVG.

## **Tentukan Celah Tengah pada Diagram Donat**
{{% alert color="info" %}} 
Aspose.Slides untuk Android via Java kini mendukung penentuan ukuran lubang pada diagram donat. Pada topik ini, kita akan melihat contoh cara menentukan ukuran lubang pada diagram donat.
{{% /alert %}} 

Untuk menentukan ukuran lubang pada diagram donat, ikuti langkah‑langkah berikut:

1. Instansiasi objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
2. Tambahkan diagram donat ke slide.
3. Tentukan ukuran lubang pada diagram donat.
4. Tuliskan presentasi ke disk.

Pada contoh di bawah, kami telah menetapkan ukuran lubang pada diagram donat.

```java
import com.aspose.slides.*;

// Buat sebuah instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Tulis presentasi ke disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Apakah saya dapat membuat donat multi‑tingkat dengan beberapa cincin?

Ya. Tambahkan beberapa seri ke satu diagram donat—setiap seri menjadi cincin terpisah. Urutan cincin ditentukan oleh urutan seri dalam koleksi.

### Apakah donat "meletus" (irisan terpisah) didukung?

Ya. Terdapat tipe diagram Exploded Doughnut [chart type](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/charttype/) dan properti ledakan pada titik data; Anda dapat memisahkan irisan individu.

### Bagaimana cara mendapatkan gambar diagram donat (PNG/SVG) untuk laporan?

Diagram adalah sebuah bentuk; Anda dapat merendernya menjadi [gambar raster](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) atau mengekspor diagram ke [gambar SVG](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).