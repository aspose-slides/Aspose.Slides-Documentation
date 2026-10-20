---
title: Solusi Praktis untuk Mengubah Ukuran Worksheet
type: docs
weight: 20
url: /id/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE worksheet Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—menskalakan bingkai atau lembar kerja—di semua format PPT dan PPTX."
---
{{% alert color="info" title="Note" %}}
Worksheet Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat mengubah ukuran secara tak terduga setelah aktivasi pertama. Perilaku ini menimbulkan perbedaan visual yang terlihat antara objek OLE sebelum dan setelah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk menanganinya.
{{% /alert %}}

## **Latar Belakang**

Pada artikel [Kelola OLE](/slides/id/php-java/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk PHP via Java. Untuk mengatasi [masalah preview objek](/slides/id/php-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Dalam presentasi output, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun yang diinginkan pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint melakukan negosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala bingkai OLE dalam presentasi PowerPoint agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih.
- Pertahankan ukuran bingkai OLE tetap konstan dan skala baris serta kolom yang dipilih agar sesuai di dalamnya.

### **Skala Ukuran Bingkai OLE**

Pendekatan ini mengatur ukuran bingkai OLE agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih dalam lembar kerja Excel yang disematkan.

Contoh ini memuat buku kerja Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) mendefinisikan rentang yang ditampilkan. Pratinjau dirender pada 96 DPI, dan dimensi pixel-nya dikonversi ke poin menggunakan 72 poin per inci. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) menyematkan buku kerja yang telah dimodifikasi ke dalam bingkai dengan dimensi tersebut. Pratinjau ditetapkan melalui [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Menyematkan workbook yang dimodifikasi dan menyimpan data biner dalam array byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Pembantu pratinjau mengatur [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) diaktifkan, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) merender rentang tersebut sebagai gambar PNG. Pembantu mengembalikan aliran input baru yang berisi gambar PNG, diposisikan pada awalnya untuk digunakan dalam presentasi.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Skala Ukuran Rentang Sel**

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar sesuai dengan ukuran bingkai OLE khusus.

Contoh ini memuat buku kerja Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) mendefinisikan rentang yang ditampilkan, dan pembantu di bawah ini menskalakan rentang tersebut agar sesuai dengan bingkai seluas 400 poin lebar dan 100 poin tinggi. Setelah menyimpan buku kerja yang dimodifikasi ke aliran, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) menyematkannya dengan ukuran yang ditentukan. Pratinjau yang dirender pada 96 DPI ditetapkan melalui [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), sehingga presentasi yang disimpan menampilkan sel yang dipilih alih-alih placeholder default.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Menyematkan workbook yang dimodifikasi dan menyimpan data biner dalam array byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Pembantu skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, mempertahankan lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum menerapkannya dengan [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) dan [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Rentang yang dipilih harus memiliki lebar dan tinggi yang tidak nol.

```php
use aspose\cells\CellsUnitType;

// Lebar dan tinggi adalah dimensi yang diharapkan dari rentang sel dalam poin.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Pembantu pratinjau ini merender rentang yang diubah ukurannya menggunakan [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Ia membatasi [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ke rentang tersebut, menghapus margin, header, dan footer, serta mengembalikan aliran PNG yang diposisikan pada awalnya.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Kesimpulan**

{{% alert color="info" title="Note" %}}
Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan berfungsi dengan cara yang sama, baik presentasi dibuat dari templat maupun dari nol. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.
{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sedangkan bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel melakukan negosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk sepenuhnya mencegah masalah perubahan ukuran ini?**

Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**

Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel yang asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan berfungsi jika presentasi saya berbasis pada templat?**

Ya. Kedua solusi berfungsi untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat bingkai objek OLE dengan ukuran berapa pun selama Anda mengatur skala dengan tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar preview khusus menggantikan placeholder default.

## **Artikel Terkait**

[Membuat Diagram Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE](/slides/id/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Memperbarui Objek OLE secara Otomatis Menggunakan Add-In MS PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)