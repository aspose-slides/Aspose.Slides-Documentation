---
title: Kustomisasi Area Plot Grafik pada Presentasi dengan JavaScript
linktitle: Area Plot
type: docs
url: /id/nodejs-java/chart-plot-area/
keywords:
- grafik
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot grafik dalam presentasi PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js. Tingkatkan visual slide Anda dengan mudah."
---
## **Ringkasan**

Artikel ini menunjukkan cara bekerja dengan area plot grafik di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran aktual area plot dengan memvalidasi tata letak grafik dan kemudian membaca nilai X, Y, lebar, dan tinggi.

Ini juga menunjukkan cara mengkonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar, Tinggi Area Plot Grafik**

Aspose.Slides untuk Node.js melalui Java menyediakan API sederhana untuk .

1. Buat sebuah instance dari kelas[Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Akses slide pertama.
3. Tambahkan grafik dengan data default.
4. Panggil metode[Chart.validateChartLayout()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Chart#validateChartLayout--) sebelum untuk mendapatkan nilai aktual.
5. Mendapatkan lokasi X aktual (kiri) dari elemen grafik relatif terhadap sudut kiri atas grafik.
6. Mendapatkan posisi atas aktual dari elemen grafik relatif terhadap sudut kiri atas grafik.
7. Mendapatkan lebar aktual dari elemen grafik.
8. Mendapatkan tinggi aktual dari elemen grafik.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Mode Tata Letak Area Plot Grafik**

Aspose.Slides untuk Node.js melalui Java menyediakan API sederhana untuk mengatur mode tata letak area plot grafik. Metode[**setLayoutTargetType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) dan[**getLayoutTargetType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) telah ditambahkan ke kelas[**ChartPlotArea**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartPlotArea) dan kelas[**ChartPlotArea**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartPlotArea). Jika tata letak area plot ditentukan secara manual, properti ini menentukan apakah menata area plot berdasarkan bagian dalamnya (tidak termasuk sumbu dan label sumbu) atau bagian luarnya (termasuk sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum[**LayoutTargetType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LayoutTargetType#Inner) - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tidak termasuk tanda penskala dan label sumbu.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LayoutTargetType#Outer) - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tanda penskala, dan label sumbu.

Kode contoh diberikan di bawah.

```javascript
// Buat sebuah instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Dalam satuan apa X aktual, Y aktual, Lebar aktual, dan Tinggi aktual dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan Area Plot dengan Area Grafik dalam hal konten?**

Area Plot adalah wilayah menggambar data (seri, garis kisi, garis tren, dll.); Area Grafik mencakup elemen di sekitarnya (judul, legenda, dll.). Pada grafik 3D, Area Plot juga mencakup dinding/lantai dan sumbu.

**Bagaimana X, Y, Lebar, dan Tinggi Area Plot diinterpretasikan ketika tata letak manual?**

Mereka merupakan fraksi (0–1) dari ukuran keseluruhan grafik; dalam mode ini, penempatan otomatis dinonaktifkan dan fraksi yang Anda atur digunakan.

**Mengapa posisi Area Plot berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di area grafik di luar Area Plot tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Area Plot dapat bergeser ketika penempatan otomatis diaktifkan. (Ini adalah perilaku standar untuk grafik PowerPoint.)