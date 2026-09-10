---
title: Sesuaikan Tabel Data Grafik dalam Presentasi Menggunakan Python
linktitle: Tabel Data
type: docs
url: /id/python-java/chart-data-table/
keywords:
- data grafik
- tabel data
- properti font
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Sesuaikan tabel data grafik dalam Python untuk PPT dan PPTX dengan Aspose.Slides untuk Python melalui Java guna meningkatkan efisiensi dan daya tarik dalam presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan tabel data grafik di Aspose.Slides. Ini menunjukkan cara menampilkan tabel data untuk sebuah grafik dan menyesuaikan pemformatan teksnya dengan mengatur properti font seperti gaya tebal dan tinggi font. Contoh ini memperagakan pembuatan presentasi, menambahkan grafik, mengaktifkan tabel data grafik, menerapkan pengaturan font, dan menyimpan presentasi yang diperbarui.

Ini juga mencakup jawaban singkat untuk pertanyaan umum tentang menampilkan kunci legenda di tabel data grafik, mempertahankan tabel data saat mengekspor, bekerja dengan grafik yang dimuat dari presentasi atau templat yang ada, dan mengidentifikasi grafik dimana tabel data diaktifkan.

## **Atur Properti Font untuk Tabel Data Grafik**

Aspose.Slides for Python via Java memungkinkan Anda menampilkan tabel data sebuah grafik dan mengubah properti font teksnya.

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tambahkan grafik ke slide.
1. Tampilkan tabel data grafik.
1. Atur gaya tebal dan tinggi font teks tabel data.
1. Simpan presentasi yang dimodifikasi.

Contoh berikut memperagakan langkah-langkah ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Buat presentasi kosong.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat menampilkan kunci legenda kecil di samping nilai dalam tabel data grafik?**

Ya. Tabel data mendukung [kunci legenda](https://reference.aspose.com/slides/id/python-java/aspose.slides/datatable/#setShowLegendKey), dan Anda dapat mengaktifkan atau menonaktifkannya.

**Apakah tabel data akan dipertahankan saat mengekspor presentasi ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides merender grafik sebagai bagian dari slide, sehingga [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/id/python-java/convert-powerpoint-to-html/)/[gambar](/slides/id/python-java/convert-powerpoint-to-png/) yang diekspor mencakup grafik beserta tabel datanya.

**Apakah tabel data didukung untuk grafik yang berasal dari file templat?**

Ya. Untuk setiap grafik yang dimuat dari presentasi atau templat yang ada, Anda dapat memeriksa dan mengubah apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#hasDataTable) menggunakan properti grafik.

**Bagaimana cara cepat menemukan grafik mana dalam sebuah file yang memiliki tabel data diaktifkan?**

Periksa properti setiap grafik yang menunjukkan apakah tabel data [ditampilkan](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#hasDataTable) dan iterasi melalui slide untuk mengidentifikasi grafik yang diaktifkan.