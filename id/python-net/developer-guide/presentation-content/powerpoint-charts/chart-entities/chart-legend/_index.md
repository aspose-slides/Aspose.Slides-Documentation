---
title: Kustomisasi Legenda Diagram dalam Presentasi dengan Python
linktitle: Legenda Diagram
type: docs
url: /id/python-net/chart-legend/
keywords:
- legenda diagram
- posisi legenda
- ukuran font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kustomisasi legenda diagram dengan Aspose.Slides untuk Python melalui .NET untuk mengoptimalkan presentasi PowerPoint dan OpenDocument dengan pemformatan legenda yang disesuaikan."
---
## **Gambaran Umum**

Aspose.Slides untuk Python menyediakan kontrol penuh atas legenda diagram sehingga Anda dapat membuat label data menjadi jelas dan siap presentasi. Anda dapat menampilkan atau menyembunyikan legenda, memilih posisinya pada slide, dan menyesuaikan tata letak agar tidak tumpang tindih dengan area plot. API memungkinkan Anda menata teks dan penanda, menyempurnakan padding dan latar belakang, serta memformat batas dan isi agar sesuai dengan tema Anda. Pengembang juga dapat mengakses entri legenda individu untuk mengganti nama atau menyaringnya, memastikan hanya seri yang paling relevan yang ditampilkan. Dengan kemampuan ini, diagram Anda tetap dapat dibaca, konsisten, dan selaras dengan standar desain presentasi Anda.

## **Posisi Legenda**

Dengan menggunakan Aspose.Slides, Anda dapat dengan cepat mengontrol di mana legenda diagram muncul dan bagaimana ia sesuai dengan tata letak slide Anda. Pelajari cara menempatkan legenda secara tepat.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide.
1. Tambahkan diagram ke slide.
1. Atur properti legenda.
1. Simpan presentasi sebagai file PPTX.

Pada contoh di bawah ini, kami mengatur posisi dan ukuran legenda diagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Buat sebuah instance dari kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan referensi ke slide.
    slide = presentation.slides[0]

    # Tambahkan diagram kolom terkelompok ke slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Atur properti legenda.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Simpan presentasi ke disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Ukuran Font Legenda**

Legenda pada diagram harus dapat dibaca sebagaimana data yang dijelaskannya. Bagian ini menunjukkan cara menyesuaikan ukuran font legenda sehingga Anda dapat menyesuaikan tipografi presentasi Anda dan meningkatkan aksesibilitas.

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Buat sebuah diagram.
1. Atur ukuran font.
1. Simpan presentasi ke disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Ukuran Font untuk Entri Legenda**

Aspose.Slides memungkinkan Anda menyempurnakan tampilan legenda diagram dengan memformat entri individual. Contoh di bawah ini menunjukkan cara menargetkan item legenda tertentu dan mengatur propertinya tanpa mengubah sisa legenda.

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Buat sebuah diagram.
1. Akses sebuah entri legenda.
1. Atur properti entri.
1. Simpan presentasi ke disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
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

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bisakah saya mengaktifkan legenda sehingga diagram secara otomatis mengalokasikan ruang untuknya alih-alih menimpanya?**

Ya. Gunakan mode non-overlay ([overlay](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/legend/overlay/) = `false`); dalam hal ini, area plot akan menyusut untuk menampung legenda.

**Bisakah saya membuat label legenda multi-baris?**

Ya. Label panjang secara otomatis akan dibungkus ketika ruang tidak cukup; pemutusan baris paksa didukung melalui karakter baris baru dalam nama seri.

**Bagaimana cara membuat legenda mengikuti skema warna tema presentasi?**

Jangan menetapkan warna/isi/font secara eksplisit untuk legenda atau teksnya. Mereka akan mewarisi dari tema dan diperbarui secara otomatis ketika desain berubah.