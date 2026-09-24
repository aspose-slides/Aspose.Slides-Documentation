---
title: Sesuaikan Tabel Data Grafik pada Presentasi Menggunakan Java
linktitle: Tabel Data
type: docs
url: /id/java/chart-data-table/
keywords:
- data grafik
- tabel data
- properti font
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides for Java memungkinkan Anda menampilkan tabel data grafik dan menyesuaikan pemformatan teks, batas, serta kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol setiap jenis batas, dan menampilkan atau menyembunyikan kunci legenda. Contoh-contoh menyimpan grafik yang telah dikonfigurasi dalam file PPTX.

## **Atur Properti Font**

Untuk menampilkan tabel data grafik, berikan `true` ke [setDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#setDataTable-boolean-). Gunakan [getChartDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#getChartDataTable--) untuk mengakses tabel dan mengonfigurasi pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Tambahkan grafik kolom berkelompok ke slide pertama.
1. Aktifkan tabel data grafik.
1. Aktifkan teks tebal dengan [setFontBold](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) dan berikan `20` ke [setFontHeight](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memerlukan `test.pptx` di direktori kerja dengan setidaknya satu slide. Ia menambahkan grafik dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. `output.pptx` yang disimpan berisi grafik dengan tabel datanya diaktifkan serta pengaturan font yang ditentukan diterapkan.

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

## **Sesuaikan Batas Tabel Data**

Aktifkan tabel dengan [IChart.setDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setDataTable-boolean-) dan akses melalui [IChart.getChartDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#getChartDataTable--). Anda dapat mengontrol tiga jenis batas secara independen:

- [setBorderHorizontal](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) mengontrol batas sel horizontal.
- [setBorderVertical](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) mengontrol batas sel vertikal.
- [setBorderOutline](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) mengontrol batas luar tabel.

Berikan `true` ke setiap metode untuk menampilkan batasnya atau `false` untuk menyembunyikannya. Contoh berikut membuat grafik kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file masukan. Posisi dan ukuran grafik ditentukan dalam poin.

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

Perbandingan di bawah menggunakan data grafik dan pengaturan kunci legenda yang sama pada keempat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan satu pengaturan batas saja. Varian kiri bawah mencocokkan pengaturan batas pada contoh.

![Tabel data grafik dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Tampilkan atau Sembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri grafik. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) untuk menampilkan penanda ini atau `false` untuk menyembunyikannya.

Legenda terpisah grafik diatur oleh [IChart.setLegend](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#setLegend-boolean-). Pengaturan ini independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat grafik dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sementara menyembunyikan legenda terpisah. Semua batas tabel secara eksplisit diaktifkan. Tidak diperlukan presentasi masukan. Untuk menyembunyikan hanya kunci tabel, berikan `false` ke [setShowLegendKey](https://reference.aspose.com/slides/id/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

Perbandingan di bawah menampilkan tabel yang sama dengan kunci legenda diaktifkan dan dinonaktifkan. Semua batas tetap diaktifkan, dan legenda grafik terpisah disembunyikan pada kedua kasus.

![Tabel data grafik dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda di tabel data grafik?**

Ya. Berikan `true` ke [setShowLegendKey](https://reference.aspose.com/slides/id/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) untuk menampilkan kunci legenda atau `false` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender grafik dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/java/convert-powerpoint-to-pdf/), [HTML](/slides/id/java/convert-powerpoint-to-html/), atau [images](/slides/id/java/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data dalam grafik yang dimuat dari templat?**

Ya. Untuk grafik yang dimuat dari presentasi atau templat yang ada, gunakan [hasDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#hasDataTable--) dan [setDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#setDataTable-boolean-) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana saya dapat menemukan grafik yang memiliki tabel data diaktifkan?**

Iterasikan melalui shape pada setiap slide, identifikasi grafik, dan panggil metode [hasDataTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/#hasDataTable--) mereka. Nilai `true` menunjukkan bahwa tabel data diaktifkan.