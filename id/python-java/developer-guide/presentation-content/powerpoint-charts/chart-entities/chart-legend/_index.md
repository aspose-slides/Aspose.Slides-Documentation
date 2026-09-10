---
title: Sesuaikan Legenda Diagram dalam Presentasi Menggunakan Python
linktitle: Legenda Diagram
type: docs
url: /id/python-java/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Sesuaikan legenda diagram dengan Aspose.Slides untuk Python via Java untuk mengoptimalkan presentasi PowerPoint dengan pemformatan legenda yang disesuaikan."
---
## **Ikhtisar**

Aspose.Slides menyediakan opsi untuk menyesuaikan legenda diagram dalam presentasi PowerPoint. Artikel ini menunjukkan cara memposisikan dan mengubah ukuran legenda, mengatur ukuran font untuk seluruh legenda, dan menerapkan pemformatan pada entri legenda individual.

Artikel ini juga mencakup beberapa perilaku terkait dalam FAQ, termasuk menggunakan mode non-overlay sehingga area plot memberi ruang untuk legenda, memungkinkan label legenda panjang membungkus atau menggunakan pemisah baris, serta membiarkan pemformatan legenda mewarisi dari tema presentasi ketika pengaturan teks dan isi eksplisit tidak diterapkan.

## **Penempatan Legenda**

Untuk mengatur properti legenda, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide.
1. Tambahkan diagram ke slide.
1. Atur properti legenda.
1. Simpan presentasi sebagai file PPTX.

Contoh berikut mengatur posisi dan ukuran legenda diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Buat presentasi kosong.
presentation = Presentation()
try:
    # Dapatkan referensi ke slide.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan diagram kolom berkelompok ke slide.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Atur properti legenda.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Simpan presentasi ke disk.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Ukuran Font Legenda**

Aspose.Slides untuk Python via Java memungkinkan Anda mengatur ukuran font legenda. Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Buat diagram default.
1. Atur ukuran font.
1. Atur nilai minimum sumbu.
1. Atur nilai maksimum sumbu.
1. Simpan presentasi ke disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Buat presentasi kosong.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Ukuran Font Entri Legenda Individual**

Aspose.Slides untuk Python via Java memungkinkan Anda mengatur ukuran font entri legenda individual. Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Buat diagram default.
1. Akses entri legenda.
1. Atur ukuran font.
1. Simpan presentasi ke disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Buat presentasi kosong.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengaktifkan legenda sehingga diagram secara otomatis menyediakan ruang untuknya alih‑alih menimpanya?**

Ya. Gunakan [setOverlay](https://reference.aspose.com/slides/id/python-java/aspose.slides/legend/#setOverlay) dengan `False` untuk mengaktifkan mode non-overlay; dalam kasus ini, area plot akan menyusut untuk menampung legenda.

**Apakah saya dapat membuat label legenda multi‑baris?**

Ya. Label panjang secara otomatis akan membungkus ketika ruang tidak cukup; pemisah baris paksa didukung melalui karakter newline dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan mengatur warna, isian, atau font secara eksplisit untuk legenda atau teksnya. Maka legenda akan mewarisi dari tema dan akan diperbarui dengan benar ketika desain berubah.