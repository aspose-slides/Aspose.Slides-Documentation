---
title: Sesuaikan Legenda Diagram dalam Presentasi di .NET
linktitle: Legenda Diagram
type: docs
url: /id/net/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk .NET guna mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara menempatkan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individual.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non‑overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda panjang melilit atau menggunakan jeda baris, dan membiarkan pemformatan legenda mewarisi skema warna tema presentasi bila pengaturan teks dan isian eksplisit tidak diterapkan.

## **Penempatan Legenda**
Untuk mengatur properti legenda, ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Dapatkan referensi slide.
- Tambahkan chart pada slide.
- Atur properti legend.
- Simpan presentasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah mengatur posisi dan ukuran untuk legenda Chart.

```c#
// Buat sebuah instance dari kelas Presentation
Presentation presentation = new Presentation();

// Dapatkan referensi slide
ISlide slide = presentation.Slides[0];

// Tambahkan diagram kolom berkelompok pada slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Atur Properti Legenda
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Simpan presentasi ke disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Atur Ukuran Font Legenda**
Aspose.Slides untuk .NET memungkinkan pengembang mengatur ukuran font legenda. Ikuti langkah‑langkah berikut:

- Instantiate `Presentation` class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Atur Ukuran Font Legenda Individual**
Aspose.Slides untuk .NET memungkinkan pengembang mengatur ukuran font entri legenda individual. Ikuti langkah‑langkah berikut:

- Instantiate `Presentation` class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([Overlay](https://reference.aspose.com/slides/id/net/aspose.slides.charts/legend/overlay/) = `false`); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.