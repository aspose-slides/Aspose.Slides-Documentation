---
title: Sesuaikan Grafik 3D dalam Presentasi dengan Python
linktitle: Grafik 3D
type: docs
url: /id/python-net/3d-chart/
keywords:
- grafik 3d
- rotasi
- kedalaman
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan grafik 3-D di Aspose.Slides untuk Python via .NET, dengan dukungan file PPT, PPTX, dan ODP—tingkatkan presentasi Anda hari ini."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan grafik 3D di Aspose.Slides dengan mengonfigurasi pengaturan `rotation_3d` seperti `rotation_x`, `rotation_y`, `depth_percents`, dan `right_angle_axes`. Artikel ini memandu pembuatan presentasi, menambahkan grafik 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur properti RotationX, RotationY, dan DepthPercents pada Grafik 3D**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengatur properti ini. Artikel berikut akan membantu Anda cara mengatur berbagai properti seperti Rotasi X, Y, **DepthPercents**, dll. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan grafik dengan data default.
1. Atur properti Rotation3D.
1. Tuliskan presentasi yang dimodifikasi ke file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Buat sebuah instance dari kelas Presentation
    with slides.Presentation() as presentation:
            
    # Akses slide pertama
    slide = presentation.slides[0]

    # Tambahkan chart dengan data default
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Mengatur indeks lembar data chart
    defaultWorksheetIndex = 0

    # Mendapatkan lembar kerja data chart
    fact = chart.chart_data.chart_data_workbook

    # Tambahkan seri
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Tambahkan Kategori
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Atur properti Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Ambil seri chart kedua
    series = chart.chart_data.series[1]

    # Sekarang mengisi data seri
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Atur nilai OverLap
    series.parent_series_group.overlap = 100         

    # Simpan presentasi ke disk
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jenis grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui enumerasi [ChartType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor grafik ke gambar melalui [chart API](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/get_image/) atau [render seluruh slide](/slides/id/python-net/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda membutuhkan pratinjau pixel‑perfect atau ingin menyematkan grafik ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan rendering grafik 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, minimalkan efek 3D, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) agar cocok dengan tampilan atau kebutuhan cetak target.