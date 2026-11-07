---
title: Tautkan grafik ke buku kerja eksternal
description: Tautkan data grafik ke buku kerja eksternal dan segarkan.
type: docs
url: /id/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Gambaran Umum**

Arahkan grafik ke buku kerja eksternal alih-alih menyimpan semua data sumbernya tertanam dalam presentasi. Anda dapat mengatur jalur buku kerja dan memilih apakah memperbarui grafik dari file tersebut. Grafik yang disimpan juga dapat membawa data tampilan yang di-cache.

## **Contoh Penggunaan**

Contoh C# ini menggunakan Aspose.Slides untuk .NET. Buat buku kerja penjualan yang valid dengan North = 55 dan South = 40 dan simpan sebagai sales.xlsx di samping output. Atur ulang nilai North pada grafik menjadi 20, lalu tautkan grafik ke jalur absolut buku kerja dan segarkan: North kembali menjadi 55. Rentang eksplisit mencakup header dan dua baris data. Pastikan sales.xlsx tersedia saat membuka kembali atau memperbarui grafik yang ditautkan; presentasi tidak menyematkan file eksternal ini. Tidak diperlukan file masukan. Ini menyimpan *external-chart-workbook.pptx* dan *external-chart-workbook.png*. Instal perpustakaan menggunakan [panduan instalasi](/slides/id/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Apakah saya dapat membaca setiap nilai yang di-cache ketika file yang ditautkan tidak ada?**

Aspose.Slides for .NET 26.11 dapat [membaca nilai grafik yang disimpan secara langsung](/slides/id/net/chart-workbook/#read-cached-chart-values-without-a-workbook) tanpa membuka buku kerja yang ditautkan. Ini termasuk nilai biasa, nilai X/Y, ukuran gelembung, dan nilai kategori ketika cache tersebut ada. Data yang di-cache mungkin tidak ada atau kedaluwarsa; itu bukan buku kerja lengkap. Menyegarkan dari sumber masih memerlukan buku kerja yang didukung dan tersedia. Untuk SDK lain dan versi lain, periksa panduan grafik yang sesuai.

### **Apa yang terjadi jika buku kerja eksternal dipindahkan?**

Perbarui jalur buku kerja eksternal grafik ke lokasi barunya, dan pastikan file tersebut tersedia di mana pun presentasi diproses. Jangan mengandalkan data yang di-cache untuk operasi akses data penuh ketika data tersebut tidak ada.

### **Apakah saya dapat memilih apakah menyegarkan data grafik yang di-cache saat menautkan?**

Ya. Pilih apakah memperbarui data grafik saat mengatur tautan. Menyegarkan memerlukan buku kerja yang didukung dan tersedia; melewatkan penyegaran mencatat tautan tanpa membaca nilai baru dari file tersebut.

## **Panduan**

- [Kelola Buku Kerja Grafik dalam Presentasi di .NET](/slides/id/net/chart-workbook/)

Fitur terkait: [Isi grafik yang dapat diedit dengan data](/slides/id/features/chart-data-binding/).