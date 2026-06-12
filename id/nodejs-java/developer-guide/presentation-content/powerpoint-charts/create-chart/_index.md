---
title: Buat atau Perbarui Diagram Presentasi PowerPoint dalam JavaScript
linktitle: Buat atau Perbarui Diagram
type: docs
weight: 10
url: /id/nodejs-java/create-chart/
keywords:
- tambahkan diagram
- buat diagram
- edit diagram
- ubah diagram
- perbarui diagram
- diagram sebar
- diagram lingkaran
- diagram garis
- diagram peta pohon
- diagram saham
- diagram kotak dan whisker
- diagram corong
- diagram sunburst
- diagram histogram
- diagram radar
- diagram multi kategori
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan diagram dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js. Tambahkan, format, dan edit diagram dengan contoh kode praktis dalam JavaScript."
---
## **Gambaran Umum**

Artikel ini menyediakan panduan komprehensif tentang cara membuat dan menyesuaikan diagram menggunakan Aspose.Slides. Anda akan belajar cara menambahkan diagram secara programatis ke slide, mengisinya dengan data, dan menerapkan berbagai opsi pemformatan untuk menyesuaikan dengan kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode terperinci mengilustrasikan setiap langkah, mulai dari inisialisasi presentasi dan objek diagram hingga konfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman yang kuat tentang cara mengintegrasikan pembuatan diagram dinamis ke dalam aplikasi Anda, mempermudah proses pembuatan presentasi berbasis data.

## **Membuat Diagram**
Diagram membantu orang dengan cepat memvisualisasikan data dan memperoleh wawasan, yang mungkin tidak langsung terlihat dari tabel atau spreadsheet. 


**Mengapa Membuat Diagram?**

Dengan diagram, Anda dapat

* menggabungkan, merangkum, atau menyederhanakan sejumlah besar data pada satu slide dalam sebuah presentasi
* menampilkan pola dan tren dalam data
* menyimpulkan arah dan momentum data seiring waktu atau terhadap satuan ukuran tertentu 
* menemukan nilai outlier, penyimpangan, kesalahan, data yang tidak masuk akal, dll. 
* menyampaikan atau mempresentasikan data yang kompleks

Di PowerPoint, Anda dapat membuat diagram melalui fungsi sisipkan, yang menyediakan templat untuk merancang berbagai jenis diagram. Menggunakan Aspose.Slides, Anda dapat membuat diagram standar (berdasarkan tipe diagram populer) dan diagram khusus. 

{{% alert color="primary" %}} 

Untuk memungkinkan Anda membuat diagram, Aspose.Slides menyediakan kelas [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType). Field di bawah kelas ini sesuai dengan tipe diagram yang berbeda.

{{% /alert %}} 

### **Membuat Diagram Normal**

_Langkah: Membuat Diagram_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Langkah:</em> Membuat Diagram PowerPoint dalam JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Langkah:</em> Membuat Diagram Presentasi dalam JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Langkah:</em> Membuat Diagram Presentasi PowerPoint dalam JavaScript</strong></a>

_Langkah Kode:_

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan beberapa data dan tentukan tipe diagram yang Anda inginkan. 
4. Tambahkan judul untuk diagram. 
5. Akses worksheet data diagram. 
6. Hapus semua seri dan kategori default. 
7. Tambahkan seri dan kategori baru. 
8. Tambahkan data diagram baru untuk seri diagram. 
9. Tambahkan warna isi untuk seri diagram. 
10. Tambahkan label untuk seri diagram. 
11. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript berikut menampilkan cara membuat diagram normal:

```javascript
// Membuat instance kelas presentasi yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Menambahkan diagram dengan data defaultnya
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Menetapkan Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Menetapkan seri pertama untuk menampilkan nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Menetapkan indeks untuk lembar data diagram
    var defaultWorksheetIndex = 0;
    // Mengambil WorkSheet data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Menghapus seri dan kategori default yang dihasilkan
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Mengambil seri diagram pertama
    var series = chart.getChartData().getSeries().get_Item(0);
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Menetapkan warna isi untuk seri
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Mengambil seri diagram kedua
    series = chart.getChartData().getSeries().get_Item(1);
    // Mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Menetapkan warna isi untuk seri
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Membuat label khusus untuk setiap kategori pada seri baru
    // Menetapkan label pertama untuk menampilkan nama Kategori
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Menampilkan nilai untuk label ketiga
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Menyimpan presentasi dengan diagram
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Sebaran**
Diagram sebar (juga dikenal sebagai scatter plot atau grafik x‑y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel. 

Anda mungkin ingin menggunakan diagram sebar ketika 

* Anda memiliki data numerik berpasangan
* Anda memiliki 2 variabel yang cocok satu sama lain
* Anda ingin menentukan apakah 2 variabel tersebut berhubungan
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Langkah:</em> Membuat Diagram Sebaran dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Langkah:</em> Membuat Diagram Sebaran PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Langkah:</em> Membuat Diagram Sebaran Presentasi PowerPoint dalam JavaScript</strong></a>

1. Ikuti langkah‑langkah yang disebutkan di atas pada [Membuat Diagram Normal](#creating-normal-charts)
2. Pada langkah ketiga, Tambahkan diagram dengan beberapa data dan tentukan tipe diagram Anda sebagai salah satu berikut
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Mewakili Diagram Sebaran dengan Penanda._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Mewakili Diagram Sebaran yang dihubungkan dengan kurva, dengan penanda data._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Mewakili Diagram Sebaran yang dihubungkan dengan kurva, tanpa penanda data._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Mewakili Diagram Sebaran yang dihubungkan dengan garis lurus, dengan penanda data._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Mewakili Diagram Sebaran yang dihubungkan dengan garis lurus, tanpa penanda data._

Kode JavaScript berikut menampilkan cara membuat diagram sebar dengan rangkaian penanda yang berbeda:

```javascript
// Membuat instance kelas presentasi yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Membuat diagram default
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Mendapatkan indeks worksheet data diagram default
    var defaultWorksheetIndex = 0;
    // Mendapatkan worksheet data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Menghapus seri demo
    chart.getChartData().getSeries().clear();
    // Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Mengambil seri diagram pertama
    var series = chart.getChartData().getSeries().get_Item(0);
    // Menambahkan titik baru (1:3) ke seri
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Menambahkan titik baru (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Mengubah tipe seri
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Mengubah penanda seri diagram
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
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
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Lingkaran**

Diagram lingkaran paling cocok untuk menampilkan hubungan bagian‑ke‑keseluruhan dalam data, terutama ketika data berisi label kategorikal dengan nilai numerik. Namun, jika data Anda memiliki banyak bagian atau label, Anda mungkin ingin mempertimbangkan menggunakan diagram batang sebagai gantinya.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Langkah:</em> Membuat Diagram Lingkaran dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Langkah:</em> Membuat Diagram Lingkaran PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Langkah:</em> Membuat Diagram Lingkaran Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam hal ini, [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).Pie).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tambahkan titik baru untuk diagram dan tambahkan warna khusus untuk sektor diagram lingkaran.
9. Atur label untuk seri.
10. Atur garis penunjuk (leader lines) untuk label seri.
11. Atur sudut rotasi untuk slide diagram lingkaran.
12. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram lingkaran:

```javascript
// Membuat instance kelas presentasi yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var slides = pres.getSlides().get_Item(0);
    // Menambahkan diagram dengan data default
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Menetapkan Judul diagram
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Menetapkan seri pertama untuk menampilkan nilai
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Menetapkan indeks untuk lembar data diagram
    var defaultWorksheetIndex = 0;
    // Mengambil worksheet data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Menghapus seri dan kategori default yang dihasilkan
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Menambahkan kategori baru
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Menambahkan seri baru
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Mengisi data seri
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Tidak berfungsi di versi baru
    // Menambahkan titik baru dan mengatur warna sektor
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Menetapkan batas sektor
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Menetapkan batas sektor
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Menetapkan batas sektor
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Membuat label khusus untuk tiap kategori pada seri baru
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Menampilkan Garis Penunjuk untuk Diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Menetapkan Sudut Rotasi untuk Sektor Diagram Lingkaran
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Menyimpan presentasi dengan diagram
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Garis**

Diagram garis (juga dikenal sebagai grafik garis) paling cocok untuk situasi di mana Anda ingin menunjukkan perubahan nilai seiring waktu. Dengan diagram garis, Anda dapat membandingkan banyak data sekaligus, melacak perubahan dan tren seiring waktu, menyoroti anomali dalam seri data, dll.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam hal ini, `ChartType.Line`).
1. Akses data diagram IChartDataWorkbook.
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data diagram baru untuk seri diagram.
1. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram garis:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Secara default, titik pada diagram garis dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik‑titik tersebut dihubungkan oleh garis putus‑putus, Anda dapat menentukan tipe dash yang diinginkan sebagai berikut:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Membuat Diagram Peta Pohon**

Diagram peta pohon paling cocok untuk data penjualan ketika Anda ingin menampilkan ukuran relatif kategori data dan (pada saat yang sama) dengan cepat menarik perhatian ke item yang menjadi kontributor besar bagi tiap kategori. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta Pohon dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta Pohon PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta Pohon Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam hal ini, [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram peta pohon:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // cabang 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // cabang 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Saham**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Langkah:</em> Membuat Diagram Saham dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Langkah:</em> Membuat Diagram Saham PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Langkah:</em> Membuat Diagram Saham Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tentukan format HiLowLines.
9. Simpan presentasi yang telah dimodifikasi ke file PPTX

Contoh kode JavaScript yang digunakan untuk membuat diagram saham:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Kotak‑dan‑Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Langkah:</em> Membuat Diagram Kotak‑dan‑Whisker dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Langkah:</em> Membuat Diagram Kotak‑dan‑Whisker PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Langkah:</em> Membuat Diagram Kotak‑dan‑Whisker Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram kotak‑dan‑whisker:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Corong**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Langkah:</em> Membuat Diagram Corong dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Langkah:</em> Membuat Diagram Corong PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Langkah:</em> Membuat Diagram Corong Presentasi PowerPoint dalam JavaScript</strong></a>


1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).Funnel).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram corong:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Langkah:</em> Membuat Diagram Sunburst dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Langkah:</em> Membuat Diagram Sunburst PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Langkah:</em> Membuat Diagram Sunburst Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (dalam hal ini, [ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).sunburst).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram sunburst:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // cabang 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // cabang 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Histogram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Langkah:</em> Membuat Diagram Histogram dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Langkah:</em> Membuat Diagram Histogram PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Langkah:</em> Membuat Diagram Histogram Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).Histogram).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram histogram:

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Membuat Diagram Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Langkah:</em> Membuat Diagram Radar dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Langkah:</em> Membuat Diagram Radar PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Langkah:</em> Membuat Diagram Radar Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan diagram dengan beberapa data dan tentukan tipe diagram yang Anda inginkan (`ChartType.Radar` dalam hal ini).
4. Simpan presentasi yang telah dimodifikasi ke file PPTX

Kode JavaScript berikut menampilkan cara membuat diagram radar:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Multi Kategori**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Langkah:</em> Membuat Diagram Multi Kategori dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Langkah:</em> Membuat Diagram Multi Kategori PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Langkah:</em> Membuat Diagram Multi Kategori Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan ([ChartType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Akses data diagram [ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Hapus seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Kode JavaScript berikut menampilkan cara membuat diagram multi kategori:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Simpan presentasi dengan diagram
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Peta**

Diagram peta adalah visualisasi area yang berisi data. Diagram peta paling cocok untuk membandingkan data atau nilai antar wilayah geografis.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta PowerPoint dalam JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Langkah:</em> Membuat Diagram Peta Presentasi PowerPoint dalam JavaScript</strong></a>

Kode JavaScript berikut menampilkan cara membuat diagram peta:

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Membuat Diagram Kombinasi**

Diagram kombinasi (atau combo chart) menggabungkan dua atau lebih tipe diagram dalam satu grafik. Diagram ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antar dua atau lebih set data, membantu mengidentifikasi hubungan di antaranya.

![The combination chart](combination_chart.png)

Kode JavaScript berikut menampilkan cara membuat diagram kombinasi yang ditampilkan di atas dalam presentasi PowerPoint:

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Atur judul diagram.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Atur legenda diagram.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Hapus seri dan kategori default yang dihasilkan.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Tambahkan kategori baru.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Tambahkan seri pertama.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Atur sumbu horizontal.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Atur sumbu vertikal.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Atur warna garis kisi utama vertikal.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Atur sumbu horizontal sekunder.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Atur sumbu vertikal sekunder.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Memperbarui Diagram**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Langkah:</em> Memperbarui Diagram PowerPoint dalam JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Langkah:</em> Memperbarui Diagram Presentasi dalam JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Langkah:</em> Memperbarui Diagram Presentasi PowerPoint dalam JavaScript</strong></a>

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang mewakili presentasi yang berisi diagram yang ingin Anda perbarui.
2. Dapatkan referensi slide dengan menggunakan Indeksnya.
3. Telusuri semua shape untuk menemukan diagram yang diinginkan.
4. Akses worksheet data diagram.
5. Ubah data seri diagram dengan mengubah nilai seri.
6. Tambahkan seri baru dan isi data di dalamnya.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript berikut menampilkan cara memperbarui sebuah diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Akses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Dapatkan diagram dengan data default
    var chart = sld.getShapes().get_Item(0);
    // Menetapkan indeks lembar data diagram
    var defaultWorksheetIndex = 0;
    // Mengambil worksheet data diagram
    var fact = chart.getChartData().getChartDataWorkbook();
    // Mengubah Nama Kategori diagram
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Ambil seri diagram pertama
    var series = chart.getChartData().getSeries().get_Item(0);
    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Ambil seri diagram kedua
    series = chart.getChartData().getSeries().get_Item(1);
    // Sekarang memperbarui data seri
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Memodifikasi nama seri
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Sekarang, Menambahkan seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Ambil seri diagram ke-3
    series = chart.getChartData().getSeries().get_Item(2);
    // Sekarang mengisi data seri
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Simpan presentasi dengan diagram
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menetapkan Rentang Data untuk Diagram**

Untuk menetapkan rentang data bagi sebuah diagram, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang mewakili presentasi yang berisi diagram.
2. Dapatkan referensi slide melalui indeksnya.
3. Telusuri semua shape untuk menemukan diagram yang diinginkan.
4. Akses data diagram dan tetapkan rentangnya.
5. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript berikut menampilkan cara menetapkan rentang data untuk sebuah diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menggunakan Penanda Default dalam Diagram**
Saat Anda menggunakan penanda default dalam diagram, setiap seri diagram secara otomatis mendapatkan simbol penanda default yang berbeda.

Kode JavaScript berikut menampilkan cara mengatur penanda seri diagram secara otomatis:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Now populating series data
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jenis diagram apa yang didukung oleh Aspose.Slides?**

Aspose.Slides mendukung berbagai tipe diagram, termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih tipe diagram yang paling sesuai untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan diagram baru ke slide?**

Untuk menambahkan diagram, pertama buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) , dapatkan slide yang diinginkan menggunakan indeksnya, lalu panggil metode untuk menambahkan diagram, menentukan tipe diagram dan data awal. Proses ini mengintegrasikan diagram langsung ke dalam presentasi Anda.

**Bagaimana cara memperbarui data yang ditampilkan dalam diagram?**

Anda dapat memperbarui data diagram dengan mengakses workbook datanya ([ChartDataWorkbook](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chartdataworkbook/)), menghapus semua seri dan kategori default, lalu menambahkan data khusus Anda. Ini memungkinkan Anda memperbarui diagram secara programatis agar mencerminkan data terbaru.

**Apakah memungkinkan untuk menyesuaikan tampilan diagram?**

Ya, Aspose.Slides menyediakan opsi penyesuaian yang luas. Anda dapat memodifikasi warna, font, label, legenda, dan elemen pemformatan lainnya untuk menyesuaikan tampilan diagram sesuai dengan kebutuhan desain spesifik Anda.