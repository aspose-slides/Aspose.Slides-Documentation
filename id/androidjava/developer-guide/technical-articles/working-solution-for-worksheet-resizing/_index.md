---
title: Solusi Kerja untuk Mengubah Ukuran Lembar Kerja
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
description: "Perbaiki pengubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi frame objek—skala frame atau lembar kerja—di format PPT dan PPTX."
---
{{% alert color="info" %}}
Telah diamati bahwa lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint melalui komponen Aspose diubah ukurannya ke skala yang tidak teridentifikasi setelah aktivasi pertama. Perilaku ini menghasilkan perbedaan visual yang jelas dalam presentasi antara keadaan objek OLE sebelum dan sesudah aktivasi. Kami telah menyelidiki masalah ini secara detail dan menyediakan solusi, yang dibahas dalam artikel ini.
{{% /alert %}}

## **Latar Belakang**

Dalam artikel [Kelola OLE](/slides/id/androidjava/manage-ole/), kami menjelaskan cara menambahkan frame OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke frame objek OLE. Pada presentasi output, ketika Anda mengklik dua kali frame objek OLE yang menampilkan gambar lembar kerja, workbook Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apapun pada workbook Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar workbook Excel yang diaktifkan. Ukuran frame objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran frame objek OLE dan workbook Excel yang disematkan.

## **Penyebab Pengubahan Ukuran**

Karena workbook Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya pada aktivasi pertama. Di sisi lain, frame objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Pengubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi frame objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang mungkin untuk menghindari efek pengubahan ukuran.

- Skala ukuran frame OLE dalam presentasi PowerPoint agar cocok dengan tinggi dan lebar jumlah baris serta kolom yang diinginkan dalam frame OLE.  
- Pertahankan ukuran frame OLE tetap dan skala ukuran baris serta kolom yang berpartisipasi agar sesuai dengan ukuran frame OLE yang dipilih.

### **Skala Ukuran Frame OLE**

Dalam pendekatan ini, kami akan belajar cara mengatur ukuran frame OLE dari workbook Excel yang disematkan agar cocok dengan ukuran kumulatif baris dan kolom yang berpartisipasi dalam lembar kerja Excel.

Misalkan kami memiliki lembar Excel template dan ingin menambahkannya ke presentasi sebagai frame OLE. Dalam skenario ini, ukuran frame objek OLE pertama-tama akan dihitung berdasarkan tinggi baris kumulatif dan lebar kolom kumulatif dari baris dan kolom yang berpartisipasi dalam workbook. Kemudian, kami akan menetapkan ukuran frame OLE ke nilai yang dihitung tersebut. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada frame OLE di PowerPoint, kami juga akan mengambil gambar bagian yang diinginkan dari baris dan kolom dalam workbook dan menetapkannya sebagai gambar frame OLE.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Dapatkan lebar dan tinggi gambar OLE dalam satuan poin.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

// Buat frame objek OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

Dalam pendekatan ini, kami akan belajar cara menskalakan tinggi baris yang berpartisipasi dan lebar kolom yang berpartisipasi agar cocok dengan ukuran frame OLE khusus.

Misalkan kami memiliki lembar Excel template dan ingin menambahkannya ke presentasi sebagai frame OLE. Dalam skenario ini, kami akan menetapkan ukuran frame OLE dan menskalakan ukuran baris serta kolom yang berpartisipasi dalam area frame OLE. Kami kemudian akan menyimpan workbook ke aliran untuk menerapkan perubahan dan mengubahnya menjadi array byte untuk menambahkannya ke frame OLE. Untuk menghindari pesan merah "EMBEDDED OLE OBJECT" pada frame OLE di PowerPoint, kami juga akan mengambil gambar bagian yang diinginkan dari baris dan kolom dalam workbook dan menetapkannya sebagai gambar frame OLE.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Atur ukuran tampilan saat file workbook digunakan sebagai objek OLE di PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skala rentang sel agar sesuai dengan ukuran frame.
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

// Buat frame objek OLE.
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
 * @param width     Lebar yang diharapkan dari rentang sel dalam satuan poin.
 * @param height    Tinggi yang diharapkan dari rentang sel dalam satuan poin.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" %}} 
Ada dua pendekatan untuk memperbaiki masalah pengubahan ukuran lembar kerja. Pemilihan pendekatan yang tepat bergantung pada kebutuhan spesifik dan kasus penggunaan. Kedua pendekatan berfungsi dengan cara yang sama, baik presentasi dibuat dari template maupun dari awal. Selain itu, tidak ada batasan ukuran frame objek OLE dalam solusi ini.
{{% /alert %}}

## **FAQ**

### Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara frame objek OLE di PowerPoint memiliki dimensi sendiri. PowerPoint dan Excel bernegosiasi ukuran untuk menjaga rasio aspek, yang dapat menyebabkan pengubahan ukuran.

### Apakah memungkinkan untuk mencegah masalah pengubahan ukuran ini sepenuhnya?

Ya. Dengan menskalakan frame OLE agar cocok dengan ukuran rentang sel Excel atau menskalakan rentang sel agar cocok dengan ukuran frame OLE yang diinginkan, Anda dapat mencegah pengubahan ukuran yang tidak diinginkan.

### Metode skala mana yang harus saya gunakan, skala frame OLE atau skala rentang sel?

Pilih **skala frame OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk frame OLE dalam presentasi Anda.

### Apakah solusi ini akan bekerja jika presentasi saya berbasis template?

Ya. Kedua solusi bekerja untuk presentasi yang dibuat dari template maupun dari awal.

### Apakah ada batasan ukuran frame OLE saat menggunakan metode ini?

Tidak. Anda dapat membuat frame objek OLE berukuran berapa pun selama Anda mengatur skala dengan tepat.

### Apakah ada cara menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder frame OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.