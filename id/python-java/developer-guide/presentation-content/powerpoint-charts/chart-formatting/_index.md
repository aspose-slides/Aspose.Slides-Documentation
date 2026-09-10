---
title: Format Grafik Presentasi dalam Python
linktitle: Pemformatan Grafik
type: docs
weight: 60
url: /id/python-java/chart-formatting/
keywords:
- format grafik
- pemformatan grafik
- entitas grafik
- properti grafik
- pengaturan grafik
- opsi grafik
- properti font
- garis tepi melengkung
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari pemformatan grafik di Aspose.Slides untuk Python via Java dan tingkatkan presentasi PowerPoint Anda dengan gaya profesional yang menarik perhatian."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memformat grafik dalam presentasi PowerPoint dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyesuaikan elemen grafik utama seperti sumbu, garis kisi, judul, legenda, area plot, dan isi dinding untuk meningkatkan tampilan dan keterbacaan data grafik.

Artikel ini juga memperagakan cara mengatur properti font untuk teks grafik, menerapkan format numerik preset dan kustom pada data grafik, serta mengaktifkan sudut melengkung untuk area grafik. Bersama-sama, contoh-contoh ini menunjukkan cara mengendalikan gaya visual dan penyajian data grafik dalam sebuah presentasi.

## **Format Entitas Grafik**
Aspose.Slides for Python via Java memungkinkan pengembang menambahkan grafik kustom ke slide mereka dari awal. Artikel ini menjelaskan cara memformat berbagai entitas grafik termasuk sumbu kategori dan nilai.

Aspose.Slides for Python via Java menyediakan API sederhana untuk mengelola berbagai entitas grafik dan memformatnya menggunakan nilai kustom:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Akses slide berdasarkan indeksnya.
1. Tambahkan grafik tipe yang diinginkan dengan data default (contoh ini menggunakan [ChartType.LineWithMarkers](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Akses sumbu nilai grafik dan atur properti berikut:
   1. Atur **Line format** untuk garis kisi utama sumbu nilai.
   1. Atur **Line format** untuk garis kisi minor sumbu nilai.
   1. Atur **Number Format** untuk sumbu nilai.
   1. Atur **minimum, maximum, major, and minor units** untuk sumbu nilai.
   1. Atur **Text Properties** untuk data sumbu nilai.
   1. Atur **Title** untuk sumbu nilai.
1. Akses sumbu kategori grafik dan atur properti berikut:
   1. Atur **Line format** untuk garis kisi utama sumbu kategori.
   1. Atur **Line format** untuk garis kisi minor sumbu kategori.
   1. Atur **Text Properties** untuk data sumbu kategori.
   1. Atur **Title** untuk sumbu kategori.
   1. Atur **Label Positioning** untuk sumbu kategori.
   1. Atur **Rotation Angle** untuk label sumbu kategori.
1. Akses legenda grafik dan atur **text properties**‑nya.
1. Tampilkan legenda grafik tanpa menutupi grafik.
1. Akses **secondary value axis** grafik dan atur properti berikut:
   1. Aktifkan **value axis** sekunder.
   1. Atur **Line Format** untuk sumbu nilai sekunder.
   1. Atur **Number Format** untuk sumbu nilai sekunder.
   1. Atur **minimum, maximum, major, and minor units** untuk sumbu nilai sekunder.
1. Plot seri grafik pertama pada sumbu nilai sekunder.
1. Atur warna isi back wall grafik.
1. Atur warna isi area plot grafik.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Buat sebuah instance dari kelas Presentation
presentation = Presentation()
try:
    # Akses slide pertama
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan grafik contoh
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Setel Judul Grafik
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Setel format garis kisi utama untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Setel format garis kisi minor untuk sumbu nilai
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Setel format angka sumbu nilai
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Setel nilai maksimum dan minimum grafik
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Setel Properti Teks Sumbu Nilai
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Setel judul sumbu nilai
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Setel format garis kisi utama untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Setel format garis kisi minor untuk sumbu Kategori
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Setel Properti Teks Sumbu Kategori
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Setel Judul Kategori
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Setel posisi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Setel sudut rotasi label sumbu kategori
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Setel Properti Teks Legenda
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Tampilkan legenda grafik tanpa menutupi grafik

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Setel sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Setel format angka sumbu nilai sekunder
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Setel nilai maksimum dan minimum grafik
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Setel warna dinding belakang grafik
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Setel warna area plot
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Simpan presentasi
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Properti Font untuk Grafik**
Aspose.Slides for Python via Java mendukung pengaturan properti font untuk grafik. Ikuti langkah‑langkah berikut untuk mengatur properti font:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Tambahkan grafik ke slide.
- Atur tinggi font.
- Simpan presentasi yang telah dimodifikasi.

Contoh berikut memperagakan langkah‑langkah tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Format Numerik**
Aspose.Slides for Python via Java menyediakan API sederhana untuk mengelola format data grafik:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Akses slide berdasarkan indeksnya.
1. Tambahkan grafik tipe yang diinginkan dengan data default (contoh ini menggunakan [ChartType.ClusteredColumn](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Atur format angka preset dari nilai preset yang tersedia.
1. Iterasi melalui sel data pada setiap seri grafik dan atur format angka mereka.
1. Simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation
presentation = Presentation()
try:
    # Akses slide presentasi pertama
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan grafik kolom berkelompok default
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Akses koleksi seri grafik
    chart_series_collection = chart.getChartData().getSeries()

    # Iterasi melalui setiap seri grafik
    for chart_series in chart_series_collection:
        # Iterasi melalui setiap titik data dalam seri
        for data_point in chart_series.getDataPoints():
            # Atur format angka
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Simpan presentasi
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Format angka preset yang tersedia dan indeksnya terdaftar di bawah ini:

|**0**|Umum|
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

## **Atur Sudut Melengkung pada Area Grafik**
Aspose.Slides for Python via Java mendukung sudut melengkung untuk area grafik melalui metode [hasRoundedCorners](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#hasRoundedCorners) dan [setRoundedCorners](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setRoundedCorners) pada kelas [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/).

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tambahkan grafik ke slide.
1. Atur tipe dan gaya isian garis batas grafik.
1. Aktifkan sudut melengkung.
1. Simpan presentasi yang telah dimodifikasi.

Contoh berikut memperagakan langkah‑langkah tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengatur isian semi-transparan untuk kolom/area sambil menjaga batas tetap opak?**

Ya. Transparansi isian dan outline diatur secara terpisah. Ini berguna untuk meningkatkan keterbacaan kisi dan data pada visualisasi yang padat.

**Bagaimana saya menangani label data ketika mereka saling menumpuk?**

Kurangi ukuran font, nonaktifkan komponen label yang tidak penting (misalnya kategori), atur offset/posisi label, tampilkan label hanya untuk titik yang dipilih bila perlu, atau ubah format menjadi "nilai + legenda".

**Apakah saya dapat menerapkan isian gradien atau pola pada seri?**

Ya. Baik isian solid maupun gradien/pola biasanya tersedia. Pada praktiknya, gunakan gradien secara hemat dan hindari kombinasi yang mengurangi kontras dengan kisi dan teks.