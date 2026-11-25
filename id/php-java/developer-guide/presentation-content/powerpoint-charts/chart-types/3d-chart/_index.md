---
title: Sesuaikan Diagram 3D dalam Presentasi dengan PHP
linktitle: Diagram 3D
type: docs
url: /id/php-java/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Sesuaikan rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh PHP."
---
## **Gambaran Umum**

Aspose.Slides untuk PHP via Java memungkinkan Anda menyesuaikan tampilan diagram 3D melalui metode [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Artikel ini menunjukkan cara menyesuaikan rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah membuat sebuah [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan menggunakan [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) untuk menambahkan diagram kolom 3D bertumpuk ke slide pertama. Ia mengganti seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) dan [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) mengatur rotasi diagram menjadi 40 dan 270 derajat masing‑masing. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) mengatur kedalamannya menjadi 150 % dari lebar, sementara [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi diagram yang telah diisi dengan pengaturan tampilan 3D ini.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Terapkan Isi Gambar pada Permukaan Diagram 3D**

Anda dapat mengisi secara terpisah [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/), dan [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) sebuah diagram 3D. Atur [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) permukaan ke `Picture` dan tetapkan gambar. Atur baik [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) maupun [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) permukaan ke `Stretch` agar satu salinan gambar menutupi seluruh permukaan.

Simpan [arrow.png](arrow.png) di samping skrip PHP. Contoh ini memutar diagram dan menaikkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian ia menggandakan slide dua kali dan menerapkan panah pada permukaan yang berbeda di setiap slide. Ketiga diagram mempertahankan data, sudut pandang, dan latar belakang yang sama.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint menampilkan tiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah menunjuk ke dalam diagram sepanjang dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai di antara kolom](floor.png) |

## **Sesuaikan Proporsi Tinggi Diagram 3D**

Gunakan [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) untuk menetapkan tinggi diagram 3D sebagai persentase lebar. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi diagram tetap tetap. Data, rotasi, kedalaman, jarak antar seri, dan pemformatan identik di ketiga file; hanya persentase tinggi yang berubah.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Gambar berikut menggambarkan pengaturan tinggi yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Metode‑metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Tinggi adegan 3D sebagai persentase lebar. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Tinggi objek diagram pada slide, dalam poin. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Kedalaman adegan 3D sebagai persentase lebar. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `Column3D` yang terverifikasi. Pengaturan ini tidak mengubah tampilan diagram 2D `ClusteredColumn` atau diagram `BubbleWith3D`; nama‑nama tersebut merupakan anggota kelas [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Untuk pengaturan tampilan diagram lain, lihat [Chart Formatting](/slides/id/php-java/chart-formatting/).

## **Sesuaikan Jarak Antara Seri**

Gunakan [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 to 500**, termasuk: `0` menghilangkan celah, sementara nilai yang lebih besar menambah jarak. Dengan kedalaman diagram yang tetap, meningkatkan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Pengaturan ini diterapkan ke setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) mengembalikan celah kedalaman dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Penampilannya tergantung pada apakah seri disusun dalam kedalaman, berkelompok, atau bertumpuk. Untuk perbandingan jelas tentang celah antar seri terpisah, gunakan `ChartType::Column3D` dari kelas [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Metode‑metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Jarak antar klaster batang atau kolom berdekatan, sebagai persentase lebar batang atau kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Kedalaman keseluruhan diagram, sebagai persentase lebar diagram. |

Contoh mandiri berikut menggunakan data diagram default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya kedalaman celah yang berubah.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Gambar berikut menggambarkan pengaturan kedalaman celah yang sama dalam contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Dalam diagram silinder berkelompok, seri pertama dimulai dengan bentuk batang silindris. Contoh mencetak nilai integer yang dikembalikan oleh [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) dan [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) sebelum dan sesudah tiap perubahan. Tabel memberikan nama konstanta yang bersesuaian.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Ubah seri pertama | Tipe seri | Bentuk batang |
| --- | --- | --- |
| Buat diagram | `ClusteredCylinder` | `Cylinder` |
| Atur tipe seri ke `ClusteredCone` | `ClusteredCone` | `Cone` |
| Atur bentuk batang ke `Box` | `ClusteredColumn3D` | `Box` |

Mengatur bentuk ke `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, panggil [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) setelah mengubah bentuk. Nilai yang disimpan sebelumnya sebelum penugasan tetap akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint yang menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **Tanya Jawab**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui kelas [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) atau [render seluruh slide](/slides/id/php-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyisipkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja membangun dan merender diagram 3D besar?**

Kinerja bergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D tetap minimal, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk memenuhi kebutuhan tampilan atau cetak target.