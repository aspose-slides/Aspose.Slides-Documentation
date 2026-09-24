---
title: Sesuaikan Tabel Data Diagram pada Presentasi dengan Python
linktitle: Tabel Data
type: docs
url: /id/python-net/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Sesuaikan font, batas, dan kunci legenda tabel data diagram dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET memungkinkan Anda menampilkan tabel data diagram dan menyesuaikan pemformatan teks, batas, serta kunci legenda. Artikel ini menjelaskan cara mengaktifkan tabel, memformat teksnya, mengontrol setiap jenis batas, dan menampilkan atau menyembunyikan kunci legenda. Contoh-contohnya menyimpan diagram yang dikonfigurasi dalam file PPTX.

## **Mengatur Properti Font**

Untuk menampilkan tabel data diagram, setel [has_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/) ke `True`. Gunakan [chart_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data_table/) untuk mengakses tabel dan mengonfigurasi pemformatan teksnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Tambahkan diagram kolom berkelompok ke slide pertama.
1. Aktifkan tabel data diagram.
1. Aktifkan teks tebal dengan [font_bold](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/font_bold/) dan setel [font_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseportionformat/font_height/) ke `20` untuk teks berukuran 20 poin.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memerlukan file `test.pptx` di direktori kerja dengan setidaknya satu slide. Ia menambahkan diagram dengan data default pada posisi (50, 50), dengan lebar 600 poin dan tinggi 400 poin. File `output.pptx` yang disimpan berisi diagram dengan tabel datanya diaktifkan dan pengaturan font yang ditentukan diterapkan.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sesuaikan Batas Tabel Data**

Aktifkan tabel dengan [Chart.has_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/) dan akses melalui [Chart.chart_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data_table/). Anda dapat mengontrol tiga jenis batas secara terpisah:

- [has_border_horizontal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/has_border_horizontal/) mengontrol batas sel horizontal.
- [has_border_vertical](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/has_border_vertical/) mengontrol batas sel vertikal.
- [has_border_outline](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/has_border_outline/) mengontrol batas luar tabel.

Setel setiap properti ke `True` untuk menampilkan batasnya atau `False` untuk menyembunyikannya. Contoh berikut membuat diagram kolom berkelompok dengan data default, menampilkan batas horizontal dan batas luar, serta menyembunyikan batas vertikal. Tidak memerlukan file input. Posisi dan ukuran diagram ditentukan dalam poin.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Perbandingan di bawah menggunakan data diagram yang sama dan pengaturan kunci legenda yang sama dalam semua empat kasus. Dimulai dengan semua batas diaktifkan, setiap varian yang tersisa menonaktifkan satu properti batas saja. Varian kiri‑bawah mencocokkan pengaturan batas pada contoh.

![Diagram tabel data dengan semua batas diaktifkan, tanpa batas horizontal, tanpa batas vertikal, dan tanpa batas luar](data-table-borders.png)

## **Tampilkan atau Sembunyikan Kunci Legenda**

Kunci legenda adalah penanda berwarna kecil di sebelah nama seri dalam tabel data. Mereka membantu pembaca mencocokkan setiap baris tabel dengan seri diagram. Setel [show_legend_key](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/show_legend_key/) ke `True` untuk menampilkan penanda ini atau `False` untuk menyembunyikannya.

Leganda terpisah diagram dikontrol oleh [Chart.has_legend](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_legend/). Pengaturan ini bersifat independen: menyembunyikan legenda terpisah tidak menyembunyikan kunci di dalam tabel data, dan menyembunyikan kunci tabel tidak menyembunyikan legenda terpisah.

Contoh berikut membuat diagram dengan data default, mengaktifkan tabel datanya, dan menampilkan kunci legenda di dalamnya sekaligus menyembunyikan legenda terpisah. Semua batas tabel diaktifkan secara eksplisit. Tidak memerlukan presentasi input. Untuk menyembunyikan hanya kunci tabel, ubah `data_table.show_legend_key` menjadi `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Perbandingan di bawah menunjukkan tabel yang sama dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan. Semua batas tetap diaktifkan, dan legenda diagram terpisah disembunyikan dalam kedua kasus.

![Diagram tabel data dengan kunci legenda ditampilkan di kiri dan disembunyikan di kanan](data-table-legend-keys.png)

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda dalam tabel data diagram?**

Ya. Setel [show_legend_key](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/show_legend_key/) ke `True` untuk menampilkan kunci legenda atau ke `False` untuk menyembunyikannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram dan tabel data yang ditampilkan sebagai bagian dari slide saat mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), atau [images](/slides/id/python-net/convert-powerpoint-to-png/).

**Apakah saya dapat bekerja dengan tabel data dalam diagram yang dimuat dari templat?**

Ya. Untuk diagram yang dimuat dari presentasi atau templat yang ada, gunakan [has_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/) untuk memeriksa atau mengubah apakah tabel datanya ditampilkan.

**Bagaimana cara menemukan diagram yang memiliki tabel data diaktifkan?**

Iterasi melalui shape pada setiap slide, identifikasi diagramnya, dan periksa properti [has_data_table](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/). Nilai `True` menunjukkan bahwa tabel data diaktifkan.