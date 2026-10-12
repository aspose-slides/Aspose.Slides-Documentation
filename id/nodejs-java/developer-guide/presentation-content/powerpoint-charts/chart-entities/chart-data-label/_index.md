---
title: "Kelola Label Data Diagram dalam Presentasi Menggunakan JavaScript"
linktitle: "Label Data"
type: docs
url: /id/nodejs-java/chart-data-label/
keywords:
- "diagram"
- "label data"
- "presisi data"
- "persentase"
- "jarak label"
- "lokasi label"
- "PowerPoint"
- "presentasi"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint menggunakan JavaScript dan Aspose.Slides untuk Node.js melalui Java untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri diagram dan titik data individual, membantu pembaca mengidentifikasi nilai dan memahami diagram. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengendalikan label di luar batas maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan menempatkan label diagram pai.

## **Atur Presisi Data dalam Label Data Diagram**

Gunakan [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) untuk memformat nilai seri. Contoh ini membuat diagram garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tampilkan Persentase sebagai Label**

Untuk diagram kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan tetapkan teks ke bingkai teks yang dikembalikan oleh [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Contoh ini menggunakan data diagram default dan menampilkan persentase dengan dua tempat desimal dalam font berukuran 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus bila data diagram berubah.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Tanda Persentase dengan Label Data Diagram**

Ketika nilai disimpan sebagai pecahan, gunakan [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) untuk menampilkan persentase. Berikan `false` ke [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) untuk menerapkan format label secara independen dari sel sumber.

Contoh ini membuat diagram kolom 100% bertumpuk dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai berjumlah 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label putih berukuran 10 poin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Baca Teks Aktual dari Label Data**

Gunakan [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi diagram yang dihasilkan. Pada contoh di bawah, format [label data default](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan yang lain menggunakan teks khusus dari [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Angka yang disimpan dalam sebuah titik data tetap `0.75`, meskipun labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan label yang dihasilkan. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda hanya ingin mengekstrak label yang terlihat.

## **Kendalikan Label Data Melebihi Batas Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data mungkin melampaui maksimum. Gunakan [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) untuk mengontrol apakah label data mereka ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data yang mendasarinya.

Contoh di bawah membuat diagram kolom berkelompok 2D dengan nilai 60 dan 120. Ia memberikan `false` ke [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) dan menetapkan maksimum menjadi 100 dengan [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) pada sumbu vertikal. Slide pertama mengizinkan label melampaui maksimum; salinan slide tersebut menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Pengaturan tingkat diagram tidak mengaktifkan tampilan nilai secara mandiri atau menggantikan penonaktifan tampilan nilai label individual. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) untuk menempatkan label di ujung luar setiap kolom.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gambar berikut menunjukkan slide yang disimpan yang dirender oleh Microsoft PowerPoint. Dengan `true`, label **120** terlihat pada batas atas; dengan `false`, label tersebut disembunyikan. Label **60** tetap terlihat, maksimum sumbu tetap **100**, dan titik data kedua tetap **120** dalam kedua kasus.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Contoh ini menggunakan diagram kolom 2D dengan sumbu nilai. Diagram tanpa sumbu nilai, seperti diagram pai dan donat, tidak memiliki maksimum sumbu yang dapat dibatasi dengan cara ini.
{{% /alert %}}

## **Atur Jarak Label dari Sumbu**

Gunakan [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) untuk mengontrol jarak antara label sumbu kategori dan sumbu. Nilainya adalah persentase dari ukuran font maksimum label sumbu. Contoh ini membuat diagram kolom berkelompok dan menetapkan offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terpasang pada titik data individual.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sesuaikan Lokasi Label**

Pada diagram pai, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis pemimpin.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset horizontal dan vertikal menggunakan [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) dan [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). Offset ini relatif terhadap lebar dan tinggi diagram masing‑masing.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Diagram pai dengan posisi label data yang disesuaikan](pie-chart-adjusted-label.png)

## **Tambah Beberapa Baris Label Data Di Atas Diagram Kolom**

Contoh ini membuat diagram kolom dengan dua baris label data di atas area plot. Seri A menampilkan kolom yang terlihat, sementara Seri B dan Seri C menyediakan label tambahan. Kolom mereka disembunyikan dengan menghapus isian dan outline. Metode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) menyelaraskan ketiga seri dengan pusat kategori yang sama.

Pengaturan [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) menyediakan ruang untuk baris label. Setelah [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) menghitung posisi default, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) dan [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) mempertahankan penyelarasan horizontal dan menerapkan offset vertikal untuk menata label dalam dua baris. Angka tetap menjadi label data yang terhubung ke nilai seri; hanya judul baris yang merupakan bentuk teks terpisah.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Sembunyikan kolom B dan C, tetapi pertahankan label data mereka.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Ratakan ketiga seri dengan pusat kategori yang sama.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Gunakan lebih sedikit garis kisi untuk contoh yang ringkas ini.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Cadangkan ruang di atas area plot untuk dua baris label data.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Pertahankan posisi horizontal default. Y adalah offset dari
            // posisi label default, dinyatakan sebagai pecahan tinggi diagram.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Hanya heading baris yang merupakan bentuk teks terpisah.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Diagram kolom dengan dua baris label data di atas area plot](multiple-rows-of-labels.png)

## **FAQ**

**Bagaimana saya dapat mencegah label data saling tumpang tindih pada diagram yang padat?**  
Gabungkan penempatan label otomatis, garis pemimpin, dan ukuran font yang diperkecil; jika perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk nilai ekstrim atau titik penting.

**Bagaimana saya dapat menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**  
Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditetapkan.

**Bagaimana saya dapat memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**  
Tetapkan secara eksplisit keluarga font dan ukuran, serta pastikan font tersedia di lingkungan rendering untuk menghindari fallback.