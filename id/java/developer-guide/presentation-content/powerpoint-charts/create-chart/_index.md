---
title: Buat atau Perbarui Diagram Presentasi PowerPoint dalam Java
linktitle: Buat atau Perbarui Diagram
type: docs
weight: 10
url: /id/java/create-chart/
keywords:
- tambahkan diagram
- buat diagram
- edit diagram
- ubah diagram
- perbarui diagram
- diagram scatter
- diagram pai
- diagram garis
- diagram peta pohon
- diagram saham
- diagram kotak dan whisker
- diagram corong
- diagram ledakan matahari
- diagram histogram
- diagram radar
- diagram multi‑kategori
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat dan sesuaikan diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Java. Tambahkan, format, dan edit diagram dengan contoh kode praktis dalam Java."
---
## **Ikhtisar**

Artikel ini menyediakan panduan komprehensif tentang cara membuat dan menyesuaikan diagram menggunakan Aspose.Slides. Anda akan belajar cara menambahkan diagram ke slide secara programatik, mengisi data, dan menerapkan berbagai opsi pemformatan untuk memenuhi kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode detail menggambarkan setiap langkah, mulai dari menginisialisasi presentasi dan objek diagram hingga mengkonfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman kuat tentang cara mengintegrasikan pembuatan diagram dinamis ke dalam aplikasi Anda, mempermudah proses pembuatan presentasi berbasis data.

## **Buat Diagram**
Diagram membantu orang dengan cepat memvisualisasikan data dan mendapatkan wawasan, yang mungkin tidak langsung terlihat dari tabel atau spreadsheet. 


**Mengapa Membuat Diagram?**

Dengan diagram, Anda dapat

* menggabungkan, merangkum, atau menyederhanakan sejumlah besar data pada satu slide dalam presentasi
*menampilkan pola dan tren dalam data
*menentukan arah dan momentum data seiring waktu atau terhadap satuan ukuran tertentu 
*menemukan outlier, penyimpangan, deviasi, kesalahan, data yang tidak masuk akal, dll. 
*berkomunikasi atau menyajikan data kompleks

Di PowerPoint, Anda dapat membuat diagram melalui fungsi sisipkan, yang menyediakan templat untuk merancang banyak jenis diagram. Menggunakan Aspose.Slides, Anda dapat membuat diagram biasa (berdasarkan tipe diagram populer) dan diagram khusus. 

{{% alert color="primary" %}} 

Agar Anda dapat membuat diagram, Aspose.Slides menyediakan kelas [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType). Field di dalam kelas ini sesuai dengan berbagai tipe diagram. 

{{% /alert %}} 

### **Buat Diagram Normal**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Langkah:</em> Buat Diagram PowerPoint di Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Langkah:</em> Buat Diagram Presentasi di Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Langkah:</em> Buat Diagram Presentasi PowerPoint di Java</strong></a>

_Code Steps:_

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan beberapa data dan tentukan tipe diagram yang Anda inginkan. 
4. Tambahkan judul untuk diagram. 
5. Akses lembar kerja data diagram. 
6. Hapus semua seri dan kategori default. 
7. Tambahkan seri dan kategori baru. 
8. Tambahkan beberapa data diagram baru untuk seri diagram. 
9. Tambahkan warna isi untuk seri diagram. 
10. Tambahkan label untuk seri diagram. 
11. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat diagram normal:

```java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Menambahkan diagram dengan data defaultnya
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Mengatur Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Mengatur seri pertama untuk menampilkan nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Mengatur indeks untuk lembar data diagram
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan WorkSheet data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Menghapus seri dan kategori yang dihasilkan secara default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Mengambil seri diagram pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Mengatur warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Mengambil seri diagram kedua
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Mengatur warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Buat label khusus untuk setiap kategori bagi seri baru
    // Mengatur label pertama untuk menampilkan nama Kategori
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Menampilkan nilai untuk label ketiga
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Menyimpan presentasi dengan diagram
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Scatter**
Diagram scatter (juga dikenal sebagai scatter plot atau grafik x-y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel. 

Anda mungkin ingin menggunakan diagram scatter ketika 

* Anda memiliki data numerik berpasangan
* Anda memiliki 2 variabel yang cocok bersama
* Anda ingin menentukan apakah 2 variabel saling berhubungan
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Langkah:</em> Buat Diagram Scatter di Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Langkah:</em> Buat Diagram Scatter PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Langkah:</em> Buat Diagram Scatter Presentasi PowerPoint di Java</strong></a>

1. Ikuti langkah‑langkah yang disebutkan di atas pada [Membuat Diagram Normal](#creating-normal-charts)
2. Pada langkah ketiga, Tambahkan diagram dengan beberapa data dan tentukan tipe diagram Anda sebagai salah satu berikut
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Mewakili Diagram Scatter._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Mewakili Diagram Scatter yang terhubung oleh kurva, dengan penanda data._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Mewakili Diagram Scatter yang terhubung oleh kurva, tanpa penanda data._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Mewakili Diagram Scatter yang terhubung oleh garis lurus, dengan penanda data._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Mewakili Diagram Scatter yang terhubung oleh garis lurus, tanpa penanda data._

Kode Java ini menunjukkan cara membuat diagram scatter dengan seri penanda yang berbeda: 

```java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Membuat diagram default
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Mendapatkan indeks worksheet data diagram default
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan worksheet data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Menghapus seri demo
    chart.getChartData().getSeries().clear();
    
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Mengambil seri diagram pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Menambahkan titik baru (1:3) ke seri
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Menambahkan titik baru (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Mengubah tipe seri
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Mengubah penanda seri diagram
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Mengambil seri diagram kedua
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Menambahkan titik baru (5:2) di sana
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Menambahkan titik baru (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Menambahkan titik baru (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Menambahkan titik baru (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Mengubah penanda seri diagram
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Pie**

Diagram pie paling baik digunakan untuk menunjukkan hubungan bagian‑ke‑keseluruhan dalam data, terutama ketika data berisi label kategori dengan nilai numerik. Namun, jika data Anda memiliki banyak bagian atau label, Anda mungkin ingin mempertimbangkan menggunakan diagram batang sebagai gantinya.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Langkah:</em> Buat Diagram Pie di Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Langkah:</em> Buat Diagram Pie PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Langkah:</em> Buat Diagram Pie Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam kasus ini, [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).Pie).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tambahkan titik baru untuk diagram dan tambahkan warna khusus untuk sektor diagram pie.
9. Atur label untuk seri.
10. Atur garis pemimpin untuk label seri.
11. Atur sudut rotasi untuk slide diagram pie.
12. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram pie:

```java
// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Menambahkan diagram dengan data default
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Mengatur Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Mengatur seri pertama untuk menampilkan nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Mengatur indeks untuk lembar data diagram
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan worksheet data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Menghapus seri dan kategori yang dihasilkan secara default
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Menambahkan seri baru
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Mengisi data seri
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Tidak berfungsi pada versi baru
    // Menambahkan titik baru dan mengatur warna sektor
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Mengatur batas sektor
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Mengatur batas sektor
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Mengatur batas sektor
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Membuat label khusus untuk setiap kategori pada seri baru
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Menampilkan Garis Pemimpin untuk Diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Mengatur Sudut Rotasi untuk Sektor Diagram Pai
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Menyimpan presentasi dengan diagram
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Line**

Diagram line (juga dikenal sebagai grafik garis) paling baik digunakan dalam situasi di mana Anda ingin menunjukkan perubahan nilai seiring waktu. Dengan diagram line, Anda dapat membandingkan banyak data sekaligus, melacak perubahan dan tren dari waktu ke waktu, menyoroti anomali dalam seri data, dll.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam kasus ini, `ChartType.Line`).
1. Akses data diagram IChartDataWorkbook.
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data diagram baru untuk seri diagram.
1. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram line:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Secara default, titik pada diagram line dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik‑titik tersebut dihubungkan dengan garis putus‑putus, Anda dapat menentukan tipe dash yang diinginkan dengan cara berikut:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Buat Diagram Tree Map**

Diagram tree map paling baik digunakan untuk data penjualan ketika Anda ingin menunjukkan ukuran relatif kategori data dan (pada saat yang sama) dengan cepat menarik perhatian ke item yang memberikan kontribusi besar pada tiap kategori. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Langkah:</em> Buat Diagram Tree Map di Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Langkah:</em> Buat Diagram Tree Map PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Langkah:</em> Buat Diagram Tree Map Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam kasus ini, [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).TreeMap).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram tree map:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //cabang 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //cabang 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Stock**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Langkah:</em> Buat Diagram Stock di Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Langkah:</em> Buat Diagram Stock PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Langkah:</em> Buat Diagram Stock Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tentukan format HiLowLines.
9. Simpan presentasi yang telah dimodifikasi ke file PPTX

Contoh kode Java yang digunakan untuk membuat diagram stock:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Box and Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Langkah:</em> Buat Diagram Box and Whisker di Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Langkah:</em> Buat Diagram Box and Whisker PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Langkah:</em> Buat Diagram Box and Whisker Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram box and whisker:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Funnel**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Langkah:</em> Buat Diagram Funnel di Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Langkah:</em> Buat Diagram Funnel PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Langkah:</em> Buat Diagram Funnel Presentasi PowerPoint di Java</strong></a>


1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).Funnel).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java yang menunjukkan cara membuat diagram funnel:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Langkah:</em> Buat Diagram Sunburst di Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Langkah:</em> Buat Diagram Sunburst PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Langkah:</em> Buat Diagram Sunburst Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam kasus ini, [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).sunburst).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram sunburst:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //cabang 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //cabang 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Histogram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Langkah:</em> Buat Diagram Histogram di Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Langkah:</em> Buat Diagram Histogram PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Langkah:</em> Buat Diagram Histogram Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).Histogram).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram histogram:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Langkah:</em> Buat Diagram Radar di Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Langkah:</em> Buat Diagram Radar PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Langkah:</em> Buat Diagram Radar Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan diagram dengan beberapa data dan tentukan tipe diagram yang Anda inginkan (`ChartType.Radar` dalam kasus ini).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode Java ini menunjukkan cara membuat diagram radar:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Multi‑Category**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Langkah:</em> Buat Diagram Multi‑Category di Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Langkah:</em> Buat Diagram Multi‑Category PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Langkah:</em> Buat Diagram Multi‑Category Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Akses data diagram [IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Kode Java ini menunjukkan cara membuat diagram multi‑category:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Menambahkan Seri
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Simpan presentasi dengan diagram
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Peta**

Diagram peta adalah visualisasi area yang berisi data. Diagram peta paling baik digunakan untuk membandingkan data atau nilai di seluruh wilayah geografis.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Langkah:</em> Buat Diagram Peta di Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Langkah:</em> Buat Diagram Peta PowerPoint di Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Langkah:</em> Buat Diagram Peta Presentasi PowerPoint di Java</strong></a>

Kode Java ini menunjukkan cara membuat diagram peta:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Diagram Kombinasi**

Diagram kombinasi (atau combo chart) menggabungkan dua atau lebih tipe diagram dalam satu grafik. Diagram ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan di antaranya.

![The combination chart](combination_chart.png)

Kode Java berikut menunjukkan cara membuat diagram kombinasi seperti yang ditampilkan di atas dalam sebuah presentasi PowerPoint:

```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Atur judul diagram.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Atur legenda diagram.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Hapus seri dan kategori yang dihasilkan secara default.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Tambahkan kategori baru.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Tambahkan seri pertama.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Atur sumbu horizontal.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Atur sumbu vertikal.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Atur warna garis kisi utama vertikal.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Atur sumbu horizontal sekunder.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Atur sumbu vertikal sekunder.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Perbarui Diagram**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Langkah:</em> Perbarui Diagram PowerPoint di Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Langkah:</em> Perbarui Diagram Presentasi di Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Langkah:</em> Perbarui Diagram Presentasi PowerPoint di Java</strong></a>

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang mewakili presentasi yang berisi diagram yang ingin Anda perbarui. 
2. Dapatkan referensi slide dengan menggunakan indeksnya.
3. Telusuri semua shape untuk menemukan diagram yang diinginkan.
4. Akses lembar kerja data diagram.
5. Modifikasi data seri diagram dengan mengubah nilai seri.
6. Tambahkan seri baru dan isi data di dalamnya.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara memperbarui diagram:

```java
Presentation pres = new Presentation();
try {
    // Akses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Dapatkan diagram dengan data default
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Mengatur indeks lembar data diagram
    int defaultWorksheetIndex = 0;

    // Mengambil worksheet data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Mengubah Nama Kategori diagram
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Ambil seri diagram pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Ambil seri diagram kedua
    series = chart.getChartData().getSeries().get_Item(1);

    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Sekarang, Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Ambil seri diagram ketiga
    series = chart.getChartData().getSeries().get_Item(2);

    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Simpan presentasi dengan diagram
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Rentang Data untuk Diagram**

Untuk mengatur rentang data untuk sebuah diagram, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang mewakili presentasi yang berisi diagram.
2. Dapatkan referensi slide melalui indeksnya.
3. Telusuri semua shape untuk menemukan diagram yang diinginkan.
4. Akses data diagram dan atur rentangnya.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengatur rentang data untuk diagram:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gunakan Penanda Default di Diagram**
Ketika Anda menggunakan penanda default di diagram, setiap seri diagram secara otomatis mendapatkan simbol penanda default yang berbeda.

Kode Java ini menunjukkan cara mengatur penanda seri diagram secara otomatis:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Ambil seri diagram kedua
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Sekarang mengisi data seri
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tipe diagram apa saja yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung berbagai [tipe diagram](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/), termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih tipe diagram yang paling sesuai untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan diagram baru ke slide?**

Untuk menambahkan diagram, pertama buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) , dapatkan slide yang diinginkan menggunakan indeksnya, lalu panggil metode untuk menambahkan diagram dengan menentukan tipe diagram dan data awal. Proses ini mengintegrasikan diagram secara langsung ke dalam presentasi Anda.

**Bagaimana cara memperbarui data yang ditampilkan pada diagram?**

Anda dapat memperbarui data diagram dengan mengakses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdataworkbook/)), menghapus semua seri dan kategori default, lalu menambahkan data khusus Anda. Hal ini memungkinkan Anda menyegarkan diagram untuk mencerminkan data terbaru.

**Apakah mungkin menyesuaikan tampilan diagram?**

Ya, Aspose.Slides menyediakan opsi penyesuaian yang luas. Anda dapat mengubah warna, font, label, legenda, dan elemen [formatting](/slides/id/java/chart-entities/) lainnya untuk menyesuaikan tampilan diagram dengan persyaratan desain spesifik Anda.