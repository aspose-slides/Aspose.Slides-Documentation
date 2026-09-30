---
title: Sesuaikan Legenda Diagram di Presentasi Menggunakan Java
linktitle: Legenda Diagram
type: docs
url: /id/java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides for Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for Java menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda tunggal, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multiline, dan mewarisi format dari tema presentasi.

## **Posisi Legenda**

Gunakan metode legend [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), dan [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) untuk menentukan posisi dan ukurannya sebagai pecahan dari dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda dipindahkan sejauh 50 poin dari sudut kiri atas diagram dan berukuran 100 x 100 poin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Ekspresikan posisi dan ukuran legenda relatif terhadap diagram.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Ukuran Font Legenda**

Gunakan [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) legenda untuk mengakses pemformatan teksnya dan gunakan [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Selain itu, menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur jangkauannya menjadi -5 sampai 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Ukuran Font Entri Legenda Individual**

Gunakan koleksi yang dikembalikan oleh metode [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) legenda untuk mengakses pemformatan entri tertentu. Indeks entri berbasis nol, sehingga indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ia memformat entri legenda kedua dengan teks tebal, miring, dan biru berukuran 20 poin.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sembunyikan Entri Legenda Individual**

Untuk mengecualikan seri tambahan dari legenda sambil tetap menampilkan datanya, panggil [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) dengan `true` melalui [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Ini hanya menyembunyikan entri legenda yang dipilih; tidak menghapus seri atau titik datanya. Sebaliknya, memanggil [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) dengan `false` menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Ia menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri tersebut dipulihkan dengan memanggil [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) dengan `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Pulihkan entri yang sama tanpa mengubah data diagram.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah ini menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua tersembunyi. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan dengan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Pada diagram pai, mereka mengidentifikasi titik data individual (iris), sehingga gunakan [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) pada irisan yang dipilih. API mendokumentasikan metode titik data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan menganggapnya berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Bisakah saya membuat diagram mengalokasikan ruang untuk legenda alih-alih menimpanya?**

Ya. Panggil [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) dengan `false` untuk memesan ruang bagi legenda alih-alih memungkinkan menimpanya pada area plot.

**Bisakah saya membuat label legenda multiline?**

Ya. Label yang panjang dapat dibungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana saya membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isian, dan font legenda tidak diatur sehingga dapat mewarisi pemformatan tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.