---
title: Optimalkan Perhitungan Diagram untuk Presentasi di .NET
linktitle: Perhitungan Diagram
type: docs
weight: 50
url: /id/net/chart-calculations/
keywords:
- perhitungan diagram
- elemen diagram
- posisi elemen
- posisi sebenarnya
- elemen anak
- elemen induk
- nilai diagram
- nilai sebenarnya
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Memahami perhitungan diagram, pembaruan data, dan kontrol presisi dalam Aspose.Slides untuk .NET untuk PPT dan PPTX, dengan contoh kode C# yang praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan diagram dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai sebenarnya dari elemen diagram, termasuk posisi dan ukuran nyata dari elemen yang mengimplementasikan `IActualLayout` serta nilai sebenarnya dari sumbu diagram. Artikel ini juga menjelaskan bahwa nilai-nilai tersebut diisi setelah validasi tata letak diagram.

Selain itu, artikel ini mendemonstrasikan cara memperoleh posisi sebenarnya dari elemen diagram induk dan cara menyembunyikan komponen diagram seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak diagram dan mengontrol visibilitas elemen diagram dalam presentasi PowerPoint secara programatis.

## **Hitung Nilai Sebenarnya dari Elemen Diagram**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mendapatkan properti ini. Ini akan membantu Anda menghitung nilai sebenarnya dari elemen diagram. Nilai sebenarnya mencakup posisi elemen yang mengimplementasikan antarmuka IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) serta nilai sumbu sebenarnya (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Menyimpan presentasi
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **Hitung Posisi Sebenarnya dari Elemen Diagram Induk**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mendapatkan properti ini. Properti IActualLayout memberikan informasi tentang posisi sebenarnya dari elemen diagram induk. Perlu memanggil metode IChart.ValidateChartLayout() terlebih dahulu untuk mengisi properti dengan nilai sebenarnya.

```c#
// Membuat presentasi kosong
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```


## **Sembunyikan Elemen Diagram**
Topik ini membantu Anda memahami cara menyembunyikan informasi dari diagram. Menggunakan Aspose.Slides untuk .NET Anda dapat menyembunyikan **Judul, Sumbu Vertikal, Sumbu Horizontal** dan **Garis Kisi** dari diagram. Contoh kode di bawah menunjukkan cara menggunakan properti ini.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Menyembunyikan Judul Diagram
    chart.HasTitle = false;

    ///Menyembunyikan sumbu Nilai
    chart.Axes.VerticalAxis.IsVisible = false;

    //Visibilitas sumbu Kategori
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Menyembunyikan Legenda
    chart.HasLegend = false;

    //Menyembunyikan Garis Kisi Utama
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Menetapkan warna garis seri
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah buku kerja Excel eksternal dapat berfungsi sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Diagram dapat merujuk ke buku kerja eksternal: ketika Anda menyambungkan atau menyegarkan sumber eksternal, formula dan nilai diambil dari buku kerja tersebut, dan diagram mencerminkan pembaruan selama operasi buka/sunting. API memungkinkan Anda [menentukan buku kerja eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/setexternalworkbook/) path dan mengelola data yang ditautkan.

**Bisakah saya menghitung dan menampilkan garis tren tanpa mengimplementasikan regresi sendiri?**

Ya. [Garis Tren](/slides/id/net/trend-line/) (linier, eksponensial, dan lainnya) ditambahkan dan diperbarui oleh Aspose.Slides; parameter mereka dihitung ulang dari data seri secara otomatis, sehingga Anda tidak perlu mengimplementasikan perhitungan sendiri.

**Jika sebuah presentasi memiliki banyak diagram dengan tautan eksternal, dapatkah Anda mengontrol buku kerja mana yang digunakan masing-masing diagram untuk nilai yang dihitung?**

Ya. Setiap diagram dapat menunjuk ke [buku kerja eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/setexternalworkbook/) miliknya sendiri, atau Anda dapat membuat/mengganti buku kerja eksternal per diagram secara independen dari yang lain.