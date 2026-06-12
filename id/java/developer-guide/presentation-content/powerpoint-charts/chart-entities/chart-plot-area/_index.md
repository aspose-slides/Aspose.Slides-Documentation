---
title: Kustomisasi Area Plot Grafik pada Presentasi di Java
linktitle: Area Plot
type: docs
url: /id/java/chart-plot-area/
keywords:
- grafik
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot grafik dalam presentasi PowerPoint dengan Aspose.Slides untuk Java. Tingkatkan visual slide Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan area plot grafik di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran sebenarnya dari area plot dengan memvalidasi tata letak grafik dan kemudian membaca nilai X, Y, lebar, dan tinggi.

Artikel ini juga menunjukkan cara mengonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar dan Tinggi Area Plot Grafik**
Aspose.Slides untuk Java menyediakan API sederhana untuk .

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan grafik dengan data default.
4. Panggil metode [IChart.validateChartLayout()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChart#validateChartLayout--) sebelum untuk memperoleh nilai sebenarnya.
5. Mendapatkan lokasi X sebenarnya (kiri) dari elemen grafik relatif terhadap sudut kiri atas grafik.
6. Mendapatkan posisi atas sebenarnya dari elemen grafik relatif terhadap sudut kiri atas grafik.
7. Mendapatkan lebar sebenarnya dari elemen grafik.
8. Mendapatkan tinggi sebenarnya dari elemen grafik.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Mode Tata Letak Area Plot Grafik**
Aspose.Slides untuk Java menyediakan API sederhana untuk mengatur mode tata letak area plot grafik. Metode [**setLayoutTargetType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) dan [**getLayoutTargetType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) telah ditambahkan ke kelas [**ChartPlotArea**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartPlotArea) dan antarmuka [**IChartPlotArea**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartPlotArea). Jika tata letak area plot didefinisikan secara manual, properti ini menentukan apakah tata letak area plot menggunakan bagian dalamnya (tidak termasuk sumbu dan label sumbu) atau bagian luarnya (termasuk sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum [**LayoutTargetType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/id/java/com.aspose.slides/LayoutTargetType#Inner) - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tidak termasuk tanda centang dan label sumbu.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/id/java/com.aspose.slides/LayoutTargetType#Outer) - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tanda centang, dan label sumbu.

Kode contoh diberikan di bawah.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Dalam satuan apa x sebenarnya, y sebenarnya, lebar sebenarnya, dan tinggi sebenarnya dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan Area Plot dengan Area Grafik dalam hal konten?**

Area Plot adalah wilayah gambar data (seri, garis kisi, garis tren, dll.); Area Grafik mencakup elemen di sekitarnya (judul, legenda, dll.). Pada grafik 3D, Area Plot juga mencakup dinding/lantai dan sumbu.

**Bagaimana x, y, lebar, dan tinggi Area Plot diinterpretasikan ketika tata letak manual?**

Mereka merupakan pecahan (0–1) dari ukuran keseluruhan grafik; dalam mode ini, penempatan otomatis dinonaktifkan dan pecahan yang Anda tetapkan digunakan.

**Mengapa posisi Area Plot berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di area grafik di luar Area Plot tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Area Plot dapat bergeser ketika penempatan otomatis aktif. (Ini adalah perilaku standar untuk grafik PowerPoint.)