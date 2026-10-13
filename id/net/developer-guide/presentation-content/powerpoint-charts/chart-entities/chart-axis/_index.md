---
title: Sesuaikan Sumbu Diagram dalam Presentasi di .NET
linktitle: Sumbu Diagram
type: docs
url: /id/net/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: Temukan cara menggunakan Aspose.Slides untuk .NET untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi.
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram dengan Aspose.Slides for .NET. Artikel ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom diagram, visibilitas sumbu, interval label kategori dan tanda centang, kategori tanggal dan pemformatannya, rotasi judul, posisi sumbu, satuan tampilan, dan skala logaritmik.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**

Buat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan tambahkan diagram area dengan data default. Panggil [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) sebelum membaca nilai sumbu yang dihitung sehingga tata letak diagram mutakhir.

Baca [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) dan [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) untuk batas sumbu, serta [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) dan [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) untuk interval tanda centang. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) dan [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh ini menyimpan nilai‑nilai tersebut dalam variabel lokal dan menyimpan diagramnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Tukar Data antara Sumbu**

Gunakan [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori sebelumnya menjadi seri, dan setiap seri sebelumnya menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh menggunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) untuk mengikat data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Contoh menyimpan diagram dengan empat seri dan tiga kategori.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Setel [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) ke `false` pada sumbu vertikal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu vertikal tersembunyi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Setel [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) ke `false` pada sumbu horizontal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu horizontal tersembunyi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Ubah Sumbu Kategori**

Setel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan diagram sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Contoh mengubah sumbu horizontal menjadi sumbu tanggal. Menetapkan [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) ke `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) ke `1`, dan [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) ke bulan menempatkan tanda mayor pada interval satu bulan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Kontrol Interval Label Sumbu Kategori**

Ketika diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Setel [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) ke `false`, kemudian setel [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) ke interval kategori yang diinginkan. Untuk kategori teks dalam urutan normal, penghitung dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` menampilkan setiap label ketiga, meninggalkan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersesuaian. Spasi otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda centang memiliki kontrol terpisah. Setel [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) ke `false` dan gunakan [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) untuk mengatur intervalnya. Misalnya, `1` menjaga tanda centang pada setiap interval kategori sementara label muncul hanya setiap kategori ketiga. Setel [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ke gaya yang terlihat agar Anda dapat melihat hasilnya. Mengatur kembali properti spasi otomatis ke `true` membiarkan diagram memilih interval tersebut lagi.

Contoh mandiri berikut membuat 24 kategori dan satu seri, kemudian menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: spasi otomatis, spasi label manual dengan tanda centang independen, dan spasi otomatis yang dipulihkan. Kedua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi input. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slide 2: tampilkan setiap label ketiga, tetapi tetap pertahankan tanda centang untuk setiap kategori.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: biarkan diagram memilih kedua interval lagi.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Spasi otomatis (slide 1):** Pada render ini, setiap label kategori kedua ditampilkan dan terbungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung pada ukuran diagram, font, dan perender.

![Spasi otomatis label kategori dengan semua 24 kolom terlihat](category-axis-automatic.png)

**Spasi manual (slide 2):** Setiap label ketiga ditampilkan pada satu baris, sementara tanda centang tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 memulihkan tampilan otomatis yang ditunjukkan di atas.

![Interval label kategori manual tiga dengan semua 24 kolom terlihat](category-axis-manual.png)

### **Pilih Sumbu dan Interval yang Tepat**

Gunakan interval hitungan kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, sumbu ini adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori bersifat vertikal, sehingga terapkan pengaturan ini ke [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Spasi tanda centang juga berlaku untuk sumbu seri pada diagram yang memilikinya.

Jangan gunakan spasi label kategori untuk mengatur skala numerik pada sumbu nilai. Pada sumbu nilai, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) menentukan selisih nilai: misalnya, satuan mayor `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu mulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai datanya. Diagram sebar dan gelembung menggunakan sumbu nilai bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan satuan mayor berbasis waktu dan skala seperti yang dijelaskan pada [Ubah Sumbu Kategori](#ubah-sumbu-kategori).

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**

Contoh ini mengganti data diagram default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`). Setel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) ke sumbu tanggal, nonaktifkan [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), dan tetapkan `yyyy` ke [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) sehingga label kategori menampilkan tahun empat digit secara terpisah dari pemformatan sel.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**

Aktifkan [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) pada sumbu vertikal, beri teks judul, dan setel [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai diputar 90 derajat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**

Gunakan [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) untuk mengontrol apakah sumbu nilai melewati sumbu kategori di antara kategori atau pada tanda centang kategori. Properti ini berlaku untuk sumbu kategori. Contoh mengaturnya ke `true` pada sumbu kategori horizontal diagram kolom dan menyimpan hasilnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Atur Satuan Tampilan pada Sumbu Nilai Diagram**

Setel [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) untuk mengskalakan label pada sumbu nilai tanpa mengubah data yang mendasarinya. Dengan [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) diatur ke `Millions`, nilai 60.000.000 ditampilkan sebagai 60. Contoh ini membuat diagram kolom dan menerapkan satuan tampilan jutaan pada sumbu vertikalnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Konfigurasi Sumbu Nilai Logaritmik**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linear, nilai kecil muncul berdekatan di dekat nol. Skala logaritmik membuat pertumbuhan relatif mereka lebih mudah dibandingkan: jarak yang sama mewakili rasio yang sama, bukan selisih yang sama.

Setel [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) ke `true` pada sumbu nilai dan gunakan [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) untuk memilih basisnya. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambahkan garis tren logaritmik. Garis tren adalah fitur terpisah yang mewakili hubungan yang dipasang pada data.

### **Pilih Sumbu Nilai dan Basisnya**

Untuk diagram garis atau kolom, sumbu nilai adalah [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Untuk diagram batang horizontal, sumbu nilai adalah [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Diagram sebar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan penskalaan logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk diagram PPTX, gunakan basis antara `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 berjarak sama.

### **Bandingkan Skala Linear dan Logaritmik**

Contoh mandiri berikut membuat diagram garis dengan lima hitungan permintaan pada slide pertama, kemudian menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis-10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Pertahankan slide pertama linear dan ubah hanya skala sumbu nilai salinan.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili selisih yang sama dalam hitungan permintaan. Nilai terbesar mendominasi diagram, membuat nilai yang lebih kecil sulit dibedakan.

![Diagram garis di PowerPoint menampilkan lima hitungan permintaan pada sumbu nilai linear](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lebih banyak permintaan daripada periode sebelumnya, sehingga titik‑titik membentuk garis naik lurus pada skala basis-10. Label sumbu tetap menunjukkan hitungan permintaan asli.

![Lima hitungan permintaan yang sama di PowerPoint pada sumbu nilai logaritmik basis-10](value-axis-logarithmic.png)

### **Tangani Nilai Nol dan Negatif**

Skala logaritmik hanya dapat menampilkan nilai yang benar‑benar positif. Periksa data sebelum mengaktifkannya. Jika nilai nol atau negatif memiliki makna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengeluarkan nilai‑nilai tersebut sesuai untuk analisis, jelaskan penghapusannya. Jangan diam‑diam menggantinya dengan angka positif kecil, karena hal itu mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lain (crossing sumbu)?**

Gunakan [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) untuk memilih perilaku pemotongan. Untuk menentukan nilai pemotongan numerik, setel [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Pengaturan ini memungkinkan Anda memindahkan titik pertemuan sumbu ke garis dasar yang sesuai.

**Bagaimana saya dapat memposisikan label tanda centang relatif terhadap sumbu?**

Setel [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) menggunakan [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, atau `None`. Untuk mengontrol tanda centang itu sendiri, gunakan [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) atau [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); keduanya terpisah dari posisi label.