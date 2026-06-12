---
title: Solusi Praktis untuk Mengatasi Perubahan Ukuran Lembar Kerja
type: docs
weight: 20
url: /id/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—di seluruh format PPT dan PPTX."
---
{{% alert color="primary" %}}

Telah diamati bahwa lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose mengalami perubahan ukuran ke skala yang tidak teridentifikasi setelah aktivasi pertama. Perilaku ini menciptakan perbedaan visual yang terlihat jelas dalam presentasi antara keadaan objek OLE sebelum dan sesudah aktivasi. Kami telah menyelidiki masalah ini secara detail dan menyediakan solusi, yang dibahas dalam artikel ini.

{{% /alert %}}

## **Latar Belakang**

Dalam artikel [Manage OLE](/slides/id/androidjava/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java. Untuk mengatasi [object preview issue](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/), kami menugaskan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Pada presentasi output, ketika Anda mengklik ganda bingkai objek OLE yang menampilkan gambar lembar kerja, workbook Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada workbook Excel sebenarnya dan kemudian kembali ke slide dengan mengklik di luar workbook Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena workbook Excel memiliki ukuran jendela tersendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran sendiri. Menurut Microsoft, saat workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala ukuran bingkai OLE di presentasi PowerPoint agar sesuai dengan tinggi dan lebar jumlah baris serta kolom yang diinginkan dalam bingkai OLE.
- Pertahankan ukuran bingkai OLE konstan dan skala ukuran baris serta kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE yang dipilih.

### **Skala Ukuran Bingkai OLE**

Dalam pendekatan ini, kita akan belajar cara mengatur ukuran bingkai OLE dari workbook Excel yang disematkan agar sesuai dengan ukuran kumulatif baris dan kolom yang berpartisipasi dalam lembar kerja Excel.

Misalkan kita memiliki templat lembar kerja Excel dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, ukuran bingkai objek OLE pertama‑tama akan dihitung berdasarkan tinggi baris kumulatif dan lebar kolom kumulatif dari baris dan kolom yang berpartisipasi dalam workbook. Kemudian, kita akan mengatur ukuran bingkai OLE ke nilai yang dihitung tersebut. Untuk menghindari pesan merah “EMBEDDED OLE OBJECT” pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam workbook dan menetapkannya sebagai gambar bingkai OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Atur ukuran tampilan ketika file workbook digunakan sebagai objek OLE di PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Dapatkan lebar dan tinggi gambar OLE dalam poin.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Kita perlu menggunakan workbook yang telah dimodifikasi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan gambar OLE ke sumber daya presentasi.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Buat bingkai objek OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Skala Ukuran Rentang Sel**

Dalam pendekatan ini, kita akan belajar cara menyesuaikan tinggi baris yang berpartisipasi dan lebar kolom yang berpartisipasi agar sesuai dengan ukuran bingkai OLE khusus.

Misalkan kita memiliki templat lembar kerja Excel dan ingin menambahkannya ke presentasi sebagai bingkai OLE. Dalam skenario ini, kita akan mengatur ukuran bingkai OLE dan menyesuaikan ukuran baris serta kolom yang berpartisipasi dalam area bingkai OLE. Selanjutnya kita akan menyimpan workbook ke dalam stream untuk menerapkan perubahan dan mengonversinya menjadi byte array untuk ditambahkan ke bingkai OLE. Untuk menghindari pesan merah “EMBEDDED OLE OBJECT” pada bingkai OLE di PowerPoint, kita juga akan menangkap gambar bagian yang diinginkan dari baris dan kolom dalam workbook dan menetapkannya sebagai gambar bingkai OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Atur ukuran tampilan ketika file workbook digunakan sebagai objek OLE di PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala rentang sel agar sesuai dengan ukuran bingkai.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Kita perlu menggunakan workbook yang telah dimodifikasi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Tambahkan gambar OLE ke sumber daya presentasi.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Buat bingkai objek OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Lebar yang diharapkan dari rentang sel dalam poin.
 * @param height    Tinggi yang diharapkan dari rentang sel dalam poin.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Kesimpulan**

{{% alert color="primary" %}} 

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pemilihan pendekatan yang tepat bergantung pada persyaratan spesifik dan kasus penggunaan. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan pada ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menyesuaikan skala bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menyesuaikan skala rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**

Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan berfungsi jika presentasi saya berbasis templat?**

Ya. Kedua solusi berfungsi untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat bingkai objek OLE dengan ukuran apa pun selama Anda mengatur skala dengan tepat.

**Apakah ada cara untuk menghindari teks placeholder “EMBEDDED OLE OBJECT” di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.