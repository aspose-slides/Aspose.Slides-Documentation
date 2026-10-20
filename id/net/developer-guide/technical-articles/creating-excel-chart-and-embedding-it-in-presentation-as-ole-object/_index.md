---
title: Buat Diagram Excel dan Sematkan ke dalam Presentasi sebagai OLE Objects
type: docs
weight: 50
url: /id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- sematkan diagram
- objek OLE
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk .NET dan sematkan workbook ke dalam presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells untuk .NET dan menyematkan workbook‑nya ke dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Workbook yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint native. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Tambahkan referensi ke Aspose.Cells untuk .NET dan Aspose.Slides untuk .NET dalam proyek C# Anda. Contoh ini menggunakan pernyataan tingkat atas dan memerlukan C# 9 atau lebih baru. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak ada file input yang diperlukan: contoh membuat data dan diagram di memori, kemudian menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar diagram.  
1. Jadikan lembar diagram aktif sehingga workbook terbuka pada diagram.  
1. Atur rentang tampilan OLE workbook dan render diagram ke PNG.  
1. Simpan workbook sebagai XLSX di memori dan sematkan byte‑nya ke dalam slide.  
1. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) menerima indeks baris dan kolom mulai/akhir berbasis nol. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) justru menerima baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai‑nilai ini adalah pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan satuan poin. Contoh menyesuaikannya dalam slide dan menempatkannya di tengah sambil mempertahankan rasio aspek PNG, alih‑alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

Workbook secara eksplisit disimpan sebagai XLSX, sesuai ekstensi `xlsx` yang diteruskan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG dimuat langsung dari alirannya tanpa konversi bitmap perantara. Menetapkannya melalui [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) menggantikan placeholder OLE default.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Render preview diagram dan serialisasi workbook yang dapat diedit secara terpisah.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau diagram. Workbook berisi data asli dan diagram kolom dengan empat seri. Pratinjau ditempatkan di tengah slide dan mempertahankan proporsinya.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Di lingkungan PowerPoint desktop yang kompatibel dengan Excel, klik ganda objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan penyuntingan bergantung pada dukungan OLE serta pengaturan keamanan aplikasi host.

## **FAQ**

**Mengapa diperlukan gambar pratinjau?**

Workbook yang disematkan dan pratinjau slide‑nya adalah konten terpisah. Sediakan gambar diagram agar slide menampilkan diagram alih‑alih placeholder default “EMBEDDED OLE OBJECT”. Lihat [Object Preview Issue when Adding OleObjectFrame](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau diperbarui secara otomatis saat saya mengubah workbook dalam kode?**

Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatis, hasilkan kembali gambar diagram dan ganti pratinjau serta data workbook yang disematkan.

**Bisakah saya menggunakan XLS alih‑alih XLSX?**

Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus cocok dengan format workbook sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**

Aplikasi host dapat memperbarui tampilan objek OLE ketika workbook diaktifkan. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya memengaruhi hasil. Lihat [Working Solution for Chart Resizing in PPTX](/slides/id/net/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Working Solution for Chart Resizing in PPTX](/slides/id/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)