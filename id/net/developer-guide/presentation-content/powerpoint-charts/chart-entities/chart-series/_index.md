---
title: Kelola Seri Data Diagram dalam Presentasi di .NET
linktitle: Seri Data
type: docs
url: /id/net/chart-series/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram di C# untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartseries/) dalam Aspose.Slides untuk .NET, dengan fokus pada cara data disusun dan divisualisasikan dalam presentasi. Objekt‑objek ini menyediakan elemen dasar yang mendefinisikan kumpulan titik data, kategori, dan parameter penampilan individual dalam sebuah diagram. Dengan bekerja dengan [ChartSeries](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartseries/), pengembang dapat dengan mudah mengintegrasikan sumber data yang mendasari dan mempertahankan kontrol penuh atas cara informasi ditampilkan, menghasilkan presentasi dinamis berbasis data yang secara jelas menyampaikan wawasan dan analisis.

Seri adalah baris atau kolom angka yang dipetakan dalam diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

Properti [IChartSeriesOverlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/properties/overlap) mengontrol cara batang dan kolom saling tumpang tindih dalam diagram 2D dengan menentukan rentang dari -100 hingga 100. Karena properti ini terkait dengan grup seri bukan seri diagram individual, properti ini hanya dapat dibaca pada tingkat seri. Untuk mengonfigurasi nilai overlap, gunakan properti `ParentSeriesGroup.Overlap` yang dapat dibaca‑tulis, yang menerapkan overlap yang ditentukan ke semua seri dalam grup tersebut.

Berikut contoh C# yang menunjukkan cara membuat presentasi, menambahkan diagram kolom berkelompok, mengakses seri diagram pertama, mengatur nilai overlap, dan kemudian menyimpan hasilnya sebagai file PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram kolom berkelompok dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Atur tumpang tindih seri.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Simpan file presentasi ke disk.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Overlap seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Aspose.Slides memudahkan penyesuaian warna isian seri diagram, memungkinkan Anda menyoroti titik data tertentu dan membuat diagram yang menarik secara visual. Hal ini dicapai melalui objek [IFormat](https://reference.aspose.com/slides/id/net/aspose.slides.charts/iformat/), yang mendukung berbagai tipe isian, konfigurasi warna, dan opsi styling lanjutan lainnya. Setelah menambahkan diagram ke slide dan mengakses seri yang diinginkan, cukup dapatkan seri dan terapkan warna isian yang sesuai. Selain isian padat, Anda juga dapat memanfaatkan isian gradasi atau pola untuk fleksibilitas desain yang lebih baik. Setelah Anda mengatur warna sesuai kebutuhan, simpan presentasi untuk menyelesaikan tampilan yang diperbarui.

Contoh kode C# berikut menunjukkan cara mengubah warna seri pertama:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram kolom berkelompok dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Atur warna seri pertama.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Simpan file presentasi ke disk.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Aspose.Slides menawarkan cara sederhana untuk memodifikasi nama seri diagram, memudahkan pelabelan data secara jelas dan bermakna. Dengan mengakses sel worksheet yang relevan dalam data diagram, pengembang dapat menyesuaikan cara data tersebut disajikan. Modifikasi ini sangat berguna ketika nama seri perlu diperbarui atau diperjelas berdasarkan konteks data. Setelah mengganti nama seri, presentasi dapat disimpan untuk menyimpan perubahan.

Berikut cuplikan kode C# yang mendemonstrasikan proses ini dalam aksi.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram kolom berkelompok dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Atur nama seri pertama.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Simpan file presentasi ke disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Kode C# berikut menampilkan cara alternatif untuk mengubah nama seri:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram kolom berkelompok dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Atur nama seri pertama.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Simpan file presentasi ke disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Nama seri](series_name.png)

## **Dapatkan Warna Isian Seri Otomatis**

Aspose.Slides untuk .NET memungkinkan Anda mendapatkan warna isian otomatis untuk seri diagram dalam area plot. Setelah membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), Anda dapat memperoleh referensi ke slide yang diinginkan berdasarkan indeks, lalu menambahkan diagram dengan tipe pilihan Anda (seperti `ChartType.ClusteredColumn`). Dengan mengakses seri dalam diagram, Anda dapat memperoleh warna isian otomatis.

Kode C# di bawah ini mendemonstrasikan proses ini secara detail.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram kolom berkelompok dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Dapatkan warna isian seri.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Keluaran:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Atur Warna Isian Terbalik untuk Seri Diagram**

Ketika seri data Anda berisi nilai positif dan negatif, memberi warna yang sama pada setiap kolom atau batang dapat membuat diagram sulit dibaca. Aspose.Slides untuk .NET memungkinkan Anda menetapkan warna isian terbalik — sebuah isian terpisah yang diterapkan secara otomatis pada titik data yang berada di bawah nol — sehingga nilai negatif menonjol secara sekilas. Pada bagian ini Anda akan belajar cara mengaktifkan opsi tersebut, memilih warna yang tepat, dan menyimpan presentasi yang diperbarui.

Contoh kode berikut mendemonstrasikan operasi tersebut:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Tambahkan kategori baru.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Tambahkan seri baru.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Isi data seri.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Atur pengaturan warna untuk seri.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Warna isian padat terbalik](inverted_solid_fill_color.png)

Anda dapat membalikkan warna isian untuk satu titik data saja, bukan seluruh seri. Cukup akses `IChartDataPoint` yang diinginkan dan set properti `InvertIfNegative`‑‑nya ke true.

Contoh kode berikut menunjukkan cara melakukannya:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Balikkan warna jika titik data pada indeks 2 bernilai negatif.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Bersihkan Nilai Titik Data Spesifik**

Kadang‑kadang diagram berisi nilai tes, outlier, atau entri usang yang perlu dihapus tanpa harus membuat ulang seluruh seri. Aspose.Slides untuk .NET memungkinkan Anda menargetkan titik data mana pun berdasarkan indeks, membersihkan isinya, dan secara otomatis memperbarui plot sehingga titik yang tersisa bergeser dan sumbu menyesuaikan skala secara otomatis.

Contoh kode berikut mendemonstrasikan operasi tersebut:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Atur Lebar Celah Seri**

Lebar celah mengontrol jumlah ruang kosong antara kolom atau batang yang bersebelahan — celah yang lebih lebar menekankan kategori individual, sementara celah yang lebih sempit menciptakan tampilan yang lebih padat dan kompak. Melalui Aspose.Slides for .NET Anda dapat menyesuaikan parameter ini untuk seluruh seri, mencapai keseimbangan visual yang tepat tanpa mengubah data yang mendasarinya.

Contoh kode berikut menunjukkan cara mengatur lebar celah untuk sebuah seri:

```cs
ushort gapWidth = 30;

// Buat presentasi kosong.
using (Presentation presentation = new Presentation())
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram dengan data default.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Simpan presentasi ke disk.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Atur nilai GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Simpan presentasi ke disk.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Lebar celah](gap_width.png)

## **FAQ**

**Apakah ada batasan berapa banyak seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak menetapkan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan oleh memori yang tersedia untuk aplikasi Anda.

**Bagaimana jika kolom dalam satu klaster terlalu berdekatan atau terlalu jauh?**

Sesuaikan pengaturan `GapWidth` untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai akan memperlebar ruang antar kolom, sementara menurunkannya akan membuat kolom lebih rapat.