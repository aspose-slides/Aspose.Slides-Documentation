---
title: Mengelola Seri Data Diagram dalam Presentasi dengan Java
linktitle: Seri Data
type: docs
url: /id/java/chart-series/
keywords:
- seri diagram
- overlap seri
- warna seri
- nama seri
- titik data
- sel workbook
- celah seri
- nilai negatif
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel workbook, pemformatan, overlap, lebar celah, dan nilai negatif dalam presentasi dengan Java."
---
## **Ikhtisar**

Sebuah diagram menyimpan data yang diplot dalam sebuah workbook data diagram. Sebuah [IChartSeries](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/) mewakili satu set nilai yang terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/) dalam seri mengacu pada satu atau lebih sel workbook. Objek [IChartCategory](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagi oleh seri. Nama seri, kategori, dan nilai titik karena itu terhubung ke objek [IChartDataCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk diagram kategori tipikal, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks worksheet, baris, dan kolom yang dilewatkan ke [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan mengasumsikan bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel yang direferensikan oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan diagram memiliki tiga ruang lingkup berbeda:

- Pengaturan tingkat‑seri, seperti [IChartSeries.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getFormat--), menyediakan penampilan default untuk semua titik dalam satu seri.
- Pengaturan titik‑data, seperti [IChartDataPoint.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getFormat--), menggantikan penampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang termasuk dalam satu [IChartSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/). Akses grup melalui [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada pengisian (fill) titik atau seri yang eksplisit, gaya dan tema diagram menentukan penampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Mengatur Overlap Seri Diagram**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getOverlap--) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Ini adalah proyeksi baca‑saja dari pengaturan pada grup seri induk. Gunakan [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) untuk memperbarui setiap seri kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Diagram baru berisi seri contoh, kategori, dan nilai.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![The series overlap](series_overlap.png)

## **Mengubah Warna Isi Seri**

Gunakan [IChartSeries.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getFormat--) untuk mengatur isi default bagi seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [IChartDataPoint.getFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getFormat--) menimpa isi seri untuk titik tersebut.

Contoh berikut menerapkan isi biru solid pada seri pertama:

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

![The color of the series](series_color.png)

## **Mengubah Nama Seri**

Nama seri disimpan dalam workbook data diagram dan biasanya ditampilkan di legenda. Dalam workbook default yang dibuat untuk diagram kolom terkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur tersebut eksplisit:

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

Anda juga dapat memperbarui sel yang sudah direferensikan oleh [IChartSeries.getName](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getName--). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang ada:

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

![The series name](series_name.png)

## **Mendapatkan Warna Isi Seri Otomatis**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isi seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis untuk setiap seri default:

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

Output contoh untuk gaya diagram default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna yang tepat tergantung pada gaya dan tema diagram.

## **Mengatur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) dapat menampilkan nilai negatif dengan isi yang berbeda. Atur isi seri reguler menjadi solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Angka negatif tetap tidak berubah di workbook; hanya warna tampilannya yang berubah.

Contoh berikut mengganti data diagram default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dalam contoh berikut, inversi dinonaktifkan untuk seri dan hanya diaktifkan untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif agar efeknya terlihat:

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

## **Mengosongkan Nilai Titik Data Tertentu**

Untuk membuat satu titik menjadi kosong tanpa menghapus titik‑titik lain, atur sel workbook yang mendasarinya menjadi `null`. Untuk diagram kolom, nilai yang diplot tersedia melalui [IChartDataPoint.getValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#getValue--). Titik data tetap berada pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong diagram.

Contoh berikut mengosongkan hanya titik kedua dalam seri pertama:

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

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hanya kosongkan sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [IChartDataPointCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapointcollection/#clear--) ketika Anda ingin mempertahankan titik‑titik lain, karena metode tersebut menghapus setiap titik data dari koleksi.

## **Mengontrol Tampilan Sel Kosong**

Sebuah sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [IChartDataCell.setValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) dengan `null` untuk membuat sel menjadi kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) untuk memilih cara diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ini mengubah cara kosong dipetakan, tanpa mengisi sel workbook kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan tiap mode. Tidak diperlukan berkas input. [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Setiap berkas output menyimpan mode yang ditetapkan sebelum menyimpan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja tanpa mengulangi mode.

Perbandingan di bawah memperlihatkan data yang sama dalam ketiga berkas. Hari 3 kosong di workbook dalam setiap kasus:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Efek yang terlihat tergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis yang menghubungkan antar kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol juga dapat tampak serupa. Begitu pula diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Mengatur Lebar Celah Seri**

Lebar celah adalah ruang antara kelompok batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, lebar celah milik grup seri induk bukan milik satu seri. Panggil [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) sekali untuk grup tersebut. Nilai yang lebih besar menciptakan lebih banyak ruang antar kelompok; nilai yang lebih kecil membuatnya lebih padat.

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

![The gap width](gap_width.png)

## **FAQ**

**Jenis diagram apa yang mendukung seri data?**

Semua tipe diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) menggunakan data diagram, tetapi seri‑serinya tidak semua memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [IChartSeriesGroup](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/) berisi seri‑seri yang kompatibel dan berbagi pengaturan plotting tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses lewat satu seri tidak selalu mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [IShapeCollection.addChart](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) membuat seri, kategori, dan nilai contoh. Anda dapat mengedit sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan kumpulan data yang sepenuhnya kustom. Sebuah overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/). Mengubah sel yang direferensikan memperbarui elemen diagram yang bersangkutan. Ketika Anda membangun data kustom, pertahankan baris kategori dan baris nilai‑serai selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa menghapus seluruh seri?**

Setel sel nilai yang bersangkutan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [IChartDataPointCollection.clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapointcollection/#clear--) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan nilai yang dikonfigurasi melalui [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan arti data yang hilang dalam presentasi Anda. Lihat **Mengontrol Tampilan Sel Kosong** untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) dan setel warna yang dikembalikan oleh [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Anda dapat menimpa perilaku untuk titik individu dengan [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Metode‑metode ini memengaruhi format, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika baik seri maupun titik diformat?**

Format titik data eksplisit memiliki prioritas untuk titik tersebut. Titik‑titik lain tetap menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema diagram otomatis. Pengaturan grup seperti overlap dan lebar celah mengontrol tata letak dan bukan merupakan penimpaan format tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas ditentukan oleh kendala berkas presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Panggil [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) pada grup seri induk yang sesuai. Tingkatkan nilainya untuk memperlebar ruang antar kelompok, atau turunkan untuk mendekatkan kelompok.