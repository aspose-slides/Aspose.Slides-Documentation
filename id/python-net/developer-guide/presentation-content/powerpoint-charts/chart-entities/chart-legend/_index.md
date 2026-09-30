---
title: Sesuaikan Legenda Diagram dalam Presentasi dengan Python
linktitle: Legenda Diagram
type: docs
url: /id/python-net/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk Python via .NET untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, memformat entri legenda individual, serta menyembunyikan atau mengembalikan entri yang dipilih.

FAQ mencakup perilaku terkait, termasuk memesan ruang untuk legenda, menampilkan label multilini, dan mewarisi format dari tema presentasi.

## **Penempatan Legenda**

Gunakan properti legenda [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), dan [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) untuk menentukan posisi dan ukuran sebagai pecahan dari dimensi diagram.

Contoh ini membuat presentasi dan menambahkan diagram kolom berkelompok dengan data default ke slide pertama. Membagi offset dan dimensi legenda yang diinginkan dengan lebar serta tinggi diagram mengubahnya menjadi nilai relatif: legenda di-offset 50 poin dari sudut kiri‑atas diagram dan berukuran 100 × 100 poin.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Ekspresikan posisi dan ukuran legenda relatif terhadap diagram.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Ukuran Font Legenda**

Gunakan [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) legenda untuk mengakses pemformatan teksnya dan atur [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) dalam poin.

Contoh ini membuat diagram dengan data default dan mengatur teks legenda menjadi 20 poin. Contoh ini juga menonaktifkan batas otomatis untuk sumbu vertikal dan mengatur rentangnya menjadi –5 sampai 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Ukuran Font Entri Legenda Individual**

Gunakan koleksi [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) legenda untuk mengakses pemformatan entri tertentu. Indeks entri dimulai dari nol, jadi indeks `1` mengacu pada entri kedua.

Contoh ini membuat diagram kolom berkelompok yang data defaultnya mencakup setidaknya dua seri. Ia memformat entri legenda kedua dengan teks tebal, miring, berwarna biru, dan ukuran 20 poin.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyembunyikan Entri Legenda Individual**

Untuk mengecualikan seri tambahan dari legenda sekaligus tetap menampilkan datanya, atur [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) menjadi `True` melalui [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Ini hanya menyembunyikan entri legenda yang dipilih; tidak menghapus seri atau titik datanya. Menetapkan [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) menjadi `False`, sebaliknya, menyembunyikan seluruh legenda.

Contoh di bawah ini membuat diagram kolom berkelompok dengan beberapa seri menggunakan data default. Ia menyembunyikan entri legenda seri kedua (indeks `1`) dan menyimpan presentasi. Kemudian ia mengembalikan entri tersebut dengan mengatur [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) menjadi `False` dan menyimpan salinan kedua. Kolom tetap terlihat di kedua file.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Pulihkan entri yang sama tanpa mengubah data diagram.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Perbandingan di bawah ini menampilkan diagram yang sama dengan semua entri terlihat dan dengan entri kedua disembunyikan. Kolom seri kedua tetap tidak berubah.

![Perbandingan diagram dengan semua entri legenda terlihat dan dengan Seri 2 disembunyikan dari legenda; semua kolom tetap terlihat.](hide-legend-entry.png)

Dalam diagram kolom, batang, dan garis, entri legenda mengidentifikasi seri. Pada diagram pai, mereka mengidentifikasi titik data individual (irisan), jadi gunakan [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) pada irisan yang dipilih. API mendokumentasikan properti titik data ini untuk tipe diagram `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE`, dan `BAR_OF_PIE`. Jangan mengasumsikan bahwa ini berlaku untuk diagram donat, yang tidak termasuk dalam daftar tersebut.

## **FAQ**

**Apakah saya dapat membuat diagram menyediakan ruang untuk legenda alih‑alih menimpanya?**

Ya. Atur [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) menjadi `False` untuk memesan ruang bagi legenda alih‑alih membiarkannya menumpuk area plot.

**Apakah saya dapat membuat label legenda multiline?**

Ya. Label panjang dapat terbungkus ketika lebar yang tersedia tidak cukup. Anda juga dapat menggunakan karakter baris baru dalam nama seri untuk meminta pemisahan baris.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Biarkan warna, isian, dan font legenda tidak diatur sehingga dapat mewarisi format tema. Pemformatan eksplisit akan menimpa pengaturan tema yang bersesuaian.