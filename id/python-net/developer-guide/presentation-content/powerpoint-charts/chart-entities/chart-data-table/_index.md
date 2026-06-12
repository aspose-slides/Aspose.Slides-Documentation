---
title: Sesuaikan Tabel Data Diagram di Python
linktitle: Tabel Data
type: docs
url: /id/python-net/chart-data-table/
keywords:
- data diagram
- tabel data
- properti font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Sesuaikan tabel data diagram di Python untuk PPT, PPTX, dan ODP dengan Aspose.Slides untuk meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan tabel data diagram di Aspose.Slides. Ini menunjukkan cara menampilkan tabel data untuk diagram dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contohnya mendemonstrasikan memuat presentasi, menambahkan diagram, mengaktifkan tabel data diagram, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

Ini juga mencakup jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda di tabel data diagram, mempertahankan tabel data saat ekspor, bekerja dengan diagram yang dimuat dari presentasi atau templat yang ada, dan mengidentifikasi diagram di mana tabel data diaktifkan.

## **Atur Properti Font untuk Tabel Data Diagram**
Aspose.Slides for Python via .NET menyediakan dukungan untuk mengubah warna kategori dalam warna seri.

1. Membuat instance objek kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Menambahkan diagram pada slide.
1. Mengatur tabel diagram.
1. Mengatur tinggi font.
1. Menyimpan presentasi yang dimodifikasi.

Berikut contoh sampel yang diberikan.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di sebelah nilai dalam tabel data diagram?**

Ya. Tabel data mendukung [legend keys](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datatable/show_legend_key/), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender diagram sebagai bagian dari slide, sehingga [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/id/python-net/convert-powerpoint-to-html/)/[image](/slides/id/python-net/convert-powerpoint-to-png/) yang diekspor mencakup diagram dengan tabel datanya.

**Apakah tabel data didukung untuk diagram yang berasal dari file template?**

Ya. Untuk diagram apa pun yang dimuat dari presentasi atau template yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [is shown](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/) menggunakan properti diagram.

**Bagaimana cara cepat menemukan diagram mana dalam file yang memiliki tabel data diaktifkan?**

Periksa properti setiap diagram yang menunjukkan apakah tabel data [is shown](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/has_data_table/) dan iterasi melalui slide untuk mengidentifikasi diagram yang mengaktifkannya.