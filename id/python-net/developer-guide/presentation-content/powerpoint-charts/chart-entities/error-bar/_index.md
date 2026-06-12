---
title: Sesuaikan Batang Kesalahan dalam Bagan Presentasi dengan Python
linktitle: Batang Kesalahan
type: docs
url: /id/python-net/error-bar/
keywords:
- batang kesalahan
- nilai khusus
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan menyesuaikan batang kesalahan dalam bagan dengan Aspose.Slides untuk Python via .NET—optimalkan visualisasi data dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan batang kesalahan dalam bagan presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara menambahkan batang kesalahan ke seri bagan, mengonfigurasi pengaturan batang kesalahan X dan Y, serta menerapkan berbagai tipe nilai seperti tetap, persentase, dan nilai khusus.

Artikel ini juga mendemonstrasikan cara menetapkan nilai batang kesalahan khusus untuk titik data individu dalam sebuah seri dengan menggunakan koleksi titik data yang bersesuaian. Selain itu, artikel ini mencakup catatan singkat tentang cara batang kesalahan berperilaku selama ekspor, kompatibilitasnya dengan penanda dan label data, serta di mana menemukan kelas dan enum referensi API yang terkait.

## **Menambahkan Batang Kesalahan**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengelola nilai batang kesalahan. Kode contoh berlaku saat menggunakan tipe nilai khusus. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Tambahkan bagan gelembung pada slide yang diinginkan.
1. Akses seri bagan pertama dan atur format batang kesalahan X.
1. Akses seri bagan pertama dan atur format batang kesalahan Y.
1. Menetapkan nilai batang dan formatnya.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Membuat presentasi kosong
with slides.Presentation() as presentation:
    # Membuat bagan gelembung
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Menambahkan batang kesalahan dan mengatur formatnya
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Menyimpan presentasi
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menambahkan Nilai Batang Kesalahan Khusus**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengelola nilai batang kesalahan khusus. Kode contoh berlaku ketika properti **IErrorBarsFormat.ValueType** bernilai **Custom**. Untuk menentukan nilai, gunakan properti **ErrorBarCustomValues** dari titik data tertentu dalam koleksi **DataPoints** pada seri:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Tambahkan bagan gelembung pada slide yang diinginkan.
1. Akses seri bagan pertama dan atur format batang kesalahan X.
1. Akses seri bagan pertama dan atur format batang kesalahan Y.
1. Akses titik data individu pada seri bagan dan atur nilai Batang Kesalahan untuk setiap titik data seri.
1. Menetapkan nilai batang dan formatnya.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Membuat presentasi kosong
with slides.Presentation() as presentation:
    # Membuat bagan gelembung
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Menambahkan batang kesalahan khusus dan mengatur formatnya
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Mengakses titik data seri bagan dan mengatur nilai batang kesalahan untuk titik individu
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Mengatur batang kesalahan untuk titik-titik seri bagan
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Menyimpan presentasi
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa yang terjadi pada batang kesalahan saat mengekspor presentasi ke PDF atau gambar?**

Mereka dirender sebagai bagian dari bagan dan dipertahankan selama konversi bersama dengan format bagan lainnya, dengan asumsi versi atau perender yang kompatibel.

**Apakah batang kesalahan dapat digabungkan dengan penanda dan label data?**

Ya. Batang kesalahan adalah elemen terpisah dan kompatibel dengan penanda serta label data; jika elemen saling bertumpuk, Anda mungkin perlu menyesuaikan formatnya.

**Di mana saya dapat menemukan daftar properti dan enum untuk bekerja dengan batang kesalahan dalam API?**

Di referensi API: kelas [ErrorBarsFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/errorbarsformat/) dan enum terkait [ErrorBarType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/errorbartype/) serta [ErrorBarValueType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/errorbarvaluetype/).