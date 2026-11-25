---
title: Sesuaikan Diagram 3D dalam Presentasi Menggunakan Java
linktitle: Diagram 3D
type: docs
url: /id/java/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Java. Atur rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh Java."
---
## **Gambaran Umum**

Aspose.Slides untuk Java memungkinkan Anda menyesuaikan tampilan diagram 3D melalui metode [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Artikel ini menunjukkan cara menyesuaikan rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah ini membuat sebuah [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dan menggunakan [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) untuk menambahkan diagram kolom 3D bertumpuk ke slide pertamanya. Itu menggantikan seri dan kategori default dengan dua seri yang masing-masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) dan [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) mengatur rotasi diagram menjadi 40 dan 270 derajat masing-masing. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) menetapkan kedalamannya menjadi 150% dari lebar, sementara [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) mengaktifkan sumbu sudut kanan alih-alih perspektif. Presentasi yang dihasilkan berisi diagram yang terisi dengan pengaturan tampilan 3D ini.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Terapkan Isi Gambar pada Permukaan Diagram 3D**

Diagram 3D memiliki tiga permukaan yang dapat Anda isi secara terpisah: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--), dan [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Atur [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) permukaan menjadi `Picture` dan tetapkan gambar. Atur baik [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) maupun [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) permukaan menjadi `Stretch` agar satu salinan gambar menutupi seluruh permukaan.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh ini memutar diagram dan meningkatkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian slide tersebut digandakan dua kali dan panah diterapkan pada permukaan yang berbeda di tiap slide. Ketiga diagram tersebut mempertahankan data, sudut pandang, dan latar belakang yang sama.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint menampilkan tiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah mengarah ke dalam diagram sepanjang dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai di antara kolom](floor.png) |

## **Sesuaikan Proporsi Tinggi Diagram 3D**

Gunakan [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) untuk mengatur tinggi diagram 3D sebagai persentase dari lebarnya. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50%, 100%, dan 200%. Posisi, lebar, dan tinggi diagram tetap tetap. Data, rotasi, kedalaman, jarak antar seri, dan pemformatan identik di ketiga berkas; hanya persentase tinggi yang berubah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gambar berikut menggambarkan pengaturan tinggi yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sedangkan persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Diagram kolom 3D dengan tinggi diatur menjadi 50 persen dari lebarnya](height_percent_50.png) | ![Diagram kolom 3D dengan tinggi diatur menjadi 100 persen dari lebarnya](height_percent_100.png) | ![Diagram kolom 3D dengan tinggi diatur menjadi 200 persen dari lebarnya](height_percent_200.png) |

Metode-metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Tinggi adegan 3D sebagai persentase dari lebarnya. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Tinggi objek diagram pada slide, dalam poin. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Kedalaman adegan 3D sebagai persentase dari lebarnya. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `Column3D` yang terverifikasi. Pengaturan ini tidak mengubah tampilan diagram 2D `ClusteredColumn` atau diagram `BubbleWith3D`; nama-nama ini adalah anggota kelas [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Untuk pengaturan tampilan diagram lainnya, lihat [Chart Formatting](/slides/id/java/chart-formatting/).

## **Sesuaikan Celah Antar Seri**

Gunakan [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 hingga 500**, termasuk: `0` menghilangkan celah, sementara nilai yang lebih besar meningkatkan jarak. Dengan kedalaman diagram tetap, meningkatkan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) mengembalikan celah kedalaman dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Penampilan tergantung pada apakah seri diatur dalam kedalaman, berkelompok, atau bertumpuk. Untuk perbandingan jelas mengenai celah antar seri terpisah, gunakan `ChartType.Column3D` dari kelas [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) .

Metode-metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Jarak antar klaster batang atau kolom bersebelahan, sebagai persentase lebar batang atau kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Kedalaman diagram secara keseluruhan, sebagai persentase lebar diagram. |

Contoh mandiri berikut menggunakan data diagram default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya celah kedalaman yang berubah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gambar berikut menggambarkan pengaturan celah kedalaman yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint.

| Celah kedalaman: 0% | Celah kedalaman: 500% |
| --- | --- |
| ![Diagram kolom 3D tanpa celah antar seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Diagram kolom 3D dengan celah 500 persen antar seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Dalam diagram silinder berkelompok, seri pertama dimulai dengan bentuk batang silinder. Contoh ini mencetak nilai integer yang dikembalikan oleh [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) dan [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) sebelum dan setelah setiap perubahan. Tabel memberikan nama konstanta yang sesuai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Ubah ke seri pertama | Tipe seri | Bentuk batang |
| --- | --- | --- |
| Buat diagram | `ClusteredCylinder` | `Cylinder` |
| Atur tipe seri ke `ClusteredCone` | `ClusteredCone` | `Cone` |
| Atur bentuk batang ke `Box` | `ClusteredColumn3D` | `Box` |

Mengatur bentuk ke `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, panggil `series.getType()` setelah mengubah bentuk. Nilai yang disimpan sebelum penetapan masih akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint yang menunjukkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Tipe diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui kelas [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) atau [render the entire slide](/slides/id/java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyematkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa cepat kinerja pembuatan dan perenderan diagram 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output berukuran sesuai (resolusi dan dimensi) untuk mencocokkan kebutuhan tampilan atau cetak target.