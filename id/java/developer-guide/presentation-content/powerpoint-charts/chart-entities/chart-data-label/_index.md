---
title: Kelola Label Data Diagram dalam Presentasi Menggunakan Java
linktitle: Label Data
type: docs
url: /id/java/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Java agar slide lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri diagram dan titik data individu, membantu pembaca mengidentifikasi nilai dan memahami diagram. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengontrol label di luar batas maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan memposisikan label diagram lingkaran.

## **Atur Presisi Data pada Label Data Diagram**

Gunakan [setNumberFormatOfValues](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) untuk memformat nilai seri. Contoh ini membuat diagram garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tampilkan Persentase sebagai Label**

Untuk diagram kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan beri teks ke bingkai teks yang dikembalikan oleh [getTextFrameForOverriding](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Contoh ini menggunakan data diagram default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus jika data diagram berubah.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Tanda Persentase dengan Label Data Diagram**

Ketika nilai disimpan sebagai pecahan, gunakan [setNumberFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) untuk menampilkan persentase. Kirimkan `false` ke [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) untuk menerapkan format label secara terpisah dari sel sumber.

Contoh ini membuat diagram kolom bertumpuk 100% dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai menjumlahkan menjadi 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label berwarna putih dengan ukuran 10 poin.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Baca Teks Sebenarnya dari Label Data**

Gunakan [getActualLabelText](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabel/#getActualLabelText--) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi diagram yang dihasilkan. Pada contoh di bawah, [format label data](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/) default menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan yang lain menggunakan teks khusus dari [getTextFrameForOverriding](https://reference.aspose.com/slides/id/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Angka yang disimpan dalam titik data tetap `0.75`, bahkan ketika labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan teks label yang dihasilkan. [getActualLabelText](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabel/#getActualLabelText--) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [isVisible](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabel/#isVisible--) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda ingin mengekstrak hanya label yang terlihat.

## **Kendalikan Label Data di Luar Batas Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data dapat melebihi maksimum sumbu. Gunakan [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) untuk mengatur apakah label data mereka ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data yang mendasarinya.

Contoh di bawah membuat diagram kolom berkelompok 2D dengan nilai 60 dan 120. Itu mengirim `false` ke [setAutomaticMaxValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) dan menetapkan maksimum menjadi 100 dengan [setMaxValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaxis/#setMaxValue-double-) pada sumbu vertikal. Slide pertama memungkinkan label melampaui maksimum; salinan slide tersebut menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [setShowValue](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Pengaturan pada tingkat diagram tidak secara otomatis menampilkan nilai maupun menggantikan penonaktifan tampilan nilai pada label individu. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [setPosition](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatalabelformat/#setPosition-int-) untuk menempatkan label di ujung luar setiap kolom.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar berikut menunjukkan slide yang disimpan yang dirender oleh Microsoft PowerPoint. Dengan `true`, label **120** terlihat pada batas atas; dengan `false`, label tersebut tersembunyi. Label **60** tetap terlihat, maksimum sumbu tetap **100**, dan titik data kedua tetap **120** dalam kedua kasus.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Diagram PowerPoint yang menampilkan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-true.png) | ![Diagram PowerPoint yang menyembunyikan label nilai 120 dengan maksimum sumbu 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Tipe Diagram" %}}
Contoh ini menggunakan diagram kolom 2D dengan sumbu nilai. Diagram tanpa sumbu nilai, seperti diagram lingkaran dan donat, tidak memiliki maksimum sumbu yang dapat dibatasi dengan cara ini.
{{% /alert %}}

## **Atur Jarak Label dari Sumbu**

Gunakan [setLabelOffset](https://reference.aspose.com/slides/id/java/com.aspose.slides/iaxis/#setLabelOffset-int-) untuk mengontrol jarak antara label sumbu kategori dan sumbu. Nilainya merupakan persentase dari ukuran huruf maksimum label sumbu. Contoh ini membuat diagram kolom berkelompok dan menetapkan offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terikat pada titik data individual.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sesuaikan Lokasi Label**

Pada diagram lingkaran, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis penghubung.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset horizontal dan vertikalnya menggunakan [setX](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutable/#setX-float-) dan [setY](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutable/#setY-float-). Offset ini relatif terhadap lebar dan tinggi diagram, masing-masing.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Diagram lingkaran dengan posisi label data yang disesuaikan](pie-chart-adjusted-label.png)

## **FAQ**

**Bagaimana cara mencegah label data saling tumpang tindih pada diagram yang padat?**

Gabungkan penempatan label otomatis, garis penghubung, dan ukuran huruf yang lebih kecil; bila perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk nilai ekstrem atau titik kunci.

**Bagaimana cara menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang tidak ada sesuai aturan yang ditentukan.

**Bagaimana cara memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga dan ukuran font dan pastikan font tersedia di lingkungan rendering untuk menghindari fallback.