---
title: Solusi Bekerja untuk Perubahan Ukuran Lembar Kerja
type: docs
weight: 40
url: /id/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—menskalakan bingkai atau lembar kerja—pada format PPT dan PPTX."
---
{{% alert color="primary" %}} 

Telah diamati bahwa lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose diubah ukurannya ke skala yang tidak teridentifikasi setelah aktivasi pertama. Perilaku ini menghasilkan perbedaan visual yang terlihat pada presentasi antara keadaan sebelum dan sesudah aktivasi objek OLE. Kami telah menyelidiki masalah ini secara detail dan menyediakan solusi, yang dibahas dalam artikel ini.

{{% /alert %}} 

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/net/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides for .NET. Untuk mengatasi [masalah pratinjau objek](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Pada presentasi keluaran, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan. 

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsinya tetap benar sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala ukuran bingkai OLE dalam presentasi PowerPoint agar cocok dengan tinggi dan lebar jumlah baris dan kolom yang diinginkan dalam bingkai OLE.
- Pertahankan ukuran bingkai OLE tetap dan skala ukuran baris serta kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE yang dipilih.

### **Skalakan Ukuran Bingkai OLE**

Dalam pendekatan ini, kita akan mempelajari cara mengatur ukuran bingkai OLE dari buku kerja Excel yang disematkan agar cocok dengan ukuran kumulatif baris dan kolom yang berpartisipasi dalam lembar kerja Excel.

Misalkan kami memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Pada skenario ini, ukuran bingkai objek OLE pertama-tama akan dihitung berdasarkan tinggi baris kumulatif dan lebar kolom kumulatif dari baris serta kolom yang berpartisipasi dalam buku kerja. Kemudian, kami akan mengatur ukuran bingkai OLE ke nilai yang telah dihitung tersebut. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kami juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam buku kerja dan menetapkannya sebagai gambar bingkai OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Atur ukuran yang ditampilkan ketika file workbook digunakan sebagai objek OLE di PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Dapatkan lebar dan tinggi gambar OLE dalam poin.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Kita perlu menggunakan workbook yang telah dimodifikasi.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Tambahkan gambar OLE ke sumber daya presentasi.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Buat bingkai objek OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Skalakan Ukuran Rentang Sel**

Dalam pendekatan ini, kita akan mempelajari cara menskalakan tinggi baris yang berpartisipasi dan lebar kolom yang berpartisipasi agar cocok dengan ukuran bingkai OLE khusus.

Misalkan kami memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Pada skenario ini, kami akan mengatur ukuran bingkai OLE dan menskalakan ukuran baris serta kolom yang berpartisipasi dalam area bingkai OLE. Kami kemudian akan menyimpan buku kerja ke aliran untuk menerapkan perubahan dan mengonversinya menjadi array byte untuk menambahkannya ke bingkai OLE. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kami juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam buku kerja dan menetapkannya sebagai gambar bingkai OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Atur ukuran yang ditampilkan ketika file workbook digunakan sebagai objek OLE di PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala rentang sel agar sesuai dengan ukuran bingkai.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Kita perlu menggunakan workbook yang telah dimodifikasi.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Tambahkan gambar OLE ke sumber daya presentasi.
var oleImage = presentation.Images.AddImage(imageStream);

// Buat bingkai objek OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Lebar yang diharapkan dari rentang sel dalam poin.</param>
/// <param name="height">Tinggi yang diharapkan dari rentang sel dalam poin.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Kesimpulan**

{{% alert color="primary" %}}

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pemilihan pendekatan yang tepat bergantung pada kebutuhan spesifik dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**  
Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**  
Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**  
Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini bekerja jika presentasi saya berbasis templat?**  
Ya. Kedua solusi bekerja untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**  
Tidak. Anda dapat membuat bingkai objek OLE berukuran apa pun selama Anda mengatur skala secara tepat.

**Apakah ada cara menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**  
Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)