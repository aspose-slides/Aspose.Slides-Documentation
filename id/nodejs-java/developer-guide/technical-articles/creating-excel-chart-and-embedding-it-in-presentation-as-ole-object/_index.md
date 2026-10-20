---
title: Buat Diagram Excel dan Sematkan ke dalam Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- sematkan diagram
- objek OLE
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk Node.js melalui Java dan sematkan workbook ke dalam presentasi PowerPoint dengan Aspose.Slides, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara membuat diagram kolom Excel dengan Aspose.Cells untuk Node.js melalui Java dan menyematkan workbook‑nya ke dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js melalui Java. Workbook yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint bawaan. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Instal paket Node.js `aspose.cells`, `aspose.slides.via.java`, dan `java`. Jalankan contoh sebagai dua skrip CommonJS dalam proses Node.js terpisah: pertama `create-chart.js`, kemudian `embed-chart.js`, menggunakan direktori kerja yang sama. Kedua paket Aspose menginisialisasi jembatan Java saat dimuat, sehingga contoh ini menempatkannya dalam proses terpisah. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan perpustakaan ini.

Tidak diperlukan workbook atau gambar yang sudah ada. Skrip pertama membuat `ChartWorkbook.xlsx` dan `ChartPreview.png`; skrip kedua membaca file tersebut dan menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar diagram.  
1. Aktifkan lembar diagram sehingga workbook terbuka pada diagram.  
1. Atur rentang tampilan OLE workbook dan render diagram ke PNG.  
1. Simpan workbook sebagai XLSX dan sematkan byte‑nya dalam slide pada proses Node.js terpisah.  
1. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) menerima indeks baris dan kolom mulai/akhir yang berbasis nol. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) malah menerima baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai‑nilai ini adalah pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan poin. Contoh ini menyesuaikannya dalam slide dan memusatkannya sambil mempertahankan rasio aspek PNG, alih‑alih meregangkan pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Simpan contoh pertama sebagai `create-chart.js`. Contoh ini mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render pratinjau diagram dan serialisasikan workbook yang dapat diedit secara terpisah.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Semua pekerjaan sinkron selesai; hentikan proses jembatan Java.
process.exit(0);
```

Simpan contoh berikut sebagai `embed-chart.js`. Jalankan setelah `create-chart.js` membuat kedua file input. Contoh ini memusatkan bingkai OLE dan mempertahankan rasio aspek gambar pratinjau.

Script kedua menyematkan workbook yang disimpan dan menggunakan PNG sebagai pratinjau. Workbook secara eksplisit disimpan sebagai XLSX, sesuai dengan ekstensi `xlsx` yang diberikan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG dimuat langsung dari byte‑nya tanpa konversi bitmap perantara. Jembatan Java memerlukan array byte Java eksplisit untuk gambar dan data workbook, serta nilai float Java untuk koordinat bingkai slide. Menetapkannya melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) menggantikan placeholder OLE default.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Sesuaikan pratinjau dalam slide tanpa mengubah rasio aspeknya.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Semua pekerjaan sinkron selesai; hentikan proses jembatan Java.
process.exit(0);
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau diagram. Workbook berisi data asli dan diagram kolom dengan empat seri. Pratinjau diposisikan di tengah slide dan mempertahankan proporsinya.

![Diagram kolom Excel yang ditampilkan sebagai pratinjau workbook yang disematkan](excel-chart-ole-preview.png)

Di lingkungan PowerPoint desktop yang kompatibel dengan Excel tersedia, klik dua kali objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan pengeditan bergantung pada dukungan OLE aplikasi host serta pengaturan keamanan.

## **FAQ**

**Mengapa gambar pratinjau diperlukan?**

Workbook yang disematkan dan pratinjau slide‑nya adalah konten terpisah. Sediakan gambar diagram agar slide menampilkan diagram alih‑alih placeholder default "EMBEDDED OLE OBJECT". Lihat [Object Preview Issue when Adding OleObjectFrame](/slides/id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau diperbarui secara otomatis ketika saya mengubah workbook dalam kode?**

Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatik, hasilkan kembali gambar diagram dan ganti pratinjau serta data workbook yang disematkan.

**Bisakah saya menggunakan XLS alih‑alih XLSX?**

Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus cocok dengan format workbook sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**

Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan workbook. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya penting. Lihat [Working Solution for Chart Resizing in PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambah OleObjectFrame](/slides/id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)