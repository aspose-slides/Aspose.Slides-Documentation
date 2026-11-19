---
title: Kustomisasi Bagan 3D dalam Presentasi Menggunakan JavaScript
linktitle: Bagan 3D
type: docs
url: /id/nodejs-java/3d-chart/
keywords:
- bagan 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat bagan 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java. Atur rotasi, proporsi tinggi, kedalaman bagan, dan jarak antar seri dengan contoh JavaScript."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java memungkinkan Anda menyesuaikan tampilan bagan 3D melalui metode [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Bagan 3D**

Contoh di bawah ini membuat sebuah [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) dan menggunakan [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) untuk menambahkan bagan kolom 3D bertumpuk ke slide pertamanya. Contoh ini menggantikan seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama bagan; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) dan [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) mengatur rotasi bagan menjadi 40 dan 270 derajat masing‑masing. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) mengatur kedalamannya menjadi 150% dari lebar, sementara [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi bagan yang terisi dengan pengaturan tampilan 3D ini.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sesuaikan Proporsi Tinggi Bagan 3D**

Gunakan [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) untuk mengatur tinggi bagan 3D sebagai persentase lebar bagan. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek bagan pada slide.

Contoh berikut membuat sebuah bagan [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dengan data default: tiga seri dan empat kategori. Contoh ini menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi bagan tetap sama. Data, rotasi, kedalaman, jarak antar seri, dan pemformatan identik di ketiga file; hanya persentase tinggi yang berubah.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gambar di bawah ini menggambarkan pengaturan tinggi yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek bagan yang sama. PowerPoint juga dapat menyesuaikan interval tanda pada sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Bagan kolom 3D dengan tinggi diatur menjadi 50 persen dari lebarnya](height_percent_50.png) | ![Bagan kolom 3D dengan tinggi diatur menjadi 100 persen dari lebarnya](height_percent_100.png) | ![Bagan kolom 3D dengan tinggi diatur menjadi 200 persen dari lebarnya](height_percent_200.png) |

Metode‑metode ini mengontrol aspek‑aspek yang berbeda dari bagan:

| Metode | Efek |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Tinggi adegan 3D sebagai persentase lebar bagan. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Tinggi objek bagan pada slide, dalam point. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Kedalaman adegan 3D sebagai persentase lebar bagan. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi bagan kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta bagan garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `Column3D` yang terverifikasi. Pengaturan ini tidak mengubah tampilan bagan `ClusteredColumn` 2D atau bagan `BubbleWith3D`; nama‑nama tersebut merupakan anggota kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Untuk pengaturan tampilan bagan lainnya, lihat [Pemformatan Bagan](/slides/id/nodejs-java/chart-formatting/).

## **Sesuaikan Celah Antara Seri**

Gunakan [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) untuk mengontrol jarak antara seri data sepanjang sumbu kedalaman bagan 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 to 500**, inklusif: `0` menghilangkan celah, sementara nilai yang lebih besar meningkatkan jarak. Dengan kedalaman bagan yang tetap, meningkatkan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) mengembalikan celah kedalaman dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi bagan kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta bagan garis dan area 3D. Tampilan tergantung pada apakah seri diatur dalam kedalaman, berkelompok, atau bertumpuk. Untuk perbandingan yang jelas antara celah antar seri terpisah, gunakan `ChartType.Column3D` dari kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Metode‑metode ini mengontrol aspek‑aspek yang berbeda dari bagan:

| Metode | Efek |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Jarak antar kelompok batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Kedalaman keseluruhan bagan, sebagai persentase lebar bagan. |

Contoh mandiri berikut menggunakan data bagan default, yang berisi tiga seri dan empat kategori. Contoh ini menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman bagan yang identik; hanya kedalaman celah yang berubah.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gambar di bawah ini menggambarkan pengaturan kedalaman celah yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Bagan kolom 3D tanpa celah antara seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Bagan kolom 3D dengan celah 500 persen antara seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Dalam bagan silinder berkelompok, seri pertama dimulai dengan bentuk batang silinder. Contoh ini mencetak nilai integer yang dikembalikan oleh [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) dan [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) sebelum dan sesudah setiap perubahan. Tabel memberikan nama konstan yang bersesuaian.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Ubah pada seri pertama | Tipe seri | Bentuk batang |
| --- | --- | --- |
| Buat bagan | `ClusteredCylinder` | `Cylinder` |
| Atur tipe seri menjadi `ClusteredCone` | `ClusteredCone` | `Cone` |
| Atur bentuk batang menjadi `Box` | `ClusteredColumn3D` | `Box` |

Menetapkan bentuk ke `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, panggil `series.getType()` setelah mengubah bentuk. Nilai yang di‑cache sebelum penetapan masih akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint yang menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Jenis bagan mana yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari bagan kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe‑tipe 3D terkait yang diekspos melalui kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster bagan 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor bagan ke gambar dengan [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) atau [render the entire slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda membutuhkan pratinjau raster atau ingin menyematkan bagan ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa cepat kinerja pembuatan dan render bagan 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran (resolusi dan dimensi) yang sesuai dengan tampilan atau kebutuhan pencetakan target.