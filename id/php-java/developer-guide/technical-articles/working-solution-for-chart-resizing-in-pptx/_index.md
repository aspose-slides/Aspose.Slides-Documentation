---
title: Solusi Praktis untuk Pengubahan Ukuran Diagram di PPTX
type: docs
weight: 40
url: /id/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- pengubahan ukuran diagram
- diagram Excel
- objek OLE
- menyisipkan diagram
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak diharapkan pada PPTX saat menggunakan objek OLE Excel yang disisipkan dengan Aspose.Slides untuk PHP via Java. Tetapkan dimensi diagram tetap untuk menjaga ukuran diagram dan frame OLE tetap konsisten."
---
## **Gambaran Umum**

Diagram Excel yang disisipkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang terlihat pada tampilan diagram sebelum dan setelah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan frame OLE.

Dalam [Buat Diagram Excel dan Sisipkan Sebagai Obyek OLE dalam Presentasi](/slides/id/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells for PHP via Java dan menyisipkannya dalam presentasi PowerPoint menggunakan Aspose.Slides for PHP via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/php-java/object-preview-issue-when-adding-oleobjectframe/), kami menetapkan gambar diagram ke frame objek OLE diagram tersebut. Pada presentasi keluaran, ketika Anda mengklik ganda frame objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat mengedit buku kerja Excel yang disisipkan dan kemudian kembali ke slide dengan mengklik di luar buku kerja yang diaktifkan. Ukuran frame objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik frame objek OLE maupun buku kerja Excel yang disisipkan.

## **Penyebab Perubahan Ukuran**

Buku kerja Excel yang disisipkan memiliki dimensi jendela sendiri, yang coba dipertahankan oleh Excel ketika objek pertama kali diaktifkan. Frame OLE pada slide memiliki dimensi yang ditentukan secara terpisah. Ketika buku kerja Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk menjaga proporsinya sebagai bagian dari proses penyisipan. Perbedaan antara jendela buku kerja dan frame OLE dapat menyebabkan objek berubah ukuran.

## **Solusi yang Berfungsi**

Cocokkan ukuran diagram dengan frame OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela buku kerja. Solusi ini bekerja dengan presentasi baru atau template yang ada.

Contoh ini memerlukan Aspose.Cells for PHP via Java dan Aspose.Slides for PHP via Java. Konfigurasikan kedua produk dengan instance PHP/Java Bridge yang sama, muat kedua pembungkus PHP, dan buat kedua pustaka Java tersedia untuk bridge. Tidak diperlukan file input. Ia membuat diagram kolom sederhana pada lembar diagram aktif dan menyisipkan buku kerja dalam format XLS. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan frame OLE berukuran 9.5 × 4 inci yang diposisikan 0.5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide berada dalam poin (72 poin per inci). Untuk presentasi yang ada, lihat [Gunakan Template](#use-a-template).

## **Tetapkan Ukuran Diagram Tetap**

Setel [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) ke false sehingga dimensi diagram terpisah dari jendela buku kerja. Atur dimensi [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) melalui [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) dan [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), mengubah poin ke piksel dengan 96 piksel per inci: sebuah frame berukuran 684 × 288 poin sesuai dengan diagram berukuran 912 × 384 piksel. Setel [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) ke nilai CUSTOM dari [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Contoh ini menyisipkan buku kerja dengan [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) dan menyimpan presentasi dengan frame OLE 9.5 × 4 inci.

Hasil numerik Java dikonversi dengan `java_values` sebelum digunakan sebagai indeks PHP. Byte buku kerja tetap dalam array byte Java ketika diteruskan ke [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Koordinat slide dan dimensi dalam poin (72 poin per inci).
        $width = 684; // 9,5 inci.
        $height = 288; // 4 inci.

        $chart->setSizeWithWindow(false);
        // Ubah poin menjadi piksel diagram menggunakan 96 piksel per inci.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Gunakan Template**

Logika penentuan ukuran sama untuk presentasi yang ada. Untuk menyesuaikan contoh:

1. Muat presentasi template alih-alih membuat presentasi kosong.
1. Pastikan slide pertama berisi setidaknya tiga shape, lalu gunakan shape pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi frame dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Biarkan perhitungan ukuran tetap tidak berubah.
1. Tambahkan frame OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **Tanya Jawab**

**Mengapa diagram Excel yang saya sisipkan berubah ukuran setelah diaktifkan di PowerPoint?**

Hal ini terjadi karena Excel mencoba mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara frame objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana saya dapat menjaga konsistensi ukuran diagram dan frame OLE?**

Tetapkan dimensi diagram tetap yang sesuai dengan frame OLE dan gunakan ukuran cetak diagram khusus sebelum menyisipkan buku kerja. Contoh di atas menunjukkan pengaturan yang diperlukan dan konversi satuan.

**Apakah mencocokkan ukuran jendela buku kerja sudah cukup?**

Mencocokkan ukuran jendela buku kerja saja tidak secara andal mencegah frame OLE berubah ukuran setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan dalam contoh.

**Apakah solusi ini bekerja pada presentasi berbasis template dan presentasi baru?**

Ya. Untuk template, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi frame secara langsung.

**Dapatkah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan buku kerja Excel yang dibuat dengan Aspose.Cells. Ia tidak menunjukkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sisipkan Sebagai Obyek OLE dalam Presentasi](/slides/id/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)