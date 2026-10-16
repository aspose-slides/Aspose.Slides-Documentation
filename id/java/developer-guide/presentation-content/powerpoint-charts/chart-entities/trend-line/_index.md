---
title: Tambah Garis Tren ke Diagram Presentasi di Java
linktitle: Garis Tren
type: docs
url: /id/java/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren daya
- garis tren kustom
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Dengan cepat menambahkan dan menyesuaikan garis tren dalam diagram PowerPoint menggunakan Aspose.Slides untuk Java — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan daya.

Selain itu, artikel ini menjelaskan cara menambahkan garis kustom ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) untuk menambahkan garis tren ke seri diagram, dengan memilih tipenya menggunakan [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Contoh ini membuat diagram kolom berkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing tiga serinya.

Garis tren eksponensial menyembunyikan persamaannya dan nilai R‑squared melalui [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) dan [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), sementara garis tren linear berwarna merah. Garis tren logaritmik menggunakan [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) untuk label kustom. Rata‑rata bergerak menggunakan [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) tiga titik data dan [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) kustom.

Garis tren polinomial memiliki [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) tiga dan memperpanjang satu kategori ke depan melalui [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Garis tren daya memperpanjang satu kategori ke belakang melalui [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menetapkan Intersep Garis Tren**

Gunakan [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) untuk mengunci nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linear, eksponensial, dan polinomial.

Misalnya, model biaya produksi mungkin perlu dimulai dengan biaya tetap yang diketahui sebesar 100, bahkan ketika pengukuran pada volume produksi tidak nol menunjukkan baseline yang berbeda. Untuk garis tren linear, mengunci intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan dipasang pada data dengan batasan tersebut. Ini tidak sekadar memindahkan garis yang sudah dipasang. Pengaturan pertemuan sumbu mengontrol di mana sumbu diagram bertemu, bukan koefisien garis tren yang dipasang.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi dari 1 hingga 4 dan biaya 170, 200, 230, dan 260. Diagram disimpan dengan intersep otomatis default, kemudian intersep diatur ke 100, dan disimpan PPTX kedua. Kedua file hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali ke X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Mengatur intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sementara garis tidak lagi melewati setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linear dengan intersep yang dihitung otomatis 140](intercept-automatic.png) | ![Garis tren linear dengan intersep tetap 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali ke X = 0 untuk menunjukkan intersepnya.

Secara default, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) mengembalikan `Double.NaN`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung otomatis dari data.

## **Menambahkan Garis Kustom**

Garis kustom adalah bentuk yang digambar di atas diagram bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga dimulai di tepi kiri diagram dan berada setengah tinggi diagram. Lebarnya sesuai dengan lebar diagram. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) memberi garis warna merah solid.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' untuk garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan maju/mundur: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/java/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/java/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/java/create-shape-thumbnails/) itu sendiri.