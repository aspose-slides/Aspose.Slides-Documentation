---
title: Mengelola Penanda Data Diagram dalam Presentasi di Android
linktitle: Penanda Data
type: docs
url: /id/androidjava/chart-data-marker/
keywords:
- diagram
- titik data
- penanda
- opsi penanda
- ukuran penanda
- jenis isian
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan penanda data diagram di Aspose.Slides untuk Android, meningkatkan dampak presentasi pada format PPT dan PPTX dengan contoh kode Java yang jelas."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan penanda data diagram di Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, mengakses seri dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang telah diperbarui. Juga disebutkan bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan tampilan penanda dipertahankan saat mengekspor diagram ke format raster atau SVG.

## **Atur Opsi Penanda Diagram**
Penanda dapat diatur pada titik data diagram dalam seri tertentu. Untuk mengatur opsi penanda diagram, ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Membuat diagram default.
- Atur gambar.
- Ambil seri diagram pertama.
- Tambahkan titik data baru.
- Tulis presentasi ke disk.

Dalam contoh di bawah ini, kami telah mengatur opsi penanda diagram pada tingkat titik data.

```java
// Membuat presentasi kosong
Presentation pres = new Presentation();
try {
    // Akses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Membuat diagram default
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Mendapatkan indeks WorkSheet data diagram default
    int defaultWorksheetIndex = 0;
    
    // Mendapatkan WorkSheet data diagram
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Hapus seri demo
    chart.getChartData().getSeries().clear();
    
    // Tambah seri baru
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Muat gambar 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Muat gambar 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Ambil seri diagram pertama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Tambah titik baru (1:3) di sana.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Mengubah penanda seri diagram
    series.getMarker().setSize(15);
    
    // Simpan presentasi dengan diagram
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bentuk penanda apa saja yang tersedia secara bawaan?**

Bentuk standar tersedia (lingkaran, persegi, wajik, segitiga, dll.); daftarnya ditentukan oleh kelas [MarkerStyleType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/markerstyletype/). Jika Anda memerlukan bentuk non-standar, gunakan penanda dengan isian gambar untuk meniru visual kustom.

**Apakah penanda dipertahankan saat mengekspor diagram ke gambar atau SVG?**

Ya. Saat merender diagram ke [format raster](/slides/id/androidjava/convert-powerpoint-to-png/) atau menyimpan [bentuk sebagai SVG](/slides/id/androidjava/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilan dan pengaturannya, termasuk ukuran, isian, dan garis luar.