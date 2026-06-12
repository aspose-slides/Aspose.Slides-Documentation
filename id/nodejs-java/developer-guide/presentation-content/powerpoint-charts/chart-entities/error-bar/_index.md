---
title: Kustomisasi Batang Kesalahan dalam Diagram Presentasi Menggunakan JavaScript
linktitle: Batang Kesalahan
type: docs
url: /id/nodejs-java/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang kesalahan dalam diagram dengan JavaScript dan Aspose.Slides untuk Node.js via Java—optimalkan visual data dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan dalam diagram presentasi menggunakan Aspose.Slides. Ini menunjukkan cara menambahkan batang kesalahan ke seri diagram, mengonfigurasi pengaturan batang kesalahan X dan Y, serta menerapkan berbagai jenis nilai seperti tetap, persentase, dan nilai khusus.

Artikel ini juga mendemonstrasikan cara menetapkan nilai batang kesalahan khusus untuk titik data individual dalam sebuah seri dengan menggunakan koleksi titik data yang bersangkutan. Selain itu, artikel ini menyertakan catatan singkat tentang cara batang kesalahan berperilaku saat ekspor, kompatibilitasnya dengan penanda dan label data, serta di mana menemukan kelas referensi API dan enum yang terkait.

## **Tambah Batang Kesalahan**

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengelola nilai batang kesalahan. Kode contoh berlaku ketika menggunakan jenis nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesCollection) seri:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format batang kesalahan X.
1. Akses seri diagram pertama dan atur format batang kesalahan Y.
1. Mengatur nilai batang dan format.
1. Tulis presentasi yang dimodifikasi ke file PPTX.

```javascript
// Membuat instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Membuat diagram gelembung
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Menambahkan Batang Kesalahan dan mengatur formatnya
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Menyimpan presentasi
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tambah Nilai Batang Kesalahan Kustom**

Aspose.Slides for Node.js via Java menyediakan API sederhana untuk mengelola nilai batang kesalahan kustom. Kode contoh berlaku ketika properti [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) bernilai **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi [**DataPoints**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ChartSeriesCollection) seri:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Tambahkan diagram gelembung pada slide yang diinginkan.
1. Akses seri diagram pertama dan atur format batang kesalahan X.
1. Akses seri diagram pertama dan atur format batang kesalahan Y.
1. Akses titik data individual seri diagram dan atur nilai Batang Kesalahan untuk titik data seri individual.
1. Mengatur nilai batang dan format.
1. Tulis presentasi yang dimodifikasi ke file PPTX.

```javascript
// Buat instance dari kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Membuat diagram gelembung
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Menambahkan Batang Kesalahan kustom dan mengatur formatnya
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Mengakses titik data seri diagram dan mengatur nilai batang kesalahan untuk
    // titik individual
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Mengatur batang kesalahan untuk titik seri diagram
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Menyimpan presentasi
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apa yang terjadi pada batang kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari diagram dan dipertahankan selama konversi bersama dengan format diagram lainnya, dengan asumsi versi atau renderer yang kompatibel.

**Apakah batang kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Batang kesalahan adalah elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling tumpang tindih, Anda mungkin perlu menyesuaikan format.

**Di mana saya dapat menemukan daftar properti dan enum untuk bekerja dengan batang kesalahan dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/errorbarsformat/) dan enum terkait [ErrorBarType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/errorbarvaluetype/).