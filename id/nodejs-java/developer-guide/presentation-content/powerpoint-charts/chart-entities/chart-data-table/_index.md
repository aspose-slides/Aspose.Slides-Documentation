---
title: Sesuaikan Tabel Data Diagram dalam Presentasi Menggunakan JavaScript
linktitle: Tabel Data
type: docs
url: /id/nodejs-java/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Node.js via Java."
---
## **Ikhtisar**

Aspose.Slides untuk Node.js via Java memungkinkan Anda menampilkan tabel data diagram dan menyesuaikan format teks, batas, serta kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol masing‑masing jenis batas, serta menampilkan atau menyembunyikan kunci legenda. Contoh‑contoh menyimpan diagram yang telah dikonfigurasi ke dalam file PPTX.

## **Mengatur Properti Font**

Untuk menampilkan tabel data diagram, berikan `true` ke [setDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/setdatatable/). Gunakan [getChartDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/getchartdatatable/) untuk mengakses tabel dan mengatur format teksnya.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
1. Tambahkan diagram kolom berkelompok ke slide pertama.
1. Aktifkan tabel data diagram.
1. Aktifkan teks tebal dengan [setFontBold](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setfontbold) dan berikan `20` ke [setFontHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setfontheight) untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memerlukan `input.pptx` di direktori kerja dengan setidaknya satu slide. Ia menambahkan diagram dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. `output.pptx` yang disimpan berisi diagram dengan tabel data diaktifkan serta pengaturan font yang ditentukan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menyesuaikan Batas Tabel Data**

Aktifkan tabel dengan [Chart.setDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/setdatatable/) dan akses melalui [Chart.getChartDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/getchartdatatable/). Anda dapat mengontrol tiga jenis batas secara independen:

- [setBorderHorizontal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setborderhorizontal/) mengatur batas sel horizontal.
- [setBorderVertical](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setbordervertical/) mengatur batas sel vertikal.
- [setBorderOutline](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setborderoutline/) mengatur batas luar tabel.

Berikan `true` ke setiap metode untuk menampilkan batasnya atau `false` untuk menyembunyikannya. Contoh berikut membuat diagram kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file masukan. Posisi dan ukuran diagram ditentukan dalam poin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah menggunakan data diagram yang sama dan pengaturan kunci legenda yang sama di semua empat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan satu pengaturan batas saja. Varian kiri‑bawah mencocokkan pengaturan batas pada contoh.

![Tabel data diagram dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Menampilkan atau Menyembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri diagram. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setshowlegendkey/) untuk menampilkan penanda ini atau `false` untuk menyembunyikannya.

Legenda terpisah diagram dikontrol oleh [Chart.setLegend](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/setlegend/). Pengaturan ini bersifat independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat diagram dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sambil menyembunyikan legenda terpisah. Semua batas tabel secara eksplisit diaktifkan. Tidak memerlukan presentasi masukan. Untuk menyembunyikan hanya kunci tabel, berikan `false` ke [setShowLegendKey](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah memperlihatkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda diagram terpisah disembunyikan pada kedua kasus.

![Tabel data diagram dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda di tabel data diagram?**

Ya. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/datatable/setshowlegendkey/) untuk menampilkan kunci legenda atau `false` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), atau [images](/slides/id/nodejs-java/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data dalam diagram yang dimuat dari templat?**

Ya. Untuk diagram yang dimuat dari presentasi atau templat yang ada, gunakan [hasDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/hasdatatable/) dan [setDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/setdatatable/) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan diagram yang memiliki tabel data diaktifkan?**

Iterasikan bentuk‑bentuk pada setiap slide, identifikasi diagram‑diagramnya, dan panggil metode [hasDataTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/hasdatatable/) mereka. Nilai `true` menunjukkan bahwa tabel data diaktifkan.