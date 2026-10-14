---
title: Sesuaikan Diagram Lingkaran dalam Presentasi Menggunakan JavaScript
linktitle: Diagram Lingkaran
type: docs
url: /id/nodejs-java/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- sesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan diagram lingkaran dalam JavaScript dengan Aspose.Slides untuk Node.js via Java. Konfigurasikan plot sekunder, tampilkan label data, dan terapkan warna irisan otomatis di PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada tugas penyesuaian diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for Node.js via Java mendukung opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie. Opsi-opsi ini mengontrol ukuran plot sekunder dan cara titik data dibagi antara dua plot.

Contoh berikut membuat diagram Pie of Pie dalam presentasi baru dan menampilkan nilai titik data sebagai label. Metode [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) mengatur ukuran plot sekunder menjadi 149% dari plot utama. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) memilih pemisahan berbasis persentase, dan [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) menetapkan ambang batas menjadi 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Tampilkan nilai dan konfigurasikan plot sekunder.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pilih Kategori untuk Plot Sekunder**

Gunakan pemisahan khusus ketika Anda ingin mengelompokkan kategori tertentu dalam plot sekunder terlepas dari nilai persentasenya. Misalnya, laporan penjualan mungkin menampilkan Online dan Events bersama-sama sehingga pembaca dapat membandingkan dua saluran ini, meskipun keduanya menyumbang 35% dan 10% dari total penjualan.

Panggil [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) dengan [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) dan pilih titik melalui [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metode [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) pada koleksi menerima indeks berbasis nol dalam seri; gunakan [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) untuk menambahkan objek titik data. Dalam contoh ini, indeks 1 memilih Online, dan titik pada indeks 3 memilih Events. Partners juga ditambahkan sementara, kemudian dikecualikan menggunakan [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Ganti data default dengan penjualan per saluran.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Pilih Online berdasarkan indeks berbasis nol dan Events berdasarkan objek titik data.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Kecualikan Partners dari pilihan tanpa menghapus data sumbernya.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) dan Events (10) muncul sebagai irisan terpisah di plot sekunder. Di plot utama, mereka diwakili oleh satu irisan gabungan dengan nilai 45, bersama dengan Retail (40) dan Partners (15). Menghapus Partners dari pilihan khusus mempertahankannya di plot utama; hal itu tidak menghapus kategori atau nilainya dari data sumber diagram.

Gambar berikut menunjukkan presentasi yang disimpan di PowerPoint:

![Diagram Pie of Pie dengan Online dan Events di plot sekunder dan nilai gabungan mereka sebesar 45 di plot utama](pie_of_pie_custom.png)

## **Atur Pewarnaan Irisan Diagram Lingkaran Otomatis**

Aspose.Slides for Node.js via Java dapat secara otomatis menetapkan warna yang berbeda untuk irisan diagram lingkaran. Contoh berikut membuat diagram lingkaran dengan judul terpusat dan mengganti data default dengan tiga kategori kuartalan serta nilai-nilainya. Metode [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) menampilkan nilai 20, 50, dan 30 sebagai label, sementara [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) mengaktifkan warna berbeda untuk setiap irisan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Tambahkan judul bagan yang terpusat.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ganti data default dengan menggunakan lembar kerja pertama.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Tampilkan nilai dan tetapkan warna berbeda pada irisan.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tanya Jawab**

**Apakah variasi Pie of Pie dan Bar of Pie didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe Pie of Pie dan Bar of Pie.

**Bisakah saya mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (seperti PNG) tanpa mengekspor seluruh presentasi.