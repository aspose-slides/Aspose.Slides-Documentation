---
title: Buat atau Perbarui Diagram Presentasi PowerPoint di .NET
linktitle: Buat atau Perbarui Diagram
type: docs
weight: 10
url: /id/net/create-chart/
keywords:
- menambahkan diagram
- membuat diagram
- mengedit diagram
- mengubah diagram
- memperbarui diagram
- diagram sebar
- diagram pie
- diagram garis
- diagram peta pohon
- diagram saham
- diagram box dan whisker
- diagram corong
- diagram sunburst
- diagram histogram
- diagram radar
- diagram multi kategori
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Tambahkan, format, dan edit diagram dengan contoh kode praktis dalam C#."
---
## **Ikhtisar**

Artikel ini memberikan panduan komprehensif tentang cara membuat dan menyesuaikan diagram menggunakan Aspose.Slides untuk .NET. Anda akan mempelajari cara menambahkan diagram secara programatik ke slide, mengisi dengan data, dan menerapkan berbagai opsi pemformatan untuk memenuhi kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode terperinci mengilustrasikan setiap langkah, mulai dari menginisialisasi presentasi dan objek diagram hingga mengkonfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman yang kuat tentang cara mengintegrasikan pembuatan diagram dinamis ke dalam aplikasi .NET Anda, mempercepat proses pembuatan presentasi berbasis data.

## **Buat Diagram**

Diagram membantu orang dengan cepat memvisualisasikan data dan memperoleh wawasan yang mungkin tidak langsung terlihat dari tabel atau spreadsheet.

**Mengapa Membuat Diagram?**

Menggunakan diagram, Anda dapat:

* mengagregasi, merangkum, atau menyimpulkan sejumlah besar data pada satu slide dalam presentasi;
* menunjukkan pola dan tren dalam data;
* menyimpulkan arah dan momentum data dari waktu ke waktu atau terhadap satuan ukuran tertentu;
* mendeteksi outlier, penyimpangan, deviasi, kesalahan, dan data yang tidak masuk akal;
* mengkomunikasikan atau menyajikan data yang kompleks.

Di PowerPoint, Anda dapat membuat diagram melalui fungsi *Insert*, yang menyediakan templat untuk merancang banyak jenis diagram. Dengan Aspose.Slides, Anda dapat membuat diagram reguler (berdasarkan jenis diagram populer) dan diagram khusus.

{{% alert color="primary" %}} 
Gunakan enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) di bawah namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/id/net/aspose.slides.charts/). Nilai-nilai dalam enumerasi ini sesuai dengan berbagai jenis diagram.
{{% /alert %}} 

### **Buat Diagram Kolom Berkelompok**

Bagian ini menjelaskan cara membuat diagram kolom berkelompok menggunakan Aspose.Slides untuk .NET. Anda akan belajar menginisialisasi presentasi, menambahkan diagram, dan menyesuaikan elemennya seperti judul, data, seri, kategori, dan gaya. Ikuti langkah‑langkah di bawah untuk melihat bagaimana diagram kolom berkelompok standar dihasilkan:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan beberapa data dan tentukan tipe `ChartType.ClusteredColumn`.
4. Tambahkan judul ke diagram.
5. Akses lembar kerja data diagram.
6. Hapus semua seri dan kategori default.
7. Tambahkan seri dan kategori baru.
8. Tambahkan data diagram baru untuk seri diagram.
9. Terapkan warna isi pada seri diagram.
10. Tambahkan label ke seri diagram.
11. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram kolom berkelompok:

```c#
// Membuat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Menambahkan diagram kolom berkelompok dengan data defaultnya.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Mengatur judul diagram.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Mengatur seri pertama agar menampilkan nilai.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Mengatur indeks lembar data diagram.
    int worksheetIndex = 0;

    // Mendapatkan workbook data diagram.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Menghapus seri dan kategori default yang dihasilkan.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Menambahkan seri baru.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Menambahkan kategori baru.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Mendapatkan seri diagram pertama.
    IChartSeries series = chart.ChartData.Series[0];

    // Mengisi data seri.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Mengatur warna isi untuk seri.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Mendapatkan seri diagram kedua.
    series = chart.ChartData.Series[1];

    // Mengisi data seri.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Mengatur warna isi untuk seri.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Mengatur label pertama agar menampilkan nama kategori.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Mengatur seri agar menampilkan nilai pada label ketiga.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Menyimpan presentasi ke disk sebagai file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Kolom Berkelompok](clustered_column_chart.png)

### **Buat Diagram Sebar**

Diagram sebar (juga dikenal sebagai scatter plot atau grafik x-y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel.

Gunakan diagram sebar ketika:

* Anda memiliki data numerik berpasangan.
* Anda memiliki dua variabel yang berpasangan baik.
* Anda ingin menentukan apakah kedua variabel saling terkait.
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen.

Kode C# ini menunjukkan cara membuat diagram sebar dengan rangkaian penanda yang berbeda:

```c#
// Membuat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Membuat diagram sebar default.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Mengatur indeks lembar data diagram.
    int worksheetIndex = 0;

    // Mendapatkan workbook data diagram.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Menghapus seri default.
    chart.ChartData.Series.Clear();

    // Menambahkan seri baru.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Mendapatkan seri diagram pertama.
    IChartSeries series = chart.ChartData.Series[0];

    // Menambahkan titik baru (1:3) ke seri.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Menambahkan titik baru (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Mengubah tipe seri.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Mengubah penanda seri diagram.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Mendapatkan seri diagram kedua.
    series = chart.ChartData.Series[1];

    // Menambahkan titik baru (5:2) ke seri diagram.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Menambahkan titik baru (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Menambahkan titik baru (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Menambahkan titik baru (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Mengubah penanda seri diagram.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Menyimpan presentasi ke disk sebagai file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Sebar](scatter_chart.png)

### **Buat Diagram Pie**

Diagram pie paling cocok untuk menampilkan hubungan bagian‑dengan‑seluruh dalam data, terutama ketika data berisi label kategori dengan nilai numerik. Namun, jika data Anda memiliki banyak bagian atau label, Anda mungkin ingin mempertimbangkan menggunakan diagram batang sebagai gantinya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.Pie`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tambahkan poin baru untuk diagram dan terapkan warna khusus pada sektornya.
9. Tetapkan label untuk seri.
10. Aktifkan garis pemimpin untuk label seri.
11. Atur sudut rotasi untuk diagram pie.
12. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram pie:

```c#
// Membuat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Menambahkan diagram dengan data defaultnya.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Mengatur judul diagram.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Mengatur seri pertama agar menampilkan nilai.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Mengatur indeks lembar data diagram.
    int worksheetIndex = 0;

    // Mendapatkan workbook data diagram.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Menghapus seri dan kategori default yang dihasilkan.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Menambahkan kategori baru.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Menambahkan seri baru.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Mengisi data seri.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Mengatur warna sektor.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Mengatur batas sektor.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Mengatur batas sektor.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Mengatur batas sektor.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Membuat label khusus untuk setiap kategori dalam seri baru.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Mengatur seri agar menampilkan garis pemimpin untuk diagram.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Mengatur sudut rotasi untuk sektor diagram pie.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Menyimpan presentasi ke disk sebagai file PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Pie](pie_chart.png)

### **Buat Diagram Garis**

Diagram garis (juga dikenal sebagai grafik garis) paling cocok digunakan dalam situasi di mana Anda ingin menunjukkan perubahan nilai dari waktu ke waktu. Dengan diagram garis, Anda dapat membandingkan sejumlah besar data sekaligus, melacak perubahan dan tren seiring waktu, menyoroti anomali dalam seri data, dan lain‑lain.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.Line`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram garis:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Secara default, titik pada diagram garis dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik dihubungkan dengan garis putus‑putus, Anda dapat menentukan jenis dash yang diinginkan sebagai berikut:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Hasilnya:

![Diagram Garis](line_chart.png)

### **Buat Diagram Peta Pohon**

Diagram peta pohon paling cocok untuk data penjualan ketika Anda ingin menampilkan ukuran relatif kategori data dan dengan cepat menarik perhatian ke item yang berkontribusi besar dalam setiap kategori.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.Treemap`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram peta pohon:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Cabang 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Cabang 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Peta Pohon](treemap_chart.png)

### **Buat Diagram Saham**

Diagram saham digunakan untuk menampilkan data keuangan seperti harga pembukaan, tertinggi, terendah, dan penutupan, membantu menganalisis tren pasar dan volatilitas. Mereka menawarkan wawasan penting tentang kinerja saham, membantu investor dan analis membuat keputusan yang tepat.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.OpenHighLowClose`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Tentukan format HiLowLines.
9. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram saham:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Saham](stock_chart.png)

### **Buat Diagram Box dan Whisker**

Diagram Box and Whisker digunakan untuk menampilkan distribusi data dengan merangkum ukuran statistik utama, seperti median, kuartil, dan potensi outlier. Mereka sangat berguna dalam analisis data eksploratori dan studi statistik untuk dengan cepat memahami variabilitas data dan mengidentifikasi anomali.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.BoxAndWhisker`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram box dan whisker:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Buat Diagram Corong**

Diagram corong digunakan untuk memvisualisasikan proses yang melibatkan tahap berurutan, di mana volume data berkurang saat bergerak dari satu langkah ke langkah berikutnya. Mereka sangat membantu dalam menganalisis tingkat konversi, mengidentifikasi bottleneck, dan melacak efisiensi proses penjualan atau pemasaran.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.Funnel`.
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram corong:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Corong](funnel_chart.png)

### **Buat Diagram Sunburst**

Diagram sunburst digunakan untuk memvisualisasikan data hierarkis, menampilkan tingkat sebagai cincin konsentris. Mereka membantu menggambarkan hubungan bagian‑dengan‑seluruh dan ideal untuk mewakili kategori bersarang dan subkategori dalam format yang jelas dan kompak.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.Sunburst`.
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram sunburst:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Cabang 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Cabang 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Sunburst](sunburst_chart.png)

### **Buat Diagram Histogram**

Diagram histogram digunakan untuk menggambarkan distribusi data numerik dengan mengelompokkan nilai ke dalam rentang atau bin. Mereka sangat berguna untuk mengidentifikasi pola data seperti frekuensi, kemencengan, dan penyebaran, serta untuk mendeteksi outlier dalam sebuah dataset.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan beberapa data dan tentukan tipe `ChartType.Histogram`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram histogram:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Histogram](histogram_chart.png)

### **Buat Diagram Radar**

Diagram radar digunakan untuk menampilkan data multivariate dalam format dua dimensi, memungkinkan perbandingan beberapa variabel secara simultan. Mereka sangat berguna untuk mengidentifikasi pola, kekuatan, dan kelemahan di seluruh metrik atau atribut kinerja.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan beberapa data dan tentukan tipe `ChartType.Radar`.
4. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram radar:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Radar](radar_chart.png)

### **Buat Diagram Multi‑Kategori**

Diagram Multi Kategori digunakan untuk menampilkan data yang melibatkan lebih dari satu pengelompokan kategori, memungkinkan Anda membandingkan nilai di berbagai dimensi secara simultan. Mereka sangat membantu ketika Anda perlu menganalisis tren dan hubungan dalam dataset yang kompleks dan berlapis.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan diagram dengan data default dan tentukan tipe `ChartType.ClusteredColumn`.
4. Akses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
5. Hapus semua seri dan kategori default.
6. Tambahkan seri dan kategori baru.
7. Tambahkan data diagram baru untuk seri diagram.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat diagram multi kategori:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Tambahkan sebuah seri.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Simpan presentasi dengan diagram.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram multi kategori](multi_category_chart.png)

### **Buat Diagram Peta**

Diagram peta digunakan untuk memvisualisasikan data geografis dengan memetakan informasi ke lokasi spesifik seperti negara, provinsi, atau kota. Mereka sangat berguna untuk menganalisis tren wilayah, data demografis, dan distribusi spasial dengan cara yang jelas dan menarik secara visual.

Kode C# ini menunjukkan cara membuat diagram peta:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Diagram Peta](map_chart.png)

### **Buat Diagram Kombinasi**

Diagram kombinasi (atau combo chart) menggabungkan dua atau lebih jenis diagram dalam satu grafik. Diagram ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan di antara mereka.

![Diagram kombinasi](combination_chart.png)

Kode C# berikut menunjukkan cara membuat diagram kombinasi yang ditampilkan di atas dalam presentasi PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Mengatur judul diagram
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Mengatur legenda diagram
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Menghapus seri dan kategori default yang dihasilkan
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Menambahkan kategori baru
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Menambahkan seri pertama
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Mengatur sumbu horizontal
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Mengatur sumbu vertikal
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Mengatur warna garis kisi utama vertikal
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Mengatur sumbu horizontal sekunder
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Mengatur sumbu vertikal sekunder
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Perbarui Diagram**

Aspose.Slides untuk .NET memungkinkan Anda memperbarui diagram PowerPoint dengan memodifikasi data diagram, pemformatan, dan gaya. Fungsionalitas ini menyederhanakan proses menjaga presentasi tetap mutakhir dengan konten dinamis dan memastikan bahwa diagram secara akurat mencerminkan data dan standar visual saat ini.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang mewakili presentasi yang berisi diagram.
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Jelajahi semua shape untuk menemukan diagram.
4. Akses lembar kerja data diagram.
5. Modifikasi seri data diagram dengan mengubah nilai seri.
6. Tambahkan seri baru dan isi datanya.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara memperbarui diagram:

```c#
const string chartName = "My chart";

// Membuat instance kelas Presentation yang mewakili file PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Mengakses slide pertama.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Mengatur indeks lembar data diagram.
            int worksheetIndex = 0;

            // Mendapatkan workbook data diagram.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Mengubah nama kategori diagram.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Mendapatkan seri diagram pertama.
            IChartSeries series = chart.ChartData.Series[0];

            // Memperbarui data seri.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Mengubah nama seri.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Mendapatkan seri diagram kedua.
            series = chart.ChartData.Series[1];

            // Memperbarui data seri.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Mengubah nama seri.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Menambahkan seri baru.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Mengisi data seri.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Menyimpan presentasi dengan diagram.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Tetapkan Rentang Data untuk Diagram**

Aspose.Slides untuk .NET menyediakan fleksibilitas untuk mendefinisikan rentang data spesifik dari lembar kerja sebagai sumber data diagram Anda. Ini berarti Anda dapat memetakan bagian lembar kerja secara langsung ke diagram, memungkinkan Anda mengontrol sel mana yang berkontribusi pada seri dan kategori diagram. Dengan demikian, Anda dapat dengan mudah memperbarui dan menyinkronkan diagram dengan perubahan data terbaru di lembar kerja, memastikan presentasi PowerPoint Anda mencerminkan informasi yang akurat dan terkini.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang mewakili presentasi yang berisi diagram.
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Jelajahi semua shape untuk menemukan diagram.
4. Akses data diagram dan tetapkan rentangnya.
5. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara menetapkan rentang data untuk diagram:

```c#
const string chartName = "My chart";

// Membuat instance kelas Presentation yang mewakili file PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Mengakses slide pertama.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Gunakan Penanda Default pada Diagram**

Ketika Anda menggunakan penanda default pada diagram, setiap seri diagram secara otomatis mendapatkan simbol penanda default yang berbeda.

Kode C# ini menunjukkan cara mengatur penanda seri diagram secara otomatis:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Mengisi data seri.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jenis diagram apa yang didukung oleh Aspose.Slides untuk .NET?**

Aspose.Slides untuk .NET mendukung berbagai jenis diagram, termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih jenis diagram yang paling sesuai untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan diagram baru ke slide?**

Untuk menambahkan diagram, pertama buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation), ambil slide yang diinginkan menggunakan indeksnya, lalu panggil metode untuk menambahkan diagram, dengan menentukan jenis diagram dan data awal. Proses ini mengintegrasikan diagram langsung ke dalam presentasi Anda.

**Bagaimana cara memperbarui data yang ditampilkan dalam diagram?**

Anda dapat memperbarui data diagram dengan mengakses workbook data diagram ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)), menghapus semua seri dan kategori default, kemudian menambahkan data khusus Anda. Hal ini memungkinkan Anda menyegarkan diagram secara programatik agar mencerminkan data terbaru.

**Apakah memungkinkan untuk menyesuaikan tampilan diagram?**

Ya, Aspose.Slides untuk .NET menyediakan opsi kustomisasi yang luas. Anda dapat mengubah warna, font, label, legenda, dan elemen pemformatan lainnya untuk menyesuaikan tampilan diagram sesuai dengan kebutuhan desain spesifik Anda.