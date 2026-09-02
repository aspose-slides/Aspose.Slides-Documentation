---
title: Kelola Seri Data Diagram dalam Presentasi dengan Java
linktitle: Seri Data
type: docs
url: /id/java/chart-series/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan Java."
---
## **Gambaran Umum**

Diagram menyimpan data yang dipetakan dalam buku kerja data diagram. Sebuah [IChartSeries](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/) mewakili satu set nilai terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/) dalam seri mengacu pada satu atau lebih sel buku kerja. Objek [IChartCategory](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik oleh karena itu terhubung ke objek [IChartDataCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/) bukan disimpan hanya sebagai teks tampilan.

Untuk diagram kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel-sel lainnya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) berbasis nol. Tata letak ini berguna saat Anda membuat diagram dengan data default, tetapi jangan berasumsi bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel-sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan diagram memiliki tiga ruang lingkup berbeda:

- Pengaturan level seri, seperti [IChartSeries.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getFormat--), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [IChartDataPoint.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getFormat--), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang termasuk dalam [IChartSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/). Akses grup melalui [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) ketika Anda perlu mengatur opsi seperti tumpang tindih atau lebar celah.

Jika tidak ada isian titik atau seri yang eksplisit, gaya diagram dan tema menentukan tampilan otomatis. Jika baik format seri maupun titik hadir, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Tumpang Tindih Seri Diagram**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getOverlap--) melaporkan seberapa banyak batang atau kolom tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi baca-saja dari pengaturan pada grup seri induk. Gunakan [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur tumpang tindih untuk grup yang berisi seri pertama:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Diagram baru berisi contoh seri, kategori, dan nilai.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Tumpang tindih seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Gunakan [IChartSeries.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getFormat--) untuk mengatur isian default untuk seluruh seri. Jika suatu titik sudah memiliki isian eksplisit, pengaturan [IChartDataPoint.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getFormat--) akan menggantikan isian seri untuk titik tersebut.

Contoh berikut menerapkan isian biru solid pada seri pertama:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam buku kerja data diagram dan biasanya ditampilkan di legenda. Dalam buku kerja default yang dibuat untuk diagram kolom terkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut menjelaskan struktur tersebut secara eksplisit:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [IChartSeries.getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getName--). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang ada:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Nama seri](series_name.png)

## **Dapatkan Warna Isian Seri Otomatis**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isian seri belum didefinisikan secara eksplisit. Memanggil metode ini membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
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

Warna yang tepat tergantung pada gaya diagram dan tema.

## **Atur Warna Isian Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) dapat menampilkan nilai negatif dengan isian berbeda. Atur isian seri reguler menjadi solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Angka negatif tetap tidak berubah di buku kerja; hanya warna tampilan mereka yang berubah.

Contoh berikut mengganti data diagram default dengan satu seri. Baris 0 lembar kerja berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Warna Isian Solid Terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dalam contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik juga diberikan nilai negatif agar efeknya terlihat:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bersihkan Nilai Titik Data Spesifik**

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, atur sel buku kerja yang mendasarinya menjadi `null`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [IChartDataPoint.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getValue--). Titik data tetap pada posisi kategori yang sama, namun diagram memperlakukan nilainya sebagai kosong menurut pengaturan nilai kosong diagram.

Contoh berikut membersihkan hanya titik kedua dalam seri pertama:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan memanggil [IChartDataPointCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapointcollection/#clear--) ketika Anda ingin mempertahankan titik lainnya, karena metode itu menghapus setiap titik data dari koleksi.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara gugusan batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti tumpang tindih, lebar celah merupakan milik grup seri induk, bukan satu seri. Panggil [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sekali untuk grup tersebut. Nilai yang lebih besar menciptakan lebih banyak ruang antara gugusan; nilai yang lebih kecil membuatnya lebih rapat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Lebar celah](gap_width.png)

## **FAQ**

**Tipe diagram mana yang mendukung seri data?**

Semua tipe diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) menggunakan data diagram, tetapi serinya tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti tumpang tindih dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [IChartSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plot tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah semua seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [IShapeCollection.addChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) membuat contoh seri, kategori, dan nilai. Anda dapat mengedit sel-sel tersebut atau menghapus koleksi seri dan kategori sebelum menambahkan kumpulan data yang sepenuhnya khusus. Sebuah overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membuat data khusus, jaga agar baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara menghapus satu titik alih-alih seluruh seri?**

Setel sel nilai yang relevan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [IChartDataPointCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapointcollection/#clear--) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri sehingga nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan nilai yang dikonfigurasi melalui [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik-titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) dan atur warna yang dikembalikan oleh [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Anda dapat mengganti perilaku untuk titik individual dengan [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Metode-metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pemformatan mana yang menang ketika baik seri maupun titik diformat?**

Pemformatan titik data yang eksplisit memiliki prioritas untuk titik tersebut. Titik lain terus menggunakan format seri yang eksplisit atau, jika format seri tidak didefinisikan, gaya dan tema diagram otomatis. Pengaturan grup seperti tumpang tindih dan lebar celah mengontrol tata letak dan bukan merupakan penggantian pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimuat diagram?**

Aspose.Slides tidak memberlakukan batas jumlah seri yang tetap. Pada kenyataannya, batasan file presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram menentukan batas yang berguna.

**Apa yang harus diubah ketika kolom terlalu dekat atau terlalu jauh?**

Panggil [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antara gugusan, atau turunkan untuk mendekatkan gugusan.