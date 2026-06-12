---
title: Kelola Penanda Data Grafik dalam Presentasi dengan Python
linktitle: Penanda Data
type: docs
url: /id/python-net/chart-data-marker/
keywords:
- grafik
- titik data
- penanda
- opsi penanda
- ukuran penanda
- tipe isian
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menyesuaikan penanda data grafik di Aspose.Slides, meningkatkan dampak presentasi pada format PPT, PPTX, dan ODP dengan contoh kode yang jelas."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan penanda data grafik di Aspose.Slides. Menunjukkan cara membuat grafik, mengakses serangkaian data dan titik datanya, menerapkan isian gambar pada penanda di tingkat titik data, menyesuaikan ukuran penanda, dan menyimpan presentasi yang telah diperbarui. Juga dicatat bahwa bentuk penanda standar tersedia melalui enumerasi `MarkerStyleType` dan tampilan penanda dipertahankan saat mengekspor grafik ke format raster atau SVG.

## **Atur Opsi Penanda Grafik**
Penanda dapat diatur pada titik data grafik dalam seri tertentu. Untuk mengatur opsi penanda grafik, ikuti langkah-langkah berikut:

- Membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
- Membuat grafik default.
- Mengatur gambar.
- Mengambil seri grafik pertama.
- Menambahkan titik data baru.
- Menulis presentasi ke disk.

Pada contoh di bawah ini, kami telah mengatur opsi penanda grafik pada tingkat titik data.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Buat instance kelas Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Membuat grafik default
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Mendapatkan indeks lembar kerja data grafik default
    defaultWorksheetIndex = 0

    # Mendapatkan lembar kerja data grafik
    fact = chart.chart_data.chart_data_workbook

    # Hapus seri demo
    chart.chart_data.series.clear()

    # Tambahkan seri baru
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Atur gambar
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Atur gambar
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Ambil seri grafik pertama
    series = chart.chart_data.series[0]

    # Tambahkan titik baru (1:3) di sana.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Mengubah penanda seri grafik
    series.marker.size = 15

    # Simpan presentasi ke disk
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bentuk penanda apa yang tersedia secara bawaan?**

Bentuk standar tersedia (lingkaran, persegi, belah ketupat, segitiga, dll.); daftar tersebut didefinisikan oleh enumerasi [MarkerStyleType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/markerstyletype/). Jika Anda membutuhkan bentuk yang tidak standar, gunakan penanda dengan isian gambar untuk meniru visual khusus.

**Apakah penanda dipertahankan saat mengekspor grafik ke gambar atau SVG?**

Ya. Saat merender grafik ke [format raster](/slides/id/python-net/convert-powerpoint-to-png/) atau menyimpan [bentuk sebagai SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/), penanda mempertahankan tampilannya dan pengaturannya, termasuk ukuran, isian, dan garis tepi.