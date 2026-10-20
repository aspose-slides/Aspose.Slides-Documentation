---
title: Solusi Bekerja untuk Perubahan Ukuran Lembar Kerja
type: docs
weight: 40
url: /id/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- penyesuaian ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—di format PPT dan PPTX."
---
{{% alert color="info" title="Catatan" %}}

Lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat mengubah ukuran secara tak terduga setelah aktivasi pertama. Perilaku ini menghasilkan perbedaan visual yang terlihat antara objek OLE sebelum dan setelah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk mengatasinya.

{{% /alert %}} 

## **Latar Belakang**

Dalam artikel [Manage OLE](/slides/id/net/manage-ole/), kami menjelaskan cara menambahkan frame OLE ke presentasi PowerPoint menggunakan Aspose.Slides for .NET. Untuk mengatasi [object preview issue](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke frame objek OLE. Pada presentasi output, ketika Anda mengklik ganda frame objek OLE yang menampilkan gambar lembar kerja, workbook Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada workbook Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar workbook Excel yang diaktifkan. Ukuran frame objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran frame objek OLE dan workbook Excel yang disematkan. 

## **Penyebab Perubahan Ukuran**

Karena workbook Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, frame objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi frame objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala frame OLE dalam presentasi PowerPoint agar cocok dengan total tinggi dan lebar baris serta kolom yang dipilih.  
- Pertahankan ukuran frame OLE tetap dan skala baris serta kolom yang dipilih agar muat di dalamnya.  

### **Skala Ukuran Frame OLE**

Pendekatan ini mengatur ukuran frame OLE agar cocok dengan total tinggi dan lebar baris serta kolom yang dipilih dalam lembar kerja Excel yang disematkan.

Contoh ini memuat workbook Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) mendefinisikan rentang yang ditampilkan. Pratinjau dirender pada 96 DPI, dan dimensi pikselnya dikonversi ke poin menggunakan 72 poin per inci. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) menyematkan workbook yang telah dimodifikasi ke dalam sebuah frame dengan dimensi tersebut. Pratinjau ditetapkan melalui [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
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

// Buat frame objek OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pembantu pratinjau mengatur [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) diaktifkan, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) merender rentang tersebut menjadi gambar PNG. Pembantu tersebut mengatur ulang aliran gambar sebelum mengembalikannya untuk digunakan dalam presentasi.

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

### **Skala Ukuran Rentang Sel**

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar sesuai dengan ukuran frame OLE khusus.

Contoh ini memuat workbook Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) mendefinisikan rentang yang ditampilkan, dan pembantu di bawah ini menskalakan rentang tersebut agar muat dalam frame seluas 400 poin lebar dan 100 poin tinggi. Setelah menyimpan workbook yang telah dimodifikasi ke dalam aliran, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) menyematkannya dengan ukuran yang ditentukan. Pratinjau yang dirender pada 96 DPI ditetapkan melalui [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), sehingga presentasi yang disimpan menampilkan sel yang dipilih alih-alih placeholder default.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalakan rentang sel agar sesuai dengan ukuran frame.
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

// Buat frame objek OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pembantu skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, mempertahankan lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum diterapkan dengan [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) dan [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Rentang yang dipilih harus memiliki lebar dan tinggi yang tidak nol.

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

Pembantu pratinjau ini merender ulang rentang yang diubah ukurannya menggunakan [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Ia membatasi [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) ke rentang tersebut, menghapus margin, header, dan footer, serta mengembalikan aliran PNG yang diposisikan di awal.

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

{{% alert color="info" title="Catatan" %}}

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan berfungsi dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran frame objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara frame objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menskalakan frame OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran frame OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala frame OLE atau skala rentang sel?**

Pilih **skala frame OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran frame OLE yang tetap dalam presentasi Anda.

**Apakah solusi ini akan bekerja jika presentasi saya berbasis pada templat?**

Ya. Kedua solusi berfungsi untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran frame OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat frame objek OLE dengan ukuran apa pun selama Anda mengatur skala secara tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan mengaturnya sebagai gambar placeholder frame OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Membuat Diagram Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE](/slides/id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Memperbarui Objek OLE secara Otomatis Menggunakan Add-In MS PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)