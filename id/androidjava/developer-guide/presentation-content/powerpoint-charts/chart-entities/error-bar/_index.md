---
title: Sesuaikan Bar Kesalahan pada Diagram Presentasi di Android
linktitle: Bar Kesalahan
type: docs
url: /id/androidjava/error-bar/
keywords:
- bar kesalahan
- nilai khusus
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan bar kesalahan dalam diagram dengan Aspose.Slides untuk Android via Java—optimalkan visualisasi data dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bar kesalahan dalam diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan bar kesalahan ke seri diagram, mengonfigurasi pengaturan bar kesalahan X dan Y, serta menerapkan tipe nilai yang berbeda seperti nilai tetap, persentase, dan nilai khusus.

Ini juga mendemonstrasikan cara menetapkan nilai bar kesalahan khusus untuk titik data individu dalam sebuah seri dengan menggunakan koleksi titik data yang bersangkutan. Selain itu, artikel ini mencakup catatan singkat tentang cara bar kesalahan berperilaku selama ekspor, kompatibilitasnya dengan penanda dan label data, serta dimana menemukan kelas dan enum referensi API yang terkait.

## **Menambahkan Bar Kesalahan**
Aspose.Slides for Android via Java menyediakan API sederhana untuk mengelola nilai bar kesalahan. Kode contoh berlaku ketika menggunakan tipe nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesCollection) pada seri:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Tambahkan diagram gelembung pada slide yang diinginkan.
3. Akses seri diagram pertama dan atur format bar kesalahan X.
4. Akses seri diagram pertama dan atur format bar kesalahan Y.
5. Atur nilai bar dan formatnya.
6. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```java
// Membuat instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Membuat diagram gelembung
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Menambahkan bar kesalahan dan mengatur formatnya
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

## **Menambahkan Nilai Bar Kesalahan Khusus**
Aspose.Slides for Android via Java menyediakan API sederhana untuk mengelola nilai bar kesalahan khusus. Kode contoh berlaku ketika properti [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) sama dengan **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartSeriesCollection) pada seri:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Tambahkan diagram gelembung pada slide yang diinginkan.
3. Akses seri diagram pertama dan atur format bar kesalahan X.
4. Akses seri diagram pertama dan atur format bar kesalahan Y.
5. Akses titik data individual pada seri diagram dan atur nilai Bar Kesalahan untuk tiap titik data seri.
6. Atur nilai bar dan formatnya.
7. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```java
// Membuat instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Membuat diagram gelembung
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Menambahkan bar kesalahan khusus dan mengatur formatnya
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Mengakses titik data seri diagram dan mengatur nilai bar kesalahan untuk
    // titik individual
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Mengatur bar kesalahan untuk titik-titik seri diagram
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

**Apa yang terjadi pada bar kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Bar kesalahan dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan format diagram lainnya, dengan asumsi versi atau renderer yang kompatibel.

**Apakah bar kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Bar kesalahan merupakan elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan format.

**Di mana saya dapat menemukan daftar properti dan kelas untuk bekerja dengan bar kesalahan dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/errorbarsformat/) dan kelas terkait [ErrorBarType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/errorbarvaluetype/).