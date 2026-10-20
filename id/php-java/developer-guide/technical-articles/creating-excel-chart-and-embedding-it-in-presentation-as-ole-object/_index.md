---
title: Membuat Diagram Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE
type: docs
weight: 30
url: /id/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Diagram Excel
- menyematkan diagram
- objek OLE
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat diagram Excel dengan Aspose.Cells untuk PHP via Java dan sematkan workbook-nya dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java, termasuk pratinjau diagram."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat diagram kolom Excel dengan Aspose.Cells untuk PHP via Java dan menyematkan workbook‑nya ke dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Workbook yang disematkan berisi data sumber dan diagram. Pratinjau PNG terpisah menampilkan diagram pada slide sebelum objek OLE diaktifkan.

Hasilnya adalah objek Excel yang disematkan, bukan diagram PowerPoint asli. Mengedit workbook melalui OLE memerlukan aplikasi desktop yang mendukung aktivasi OLE dan instalasi Excel yang kompatibel.

## **Prasyarat**

Konfigurasikan Aspose.Cells untuk PHP via Java dan Aspose.Slides untuk PHP via Java dengan instance PHP/Java Bridge yang sama. Muat kedua pembungkus PHP dan buat perpustakaan Java kedua produk tersedia untuk bridge. Microsoft Office tidak diperlukan untuk menghasilkan presentasi dengan pustaka ini.

Tidak diperlukan file input: contoh membuat data dan diagram dalam memori, lalu menulis `OutputChart.pptx` ke direktori kerja saat ini. Terapkan lisensi untuk kedua produk saat dijalankan di luar mode evaluasi.

## **Cara Kerja Penyematan**

1. Buat workbook dengan lembar kerja data dan lembar diagram.  
2. Aktifkan lembar diagram sehingga workbook terbuka pada diagram.  
3. Atur rentang tampilan OLE workbook dan render diagram ke PNG.  
4. Simpan workbook sebagai XLSX dalam memori dan sematkan byte tersebut ke dalam slide.  
5. Tetapkan PNG sebagai pratinjau objek OLE dan simpan presentasi sebagai PPTX.

Rentang tampilan workbook dan bingkai pada slide memiliki peran yang berbeda. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) mengambil indeks baris dan kolom awal/akhir yang berbasis nol. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) justru mengambil baris atas, kolom kiri, baris bawah, dan kolom kanan. Contoh ini menggunakan indeks baris 55 dan indeks kolom 25 sebagai batas kanan‑bawah; nilai ini merupakan pilihan tata letak, bukan jumlah baris atau kolom data.

Bingkai slide menggunakan poin. Contoh ini menyesuaikannya dalam slide dan menengahkan sambil mempertahankan rasio aspek PNG, bukan memperluas pratinjau untuk mengisi slide.

## **Buat dan Sematkan Diagram**

Contoh lengkap berikut mengisi `DataSheet` dengan empat baris dan lima kolom nilai. Setiap baris menjadi satu seri diagram. `ChartSheet` dipilih sebagai lembar aktif sebelum workbook disimpan.

Workbook secara eksplisit disimpan sebagai XLSX, cocok dengan ekstensi `xlsx` yang diberikan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Hasil numerik Java dikonversi dengan `java_values` sebelum PHP melakukan operasi aritmetika, sementara data biner tetap dalam array byte Java. PNG dimuat langsung dari byte‑nya tanpa konversi bitmap menengah. Menetapkannya melalui [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) menggantikan placeholder OLE default.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Simpan PNG dan XLSX sebagai array byte Java saat meneruskannya ke Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Sesuaikan dan tengahkan pratinjau sambil mempertahankan rasio aspeknya.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Hasil yang Diharapkan**

`OutputChart.pptx` berisi satu slide dengan workbook Excel yang disematkan dan pratinjau diagram. Workbook berisi data asli dan diagram kolom dengan empat seri. Pratinjau tersebut ditempatkan di tengah slide dan mempertahankan proporsinya.

![Diagram kolom Excel ditampilkan sebagai pratinjau workbook yang disematkan](excel-chart-ole-preview.png)

Dalam lingkungan PowerPoint desktop yang kompatibel dengan Excel tersedia, klik ganda objek untuk mengaktifkan dan mengedit workbook yang disematkan. Aktivasi dan pengeditan bergantung pada dukungan OLE aplikasi host dan pengaturan keamanannya.

## **Tanya Jawab**

**Mengapa gambar pratinjau diperlukan?**  
Workbook yang disematkan dan pratinjau slidennya merupakan konten terpisah. Sediakan gambar diagram sehingga slide menampilkan diagram alih‑alih placeholder default "EMBEDDED OLE OBJECT". Lihat [Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame](/slides/id/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Apakah pratinjau diperbarui secara otomatis ketika saya mengubah workbook dalam kode?**  
Anggap pratinjau sebagai snapshot. Saat memperbarui data workbook secara programatik, buat ulang gambar diagram dan ganti pratinjau serta data workbook yang disematkan.

**Bisakah saya menggunakan XLS alih‑alih XLSX?**  
Ya. Simpan workbook dalam format XLS dan gunakan `xls` sebagai ekstensi data yang disematkan. Ekstensi harus sesuai dengan format workbook yang sebenarnya; mengubah ekstensi saja tidak mengonversi data.

**Mengapa objek dapat berubah ukuran setelah aktivasi?**  
Aplikasi host dapat memperbarui tampilan objek OLE ketika mengaktifkan workbook. Rentang tampilan OLE workbook dan dimensi bingkai slide keduanya penting. Lihat [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/).

## **Bagian Terkait**

- [Solusi Bekerja untuk Mengubah Ukuran Diagram di PPTX](/slides/id/java/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek Saat Menambahkan OleObjectFrame](/slides/id/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Kelola Objek OLE](/slides/id/php-java/manage-ole/)