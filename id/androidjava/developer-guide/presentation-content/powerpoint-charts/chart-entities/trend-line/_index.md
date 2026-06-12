---
title: Menambahkan Garis Tren ke Diagram Presentasi di Android
linktitle: Garis Tren
type: docs
url: /id/androidjava/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren daya
- garis tren khusus
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dalam diagram PowerPoint dengan Aspose.Slides untuk Android via Java secara cepat — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa tipe garis tren, termasuk eksponensial, linear, logaritmik, rata-rata bergerak, polinomial, dan daya.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**
Aspose.Slides for Android via Java menyediakan API sederhana untuk mengelola berbagai Garis Tren diagram:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default beserta tipe yang diinginkan (contoh ini menggunakan ChartType.ClusteredColumn).
4. Menambahkan garis tren eksponensial untuk seri diagram 1.
5. Menambahkan garis tren linear untuk seri diagram 1.
6. Menambahkan garis tren logaritmik untuk seri diagram 2.
7. Menambahkan garis tren rata-rata bergerak untuk seri diagram 2.
8. Menambahkan garis tren polinomial untuk seri diagram 3.
9. Menambahkan garis tren daya untuk seri diagram 3.
10. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Membuat diagram kolom terkonsentrasi
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Menambahkan garis tren eksponensial untuk seri diagram 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Menambahkan garis tren Linear untuk seri diagram 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Menambahkan garis tren Logaritmik untuk seri diagram 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Menambahkan garis tren MovingAverage untuk seri diagram 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Menambahkan garis tren Polinomial untuk seri diagram 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Menambahkan garis tren Power untuk seri diagram 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Menyimpan presentasi
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Garis Khusus**
Aspose.Slides for Android via Java menyediakan API sederhana untuk menambahkan garis khusus ke dalam diagram. Untuk menambahkan garis polos sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Buat diagram baru menggunakan metode AddChart yang disediakan oleh objek Shapes.
- Tambahkan AutoShape tipe Garis menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
- Atur Warna garis bentuk.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/id/androidjava/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/androidjava/create-shape-thumbnails/) itu sendiri.