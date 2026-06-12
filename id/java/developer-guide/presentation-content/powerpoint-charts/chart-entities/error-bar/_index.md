---
title: Sesuaikan Batang Kesalahan dalam Diagram Presentasi Menggunakan Java
linktitle: Batang Kesalahan
type: docs
url: /id/java/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang kesalahan dalam diagram dengan Aspose.Slides for Java—optimalkan visualisasi data dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan pada diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan batang kesalahan ke serangkaian diagram, mengonfigurasi pengaturan batang kesalahan X dan Y, serta menerapkan berbagai tipe nilai seperti tetap, persentase, dan nilai khusus.

Ini juga mendemonstrasikan cara menetapkan nilai batang kesalahan khusus untuk titik data individual dalam sebuah seri dengan menggunakan koleksi titik data yang bersangkutan. Selain itu, artikel ini mencakup catatan singkat tentang bagaimana batang kesalahan berperilaku saat diekspor, kompatibilitasnya dengan penanda dan label data, serta di mana menemukan kelas dan enum referensi API yang terkait.

## **Menambahkan Batang Kesalahan**
Aspose.Slides for Java menyediakan API sederhana untuk mengelola nilai batang kesalahan. Kode contoh berlaku saat menggunakan tipe nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesCollection) pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Tambahkan diagram gelembung pada slide yang diinginkan.
3. Akses seri diagram pertama dan atur format batang kesalahan X.
4. Akses seri diagram pertama dan atur format batang kesalahan Y.
5. Mengatur nilai batang dan formatnya.
6. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Membuat diagram gelembung
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Menambahkan batang kesalahan dan mengatur formatnya
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Menyimpan presentasi
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Nilai Batang Kesalahan Khusus**
Aspose.Slides for Java menyediakan API sederhana untuk mengelola nilai batang kesalahan khusus. Kode contoh berlaku ketika properti [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IErrorBarsFormat#getValue--) sama dengan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartSeriesCollection) pada seri:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Tambahkan diagram gelembung pada slide yang diinginkan.
3. Akses seri diagram pertama dan atur format batang kesalahan X.
4. Akses seri diagram pertama dan atur format batang kesalahan Y.
5. Akses titik data individual pada seri diagram dan atur nilai Batang Kesalahan untuk titik data seri masing‑masing.
6. Mengatur nilai batang dan formatnya.
7. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```java
// Buat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Membuat diagram gelembung
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Menambahkan batang Kesalahan khusus dan mengatur formatnya
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Mengakses titik data seri diagram dan mengatur nilai batang kesalahan untuk
    // titik individual
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Mengatur batang kesalahan untuk titik seri diagram
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Menyimpan presentasi
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa yang terjadi pada batang kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan format diagram lainnya, dengan asumsi versi atau renderer yang kompatibel.

**Apakah batang kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Batang kesalahan merupakan elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan formatnya.

**Di mana saya dapat menemukan daftar properti dan kelas untuk bekerja dengan batang kesalahan di API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/errorbarsformat/) dan kelas terkait [ErrorBarType](https://reference.aspose.com/slides/id/java/com.aspose.slides/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/java/com.aspose.slides/errorbarvaluetype/).