---
title: Buat atau Perbarui Grafik Presentasi PowerPoint di Android
linktitle: Buat atau Perbarui Grafik
type: docs
weight: 10
url: /id/androidjava/create-chart/
keywords:
- menambahkan grafik
- membuat grafik
- menyunting grafik
- mengubah grafik
- memperbarui grafik
- grafik sebar
- grafik pai
- grafik garis
- grafik peta pohon
- grafik saham
- grafik kotak dan gigi garpu
- grafik corong
- grafik matahari
- grafik histogram
- grafik radar
- grafik multi kategori
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Android. Tambahkan, format, dan edit grafik dengan contoh kode Java yang praktis."
---
## **Gambaran Umum**

Artikel ini memberikan panduan komprehensif tentang cara membuat dan menyesuaikan grafik menggunakan Aspose.Slides. Anda akan belajar cara menambahkan grafik secara programatis ke slide, mengisinya dengan data, dan menerapkan berbagai opsi pemformatan untuk memenuhi kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode terperinci mengilustrasikan setiap langkah, mulai dari menginisialisasi presentasi dan objek grafik hingga mengonfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan mendapatkan pemahaman mendalam tentang cara mengintegrasikan pembuatan grafik dinamis ke dalam aplikasi Anda, menyederhanakan proses pembuatan presentasi berbasis data.

## **Buat Grafik**

Grafik membantu orang memvisualisasikan data dengan cepat dan mendapatkan wawasan yang mungkin tidak langsung terlihat dari tabel atau lembar kerja.

**Mengapa Membuat Grafik?**

Dengan grafik, Anda dapat:

* menggabungkan, merangkum, atau menyederhanakan sejumlah besar data pada satu slide dalam presentasi
* mengungkap pola dan tren dalam data
* menyimpulkan arah dan momentum data seiring waktu atau terhadap satuan ukuran tertentu
* menemukan outlier, penyimpangan, kesalahan, data yang tidak masuk akal, dll.
* mengkomunikasikan atau mempresentasikan data yang kompleks

Di PowerPoint, Anda dapat membuat grafik melalui fungsi *Insert*, yang menyediakan templat untuk merancang berbagai jenis grafik. Menggunakan Aspose.Slides, Anda dapat membuat grafik reguler (berdasarkan tipe grafik populer) dan grafik khusus.

{{% alert color="info" title="Note" %}}
Untuk membuat grafik, gunakan kelas [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) . Bidang‑bidang dalam kelas ini berkorespondensi dengan tipe grafik yang berbeda.
{{% /alert %}}

### **Buat Grafik Kolom Berkelompok**

Bagian ini menjelaskan cara membuat grafik kolom berkelompok menggunakan Aspose.Slides. Anda akan belajar menginisialisasi presentasi, menambahkan grafik, dan menyesuaikan elemennya seperti judul, data, seri, kategori, dan gaya. Ikuti langkah‑langkah di bawah ini untuk melihat bagaimana grafik kolom berkelompok standar dihasilkan:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan beberapa data dan tentukan tipe `ChartType.ClusteredColumn` .
4. Tambahkan judul ke grafik.
5. Akses worksheet data grafik.
6. Hapus semua seri dan kategori default.
7. Tambahkan seri dan kategori baru.
8. Tambahkan data grafik baru untuk seri grafik.
9. Terapkan warna isi ke seri grafik.
10. Tambahkan label ke seri grafik.
11. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik kolom berkelompok:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Menambahkan grafik dengan data defaultnya
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Mengatur Judul grafik
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Mengatur indeks untuk lembar data grafik
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan WorkSheet data grafik
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
    
    // Mengambil seri grafik pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Mengatur warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Mengambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Mengatur warna isi untuk seri
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Create label khusus untuk setiap kategori untuk seri baru
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
    
    // Menyimpan presentasi dengan grafik
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Sebar**

Grafik sebar (juga dikenal sebagai scatter plot atau grafik x‑y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel.

Gunakan grafik sebar ketika:

* Anda memiliki data numerik berpasangan
* Anda memiliki dua variabel yang saling berkaitan
* Anda ingin menentukan apakah dua variabel terkait
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen

1. Ikuti langkah‑langkah di [Buat Grafik Kolom Berkelompok](#buat-grafik-kolom-berkelompok) .
2. Untuk langkah ketiga, tambahkan grafik dengan beberapa data dan tentukan tipe grafik Anda sebagai salah satu berikut:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Mewakili grafik sebar._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Mewakili grafik sebar yang dihubungkan oleh kurva, dengan penanda data._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Mewakili grafik sebar yang dihubungkan oleh kurva, tanpa penanda data._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Mewakili grafik sebar yang dihubungkan oleh garis, dengan penanda data._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Mewakili grafik sebar yang dihubungkan oleh garis, tanpa penanda data._

Kode Java ini menunjukkan cara membuat grafik sebar dengan penanda yang berbeda untuk setiap seri:

```java
import com.aspose.slides.*;

// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Membuat grafik default
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Mendapatkan indeks worksheet data grafik default
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan worksheet data grafik
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Menghapus seri demo
    chart.getChartData().getSeries().clear();
    
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Mengambil seri grafik pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Menambahkan titik baru (1:3) ke seri
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Menambahkan titik baru (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Mengubah tipe seri
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Mengubah penanda seri grafik
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Mengambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Menambahkan titik baru (5:2) di sana
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Menambahkan titik baru (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Menambahkan titik baru (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Menambahkan titik baru (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Mengubah penanda seri grafik
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Pai**

Grafik pai paling cocok untuk menunjukkan hubungan bagian‑dengan‑keseluruhan dalam data, terutama ketika data berisi label kategori dengan nilai numerik. Namun, bila data Anda memiliki banyak bagian atau label, pertimbangkan menggunakan grafik batang sebagai gantinya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Pie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Pie) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Tambahkan titik baru untuk grafik dan terapkan warna khusus untuk sektor grafik pai.
9. Atur label untuk seri.
10. Aktifkan garis pemimpin untuk label seri.
11. Tetapkan sudut rotasi untuk sektor grafik pai.
12. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik pai:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas presentasi yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Menambahkan grafik dengan data default
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Mengatur Judul grafik
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Mengatur indeks untuk lembar data grafik
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan worksheet data grafik
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
    
    // Menampilkan Garis Pemimpin untuk Grafik
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Mengatur Sudut Rotasi untuk Sektor Grafik Pai
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Menyimpan presentasi dengan grafik
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Garis**

Grafik garis (juga dikenal sebagai grafik line) paling cocok untuk situasi di mana Anda ingin menunjukkan perubahan nilai seiring waktu. Dengan grafik garis, Anda dapat membandingkan sejumlah besar data sekaligus, melacak perubahan dan tren seiring waktu, menyoroti anomali dalam seri data, dan lain‑lain.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Line) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik garis:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Secara default, titik pada grafik garis dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik‑titik tersebut dihubungkan oleh garis putus‑putus, Anda dapat menentukan tipe dash yang diinginkan sebagai berikut:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Peta Pohon**

Grafik peta pohon paling cocok untuk data penjualan ketika Anda ingin menunjukkan ukuran relatif kategori data dan dengan cepat menarik perhatian ke item yang menjadi kontributor besar dalam setiap kategori.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Treemap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Treemap) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik peta pohon:

```java
import com.aspose.slides.*;

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

### **Buat Grafik Saham**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Tentukan format garis tinggi‑rendah.
9. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik saham:

```java
import com.aspose.slides.*;

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

### **Buat Grafik Kotak dan Gigi Garpu**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik kotak dan gigi garpu:

```java
import com.aspose.slides.*;

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

### **Buat Grafik Corong**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Funnel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Funnel) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik corong:

```java
import com.aspose.slides.*;

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

### **Buat Grafik Sunburst**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Sunburst](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Sunburst) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik sunburst:

```java
import com.aspose.slides.*;

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

### **Buat Grafik Histogram**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.Histogram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Histogram) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik histogram:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Radar**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan beberapa data dan tentukan tipe grafik pilihan Anda ([ChartType.Radar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Radar) dalam hal ini) .
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik radar:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Multi‑Kategori**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan grafik dengan data default dan tentukan tipe [ChartType.ClusteredColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ClusteredColumn) .
4. Akses workbook data grafik [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data grafik baru untuk seri grafik.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara membuat grafik multi‑kategori:

```java
import com.aspose.slides.*;

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
    
    // Simpan presentasi dengan grafik
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Peta**

Grafik peta memvisualisasikan data geografis dan membantu membandingkan nilai antar wilayah.

Kode Java ini menunjukkan cara membuat grafik peta:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Buat Grafik Kombinasi**

Grafik kombinasi (atau combo chart) menggabungkan dua atau lebih tipe grafik dalam satu grafik. Grafik ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan di antaranya.

![Grafik kombinasi](combination_chart.png)

Kode Java berikut menunjukkan cara membuat grafik kombinasi yang ditampilkan di atas dalam presentasi PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Atur judul grafik.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Atur legenda grafik.
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

## **Perbarui Grafik**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) yang mewakili presentasi berisi grafik yang ingin Anda perbarui.
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Telusuri semua shape untuk menemukan grafik yang diinginkan.
4. Akses worksheet data grafik.
5. Ubah seri data grafik dengan mengubah nilai seri.
6. Tambahkan seri baru dan isi datanya.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara memperbarui grafik:

```java
import com.aspose.slides.*;

// Membuka presentasi yang berisi grafik yang akan diperbarui
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendapatkan grafik dari slide
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Menetapkan indeks lembar data grafik
    int defaultWorksheetIndex = 0;

    // Mendapatkan worksheet data grafik
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Mengubah Nama Kategori grafik
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Ambil seri grafik pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Mengubah nama seri
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Ambil seri grafik kedua
    series = chart.getChartData().getSeries().get_Item(1);

    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Mengubah nama seri
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Sekarang, Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Ambil seri grafik ketiga
    series = chart.getChartData().getSeries().get_Item(2);

    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Simpan presentasi dengan grafik
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Rentang Data untuk Grafik**

Untuk memeriksa rentang yang sudah digunakan oleh grafik yang ada, lihat [Ambil Rentang Data Grafik](/slides/id/androidjava/chart-workbook/#retrieve-a-charts-data-range) .

Untuk mengatur rentang data bagi grafik, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) yang mewakili presentasi berisi grafik.
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Telusuri semua shape untuk menemukan grafik yang diinginkan.
4. Akses data grafik dan tentukan rentangnya.
5. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara mengatur rentang data untuk grafik:

```java
import com.aspose.slides.*;

// Membuka presentasi yang berisi grafik
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gunakan Penanda Default dalam Grafik**

Saat Anda menggunakan penanda default dalam grafik, setiap seri grafik secara otomatis mendapatkan simbol penanda yang berbeda.

Kode Java ini menunjukkan cara mengatur penanda seri grafik secara otomatis:

```java
import com.aspose.slides.*;

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
    //Ambil seri grafik kedua
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Sekarang mengisi data seri
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

**Apa tipe grafik yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung beragam [tipe grafik](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) , termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih tipe grafik yang paling tepat untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan grafik baru ke slide?**

Untuk menambahkan grafik, pertama buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) , ambil slide yang diinginkan menggunakan indeksnya, kemudian panggil metode untuk menambahkan grafik, dengan menentukan tipe grafik dan data awal. Proses ini mengintegrasikan grafik langsung ke dalam presentasi Anda.

**Bagaimana saya dapat memperbarui data yang ditampilkan dalam grafik?**

Anda dapat memperbarui data grafik dengan mengakses workbook datanya ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ), menghapus semua seri dan kategori default, lalu menambahkan data khusus Anda. Hal ini memungkinkan Anda menyegarkan grafik agar mencerminkan data terbaru.

**Apakah memungkinkan untuk menyesuaikan tampilan grafik?**

Ya, Aspose.Slides menyediakan opsi penyesuaian yang luas. Anda dapat mengubah warna, font, label, legenda, dan [elemen pemformatan](/slides/id/androidjava/chart-entities/) lainnya untuk menyesuaikan tampilan grafik sesuai kebutuhan desain spesifik Anda.