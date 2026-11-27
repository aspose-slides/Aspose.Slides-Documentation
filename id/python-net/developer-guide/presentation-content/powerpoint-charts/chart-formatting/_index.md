---
title: Format Grafik dalam Presentasi Menggunakan Python
linktitle: Pemformatan Grafik
type: docs
weight: 60
url: /id/python-net/chart-formatting/
keywords:
- format grafik
- pemformatan grafik
- entitas grafik
- properti grafik
- pengaturan grafik
- opsi grafik
- properti font
- border melengkung
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari pemformatan grafik di Aspose.Slides untuk Python via .NET dan tingkatkan presentasi PowerPoint Anda dengan sumbu khusus, font, format angka, serta border grafik yang melengkung."
---
## **Ikhtisar**

Artikel ini menjelaskan cara memformat grafik dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen penting grafik seperti sumbu, garis kisi, judul, legenda, area plot, dan isian dinding untuk meningkatkan tampilan dan keterbacaan data grafik.

Artikel ini juga memperlihatkan cara mengatur properti font untuk teks grafik, menerapkan format angka bawaan pada data grafik, dan mengaktifkan sudut melengkung untuk area grafik. Bersama-sama, contoh‑contoh ini menunjukkan cara mengontrol gaya visual maupun penyajian data grafik dalam sebuah presentasi.

Untuk isian dan outline terpisah pada interval naik dan turun, lihat [contoh grafik saham](/slides/id/python-net/create-chart/#create-stock-charts).

## **Format Entitas Grafik**

Gunakan [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) untuk memformat judul grafik, sumbu, garis kisi, legenda, dan area plot. Contoh ini membuat grafik garis dengan penanda dan data default, kemudian menerapkan gaya teks dan garis terpisah pada sumbu nilai dan sumbu kategori. Ukuran font dan lebar garis ditentukan dalam poin; label kategori diputar 45 derajat.

Sumbu nilai menggunakan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) secara independen dari sel sumber. Skala berjalan dari -2 hingga 15, dengan interval utama 2 dan interval minor 0,5. Contoh ini juga menggabungkan format persentase dengan [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) yang diset ke ribuan, sehingga Anda dapat menyesuaikan pengaturan ini dengan arti dan besaran data Anda. Legenda tetap berada di luar area plot karena [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) dinonaktifkan. Isian back‑wall dan floor dikonfigurasi melalui [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) dan [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), tetapi permukaan ini hanya terlihat pada grafik 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Properti Font untuk Grafik**

Atur ukuran font default untuk teks grafik melalui [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Contoh ini membuat grafik kolom berklaster dengan font 20 poin dan mengaktifkan label nilai untuk seri pertama melalui [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Elemen teks dengan pengaturan font eksplisitnya dapat menimpa nilai default grafik.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Gunakan Kembali Pemformatan Bingkai Teks untuk Legenda Grafik**

Agar legenda cocok dengan judul slide, atur font melalui [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) pada paragraf pertama judul. Panggil [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) pada [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) legenda. Metode ini menyalin pengaturan bingkai teks, format paragraf pertama, dan properti font default paragraf tersebut. Pemformatan yang diterapkan langsung pada bagian individual atau pada paragraf berikutnya tetap bersifat lokal pada sumbernya.

Contoh menggunakan judul tebal, warna navy, 26 poin Calibri sebagai templat. Setelah menata legenda, contoh menggunakan [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) untuk menerapkan pemformatan yang sama pada keterangan terpisah.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Pada presentasi yang disimpan, legenda dan keterangan cocok dengan judul dalam ukuran, bobot, dan warna. Legenda tetap menampilkan nama seri, dan keterangan mempertahankan teksnya sendiri. Jika suatu bagian dalam keterangan sudah memiliki ukuran font eksplisit, ukuran tersebut akan mengambil prioritas dibandingkan default paragraf yang disalin.

| Sebelum menyalin | Setelah menyalin |
| --- | --- |
| ![Grafik penjualan kuartalan dengan label legenda hitam biasa dan keterangan hitam](legend-formatting-before.png) | ![Grafik yang sama dengan label legenda navy tebal lebih besar dan keterangan yang cocok](legend-formatting.png) |

## **Atur Format Numerik**

Gunakan [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) untuk menerapkan format angka bawaan pada sel workbook grafik. Contoh ini membuat grafik kolom berklaster dengan data default yang didukung sel, dan menerapkan indeks format 10 (`0.00%`) pada setiap sel nilai seri. Ini mengubah cara nilai ditampilkan di workbook tanpa mengubah angka dasarnya; misalnya, 0,25 akan ditampilkan sebagai 25,00 %. Format sumbu dan label data dapat dikonfigurasi secara terpisah.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Tabel berikut menyajikan indeks format angka bawaan beserta contoh format Excel untuk locale English (United States). String format dan tampilan sebenarnya dapat berbeda antar aplikasi dan locale, terutama untuk mata uang dan tanggal. Beberapa format Excel juga berbeda dari default standar OOXML, sebagaimana dijelaskan dalam [catatan implementasi format angka Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Atur Sudut Membulat pada Area Grafik**

Aktifkan [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) untuk membuat sudut area grafik menjadi melengkung. Contoh ini membuat grafik kolom berklaster dan menggunakan [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) untuk memberi outline warna abu‑abu solid dengan gaya satu‑garis sebelum menyimpan presentasi.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Edit Anotasi Grafik yang Ada**

Sebuah grafik dapat berisi bentuk khusus, seperti anotasi teks yang menjelaskan status laporan. Akses bentuk‑bentuk ini melalui [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Koleksi [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑nya berisi bentuk‑bentuk yang dimiliki grafik.

Kotak teks biasa yang ditempatkan di atas grafik merupakan bagian slide, meskipun tampak seperti bagian grafik. Menelusuri [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) menemukan grafik serta bentuk slide biasa, tetapi tidak mengenumerasi bentuk individual di dalam grafik. Judul grafik dan label data adalah elemen grafik terpisah, bukan anotasi khusus dalam koleksi ini.

Unduh [chart-annotations.pptx](chart-annotations.pptx) dan letakkan di direktori kerja aplikasi. Slide pertama berisi grafik dengan anotasi tidak berkelompok yang berisi teks "Preliminary results", sebuah garis milik grafik, dan kotak teks slide biasa yang berisi "Slide overlay". Contoh menemukan grafik pertama pada slide tersebut dan mengubah anotasi menjadi "Final results" ketika laporan siap dipublikasikan. Contoh memeriksa apakah koleksi kosong dan hanya mengedit sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dengan [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) yang tidak `None` serta berisi teks yang diharapkan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Garis dan kotak teks slide tetap tidak berubah. Gambar berikut menampilkan input dan hasil yang disimpan serta dibuka kembali:

| Sebelum edit | Setelah edit |
| --- | --- |
| ![Anotasi grafik berisi teks Preliminary results](chart-annotations-before.png) | ![Anotasi grafik berisi teks Final results](chart-annotations-after.png) |

{{% alert color="info" title="Catatan" %}}
Contoh hanya memeriksa bentuk‑bentuk tingkat atas yang dimiliki grafik. Jika anotasi berada di dalam sebuah [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), periksa koleksi [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) grup tersebut juga. Lakukan proses ini secara rekursif untuk grup bersarang, menerapkan pemeriksaan teks yang sama pada bentuk anak mereka. Sebuah grup sendiri adalah kontainer; jangan perlakukan sebagai kotak teks.
{{% /alert %}}

## **FAQ**

**Apakah saya dapat menetapkan isian semi‑transparan untuk kolom/area sambil menjaga batas tetap opak?**

Ya. Transparansi isian dan outline dapat dikonfigurasi secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana cara menangani label data yang saling tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya, kategori), sesuaikan posisi label, tampilkan label hanya untuk titik terpilih bila perlu, atau ubah format menjadi "nilai + legenda".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Seri mendukung isian solid, gradien, dan pola. Pada praktiknya, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.