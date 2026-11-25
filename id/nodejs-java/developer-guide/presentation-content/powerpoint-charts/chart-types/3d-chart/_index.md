---
title: Sesuaikan Diagram 3D dalam Presentasi Menggunakan JavaScript
linktitle: Diagram 3D
type: docs
url: /id/nodejs-java/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java. Atur rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh JavaScript."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js melalui Java memungkinkan Anda menyesuaikan tampilan diagram 3D melalui metode [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut‑kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Mengatur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah membuat sebuah [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) dan menggunakan [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) untuk menambahkan diagram kolom 3D bertumpuk ke slide pertamanya. Itu menggantikan seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` menunjukkan lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) dan [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) mengatur rotasi diagram menjadi 40 dan 270 derajat, masing‑masing. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) mengatur kedalaman menjadi 150 % dari lebar diagram, sementara [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) mengaktifkan sumbu sudut‑kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi diagram yang telah diisi dengan pengaturan tampilan 3D ini.

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

## **Menerapkan Isian Gambar pada Permukaan Diagram 3D**

Anda dapat mengisi [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), dan [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) diagram 3D secara terpisah. Atur [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) permukaan menjadi `Picture` dan tetapkan gambar. Atur baik [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) maupun [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) permukaan menjadi `Stretch` untuk menyesuaikan satu salinan gambar pada seluruh permukaan.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh tersebut memutar diagram dan menaikkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian contoh menggandakan slide dua kali dan menerapkan panah pada permukaan yang berbeda di setiap slide. Semua tiga diagram mempertahankan data, sudut pandang, dan latar belakang yang sama.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint menampilkan tiga slide sebagaimana berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah menunjuk ke dalam diagram sepanjang dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai di antara kolom](floor.png) |

## **Mengatur Proporsi Tinggi Diagram 3D**

Gunakan [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) untuk mengatur tinggi diagram 3D sebagai persentase lebar diagram. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi diagram tetap konstan. Data, rotasi, kedalaman, jarak antar seri, dan pemformatan identik di ketiga file; hanya persentase tinggi yang berubah.

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

Gambar berikut mengilustrasikan pengaturan tinggi yang sama pada contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Diagram kolom 3D dengan tinggi ditetapkan 50 % dari lebarnya](height_percent_50.png) | ![Diagram kolom 3D dengan tinggi ditetapkan 100 % dari lebarnya](height_percent_100.png) | ![Diagram kolom 3D dengan tinggi ditetapkan 200 % dari lebarnya](height_percent_200.png) |

Metode‑metode ini mengontrol aspek‑aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Tinggi adegan 3D sebagai persentase lebar adegan. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Tinggi objek diagram pada slide, dalam poin. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Kedalaman adegan 3D sebagai persentase lebar adegan. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `Column3D` yang terverifikasi. Pengaturan ini tidak mengubah tampilan diagram 2D `ClusteredColumn` atau `BubbleWith3D`; nama‑nama tersebut adalah anggota kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Untuk pengaturan tampilan diagram lainnya, lihat [Chart Formatting](/slides/id/nodejs-java/chart-formatting/).

## **Mengatur Jarak Antar Seri**

Gunakan [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 hingga 500**, inklusif: `0` menghapus celah, sementara nilai yang lebih besar meningkatkan jarak. Dengan kedalaman diagram tetap, peningkatan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) mengembalikan celah kedalaman dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Tampilan tergantung pada apakah seri diatur dalam kedalaman, berkelompok, atau ditumpuk. Untuk perbandingan jelas tentang celah antar seri terpisah, gunakan `ChartType.Column3D` dari kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Metode‑metode ini mengontrol aspek‑aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Jarak antar kelompok batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Kedalaman keseluruhan diagram, sebagai persentase lebar diagram. |

Contoh berikut menggunakan data diagram default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya kedalaman celah yang berubah.

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

Gambar berikut mengilustrasikan pengaturan kedalaman celah yang sama pada contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Diagram kolom 3D tanpa celah antar seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Diagram kolom 3D dengan celah 500 % antar seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Mengubah Tipe Seri 3D dan Bentuk Batang**

Pada diagram silinder berkelompok, seri pertama dimulai dengan bentuk batang silinder. Contoh mencetak nilai integer yang dikembalikan oleh [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) dan [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) sebelum dan sesudah setiap perubahan. Tabel memberikan nama konstanta yang sesuai.

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
| Buat diagram | `ClusteredCylinder` | `Cylinder` |
| Atur tipe seri menjadi `ClusteredCone` | `ClusteredCone` | `Cone` |
| Atur bentuk batang menjadi `Box` | `ClusteredColumn3D` | `Box` |

Menetapkan bentuk menjadi `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, panggil `series.getType()` setelah mengubah bentuk. Nilai yang disimpan sebelum penetapan masih akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint yang menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Tipe diagram mana yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang diekspos melalui kelas [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) atau [render seluruh slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyematkan diagram ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja dalam membangun dan merender diagram 3D yang besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, minimalkan efek 3D, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) untuk menyesuaikan dengan tampilan atau kebutuhan cetak target.