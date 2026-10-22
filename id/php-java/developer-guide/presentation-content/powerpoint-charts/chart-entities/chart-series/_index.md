---
title: Kelola Seri Data Diagram dalam Presentasi dengan PHP
linktitle: Seri Data
type: docs
url: /id/php-java/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- nama seri
- titik data
- sel buku kerja
- celah seri
- nilai negatif
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan PHP."
---
## **Gambaran Umum**

Diagram dapat menyimpan nilai yang dipetakan di sel buku kerja atau langsung sebagai literal numerik. Sebuah [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) mewakili satu set nilai terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) mewakili sebuah titik dalam seri tersebut. Objek [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagi oleh seri. Pada diagram yang dibuat dengan data default, nama seri, kategori, dan nilai titik menggunakan objek [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) dari buku kerja diagram.

Untuk diagram kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diberikan ke [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) bersifat berbasis nol. Tata letak ini berguna saat Anda membuat diagram dengan data default, tetapi jangan berasumsi bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan diagram memiliki tiga lingkup yang berbeda:

- Pengaturan tingkat‑seri, seperti [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik‑data, seperti [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), menimpa tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri‑seri yang kompatibel yang berada dalam [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) yang sama. Akses grup melalui [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika pemformatan seri dan titik keduanya ada, pemformatan titik memiliki prioritas untuk titik tersebut.

![seri-diagram-powerpoint](chart-series-powerpoint.png)

## **Menetapkan Nilai Seri Menggunakan Literal Numerik**

Gunakan literal numerik ketika nilai seri berasal dari data aplikasi atau perhitungan dan tidak memerlukan referensi sel worksheet. Panggil [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) dengan [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) sebelum menetapkan hasil [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) setiap titik melalui [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Pengaturan koleksi mengendalikan tipe sumber semua nilai titik dalam seri tersebut. Metode [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) setiap nilai titik melaporkan tipe yang dipilih; ubah melalui pengaturan koleksi. Dengan `Worksheet`, gunakan [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) untuk mengakses sel yang dirujuk. Dengan `DoubleLiterals`, gunakan [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) atau `setAsLiteralDouble` untuk membaca atau menulis angka secara langsung.

Contoh berikut membuat diagram kolom dengan seri dan kategori default, lalu menetapkan nilai yang dihitung 10, 20, dan seterusnya ke titik‑titik yang ada pada seri pertama. Diagram disimpan, dibuka kembali, dan nilai yang disimpan dicetak.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Tipe sumber nilai titik terpisah dari [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), yang mengidentifikasi konfigurasi buku kerja internal atau eksternal diagram. Menggunakan literal numerik tidak secara otomatis menghapus buku kerja yang disematkan. Pada contoh ini, buku kerja tetap tersedia untuk label kategori, nama seri, dan seri lainnya. Lihat [Chart Workbook](/slides/id/php-java/chart-workbook/) untuk manajemen buku kerja.

Untuk diagram pencar dan gelembung, gunakan [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) dan [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) untuk memilih sumber bagi [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) dan [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Diagram gelembung juga menggunakan [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) untuk [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Tetapkan setiap sumber yang berlaku ke `DoubleLiterals` sebelum menugaskan angka melalui metode `setAsLiteralDouble` nilai tersebut.

## **Menetapkan Overlap Seri Diagram**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) melaporkan berapa persen batang atau kolom tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Gunakan [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom yang dikelompokkan; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut menetapkan overlap untuk grup yang berisi seri pertama:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Diagram baru berisi seri contoh, kategori, dan nilai.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Overlap seri](series_overlap.png)

## **Mengubah Warna Isian Seri**

Gunakan [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) untuk menetapkan isian default bagi seluruh seri. Jika sebuah titik sudah memiliki isian eksplisit, pengaturan [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) menimpa isian seri untuk titik tersebut.

Contoh berikut menerapkan isian biru solid pada seri pertama:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Warna seri](series_color.png)

## **Mengubah Nama Seri**

Nama seri disimpan dalam buku kerja data diagram dan biasanya ditampilkan di legenda. Pada buku kerja default yang dibuat untuk diagram kolom berkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Variabel bernama dalam contoh berikut membuat struktur itu eksplisit:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang ada:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Nama seri](series_name.png)

### **Membuat Seri dengan Nama dari Beberapa Sel**

Nama seri komposit berguna ketika nama produk dan periode laporan disimpan di sel buku kerja terpisah. Misalnya, Anda dapat menggabungkan `Product A` di B1 dan `2026` di C1 menjadi satu nama seri sambil menjaga kedua bagian tetap terhubung ke sel sumbernya.

Gunakan [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) untuk mengambil rentang nama, lalu berikan koleksi itu ke [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Argumen `skipHiddenCells` mengontrol apakah sel tersembunyi disertakan: `true` mengecualikannya, sementara `false` menyertakannya. Contoh ini menggunakan `false` untuk menyertakan setiap sel dalam rentang nama.

Contoh berikut membuat presentasi dengan satu seri dan dua titik data. Sel B1:C1 hanya menyediakan nama seri; A2:A3 menyediakan label kategori, dan B2:B3 menyediakan nilai numerik.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Dua sel ini menyediakan nama seri.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Sel terpisah menyediakan kategori dan titik data numerik.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nama seri yang dihasilkan adalah `Product A 2026`, dengan spasi di antara dua nilai sel. Legenda menampilkan ini sebagai satu entri untuk kedua kolom. Gambar di bawah mengilustrasikan hasilnya:

![Diagram kolom dengan nilai Utara dan Selatan serta nama seri komposit Product A 2026 di legenda](composite_series_name.png)

## **Mendapatkan Warna Isian Seri Otomatis**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Contoh output untuk gaya diagram default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna tepatnya tergantung pada gaya dan tema diagram.

## **Menetapkan Warna Isian Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) dapat menampilkan nilai negatif dengan isian berbeda. Tetapkan isian seri reguler ke solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Angka negatif tetap tidak berubah di buku kerja; hanya warna tampilannya yang berubah.

Contoh berikut menggantikan data diagram default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Warna isian solid terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Mengosongkan Nilai Titik Data Tertentu**

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, setel sel buku kerja yang mendasarinya menjadi `null`. Pada diagram kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Titik data tetap berada pada posisi kategori yang sama, namun diagram memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong diagram.

Contoh berikut hanya mengosongkan titik kedua dalam seri pertama:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Diagram pencar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hanya kosongkan sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lainnya, karena metode tersebut menghapus semua titik data dari koleksi.

## **Mengendalikan Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom worksheet yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel buku kerja kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) dengan `null` untuk membuat sel kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) untuk memilih bagaimana diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel buku kerja kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan setiap mode. Tidak diperlukan berkas input. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memegang nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Setiap berkas output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi semua mode.

Perbandingan di bawah menampilkan data yang sama dalam ketiga berkas. Hari 3 kosong di buku kerja pada setiap kasus:

![Diagram garis dengan data identik: Gap memutus garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efek yang terlihat bergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom nol‑tinggi juga dapat terlihat serupa. Begitu pula diagram pencar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Menetapkan Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, lebar celah dimiliki oleh grup seri induk, bukan oleh satu seri. Panggil [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) sekali untuk grup tersebut. Nilai yang lebih besar menciptakan lebih banyak ruang antar klaster; nilai yang lebih kecil membuatnya lebih rapat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Hasilnya:

![Lebar celah](gap_width.png)

## **Tanya Jawab**

**Jenis diagram apa yang mendukung data seri?**

Semua jenis diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) menggunakan data diagram, tetapi seri‑serinya tidak semua memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram pencar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) berisi seri‑seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup melalui satu seri tidak serta‑merta mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) membuat contoh seri, kategori, dan nilai. Anda dapat menyunting sel‑sel itu atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya khusus. Overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membangun data khusus, jaga agar baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa seluruh seri?**

Setel sel nilai yang relevan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri sehingga nilai‑nya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan nilai yang dikonfigurasi melalui [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Mengendalikan Tampilan Sel Kosong](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) dan tetapkan warna yang dikembalikan oleh [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Anda dapat menimpa perilaku untuk titik individual dengan [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Metode‑metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pemformatan mana yang menang ketika seri dan titik keduanya diformat?**

Pemformatan titik data yang eksplisit memiliki prioritas untuk titik tersebut. Titik lainnya tetap menggunakan pemformatan seri eksplisit atau, bila pemformatan seri tidak didefinisikan, gaya dan tema diagram otomatis. Pengaturan grup seperti overlap dan lebar celah mengendalikan tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki diagram?**

Aspose.Slides tidak menetapkan batas tetap terpisah untuk jumlah seri. Dalam praktiknya, batas ditentukan oleh kendala berkas presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu terpisah?**

Panggil [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antar klaster, atau turunkan nilai untuk mendekatkan klaster.