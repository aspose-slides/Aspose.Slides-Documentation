---
title: Kelola Seri Data Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Seri Data
type: docs
url: /id/nodejs-java/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram dalam JavaScript untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Ringkasan**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/) dalam Aspose.Slides, dengan fokus pada cara data disusun dan divisualisasikan dalam presentasi. Objek-objek ini menyediakan elemen dasar yang mendefinisikan kumpulan titik data, kategori, dan parameter tampilan dalam sebuah diagram. Dengan bekerja dengan [ChartSeries](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/), pengembang dapat mengintegrasikan sumber data secara mulus dan mempertahankan kontrol penuh atas cara informasi ditampilkan, menghasilkan presentasi yang dinamis dan berbasis data serta menyampaikan wawasan dan analisis dengan jelas.

Seri adalah baris atau kolom angka yang dipetakan dalam diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

Dengan metode [ChartSeries.getOverlap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartseries/#getOverlap), Anda dapat menentukan seberapa banyak batang dan kolom harus saling tumpang tindih pada diagram 2D (rentang: -100 hingga 100). Properti ini berlaku untuk semua seri dalam grup seri induk: ini merupakan proyeksi properti grup yang sesuai. Oleh karena itu, properti ini hanya-baca.

Gunakan properti `ParentSeriesGroup.getOverlap` yang dapat dibaca/ditulis untuk mengatur nilai `Overlap` yang Anda inginkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan diagram kolom berkelompok pada slide.
1. Akses seri diagram pertama.
1. Akses `ParentSeriesGroup` seri diagram dan atur nilai overlap yang diinginkan untuk seri tersebut.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode JavaScript ini menunjukkan cara mengatur overlap untuk sebuah seri diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan diagram
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Mengatur tumpang tindih seri
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Menulis file presentasi ke disk
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ubah Warna Seri**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengubah warna seri dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses seri yang warnanya ingin Anda ubah.
1. Atur tipe isian dan warna isian yang diinginkan.
1. Simpan presentasi yang telah dimodifikasi.

Kode JavaScript ini menunjukkan cara mengubah warna seri:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ubah Warna Kategori Seri**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengubah warna kategori seri dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses kategori seri yang warnanya ingin Anda ubah.
1. Atur tipe isian dan warna isian yang diinginkan.
1. Simpan presentasi yang telah dimodifikasi.

Kode JavaScript ini menunjukkan cara mengubah warna kategori seri:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ubah Nama Seri** 

Secara default, nama legenda untuk sebuah diagram merupakan isi sel di atas setiap kolom atau baris data.

Pada contoh kami (gambar contoh),

* kolomnya adalah *Series 1, Series 2,* dan *Series 3*;
* barisnya adalah *Category 1, Category 2, Category 3,* dan *Category 4*.

Aspose.Slides untuk Node.js via Java memungkinkan Anda memperbarui atau mengubah nama seri dalam data diagram dan legenda.

Kode JavaScript ini menunjukkan cara mengubah nama seri dalam `ChartDataWorkbook` diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Kode JavaScript ini menunjukkan cara mengubah nama seri dalam legendanya melalui `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Warna Isian Seri Diagram**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengatur warna isian otomatis untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (pada contoh di bawah, kami menggunakan `ChartType.ClusteredColumn`).
1. Akses seri diagram dan atur warna isian ke Automatic.
1. Simpan presentasi ke file PPTX.

Kode JavaScript ini menunjukkan cara mengatur warna isian otomatis untuk sebuah seri diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Membuat diagram kolom berkelompok
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Mengatur format isian seri menjadi otomatis
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Menulis file presentasi ke disk
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Warna Isian Terbalik Seri Diagram**

Aspose.Slides memungkinkan Anda mengatur warna isian terbalik untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (pada contoh di bawah, kami menggunakan `ChartType.ClusteredColumn`).
1. Akses seri diagram dan atur warna isian ke invert.
1. Simpan presentasi ke file PPTX.

Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Menambahkan seri dan kategori baru
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Mengambil seri diagram pertama dan mengisi data serinya.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Seri Menjadi Terbalik Ketika Nilai Negatif**

Aspose.Slides memungkinkan Anda mengatur pembalikan melalui metode `ChartDataPoint.setInvertIfNegative`. Ketika pembalikan diatur menggunakan properti tersebut, titik data akan membalikkan warnanya ketika memperoleh nilai negatif.

Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bersihkan Data Titik Data Tertentu**

Aspose.Slides untuk Node.js via Java memungkinkan Anda membersihkan data `DataPoints` untuk seri diagram tertentu dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Dapatkan referensi diagram melalui indeksnya.
4. Iterasi semua `DataPoints` diagram dan setel `XValue` serta `YValue` ke null.
5. Bersihkan semua `DataPoints` untuk seri diagram tertentu.
6. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Lebar Celah Seri**

Aspose.Slides untuk Node.js via Java memungkinkan Anda mengatur Lebar Celah (Gap Width) sebuah seri melalui properti **`GapWidth`** dengan cara berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Akses seri diagram mana saja.
1. Setel properti `GapWidth`.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode JavaScript ini menunjukkan cara mengatur Lebar Celah seri:

```javascript
// Membuat presentasi kosong
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama presentasi
    var slide = pres.getSlides().get_Item(0);
    // Menambahkan diagram dengan data default
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Menetapkan indeks lembar data diagram
    var defaultWorksheetIndex = 0;
    // Mendapatkan worksheet data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Menambahkan seri
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Menambahkan Kategori
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Mengambil seri diagram kedua
    var series = chart.getChartData().getSeries().get_Item(1);
    // Mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Menetapkan nilai GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Menyimpan presentasi ke disk
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah ada batasan jumlah seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak memberlakukan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan memori yang tersedia untuk aplikasi Anda.

**Bagaimana jika kolom dalam satu grup terlalu berdekatan atau terlalu jauh?**

Sesuaikan pengaturan Gap Width untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai memperlebar ruang antar kolom, sedangkan menurunkan nilai membuatnya lebih rapat.