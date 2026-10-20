---
title: Solusi Praktis untuk Perubahan Ukuran Lembar Kerja
type: docs
weight: 20
url: /id/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- gambar pratinjau
- pengubahan ukuran gambar
- Excel
- lembar kerja
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Perbaiki perubahan ukuran OLE lembar kerja Excel dalam presentasi: dua cara untuk menjaga konsistensi bingkai objek—skala bingkai atau lembar kerja—di seluruh format PPT dan PPTX."
---
{{% alert color="info" title="Note" %}}

Lembar kerja Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran secara tidak terduga setelah aktivasi pertama. Perilaku ini menciptakan perbedaan visual yang terlihat antara objek OLE sebelum dan setelah aktivasi. Artikel ini menjelaskan masalah tersebut dan menggambarkan dua cara untuk menanganinya.

{{% /alert %}}

## **Latar Belakang**

Di artikel [Kelola OLE](/slides/id/nodejs-java/manage-ole/), kami menjelaskan cara menambahkan bingkai OLE ke presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar area lembar kerja yang dipilih ke bingkai objek OLE. Dalam presentasi keluaran, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar lembar kerja, buku kerja Excel diaktifkan. Pengguna akhir dapat melakukan perubahan apa pun yang diinginkan pada buku kerja Excel yang sebenarnya dan kemudian kembali ke slide dengan mengklik di luar buku kerja Excel yang diaktifkan. Ukuran bingkai objek OLE akan berubah ketika pengguna kembali ke slide. Faktor perubahan ukuran akan bervariasi tergantung pada ukuran bingkai objek OLE dan buku kerja Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Karena buku kerja Excel memiliki ukuran jendela sendiri, ia berusaha mempertahankan ukuran aslinya saat aktivasi pertama. Di sisi lain, bingkai objek OLE memiliki ukuran tersendiri. Menurut Microsoft, ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi tentang ukuran untuk memastikan proporsi yang tepat sebagai bagian dari proses penyematan. Perubahan ukuran terjadi berdasarkan perbedaan antara ukuran jendela Excel dan ukuran serta posisi bingkai objek OLE.

## **Solusi yang Berfungsi**

Ada dua solusi yang memungkinkan untuk menghindari efek perubahan ukuran.

- Skala bingkai OLE dalam presentasi PowerPoint agar sesuai dengan tinggi dan lebar total baris dan kolom yang dipilih.
- Pertahankan ukuran bingkai OLE tetap konstan dan skala baris serta kolom yang dipilih agar sesuai di dalamnya.

### **Skala Ukuran Bingkai OLE**

Pendekatan ini mengatur ukuran bingkai OLE agar sesuai dengan tinggi dan lebar total baris serta kolom yang dipilih dalam lembar kerja Excel yang disematkan.

Contoh ini memuat buku kerja Excel yang sudah ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) mendefinisikan rentang yang ditampilkan. Pratinjau dirender pada 96 DPI, dan dimensi pixelnya dikonversi ke poin menggunakan 72 poin per inci. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) menyematkan buku kerja yang dimodifikasi ke dalam bingkai dengan dimensi tersebut. Pratinjau ditetapkan melalui [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) untuk menggantikan placeholder "EMBEDDED OLE OBJECT" dalam presentasi yang disimpan.

Instal paket `aspose.cells`, `aspose.slides.via.java`, dan `java` serta letakkan `sample.xlsx` di direktori kerja. Untuk setiap pendekatan, jalankan skrip persiapan terlebih dahulu, kemudian skrip penyematan dalam proses Node.js terpisah di direktori yang sama. Kedua paket Aspose menginisialisasi jembatan Java secara terpisah.

Simpan skrip persiapan ini sebagai `prepare-frame-scaled.js` dan jalankan dengan `node prepare-frame-scaled.js`. Skrip ini menulis `frame-scaled.xlsx` dan `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Semua pekerjaan sinkron selesai; hentikan proses bridge Java.
process.exit(0);
```

Simpan skrip penyematan ini sebagai `embed-frame-scaled.js` dan jalankan dengan `node embed-frame-scaled.js`. Skrip ini membaca file tersebut dan menulis `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Semua pekerjaan sinkron selesai; hentikan proses bridge Java.
process.exit(0);
```

Pembantu pratinjau mengatur [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) ke rentang yang dipilih dan menghapus margin, header, serta footer. Dengan [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) diaktifkan, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) merender rentang sebagai gambar PNG. Pembantu menyimpan gambar PNG ke file untuk digunakan dalam presentasi.

### **Skala Ukuran Rentang Sel**

Pendekatan ini menskalakan tinggi baris yang dipilih dan lebar kolom yang dipilih agar sesuai dengan ukuran bingkai OLE khusus.

Contoh ini memuat buku kerja Excel yang ada dan memilih 10 baris pertama serta 13 kolom pertama dari lembar kerja pertamanya menggunakan indeks berbasis nol. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) mendefinisikan rentang yang ditampilkan, dan pembantu menskalakan rentang tersebut agar cocok dengan bingkai seluas 400 poin lebar dan 100 poin tinggi. Setelah menyimpan buku kerja yang dimodifikasi ke sebuah file, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) menyematkannya pada ukuran yang ditentukan. Pratinjau yang dirender pada 96 DPI ditetapkan melalui [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), sehingga presentasi yang disimpan menampilkan sel yang dipilih daripada placeholder default.

Simpan skrip persiapan ini sebagai `prepare-cells-scaled.js` dan jalankan dengan `node prepare-cells-scaled.js`. Skrip ini menulis `cells-scaled.xlsx` dan `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Semua pekerjaan sinkron selesai; hentikan proses bridge Java.
process.exit(cellsPrepared ? 0 : 1);
```

Simpan skrip penyematan ini sebagai `embed-cells-scaled.js` dan jalankan dengan `node embed-cells-scaled.js`. Skrip ini membaca file tersebut dan menulis `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Semua pekerjaan sinkron selesai; hentikan proses bridge Java.
process.exit(0);
```

Pembantu skala menghitung rasio lebar dan tinggi terpisah untuk rentang yang dipilih, mempertahankan lebar relatif kolomnya dan tinggi relatif barisnya. Ia mengonversi dimensi yang dihitung dari poin ke inci sebelum menerapkannya dengan [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) dan [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Rentang yang dipilih harus memiliki lebar dan tinggi tidak nol.

Pembantu pratinjau ini merender rentang yang diubah ukuran menggunakan [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Ia membatasi [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) ke rentang tersebut, menghapus margin, header, dan footer, serta menyimpan gambar PNG ke sebuah file.

## **Kesimpulan**

{{% alert color="info" title="Note" %}}

Ada dua pendekatan untuk memperbaiki masalah perubahan ukuran lembar kerja. Pilih pendekatan yang paling sesuai dengan kebutuhan dan kasus penggunaan Anda. Kedua pendekatan bekerja dengan cara yang sama, baik presentasi dibuat dari templat maupun dari awal. Selain itu, tidak ada batasan ukuran bingkai objek OLE dalam solusi ini.

{{% /alert %}}

## **FAQ**

**Mengapa lembar kerja Excel yang disematkan berubah ukuran saat pertama kali diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel berusaha mempertahankan ukuran jendela asli saat diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensinya sendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk menjaga rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Apakah memungkinkan untuk mencegah masalah perubahan ukuran ini sepenuhnya?**

Ya. Dengan menskalakan bingkai OLE agar sesuai dengan ukuran rentang sel Excel atau menskalakan rentang sel agar sesuai dengan ukuran bingkai OLE yang diinginkan, Anda dapat mencegah perubahan ukuran yang tidak diinginkan.

**Metode skala mana yang harus saya gunakan, skala bingkai OLE atau skala rentang sel?**

Pilih **skala bingkai OLE** jika Anda ingin mempertahankan ukuran baris dan kolom Excel yang asli. Pilih **skala rentang sel** jika Anda menginginkan ukuran tetap untuk bingkai OLE dalam presentasi Anda.

**Apakah solusi ini akan berfungsi jika presentasi saya berbasis templat?**

Ya. Kedua solusi berfungsi untuk presentasi yang dibuat dari templat maupun dari awal.

**Apakah ada batasan ukuran bingkai OLE saat menggunakan metode ini?**

Tidak. Anda dapat membuat bingkai objek OLE dengan ukuran apa pun selama Anda mengatur skala secara tepat.

**Apakah ada cara untuk menghindari teks placeholder "EMBEDDED OLE OBJECT" di PowerPoint?**

Ya. Dengan mengambil snapshot dari rentang sel Excel target dan menetapkannya sebagai gambar placeholder bingkai OLE, Anda dapat menampilkan gambar pratinjau khusus menggantikan placeholder default.

## **Artikel Terkait**

[Membuat Grafik Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE](/slides/id/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Memperbarui Objek OLE Secara Otomatis Menggunakan Add-In MS PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)