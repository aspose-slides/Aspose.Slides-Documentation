---
title: Solusi Praktis untuk Mengubah Ukuran Diagram di PPTX
type: docs
weight: 60
url: /id/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- perubahan ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga di PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk .NET. Tetapkan dimensi diagram tetap untuk menjaga konsistensi ukuran diagram dan bingkai OLE."
---
## **Latar Belakang**

Diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang terlihat pada tampilan diagram sebelum dan sesudah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan bingkai OLE.

Di [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk .NET dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Untuk mengatasi [object preview issue](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke bingkai objek OLE diagram. Dalam presentasi hasil, ketika Anda mengklik ganda bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat menyunting workbook Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar workbook yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli bingkai objek OLE dan workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Workbook Excel yang disematkan memiliki dimensi jendela sendiri, yang akan dipertahankan oleh Excel ketika objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang ditentukan secara independen. Ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela workbook dan bingkai OLE dapat menyebabkan objek berubah ukuran.

## **Solusi yang Berfungsi**

Cocokkan ukuran diagram dengan bingkai OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela workbook. Solusi ini berfungsi dengan presentasi baru atau template yang sudah ada.

Contoh ini memerlukan Aspose.Cells untuk .NET dan Aspose.Slides untuk .NET. Ia membuat diagram kolom sederhana pada lembar diagram aktif dan menyematkan workbook dalam format XLS. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9,5 × 4 inci yang ditempatkan 0,5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide dalam poin (72 poin per inci). Untuk presentasi yang sudah ada, lihat [Gunakan Template](#use-a-template).

## **Tetapkan Ukuran Grafik Tetap**

Atur [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) ke false sehingga dimensi diagram terpisah dari jendela workbook. Atur dimensi [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) melalui [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) dan [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), mengonversi poin ke piksel dengan menggunakan 96 piksel per inci: sebuah bingkai berukuran 684 × 288 poin bersesuaian dengan diagram berukuran 912 × 384 piksel. Atur [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) ke nilai Custom dari [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Contoh ini menyematkan workbook dengan [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) dan menyimpan presentasi dengan bingkai OLE berukuran 9,5 × 4 inci.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Koordinat slide dan dimensi berada dalam poin (72 poin per inci).
var width = 684f; // 9,5 inci.
var height = 288f; // 4 inci.

chart.SizeWithWindow = false;
// Konversi poin ke piksel diagram menggunakan 96 piksel per inci.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Gunakan Template**

Logika penentuan ukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi template alih-alih membuat presentasi kosong.
1. Periksa bahwa slide pertama berisi setidaknya tiga shape, kemudian gunakan shape pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi bingkai dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Pertahankan perhitungan ukuran tidak berubah.
1. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Ini terjadi karena Excel mencoba mengembalikan ukuran jendela asli ketika pertama kali diaktifkan, sedangkan bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana saya dapat menjaga konsistensi ukuran diagram dan bingkai OLE?**

Tetapkan dimensi diagram tetap yang sesuai dengan bingkai OLE dan gunakan ukuran cetak diagram khusus sebelum menyematkan workbook. Contoh di atas menunjukkan pengaturan yang diperlukan serta konversi satuan.

**Apakah mencocokkan ukuran jendela workbook sudah cukup?**

Mencocokkan ukuran jendela workbook saja tidak secara andal mencegah bingkai OLE berubah ukuran setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan dalam contoh.

**Apakah solusi ini bekerja pada presentasi berbasis template dan presentasi baru?**

Ya. Untuk template, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Bisakah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan workbook Excel yang dibuat dengan Aspose.Cells. Ia tidak menunjukkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan Sebagai Objek OLE dalam Presentasi](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Perbarui Objek OLE Secara Otomatis Menggunakan Add-In PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)