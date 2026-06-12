---
title: Kelola Seri Data Diagram dalam Presentasi Menggunakan Java
linktitle: Seri Data
type: docs
url: /id/java/chart-series/
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
- Java
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram dalam Java untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartseries/) dalam Aspose.Slides, dengan fokus pada bagaimana data disusun dan divisualisasikan dalam presentasi. Objek-objek ini menyediakan elemen dasar yang mendefinisikan kumpulan titik data, kategori, dan parameter tampilan individu dalam diagram. Dengan bekerja menggunakan [ChartSeries](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartseries/), pengembang dapat dengan mudah mengintegrasikan sumber data yang mendasari dan mempertahankan kontrol penuh atas cara informasi ditampilkan, menghasilkan presentasi yang dinamis dan berbasis data yang dengan jelas menyampaikan wawasan serta analisis.

Sebuah seri adalah baris atau kolom angka yang dipetakan dalam diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

Dengan properti [IChartSeriesOverlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/properties/overlap), Anda dapat menentukan seberapa banyak batang dan kolom harus saling tumpang tindih pada diagram 2D (rentang: -100 hingga 100). Properti ini berlaku untuk semua seri dalam grup seri induk: ini adalah proyeksi dari properti grup yang sesuai. Karena itu, properti ini bersifat read-only. 

Gunakan properti baca/tulis `ParentSeriesGroup.Overlap` untuk mengatur nilai `Overlap` yang Anda pilih. 

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Tambahkan diagram kolom berkelompok pada slide.
1. Akses seri diagram pertama.
1. Akses `ParentSeriesGroup` dari seri diagram dan atur nilai overlap yang Anda inginkan untuk seri tersebut. 
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode Java berikut menunjukkan cara mengatur overlap untuk sebuah seri diagram:

```java
Presentation pres = new Presentation();
try {
    // Menambahkan diagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Menetapkan tumpang tindih seri
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Menulis file presentasi ke disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Warna Seri**

Aspose.Slides untuk Java memungkinkan Anda mengubah warna sebuah seri dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses seri yang ingin Anda ubah warnanya. 
1. Atur jenis isian dan warna isian yang Anda inginkan.
1. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara mengubah warna sebuah seri:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Warna Kategori Seri**

Aspose.Slides untuk Java memungkinkan Anda mengubah warna kategori sebuah seri dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Tambahkan diagram pada slide.
1. Akses kategori seri yang ingin Anda ubah warnanya.
1. Atur jenis isian dan warna isian yang Anda inginkan.
1. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara mengubah warna kategori sebuah seri:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Nama Seri** 

Secara default, nama legenda untuk sebuah diagram diambil dari isi sel di atas setiap kolom atau baris data. 

Dalam contoh kami (gambar contoh), 

* kolom adalah *Series 1, Series 2,* dan *Series 3*;
* baris adalah *Category 1, Category 2, Category 3,* dan *Category 4.* 

Aspose.Slides untuk Java memungkinkan Anda memperbarui atau mengubah nama seri dalam data diagram dan legendanya. 

Kode Java berikut menunjukkan cara mengubah nama seri dalam data diagram `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Kode Java berikut menunjukkan cara mengubah nama seri dalam legendanya melalui`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Warna Isi Seri Diagram**

Aspose.Slides untuk Java memungkinkan Anda mengatur warna isi otomatis untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (dalam contoh di bawah, kami menggunakan `ChartType.ClusteredColumn`).
1. Akses seri diagram dan atur warna isi menjadi Automatic.
1. Simpan presentasi ke file PPTX.

Kode Java berikut menunjukkan cara mengatur warna isi otomatis untuk sebuah seri diagram:

```java
Presentation pres = new Presentation();
try {
    // Membuat diagram kolom berkelompok
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Menetapkan format isi seri menjadi otomatis
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Menulis file presentasi ke disk
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Warna Isi Terbalik untuk Seri Diagram**
Aspose.Slides memungkinkan Anda mengatur warna isi terbalik untuk seri diagram di dalam area plot dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default berdasarkan tipe yang Anda pilih (dalam contoh di bawah, kami menggunakan `ChartType.ClusteredColumn`).
1. Akses seri diagram dan atur warna isi menjadi invert.
1. Simpan presentasi ke file PPTX.

Kode Java berikut menunjukkan operasi tersebut:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Menambahkan seri dan kategori baru
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Mengambil seri diagram pertama dan mengisi data serinya.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Seri Agar Terbalik Ketika Nilai Negatif**
Aspose.Slides memungkinkan Anda mengatur pembalikan melalui properti `IChartDataPoint.InvertIfNegative` dan `ChartDataPoint.InvertIfNegative`. Ketika pembalikan diatur menggunakan properti tersebut, titik data akan membalik warnanya saat mendapatkan nilai negatif. 

Kode Java berikut menunjukkan operasi tersebut:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bersihkan Data Titik Spesifik**
Aspose.Slides untuk Java memungkinkan Anda membersihkan data `DataPoints` untuk seri diagram tertentu dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Dapatkan referensi diagram melalui indeksnya.
4. Iterasi semua `DataPoints` diagram dan atur `XValue` serta `YValue` menjadi null.
5. Bersihkan semua`DataPoints` untuk seri diagram tertentu.
6. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode Java berikut menunjukkan operasi tersebut:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Lebar Celah Seri**

Aspose.Slides untuk Java memungkinkan Anda mengatur Lebar Celah (`GapWidth`) sebuah seri melalui properti **`GapWidth`** dengan cara berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Akses sembarang seri diagram.
1. Atur properti `GapWidth`.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode Java berikut menunjukkan cara mengatur Lebar Celah sebuah seri:

```java
// Membuat presentasi kosong 
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama presentasi
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan diagram dengan data default
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Menetapkan indeks lembar data diagram
    int defaultWorksheetIndex = 0;
    
    // Mengambil lembar kerja data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Menambahkan seri
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Menambahkan Kategori
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Mengambil seri diagram kedua
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
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
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah ada batas berapa banyak seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak memberlakukan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan memori yang tersedia bagi aplikasi Anda.

**Bagaimana jika kolom dalam satu klaster terlalu berdekatan atau terlalu berjauhan?**

Sesuaikan pengaturan `GapWidth` untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai memperlebar jarak antar kolom, sementara menurunkannya membuat kolom menjadi lebih dekat satu sama lain.