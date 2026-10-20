---
title: Solusi Praktis untuk Mengubah Ukuran Diagram di PPTX
type: docs
weight: 40
url: /id/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- mengubah ukuran diagram
- diagram Excel
- objek OLE
- menyematkan diagram
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Perbaiki perubahan ukuran diagram yang tidak terduga dalam PPTX saat menggunakan objek OLE Excel yang disematkan dengan Aspose.Slides untuk Node.js via Java. Tetapkan dimensi diagram tetap untuk menjaga ukuran diagram dan bingkai OLE tetap konsisten."
---
## **Gambaran Umum**

Diagram Excel yang disematkan sebagai objek OLE dalam presentasi PowerPoint menggunakan komponen Aspose dapat berubah ukuran setelah aktivasi pertama. Hal ini dapat menyebabkan perbedaan yang terlihat pada penampilan diagram sebelum dan sesudah aktivasi. Artikel ini menjelaskan mengapa perubahan ukuran terjadi dan menunjukkan cara mencegahnya dengan mencocokkan dimensi diagram tetap dengan bingkai OLE.

In [Buat Diagram Excel dan Sematkan sebagai Objek OLE dalam Presentasi](/slides/id/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), kami menjelaskan cara membuat diagram Excel dengan Aspose.Cells untuk Node.js via Java dan menyematkannya dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js via Java. Untuk mengatasi [masalah pratinjau objek](/slides/id/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), kami menugaskan gambar diagram ke bingkai objek OLE diagram. Dalam presentasi keluaran, ketika Anda mengklik dua kali bingkai objek OLE yang menampilkan gambar diagram, diagram Excel diaktifkan. Pengguna dapat menyunting workbook Excel yang disematkan dan kemudian kembali ke slide dengan mengklik di luar workbook yang diaktifkan. Ukuran bingkai objek OLE berubah ketika pengguna kembali ke slide, dan faktor perubahan ukuran bervariasi tergantung pada ukuran asli baik bingkai objek OLE maupun workbook Excel yang disematkan.

## **Penyebab Perubahan Ukuran**

Workbook Excel yang disematkan memiliki dimensi jendela tersendiri, yang berusaha dipertahankan oleh Excel saat objek pertama kali diaktifkan. Bingkai OLE pada slide memiliki dimensi yang ditentukan secara terpisah. Ketika workbook Excel diaktifkan, Excel dan PowerPoint bernegosiasi mengenai ukuran objek untuk mempertahankan proporsinya sebagai bagian dari proses penyematan. Perbedaan antara jendela workbook dan bingkai OLE dapat menyebabkan objek berubah ukuran.

## **Solusi yang Berfungsi**

Cocokkan ukuran diagram dengan bingkai OLE pada slide dan pertahankan dimensi diagram terpisah dari jendela workbook. Solusi ini berfungsi dengan presentasi baru atau templat yang sudah ada.

Contoh ini memerlukan Aspose.Cells untuk Node.js via Java dan Aspose.Slides untuk Node.js via Java. Instal paket Node.js `aspose.cells`, `aspose.slides.via.java`, dan `java`. Jalankan dua skrip CommonJS di bawah ini dalam proses Node.js terpisah, menggunakan direktori kerja yang sama, karena kedua paket Aspose menginisialisasi jembatan Java saat dimuat. Skrip ini membuat diagram kolom sederhana pada lembar diagram aktif dan menyematkan workbook dalam format XLS. Tidak ada gambar pratinjau diagram yang ditetapkan; diagram menjadi terlihat ketika objek OLE diaktifkan di PowerPoint.

Contoh ini membuat presentasi baru dengan bingkai OLE berukuran 9,5 × 4 inci yang diposisikan 0,5 inci dari tepi kiri dan 1 inci dari atas. Koordinat dan dimensi slide dalam poin (72 poin per inci). Untuk presentasi yang sudah ada, lihat [Gunakan Template](#use-a-template).

## **Tetapkan Ukuran Diagram Tetap**

Setel [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) ke false sehingga dimensi diagram terpisah dari jendela workbook. Setel dimensi [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) melalui [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) dan [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), mengonversi poin ke piksel dengan menggunakan 96 piksel per inci: sebuah bingkai berukuran 684 × 288 poin sesuai dengan diagram berukuran 912 × 384 piksel. Setel [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) ke nilai CUSTOM dari `PrintSizeType`. Contoh ini menyematkan workbook dengan [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) dan menyimpan presentasi dengan bingkai OLE berukuran 9,5 × 4 inci.

Simpan skrip pertama ini sebagai `create-fixed-chart.js`. Skrip ini menghasilkan `chart-fixed-size.xls` dengan diagram berukuran 912 × 384 piksel, yang cocok dengan bingkai 684 × 288 poin yang digunakan oleh skrip kedua. Tidak diperlukan workbook input.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Sesuaikan dimensi bingkai OLE dalam poin (72 poin per inci).
    const width = 684; // 9,5 inci.
    const height = 288; // 4 inci.

    chart.setSizeWithWindow(false);
    // Konversi poin ke piksel diagram menggunakan 96 piksel per inci.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Semua pekerjaan sinkron telah selesai; hentikan proses jembatan Java.
process.exit(0);
```

Simpan skrip kedua sebagai `embed-fixed-chart.js` dan jalankan setelah `create-fixed-chart.js`. Skrip ini membaca workbook XLS yang dihasilkan dan menyimpan `chart-fixed-size.pptx`. Jembatan Java memerlukan array byte Java yang eksplisit untuk data workbook serta nilai float Java untuk koordinat dan dimensi bingkai. Ekstensi `xls` sesuai dengan format penyimpanan workbook.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Koordinat dan dimensi slide dalam poin (72 poin per inci).
    const width = 684; // 9,5 inci.
    const height = 288; // 4 inci.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Semua pekerjaan sinkron telah selesai; hentikan proses jembatan Java.
process.exit(0);
```

## **Gunakan Template**

Logika pengukuran ukuran sama untuk presentasi yang sudah ada. Untuk menyesuaikan contoh:

1. Muat presentasi templat alih-alih membuat presentasi kosong.
1. Pastikan slide pertama memiliki setidaknya tiga shape, kemudian gunakan shape pada indeks 2 sebagai placeholder.
1. Ambil lebar dan tinggi bingkai dari shape tersebut alih-alih menggunakan nilai tetap 684 dan 288. Gunakan dimensi yang sama dalam skrip pembuatan workbook, pertahankan perhitungan ukuran tidak berubah, dan hasilkan kembali workbook XLS sebelum menyematkannya.
1. Tambahkan bingkai OLE pada posisi placeholder alih-alih koordinat tetap 36 dan 72.
1. Hapus placeholder sebelum menyimpan presentasi.

## **FAQ**

**Mengapa diagram Excel yang saya sematkan berubah ukuran setelah diaktifkan di PowerPoint?**

Ini terjadi karena Excel berusaha mengembalikan ukuran jendela asli saat pertama kali diaktifkan, sementara bingkai objek OLE di PowerPoint memiliki dimensi tersendiri. PowerPoint dan Excel bernegosiasi mengenai ukuran untuk mempertahankan rasio aspek, yang dapat menyebabkan perubahan ukuran.

**Bagaimana saya dapat menjaga konsistensi ukuran diagram dan bingkai OLE?**

Tetapkan dimensi diagram tetap yang sesuai dengan bingkai OLE dan gunakan ukuran cetak diagram khusus sebelum menyematkan workbook. Contoh di atas menunjukkan pengaturan yang diperlukan serta konversi satuan.

**Apakah mencocokkan ukuran jendela workbook sudah cukup?**

Mencocokkan ukuran jendela workbook saja tidak dapat diandalkan untuk mencegah bingkai OLE berubah ukuran setelah aktivasi. Gunakan dimensi diagram tetap seperti yang ditunjukkan dalam contoh.

**Apakah solusi ini bekerja dengan presentasi berbasis templat dan presentasi baru?**

Ya. Untuk templat, gunakan dimensi dan posisi placeholder. Untuk presentasi baru, tentukan dimensi dan posisi bingkai secara langsung.

**Bisakah saya menggunakan contoh ini dengan diagram yang dibuat di program spreadsheet lain?**

Contoh ini menggunakan workbook Excel yang dibuat dengan Aspose.Cells. Ia tidak memperlihatkan perilaku aktivasi untuk program spreadsheet lain.

## **Bagian Terkait**

- [Buat Diagram Excel dan Sematkan sebagai Objek OLE dalam Presentasi](/slides/id/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)