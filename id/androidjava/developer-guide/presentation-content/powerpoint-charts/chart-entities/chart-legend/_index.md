---
title: Sesuaikan Legenda Grafik dalam Presentasi di Android
linktitle: Legenda Grafik
type: docs
url: /id/androidjava/chart-legend/
keywords:
- legenda grafik
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan legenda grafik dengan Aspose.Slides for Android via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Ikhtisar**

Aspose.Slides for Android via Java menyediakan opsi untuk menyesuaikan legenda grafik dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda individu, dan menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multi-baris, dan mewarisi pemformatan dari tema presentasi.

## **Penempatan Legenda**

Gunakan metode [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), dan [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) pada legenda untuk menentukan posisi dan ukuran sebagai fraksi dari dimensi grafik.

Contoh ini membuat sebuah presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar dan tinggi diagram mengubahnya menjadi nilai relatif: legenda diposisikan 50 poin dari sudut kiri-atas diagram dan berukuran 100×100 poin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Ekspresikan posisi dan ukuran legenda relatif terhadap grafik.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Ukuran Font Legenda**

Gunakan [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) pada legenda untuk mengakses pemformatan teksnya dan gunakan [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk mengatur ukuran font dalam poin.

Contoh ini membuat diagram dengan data default dan menetapkan teks legenda menjadi 20 poin. Ini juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur rentangnya dari -5 hingga 10.

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

## **Mengatur Ukuran Font Entri Legenda Individu**

Gunakan koleksi yang dikembalikan oleh metode [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) pada legenda untuk mengakses pemformatan entri tertentu. Indeks entri dimulai dari nol, sehingga indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ini memformat entri legenda kedua dengan teks tebal, miring, dan biru berukuran 20 poin.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Menyembunyikan Entri Legenda Individu**

Untuk mengecualikan seri tambahan dari legenda sementara data tetap terlihat, panggil [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) dengan `true` melalui [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Ini hanya menyembunyikan entri legenda yang dipilih; tidak menghapus seri atau titik data nya. Memanggil [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) dengan `false`, sebaliknya, menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Itu menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian entri tersebut dipulihkan dengan memanggil [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) dengan `false` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

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

    // Kembalikan entri yang sama tanpa mengubah data grafik.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perbandingan di bawah ini menunjukkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua tersembunyi. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Pada diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Untuk diagram pai, mereka mengidentifikasi titik data individu (irisan), jadi gunakan [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) pada irisan yang dipilih sebagai gantinya. API mendokumentasikan metode titik data ini untuk tipe diagram `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, dan `BarOfPie`. Jangan menganggapnya berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Apakah saya dapat membuat diagram mengalokasikan ruang untuk legenda alih-alih menimpanya?**

Ya. Panggil [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) dengan `false` untuk memesan ruang bagi legenda alih-alih membiarkannya menimpa area plot.

**Apakah saya dapat membuat label legenda multi-baris?**

Ya. Label yang panjang dapat turun baris ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isi, dan font legenda tidak diatur sehingga dapat mewarisi pemformatan tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersangkutan.