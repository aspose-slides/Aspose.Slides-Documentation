---
title: Kustomisasi Area Plot Chart dalam Presentasi .NET
linktitle: Area Plot
type: docs
url: /id/net/chart-plot-area/
keywords:
- diagram
- area plot
- lebar area plot
- tinggi area plot
- ukuran area plot
- mode tata letak
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menyesuaikan area plot chart dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Tingkatkan visual slide Anda dengan mudah."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara bekerja dengan area plot chart di Aspose.Slides. Artikel ini menjelaskan cara mendapatkan posisi dan ukuran sebenarnya dari area plot dengan memvalidasi tata letak chart dan kemudian membaca nilai X, Y, lebar, dan tinggi.

Ini juga menunjukkan cara mengkonfigurasi mode tata letak area plot ketika tata letak diatur secara manual, menggunakan `LayoutTargetType` untuk menentukan apakah area plot dihitung berdasarkan wilayah dalamnya atau wilayah luarnya bersama dengan sumbu dan label sumbu.

## **Dapatkan Lebar dan Tinggi Area Plot Chart**
Aspose.Slides untuk .NET menyediakan API sederhana untuk .

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Akses slide pertama.
3. Tambahkan chart dengan data default.
4. Panggil metode IChart.ValidateChartLayout() sebelumnya untuk mendapatkan nilai sebenarnya.
5. Mendapatkan lokasi X aktual (kiri) dari elemen chart relatif terhadap sudut kiri atas chart.
6. Mendapatkan posisi atas aktual dari elemen chart relatif terhadap sudut kiri atas chart.
7. Mendapatkan lebar aktual dari elemen chart.
8. Mendapatkan tinggi aktual dari elemen chart.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Simpan presentasi dengan chart
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **Setel Mode Tata Letak Area Plot Chart**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mengatur mode tata letak area plot chart. Properti **LayoutTargetType** telah ditambahkan ke kelas **ChartPlotArea** dan **IChartPlotArea**. Jika tata letak area plot didefinisikan secara manual, properti ini menentukan apakah menata area plot berdasarkan bagian dalamnya (tidak termasuk sumbu dan label sumbu) atau bagian luarnya (termasuk sumbu dan label sumbu). Ada dua nilai yang mungkin yang didefinisikan dalam enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tidak termasuk tanda penskal dan label sumbu.
- **LayoutTargetType.Outer** - menentukan bahwa ukuran area plot akan menentukan ukuran area plot, tanda penskal, dan label sumbu.

Kode contoh diberikan di bawah.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Dalam satuan apa ActualX, ActualY, ActualWidth, dan ActualHeight dikembalikan?**

Dalam poin; 1 inci = 72 poin. Ini adalah satuan koordinat Aspose.Slides.

**Bagaimana perbedaan antara Plot Area dan Chart Area dalam hal konten?**

Plot Area adalah wilayah menggambar data (seri, garis kisi, garis tren, dll.); Chart Area mencakup elemen di sekitarnya (judul, legenda, dll.). Pada chart 3D, Plot Area juga mencakup dinding/lantai dan sumbu.

**Bagaimana X, Y, Lebar, dan Tinggi Plot Area ditafsirkan ketika tata letak diatur secara manual?**

Mereka berupa pecahan (0–1) dari ukuran keseluruhan chart; dalam mode ini, penempatan otomatis dinonaktifkan dan pecahan yang Anda atur digunakan.

**Mengapa posisi Plot Area berubah setelah menambahkan/memindahkan legenda?**

Legenda berada di area chart di luar Plot Area tetapi memengaruhi tata letak dan ruang yang tersedia, sehingga Plot Area dapat bergeser ketika penempatan otomatis aktif. (Ini adalah perilaku standar untuk chart PowerPoint.)