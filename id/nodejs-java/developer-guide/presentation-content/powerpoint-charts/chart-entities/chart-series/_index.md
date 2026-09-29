---
title: Kelola Data Seri Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Seri Data
type: docs
url: /id/nodejs-java/chart-series/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan JavaScript."
---
## **Ringkasan**

Diagram menyimpan data yang dipetakan dalam buku kerja data diagram. Sebuah [ChartSeries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/) mewakili satu set nilai yang terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/) dalam seri merujuk ke satu atau beberapa sel buku kerja. Objek [ChartCategory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik karena itu terhubung ke objek [ChartDataCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk diagram kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel lain untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/#getCell) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan mengasumsikan bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan diagram memiliki tiga lingkup berbeda:

- Pengaturan tingkat seri, seperti [ChartSeries.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getFormat), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getFormat), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/). Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) saat Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada pengisian titik atau seri yang eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika baik format seri maupun titik ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Mengatur Overlap Seri Diagram**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getOverlap) melaporkan berapa banyak batang atau kolom yang saling tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Ini adalah proyeksi baca‑saja dari pengaturan pada grup seri induk. Gunakan [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Diagram baru berisi contoh seri, kategori, dan nilai.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Overlap seri](series_overlap.png)

## **Mengubah Warna Isi Seri**

Gunakan [ChartSeries.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getFormat) untuk mengatur isi default seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getFormat)nya akan menggantikan isi seri untuk titik tersebut.

Contoh berikut menerapkan isi biru solid ke seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Warna seri](series_color.png)

## **Mengubah Nama Seri**

Nama seri disimpan dalam buku kerja data diagram dan biasanya ditampilkan di legenda. Dalam buku kerja default yang dibuat untuk diagram kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur itu eksplisit:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.getName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getName). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang sudah ada:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Nama seri](series_name.png)

## **Mendapatkan Warna Isi Seri Otomatis**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isi seri belum ditentukan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis masing‑masing seri default:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Contoh output untuk gaya diagram default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna tepatnya bergantung pada gaya dan tema diagram.

## **Mengatur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) dapat menampilkan nilai negatif dengan isi yang berbeda. Atur isi seri reguler menjadi solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Angka negatif tetap tidak berubah di buku kerja; hanya warna tampilannya yang berubah.

Contoh berikut mengganti data diagram default dengan satu seri. Baris lembar kerja 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Warna isi solid terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Pada contoh berikut, inversi dimatikan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menghapus Nilai Titik Data Tertentu**

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, atur sel buku kerja yang mendasarinya menjadi `null`. Untuk diagram kolom, nilai yang diplot tersedia melalui [ChartDataPoint.getValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#getValue). Titik data tetap berada pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong diagram.

Contoh berikut menghapus hanya titik kedua pada seri pertama:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan memanggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapointcollection/#clear) ketika Anda ingin mempertahankan titik‑titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Mengontrol Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom lembar kerja yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel buku kerja kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [ChartDataCell.setValue](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatacell/#setValue) dengan `null` untuk membuat sel menjadi kosong. Angka nol tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) untuk memilih bagaimana diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel buku kerja kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan masing‑masing mode. Tidak diperlukan berkas masukan. [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/) menggunakan lembar kerja 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 menampung nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Setiap berkas keluaran menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi semua mode.

Perbandingan di bawah memperlihatkan data yang sama dalam ketiga berkas. Hari 3 kosong di buku kerja pada setiap kasus:

![Diagram garis dengan data identik: Gap memutuskan garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efek yang terlihat bergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis yang menghubungkan melintasi kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol juga dapat tampak serupa. Demikian pula, diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa keluaran untuk tipe yang Anda gunakan.

## **Mengatur Lebar Celah Seri**

Lebar celah adalah ruang antara kelompok batang atau kolom yang berdekatan, diekspresikan sebagai persentase lebar batang atau kolom. Seperti overlap, lebar celah termasuk dalam grup seri induk, bukan satu seri tertentu. Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antar‑kelompok; nilai yang lebih kecil membuatnya lebih padat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Lebar celah](gap_width.png)

## **FAQ**

**Tipe diagram apa yang mendukung data seri?**

Semua tipe diagram yang direpresentasikan oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/) menggunakan data diagram, tetapi seri mereka tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

[ChartSeriesGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.addChart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addChart) membuat seri contoh, kategori, dan nilai. Anda dapat mengedit sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya khusus. Overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membuat data khusus, pertahankan baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik saja, bukan seluruh seri?**

Setel sel nilai yang relevan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapointcollection/#clear) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan nilai yang dikonfigurasi melalui [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Mengontrol Tampilan Sel Kosong](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) dan atur warna yang dikembalikan oleh [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Anda dapat mengganti perilaku untuk titik individu dengan [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metode‑metode ini memengaruhi formatting, bukan nilai numerik yang disimpan.

**Formatting mana yang menang ketika baik seri maupun titik diformat?**

Formatting titik data eksplisit memiliki prioritas untuk titik tersebut. Titik‑titik lain tetap menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema diagram otomatis. Pengaturan grup seperti overlap dan lebar celah mengontrol tata letak dan bukan overriding formatting tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas bergantung pada batasan berkas presentasi, memori tersedia, waktu rendering, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) pada grup seri induk yang tepat. Tingkatkan nilai untuk memperlebar ruang antar‑kelompok, atau turunkan nilai untuk mendekatkan kelompok.