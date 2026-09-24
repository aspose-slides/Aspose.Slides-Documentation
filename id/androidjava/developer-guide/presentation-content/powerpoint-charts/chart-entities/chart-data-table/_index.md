---
title: Sesuaikan Tabel Data Diagram dalam Presentasi di Android
linktitle: Tabel Data
type: docs
url: /id/androidjava/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan font tabel data diagram, batas, dan kunci legenda dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java memungkinkan Anda menampilkan tabel data diagram dan menyesuaikan pemformatan teks, batas, dan kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol setiap jenis batas, serta menampilkan atau menyembunyikan kunci legenda. Contoh-contoh menyimpan diagram yang dikonfigurasi dalam file PPTX.

## **Mengatur Properti Font**

Untuk menampilkan tabel data diagram, berikan `true` ke [setDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Gunakan [getChartDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#getChartDataTable--) untuk mengakses tabel dan mengonfigurasi pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Tambahkan diagram kolom berkelompok ke slide pertama.
1. Aktifkan tabel data diagram.
1. Aktifkan teks tebal dengan [setFontBold](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) dan berikan `20` ke [setFontHeight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memerlukan `test.pptx` di direktori kerja dengan setidaknya satu slide. Ini menambahkan diagram dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. `output.pptx` yang disimpan berisi diagram dengan tabel datanya diaktifkan dan pengaturan font yang ditentukan diterapkan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menyesuaikan Batas Tabel Data**

Aktifkan tabel dengan [IChart.setDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) dan akses melalui [IChart.getChartDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Anda dapat mengontrol tiga jenis batas secara independen:

- [setBorderHorizontal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) mengontrol batas sel horizontal.
- [setBorderVertical](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) mengontrol batas sel vertikal.
- [setBorderOutline](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) mengontrol batas luar tabel.

Berikan `true` ke setiap metode untuk menampilkan batasnya atau `false` untuk menyembunyikannya. Contoh berikut membuat diagram kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file input. Posisi dan ukuran diagram ditentukan dalam poin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah ini menggunakan data diagram dan pengaturan kunci legenda yang sama di semua empat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan hanya satu pengaturan batas. Varian kiri bawah cocok dengan pengaturan batas pada contoh.

![Tabel data diagram dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Menampilkan atau Menyembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri diagram. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) untuk menampilkan penanda ini atau `false` untuk menyembunyikannya.

Legenda terpisah diagram dikendalikan oleh [IChart.setLegend](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Pengaturan ini independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat diagram dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sambil menyembunyikan legenda terpisah. Semua batas tabel secara eksplisit diaktifkan. Tidak memerlukan presentasi input. Untuk menyembunyikan hanya kunci tabel, berikan `false` ke [setShowLegendKey](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah ini menampilkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda diagram terpisah disembunyikan dalam kedua kasus.

![Tabel data diagram dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda dalam tabel data diagram?**

Ya. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) untuk menampilkan kunci legenda atau `false` untuk menyembunyikannya.

**Apakah tabel data akan tetap dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), atau [gambar](/slides/id/androidjava/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data pada diagram yang dimuat dari templat?**

Ya. Untuk diagram yang dimuat dari presentasi atau templat yang ada, gunakan [hasDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#hasDataTable--) dan [setDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan diagram yang memiliki tabel data diaktifkan?**

Iterasi melalui bentuk-bentuk pada setiap slide, identifikasi diagram, dan panggil metode [hasDataTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/#hasDataTable--) mereka. Nilai `true` menunjukkan bahwa tabel data diaktifkan.