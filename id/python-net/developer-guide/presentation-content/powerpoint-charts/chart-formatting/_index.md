---
title: Format Diagram dalam Presentasi menggunakan Python
linktitle: Pemformatan Diagram
type: docs
weight: 60
url: /id/python-net/chart-formatting/
keywords:
- format diagram
- pemformatan diagram
- entitas diagram
- properti diagram
- pengaturan diagram
- opsi diagram
- properti font
- pinggiran bulat
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari pemformatan diagram di Aspose.Slides untuk Python via .NET dan tingkatkan presentasi PowerPoint atau OpenDocument Anda dengan gaya profesional yang menarik perhatian."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat diagram dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen diagram utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isi dinding untuk meningkatkan tampilan dan keterbacaan data diagram.

Artikel ini juga memperagakan cara mengatur properti font untuk teks diagram, menerapkan format numerik preset dan kustom pada data diagram, serta mengaktifkan sudut bulat untuk area diagram. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan gaya visual dan presentasi data diagram dalam sebuah presentasi.

## **Format Elemen Diagram**

Aspose.Slides for Python memungkinkan pengembang menambahkan diagram kustom ke slide dari awal. Bagian ini menjelaskan cara memformat berbagai elemen diagram, termasuk sumbu kategori dan sumbu nilai.

Aspose.Slides menyediakan API sederhana untuk mengelola elemen diagram dan menerapkan pemformatan kustom:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default dari tipe yang diinginkan (dalam contoh ini, `ChartType.LINE_WITH_MARKERS`).
1. Akses sumbu nilai diagram dan atur hal-hal berikut:
   1. Atur **line format** untuk garis kisi utama sumbu nilai.
   1. Atur **line format** untuk garis kisi minor sumbu nilai.
   1. Atur **number format** untuk sumbu nilai.
   1. Atur **min, max, major, and minor units** untuk sumbu nilai.
   1. Atur **text properties** untuk label sumbu nilai.
   1. Atur **title** untuk sumbu nilai.
   1. Atur **line format** untuk sumbu nilai.
1. Akses sumbu kategori diagram dan atur hal-hal berikut:
   1. Atur **line format** untuk garis kisi utama sumbu kategori.
   1. Atur **line format** untuk garis kisi minor sumbu kategori.
   1. Atur **text properties** untuk label sumbu kategori.
   1. Atur **title** untuk sumbu kategori.
   1. Atur **label positioning** untuk sumbu kategori.
   1. Atur **rotation angle** untuk label sumbu kategori.
1. Akses legenda diagram dan atur **text properties**-nya.
1. Tampilkan legenda diagram tanpa menumpuk diagram.
1. Akses **secondary value axis** diagram dan atur hal-hal berikut:
   1. Aktifkan **value axis** sekunder.
   1. Atur **line format** untuk **value axis** sekunder.
   1. Atur **number format** untuk **value axis** sekunder.
   1. Atur **min, max, major, and minor units** untuk **value axis** sekunder.
1. Plot seri diagram pertama pada **value axis** sekunder.
1. Atur warna isi dinding belakang diagram.
1. Atur warna isi area plot diagram.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan diagram contoh.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Atur judul diagram.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Atur format garis kisi utama untuk sumbu nilai.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Atur format garis kisi minor untuk sumbu nilai.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Atur format angka sumbu nilai.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Atur nilai maksimum, minimum, satuan utama, dan satuan minor sumbu nilai.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Atur properti teks sumbu nilai.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Atur judul sumbu nilai.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Atur format garis kisi utama untuk sumbu kategori.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Atur format garis kisi minor untuk sumbu kategori.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Atur properti teks sumbu kategori.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Atur judul sumbu kategori.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Atur posisi label sumbu kategori.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Atur sudut rotasi label sumbu kategori.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Atur properti teks legenda.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Tampilkan legenda diagram yang menumpuk diagram.
    chart.legend.overlay = True
                
    # Atur warna dinding belakang diagram.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Atur warna area plot.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Simpan presentasi.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Properti Font Diagram**

Aspose.Slides for Python mendukung pengaturan properti terkait font untuk diagram. Ikuti langkah-langkah di bawah ini untuk mengonfigurasi properti font diagram:

1. Instansiasi objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Tambahkan diagram ke slide.
1. Atur tinggi font.
1. Simpan presentasi yang telah dimodifikasi.

Contoh kode disediakan di bawah.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Format Numerik**

Aspose.Slides for Python menyediakan API sederhana untuk mengelola format data diagram:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default dari tipe apa pun yang diinginkan.
1. Atur format angka preset dari nilai preset yang tersedia.
1. Jelajahi sel data diagram dalam setiap seri dan atur format angka.
1. Simpan presentasi.
1. Atur format angka kustom.
1. Jelajahi sel data diagram dalam setiap seri dan atur format angka yang berbeda.
1. Simpan presentasi.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:
    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Atur format angka preset.
    # Jelajahi setiap seri diagram.
    for series in chart.chart_data.series:
        # Jelajahi setiap titik data dalam seri.
        for cell in series.data_points:
            # Atur format angka.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Simpan presentasi.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Format angka preset yang tersedia dan indeks yang bersesuaian tercantum di bawah ini.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Atur Tepi Bulat untuk Area Diagram**

Aspose.Slides for Python mendukung konfigurasi area diagram menggunakan properti `Chart.has_rounded_corners`.

1. Instansiasi objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Tambahkan diagram ke slide.
3. Atur jenis isi dan warna isi diagram.
4. Atur properti rounded-corners menjadi `True`.
5. Simpan presentasi yang telah dimodifikasi.

Contoh disediakan di bawah.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bisakah saya mengatur isi semi-transparan untuk kolom/area sambil mempertahankan batas tidak tembus pandang?**

Ya. Transparansi isi dan garis tepi diatur secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data dalam visualisasi yang padat.

**Bagaimana cara menangani label data ketika mereka saling tumpang tindih?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak esensial (misalnya kategori), atur offset/posisi label, tampilkan label hanya untuk titik yang dipilih jika diperlukan, atau ubah format menjadi "nilai + legenda".

**Bisakah saya menerapkan isian gradient atau pola pada seri?**

Ya. Baik isian padat maupun gradient/pola biasanya tersedia. Praktiknya, gunakan gradient secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.