---
title: Sesuaikan Error Bar dalam Diagram Presentasi di .NET
linktitle: Error Bar
type: docs
url: /id/net/error-bar/
keywords:
- error bar
- nilai kustom
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan error bar dalam diagram dengan Aspose.Slides untuk .NET—optimalkan visual data dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan error bar dalam diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan error bar ke seri diagram, mengkonfigurasi pengaturan error bar X dan Y, serta menerapkan berbagai tipe nilai seperti tetap, persentase, dan nilai kustom.

Artikel ini juga mendemonstrasikan cara menetapkan nilai error bar kustom untuk titik data individual dalam sebuah seri dengan menggunakan koleksi titik data yang sesuai. Selain itu, artikel ini menyertakan catatan singkat tentang perilaku error bar saat diekspor, kompatibilitasnya dengan marker dan label data, serta di mana menemukan kelas referensi API dan enum yang terkait.

## **Menambahkan Error Bar**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mengelola nilai error bar. Contoh kode berlaku ketika menggunakan tipe nilai kustom. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data spesifik dalam koleksi **DataPoints** pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format error bar X.
1. Akses seri diagram pertama dan atur format error bar Y.
1. Mengatur nilai bar dan formatnya.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```c#
 // Membuat presentasi kosong
 using (Presentation presentation = new Presentation())
 {
     // Membuat diagram gelembung
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // Menambahkan error bar dan mengatur formatnya
     IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
     IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Fixed;
     errBarX.Value = 0.1f;
     errBarY.ValueType = ErrorBarValueType.Percentage;
     errBarY.Value = 5;
     errBarX.Type = ErrorBarType.Plus;
     errBarY.Format.Line.Width = 2;
     errBarX.HasEndCap = true;

     // Menyimpan presentasi
     presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
 }
```



## **Menambahkan Nilai Error Bar Kustom**
Aspose.Slides untuk .NET menyediakan API sederhana untuk mengelola nilai error bar kustom. Contoh kode berlaku ketika properti **IErrorBarsFormat.ValueType** sama dengan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data spesifik dalam koleksi **DataPoints** pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format error bar X.
1. Akses seri diagram pertama dan atur format error bar Y.
1. Akses titik data individual pada seri diagram dan atur nilai Error Bar untuk masing‑masing titik data seri.
1. Mengatur nilai bar dan formatnya.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```c#
 // Membuat presentasi kosong
 using (Presentation presentation = new Presentation())
 {
     // Membuat diagram gelembung
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // Menambahkan Error bar kustom dan mengatur formatnya
     IChartSeries series = chart.ChartData.Series[0];
     IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
     IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Custom;
     errBarY.ValueType = ErrorBarValueType.Custom;

     // Mengakses titik data seri diagram dan mengatur nilai error bar untuk titik individual
     IChartDataPointCollection points = series.DataPoints;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

     // Mengatur error bar untuk titik seri diagram
     for (int i = 0; i < points.Count; i++)
     {
         points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
     }

     // Menyimpan presentasi
     presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
 }
```

## **FAQ**

**Apa yang terjadi dengan error bar saat mengekspor presentasi ke PDF atau gambar?**

Error bar dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan semua pemformatan diagram lainnya, dengan asumsi versi atau renderer yang kompatibel.

**Apakah error bar dapat digabungkan dengan marker dan label data?**

Ya. Error bar merupakan elemen terpisah dan kompatibel dengan marker serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan pemformatannya.

**Di mana saya dapat menemukan daftar properti dan enum untuk bekerja dengan error bar dalam API?**

Dalam referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/net/aspose.slides.charts/errorbarsformat/) dan enum terkait [ErrorBarType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/errorbarvaluetype/).