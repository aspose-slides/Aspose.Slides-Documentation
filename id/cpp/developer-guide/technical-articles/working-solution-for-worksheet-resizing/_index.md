---
title: Solusi Bekerja untuk Perubahan Ukuran Lembar Kerja
type: docs
weight: 130
url: /id/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- C++
- Aspose.Slides for C++
description: "Solusi kerja untuk perubahan ukuran lembar kerja dalam presentasi PowerPoint menggunakan C++"
---
{{% alert color="primary" %}}

Telah diamati bahwa lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak teridentifikasi setelah aktivasi pertama. Perilaku ini menimbulkan perbedaan visual yang terlihat antara keadaan pra‑aktivasi dan pasca‑aktivasi objek OLE dalam presentasi. Kami telah menyelidiki masalah ini secara mendetail dan memberikan solusi, yang dibahas dalam artikel ini.

{{% /alert %}}

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/cpp/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk C++. Untuk mengatasi [masalah pratinjau objek](/slides/id/cpp/object-preview-issue-when-adding-oleobjectframe/), kami menugaskan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Pada presentasi output, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna dapat melakukan perubahan apa pun pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan. 

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran asli saat aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala ukuran bingkai OLE dalam presentasi PowerPoint agar sesuai dengan tinggi dan lebar jumlah baris serta kolom yang diinginkan dalam bingkai OLE.
- Pertahankan ukuran bingkai OLE tetap dan skala ukuran baris serta kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE yang dipilih.

### **Skala Ukuran Bingkai OLE**

Dengan pendekatan ini, kita akan mempelajari cara mengatur ukuran bingkai OLE buku kerja Excel yang disematkan agar cocok dengan ukuran kumulatif baris dan kolom yang berpartisipasi dalam lembar kerja Excel.

Misalkan kita memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, ukuran bingkai objek OLE pertama‑tama akan dihitung berdasarkan tinggi baris kumulatif dan lebar kolom kumulatif baris dan kolom yang berpartisipasi dalam buku kerja. Kemudian, kita akan menetapkan ukuran bingkai OLE ke nilai yang dihitung tersebut. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian baris dan kolom yang diinginkan dalam buku kerja dan menjadikannya gambar bingkai OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Atur ukuran tampilan ketika file buku kerja digunakan sebagai objek OLE di PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Skala Ukuran Rentang Sel**

Dengan pendekatan ini, kita akan mempelajari cara menskalakan tinggi baris yang berpartisipasi dan lebar kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE khusus.

Misalkan kita memiliki lembar Excel templat dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, kita akan menetapkan ukuran bingkai OLE dan menskalakan ukuran baris serta kolom yang berpartisipasi dalam area bingkai OLE. Selanjutnya, kita akan menyimpan buku kerja ke aliran untuk menerapkan perubahan dan mengonversinya menjadi array byte untuk menambahkannya ke bingkai OLE. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian baris dan kolom yang diinginkan dalam buku kerja dan menjadikannya gambar bingkai OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Atur ukuran tampilan ketika file buku kerja digunakan sebagai objek OLE di PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala rentang sel agar sesuai dengan ukuran bingkai.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Kita perlu menggunakan buku kerja yang telah dimodifikasi.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Tambahkan gambar OLE ke sumber daya presentasi.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Buat bingkai objek OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">Lebar yang diharapkan dari rentang sel dalam poin.</param>
/// <param name="height">Tinggi yang diharapkan dari rentang sel dalam poin.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Kesimpulan**

{{% alert color="primary" %}}

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pemilihan pendekatan yang tepat bergantung pada kebutuhan khusus dan kasus penggunaan. Kedua pendekatan berfungsi dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah mungkin mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**

Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan bekerja jika presentasi saya berbasis templat?**

Ya. Kedua solusi bekerja untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat bingkai objek OLE dengan ukuran berapa pun asalkan Anda mengatur skala secara tepat.

**Apakah ada cara menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot rentang sel Excel target dan menjadikannya gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Menambahkan Diagram Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE](/slides/id/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)