---
title: Solusi Praktis untuk Mengubah Ukuran Worksheet
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
description: "Perbaiki perubahan ukuran OLE worksheet Excel dalam presentasi: dua cara untuk menjaga konsistensi frame objek—skala frame atau lembar kerja—di format PPT dan PPTX."
---
{{% alert color="info" title="Note" %}}
Worksheet Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat mengubah ukuran secara tak terduga setelah aktivasi pertama. Perilaku ini menciptakan perbedaan visual yang jelas antara objek OLE sebelum dan setelah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk mengatasinya.
{{% /alert %}}

## **Latar Belakang**

Pada artikel [Kelola OLE](/slides/id/androidjava/manage-ole/), kami menjelaskan cara menambahkan frame OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/androidjava/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area worksheet yang dipilih ke frame objek OLE. Dalam presentasi output, ketika Anda mengklik ganda frame objek OLE yang menampilkan gambar worksheet, workbook Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun pada workbook Excel sebenarnya dan kemudian kembali ke slide dengan mengklik di luar workbook Excel yang diaktifkan. Ukuran frame objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran frame objek OLE dan workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena workbook Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, frame objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi frame objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala frame OLE dalam presentasi PowerPoint agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih.
- Pertahankan ukuran frame OLE tetap dan skala baris serta kolom yang dipilih agar cocok di dalamnya.

### **Skala Ukuran Frame OLE**

Pendekatan ini menetapkan ukuran frame OLE agar sesuai dengan total tinggi dan lebar baris serta kolom yang dipilih dalam worksheet Excel yang disematkan.

Contoh tersebut memuat workbook Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari worksheet pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) menentukan rentang yang ditampilkan. Pratinjau dirender pada 96 DPI, dan dimensi pikselnya dikonversi ke poin menggunakan 72 poin per inci. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) menyematkan workbook yang dimodifikasi ke dalam sebuah frame dengan dimensi tersebut. Pratinjau ditetapkan melalui [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

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

// Atur ukuran tampilan ketika file workbook digunakan sebagai objek OLE dalam PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Kita perlu menggunakan workbook yang telah dimodifikasi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Helper pratinjau mengatur [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) diaktifkan, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) merender rentang sebagai gambar PNG. Helper mengembalikan aliran input baru yang berisi gambar PNG, ditempatkan di awalnya untuk digunakan dalam presentasi.

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

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar sesuai dengan ukuran frame OLE khusus.

Contoh tersebut memuat workbook Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari worksheet pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) menentukan rentang yang ditampilkan, dan helper di bawah ini menskalakan rentang tersebut agar cocok dengan frame berukuran 400 poin lebar dan 100 poin tinggi. Setelah menyimpan workbook yang dimodifikasi ke dalam aliran, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) menyematkannya pada ukuran yang ditentukan. Pratinjau yang dirender pada 96 DPI ditetapkan melalui [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), sehingga presentasi yang disimpan menampilkan sel yang dipilih alih-alih placeholder default.

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

// Atur ukuran tampilan ketika file workbook digunakan sebagai objek OLE dalam PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalakan rentang sel agar sesuai dengan ukuran frame.
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

Helper skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, mempertahankan lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum menerapkannya dengan [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) dan [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Rentang yang dipilih harus memiliki lebar dan tinggi yang tidak nol.

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

Helper pratinjau ini merender rentang yang diubah ukurannya menggunakan [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Ia membatasi [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) pada rentang tersebut, menghapus margin, header, dan footer, serta mengembalikan aliran PNG yang ditempatkan di awalnya.

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

{{% alert color="info" title="Note" %}}
Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran worksheet. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan berfungsi dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran frame objek OLE dalam solusi ini.
{{% /alert %}}

## **Tanya Jawab**

**Mengapa worksheet Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara frame objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi ukuran untuk menjaga rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menskalakan frame OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran frame OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala frame OLE atau skala rentang sel?**

Pilih **skala frame OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel yang asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk frame OLE dalam presentasi Anda.

**Apakah solusi ini akan bekerja jika presentasi saya berbasis templat?**

Ya. Kedua solusi bekerja untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran frame OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat frame objek OLE dengan ukuran berapa pun asalkan skala diatur dengan tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder frame OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Membuat Chart Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE](/slides/id/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Memperbarui Objek OLE Secara Otomatis Menggunakan Add-In MS PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)